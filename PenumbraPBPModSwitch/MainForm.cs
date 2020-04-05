using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using Memory;

namespace PenumbraPBPModSwitch
{
    public partial class MainForm : Form
    {
        private Mem MemLib;
        private string[] MapsFileWhitelist;
        private Dictionary<string, MapFileInformation> MapsInfo;

        public static string mapsInAoB = "0x6D 0x61 0x70 0x73";
        public static string modsInAoB = "0x6D 0x6F 0x64 0x73";

        #region Utils

        private void hideCheckboxInDataGridView(int rowIndex, int columnIndex)
        {
            // Dirty trick to remove a checkbox by replacing it with a read-only textbox.
            mapsSelector.Rows[rowIndex].Cells[columnIndex].Value = false;
            mapsSelector.Rows[rowIndex].Cells[columnIndex] = new DataGridViewTextBoxCell();
            mapsSelector.Rows[rowIndex].Cells[columnIndex].ReadOnly = true;
            mapsSelector.Rows[rowIndex].Cells[columnIndex].Value = "";
        }

        #endregion

        public MainForm()
        {
            InitializeComponent();

            MemLib = new Mem();
            MapsFileWhitelist = new[] { "dae", "hps", "nodes" };
            MapsInfo = new Dictionary<string, MapFileInformation>();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!MemLib.OpenProcess("penumbra"))
            {
                statusLabel.Text = "Error: Can't find the game!";
            }
            else
            {
                statusLabel.Text = "Loading maps...";
                progressBar.Visible = true;

                backgroundWorker1.RunWorkerAsync();
            }
        }

