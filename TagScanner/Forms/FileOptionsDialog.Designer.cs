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
            this.SchemaPopupAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.SchemaPopupEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.SchemaPopupDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.SchemaPopupShowFileFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeViewStateImageList = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.FilterPopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.FilterPopupUseAutocorrect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.FilterPopupShowFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.schemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterConditionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.showFormatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.showConditionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileFilterControl = new TagScanner.Controls.FileFilterControl();
            this.SchemaPopupMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.FilterPopupMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            this.TreeView.Size = new System.Drawing.Size(284, 297);
            this.TreeView.StateImageList = this.TreeViewStateImageList;
            this.TreeView.TabIndex = 1;
            // 
            // SchemaPopupMenu
            // 
            this.SchemaPopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SchemaPopupAdd,
            this.SchemaPopupEdit,
            this.SchemaPopupDelete,
            this.toolStripMenuItem1,
            this.SchemaPopupShowFileFilter});
            this.SchemaPopupMenu.Name = "PopupMenu";
            this.SchemaPopupMenu.Size = new System.Drawing.Size(217, 98);
            // 
            // SchemaPopupAdd
            // 
            this.SchemaPopupAdd.Name = "SchemaPopupAdd";
            this.SchemaPopupAdd.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.SchemaPopupAdd.Size = new System.Drawing.Size(216, 22);
            this.SchemaPopupAdd.Text = "&Add...";
            this.SchemaPopupAdd.ToolTipText = "Add a new File Format";
            // 
            // SchemaPopupEdit
            // 
            this.SchemaPopupEdit.Name = "SchemaPopupEdit";
            this.SchemaPopupEdit.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.SchemaPopupEdit.Size = new System.Drawing.Size(216, 22);
            this.SchemaPopupEdit.Text = "&Edit...";
            this.SchemaPopupEdit.ToolTipText = "Edit this File Format";
            // 
            // SchemaPopupDelete
            // 
            this.SchemaPopupDelete.Name = "SchemaPopupDelete";
            this.SchemaPopupDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.SchemaPopupDelete.Size = new System.Drawing.Size(216, 22);
            this.SchemaPopupDelete.Text = "&Delete";
            this.SchemaPopupDelete.ToolTipText = "Remove this File Format";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(213, 6);
            // 
            // SchemaPopupShowFileFilter
            // 
            this.SchemaPopupShowFileFilter.Name = "SchemaPopupShowFileFilter";
            this.SchemaPopupShowFileFilter.Size = new System.Drawing.Size(216, 22);
            this.SchemaPopupShowFileFilter.Text = "&Show selected File Formats";
            // 
            // TreeViewStateImageList
            // 
            this.TreeViewStateImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeViewStateImageList.ImageStream")));
            this.TreeViewStateImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.TreeViewStateImageList.Images.SetKeyName(0, "frClear.png");
            this.TreeViewStateImageList.Images.SetKeyName(1, "frApply.png");
            this.TreeViewStateImageList.Images.SetKeyName(2, "frPartial.png");
            // 
            // panel1
            // 
            this.panel1.ContextMenuStrip = this.FilterPopupMenu;
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.FileFilterControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(284, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 297);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // FilterPopupMenu
            // 
            this.FilterPopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FilterPopupUseAutocorrect,
            this.toolStripSeparator1,
            this.FilterPopupShowFilter});
            this.FilterPopupMenu.Name = "PopupMenu";
            this.FilterPopupMenu.Size = new System.Drawing.Size(194, 54);
            // 
            // FilterPopupUseAutocorrect
            // 
            this.FilterPopupUseAutocorrect.Name = "FilterPopupUseAutocorrect";
            this.FilterPopupUseAutocorrect.Size = new System.Drawing.Size(193, 22);
            this.FilterPopupUseAutocorrect.Text = "&Use Autocorrect";
            this.FilterPopupUseAutocorrect.ToolTipText = "Use Autocorrect to fix data validation errors";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(190, 6);
            // 
            // FilterPopupShowFilter
            // 
            this.FilterPopupShowFilter.Name = "FilterPopupShowFilter";
            this.FilterPopupShowFilter.Size = new System.Drawing.Size(193, 22);
            this.FilterPopupShowFilter.Text = "&Show Filter Conditions";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(408, 262);
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
            this.btnOK.Location = new System.Drawing.Point(316, 262);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 27);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.schemaToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // schemaToolStripMenuItem
            // 
            this.schemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showFormatsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.schemaToolStripMenuItem.Name = "schemaToolStripMenuItem";
            this.schemaToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.schemaToolStripMenuItem.Text = "&Schema";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showConditionsToolStripMenuItem,
            this.toolStripMenuItem3,
            this.filterConditionsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.viewToolStripMenuItem.Text = "&Filter";
            // 
            // filterConditionsToolStripMenuItem
            // 
            this.filterConditionsToolStripMenuItem.Name = "filterConditionsToolStripMenuItem";
            this.filterConditionsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.filterConditionsToolStripMenuItem.Text = "Use Autocorrect";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.addToolStripMenuItem.Text = "&Add";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(146, 6);
            // 
            // showFormatsToolStripMenuItem
            // 
            this.showFormatsToolStripMenuItem.Name = "showFormatsToolStripMenuItem";
            this.showFormatsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.showFormatsToolStripMenuItem.Text = "&Show Formats";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(161, 6);
            // 
            // showConditionsToolStripMenuItem
            // 
            this.showConditionsToolStripMenuItem.Name = "showConditionsToolStripMenuItem";
            this.showConditionsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.showConditionsToolStripMenuItem.Text = "Show Conditions";
            // 
            // FileFilterControl
            // 
            this.FileFilterControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.FileFilterControl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileFilterControl.Location = new System.Drawing.Point(0, 0);
            this.FileFilterControl.Margin = new System.Windows.Forms.Padding(4);
            this.FileFilterControl.Name = "FileFilterControl";
            this.FileFilterControl.Size = new System.Drawing.Size(500, 260);
            this.FileFilterControl.TabIndex = 0;
            // 
            // FileOptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 321);
            this.Controls.Add(this.TreeView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 360);
            this.Name = "FileOptionsDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "File Options";
            this.Load += new System.EventHandler(this.FileOptionsDialog_Load);
            this.SchemaPopupMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.FilterPopupMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnOK;
        public Controls.FileFilterControl FileFilterControl;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem SchemaPopupShowFileFilter;
        public System.Windows.Forms.ContextMenuStrip FilterPopupMenu;
        public System.Windows.Forms.ToolStripMenuItem FilterPopupShowFilter;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripMenuItem FilterPopupUseAutocorrect;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem schemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem showFormatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterConditionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem showConditionsToolStripMenuItem;
    }
}