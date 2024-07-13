namespace TagScanner.Forms
{
    partial class FileOptionsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileOptionsDialog));
            this.TreeView = new System.Windows.Forms.TreeView();
            this.SchemaPopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SchemaPopupShowFormats = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.SchemaPopupAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.SchemaPopupEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.SchemaPopupDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.SchemaMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeViewStateImageList = new System.Windows.Forms.ImageList(this.components);
            this.RightPanel = new System.Windows.Forms.Panel();
            this.FilterPopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.FilterPopupShowFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.FilterPopupUseTimes = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterPopupUseAutocorrect = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.FileFilterControl = new TagScanner.Controls.FileFilterControl();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.SchemaPopupMenu.SuspendLayout();
            this.RightPanel.SuspendLayout();
            this.FilterPopupMenu.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TreeView
            // 
            this.TreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TreeView.ContextMenuStrip = this.SchemaPopupMenu;
            this.TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeView.HideSelection = false;
            this.TreeView.Location = new System.Drawing.Point(0, 24);
            this.TreeView.Margin = new System.Windows.Forms.Padding(4);
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size(388, 487);
            this.TreeView.StateImageList = this.TreeViewStateImageList;
            this.TreeView.TabIndex = 1;
            // 
            // SchemaPopupMenu
            // 
            this.SchemaPopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SchemaPopupShowFormats,
            this.toolStripMenuItem1,
            this.SchemaPopupAdd,
            this.SchemaPopupEdit,
            this.SchemaPopupDelete});
            this.SchemaPopupMenu.Name = "PopupMenu";
            this.SchemaPopupMenu.OwnerItem = this.SchemaMenu;
            this.SchemaPopupMenu.Size = new System.Drawing.Size(150, 98);
            // 
            // SchemaPopupShowFormats
            // 
            this.SchemaPopupShowFormats.Name = "SchemaPopupShowFormats";
            this.SchemaPopupShowFormats.Size = new System.Drawing.Size(149, 22);
            this.SchemaPopupShowFormats.Text = "Show &Formats";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(146, 6);
            // 
            // SchemaPopupAdd
            // 
            this.SchemaPopupAdd.Name = "SchemaPopupAdd";
            this.SchemaPopupAdd.Size = new System.Drawing.Size(149, 22);
            this.SchemaPopupAdd.Text = "&Add...";
            this.SchemaPopupAdd.ToolTipText = "Add a new File Format";
            // 
            // SchemaPopupEdit
            // 
            this.SchemaPopupEdit.Name = "SchemaPopupEdit";
            this.SchemaPopupEdit.Size = new System.Drawing.Size(149, 22);
            this.SchemaPopupEdit.Text = "&Edit...";
            this.SchemaPopupEdit.ToolTipText = "Edit this File Format";
            // 
            // SchemaPopupDelete
            // 
            this.SchemaPopupDelete.Name = "SchemaPopupDelete";
            this.SchemaPopupDelete.Size = new System.Drawing.Size(149, 22);
            this.SchemaPopupDelete.Text = "&Delete";
            this.SchemaPopupDelete.ToolTipText = "Remove this File Format";
            // 
            // SchemaMenu
            // 
            this.SchemaMenu.DropDown = this.SchemaPopupMenu;
            this.SchemaMenu.Name = "SchemaMenu";
            this.SchemaMenu.Size = new System.Drawing.Size(61, 20);
            this.SchemaMenu.Text = "&Schema";
            // 
            // TreeViewStateImageList
            // 
            this.TreeViewStateImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeViewStateImageList.ImageStream")));
            this.TreeViewStateImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.TreeViewStateImageList.Images.SetKeyName(0, "frClear.png");
            this.TreeViewStateImageList.Images.SetKeyName(1, "frApply.png");
            this.TreeViewStateImageList.Images.SetKeyName(2, "frPartial.png");
            // 
            // RightPanel
            // 
            this.RightPanel.ContextMenuStrip = this.FilterPopupMenu;
            this.RightPanel.Controls.Add(this.btnCancel);
            this.RightPanel.Controls.Add(this.btnOK);
            this.RightPanel.Controls.Add(this.FileFilterControl);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightPanel.Location = new System.Drawing.Point(388, 24);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(396, 487);
            this.RightPanel.TabIndex = 2;
            // 
            // FilterPopupMenu
            // 
            this.FilterPopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FilterPopupShowFilter,
            this.toolStripSeparator1,
            this.FilterPopupUseTimes,
            this.FilterPopupUseAutocorrect});
            this.FilterPopupMenu.Name = "PopupMenu";
            this.FilterPopupMenu.OwnerItem = this.FilterMenu;
            this.FilterPopupMenu.Size = new System.Drawing.Size(165, 76);
            // 
            // FilterPopupShowFilter
            // 
            this.FilterPopupShowFilter.Name = "FilterPopupShowFilter";
            this.FilterPopupShowFilter.Size = new System.Drawing.Size(164, 22);
            this.FilterPopupShowFilter.Text = "Show &Conditions";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // FilterPopupUseTimes
            // 
            this.FilterPopupUseTimes.Name = "FilterPopupUseTimes";
            this.FilterPopupUseTimes.Size = new System.Drawing.Size(164, 22);
            this.FilterPopupUseTimes.Text = "Use &Times";
            // 
            // FilterPopupUseAutocorrect
            // 
            this.FilterPopupUseAutocorrect.Name = "FilterPopupUseAutocorrect";
            this.FilterPopupUseAutocorrect.Size = new System.Drawing.Size(164, 22);
            this.FilterPopupUseAutocorrect.Text = "Use &Autocorrect";
            this.FilterPopupUseAutocorrect.ToolTipText = "Use Autocorrect to fix data validation errors";
            // 
            // FilterMenu
            // 
            this.FilterMenu.DropDown = this.FilterPopupMenu;
            this.FilterMenu.Name = "FilterMenu";
            this.FilterMenu.Size = new System.Drawing.Size(45, 20);
            this.FilterMenu.Text = "&Filter";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(304, 452);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 27);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(212, 452);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 27);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // FileFilterControl
            // 
            this.FileFilterControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.FileFilterControl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileFilterControl.Location = new System.Drawing.Point(0, 0);
            this.FileFilterControl.Margin = new System.Windows.Forms.Padding(4);
            this.FileFilterControl.Name = "FileFilterControl";
            this.FileFilterControl.Size = new System.Drawing.Size(396, 440);
            this.FileFilterControl.TabIndex = 0;
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SchemaMenu,
            this.FilterMenu});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(784, 24);
            this.MainMenu.TabIndex = 3;
            this.MainMenu.Text = "menuStrip1";
            // 
            // FileOptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 511);
            this.Controls.Add(this.TreeView);
            this.Controls.Add(this.RightPanel);
            this.Controls.Add(this.MainMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 550);
            this.Name = "FileOptionsDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "File Options";
            this.SchemaPopupMenu.ResumeLayout(false);
            this.RightPanel.ResumeLayout(false);
            this.FilterPopupMenu.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TreeView TreeView;
        public System.Windows.Forms.ImageList TreeViewStateImageList;
        public System.Windows.Forms.ContextMenuStrip SchemaPopupMenu;
        public System.Windows.Forms.ToolStripMenuItem SchemaPopupAdd;
        public System.Windows.Forms.ToolStripMenuItem SchemaPopupEdit;
        public System.Windows.Forms.ToolStripMenuItem SchemaPopupDelete;
        public System.Windows.Forms.Panel RightPanel;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnOK;
        public Controls.FileFilterControl FileFilterControl;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem SchemaPopupShowFormats;
        public System.Windows.Forms.ContextMenuStrip FilterPopupMenu;
        public System.Windows.Forms.ToolStripMenuItem FilterPopupShowFilter;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripMenuItem FilterPopupUseAutocorrect;
        public System.Windows.Forms.MenuStrip MainMenu;
        public System.Windows.Forms.ToolStripMenuItem SchemaMenu;
        public System.Windows.Forms.ToolStripMenuItem FilterMenu;
        public System.Windows.Forms.ToolStripMenuItem FilterPopupUseTimes;
    }
}