        private async void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var mapsFiles = CommonUtils.FilterFiles(@"maps\", MapsFileWhitelist).Select(f => Path.GetFileName(f));
            var moddedFiles = CommonUtils.FilterFiles(@"mods\", MapsFileWhitelist).Select(f => Path.GetFileName(f));

            foreach (var mapsFile in mapsFiles)
            {
                // Is there is no modded version available (same name) we skip it
                if (!moddedFiles.Contains(Path.GetFileName(mapsFile))) continue;

                string filePrefix = Path.GetFileNameWithoutExtension(mapsFile);
                string fileExt = Path.GetExtension(mapsFile);
                string fullFileName = filePrefix + fileExt;

                if (fileExt.Equals(".nodes")) // Matching nodes files that have a suffix (nodes files)
                    filePrefix = filePrefix.Substring(0, filePrefix.LastIndexOf("_"));

                if (!MapsInfo.ContainsKey(filePrefix)) // New prefix entry
                {
                    var scanInfo = new Dictionary<string, long>();
                    var scanMaps = await MemLib.AoBScan(0x00400000, 0x0FFFFFFF, CommonUtils.StringToAoB("maps/" + filePrefix), true, false);

                    // We scan every string containing the prefix (.dae, .hps and .nodes files in memory)

                    foreach (var scanMap in scanMaps)
                    {
                        string str = MemLib.readString(Convert.ToString(scanMap, 16), "", 100);

                        str = str.Substring(5); // Removing 'maps/' part

                        scanInfo.Add(str, scanMap);
                    }

                    MapsInfo.Add(filePrefix, new MapFileInformation(filePrefix, scanInfo));
                }

                // If scan failed we skip this file
                if (!MapsInfo[filePrefix].ScanResults.ContainsKey(fullFileName)) continue;

                switch (fileExt)
                {
                    case ".dae": // Dealing with Map File
                        MapsInfo[filePrefix].MapFile.FullName = fullFileName;
                        MapsInfo[filePrefix].MapFile.MemoryPtr = MapsInfo[filePrefix].ScanResults[fullFileName];
                        break;
                    case ".hps": // Dealing with Program File
                        MapsInfo[filePrefix].ProgramFile.FullName = fullFileName;
                        MapsInfo[filePrefix].ProgramFile.MemoryPtr = MapsInfo[filePrefix].ScanResults[fullFileName];
                        break;
                    case ".nodes": // Dealing with Nodes File (can have multiples files for a prefix)
                        MemoryFileInformation memoryFileInformation = new MemoryFileInformation();

                        memoryFileInformation.FullName = fullFileName;
                        memoryFileInformation.MemoryPtr = MapsInfo[filePrefix].ScanResults[fullFileName];
                        MapsInfo[filePrefix].NodesFiles.Add(fullFileName, memoryFileInformation);
                        break;
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (KeyValuePair<string, MapFileInformation> prefixMap in MapsInfo)
            {
                // In the case of a prefix with no match in memory, we skip it
                if (!prefixMap.Value.MapFile.isValidPtr() && !prefixMap.Value.ProgramFile.isValidPtr() && prefixMap.Value.NodesFiles.Count == 0) continue;

                DataGridViewRow row = (DataGridViewRow)mapsSelector.RowTemplate.Clone();
                int rowIndex;

                row.CreateCells(mapsSelector, prefixMap.Key, false, false, false, false);
                rowIndex = mapsSelector.Rows.Add(row);

                // Deletion of checkboxes in case there is no match in memory
                if (!prefixMap.Value.MapFile.isValidPtr())
                {
                    hideCheckboxInDataGridView(rowIndex, 2);
                }
                if (!prefixMap.Value.ProgramFile.isValidPtr())
                {
                    hideCheckboxInDataGridView(rowIndex, 3);
                }
                if (prefixMap.Value.NodesFiles.Count == 0)
                {
                    hideCheckboxInDataGridView(rowIndex, 4);
                }
            }

            cacheCheckBox.Enabled = true;
            cacheCheckBox.Checked = true;
            statusLabel.Text = "Everything is ready!";
            progressBar.Visible = false;
        }

        private void mapsSelector_OnCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex != -1) // Select All Column
            {
                string mapPrefix = Convert.ToString(mapsSelector.Rows[e.RowIndex].Cells[0].Value);
                bool isChecked = (bool)mapsSelector.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                string aob = isChecked ? modsInAoB : mapsInAoB;

                mapsSelector.CellValueChanged -= mapsSelector_OnCellValueChanged;

                if (MapsInfo[mapPrefix].MapFile.isValidPtr())
                {
                    MapsInfo[mapPrefix].MapFile.IsModActive = isChecked;
                    mapsSelector.Rows[e.RowIndex].Cells[2].Value = isChecked;
                    MemLib.writeMemory(Convert.ToString(MapsInfo[mapPrefix].MapFile.MemoryPtr, 16), "bytes", aob);
                }
                if (MapsInfo[mapPrefix].ProgramFile.isValidPtr())
                {
                    MapsInfo[mapPrefix].ProgramFile.IsModActive = isChecked;
                    mapsSelector.Rows[e.RowIndex].Cells[3].Value = isChecked;
                    MemLib.writeMemory(Convert.ToString(MapsInfo[mapPrefix].ProgramFile.MemoryPtr, 16), "bytes", aob);
                }
                if (MapsInfo[mapPrefix].NodesFiles.Count > 0)
                {
                    mapsSelector.Rows[e.RowIndex].Cells[4].Value = isChecked ? CheckState.Checked : CheckState.Unchecked;

                    foreach (string nodesFile in MapsInfo[mapPrefix].NodesFiles.Keys)
                    {
                        MapsInfo[mapPrefix].NodesFiles[nodesFile].IsModActive = isChecked;
                        MemLib.writeMemory(Convert.ToString(MapsInfo[mapPrefix].NodesFiles[nodesFile].MemoryPtr, 16), "bytes", aob);
                    }
                }
                mapsSelector.CellValueChanged += mapsSelector_OnCellValueChanged;

            } else if ((e.ColumnIndex == 2 || e.ColumnIndex == 3) && e.RowIndex != -1 && mapsSelector.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "") // Map and Program Column
            {
                string mapPrefix = Convert.ToString(mapsSelector.Rows[e.RowIndex].Cells[0].Value);
                long memoryPtr = (e.ColumnIndex == 2 ? MapsInfo[mapPrefix].MapFile.MemoryPtr : MapsInfo[mapPrefix].ProgramFile.MemoryPtr);
                bool isChecked = (bool)mapsSelector.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (e.ColumnIndex == 2)
                {
                    MapsInfo[mapPrefix].MapFile.IsModActive = isChecked;
                } else
                {
                    MapsInfo[mapPrefix].ProgramFile.IsModActive = isChecked;
                }

                MemLib.writeMemory(Convert.ToString(memoryPtr, 16), "bytes", isChecked ? modsInAoB : mapsInAoB);
            }
            else if (e.ColumnIndex == 4 && e.RowIndex != -1 && mapsSelector.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "") // Nodes Column
            {
                string mapPrefix = Convert.ToString(mapsSelector.Rows[e.RowIndex].Cells[0].Value);
                NodeSelectionForm nodeSelectionForm = new NodeSelectionForm(MapsInfo[mapPrefix].NodesFiles, MemLib);

                nodeSelectionForm.ShowDialog();

                // We change the state of the checkbox according to the number of modded files enabled
                mapsSelector.CellValueChanged -= mapsSelector_OnCellValueChanged;
                if (MapsInfo[mapPrefix].NodesFilesActiveCount() == 0)
                {
                    mapsSelector.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = CheckState.Unchecked;
                }
                else if (MapsInfo[mapPrefix].NodesFilesActiveCount() == MapsInfo[mapPrefix].NodesFiles.Count)
                {
                    mapsSelector.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = CheckState.Checked;
                }
                else
                {
                    mapsSelector.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = CheckState.Indeterminate;
                }
                mapsSelector.CellValueChanged += mapsSelector_OnCellValueChanged;
            }
        }

        private void cacheCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            /*
             * We prevent the use of the game's cache by providing it with a wrong path. The game continues to run but is not able to cache.
             */
            MemLib.writeMemory("base+2EB9D0", "string", cacheCheckBox.Checked ? "core/cuche/" : "core/cache/");
        }

