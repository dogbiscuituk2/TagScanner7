namespace TagScanner.Forms
{
	partial class QueryDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryDialog));
            this.ListView = new System.Windows.Forms.ListView();
            this.chTagName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDataType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chWritable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PopupSourceMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PopupSourceSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupSourceSort = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupTagSortAscending = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupTagSortDescending = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.PopupTagSortNone = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupSourceGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.TreeViewStateImageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lvSelected = new System.Windows.Forms.ListView();
            this.PopupTargetMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PopupTargetCut = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupTargetCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupTargetPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupTargetDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.PopupTargetMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupTargetMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.lvOrderBy = new System.Windows.Forms.ListView();
            this.lvGroupBy = new System.Windows.Forms.ListView();
            this.lblSelect = new System.Windows.Forms.Label();
            this.lblOrderBy = new System.Windows.Forms.Label();
            this.lblGroupBy = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.Toolbar = new TagScanner.Controls.FirstClickToolStrip();
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
            this.PopupSourceMenu.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.LeftToolStripPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.TableLayoutPanel.SuspendLayout();
            this.PopupTargetMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.Toolbar.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListView
            // 
            this.ListView.AllowColumnReorder = true;
            this.ListView.CheckBoxes = true;
            this.ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTagName,
            this.chCategory,
            this.chDataType,
            this.chWritable});
            this.ListView.ContextMenuStrip = this.PopupSourceMenu;
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
            // PopupSourceMenu
            // 
            this.PopupSourceMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PopupSourceSelect,
            this.PopupSourceSort,
            this.PopupSourceGroup});
            this.PopupSourceMenu.Name = "PopupTagMenu";
            this.PopupSourceMenu.Size = new System.Drawing.Size(108, 70);
            // 
            // PopupSourceSelect
            // 
            this.PopupSourceSelect.Name = "PopupSourceSelect";
            this.PopupSourceSelect.Size = new System.Drawing.Size(107, 22);
            this.PopupSourceSelect.Text = "&Select";
            // 
            // PopupSourceSort
            // 
            this.PopupSourceSort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PopupTagSortAscending,
            this.PopupTagSortDescending,
            this.toolStripMenuItem1,
            this.PopupTagSortNone});
            this.PopupSourceSort.Name = "PopupSourceSort";
            this.PopupSourceSort.Size = new System.Drawing.Size(107, 22);
            this.PopupSourceSort.Text = "S&ort";
            // 
            // PopupTagSortAscending
            // 
            this.PopupTagSortAscending.Name = "PopupTagSortAscending";
            this.PopupTagSortAscending.Size = new System.Drawing.Size(136, 22);
            this.PopupTagSortAscending.Text = "&Ascending";
            // 
            // PopupTagSortDescending
            // 
            this.PopupTagSortDescending.Name = "PopupTagSortDescending";
            this.PopupTagSortDescending.Size = new System.Drawing.Size(136, 22);
            this.PopupTagSortDescending.Text = "&Descending";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(133, 6);
            // 
            // PopupTagSortNone
            // 
            this.PopupTagSortNone.Name = "PopupTagSortNone";
            this.PopupTagSortNone.Size = new System.Drawing.Size(136, 22);
            this.PopupTagSortNone.Text = "&None";
            // 
            // PopupSourceGroup
            // 
            this.PopupSourceGroup.Name = "PopupSourceGroup";
            this.PopupSourceGroup.Size = new System.Drawing.Size(107, 22);
            this.PopupSourceGroup.Text = "&Group";
            this.PopupSourceGroup.ToolTipText = "Include this Tag in the Custom Group?";
            // 
            // TreeView
            // 
            this.TreeView.ContextMenuStrip = this.PopupSourceMenu;
            this.TreeView.HideSelection = false;
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(760, 537);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add(this.Toolbar);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(784, 561);
            this.toolStripContainer1.TabIndex = 6;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.MainMenu);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ListView);
            this.splitContainer1.Panel1.Controls.Add(this.TreeView);
            this.splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TableLayoutPanel);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2MinSize = 100;
            this.splitContainer1.Size = new System.Drawing.Size(760, 537);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 6;
            // 
            // TableLayoutPanel
            // 
            this.TableLayoutPanel.ColumnCount = 3;
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel.Controls.Add(this.lvSelected, 0, 1);
            this.TableLayoutPanel.Controls.Add(this.lvOrderBy, 1, 1);
            this.TableLayoutPanel.Controls.Add(this.lvGroupBy, 2, 1);
            this.TableLayoutPanel.Controls.Add(this.lblSelect, 0, 0);
            this.TableLayoutPanel.Controls.Add(this.lblOrderBy, 1, 0);
            this.TableLayoutPanel.Controls.Add(this.lblGroupBy, 2, 0);
            this.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 2;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel.Size = new System.Drawing.Size(690, 233);
            this.TableLayoutPanel.TabIndex = 25;
            // 
            // lvSelected
            // 
            this.lvSelected.AllowDrop = true;
            this.lvSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvSelected.ContextMenuStrip = this.PopupTargetMenu;
            this.lvSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSelected.HideSelection = false;
            this.lvSelected.Location = new System.Drawing.Point(0, 20);
            this.lvSelected.Margin = new System.Windows.Forms.Padding(0);
            this.lvSelected.Name = "lvSelected";
            this.lvSelected.ShowItemToolTips = true;
            this.lvSelected.Size = new System.Drawing.Size(230, 213);
            this.lvSelected.TabIndex = 1;
            this.lvSelected.UseCompatibleStateImageBehavior = false;
            this.lvSelected.View = System.Windows.Forms.View.List;
            // 
            // PopupTargetMenu
            // 
            this.PopupTargetMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PopupTargetCut,
            this.PopupTargetCopy,
            this.PopupTargetPaste,
            this.PopupTargetDelete,
            this.toolStripMenuItem3,
            this.PopupTargetMoveUp,
            this.PopupTargetMoveDown});
            this.PopupTargetMenu.Name = "PopupTargetMenu";
            this.PopupTargetMenu.Size = new System.Drawing.Size(160, 142);
            // 
            // PopupTargetCut
            // 
            this.PopupTargetCut.Image = global::TagScanner.Properties.Resources.CutHS;
            this.PopupTargetCut.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupTargetCut.Name = "PopupTargetCut";
            this.PopupTargetCut.ShortcutKeyDisplayString = "^X";
            this.PopupTargetCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.PopupTargetCut.Size = new System.Drawing.Size(159, 22);
            this.PopupTargetCut.Text = "Cu&t";
            // 
            // PopupTargetCopy
            // 
            this.PopupTargetCopy.Image = global::TagScanner.Properties.Resources.CopyHS;
            this.PopupTargetCopy.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupTargetCopy.Name = "PopupTargetCopy";
            this.PopupTargetCopy.ShortcutKeyDisplayString = "^C";
            this.PopupTargetCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.PopupTargetCopy.Size = new System.Drawing.Size(159, 22);
            this.PopupTargetCopy.Text = "&Copy";
            // 
            // PopupTargetPaste
            // 
            this.PopupTargetPaste.Image = global::TagScanner.Properties.Resources.PasteHS;
            this.PopupTargetPaste.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupTargetPaste.Name = "PopupTargetPaste";
            this.PopupTargetPaste.ShortcutKeyDisplayString = "^V";
            this.PopupTargetPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.PopupTargetPaste.Size = new System.Drawing.Size(159, 22);
            this.PopupTargetPaste.Text = "&Paste";
            // 
            // PopupTargetDelete
            // 
            this.PopupTargetDelete.Image = global::TagScanner.Properties.Resources.Delete;
            this.PopupTargetDelete.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupTargetDelete.Name = "PopupTargetDelete";
            this.PopupTargetDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.PopupTargetDelete.Size = new System.Drawing.Size(159, 22);
            this.PopupTargetDelete.Text = "&Delete";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(156, 6);
            // 
            // PopupTargetMoveUp
            // 
            this.PopupTargetMoveUp.Image = global::TagScanner.Properties.Resources.arrow_Up_16xLG;
            this.PopupTargetMoveUp.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupTargetMoveUp.Name = "PopupTargetMoveUp";
            this.PopupTargetMoveUp.ShortcutKeyDisplayString = "^↑";
            this.PopupTargetMoveUp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.PopupTargetMoveUp.Size = new System.Drawing.Size(159, 22);
            this.PopupTargetMoveUp.Text = "Move Up";
            // 
            // PopupTargetMoveDown
            // 
            this.PopupTargetMoveDown.Image = global::TagScanner.Properties.Resources.arrow_Down_16xLG;
            this.PopupTargetMoveDown.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupTargetMoveDown.Name = "PopupTargetMoveDown";
            this.PopupTargetMoveDown.ShortcutKeyDisplayString = "^↓";
            this.PopupTargetMoveDown.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.PopupTargetMoveDown.Size = new System.Drawing.Size(159, 22);
            this.PopupTargetMoveDown.Text = "Move Down";
            // 
            // lvOrderBy
            // 
            this.lvOrderBy.AllowDrop = true;
            this.lvOrderBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvOrderBy.ContextMenuStrip = this.PopupTargetMenu;
            this.lvOrderBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvOrderBy.HideSelection = false;
            this.lvOrderBy.Location = new System.Drawing.Point(230, 20);
            this.lvOrderBy.Margin = new System.Windows.Forms.Padding(0);
            this.lvOrderBy.Name = "lvOrderBy";
            this.lvOrderBy.ShowItemToolTips = true;
            this.lvOrderBy.Size = new System.Drawing.Size(230, 213);
            this.lvOrderBy.TabIndex = 25;
            this.lvOrderBy.UseCompatibleStateImageBehavior = false;
            this.lvOrderBy.View = System.Windows.Forms.View.List;
            // 
            // lvGroupBy
            // 
            this.lvGroupBy.AllowDrop = true;
            this.lvGroupBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvGroupBy.ContextMenuStrip = this.PopupTargetMenu;
            this.lvGroupBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvGroupBy.HideSelection = false;
            this.lvGroupBy.Location = new System.Drawing.Point(460, 20);
            this.lvGroupBy.Margin = new System.Windows.Forms.Padding(0);
            this.lvGroupBy.Name = "lvGroupBy";
            this.lvGroupBy.ShowItemToolTips = true;
            this.lvGroupBy.Size = new System.Drawing.Size(230, 213);
            this.lvGroupBy.TabIndex = 26;
            this.lvGroupBy.UseCompatibleStateImageBehavior = false;
            this.lvGroupBy.View = System.Windows.Forms.View.List;
            // 
            // lblSelect
            // 
            this.lblSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSelect.Location = new System.Drawing.Point(3, 0);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(224, 20);
            this.lblSelect.TabIndex = 27;
            this.lblSelect.Text = "Select";
            this.lblSelect.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblOrderBy
            // 
            this.lblOrderBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrderBy.Location = new System.Drawing.Point(233, 0);
            this.lblOrderBy.Name = "lblOrderBy";
            this.lblOrderBy.Size = new System.Drawing.Size(224, 20);
            this.lblOrderBy.TabIndex = 28;
            this.lblOrderBy.Text = "Sort";
            this.lblOrderBy.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblGroupBy
            // 
            this.lblGroupBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGroupBy.Location = new System.Drawing.Point(463, 0);
            this.lblGroupBy.Name = "lblGroupBy";
            this.lblGroupBy.Size = new System.Drawing.Size(224, 20);
            this.lblGroupBy.TabIndex = 29;
            this.lblGroupBy.Text = "Group";
            this.lblGroupBy.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(690, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(70, 233);
            this.panel2.TabIndex = 23;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(10, 202);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 27);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(10, 167);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(56, 27);
            this.btnOK.TabIndex = 19;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // Toolbar
            // 
            this.Toolbar.Dock = System.Windows.Forms.DockStyle.None;
            this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbTreeAlpha,
            this.tbTreeCat,
            this.tbTreeType,
            this.toolStripSeparator1,
            this.tbListAlpha,
            this.tbListCat,
            this.tbListType,
            this.toolStripSeparator2,
            this.tbListNames});
            this.Toolbar.Location = new System.Drawing.Point(0, 3);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Size = new System.Drawing.Size(24, 184);
            this.Toolbar.TabIndex = 7;
            this.Toolbar.Text = "toolStrip1";
            // 
            // tbTreeAlpha
            // 
            this.tbTreeAlpha.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbTreeAlpha.Image = global::TagScanner.Properties.Resources.fff_app_tree_16;
            this.tbTreeAlpha.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbTreeAlpha.Name = "tbTreeAlpha";
            this.tbTreeAlpha.Size = new System.Drawing.Size(22, 20);
            this.tbTreeAlpha.Text = "toolStripButton1";
            this.tbTreeAlpha.ToolTipText = "Tree (alphabetical)";
            // 
            // tbTreeCat
            // 
            this.tbTreeCat.Checked = true;
            this.tbTreeCat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tbTreeCat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbTreeCat.Image = global::TagScanner.Properties.Resources.fff_app_tree_C2_16;
            this.tbTreeCat.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbTreeCat.Name = "tbTreeCat";
            this.tbTreeCat.Size = new System.Drawing.Size(22, 20);
            this.tbTreeCat.Text = "toolStripButton2";
            this.tbTreeCat.ToolTipText = "Tree (by category)";
            // 
            // tbTreeType
            // 
            this.tbTreeType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbTreeType.Image = ((System.Drawing.Image)(resources.GetObject("tbTreeType.Image")));
            this.tbTreeType.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbTreeType.Name = "tbTreeType";
            this.tbTreeType.Size = new System.Drawing.Size(22, 20);
            this.tbTreeType.Text = "toolStripButton3";
            this.tbTreeType.ToolTipText = "Tree (by data type)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(22, 6);
            // 
            // tbListAlpha
            // 
            this.tbListAlpha.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbListAlpha.Image = global::TagScanner.Properties.Resources.fff_app_list_16;
            this.tbListAlpha.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbListAlpha.Name = "tbListAlpha";
            this.tbListAlpha.Size = new System.Drawing.Size(22, 20);
            this.tbListAlpha.ToolTipText = "List (alphabetical)";
            // 
            // tbListCat
            // 
            this.tbListCat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbListCat.Image = global::TagScanner.Properties.Resources.fff_app_list_C2_16;
            this.tbListCat.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbListCat.Name = "tbListCat";
            this.tbListCat.Size = new System.Drawing.Size(22, 20);
            this.tbListCat.Text = "toolStripButton5";
            this.tbListCat.ToolTipText = "List (by category)";
            // 
            // tbListType
            // 
            this.tbListType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbListType.Image = global::TagScanner.Properties.Resources.fff_app_list_T_16;
            this.tbListType.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbListType.Name = "tbListType";
            this.tbListType.Size = new System.Drawing.Size(22, 20);
            this.tbListType.Text = "toolStripButton6";
            this.tbListType.ToolTipText = "List (by data type)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(22, 6);
            // 
            // tbListNames
            // 
            this.tbListNames.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbListNames.Image = global::TagScanner.Properties.Resources.fff_app_columns_16;
            this.tbListNames.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbListNames.Name = "tbListNames";
            this.tbListNames.Size = new System.Drawing.Size(22, 20);
            this.tbListNames.Text = "toolStripButton7";
            this.tbListNames.ToolTipText = "List (names only)";
            // 
            // MainMenu
            // 
            this.MainMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TreeMenu,
            this.ListMenu});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(784, 24);
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
            this.TreeAlphabetically.Image = global::TagScanner.Properties.Resources.fff_app_tree_16;
            this.TreeAlphabetically.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.TreeAlphabetically.Name = "TreeAlphabetically";
            this.TreeAlphabetically.Size = new System.Drawing.Size(149, 22);
            this.TreeAlphabetically.Text = "&Alphabetically";
            // 
            // TreeByCategory
            // 
            this.TreeByCategory.Image = global::TagScanner.Properties.Resources.fff_app_tree_C2_16;
            this.TreeByCategory.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.TreeByCategory.Name = "TreeByCategory";
            this.TreeByCategory.Size = new System.Drawing.Size(149, 22);
            this.TreeByCategory.Text = "by &Category";
            // 
            // TreeByDataType
            // 
            this.TreeByDataType.Image = ((System.Drawing.Image)(resources.GetObject("TreeByDataType.Image")));
            this.TreeByDataType.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.TreeByDataType.Name = "TreeByDataType";
            this.TreeByDataType.Size = new System.Drawing.Size(149, 22);
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
            this.ListAlphabetically.Image = global::TagScanner.Properties.Resources.fff_app_list_16;
            this.ListAlphabetically.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.ListAlphabetically.Name = "ListAlphabetically";
            this.ListAlphabetically.Size = new System.Drawing.Size(149, 22);
            this.ListAlphabetically.Text = "&Alphabetically";
            // 
            // ListByCategory
            // 
            this.ListByCategory.Image = global::TagScanner.Properties.Resources.fff_app_list_C2_16;
            this.ListByCategory.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.ListByCategory.Name = "ListByCategory";
            this.ListByCategory.Size = new System.Drawing.Size(149, 22);
            this.ListByCategory.Text = "by &Category";
            // 
            // ListByDataType
            // 
            this.ListByDataType.Image = global::TagScanner.Properties.Resources.fff_app_list_T_16;
            this.ListByDataType.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.ListByDataType.Name = "ListByDataType";
            this.ListByDataType.Size = new System.Drawing.Size(149, 22);
            this.ListByDataType.Text = "by &Data Type";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(146, 6);
            // 
            // ListNamesOnly
            // 
            this.ListNamesOnly.Image = global::TagScanner.Properties.Resources.fff_app_columns_16;
            this.ListNamesOnly.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.ListNamesOnly.Name = "ListNamesOnly";
            this.ListNamesOnly.Size = new System.Drawing.Size(149, 22);
            this.ListNamesOnly.Text = "&Names only";
            // 
            // QueryDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "QueryDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Visible Tags";
            this.PopupSourceMenu.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.TableLayoutPanel.ResumeLayout(false);
            this.PopupTargetMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.Toolbar.ResumeLayout(false);
            this.Toolbar.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.ListView ListView;
        public System.Windows.Forms.ColumnHeader chTagName;
        public System.Windows.Forms.ColumnHeader chDataType;
        public System.Windows.Forms.ColumnHeader chCategory;
        public System.Windows.Forms.ColumnHeader chWritable;
        public System.Windows.Forms.TreeView TreeView;
        public System.Windows.Forms.ImageList TreeViewStateImageList;
        public System.Windows.Forms.ToolStripContainer toolStripContainer1;
        public Controls.FirstClickToolStrip Toolbar;
        public System.Windows.Forms.ToolStripButton tbTreeAlpha;
        public System.Windows.Forms.ToolStripButton tbTreeCat;
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
        public System.Windows.Forms.ToolStripButton tbTreeType;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton tbListAlpha;
        public System.Windows.Forms.ToolStripButton tbListCat;
        public System.Windows.Forms.ToolStripButton tbListType;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripButton tbListNames;
        public System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.ContextMenuStrip PopupSourceMenu;
        public System.Windows.Forms.ToolStripMenuItem PopupSourceSort;
        public System.Windows.Forms.ToolStripMenuItem PopupTagSortAscending;
        public System.Windows.Forms.ToolStripMenuItem PopupTagSortDescending;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem PopupTagSortNone;
        public System.Windows.Forms.ToolStripMenuItem PopupSourceGroup;
        public System.Windows.Forms.ToolStripMenuItem PopupSourceSelect;
        public System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
        public System.Windows.Forms.ListView lvGroupBy;
        public System.Windows.Forms.ListView lvOrderBy;
        public System.Windows.Forms.ListView lvSelected;
        public System.Windows.Forms.Label lblSelect;
        public System.Windows.Forms.Label lblOrderBy;
        public System.Windows.Forms.Label lblGroupBy;
        public System.Windows.Forms.ContextMenuStrip PopupTargetMenu;
        public System.Windows.Forms.ToolStripMenuItem PopupTargetCut;
        public System.Windows.Forms.ToolStripMenuItem PopupTargetCopy;
        public System.Windows.Forms.ToolStripMenuItem PopupTargetPaste;
        public System.Windows.Forms.ToolStripMenuItem PopupTargetDelete;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        public System.Windows.Forms.ToolStripMenuItem PopupTargetMoveUp;
        public System.Windows.Forms.ToolStripMenuItem PopupTargetMoveDown;
    }
}