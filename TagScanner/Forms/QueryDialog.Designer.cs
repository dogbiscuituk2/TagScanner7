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
            this.ListView = new TagScanner.Controls.DoubleBufferedListView();
            this.chTagName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDataType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chWritable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSortable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PopupTree = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupTreeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TreeAlphabetically = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeByCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeByDataType = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupList = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ListAlphabetically = new System.Windows.Forms.ToolStripMenuItem();
            this.ListByCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.ListByDataType = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ListNamesOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.ListSmallIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.ListLargeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.ListTiles = new System.Windows.Forms.ToolStripMenuItem();
            this.ListMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.PopupMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.PopupSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupSortAscending = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupSortDescending = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.PopupUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.PopupCut = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupClear = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.PopupSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupInvertSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.EditMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lvSelect = new System.Windows.Forms.ListView();
            this.lvOrderBy = new System.Windows.Forms.ListView();
            this.SortByImageList = new System.Windows.Forms.ImageList(this.components);
            this.lvGroupBy = new System.Windows.Forms.ListView();
            this.lblSelect = new System.Windows.Forms.Label();
            this.lblOrderBy = new System.Windows.Forms.Label();
            this.lblGroupBy = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.Toolbar = new System.Windows.Forms.ToolStrip();
            this.tbTree = new System.Windows.Forms.ToolStripSplitButton();
            this.tbList = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tbOK = new System.Windows.Forms.ToolStripButton();
            this.tbCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbUndo = new System.Windows.Forms.ToolStripSplitButton();
            this.tbRedo = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbCut = new System.Windows.Forms.ToolStripButton();
            this.tbCopy = new System.Windows.Forms.ToolStripButton();
            this.tbPaste = new System.Windows.Forms.ToolStripButton();
            this.tbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tbMoveUp = new System.Windows.Forms.ToolStripButton();
            this.tbMoveDown = new System.Windows.Forms.ToolStripButton();
            this.MainMenu = new TagScanner.Controls.FirstClickMenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSaveAndClose = new System.Windows.Forms.ToolStripMenuItem();
            this.FileCloseWithoutSaving = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenu.SuspendLayout();
            this.PopupTreeMenu.SuspendLayout();
            this.PopupListMenu.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.LeftToolStripPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.TableLayoutPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.Toolbar.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListView
            // 
            this.ListView.AllowColumnReorder = true;
            this.ListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTagName,
            this.chCategory,
            this.chDataType,
            this.chWritable,
            this.chSortable});
            this.ListView.ContextMenuStrip = this.PopupMenu;
            this.ListView.FullRowSelect = true;
            this.ListView.HideSelection = false;
            this.ListView.Location = new System.Drawing.Point(161, 4);
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
            // chSortable
            // 
            this.chSortable.Text = "Sortable?";
            this.chSortable.Width = 80;
            // 
            // PopupMenu
            // 
            this.PopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PopupTree,
            this.PopupList,
            this.PopupSeparator1,
            this.PopupMoveUp,
            this.PopupMoveDown,
            this.PopupSeparator2,
            this.PopupSelect,
            this.PopupSortAscending,
            this.PopupSortDescending,
            this.PopupGroup,
            this.PopupSeparator3,
            this.PopupUndo,
            this.PopupRedo,
            this.PopupSeparator4,
            this.PopupCut,
            this.PopupCopy,
            this.PopupPaste,
            this.PopupDelete,
            this.PopupClear,
            this.PopupSeparator5,
            this.PopupSelectAll,
            this.PopupInvertSelection});
            this.PopupMenu.Name = "PopupTargetMenu";
            this.PopupMenu.OwnerItem = this.EditMenu;
            this.PopupMenu.Size = new System.Drawing.Size(161, 430);
            // 
            // PopupTree
            // 
            this.PopupTree.DropDown = this.PopupTreeMenu;
            this.PopupTree.Name = "PopupTree";
            this.PopupTree.Size = new System.Drawing.Size(160, 22);
            this.PopupTree.Text = "Tree View";
            // 
            // PopupTreeMenu
            // 
            this.PopupTreeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TreeAlphabetically,
            this.TreeByCategory,
            this.TreeByDataType});
            this.PopupTreeMenu.Name = "PopupTreeMenu";
            this.PopupTreeMenu.OwnerItem = this.tbTree;
            this.PopupTreeMenu.Size = new System.Drawing.Size(150, 70);
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
            // TreeMenu
            // 
            this.TreeMenu.DropDown = this.PopupTreeMenu;
            this.TreeMenu.Image = global::TagScanner.Properties.Resources.fff_app_tree_16;
            this.TreeMenu.ImageTransparentColor = System.Drawing.Color.White;
            this.TreeMenu.Name = "TreeMenu";
            this.TreeMenu.Size = new System.Drawing.Size(95, 22);
            this.TreeMenu.Text = "&Tree";
            // 
            // PopupList
            // 
            this.PopupList.DropDown = this.PopupListMenu;
            this.PopupList.Name = "PopupList";
            this.PopupList.Size = new System.Drawing.Size(160, 22);
            this.PopupList.Text = "List View";
            // 
            // PopupListMenu
            // 
            this.PopupListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ListAlphabetically,
            this.ListByCategory,
            this.ListByDataType,
            this.toolStripMenuItem2,
            this.ListNamesOnly,
            this.toolStripMenuItem3,
            this.ListSmallIcons,
            this.ListLargeIcons,
            this.ListTiles});
            this.PopupListMenu.Name = "PopupTreeMenu";
            this.PopupListMenu.OwnerItem = this.tbList;
            this.PopupListMenu.Size = new System.Drawing.Size(150, 170);
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
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(146, 6);
            this.toolStripMenuItem3.Visible = false;
            // 
            // ListSmallIcons
            // 
            this.ListSmallIcons.Name = "ListSmallIcons";
            this.ListSmallIcons.Size = new System.Drawing.Size(149, 22);
            this.ListSmallIcons.Text = "Small Icons";
            this.ListSmallIcons.Visible = false;
            // 
            // ListLargeIcons
            // 
            this.ListLargeIcons.Name = "ListLargeIcons";
            this.ListLargeIcons.Size = new System.Drawing.Size(149, 22);
            this.ListLargeIcons.Text = "Large Icons";
            this.ListLargeIcons.Visible = false;
            // 
            // ListTiles
            // 
            this.ListTiles.Name = "ListTiles";
            this.ListTiles.Size = new System.Drawing.Size(149, 22);
            this.ListTiles.Text = "Tiles";
            this.ListTiles.Visible = false;
            // 
            // ListMenu
            // 
            this.ListMenu.DropDown = this.PopupListMenu;
            this.ListMenu.Image = global::TagScanner.Properties.Resources.fff_app_list_16;
            this.ListMenu.ImageTransparentColor = System.Drawing.Color.White;
            this.ListMenu.Name = "ListMenu";
            this.ListMenu.Size = new System.Drawing.Size(95, 22);
            this.ListMenu.Text = "&List";
            // 
            // PopupSeparator1
            // 
            this.PopupSeparator1.Name = "PopupSeparator1";
            this.PopupSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // PopupMoveUp
            // 
            this.PopupMoveUp.Image = global::TagScanner.Properties.Resources.arrow_Up_16xLG;
            this.PopupMoveUp.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupMoveUp.Name = "PopupMoveUp";
            this.PopupMoveUp.ShortcutKeyDisplayString = "^↑";
            this.PopupMoveUp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.PopupMoveUp.Size = new System.Drawing.Size(160, 22);
            this.PopupMoveUp.Text = "Move Up";
            this.PopupMoveUp.ToolTipText = "Move the selected item(s) up in list order in this box";
            // 
            // PopupMoveDown
            // 
            this.PopupMoveDown.Image = global::TagScanner.Properties.Resources.arrow_Down_16xLG;
            this.PopupMoveDown.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupMoveDown.Name = "PopupMoveDown";
            this.PopupMoveDown.ShortcutKeyDisplayString = "^↓";
            this.PopupMoveDown.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.PopupMoveDown.Size = new System.Drawing.Size(160, 22);
            this.PopupMoveDown.Text = "Move Down";
            this.PopupMoveDown.ToolTipText = "Move the selected item(s) down in list order in this box";
            // 
            // PopupSeparator2
            // 
            this.PopupSeparator2.Name = "PopupSeparator2";
            this.PopupSeparator2.Size = new System.Drawing.Size(157, 6);
            // 
            // PopupSelect
            // 
            this.PopupSelect.Name = "PopupSelect";
            this.PopupSelect.ShortcutKeyDisplayString = "";
            this.PopupSelect.Size = new System.Drawing.Size(160, 22);
            this.PopupSelect.Text = "&Select";
            this.PopupSelect.ToolTipText = "Copy the selected item(s) into the \'Selected\' box";
            // 
            // PopupSortAscending
            // 
            this.PopupSortAscending.Image = global::TagScanner.Properties.Resources.Custom_Icon_Design_Flat_Cute_Arrows_Arrow_Up_16;
            this.PopupSortAscending.Name = "PopupSortAscending";
            this.PopupSortAscending.ShortcutKeyDisplayString = "";
            this.PopupSortAscending.Size = new System.Drawing.Size(160, 22);
            this.PopupSortAscending.Text = "Sort &Ascending";
            this.PopupSortAscending.ToolTipText = "Sort in Ascending order of the selected item(s)";
            // 
            // PopupSortDescending
            // 
            this.PopupSortDescending.Image = global::TagScanner.Properties.Resources.Custom_Icon_Design_Flat_Cute_Arrows_Arrow_Down_16;
            this.PopupSortDescending.Name = "PopupSortDescending";
            this.PopupSortDescending.ShortcutKeyDisplayString = "";
            this.PopupSortDescending.Size = new System.Drawing.Size(160, 22);
            this.PopupSortDescending.Text = "Sort &Descending";
            this.PopupSortDescending.ToolTipText = "Sort in Ascending order of the selected item(s)";
            // 
            // PopupGroup
            // 
            this.PopupGroup.Name = "PopupGroup";
            this.PopupGroup.ShortcutKeyDisplayString = "";
            this.PopupGroup.Size = new System.Drawing.Size(160, 22);
            this.PopupGroup.Text = "&Group";
            this.PopupGroup.ToolTipText = "Copy the selected item(s) into the \'Group By\' box";
            // 
            // PopupSeparator3
            // 
            this.PopupSeparator3.Name = "PopupSeparator3";
            this.PopupSeparator3.Size = new System.Drawing.Size(157, 6);
            // 
            // PopupUndo
            // 
            this.PopupUndo.Image = global::TagScanner.Properties.Resources.Edit_UndoHS;
            this.PopupUndo.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupUndo.Name = "PopupUndo";
            this.PopupUndo.ShortcutKeyDisplayString = "^Z";
            this.PopupUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.PopupUndo.Size = new System.Drawing.Size(160, 22);
            this.PopupUndo.Text = "&Undo";
            this.PopupUndo.ToolTipText = "Undo the most recent change";
            // 
            // PopupRedo
            // 
            this.PopupRedo.Image = global::TagScanner.Properties.Resources.Edit_RedoHS;
            this.PopupRedo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PopupRedo.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupRedo.Name = "PopupRedo";
            this.PopupRedo.ShortcutKeyDisplayString = "^Y";
            this.PopupRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.PopupRedo.Size = new System.Drawing.Size(160, 22);
            this.PopupRedo.Text = "&Redo";
            this.PopupRedo.ToolTipText = "Redo the most recently \'undone\' change";
            // 
            // PopupSeparator4
            // 
            this.PopupSeparator4.Name = "PopupSeparator4";
            this.PopupSeparator4.Size = new System.Drawing.Size(157, 6);
            // 
            // PopupCut
            // 
            this.PopupCut.Image = global::TagScanner.Properties.Resources.CutHS;
            this.PopupCut.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupCut.Name = "PopupCut";
            this.PopupCut.ShortcutKeyDisplayString = "^X";
            this.PopupCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.PopupCut.Size = new System.Drawing.Size(160, 22);
            this.PopupCut.Text = "Cu&t";
            this.PopupCut.ToolTipText = "Cut the selected item(s) to the Clipboard";
            // 
            // PopupCopy
            // 
            this.PopupCopy.Image = global::TagScanner.Properties.Resources.CopyHS;
            this.PopupCopy.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupCopy.Name = "PopupCopy";
            this.PopupCopy.ShortcutKeyDisplayString = "^C";
            this.PopupCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.PopupCopy.Size = new System.Drawing.Size(160, 22);
            this.PopupCopy.Text = "&Copy";
            this.PopupCopy.ToolTipText = "Copy the selected item(s) to the Clipboard";
            // 
            // PopupPaste
            // 
            this.PopupPaste.Image = global::TagScanner.Properties.Resources.PasteHS;
            this.PopupPaste.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupPaste.Name = "PopupPaste";
            this.PopupPaste.ShortcutKeyDisplayString = "^V";
            this.PopupPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.PopupPaste.Size = new System.Drawing.Size(160, 22);
            this.PopupPaste.Text = "&Paste";
            this.PopupPaste.ToolTipText = "Paste item(s) from the Clipboard";
            // 
            // PopupDelete
            // 
            this.PopupDelete.Image = global::TagScanner.Properties.Resources.Delete;
            this.PopupDelete.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupDelete.Name = "PopupDelete";
            this.PopupDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.PopupDelete.Size = new System.Drawing.Size(160, 22);
            this.PopupDelete.Text = "Delete";
            this.PopupDelete.ToolTipText = "Delete the selected item(s) from this box";
            // 
            // PopupClear
            // 
            this.PopupClear.Name = "PopupClear";
            this.PopupClear.Size = new System.Drawing.Size(160, 22);
            this.PopupClear.Text = "Cl&ear";
            this.PopupClear.ToolTipText = "Delete all item(s) from this box";
            // 
            // PopupSeparator5
            // 
            this.PopupSeparator5.Name = "PopupSeparator5";
            this.PopupSeparator5.Size = new System.Drawing.Size(157, 6);
            // 
            // PopupSelectAll
            // 
            this.PopupSelectAll.Name = "PopupSelectAll";
            this.PopupSelectAll.ShortcutKeyDisplayString = "^A";
            this.PopupSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.PopupSelectAll.Size = new System.Drawing.Size(160, 22);
            this.PopupSelectAll.Text = "Select &All";
            this.PopupSelectAll.ToolTipText = "Select all the item(s) in this box";
            // 
            // PopupInvertSelection
            // 
            this.PopupInvertSelection.Name = "PopupInvertSelection";
            this.PopupInvertSelection.Size = new System.Drawing.Size(160, 22);
            this.PopupInvertSelection.Text = "&Invert Selection";
            this.PopupInvertSelection.ToolTipText = "Toggle the selected state of all item(s) in this box";
            // 
            // EditMenu
            // 
            this.EditMenu.DropDown = this.PopupMenu;
            this.EditMenu.Name = "EditMenu";
            this.EditMenu.Size = new System.Drawing.Size(39, 20);
            this.EditMenu.Text = "&Edit";
            // 
            // TreeView
            // 
            this.TreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TreeView.ContextMenuStrip = this.PopupMenu;
            this.TreeView.FullRowSelect = true;
            this.TreeView.HideSelection = false;
            this.TreeView.Location = new System.Drawing.Point(3, 3);
            this.TreeView.Name = "TreeView";
            this.TreeView.ShowNodeToolTips = true;
            this.TreeView.Size = new System.Drawing.Size(152, 121);
            this.TreeView.TabIndex = 5;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(751, 537);
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
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
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
            this.splitContainer1.Size = new System.Drawing.Size(751, 537);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 6;
            // 
            // TableLayoutPanel
            // 
            this.TableLayoutPanel.ColumnCount = 3;
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel.Controls.Add(this.lvSelect, 0, 1);
            this.TableLayoutPanel.Controls.Add(this.lvOrderBy, 1, 1);
            this.TableLayoutPanel.Controls.Add(this.lvGroupBy, 2, 1);
            this.TableLayoutPanel.Controls.Add(this.lblSelect, 0, 0);
            this.TableLayoutPanel.Controls.Add(this.lblOrderBy, 1, 0);
            this.TableLayoutPanel.Controls.Add(this.lblGroupBy, 2, 0);
            this.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 2;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel.Size = new System.Drawing.Size(751, 197);
            this.TableLayoutPanel.TabIndex = 25;
            // 
            // lvSelect
            // 
            this.lvSelect.AllowDrop = true;
            this.lvSelect.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvSelect.ContextMenuStrip = this.PopupMenu;
            this.lvSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSelect.HideSelection = false;
            this.lvSelect.Location = new System.Drawing.Point(3, 23);
            this.lvSelect.Name = "lvSelect";
            this.lvSelect.ShowItemToolTips = true;
            this.lvSelect.Size = new System.Drawing.Size(244, 171);
            this.lvSelect.TabIndex = 1;
            this.lvSelect.UseCompatibleStateImageBehavior = false;
            this.lvSelect.View = System.Windows.Forms.View.List;
            // 
            // lvOrderBy
            // 
            this.lvOrderBy.AllowDrop = true;
            this.lvOrderBy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvOrderBy.ContextMenuStrip = this.PopupMenu;
            this.lvOrderBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvOrderBy.HideSelection = false;
            this.lvOrderBy.Location = new System.Drawing.Point(253, 23);
            this.lvOrderBy.Name = "lvOrderBy";
            this.lvOrderBy.ShowItemToolTips = true;
            this.lvOrderBy.Size = new System.Drawing.Size(244, 171);
            this.lvOrderBy.SmallImageList = this.SortByImageList;
            this.lvOrderBy.TabIndex = 25;
            this.lvOrderBy.UseCompatibleStateImageBehavior = false;
            this.lvOrderBy.View = System.Windows.Forms.View.List;
            // 
            // SortByImageList
            // 
            this.SortByImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SortByImageList.ImageStream")));
            this.SortByImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.SortByImageList.Images.SetKeyName(0, "Custom-Icon-Design-Flat-Cute-Arrows-Arrow-Up.16.png");
            this.SortByImageList.Images.SetKeyName(1, "Custom-Icon-Design-Flat-Cute-Arrows-Arrow-Down.16.png");
            // 
            // lvGroupBy
            // 
            this.lvGroupBy.AllowDrop = true;
            this.lvGroupBy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvGroupBy.ContextMenuStrip = this.PopupMenu;
            this.lvGroupBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvGroupBy.HideSelection = false;
            this.lvGroupBy.Location = new System.Drawing.Point(503, 23);
            this.lvGroupBy.Name = "lvGroupBy";
            this.lvGroupBy.ShowItemToolTips = true;
            this.lvGroupBy.Size = new System.Drawing.Size(245, 171);
            this.lvGroupBy.TabIndex = 26;
            this.lvGroupBy.UseCompatibleStateImageBehavior = false;
            this.lvGroupBy.View = System.Windows.Forms.View.List;
            // 
            // lblSelect
            // 
            this.lblSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSelect.Location = new System.Drawing.Point(3, 0);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(244, 20);
            this.lblSelect.TabIndex = 27;
            this.lblSelect.Text = "Select";
            this.lblSelect.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblOrderBy
            // 
            this.lblOrderBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrderBy.Location = new System.Drawing.Point(250, 0);
            this.lblOrderBy.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrderBy.Name = "lblOrderBy";
            this.lblOrderBy.Size = new System.Drawing.Size(250, 20);
            this.lblOrderBy.TabIndex = 28;
            this.lblOrderBy.Text = "Sort By";
            this.lblOrderBy.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblGroupBy
            // 
            this.lblGroupBy.BackColor = System.Drawing.SystemColors.Control;
            this.lblGroupBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGroupBy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroupBy.Location = new System.Drawing.Point(500, 0);
            this.lblGroupBy.Margin = new System.Windows.Forms.Padding(0);
            this.lblGroupBy.Name = "lblGroupBy";
            this.lblGroupBy.Size = new System.Drawing.Size(251, 20);
            this.lblGroupBy.TabIndex = 29;
            this.lblGroupBy.Text = "Group By";
            this.lblGroupBy.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 197);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(751, 36);
            this.panel2.TabIndex = 23;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(691, 5);
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
            this.btnOK.Location = new System.Drawing.Point(627, 5);
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
            this.Toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbTree,
            this.tbList,
            this.toolStripSeparator4,
            this.tbOK,
            this.tbCancel,
            this.toolStripSeparator2,
            this.tbUndo,
            this.tbRedo,
            this.toolStripSeparator1,
            this.tbCut,
            this.tbCopy,
            this.tbPaste,
            this.tbDelete,
            this.toolStripSeparator3,
            this.tbMoveUp,
            this.tbMoveDown});
            this.Toolbar.Location = new System.Drawing.Point(0, 3);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Size = new System.Drawing.Size(33, 302);
            this.Toolbar.TabIndex = 0;
            // 
            // tbTree
            // 
            this.tbTree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbTree.DropDown = this.PopupTreeMenu;
            this.tbTree.Image = global::TagScanner.Properties.Resources.fff_app_tree_16;
            this.tbTree.ImageTransparentColor = System.Drawing.Color.White;
            this.tbTree.Name = "tbTree";
            this.tbTree.Size = new System.Drawing.Size(31, 20);
            this.tbTree.Text = "toolStripSplitButton3";
            // 
            // tbList
            // 
            this.tbList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbList.DropDown = this.PopupListMenu;
            this.tbList.Image = global::TagScanner.Properties.Resources.fff_app_list_16;
            this.tbList.ImageTransparentColor = System.Drawing.Color.White;
            this.tbList.Name = "tbList";
            this.tbList.Size = new System.Drawing.Size(31, 20);
            this.tbList.Text = "toolStripSplitButton4";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(31, 6);
            // 
            // tbOK
            // 
            this.tbOK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbOK.Image = global::TagScanner.Properties.Resources.saveHS;
            this.tbOK.ImageTransparentColor = System.Drawing.Color.White;
            this.tbOK.Name = "tbOK";
            this.tbOK.Size = new System.Drawing.Size(31, 20);
            this.tbOK.Text = "toolStripButton1";
            // 
            // tbCancel
            // 
            this.tbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCancel.Image = global::TagScanner.Properties.Resources.frClose;
            this.tbCancel.ImageTransparentColor = System.Drawing.Color.White;
            this.tbCancel.Name = "tbCancel";
            this.tbCancel.Size = new System.Drawing.Size(31, 20);
            this.tbCancel.Text = "toolStripButton2";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(31, 6);
            // 
            // tbUndo
            // 
            this.tbUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbUndo.Image = global::TagScanner.Properties.Resources.Edit_UndoHS;
            this.tbUndo.ImageTransparentColor = System.Drawing.Color.White;
            this.tbUndo.Name = "tbUndo";
            this.tbUndo.Size = new System.Drawing.Size(31, 20);
            this.tbUndo.Text = "toolStripSplitButton1";
            // 
            // tbRedo
            // 
            this.tbRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbRedo.Image = global::TagScanner.Properties.Resources.Edit_RedoHS;
            this.tbRedo.ImageTransparentColor = System.Drawing.Color.White;
            this.tbRedo.Name = "tbRedo";
            this.tbRedo.Size = new System.Drawing.Size(31, 20);
            this.tbRedo.Text = "toolStripSplitButton2";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(31, 6);
            // 
            // tbCut
            // 
            this.tbCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCut.Image = global::TagScanner.Properties.Resources.CutHS;
            this.tbCut.ImageTransparentColor = System.Drawing.Color.White;
            this.tbCut.Name = "tbCut";
            this.tbCut.Size = new System.Drawing.Size(31, 20);
            this.tbCut.Text = "toolStripButton5";
            // 
            // tbCopy
            // 
            this.tbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCopy.Image = global::TagScanner.Properties.Resources.CopyHS;
            this.tbCopy.ImageTransparentColor = System.Drawing.Color.White;
            this.tbCopy.Name = "tbCopy";
            this.tbCopy.Size = new System.Drawing.Size(31, 20);
            this.tbCopy.Text = "toolStripButton6";
            // 
            // tbPaste
            // 
            this.tbPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbPaste.Image = global::TagScanner.Properties.Resources.PasteHS;
            this.tbPaste.ImageTransparentColor = System.Drawing.Color.White;
            this.tbPaste.Name = "tbPaste";
            this.tbPaste.Size = new System.Drawing.Size(31, 20);
            this.tbPaste.Text = "toolStripButton7";
            // 
            // tbDelete
            // 
            this.tbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbDelete.Image = global::TagScanner.Properties.Resources.Delete;
            this.tbDelete.ImageTransparentColor = System.Drawing.Color.White;
            this.tbDelete.Name = "tbDelete";
            this.tbDelete.Size = new System.Drawing.Size(31, 20);
            this.tbDelete.Text = "toolStripButton8";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(31, 6);
            // 
            // tbMoveUp
            // 
            this.tbMoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbMoveUp.Image = global::TagScanner.Properties.Resources.arrow_Up_16xLG;
            this.tbMoveUp.ImageTransparentColor = System.Drawing.Color.White;
            this.tbMoveUp.Name = "tbMoveUp";
            this.tbMoveUp.Size = new System.Drawing.Size(31, 20);
            this.tbMoveUp.Text = "toolStripButton3";
            // 
            // tbMoveDown
            // 
            this.tbMoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbMoveDown.Image = global::TagScanner.Properties.Resources.arrow_Down_16xLG;
            this.tbMoveDown.ImageTransparentColor = System.Drawing.Color.White;
            this.tbMoveDown.Name = "tbMoveDown";
            this.tbMoveDown.Size = new System.Drawing.Size(31, 20);
            this.tbMoveDown.Text = "toolStripButton4";
            // 
            // MainMenu
            // 
            this.MainMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.EditMenu,
            this.ViewMenu,
            this.HelpMenu});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(784, 24);
            this.MainMenu.TabIndex = 7;
            this.MainMenu.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileSaveAndClose,
            this.FileCloseWithoutSaving});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 20);
            this.FileMenu.Text = "&File";
            // 
            // FileSaveAndClose
            // 
            this.FileSaveAndClose.Image = global::TagScanner.Properties.Resources.saveHS;
            this.FileSaveAndClose.ImageTransparentColor = System.Drawing.Color.White;
            this.FileSaveAndClose.Name = "FileSaveAndClose";
            this.FileSaveAndClose.ShortcutKeyDisplayString = "Enter";
            this.FileSaveAndClose.Size = new System.Drawing.Size(208, 22);
            this.FileSaveAndClose.Text = "&Save && Close";
            // 
            // FileCloseWithoutSaving
            // 
            this.FileCloseWithoutSaving.Image = global::TagScanner.Properties.Resources.frClose;
            this.FileCloseWithoutSaving.ImageTransparentColor = System.Drawing.Color.White;
            this.FileCloseWithoutSaving.Name = "FileCloseWithoutSaving";
            this.FileCloseWithoutSaving.ShortcutKeyDisplayString = "Esc";
            this.FileCloseWithoutSaving.Size = new System.Drawing.Size(208, 22);
            this.FileCloseWithoutSaving.Text = "&Close without saving";
            // 
            // ViewMenu
            // 
            this.ViewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TreeMenu,
            this.ListMenu});
            this.ViewMenu.Name = "ViewMenu";
            this.ViewMenu.Size = new System.Drawing.Size(44, 20);
            this.ViewMenu.Text = "&View";
            // 
            // HelpMenu
            // 
            this.HelpMenu.Name = "HelpMenu";
            this.HelpMenu.Size = new System.Drawing.Size(44, 20);
            this.HelpMenu.Text = "&Help";
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
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "QueryDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Visible Tags";
            this.PopupMenu.ResumeLayout(false);
            this.PopupTreeMenu.ResumeLayout(false);
            this.PopupListMenu.ResumeLayout(false);
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
            this.panel2.ResumeLayout(false);
            this.Toolbar.ResumeLayout(false);
            this.Toolbar.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		public TagScanner.Controls.DoubleBufferedListView ListView;
        public System.Windows.Forms.ColumnHeader chTagName;
        public System.Windows.Forms.ColumnHeader chDataType;
        public System.Windows.Forms.ColumnHeader chCategory;
        public System.Windows.Forms.ColumnHeader chWritable;
        public System.Windows.Forms.TreeView TreeView;
        public System.Windows.Forms.ToolStripContainer toolStripContainer1;
        public Controls.FirstClickMenuStrip MainMenu;
        public System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
        public System.Windows.Forms.ListView lvGroupBy;
        public System.Windows.Forms.ListView lvOrderBy;
        public System.Windows.Forms.ListView lvSelect;
        public System.Windows.Forms.Label lblSelect;
        public System.Windows.Forms.Label lblOrderBy;
        public System.Windows.Forms.Label lblGroupBy;
        public System.Windows.Forms.ContextMenuStrip PopupMenu;
        public System.Windows.Forms.ToolStripMenuItem PopupCut;
        public System.Windows.Forms.ToolStripMenuItem PopupCopy;
        public System.Windows.Forms.ToolStripMenuItem PopupPaste;
        public System.Windows.Forms.ToolStripMenuItem PopupDelete;
        public System.Windows.Forms.ToolStripMenuItem PopupMoveUp;
        public System.Windows.Forms.ToolStripMenuItem PopupMoveDown;
        public System.Windows.Forms.ToolStripMenuItem PopupGroup;
        public System.Windows.Forms.ToolStripMenuItem PopupSelect;
        public System.Windows.Forms.ToolStripSeparator PopupSeparator3;
        public System.Windows.Forms.ToolStripMenuItem PopupSelectAll;
        public System.Windows.Forms.ToolStripMenuItem PopupInvertSelection;
        public System.Windows.Forms.ToolStripMenuItem PopupClear;
        public System.Windows.Forms.ToolStripSeparator PopupSeparator5;
        public System.Windows.Forms.ToolStripMenuItem PopupUndo;
        public System.Windows.Forms.ToolStripMenuItem PopupRedo;
        public System.Windows.Forms.ToolStripSeparator PopupSeparator4;
        public System.Windows.Forms.ToolStripMenuItem EditMenu;
        public System.Windows.Forms.ToolStripMenuItem FileMenu;
        public System.Windows.Forms.ToolStripMenuItem ViewMenu;
        public System.Windows.Forms.ToolStripMenuItem TreeMenu;
        public System.Windows.Forms.ToolStripMenuItem ListMenu;
        public System.Windows.Forms.ToolStripMenuItem FileCloseWithoutSaving;
        public System.Windows.Forms.ToolStripMenuItem HelpMenu;
        public System.Windows.Forms.ToolStripMenuItem FileSaveAndClose;
        public System.Windows.Forms.ToolStrip Toolbar;
        public System.Windows.Forms.ToolStripButton tbOK;
        public System.Windows.Forms.ToolStripButton tbCancel;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton tbMoveUp;
        public System.Windows.Forms.ToolStripButton tbMoveDown;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripSplitButton tbUndo;
        public System.Windows.Forms.ToolStripSplitButton tbRedo;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripButton tbCut;
        public System.Windows.Forms.ToolStripButton tbCopy;
        public System.Windows.Forms.ToolStripButton tbPaste;
        public System.Windows.Forms.ToolStripButton tbDelete;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        public System.Windows.Forms.ToolStripSplitButton tbTree;
        public System.Windows.Forms.ToolStripSplitButton tbList;
        public System.Windows.Forms.ContextMenuStrip PopupTreeMenu;
        public System.Windows.Forms.ContextMenuStrip PopupListMenu;
        public System.Windows.Forms.ToolStripMenuItem TreeAlphabetically;
        public System.Windows.Forms.ToolStripMenuItem TreeByCategory;
        public System.Windows.Forms.ToolStripMenuItem TreeByDataType;
        public System.Windows.Forms.ToolStripMenuItem ListAlphabetically;
        public System.Windows.Forms.ToolStripMenuItem ListByCategory;
        public System.Windows.Forms.ToolStripMenuItem ListByDataType;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        public System.Windows.Forms.ToolStripMenuItem ListNamesOnly;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.ImageList SortByImageList;
        public System.Windows.Forms.ToolStripMenuItem PopupSortAscending;
        public System.Windows.Forms.ToolStripMenuItem PopupSortDescending;
        public System.Windows.Forms.ToolStripSeparator PopupSeparator2;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        public System.Windows.Forms.ToolStripMenuItem ListSmallIcons;
        public System.Windows.Forms.ToolStripMenuItem ListLargeIcons;
        public System.Windows.Forms.ToolStripMenuItem ListTiles;
        public System.Windows.Forms.ToolStripMenuItem PopupTree;
        public System.Windows.Forms.ToolStripMenuItem PopupList;
        public System.Windows.Forms.ToolStripSeparator PopupSeparator1;
        public System.Windows.Forms.ColumnHeader chSortable;
    }
}