        private void mapsSelector_OnCellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            // A trick to improve the detection of the "Checked" event in the DataGridView checkboxes
            if (e.ColumnIndex > 0 && e.RowIndex != -1)
            {
                mapsSelector.EndEdit();
            }
        }

        private void mapsSelector_SelectionChanged(Object sender, EventArgs e)
        {
            // A trick to prevent the user to select a row in the DataGridView (we only want checkboxes to be selectionnable)
            mapsSelector.ClearSelection();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MemLib.closeProcess();
        }

        private void aboutLabel_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void selectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in mapsSelector.Rows)
            {
                row.Cells[1].Value = true;
            }
        }

        private void unselectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in mapsSelector.Rows)
            {
                row.Cells[1].Value = false;
            }
        }

        private void selectMaps_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in mapsSelector.Rows)
            {
                if (MapsInfo[Convert.ToString(row.Cells[0].Value)].MapFile.isValidPtr())
                {
                    row.Cells[2].Value = true;
                }
            }
        }

        private void unselectMaps_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in mapsSelector.Rows)
            {
                if (MapsInfo[Convert.ToString(row.Cells[0].Value)].MapFile.isValidPtr())
                {
                    row.Cells[2].Value = false;
                }
            }
        }

        private void selectPrograms_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in mapsSelector.Rows)
            {
                if (MapsInfo[Convert.ToString(row.Cells[0].Value)].ProgramFile.isValidPtr())
                {
                    row.Cells[3].Value = true;
                }
            }
        }

        private void unselectPrograms_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in mapsSelector.Rows)
            {
                if (MapsInfo[Convert.ToString(row.Cells[0].Value)].ProgramFile.isValidPtr())
                {
                    row.Cells[3].Value = false;
                }
            }
        }

        private void selectNodes_Click(object sender, EventArgs e)
        {
            mapsSelector.CellValueChanged -= mapsSelector_OnCellValueChanged;
            foreach (DataGridViewRow row in mapsSelector.Rows) {
                string mapPrefix = Convert.ToString(mapsSelector.Rows[row.Index].Cells[0].Value);

                if (MapsInfo[mapPrefix].NodesFiles.Count > 0)
                {
                    mapsSelector.Rows[row.Index].Cells[4].Value = CheckState.Checked;

                    foreach (string nodesFile in MapsInfo[mapPrefix].NodesFiles.Keys)
                    {
                        MapsInfo[mapPrefix].NodesFiles[nodesFile].IsModActive = true;
                        MemLib.writeMemory(Convert.ToString(MapsInfo[mapPrefix].NodesFiles[nodesFile].MemoryPtr, 16), "bytes", modsInAoB);
                    }
                }
            }
            mapsSelector.CellValueChanged += mapsSelector_OnCellValueChanged;
        }

        private void unselectNodes_Click(object sender, EventArgs e)
        {
            mapsSelector.CellValueChanged -= mapsSelector_OnCellValueChanged;
            foreach (DataGridViewRow row in mapsSelector.Rows)
            {
                string mapPrefix = Convert.ToString(mapsSelector.Rows[row.Index].Cells[0].Value);

                if (MapsInfo[mapPrefix].NodesFiles.Count > 0)
                {
                    mapsSelector.Rows[row.Index].Cells[4].Value = CheckState.Unchecked;

                    foreach (string nodesFile in MapsInfo[mapPrefix].NodesFiles.Keys)
                    {
                        MapsInfo[mapPrefix].NodesFiles[nodesFile].IsModActive = false;
                        MemLib.writeMemory(Convert.ToString(MapsInfo[mapPrefix].NodesFiles[nodesFile].MemoryPtr, 16), "bytes", mapsInAoB);
                    }
                }
            }
            mapsSelector.CellValueChanged += mapsSelector_OnCellValueChanged;
        }
    }
}
