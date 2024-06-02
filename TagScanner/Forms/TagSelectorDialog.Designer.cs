namespace TagScanner.Forms
{
	partial class TagSelectorDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TagSelectorDialog));
            this.ListView = new System.Windows.Forms.ListView();
            this.chTagName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDataType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chWritable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.TreeViewStateImageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbTreeAlpha = new System.Windows.Forms.ToolStripButton();
            this.tbTreeCat = new System.Windows.Forms.ToolStripButton();
            this.tbTreeType = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbListAlpha = new System.Windows.Forms.ToolStripButton();
            this.tbListCat = new System.Windows.Forms.ToolStripButton();
            this.tbListType = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbListNames = new System.Windows.Forms.ToolStripButton();
            this.MainMenu = new TagScanner.Controls.FirstClickMenuStrip();
            this.TreeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeAlphabetically = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeByCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeByDataType = new System.Windows.Forms.ToolStripMenuItem();
            this.ListMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ListAlphabetically = new System.Windows.Forms.ToolStripMenuItem();
            this.ListByCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.ListByDataType = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ListNamesOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.LeftToolStripPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListView
            // 
            this.ListView.AllowColumnReorder = true;
            this.ListView.AllowDrop = true;
            this.ListView.CheckBoxes = true;
            this.ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTagName,
            this.chCategory,
            this.chDataType,
            this.chWritable});
            this.ListView.FullRowSelect = true;
            this.ListView.HideSelection = false;
            this.ListView.Location = new System.Drawing.Point(4, 4);
            this.ListView.Margin = new System.Windows.Forms.Padding(4);
            this.ListView.Name = "ListView";
            this.ListView.ShowItemToolTips = true;
            this.ListView.Size = new System.Drawing.Size(152, 120);
            this.ListView.TabIndex = 2;
            this.ListView.UseCompatibleStateImageBehavior = false;
            this.ListView.View = System.Windows.Forms.View.List;
            // 
            // chTagName
            // 
            this.chTagName.Text = "Tag Name";
            this.chTagName.Width = 200;
            // 
            // chCategory
            // 
            this.chCategory.Text = "Category";
            this.chCategory.Width = 100;
            // 
            // chDataType
            // 
            this.chDataType.Text = "Data Type";
            this.chDataType.Width = 100;
            // 
            // chWritable
            // 
            this.chWritable.Text = "Writable?";
            this.chWritable.Width = 80;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 366);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 51);
            this.panel1.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(466, 9);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 30);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(372, 9);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 30);
            this.btnOK.TabIndex = 19;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // TreeView
            // 
            this.TreeView.Location = new System.Drawing.Point(163, 4);
            this.TreeView.Name = "TreeView";
            this.TreeView.ShowNodeToolTips = true;
            this.TreeView.Size = new System.Drawing.Size(152, 121);
            this.TreeView.StateImageList = this.TreeViewStateImageList;
            this.TreeView.TabIndex = 5;
            // 
            // TreeViewStateImageList
            // 
            this.TreeViewStateImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeViewStateImageList.ImageStream")));
            this.TreeViewStateImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.TreeViewStateImageList.Images.SetKeyName(0, "frClear.png");
            this.TreeViewStateImageList.Images.SetKeyName(1, "frApply.png");
            this.TreeViewStateImageList.Images.SetKeyName(2, "frPartial.png");
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.ListView);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.TreeView);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(600, 417);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(624, 441);
            this.toolStripContainer1.TabIndex = 6;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.MainMenu);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbTreeAlpha,
            this.tbTreeCat,
            this.tbTreeType,
            this.toolStripSeparator1,
            this.tbListAlpha,
            this.tbListCat,
            this.tbListType,
            this.toolStripSeparator2,
            this.tbListNames});
            this.toolStrip1.Location = new System.Drawing.Point(0, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(24, 184);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbTreeAlpha
            // 
            this.tbTreeAlpha.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbTreeAlpha.Image = global::TagScanner.Properties.Resources.vsTreeView;
            this.tbTreeAlpha.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbTreeAlpha.Name = "tbTreeAlpha";
            this.tbTreeAlpha.Size = new System.Drawing.Size(30, 20);
            this.tbTreeAlpha.Text = "toolStripButton1";
            // 
            // tbTreeCat
            // 
            this.tbTreeCat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbTreeCat.Image = global::TagScanner.Properties.Resources.vsTreeViewGreen;
            this.tbTreeCat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbTreeCat.Name = "tbTreeCat";
            this.tbTreeCat.Size = new System.Drawing.Size(22, 20);
            this.tbTreeCat.Text = "toolStripButton2";
            // 
            // tbTreeType
            // 
            this.tbTreeType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbTreeType.Image = global::TagScanner.Properties.Resources.vsTreeViewBlue;
            this.tbTreeType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbTreeType.Name = "tbTreeType";
            this.tbTreeType.Size = new System.Drawing.Size(22, 20);
            this.tbTreeType.Text = "toolStripButton3";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(30, 6);
            // 
            // tbListAlpha
            // 
            this.tbListAlpha.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbListAlpha.Image = global::TagScanner.Properties.Resources.vsCheckedsListBox;
            this.tbListAlpha.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbListAlpha.Name = "tbListAlpha";
            this.tbListAlpha.Size = new System.Drawing.Size(22, 20);
            this.tbListAlpha.Text = "toolStripButton4";
            // 
            // tbListCat
            // 
            this.tbListCat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbListCat.Image = global::TagScanner.Properties.Resources.vsCheckedsListBoxGreen;
            this.tbListCat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbListCat.Name = "tbListCat";
            this.tbListCat.Size = new System.Drawing.Size(22, 20);
            this.tbListCat.Text = "toolStripButton5";
            // 
            // tbListType
            // 
            this.tbListType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbListType.Image = global::TagScanner.Properties.Resources.vsCheckedsListBoxBlue;
            this.tbListType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbListType.Name = "tbListType";
            this.tbListType.Size = new System.Drawing.Size(22, 20);
            this.tbListType.Text = "toolStripButton6";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(30, 6);
            // 
            // tbListNames
            // 
            this.tbListNames.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbListNames.Image = global::TagScanner.Properties.Resources.vsLinkLabel;
            this.tbListNames.ImageTransparentColor = System.Drawing.Color.White;
            this.tbListNames.Name = "tbListNames";
            this.tbListNames.Size = new System.Drawing.Size(30, 20);
            this.tbListNames.Text = "toolStripButton7";
            // 
            // MainMenu
            // 
            this.MainMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TreeMenu,
            this.ListMenu});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(624, 24);
            this.MainMenu.TabIndex = 7;
            this.MainMenu.Text = "menuStrip1";
            // 
            // TreeMenu
            // 
            this.TreeMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TreeAlphabetically,
            this.TreeByCategory,
            this.TreeByDataType});
            this.TreeMenu.Name = "TreeMenu";
            this.TreeMenu.Size = new System.Drawing.Size(40, 20);
            this.TreeMenu.Text = "&Tree";
            // 
            // TreeAlphabetically
            // 
            this.TreeAlphabetically.Image = global::TagScanner.Properties.Resources.vsTreeView;
            this.TreeAlphabetically.Name = "TreeAlphabetically";
            this.TreeAlphabetically.Size = new System.Drawing.Size(180, 22);
            this.TreeAlphabetically.Text = "&Alphabetically";
            // 
            // TreeByCategory
            // 
            this.TreeByCategory.Image = global::TagScanner.Properties.Resources.vsTreeViewGreen;
            this.TreeByCategory.Name = "TreeByCategory";
            this.TreeByCategory.Size = new System.Drawing.Size(180, 22);
            this.TreeByCategory.Text = "by &Category";
            // 
            // TreeByDataType
            // 
            this.TreeByDataType.Image = global::TagScanner.Properties.Resources.vsTreeViewBlue;
            this.TreeByDataType.Name = "TreeByDataType";
            this.TreeByDataType.Size = new System.Drawing.Size(180, 22);
            this.TreeByDataType.Text = "by &Data Type";
            // 
            // ListMenu
            // 
            this.ListMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ListAlphabetically,
            this.ListByCategory,
            this.ListByDataType,
            this.toolStripMenuItem2,
            this.ListNamesOnly});
            this.ListMenu.Name = "ListMenu";
            this.ListMenu.Size = new System.Drawing.Size(37, 20);
            this.ListMenu.Text = "&List";
            // 
            // ListAlphabetically
            // 
            this.ListAlphabetically.Image = global::TagScanner.Properties.Resources.vsCheckedsListBox;
            this.ListAlphabetically.Name = "ListAlphabetically";
            this.ListAlphabetically.Size = new System.Drawing.Size(180, 22);
            this.ListAlphabetically.Text = "&Alphabetically";
            // 
            // ListByCategory
            // 
            this.ListByCategory.Image = global::TagScanner.Properties.Resources.vsCheckedsListBoxGreen;
            this.ListByCategory.Name = "ListByCategory";
            this.ListByCategory.Size = new System.Drawing.Size(180, 22);
            this.ListByCategory.Text = "by &Category";
            // 
            // ListByDataType
            // 
            this.ListByDataType.Image = global::TagScanner.Properties.Resources.vsCheckedsListBoxBlue;
            this.ListByDataType.Name = "ListByDataType";
            this.ListByDataType.Size = new System.Drawing.Size(180, 22);
            this.ListByDataType.Text = "by &Data Type";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // ListNamesOnly
            // 
            this.ListNamesOnly.Image = global::TagScanner.Properties.Resources.vsLinkLabel;
            this.ListNamesOnly.ImageTransparentColor = System.Drawing.Color.White;
            this.ListNamesOnly.Name = "ListNamesOnly";
            this.ListNamesOnly.Size = new System.Drawing.Size(180, 22);
            this.ListNamesOnly.Text = "&Names only";
            // 
            // TagSelectorDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "TagSelectorDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Visible Tags";
            this.panel1.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.ListView ListView;
        public System.Windows.Forms.ColumnHeader chTagName;
        public System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.Button btnCancel;
		public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.ColumnHeader chDataType;
        public System.Windows.Forms.ColumnHeader chCategory;
        public System.Windows.Forms.ColumnHeader chWritable;
        public System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.ImageList TreeViewStateImageList;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbTreeAlpha;
        private System.Windows.Forms.ToolStripButton tbTreeCat;
        public Controls.FirstClickMenuStrip MainMenu;
        public System.Windows.Forms.ToolStripMenuItem TreeMenu;
        public System.Windows.Forms.ToolStripMenuItem TreeAlphabetically;
        public System.Windows.Forms.ToolStripMenuItem TreeByCategory;
        public System.Windows.Forms.ToolStripMenuItem TreeByDataType;
        public System.Windows.Forms.ToolStripMenuItem ListMenu;
        public System.Windows.Forms.ToolStripMenuItem ListAlphabetically;
        public System.Windows.Forms.ToolStripMenuItem ListByCategory;
        public System.Windows.Forms.ToolStripMenuItem ListByDataType;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        public System.Windows.Forms.ToolStripMenuItem ListNamesOnly;
        private System.Windows.Forms.ToolStripButton tbTreeType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbListAlpha;
        private System.Windows.Forms.ToolStripButton tbListCat;
        private System.Windows.Forms.ToolStripButton tbListType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tbListNames;
    }
}