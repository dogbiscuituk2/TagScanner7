namespace TagScanner.Forms
{
    partial class FileChecksDialog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileChecksDialog));
            this.TreeView = new System.Windows.Forms.TreeView();
            this.SchemaPopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SchemaPopupAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.SchemaPopupEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.SchemaPopupDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeViewStateImageList = new System.Windows.Forms.ImageList(this.components);
            this.FileFilterPanel = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.edFilespecs = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbDontShowThisAgain = new System.Windows.Forms.CheckBox();
            this.FileFilterControl = new TagScanner.Controls.FileFilterControl();
            this.SchemaPopupMenu.SuspendLayout();
            this.FileFilterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TreeView
            // 
            this.TreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TreeView.ContextMenuStrip = this.SchemaPopupMenu;
            this.TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeView.HideSelection = false;
            this.TreeView.Location = new System.Drawing.Point(0, 0);
            this.TreeView.Margin = new System.Windows.Forms.Padding(4);
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size(388, 235);
            this.TreeView.StateImageList = this.TreeViewStateImageList;
            this.TreeView.TabIndex = 0;
            // 
            // SchemaPopupMenu
            // 
            this.SchemaPopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SchemaPopupAdd,
            this.SchemaPopupEdit,
            this.SchemaPopupDelete});
            this.SchemaPopupMenu.Name = "PopupMenu";
            this.SchemaPopupMenu.Size = new System.Drawing.Size(108, 70);
            // 
            // SchemaPopupAdd
            // 
            this.SchemaPopupAdd.Name = "SchemaPopupAdd";
            this.SchemaPopupAdd.Size = new System.Drawing.Size(107, 22);
            this.SchemaPopupAdd.Text = "&Add...";
            this.SchemaPopupAdd.ToolTipText = "Add a new File Format";
            // 
            // SchemaPopupEdit
            // 
            this.SchemaPopupEdit.Name = "SchemaPopupEdit";
            this.SchemaPopupEdit.Size = new System.Drawing.Size(107, 22);
            this.SchemaPopupEdit.Text = "&Edit...";
            this.SchemaPopupEdit.ToolTipText = "Edit this File Format";
            // 
            // SchemaPopupDelete
            // 
            this.SchemaPopupDelete.Name = "SchemaPopupDelete";
            this.SchemaPopupDelete.Size = new System.Drawing.Size(107, 22);
            this.SchemaPopupDelete.Text = "&Delete";
            this.SchemaPopupDelete.ToolTipText = "Remove this File Format";
            // 
            // TreeViewStateImageList
            // 
            this.TreeViewStateImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeViewStateImageList.ImageStream")));
            this.TreeViewStateImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.TreeViewStateImageList.Images.SetKeyName(0, "frClear.png");
            this.TreeViewStateImageList.Images.SetKeyName(1, "frApply.png");
            this.TreeViewStateImageList.Images.SetKeyName(2, "frPartial.png");
            // 
            // FileFilterPanel
            // 
            this.FileFilterPanel.Controls.Add(this.FileFilterControl);
            this.FileFilterPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.FileFilterPanel.Location = new System.Drawing.Point(0, 0);
            this.FileFilterPanel.Name = "FileFilterPanel";
            this.FileFilterPanel.Size = new System.Drawing.Size(396, 345);
            this.FileFilterPanel.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(687, 4);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 27);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(595, 4);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 27);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(396, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TreeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(388, 345);
            this.splitContainer1.SplitterDistance = 235;
            this.splitContainer1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.edFilespecs);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(388, 106);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "`";
            // 
            // edFilespecs
            // 
            this.edFilespecs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.edFilespecs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edFilespecs.Location = new System.Drawing.Point(2, 20);
            this.edFilespecs.Multiline = true;
            this.edFilespecs.Name = "edFilespecs";
            this.edFilespecs.ReadOnly = true;
            this.edFilespecs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.edFilespecs.Size = new System.Drawing.Size(384, 84);
            this.edFilespecs.TabIndex = 0;
            this.edFilespecs.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbDontShowThisAgain);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 345);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 36);
            this.panel1.TabIndex = 0;
            // 
            // cbDontShowThisAgain
            // 
            this.cbDontShowThisAgain.AutoSize = true;
            this.cbDontShowThisAgain.Location = new System.Drawing.Point(12, 7);
            this.cbDontShowThisAgain.Name = "cbDontShowThisAgain";
            this.cbDontShowThisAgain.Size = new System.Drawing.Size(152, 21);
            this.cbDontShowThisAgain.TabIndex = 0;
            this.cbDontShowThisAgain.Text = "Don\'t show this again";
            this.cbDontShowThisAgain.UseVisualStyleBackColor = true;
            // 
            // FileFilterControl
            // 
            this.FileFilterControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileFilterControl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileFilterControl.Location = new System.Drawing.Point(0, 0);
            this.FileFilterControl.Margin = new System.Windows.Forms.Padding(4);
            this.FileFilterControl.Name = "FileFilterControl";
            this.FileFilterControl.Size = new System.Drawing.Size(396, 345);
            this.FileFilterControl.TabIndex = 0;
            // 
            // FileChecksDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(784, 381);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.FileFilterPanel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 420);
            this.Name = "FileChecksDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "File Options";
            this.SchemaPopupMenu.ResumeLayout(false);
            this.FileFilterPanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TreeView TreeView;
        public System.Windows.Forms.ImageList TreeViewStateImageList;
        public System.Windows.Forms.ContextMenuStrip SchemaPopupMenu;
        public System.Windows.Forms.ToolStripMenuItem SchemaPopupAdd;
        public System.Windows.Forms.ToolStripMenuItem SchemaPopupEdit;
        public System.Windows.Forms.ToolStripMenuItem SchemaPopupDelete;
        public System.Windows.Forms.Panel FileFilterPanel;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnOK;
        public Controls.FileFilterControl FileFilterControl;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox edFilespecs;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.CheckBox cbDontShowThisAgain;
    }
}