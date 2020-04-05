using Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PenumbraPBPModSwitch
{
    public partial class NodeSelectionForm : Form
    {
        private Dictionary<string, MemoryFileInformation> NodesFiles;
        private Mem MemLib;

        public NodeSelectionForm(Dictionary<string, MemoryFileInformation> nodesFiles, Mem memlib)
        {
            InitializeComponent();

            NodesFiles = nodesFiles;
            MemLib = memlib;
        }

        private void NodeSelectionForm_Load(object sender, EventArgs e)
        {
            foreach (string file in NodesFiles.Keys)
            {
                this.nodesFilesList.Items.Add(file, NodesFiles[file].IsModActive);
            }
        }

        private void nodesFilesList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                string mapName = nodesFilesList.GetItemText(nodesFilesList.Items[e.Index]);

                NodesFiles[mapName].IsModActive = nodesFilesList.GetItemChecked(e.Index);

                MemLib.writeMemory(Convert.ToString(NodesFiles[mapName].MemoryPtr, 16), "bytes", NodesFiles[mapName].IsModActive ? MainForm.modsInAoB : MainForm.mapsInAoB);
            }));
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
