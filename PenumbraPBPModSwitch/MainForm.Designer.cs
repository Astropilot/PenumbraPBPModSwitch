namespace PenumbraPBPModSwitch
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cacheCheckBox = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.aboutLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.unselectNodes = new System.Windows.Forms.Button();
            this.selectNodes = new System.Windows.Forms.Button();
            this.unselectPrograms = new System.Windows.Forms.Button();
            this.selectPrograms = new System.Windows.Forms.Button();
            this.unselectMaps = new System.Windows.Forms.Button();
            this.selectMaps = new System.Windows.Forms.Button();
            this.unselectAll = new System.Windows.Forms.Button();
            this.selectAll = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.mapsSelector = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapsSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cacheCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(795, 94);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cache Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(430, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "It is strongly advised to leave this parameter checked when you want to use modif" +
    "ied files!";
            // 
            // cacheCheckBox
            // 
            this.cacheCheckBox.AutoSize = true;
            this.cacheCheckBox.Enabled = false;
            this.cacheCheckBox.Location = new System.Drawing.Point(309, 19);
            this.cacheCheckBox.Name = "cacheCheckBox";
            this.cacheCheckBox.Size = new System.Drawing.Size(176, 17);
            this.cacheCheckBox.TabIndex = 0;
            this.cacheCheckBox.Text = "Prevent the game to cache files";
            this.cacheCheckBox.UseVisualStyleBackColor = true;
            this.cacheCheckBox.CheckedChanged += new System.EventHandler(this.cacheCheckBox_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.progressBar,
            this.toolStripStatusLabel1,
            this.aboutLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 504);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(816, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(57, 17);
            this.statusLabel.Text = "Initialized";
            // 
            // progressBar
            // 
            this.progressBar.MarqueeAnimationSpeed = 50;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 16);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(704, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // aboutLabel
            // 
            this.aboutLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.aboutLabel.IsLink = true;
            this.aboutLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.aboutLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.aboutLabel.Name = "aboutLabel";
            this.aboutLabel.Size = new System.Drawing.Size(40, 17);
            this.aboutLabel.Text = "About";
            this.aboutLabel.Click += new System.EventHandler(this.aboutLabel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.unselectNodes);
            this.groupBox2.Controls.Add(this.selectNodes);
            this.groupBox2.Controls.Add(this.unselectPrograms);
            this.groupBox2.Controls.Add(this.selectPrograms);
            this.groupBox2.Controls.Add(this.unselectMaps);
            this.groupBox2.Controls.Add(this.selectMaps);
            this.groupBox2.Controls.Add(this.unselectAll);
            this.groupBox2.Controls.Add(this.selectAll);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.mapsSelector);
            this.groupBox2.Location = new System.Drawing.Point(12, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(795, 389);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Modded Files";
            // 
            // unselectNodes
            // 
            this.unselectNodes.Location = new System.Drawing.Point(697, 347);
            this.unselectNodes.Name = "unselectNodes";
            this.unselectNodes.Size = new System.Drawing.Size(91, 23);
            this.unselectNodes.TabIndex = 10;
            this.unselectNodes.Text = "Unselect Nodes";
            this.unselectNodes.UseVisualStyleBackColor = true;
            this.unselectNodes.Click += new System.EventHandler(this.unselectNodes_Click);
            // 
            // selectNodes
            // 
            this.selectNodes.Location = new System.Drawing.Point(608, 347);
            this.selectNodes.Name = "selectNodes";
            this.selectNodes.Size = new System.Drawing.Size(83, 23);
            this.selectNodes.TabIndex = 9;
            this.selectNodes.Text = "Select Nodes";
            this.selectNodes.UseVisualStyleBackColor = true;
            this.selectNodes.Click += new System.EventHandler(this.selectNodes_Click);
            // 
            // unselectPrograms
            // 
            this.unselectPrograms.Location = new System.Drawing.Point(473, 347);
            this.unselectPrograms.Name = "unselectPrograms";
            this.unselectPrograms.Size = new System.Drawing.Size(112, 23);
            this.unselectPrograms.TabIndex = 8;
            this.unselectPrograms.Text = "Unselect Programs";
            this.unselectPrograms.UseVisualStyleBackColor = true;
            this.unselectPrograms.Click += new System.EventHandler(this.unselectPrograms_Click);
            // 
            // selectPrograms
            // 
            this.selectPrograms.Location = new System.Drawing.Point(374, 347);
            this.selectPrograms.Name = "selectPrograms";
            this.selectPrograms.Size = new System.Drawing.Size(93, 23);
            this.selectPrograms.TabIndex = 7;
            this.selectPrograms.Text = "Select Programs";
            this.selectPrograms.UseVisualStyleBackColor = true;
            this.selectPrograms.Click += new System.EventHandler(this.selectPrograms_Click);
            // 
            // unselectMaps
            // 
            this.unselectMaps.Location = new System.Drawing.Point(265, 347);
            this.unselectMaps.Name = "unselectMaps";
            this.unselectMaps.Size = new System.Drawing.Size(86, 23);
            this.unselectMaps.TabIndex = 6;
            this.unselectMaps.Text = "Unselect Maps";
            this.unselectMaps.UseVisualStyleBackColor = true;
            this.unselectMaps.Click += new System.EventHandler(this.unselectMaps_Click);
            // 
            // selectMaps
            // 
            this.selectMaps.Location = new System.Drawing.Point(184, 347);
            this.selectMaps.Name = "selectMaps";
            this.selectMaps.Size = new System.Drawing.Size(75, 23);
            this.selectMaps.TabIndex = 5;
            this.selectMaps.Text = "Select Maps";
            this.selectMaps.UseVisualStyleBackColor = true;
            this.selectMaps.Click += new System.EventHandler(this.selectMaps_Click);
            // 
            // unselectAll
            // 
            this.unselectAll.Location = new System.Drawing.Point(87, 347);
            this.unselectAll.Name = "unselectAll";
            this.unselectAll.Size = new System.Drawing.Size(75, 23);
            this.unselectAll.TabIndex = 4;
            this.unselectAll.Text = "Unselect All";
            this.unselectAll.UseVisualStyleBackColor = true;
            this.unselectAll.Click += new System.EventHandler(this.unselectAll_Click);
            // 
            // selectAll
            // 
            this.selectAll.Location = new System.Drawing.Point(6, 347);
            this.selectAll.Name = "selectAll";
            this.selectAll.Size = new System.Drawing.Size(75, 23);
            this.selectAll.TabIndex = 3;
            this.selectAll.Text = "Select All";
            this.selectAll.UseVisualStyleBackColor = true;
            this.selectAll.Click += new System.EventHandler(this.selectAll_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(283, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Simply check the modded files you want to enable in game";
            // 
            // mapsSelector
            // 
            this.mapsSelector.AllowUserToAddRows = false;
            this.mapsSelector.AllowUserToDeleteRows = false;
            this.mapsSelector.AllowUserToResizeColumns = false;
            this.mapsSelector.AllowUserToResizeRows = false;
            this.mapsSelector.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.mapsSelector.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mapsSelector.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column2,
            this.Column3,
            this.Column4});
            this.mapsSelector.Location = new System.Drawing.Point(6, 52);
            this.mapsSelector.MultiSelect = false;
            this.mapsSelector.Name = "mapsSelector";
            this.mapsSelector.RowHeadersVisible = false;
            this.mapsSelector.Size = new System.Drawing.Size(782, 289);
            this.mapsSelector.TabIndex = 1;
            this.mapsSelector.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.mapsSelector_OnCellMouseUp);
            this.mapsSelector.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.mapsSelector_OnCellValueChanged);
            this.mapsSelector.SelectionChanged += new System.EventHandler(this.mapsSelector_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 200F;
            this.Column1.HeaderText = "Map File Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 50F;
            this.Column5.HeaderText = "Select All";
            this.Column5.Name = "Column5";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Map File (.dae)";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Program File (.hps)";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Nodes File (.nodes)";
            this.Column4.Name = "Column4";
            this.Column4.ThreeState = true;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 526);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Penumbra Black Plague - Modded Map Switch (Beta)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapsSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cacheCheckBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView mapsSelector;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button unselectNodes;
        private System.Windows.Forms.Button selectNodes;
        private System.Windows.Forms.Button unselectPrograms;
        private System.Windows.Forms.Button selectPrograms;
        private System.Windows.Forms.Button unselectMaps;
        private System.Windows.Forms.Button selectMaps;
        private System.Windows.Forms.Button unselectAll;
        private System.Windows.Forms.Button selectAll;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel aboutLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
    }
}

