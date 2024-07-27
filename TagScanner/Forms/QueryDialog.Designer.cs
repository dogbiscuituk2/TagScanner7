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
            this.PopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PopupMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupSort = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupSortAscending = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupSortDescending = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.PopupUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.PopupCut = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupClear = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupSelectSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.PopupSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupInvertSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lvSelect = new System.Windows.Forms.ListView();
            this.lvOrderBy = new System.Windows.Forms.ListView();
            this.lvGroupBy = new System.Windows.Forms.ListView();
            this.lblSelect = new System.Windows.Forms.Label();
            this.lblOrderBy = new System.Windows.Forms.Label();
            this.lblGroupBy = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.EditMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu = new TagScanner.Controls.FirstClickMenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSaveAndClose = new System.Windows.Forms.ToolStripMenuItem();
            this.FileCloseWithoutSaving = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenu = new System.Windows.Forms.ToolStripMenuItem();
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
            this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenu.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.TableLayoutPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListView
            // 
            this.ListView.AllowColumnReorder = true;
            this.ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTagName,
            this.chCategory,
            this.chDataType,
            this.chWritable});
            this.ListView.ContextMenuStrip = this.PopupMenu;
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
            // PopupMenu
            // 
            this.PopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PopupMoveUp,
            this.PopupMoveDown,
            this.PopupSelect,
            this.PopupSort,
            this.PopupGroup,
            this.toolStripMenuItem10,
            this.PopupUndo,
            this.PopupRedo,
            this.toolStripMenuItem1,
            this.PopupCut,
            this.PopupCopy,
            this.PopupPaste,
            this.PopupDelete,
            this.PopupClear,
            this.PopupSelectSeparator,
            this.PopupSelectAll,
            this.PopupInvertSelection});
            this.PopupMenu.Name = "PopupTargetMenu";
            this.PopupMenu.OwnerItem = this.EditMenu;
            this.PopupMenu.Size = new System.Drawing.Size(160, 330);
            // 
            // PopupMoveUp
            // 
            this.PopupMoveUp.Image = global::TagScanner.Properties.Resources.arrow_Up_16xLG;
            this.PopupMoveUp.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupMoveUp.Name = "PopupMoveUp";
            this.PopupMoveUp.ShortcutKeyDisplayString = "^↑";
            this.PopupMoveUp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.PopupMoveUp.Size = new System.Drawing.Size(159, 22);
            this.PopupMoveUp.Text = "Move Up";
            // 
            // PopupMoveDown
            // 
            this.PopupMoveDown.Image = global::TagScanner.Properties.Resources.arrow_Down_16xLG;
            this.PopupMoveDown.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupMoveDown.Name = "PopupMoveDown";
            this.PopupMoveDown.ShortcutKeyDisplayString = "^↓";
            this.PopupMoveDown.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.PopupMoveDown.Size = new System.Drawing.Size(159, 22);
            this.PopupMoveDown.Text = "Move Down";
            // 
            // PopupSelect
            // 
            this.PopupSelect.Name = "PopupSelect";
            this.PopupSelect.ShortcutKeyDisplayString = "";
            this.PopupSelect.Size = new System.Drawing.Size(159, 22);
            this.PopupSelect.Text = "&Select";
            // 
            // PopupSort
            // 
            this.PopupSort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PopupSortAscending,
            this.PopupSortDescending});
            this.PopupSort.Name = "PopupSort";
            this.PopupSort.ShortcutKeyDisplayString = "";
            this.PopupSort.Size = new System.Drawing.Size(159, 22);
            this.PopupSort.Text = "S&ort";
            // 
            // PopupSortAscending
            // 
            this.PopupSortAscending.Name = "PopupSortAscending";
            this.PopupSortAscending.ShortcutKeyDisplayString = "";
            this.PopupSortAscending.Size = new System.Drawing.Size(136, 22);
            this.PopupSortAscending.Text = "&Ascending";
            // 
            // PopupSortDescending
            // 
            this.PopupSortDescending.Name = "PopupSortDescending";
            this.PopupSortDescending.ShortcutKeyDisplayString = "";
            this.PopupSortDescending.Size = new System.Drawing.Size(136, 22);
            this.PopupSortDescending.Text = "&Descending";
            // 
            // PopupGroup
            // 
            this.PopupGroup.Name = "PopupGroup";
            this.PopupGroup.ShortcutKeyDisplayString = "";
            this.PopupGroup.Size = new System.Drawing.Size(159, 22);
            this.PopupGroup.Text = "&Group";
            this.PopupGroup.ToolTipText = "Include this Tag in the Custom Group?";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(156, 6);
            // 
            // PopupUndo
            // 
            this.PopupUndo.Name = "PopupUndo";
            this.PopupUndo.ShortcutKeyDisplayString = "^Z";
            this.PopupUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.PopupUndo.Size = new System.Drawing.Size(159, 22);
            this.PopupUndo.Text = "Undo";
            // 
            // PopupRedo
            // 
            this.PopupRedo.Name = "PopupRedo";
            this.PopupRedo.ShortcutKeyDisplayString = "^Y";
            this.PopupRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.PopupRedo.Size = new System.Drawing.Size(159, 22);
            this.PopupRedo.Text = "Redo";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(156, 6);
            // 
            // PopupCut
            // 
            this.PopupCut.Image = global::TagScanner.Properties.Resources.CutHS;
            this.PopupCut.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupCut.Name = "PopupCut";
            this.PopupCut.ShortcutKeyDisplayString = "^X";
            this.PopupCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.PopupCut.Size = new System.Drawing.Size(159, 22);
            this.PopupCut.Text = "Cu&t";
            // 
            // PopupCopy
            // 
            this.PopupCopy.Image = global::TagScanner.Properties.Resources.CopyHS;
            this.PopupCopy.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupCopy.Name = "PopupCopy";
            this.PopupCopy.ShortcutKeyDisplayString = "^C";
            this.PopupCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.PopupCopy.Size = new System.Drawing.Size(159, 22);
            this.PopupCopy.Text = "&Copy";
            // 
            // PopupPaste
            // 
            this.PopupPaste.Image = global::TagScanner.Properties.Resources.PasteHS;
            this.PopupPaste.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupPaste.Name = "PopupPaste";
            this.PopupPaste.ShortcutKeyDisplayString = "^V";
            this.PopupPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.PopupPaste.Size = new System.Drawing.Size(159, 22);
            this.PopupPaste.Text = "&Paste";
            // 
            // PopupDelete
            // 
            this.PopupDelete.Image = global::TagScanner.Properties.Resources.Delete;
            this.PopupDelete.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupDelete.Name = "PopupDelete";
            this.PopupDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.PopupDelete.Size = new System.Drawing.Size(159, 22);
            this.PopupDelete.Text = "&Delete";
            // 
            // PopupClear
            // 
            this.PopupClear.Name = "PopupClear";
            this.PopupClear.Size = new System.Drawing.Size(159, 22);
            this.PopupClear.Text = "Cl&ear";
            // 
            // PopupSelectSeparator
            // 
            this.PopupSelectSeparator.Name = "PopupSelectSeparator";
            this.PopupSelectSeparator.Size = new System.Drawing.Size(156, 6);
            // 
            // PopupSelectAll
            // 
            this.PopupSelectAll.Name = "PopupSelectAll";
            this.PopupSelectAll.ShortcutKeyDisplayString = "^A";
            this.PopupSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.PopupSelectAll.Size = new System.Drawing.Size(159, 22);
            this.PopupSelectAll.Text = "Select &All";
            // 
            // PopupInvertSelection
            // 
            this.PopupInvertSelection.Name = "PopupInvertSelection";
            this.PopupInvertSelection.Size = new System.Drawing.Size(159, 22);
            this.PopupInvertSelection.Text = "&Invert Selection";
            // 
            // TreeView
            // 
            this.TreeView.ContextMenuStrip = this.PopupMenu;
            this.TreeView.HideSelection = false;
            this.TreeView.Location = new System.Drawing.Point(163, 4);
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
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(784, 537);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.splitContainer1.Size = new System.Drawing.Size(784, 537);
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
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 2;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel.Size = new System.Drawing.Size(714, 233);
            this.TableLayoutPanel.TabIndex = 25;
            // 
            // lvSelect
            // 
            this.lvSelect.AllowDrop = true;
            this.lvSelect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvSelect.ContextMenuStrip = this.PopupMenu;
            this.lvSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSelect.HideSelection = false;
            this.lvSelect.Location = new System.Drawing.Point(0, 20);
            this.lvSelect.Margin = new System.Windows.Forms.Padding(0);
            this.lvSelect.Name = "lvSelect";
            this.lvSelect.ShowItemToolTips = true;
            this.lvSelect.Size = new System.Drawing.Size(238, 213);
            this.lvSelect.TabIndex = 1;
            this.lvSelect.UseCompatibleStateImageBehavior = false;
            this.lvSelect.View = System.Windows.Forms.View.List;
            // 
            // lvOrderBy
            // 
            this.lvOrderBy.AllowDrop = true;
            this.lvOrderBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvOrderBy.ContextMenuStrip = this.PopupMenu;
            this.lvOrderBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvOrderBy.HideSelection = false;
            this.lvOrderBy.Location = new System.Drawing.Point(238, 20);
            this.lvOrderBy.Margin = new System.Windows.Forms.Padding(0);
            this.lvOrderBy.Name = "lvOrderBy";
            this.lvOrderBy.ShowItemToolTips = true;
            this.lvOrderBy.Size = new System.Drawing.Size(238, 213);
            this.lvOrderBy.TabIndex = 25;
            this.lvOrderBy.UseCompatibleStateImageBehavior = false;
            this.lvOrderBy.View = System.Windows.Forms.View.List;
            // 
            // lvGroupBy
            // 
            this.lvGroupBy.AllowDrop = true;
            this.lvGroupBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvGroupBy.ContextMenuStrip = this.PopupMenu;
            this.lvGroupBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvGroupBy.HideSelection = false;
            this.lvGroupBy.Location = new System.Drawing.Point(476, 20);
            this.lvGroupBy.Margin = new System.Windows.Forms.Padding(0);
            this.lvGroupBy.Name = "lvGroupBy";
            this.lvGroupBy.ShowItemToolTips = true;
            this.lvGroupBy.Size = new System.Drawing.Size(238, 213);
            this.lvGroupBy.TabIndex = 26;
            this.lvGroupBy.UseCompatibleStateImageBehavior = false;
            this.lvGroupBy.View = System.Windows.Forms.View.List;
            // 
            // lblSelect
            // 
            this.lblSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSelect.Location = new System.Drawing.Point(3, 0);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(232, 20);
            this.lblSelect.TabIndex = 27;
            this.lblSelect.Text = "Select";
            this.lblSelect.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblOrderBy
            // 
            this.lblOrderBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrderBy.Location = new System.Drawing.Point(241, 0);
            this.lblOrderBy.Name = "lblOrderBy";
            this.lblOrderBy.Size = new System.Drawing.Size(232, 20);
            this.lblOrderBy.TabIndex = 28;
            this.lblOrderBy.Text = "Sort";
            this.lblOrderBy.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblGroupBy
            // 
            this.lblGroupBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGroupBy.Location = new System.Drawing.Point(479, 0);
            this.lblGroupBy.Name = "lblGroupBy";
            this.lblGroupBy.Size = new System.Drawing.Size(232, 20);
            this.lblGroupBy.TabIndex = 29;
            this.lblGroupBy.Text = "Group";
            this.lblGroupBy.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(714, 0);
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
            // EditMenu
            // 
            this.EditMenu.DropDown = this.PopupMenu;
            this.EditMenu.Name = "EditMenu";
            this.EditMenu.Size = new System.Drawing.Size(39, 20);
            this.EditMenu.Text = "&Edit";
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
            this.FileSaveAndClose.Name = "FileSaveAndClose";
            this.FileSaveAndClose.ShortcutKeyDisplayString = "Enter";
            this.FileSaveAndClose.Size = new System.Drawing.Size(208, 22);
            this.FileSaveAndClose.Text = "&Save && Close";
            // 
            // FileCloseWithoutSaving
            // 
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
            // TreeMenu
            // 
            this.TreeMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TreeAlphabetically,
            this.TreeByCategory,
            this.TreeByDataType});
            this.TreeMenu.Name = "TreeMenu";
            this.TreeMenu.Size = new System.Drawing.Size(95, 22);
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
            this.ListMenu.Size = new System.Drawing.Size(95, 22);
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "QueryDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Visible Tags";
            this.PopupMenu.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
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
        public System.Windows.Forms.ToolStripContainer toolStripContainer1;
        public Controls.FirstClickMenuStrip MainMenu;
        public System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Panel panel2;
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
        public System.Windows.Forms.ToolStripMenuItem PopupSort;
        public System.Windows.Forms.ToolStripMenuItem PopupSortAscending;
        public System.Windows.Forms.ToolStripMenuItem PopupSortDescending;
        public System.Windows.Forms.ToolStripMenuItem PopupSelect;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
        public System.Windows.Forms.ToolStripMenuItem PopupSelectAll;
        public System.Windows.Forms.ToolStripMenuItem PopupInvertSelection;
        public System.Windows.Forms.ToolStripMenuItem PopupClear;
        public System.Windows.Forms.ToolStripSeparator PopupSelectSeparator;
        public System.Windows.Forms.ToolStripMenuItem PopupUndo;
        public System.Windows.Forms.ToolStripMenuItem PopupRedo;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem EditMenu;
        public System.Windows.Forms.ToolStripMenuItem FileMenu;
        public System.Windows.Forms.ToolStripMenuItem ViewMenu;
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
        public System.Windows.Forms.ToolStripMenuItem FileCloseWithoutSaving;
        public System.Windows.Forms.ToolStripMenuItem HelpMenu;
        public System.Windows.Forms.ToolStripMenuItem FileSaveAndClose;
    }
}