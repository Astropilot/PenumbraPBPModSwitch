namespace PenumbraPBPModSwitch
{
    partial class NodeSelectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NodeSelectionForm));
            this.closeButton = new System.Windows.Forms.Button();
            this.nodesFilesList = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(253, 117);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 26);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Ok";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // nodesFilesList
            // 
            this.nodesFilesList.CheckOnClick = true;
            this.nodesFilesList.FormattingEnabled = true;
            this.nodesFilesList.Location = new System.Drawing.Point(3, 2);
            this.nodesFilesList.Name = "nodesFilesList";
            this.nodesFilesList.Size = new System.Drawing.Size(325, 109);
            this.nodesFilesList.TabIndex = 1;
            this.nodesFilesList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.nodesFilesList_ItemCheck);
            // 
            // NodeSelectionForm
            // 
            this.AcceptButton = this.closeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 146);
            this.Controls.Add(this.nodesFilesList);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NodeSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nodes Files Selection";
            this.Load += new System.EventHandler(this.NodeSelectionForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.CheckedListBox nodesFilesList;
    }
}