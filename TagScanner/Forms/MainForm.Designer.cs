namespace TagScanner.Forms
{
	partial class MainForm
	{

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
		public void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SplitContainerMain = new System.Windows.Forms.SplitContainer();
            this.SplitContainerLeft = new System.Windows.Forms.SplitContainer();
            this.GridElementHost = new System.Windows.Forms.Integration.ElementHost();
            this.TablePopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TablePopupPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.TablePopupPlayAddToQueue = new System.Windows.Forms.ToolStripMenuItem();
            this.TablePopupPlayNewPlaylist = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.TablePopupCut = new System.Windows.Forms.ToolStripMenuItem();
            this.TablePopupCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.TablePopupPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.TablePopupDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripSeparator();
            this.TablePopupSelectColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.TablePopupMoreActions = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterPanel = new System.Windows.Forms.GroupBox();
            this.FilterPopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PopupFilterCase = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripSeparator();
            this.PopupFilterApply = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupFilterClear = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupFilterEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripSeparator();
            this.PopupFilterClose = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterControl = new TagScanner.Controls.FilterControl();
            this.SplitContainerRight = new System.Windows.Forms.SplitContainer();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.FindReplacePanel = new System.Windows.Forms.GroupBox();
            this.FindReplacePopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PopupSearchFields = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripSeparator();
            this.PopupMatchCase = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupWholeWord = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupUseRegex = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupPreserveCase = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripSeparator();
            this.PopupFindNext = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupFindPrevious = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupFindAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripSeparator();
            this.PopupReplaceNext = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupReplaceAll = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupReplaceSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.PopupCloseFindReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.FindReplaceControl = new TagScanner.Forms.FindReplaceControl();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabTags = new System.Windows.Forms.TabPage();
            this.PropertyGridPopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PropertyGridPopupTagVisibility = new System.Windows.Forms.ToolStripMenuItem();
            this.PropertyGridPopupRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.PropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.tabPlayer = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.PlaylistElementHost = new System.Windows.Forms.Integration.ElementHost();
            this.PlayerPopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PlayerPopupSelectColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.MediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.RecentLibraryPopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddRecentLibrary = new System.Windows.Forms.ToolStripMenuItem();
            this.tbReopen = new System.Windows.Forms.ToolStripMenuItem();
            this.tbAddRecentLibrary = new System.Windows.Forms.ToolStripMenuItem();
            this.FileReopen = new System.Windows.Forms.ToolStripMenuItem();
            this.RecentFolderPopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddRecentFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tbAddRecentFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.UndoPopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbUndo = new System.Windows.Forms.ToolStripSplitButton();
            this.RedoPopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbRedo = new System.Windows.Forms.ToolStripSplitButton();
            this.ToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStrip = new TagScanner.Controls.FirstClickToolStrip();
            this.tbNew = new System.Windows.Forms.ToolStripSplitButton();
            this.tbNewLibrary = new System.Windows.Forms.ToolStripMenuItem();
            this.tbNewWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tbOpen = new System.Windows.Forms.ToolStripSplitButton();
            this.tbOpenLibrary = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSave = new System.Windows.Forms.ToolStripSplitButton();
            this.tbSaveLibrary = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSaveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tbCut = new System.Windows.Forms.ToolStripButton();
            this.tbCopy = new System.Windows.Forms.ToolStripButton();
            this.tbPaste = new System.Windows.Forms.ToolStripButton();
            this.tbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbFindReplace = new System.Windows.Forms.ToolStripSplitButton();
            this.tbFind = new System.Windows.Forms.ToolStripMenuItem();
            this.tbReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.tbFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tbAdd = new System.Windows.Forms.ToolStripSplitButton();
            this.tbAddMedia = new System.Windows.Forms.ToolStripMenuItem();
            this.tbAddFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tbAddLibrary = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tbPlay = new System.Windows.Forms.ToolStripSplitButton();
            this.tbAddToQueue = new System.Windows.Forms.ToolStripMenuItem();
            this.tbNewPlaylist = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu = new TagScanner.Controls.FirstClickMenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.FileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.FileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSaveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.FileClose = new System.Windows.Forms.ToolStripMenuItem();
            this.FileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.EditMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.EditUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.EditRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.EditCut = new System.Windows.Forms.ToolStripMenuItem();
            this.EditCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.EditPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.EditDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripSeparator();
            this.EditFind = new System.Windows.Forms.ToolStripMenuItem();
            this.EditReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.EditFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.EditSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.EditInvertSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewArtistAlbum = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewArtist = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewAlbum = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.ViewYear = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewGenre = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.ViewTitle = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewCustom = new System.Windows.Forms.ToolStripMenuItem();
            this.AddMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AddMedia = new System.Windows.Forms.ToolStripMenuItem();
            this.AddFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.AddLibrary = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.AddOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.WindowMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.WindowNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerMain)).BeginInit();
            this.SplitContainerMain.Panel1.SuspendLayout();
            this.SplitContainerMain.Panel2.SuspendLayout();
            this.SplitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerLeft)).BeginInit();
            this.SplitContainerLeft.Panel2.SuspendLayout();
            this.SplitContainerLeft.SuspendLayout();
            this.TablePopupMenu.SuspendLayout();
            this.FilterPanel.SuspendLayout();
            this.FilterPopupMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerRight)).BeginInit();
            this.SplitContainerRight.Panel1.SuspendLayout();
            this.SplitContainerRight.Panel2.SuspendLayout();
            this.SplitContainerRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.FindReplacePanel.SuspendLayout();
            this.FindReplacePopupMenu.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.tabTags.SuspendLayout();
            this.PropertyGridPopupMenu.SuspendLayout();
            this.tabPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.PlayerPopupMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).BeginInit();
            this.ToolStripContainer.BottomToolStripPanel.SuspendLayout();
            this.ToolStripContainer.ContentPanel.SuspendLayout();
            this.ToolStripContainer.LeftToolStripPanel.SuspendLayout();
            this.ToolStripContainer.TopToolStripPanel.SuspendLayout();
            this.ToolStripContainer.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.ToolStrip.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitContainerMain
            // 
            this.SplitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.SplitContainerMain.Margin = new System.Windows.Forms.Padding(0);
            this.SplitContainerMain.Name = "SplitContainerMain";
            // 
            // SplitContainerMain.Panel1
            // 
            this.SplitContainerMain.Panel1.Controls.Add(this.SplitContainerLeft);
            this.SplitContainerMain.Panel1.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            // 
            // SplitContainerMain.Panel2
            // 
            this.SplitContainerMain.Panel2.Controls.Add(this.SplitContainerRight);
            this.SplitContainerMain.Panel2MinSize = 200;
            this.SplitContainerMain.Size = new System.Drawing.Size(751, 514);
            this.SplitContainerMain.SplitterDistance = 543;
            this.SplitContainerMain.SplitterWidth = 5;
            this.SplitContainerMain.TabIndex = 7;
            // 
            // SplitContainerLeft
            // 
            this.SplitContainerLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerLeft.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplitContainerLeft.Location = new System.Drawing.Point(4, 0);
            this.SplitContainerLeft.Name = "SplitContainerLeft";
            this.SplitContainerLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.SplitContainerLeft.Panel1Collapsed = true;
            this.SplitContainerLeft.Panel1MinSize = 202;
            // 
            // SplitContainerLeft.Panel2
            // 
            this.SplitContainerLeft.Panel2.Controls.Add(this.GridElementHost);
            this.SplitContainerLeft.Panel2.Controls.Add(this.FilterPanel);
            this.SplitContainerLeft.Panel2MinSize = 260;
            this.SplitContainerLeft.Size = new System.Drawing.Size(539, 514);
            this.SplitContainerLeft.SplitterDistance = 202;
            this.SplitContainerLeft.TabIndex = 3;
            // 
            // GridElementHost
            // 
            this.GridElementHost.AllowDrop = true;
            this.GridElementHost.ContextMenuStrip = this.TablePopupMenu;
            this.GridElementHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridElementHost.Location = new System.Drawing.Point(0, 48);
            this.GridElementHost.Margin = new System.Windows.Forms.Padding(0);
            this.GridElementHost.Name = "GridElementHost";
            this.GridElementHost.Size = new System.Drawing.Size(539, 466);
            this.GridElementHost.TabIndex = 0;
            this.GridElementHost.Text = "GridContainerHost";
            this.GridElementHost.Child = null;
            // 
            // TablePopupMenu
            // 
            this.TablePopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TablePopupPlay,
            this.toolStripMenuItem6,
            this.TablePopupCut,
            this.TablePopupCopy,
            this.TablePopupPaste,
            this.TablePopupDelete,
            this.toolStripMenuItem14,
            this.TablePopupSelectColumns,
            this.TablePopupMoreActions});
            this.TablePopupMenu.Name = "PopupMenu";
            this.TablePopupMenu.Size = new System.Drawing.Size(166, 170);
            // 
            // TablePopupPlay
            // 
            this.TablePopupPlay.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TablePopupPlayAddToQueue,
            this.TablePopupPlayNewPlaylist});
            this.TablePopupPlay.Image = global::TagScanner.Properties.Resources.PlayHS;
            this.TablePopupPlay.ImageTransparentColor = System.Drawing.Color.White;
            this.TablePopupPlay.Name = "TablePopupPlay";
            this.TablePopupPlay.Size = new System.Drawing.Size(165, 22);
            this.TablePopupPlay.Text = "Pl&ay";
            // 
            // TablePopupPlayAddToQueue
            // 
            this.TablePopupPlayAddToQueue.Name = "TablePopupPlayAddToQueue";
            this.TablePopupPlayAddToQueue.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.TablePopupPlayAddToQueue.Size = new System.Drawing.Size(189, 22);
            this.TablePopupPlayAddToQueue.Text = "Add to &Queue";
            // 
            // TablePopupPlayNewPlaylist
            // 
            this.TablePopupPlayNewPlaylist.Name = "TablePopupPlayNewPlaylist";
            this.TablePopupPlayNewPlaylist.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F9)));
            this.TablePopupPlayNewPlaylist.Size = new System.Drawing.Size(189, 22);
            this.TablePopupPlayNewPlaylist.Text = "&New Playlist";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(162, 6);
            // 
            // TablePopupCut
            // 
            this.TablePopupCut.Image = global::TagScanner.Properties.Resources.CutHS;
            this.TablePopupCut.Name = "TablePopupCut";
            this.TablePopupCut.ShortcutKeyDisplayString = "^X";
            this.TablePopupCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.TablePopupCut.Size = new System.Drawing.Size(165, 22);
            this.TablePopupCut.Text = "Cu&t";
            // 
            // TablePopupCopy
            // 
            this.TablePopupCopy.Image = global::TagScanner.Properties.Resources.CopyHS;
            this.TablePopupCopy.Name = "TablePopupCopy";
            this.TablePopupCopy.ShortcutKeyDisplayString = "^C";
            this.TablePopupCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.TablePopupCopy.Size = new System.Drawing.Size(165, 22);
            this.TablePopupCopy.Text = "&Copy";
            // 
            // TablePopupPaste
            // 
            this.TablePopupPaste.Image = global::TagScanner.Properties.Resources.PasteHS;
            this.TablePopupPaste.Name = "TablePopupPaste";
            this.TablePopupPaste.ShortcutKeyDisplayString = "^V";
            this.TablePopupPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.TablePopupPaste.Size = new System.Drawing.Size(165, 22);
            this.TablePopupPaste.Text = "&Paste";
            // 
            // TablePopupDelete
            // 
            this.TablePopupDelete.Image = global::TagScanner.Properties.Resources.Delete;
            this.TablePopupDelete.ImageTransparentColor = System.Drawing.Color.White;
            this.TablePopupDelete.Name = "TablePopupDelete";
            this.TablePopupDelete.Size = new System.Drawing.Size(165, 22);
            this.TablePopupDelete.Text = "&Delete";
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(162, 6);
            // 
            // TablePopupSelectColumns
            // 
            this.TablePopupSelectColumns.Image = global::TagScanner.Properties.Resources.fff_Table_select_column_16;
            this.TablePopupSelectColumns.Name = "TablePopupSelectColumns";
            this.TablePopupSelectColumns.Size = new System.Drawing.Size(165, 22);
            this.TablePopupSelectColumns.Text = "&Select Columns...";
            // 
            // TablePopupMoreActions
            // 
            this.TablePopupMoreActions.Name = "TablePopupMoreActions";
            this.TablePopupMoreActions.Size = new System.Drawing.Size(165, 22);
            this.TablePopupMoreActions.Text = "&File Operations...";
            // 
            // FilterPanel
            // 
            this.FilterPanel.ContextMenuStrip = this.FilterPopupMenu;
            this.FilterPanel.Controls.Add(this.FilterControl);
            this.FilterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FilterPanel.Location = new System.Drawing.Point(0, 0);
            this.FilterPanel.Name = "FilterPanel";
            this.FilterPanel.Size = new System.Drawing.Size(539, 48);
            this.FilterPanel.TabIndex = 1;
            this.FilterPanel.TabStop = false;
            this.FilterPanel.Text = "Filter";
            this.FilterPanel.Visible = false;
            // 
            // FilterPopupMenu
            // 
            this.FilterPopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PopupFilterCase,
            this.toolStripMenuItem18,
            this.PopupFilterApply,
            this.PopupFilterClear,
            this.PopupFilterEdit,
            this.toolStripMenuItem19,
            this.PopupFilterClose});
            this.FilterPopupMenu.Name = "FilterPopupMenu";
            this.FilterPopupMenu.Size = new System.Drawing.Size(137, 126);
            // 
            // PopupFilterCase
            // 
            this.PopupFilterCase.Image = global::TagScanner.Properties.Resources.frCase;
            this.PopupFilterCase.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupFilterCase.Name = "PopupFilterCase";
            this.PopupFilterCase.Size = new System.Drawing.Size(136, 22);
            this.PopupFilterCase.Text = "Match &Case";
            // 
            // toolStripMenuItem18
            // 
            this.toolStripMenuItem18.Name = "toolStripMenuItem18";
            this.toolStripMenuItem18.Size = new System.Drawing.Size(133, 6);
            // 
            // PopupFilterApply
            // 
            this.PopupFilterApply.Image = global::TagScanner.Properties.Resources.frApply;
            this.PopupFilterApply.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupFilterApply.Name = "PopupFilterApply";
            this.PopupFilterApply.Size = new System.Drawing.Size(136, 22);
            this.PopupFilterApply.Text = "&Apply Filter";
            // 
            // PopupFilterClear
            // 
            this.PopupFilterClear.Image = global::TagScanner.Properties.Resources.frClear;
            this.PopupFilterClear.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupFilterClear.Name = "PopupFilterClear";
            this.PopupFilterClear.Size = new System.Drawing.Size(136, 22);
            this.PopupFilterClear.Text = "C&lear Filter";
            // 
            // PopupFilterEdit
            // 
            this.PopupFilterEdit.Image = global::TagScanner.Properties.Resources.frEdit;
            this.PopupFilterEdit.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupFilterEdit.Name = "PopupFilterEdit";
            this.PopupFilterEdit.Size = new System.Drawing.Size(136, 22);
            this.PopupFilterEdit.Text = "&Edit Filter";
            // 
            // toolStripMenuItem19
            // 
            this.toolStripMenuItem19.Name = "toolStripMenuItem19";
            this.toolStripMenuItem19.Size = new System.Drawing.Size(133, 6);
            // 
            // PopupFilterClose
            // 
            this.PopupFilterClose.Image = global::TagScanner.Properties.Resources.frClose;
            this.PopupFilterClose.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupFilterClose.Name = "PopupFilterClose";
            this.PopupFilterClose.Size = new System.Drawing.Size(136, 22);
            this.PopupFilterClose.Text = "Cl&ose Filter";
            // 
            // FilterControl
            // 
            this.FilterControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterControl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterControl.Location = new System.Drawing.Point(3, 21);
            this.FilterControl.Margin = new System.Windows.Forms.Padding(4);
            this.FilterControl.Name = "FilterControl";
            this.FilterControl.Size = new System.Drawing.Size(533, 24);
            this.FilterControl.TabIndex = 0;
            // 
            // SplitContainerRight
            // 
            this.SplitContainerRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerRight.Location = new System.Drawing.Point(0, 0);
            this.SplitContainerRight.Margin = new System.Windows.Forms.Padding(4);
            this.SplitContainerRight.Name = "SplitContainerRight";
            this.SplitContainerRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainerRight.Panel1
            // 
            this.SplitContainerRight.Panel1.Controls.Add(this.PictureBox);
            this.SplitContainerRight.Panel1.Controls.Add(this.FindReplacePanel);
            this.SplitContainerRight.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 3);
            // 
            // SplitContainerRight.Panel2
            // 
            this.SplitContainerRight.Panel2.Controls.Add(this.TabControl);
            this.SplitContainerRight.Size = new System.Drawing.Size(203, 514);
            this.SplitContainerRight.SplitterDistance = 200;
            this.SplitContainerRight.SplitterWidth = 5;
            this.SplitContainerRight.TabIndex = 0;
            // 
            // PictureBox
            // 
            this.PictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBox.Location = new System.Drawing.Point(0, 92);
            this.PictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(200, 105);
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            // 
            // FindReplacePanel
            // 
            this.FindReplacePanel.ContextMenuStrip = this.FindReplacePopupMenu;
            this.FindReplacePanel.Controls.Add(this.FindReplaceControl);
            this.FindReplacePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FindReplacePanel.Location = new System.Drawing.Point(0, 0);
            this.FindReplacePanel.Name = "FindReplacePanel";
            this.FindReplacePanel.Size = new System.Drawing.Size(200, 92);
            this.FindReplacePanel.TabIndex = 1;
            this.FindReplacePanel.TabStop = false;
            this.FindReplacePanel.Text = "Find/Replace";
            this.FindReplacePanel.Visible = false;
            // 
            // FindReplacePopupMenu
            // 
            this.FindReplacePopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PopupSearchFields,
            this.toolStripMenuItem17,
            this.PopupMatchCase,
            this.PopupWholeWord,
            this.PopupUseRegex,
            this.PopupPreserveCase,
            this.toolStripMenuItem15,
            this.PopupFindNext,
            this.PopupFindPrevious,
            this.PopupFindAll,
            this.toolStripMenuItem13,
            this.PopupReplaceNext,
            this.PopupReplaceAll,
            this.PopupReplaceSeparator,
            this.PopupCloseFindReplace});
            this.FindReplacePopupMenu.Name = "FindReplacePopupMenu";
            this.FindReplacePopupMenu.Size = new System.Drawing.Size(197, 270);
            // 
            // PopupSearchFields
            // 
            this.PopupSearchFields.Image = global::TagScanner.Properties.Resources.frSearch;
            this.PopupSearchFields.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupSearchFields.Name = "PopupSearchFields";
            this.PopupSearchFields.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.PopupSearchFields.Size = new System.Drawing.Size(196, 22);
            this.PopupSearchFields.Text = "&Search Fields...";
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.Size = new System.Drawing.Size(193, 6);
            // 
            // PopupMatchCase
            // 
            this.PopupMatchCase.Image = global::TagScanner.Properties.Resources.frCase;
            this.PopupMatchCase.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupMatchCase.Name = "PopupMatchCase";
            this.PopupMatchCase.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.PopupMatchCase.Size = new System.Drawing.Size(196, 22);
            this.PopupMatchCase.Text = "Match &Case";
            // 
            // PopupWholeWord
            // 
            this.PopupWholeWord.Image = global::TagScanner.Properties.Resources.frWholeWord;
            this.PopupWholeWord.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupWholeWord.Name = "PopupWholeWord";
            this.PopupWholeWord.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.W)));
            this.PopupWholeWord.Size = new System.Drawing.Size(196, 22);
            this.PopupWholeWord.Text = "&Whole Word";
            // 
            // PopupUseRegex
            // 
            this.PopupUseRegex.Image = global::TagScanner.Properties.Resources.frRegex;
            this.PopupUseRegex.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupUseRegex.Name = "PopupUseRegex";
            this.PopupUseRegex.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.PopupUseRegex.Size = new System.Drawing.Size(196, 22);
            this.PopupUseRegex.Text = "Use R&egex";
            // 
            // PopupPreserveCase
            // 
            this.PopupPreserveCase.Name = "PopupPreserveCase";
            this.PopupPreserveCase.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.PopupPreserveCase.Size = new System.Drawing.Size(196, 22);
            this.PopupPreserveCase.Text = "Preser&ve Case";
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(193, 6);
            // 
            // PopupFindNext
            // 
            this.PopupFindNext.Image = global::TagScanner.Properties.Resources.frFindNext;
            this.PopupFindNext.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupFindNext.Name = "PopupFindNext";
            this.PopupFindNext.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.PopupFindNext.Size = new System.Drawing.Size(196, 22);
            this.PopupFindNext.Text = "Find &Next";
            // 
            // PopupFindPrevious
            // 
            this.PopupFindPrevious.Image = global::TagScanner.Properties.Resources.frFindPrevious;
            this.PopupFindPrevious.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupFindPrevious.Name = "PopupFindPrevious";
            this.PopupFindPrevious.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F3)));
            this.PopupFindPrevious.Size = new System.Drawing.Size(196, 22);
            this.PopupFindPrevious.Text = "Find &Previous";
            // 
            // PopupFindAll
            // 
            this.PopupFindAll.Name = "PopupFindAll";
            this.PopupFindAll.Size = new System.Drawing.Size(196, 22);
            this.PopupFindAll.Text = "Find All";
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(193, 6);
            // 
            // PopupReplaceNext
            // 
            this.PopupReplaceNext.Image = global::TagScanner.Properties.Resources.frReplaceNext;
            this.PopupReplaceNext.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupReplaceNext.Name = "PopupReplaceNext";
            this.PopupReplaceNext.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.PopupReplaceNext.Size = new System.Drawing.Size(196, 22);
            this.PopupReplaceNext.Text = "Replace Next";
            // 
            // PopupReplaceAll
            // 
            this.PopupReplaceAll.Image = global::TagScanner.Properties.Resources.frReplaceAll;
            this.PopupReplaceAll.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupReplaceAll.Name = "PopupReplaceAll";
            this.PopupReplaceAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.PopupReplaceAll.Size = new System.Drawing.Size(196, 22);
            this.PopupReplaceAll.Text = "Replace All";
            // 
            // PopupReplaceSeparator
            // 
            this.PopupReplaceSeparator.Name = "PopupReplaceSeparator";
            this.PopupReplaceSeparator.Size = new System.Drawing.Size(193, 6);
            // 
            // PopupCloseFindReplace
            // 
            this.PopupCloseFindReplace.Image = global::TagScanner.Properties.Resources.frClose;
            this.PopupCloseFindReplace.ImageTransparentColor = System.Drawing.Color.White;
            this.PopupCloseFindReplace.Name = "PopupCloseFindReplace";
            this.PopupCloseFindReplace.Size = new System.Drawing.Size(196, 22);
            this.PopupCloseFindReplace.Text = "Close find/replace";
            // 
            // FindReplaceControl
            // 
            this.FindReplaceControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FindReplaceControl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FindReplaceControl.Location = new System.Drawing.Point(3, 21);
            this.FindReplaceControl.Margin = new System.Windows.Forms.Padding(4);
            this.FindReplaceControl.Name = "FindReplaceControl";
            this.FindReplaceControl.Size = new System.Drawing.Size(194, 68);
            this.FindReplaceControl.TabIndex = 0;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabTags);
            this.TabControl.Controls.Add(this.tabPlayer);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Margin = new System.Windows.Forms.Padding(0);
            this.TabControl.Multiline = true;
            this.TabControl.Name = "TabControl";
            this.TabControl.Padding = new System.Drawing.Point(0, 0);
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(203, 309);
            this.TabControl.TabIndex = 0;
            // 
            // tabTags
            // 
            this.tabTags.BackColor = System.Drawing.SystemColors.Control;
            this.tabTags.ContextMenuStrip = this.PropertyGridPopupMenu;
            this.tabTags.Controls.Add(this.PropertyGrid);
            this.tabTags.Location = new System.Drawing.Point(4, 26);
            this.tabTags.Margin = new System.Windows.Forms.Padding(0);
            this.tabTags.Name = "tabTags";
            this.tabTags.Size = new System.Drawing.Size(195, 279);
            this.tabTags.TabIndex = 0;
            this.tabTags.Text = "Tags";
            // 
            // PropertyGridPopupMenu
            // 
            this.PropertyGridPopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PropertyGridPopupTagVisibility,
            this.PropertyGridPopupRefresh});
            this.PropertyGridPopupMenu.Name = "PropertyGridPopupMenu";
            this.PropertyGridPopupMenu.Size = new System.Drawing.Size(141, 48);
            // 
            // PropertyGridPopupTagVisibility
            // 
            this.PropertyGridPopupTagVisibility.Image = global::TagScanner.Properties.Resources.fff_Table_select_column_16;
            this.PropertyGridPopupTagVisibility.Name = "PropertyGridPopupTagVisibility";
            this.PropertyGridPopupTagVisibility.Size = new System.Drawing.Size(140, 22);
            this.PropertyGridPopupTagVisibility.Text = "Select &Tags...";
            // 
            // PropertyGridPopupRefresh
            // 
            this.PropertyGridPopupRefresh.Image = global::TagScanner.Properties.Resources.refresh_16xLG;
            this.PropertyGridPopupRefresh.Name = "PropertyGridPopupRefresh";
            this.PropertyGridPopupRefresh.Size = new System.Drawing.Size(140, 22);
            this.PropertyGridPopupRefresh.Text = "&Refresh";
            // 
            // PropertyGrid
            // 
            this.PropertyGrid.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.PropertyGrid.ContextMenuStrip = this.PropertyGridPopupMenu;
            this.PropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.PropertyGrid.Margin = new System.Windows.Forms.Padding(0);
            this.PropertyGrid.Name = "PropertyGrid";
            this.PropertyGrid.Size = new System.Drawing.Size(195, 279);
            this.PropertyGrid.TabIndex = 0;
            // 
            // tabPlayer
            // 
            this.tabPlayer.Controls.Add(this.splitContainer3);
            this.tabPlayer.Location = new System.Drawing.Point(4, 22);
            this.tabPlayer.Margin = new System.Windows.Forms.Padding(4);
            this.tabPlayer.Name = "tabPlayer";
            this.tabPlayer.Padding = new System.Windows.Forms.Padding(4);
            this.tabPlayer.Size = new System.Drawing.Size(195, 283);
            this.tabPlayer.TabIndex = 4;
            this.tabPlayer.Text = "Player";
            this.tabPlayer.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(4, 4);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.PlaylistElementHost);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.MediaPlayer);
            this.splitContainer3.Size = new System.Drawing.Size(187, 275);
            this.splitContainer3.SplitterDistance = 69;
            this.splitContainer3.SplitterWidth = 5;
            this.splitContainer3.TabIndex = 1;
            // 
            // PlaylistElementHost
            // 
            this.PlaylistElementHost.ContextMenuStrip = this.PlayerPopupMenu;
            this.PlaylistElementHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlaylistElementHost.Location = new System.Drawing.Point(0, 0);
            this.PlaylistElementHost.Margin = new System.Windows.Forms.Padding(4);
            this.PlaylistElementHost.Name = "PlaylistElementHost";
            this.PlaylistElementHost.Size = new System.Drawing.Size(187, 69);
            this.PlaylistElementHost.TabIndex = 0;
            this.PlaylistElementHost.Text = "elementHost1";
            this.PlaylistElementHost.Child = null;
            // 
            // PlayerPopupMenu
            // 
            this.PlayerPopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PlayerPopupSelectColumns});
            this.PlayerPopupMenu.Name = "PlayerPopupMenu";
            this.PlayerPopupMenu.Size = new System.Drawing.Size(166, 26);
            // 
            // PlayerPopupSelectColumns
            // 
            this.PlayerPopupSelectColumns.Image = global::TagScanner.Properties.Resources.fff_Table_select_column_16;
            this.PlayerPopupSelectColumns.Name = "PlayerPopupSelectColumns";
            this.PlayerPopupSelectColumns.Size = new System.Drawing.Size(165, 22);
            this.PlayerPopupSelectColumns.Text = "&Select Columns...";
            // 
            // MediaPlayer
            // 
            this.MediaPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MediaPlayer.Enabled = true;
            this.MediaPlayer.Location = new System.Drawing.Point(0, 0);
            this.MediaPlayer.Margin = new System.Windows.Forms.Padding(4);
            this.MediaPlayer.Name = "MediaPlayer";
            this.MediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MediaPlayer.OcxState")));
            this.MediaPlayer.Size = new System.Drawing.Size(187, 201);
            this.MediaPlayer.TabIndex = 0;
            // 
            // RecentLibraryPopupMenu
            // 
            this.RecentLibraryPopupMenu.Name = "RecentLibraryPopupMenu";
            this.RecentLibraryPopupMenu.OwnerItem = this.FileReopen;
            this.RecentLibraryPopupMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // AddRecentLibrary
            // 
            this.AddRecentLibrary.DropDown = this.RecentLibraryPopupMenu;
            this.AddRecentLibrary.Name = "AddRecentLibrary";
            this.AddRecentLibrary.Size = new System.Drawing.Size(149, 22);
            this.AddRecentLibrary.Text = "R&ecent Library";
            // 
            // tbReopen
            // 
            this.tbReopen.DropDown = this.RecentLibraryPopupMenu;
            this.tbReopen.Name = "tbReopen";
            this.tbReopen.Size = new System.Drawing.Size(136, 22);
            this.tbReopen.Text = "&Reopen";
            // 
            // tbAddRecentLibrary
            // 
            this.tbAddRecentLibrary.DropDown = this.RecentLibraryPopupMenu;
            this.tbAddRecentLibrary.Name = "tbAddRecentLibrary";
            this.tbAddRecentLibrary.Size = new System.Drawing.Size(149, 22);
            this.tbAddRecentLibrary.Text = "R&ecent Library";
            // 
            // FileReopen
            // 
            this.FileReopen.DropDown = this.RecentLibraryPopupMenu;
            this.FileReopen.Name = "FileReopen";
            this.FileReopen.Size = new System.Drawing.Size(161, 22);
            this.FileReopen.Text = "&Reopen";
            // 
            // RecentFolderPopupMenu
            // 
            this.RecentFolderPopupMenu.Name = "RecentFolderPopupMenu";
            this.RecentFolderPopupMenu.OwnerItem = this.tbAddRecentFolder;
            this.RecentFolderPopupMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // AddRecentFolder
            // 
            this.AddRecentFolder.DropDown = this.RecentFolderPopupMenu;
            this.AddRecentFolder.Name = "AddRecentFolder";
            this.AddRecentFolder.Size = new System.Drawing.Size(149, 22);
            this.AddRecentFolder.Text = "&Recent Folder";
            // 
            // tbAddRecentFolder
            // 
            this.tbAddRecentFolder.DropDown = this.RecentFolderPopupMenu;
            this.tbAddRecentFolder.Name = "tbAddRecentFolder";
            this.tbAddRecentFolder.Size = new System.Drawing.Size(149, 22);
            this.tbAddRecentFolder.Text = "&Recent Folder";
            // 
            // UndoPopupMenu
            // 
            this.UndoPopupMenu.Name = "UndoPopupMenu";
            this.UndoPopupMenu.OwnerItem = this.tbUndo;
            this.UndoPopupMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // tbUndo
            // 
            this.tbUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbUndo.DropDown = this.UndoPopupMenu;
            this.tbUndo.Image = global::TagScanner.Properties.Resources.Edit_UndoHS;
            this.tbUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbUndo.Name = "tbUndo";
            this.tbUndo.Size = new System.Drawing.Size(31, 20);
            this.tbUndo.Text = "tbUndo";
            this.tbUndo.ToolTipText = "Undo (^Z)";
            // 
            // RedoPopupMenu
            // 
            this.RedoPopupMenu.Name = "RedoPopupMenu";
            this.RedoPopupMenu.OwnerItem = this.tbRedo;
            this.RedoPopupMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // tbRedo
            // 
            this.tbRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbRedo.DropDown = this.RedoPopupMenu;
            this.tbRedo.Image = global::TagScanner.Properties.Resources.Edit_RedoHS;
            this.tbRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbRedo.Name = "tbRedo";
            this.tbRedo.Size = new System.Drawing.Size(31, 20);
            this.tbRedo.Text = "tbRedo";
            this.tbRedo.ToolTipText = "Redo (^Y)";
            // 
            // ToolStripContainer
            // 
            // 
            // ToolStripContainer.BottomToolStripPanel
            // 
            this.ToolStripContainer.BottomToolStripPanel.Controls.Add(this.StatusBar);
            // 
            // ToolStripContainer.ContentPanel
            // 
            this.ToolStripContainer.ContentPanel.Controls.Add(this.SplitContainerMain);
            this.ToolStripContainer.ContentPanel.Size = new System.Drawing.Size(751, 514);
            this.ToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // ToolStripContainer.LeftToolStripPanel
            // 
            this.ToolStripContainer.LeftToolStripPanel.Controls.Add(this.ToolStrip);
            this.ToolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.ToolStripContainer.Name = "ToolStripContainer";
            this.ToolStripContainer.Size = new System.Drawing.Size(784, 561);
            this.ToolStripContainer.TabIndex = 11;
            this.ToolStripContainer.Text = "toolStripContainer1";
            // 
            // ToolStripContainer.TopToolStripPanel
            // 
            this.ToolStripContainer.TopToolStripPanel.Controls.Add(this.MainMenu);
            // 
            // StatusBar
            // 
            this.StatusBar.Dock = System.Windows.Forms.DockStyle.None;
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.StatusBar.Location = new System.Drawing.Point(0, 0);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.StatusBar.Size = new System.Drawing.Size(784, 22);
            this.StatusBar.TabIndex = 10;
            this.StatusBar.Text = "Status";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // ToolStrip
            // 
            this.ToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbNew,
            this.tbOpen,
            this.tbSave,
            this.toolStripSeparator1,
            this.tbUndo,
            this.tbRedo,
            this.toolStripSeparator3,
            this.tbCut,
            this.tbCopy,
            this.tbPaste,
            this.tbDelete,
            this.toolStripSeparator2,
            this.tbFindReplace,
            this.tbFilter,
            this.toolStripSeparator4,
            this.tbAdd,
            this.toolStripSeparator5,
            this.tbPlay});
            this.ToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.ToolStrip.Location = new System.Drawing.Point(0, 3);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(33, 340);
            this.ToolStrip.TabIndex = 11;
            this.ToolStrip.Text = "toolStrip1";
            // 
            // tbNew
            // 
            this.tbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbNewLibrary,
            this.tbNewWindow});
            this.tbNew.Image = global::TagScanner.Properties.Resources.NewDocumentHS;
            this.tbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbNew.Name = "tbNew";
            this.tbNew.Size = new System.Drawing.Size(31, 20);
            this.tbNew.Text = "tbNew";
            this.tbNew.ToolTipText = "New";
            // 
            // tbNewLibrary
            // 
            this.tbNewLibrary.Image = global::TagScanner.Properties.Resources.NewDocumentHS;
            this.tbNewLibrary.Name = "tbNewLibrary";
            this.tbNewLibrary.ShortcutKeyDisplayString = "^N";
            this.tbNewLibrary.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tbNewLibrary.Size = new System.Drawing.Size(171, 22);
            this.tbNewLibrary.Text = "&New Library";
            // 
            // tbNewWindow
            // 
            this.tbNewWindow.Name = "tbNewWindow";
            this.tbNewWindow.ShortcutKeyDisplayString = "^W";
            this.tbNewWindow.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.tbNewWindow.Size = new System.Drawing.Size(171, 22);
            this.tbNewWindow.Text = "New &Window";
            // 
            // tbOpen
            // 
            this.tbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbOpen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbOpenLibrary,
            this.tbReopen});
            this.tbOpen.Image = global::TagScanner.Properties.Resources.openHS;
            this.tbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbOpen.Name = "tbOpen";
            this.tbOpen.Size = new System.Drawing.Size(31, 20);
            this.tbOpen.Text = "tbOpen";
            this.tbOpen.ToolTipText = "Open";
            // 
            // tbOpenLibrary
            // 
            this.tbOpenLibrary.Image = global::TagScanner.Properties.Resources.openfolderHS;
            this.tbOpenLibrary.Name = "tbOpenLibrary";
            this.tbOpenLibrary.ShortcutKeyDisplayString = "^O";
            this.tbOpenLibrary.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tbOpenLibrary.Size = new System.Drawing.Size(136, 22);
            this.tbOpenLibrary.Text = "&Open...";
            // 
            // tbSave
            // 
            this.tbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSave.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbSaveLibrary,
            this.tbSaveAs,
            this.tbSaveAll});
            this.tbSave.Image = global::TagScanner.Properties.Resources.saveHS;
            this.tbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSave.Name = "tbSave";
            this.tbSave.Size = new System.Drawing.Size(31, 20);
            this.tbSave.Text = "tbSave";
            this.tbSave.ToolTipText = "Save";
            // 
            // tbSaveLibrary
            // 
            this.tbSaveLibrary.Image = global::TagScanner.Properties.Resources.saveHS;
            this.tbSaveLibrary.Name = "tbSaveLibrary";
            this.tbSaveLibrary.ShortcutKeyDisplayString = "^S";
            this.tbSaveLibrary.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tbSaveLibrary.Size = new System.Drawing.Size(123, 22);
            this.tbSaveLibrary.Text = "&Save";
            // 
            // tbSaveAs
            // 
            this.tbSaveAs.Name = "tbSaveAs";
            this.tbSaveAs.Size = new System.Drawing.Size(123, 22);
            this.tbSaveAs.Text = "Save &As...";
            // 
            // tbSaveAll
            // 
            this.tbSaveAll.Image = global::TagScanner.Properties.Resources.SaveAllHS;
            this.tbSaveAll.Name = "tbSaveAll";
            this.tbSaveAll.Size = new System.Drawing.Size(123, 22);
            this.tbSaveAll.Text = "Save A&ll";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(31, 6);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(31, 6);
            // 
            // tbCut
            // 
            this.tbCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCut.Image = global::TagScanner.Properties.Resources.CutHS;
            this.tbCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbCut.Name = "tbCut";
            this.tbCut.Size = new System.Drawing.Size(31, 20);
            this.tbCut.Text = "Cu&t";
            this.tbCut.ToolTipText = "Cut (^X)";
            // 
            // tbCopy
            // 
            this.tbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCopy.Image = global::TagScanner.Properties.Resources.CopyHS;
            this.tbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbCopy.Name = "tbCopy";
            this.tbCopy.Size = new System.Drawing.Size(31, 20);
            this.tbCopy.Text = "&Copy";
            this.tbCopy.ToolTipText = "Copy (^C)";
            // 
            // tbPaste
            // 
            this.tbPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbPaste.Enabled = false;
            this.tbPaste.Image = global::TagScanner.Properties.Resources.PasteHS;
            this.tbPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbPaste.Name = "tbPaste";
            this.tbPaste.Size = new System.Drawing.Size(31, 20);
            this.tbPaste.Text = "&Paste";
            this.tbPaste.ToolTipText = "Paste (^V)";
            // 
            // tbDelete
            // 
            this.tbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbDelete.Image = global::TagScanner.Properties.Resources.Delete;
            this.tbDelete.ImageTransparentColor = System.Drawing.Color.White;
            this.tbDelete.Name = "tbDelete";
            this.tbDelete.Size = new System.Drawing.Size(31, 20);
            this.tbDelete.Text = "&Delete";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(31, 6);
            // 
            // tbFindReplace
            // 
            this.tbFindReplace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbFindReplace.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbFind,
            this.tbReplace});
            this.tbFindReplace.Image = global::TagScanner.Properties.Resources.ZoomHS;
            this.tbFindReplace.ImageTransparentColor = System.Drawing.Color.White;
            this.tbFindReplace.Name = "tbFindReplace";
            this.tbFindReplace.Size = new System.Drawing.Size(31, 20);
            this.tbFindReplace.Text = "Find";
            this.tbFindReplace.ToolTipText = "Find/Replace";
            // 
            // tbFind
            // 
            this.tbFind.Image = global::TagScanner.Properties.Resources.ZoomHS;
            this.tbFind.ImageTransparentColor = System.Drawing.Color.White;
            this.tbFind.Name = "tbFind";
            this.tbFind.ShortcutKeyDisplayString = "^F";
            this.tbFind.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.tbFind.Size = new System.Drawing.Size(148, 22);
            this.tbFind.Text = "&Find...";
            // 
            // tbReplace
            // 
            this.tbReplace.Name = "tbReplace";
            this.tbReplace.ShortcutKeyDisplayString = "^H";
            this.tbReplace.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.tbReplace.Size = new System.Drawing.Size(148, 22);
            this.tbReplace.Text = "&Replace...";
            // 
            // tbFilter
            // 
            this.tbFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbFilter.Image = global::TagScanner.Properties.Resources.fff_app_Filter_16;
            this.tbFilter.ImageTransparentColor = System.Drawing.Color.White;
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(31, 20);
            this.tbFilter.Text = "Filter";
            this.tbFilter.ToolTipText = "Filter (^L)";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(31, 6);
            // 
            // tbAdd
            // 
            this.tbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbAddMedia,
            this.tbAddFolder,
            this.tbAddLibrary,
            this.toolStripMenuItem12,
            this.tbAddRecentFolder,
            this.tbAddRecentLibrary});
            this.tbAdd.Image = global::TagScanner.Properties.Resources.action_add_16xLG;
            this.tbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbAdd.Name = "tbAdd";
            this.tbAdd.Size = new System.Drawing.Size(31, 20);
            this.tbAdd.Text = "Add";
            // 
            // tbAddMedia
            // 
            this.tbAddMedia.Name = "tbAddMedia";
            this.tbAddMedia.Size = new System.Drawing.Size(149, 22);
            this.tbAddMedia.Text = "&Media...";
            // 
            // tbAddFolder
            // 
            this.tbAddFolder.Name = "tbAddFolder";
            this.tbAddFolder.Size = new System.Drawing.Size(149, 22);
            this.tbAddFolder.Text = "&Folder...";
            // 
            // tbAddLibrary
            // 
            this.tbAddLibrary.Name = "tbAddLibrary";
            this.tbAddLibrary.Size = new System.Drawing.Size(149, 22);
            this.tbAddLibrary.Text = "&Library...";
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(146, 6);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(31, 6);
            // 
            // tbPlay
            // 
            this.tbPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbPlay.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbAddToQueue,
            this.tbNewPlaylist});
            this.tbPlay.Image = global::TagScanner.Properties.Resources.PlayHS;
            this.tbPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbPlay.Name = "tbPlay";
            this.tbPlay.Size = new System.Drawing.Size(31, 20);
            this.tbPlay.Text = "toolStripSplitButton1";
            this.tbPlay.ToolTipText = "Play";
            // 
            // tbAddToQueue
            // 
            this.tbAddToQueue.Name = "tbAddToQueue";
            this.tbAddToQueue.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.tbAddToQueue.Size = new System.Drawing.Size(189, 22);
            this.tbAddToQueue.Text = "&Add to Queue";
            // 
            // tbNewPlaylist
            // 
            this.tbNewPlaylist.Name = "tbNewPlaylist";
            this.tbNewPlaylist.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F9)));
            this.tbNewPlaylist.Size = new System.Drawing.Size(189, 22);
            this.tbNewPlaylist.Text = "&New Playlist";
            // 
            // MainMenu
            // 
            this.MainMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.MainMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.EditMenu,
            this.ViewMenu,
            this.AddMenu,
            this.WindowMenu,
            this.HelpMenu});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.MainMenu.Size = new System.Drawing.Size(784, 25);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileNew,
            this.FileOpen,
            this.FileReopen,
            this.toolStripMenuItem1,
            this.FileSave,
            this.FileSaveAs,
            this.FileSaveAll,
            this.toolStripMenuItem5,
            this.FileClose,
            this.FileExit});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 19);
            this.FileMenu.Text = "&File";
            // 
            // FileNew
            // 
            this.FileNew.Image = global::TagScanner.Properties.Resources.NewDocumentHS;
            this.FileNew.Name = "FileNew";
            this.FileNew.ShortcutKeyDisplayString = "^N";
            this.FileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.FileNew.Size = new System.Drawing.Size(161, 22);
            this.FileNew.Text = "&New Library";
            // 
            // FileOpen
            // 
            this.FileOpen.Image = global::TagScanner.Properties.Resources.openHS;
            this.FileOpen.Name = "FileOpen";
            this.FileOpen.ShortcutKeyDisplayString = "^O";
            this.FileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.FileOpen.Size = new System.Drawing.Size(161, 22);
            this.FileOpen.Text = "&Open...";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(158, 6);
            // 
            // FileSave
            // 
            this.FileSave.Image = global::TagScanner.Properties.Resources.saveHS;
            this.FileSave.Name = "FileSave";
            this.FileSave.ShortcutKeyDisplayString = "^S";
            this.FileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.FileSave.Size = new System.Drawing.Size(161, 22);
            this.FileSave.Text = "&Save";
            // 
            // FileSaveAs
            // 
            this.FileSaveAs.Name = "FileSaveAs";
            this.FileSaveAs.Size = new System.Drawing.Size(161, 22);
            this.FileSaveAs.Text = "Save &As...";
            // 
            // FileSaveAll
            // 
            this.FileSaveAll.Image = global::TagScanner.Properties.Resources.SaveAllHS;
            this.FileSaveAll.Name = "FileSaveAll";
            this.FileSaveAll.Size = new System.Drawing.Size(161, 22);
            this.FileSaveAll.Text = "Save A&ll";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(158, 6);
            // 
            // FileClose
            // 
            this.FileClose.Name = "FileClose";
            this.FileClose.ShortcutKeyDisplayString = "^F4";
            this.FileClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this.FileClose.Size = new System.Drawing.Size(161, 22);
            this.FileClose.Text = "&Close";
            // 
            // FileExit
            // 
            this.FileExit.Name = "FileExit";
            this.FileExit.ShortcutKeyDisplayString = "Alt+F4";
            this.FileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.FileExit.Size = new System.Drawing.Size(161, 22);
            this.FileExit.Text = "E&xit";
            // 
            // EditMenu
            // 
            this.EditMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditUndo,
            this.EditRedo,
            this.toolStripMenuItem10,
            this.EditCut,
            this.EditCopy,
            this.EditPaste,
            this.EditDelete,
            this.toolStripMenuItem11,
            this.EditFind,
            this.EditReplace,
            this.toolStripMenuItem2,
            this.EditFilter,
            this.EditSelectAll,
            this.EditInvertSelection});
            this.EditMenu.Name = "EditMenu";
            this.EditMenu.Size = new System.Drawing.Size(39, 19);
            this.EditMenu.Text = "&Edit";
            // 
            // EditUndo
            // 
            this.EditUndo.Image = global::TagScanner.Properties.Resources.Edit_UndoHS;
            this.EditUndo.Name = "EditUndo";
            this.EditUndo.ShortcutKeyDisplayString = "^Z";
            this.EditUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.EditUndo.Size = new System.Drawing.Size(155, 22);
            this.EditUndo.Text = "&Undo";
            // 
            // EditRedo
            // 
            this.EditRedo.Image = global::TagScanner.Properties.Resources.Edit_RedoHS;
            this.EditRedo.Name = "EditRedo";
            this.EditRedo.ShortcutKeyDisplayString = "^Y";
            this.EditRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.EditRedo.Size = new System.Drawing.Size(155, 22);
            this.EditRedo.Text = "&Redo";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(152, 6);
            // 
            // EditCut
            // 
            this.EditCut.Image = global::TagScanner.Properties.Resources.CutHS;
            this.EditCut.Name = "EditCut";
            this.EditCut.ShortcutKeyDisplayString = "^X";
            this.EditCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.EditCut.Size = new System.Drawing.Size(155, 22);
            this.EditCut.Text = "Cu&t";
            // 
            // EditCopy
            // 
            this.EditCopy.Image = global::TagScanner.Properties.Resources.CopyHS;
            this.EditCopy.Name = "EditCopy";
            this.EditCopy.ShortcutKeyDisplayString = "^C";
            this.EditCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.EditCopy.Size = new System.Drawing.Size(155, 22);
            this.EditCopy.Text = "&Copy";
            // 
            // EditPaste
            // 
            this.EditPaste.Enabled = false;
            this.EditPaste.Image = global::TagScanner.Properties.Resources.PasteHS;
            this.EditPaste.Name = "EditPaste";
            this.EditPaste.ShortcutKeyDisplayString = "^V";
            this.EditPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.EditPaste.Size = new System.Drawing.Size(155, 22);
            this.EditPaste.Text = "&Paste";
            // 
            // EditDelete
            // 
            this.EditDelete.Image = global::TagScanner.Properties.Resources.Delete;
            this.EditDelete.ImageTransparentColor = System.Drawing.Color.White;
            this.EditDelete.Name = "EditDelete";
            this.EditDelete.ShortcutKeyDisplayString = "";
            this.EditDelete.Size = new System.Drawing.Size(155, 22);
            this.EditDelete.Text = "&Delete";
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(152, 6);
            // 
            // EditFind
            // 
            this.EditFind.Image = global::TagScanner.Properties.Resources.ZoomHS;
            this.EditFind.Name = "EditFind";
            this.EditFind.ShortcutKeyDisplayString = "^F";
            this.EditFind.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.EditFind.Size = new System.Drawing.Size(155, 22);
            this.EditFind.Text = "&Find...";
            // 
            // EditReplace
            // 
            this.EditReplace.Name = "EditReplace";
            this.EditReplace.ShortcutKeyDisplayString = "^H";
            this.EditReplace.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.EditReplace.Size = new System.Drawing.Size(155, 22);
            this.EditReplace.Text = "&Replace...";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 6);
            // 
            // EditFilter
            // 
            this.EditFilter.Image = global::TagScanner.Properties.Resources.fff_app_Filter_16;
            this.EditFilter.ImageTransparentColor = System.Drawing.Color.White;
            this.EditFilter.Name = "EditFilter";
            this.EditFilter.ShortcutKeyDisplayString = "^L";
            this.EditFilter.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.EditFilter.Size = new System.Drawing.Size(155, 22);
            this.EditFilter.Text = "Fi&lter";
            // 
            // EditSelectAll
            // 
            this.EditSelectAll.Name = "EditSelectAll";
            this.EditSelectAll.ShortcutKeyDisplayString = "^A";
            this.EditSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.EditSelectAll.Size = new System.Drawing.Size(155, 22);
            this.EditSelectAll.Text = "Select &All";
            // 
            // EditInvertSelection
            // 
            this.EditInvertSelection.Name = "EditInvertSelection";
            this.EditInvertSelection.Size = new System.Drawing.Size(155, 22);
            this.EditInvertSelection.Text = "&Invert Selection";
            // 
            // ViewMenu
            // 
            this.ViewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewArtistAlbum,
            this.ViewArtist,
            this.ViewAlbum,
            this.toolStripMenuItem4,
            this.ViewYear,
            this.ViewGenre,
            this.toolStripMenuItem7,
            this.ViewTitle,
            this.ViewCustom});
            this.ViewMenu.Name = "ViewMenu";
            this.ViewMenu.Size = new System.Drawing.Size(44, 19);
            this.ViewMenu.Text = "&View";
            // 
            // ViewArtistAlbum
            // 
            this.ViewArtistAlbum.Name = "ViewArtistAlbum";
            this.ViewArtistAlbum.Size = new System.Drawing.Size(180, 22);
            this.ViewArtistAlbum.Text = "&Artist/Album";
            // 
            // ViewArtist
            // 
            this.ViewArtist.Name = "ViewArtist";
            this.ViewArtist.Size = new System.Drawing.Size(180, 22);
            this.ViewArtist.Text = "A&rtist";
            // 
            // ViewAlbum
            // 
            this.ViewAlbum.Name = "ViewAlbum";
            this.ViewAlbum.Size = new System.Drawing.Size(180, 22);
            this.ViewAlbum.Text = "A&lbum";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(177, 6);
            // 
            // ViewYear
            // 
            this.ViewYear.Name = "ViewYear";
            this.ViewYear.Size = new System.Drawing.Size(180, 22);
            this.ViewYear.Text = "&Year";
            // 
            // ViewGenre
            // 
            this.ViewGenre.Name = "ViewGenre";
            this.ViewGenre.Size = new System.Drawing.Size(180, 22);
            this.ViewGenre.Text = "&Genre";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(177, 6);
            // 
            // ViewTitle
            // 
            this.ViewTitle.Name = "ViewTitle";
            this.ViewTitle.Size = new System.Drawing.Size(180, 22);
            this.ViewTitle.Text = "&Title";
            // 
            // ViewCustom
            // 
            this.ViewCustom.Name = "ViewCustom";
            this.ViewCustom.Size = new System.Drawing.Size(180, 22);
            this.ViewCustom.Text = "&Custom...";
            // 
            // AddMenu
            // 
            this.AddMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddMedia,
            this.AddFolder,
            this.AddLibrary,
            this.toolStripMenuItem3,
            this.AddRecentFolder,
            this.AddRecentLibrary,
            this.toolStripMenuItem9,
            this.AddOptions});
            this.AddMenu.Name = "AddMenu";
            this.AddMenu.Size = new System.Drawing.Size(41, 19);
            this.AddMenu.Text = "&Add";
            // 
            // AddMedia
            // 
            this.AddMedia.Image = global::TagScanner.Properties.Resources.action_add_16xLG;
            this.AddMedia.Name = "AddMedia";
            this.AddMedia.Size = new System.Drawing.Size(149, 22);
            this.AddMedia.Text = "&Media...";
            // 
            // AddFolder
            // 
            this.AddFolder.Name = "AddFolder";
            this.AddFolder.Size = new System.Drawing.Size(149, 22);
            this.AddFolder.Text = "&Folder...";
            // 
            // AddLibrary
            // 
            this.AddLibrary.Name = "AddLibrary";
            this.AddLibrary.Size = new System.Drawing.Size(149, 22);
            this.AddLibrary.Text = "&Library...";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(146, 6);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(146, 6);
            // 
            // AddOptions
            // 
            this.AddOptions.Name = "AddOptions";
            this.AddOptions.Size = new System.Drawing.Size(149, 22);
            this.AddOptions.Text = "File &Options...";
            // 
            // WindowMenu
            // 
            this.WindowMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WindowNew,
            this.toolStripMenuItem8});
            this.WindowMenu.Name = "WindowMenu";
            this.WindowMenu.Size = new System.Drawing.Size(63, 19);
            this.WindowMenu.Text = "&Window";
            // 
            // WindowNew
            // 
            this.WindowNew.Image = global::TagScanner.Properties.Resources.NewDocumentHS;
            this.WindowNew.Name = "WindowNew";
            this.WindowNew.ShortcutKeyDisplayString = "^W";
            this.WindowNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.WindowNew.Size = new System.Drawing.Size(124, 22);
            this.WindowNew.Text = "&New";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(121, 6);
            // 
            // HelpMenu
            // 
            this.HelpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpAbout});
            this.HelpMenu.Name = "HelpMenu";
            this.HelpMenu.Size = new System.Drawing.Size(44, 19);
            this.HelpMenu.Text = "&Help";
            // 
            // HelpAbout
            // 
            this.HelpAbout.Image = global::TagScanner.Properties.Resources.info;
            this.HelpAbout.Name = "HelpAbout";
            this.HelpAbout.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.HelpAbout.Size = new System.Drawing.Size(126, 22);
            this.HelpAbout.Text = "&About";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.ToolStripContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "ID3 Tag Explorer";
            this.SplitContainerMain.Panel1.ResumeLayout(false);
            this.SplitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerMain)).EndInit();
            this.SplitContainerMain.ResumeLayout(false);
            this.SplitContainerLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerLeft)).EndInit();
            this.SplitContainerLeft.ResumeLayout(false);
            this.TablePopupMenu.ResumeLayout(false);
            this.FilterPanel.ResumeLayout(false);
            this.FilterPopupMenu.ResumeLayout(false);
            this.SplitContainerRight.Panel1.ResumeLayout(false);
            this.SplitContainerRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerRight)).EndInit();
            this.SplitContainerRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.FindReplacePanel.ResumeLayout(false);
            this.FindReplacePopupMenu.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.tabTags.ResumeLayout(false);
            this.PropertyGridPopupMenu.ResumeLayout(false);
            this.tabPlayer.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.PlayerPopupMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).EndInit();
            this.ToolStripContainer.BottomToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer.BottomToolStripPanel.PerformLayout();
            this.ToolStripContainer.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer.LeftToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer.LeftToolStripPanel.PerformLayout();
            this.ToolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer.TopToolStripPanel.PerformLayout();
            this.ToolStripContainer.ResumeLayout(false);
            this.ToolStripContainer.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.SplitContainer SplitContainerMain;
		public System.Windows.Forms.SplitContainer SplitContainerRight;
		public System.Windows.Forms.PictureBox PictureBox;
		public System.Windows.Forms.ContextMenuStrip TablePopupMenu;
		public System.Windows.Forms.ToolStripMenuItem TablePopupSelectColumns;
		public System.Windows.Forms.TabControl TabControl;
		public System.Windows.Forms.TabPage tabTags;
		public System.Windows.Forms.PropertyGrid PropertyGrid;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
		public System.Windows.Forms.ToolStripMenuItem TablePopupPlay;
		public AxWMPLib.AxWindowsMediaPlayer MediaPlayer;
		public System.Windows.Forms.TabPage tabPlayer;
        public System.Windows.Forms.ContextMenuStrip PropertyGridPopupMenu;
		public System.Windows.Forms.ToolStripMenuItem PropertyGridPopupTagVisibility;
        public System.Windows.Forms.SplitContainer splitContainer3;
		public System.Windows.Forms.ToolStripMenuItem TablePopupPlayAddToQueue;
		public System.Windows.Forms.ToolStripMenuItem TablePopupPlayNewPlaylist;
		public System.Windows.Forms.Integration.ElementHost PlaylistElementHost;
        public System.Windows.Forms.Integration.ElementHost GridElementHost;
        public System.Windows.Forms.ToolStripMenuItem TablePopupMoreActions;
        public System.Windows.Forms.ContextMenuStrip UndoPopupMenu;
        public System.Windows.Forms.ContextMenuStrip RedoPopupMenu;
        public System.Windows.Forms.ContextMenuStrip RecentLibraryPopupMenu;
        public System.Windows.Forms.ContextMenuStrip RecentFolderPopupMenu;
        public System.Windows.Forms.ToolStripMenuItem TablePopupCut;
        public System.Windows.Forms.ToolStripMenuItem TablePopupCopy;
        public System.Windows.Forms.ToolStripMenuItem TablePopupPaste;
        public System.Windows.Forms.ToolStripMenuItem TablePopupDelete;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem14;
        public System.Windows.Forms.ToolStripMenuItem PropertyGridPopupRefresh;
        public System.Windows.Forms.ToolStripMenuItem tbAddRecentLibrary;
        public System.Windows.Forms.ToolStripMenuItem tbAddRecentFolder;
        public System.Windows.Forms.ToolStripSplitButton tbUndo;
        public System.Windows.Forms.ToolStripSplitButton tbRedo;
        public Controls.FirstClickToolStrip ToolStrip;
        public System.Windows.Forms.ToolStripSplitButton tbNew;
        public System.Windows.Forms.ToolStripMenuItem tbNewLibrary;
        public System.Windows.Forms.ToolStripMenuItem tbNewWindow;
        public System.Windows.Forms.ToolStripSplitButton tbOpen;
        public System.Windows.Forms.ToolStripMenuItem tbOpenLibrary;
        public System.Windows.Forms.ToolStripMenuItem tbReopen;
        public System.Windows.Forms.ToolStripSplitButton tbSave;
        public System.Windows.Forms.ToolStripMenuItem tbSaveLibrary;
        public System.Windows.Forms.ToolStripMenuItem tbSaveAs;
        public System.Windows.Forms.ToolStripMenuItem tbSaveAll;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripButton tbCut;
        public System.Windows.Forms.ToolStripButton tbCopy;
        public System.Windows.Forms.ToolStripButton tbPaste;
        public System.Windows.Forms.ToolStripButton tbDelete;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripSplitButton tbAdd;
        public System.Windows.Forms.ToolStripMenuItem tbAddMedia;
        public System.Windows.Forms.ToolStripMenuItem tbAddFolder;
        public System.Windows.Forms.ToolStripMenuItem tbAddLibrary;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem12;
        public Controls.FirstClickMenuStrip MainMenu;
        public System.Windows.Forms.ToolStripMenuItem FileMenu;
        public System.Windows.Forms.ToolStripMenuItem FileNew;
        public System.Windows.Forms.ToolStripMenuItem FileOpen;
        public System.Windows.Forms.ToolStripMenuItem FileReopen;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem FileSave;
        public System.Windows.Forms.ToolStripMenuItem FileSaveAs;
        public System.Windows.Forms.ToolStripMenuItem FileSaveAll;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        public System.Windows.Forms.ToolStripMenuItem FileClose;
        public System.Windows.Forms.ToolStripMenuItem FileExit;
        public System.Windows.Forms.ToolStripMenuItem EditMenu;
        public System.Windows.Forms.ToolStripMenuItem EditUndo;
        public System.Windows.Forms.ToolStripMenuItem EditRedo;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
        public System.Windows.Forms.ToolStripMenuItem EditCut;
        public System.Windows.Forms.ToolStripMenuItem EditCopy;
        public System.Windows.Forms.ToolStripMenuItem EditPaste;
        public System.Windows.Forms.ToolStripMenuItem EditDelete;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem11;
        public System.Windows.Forms.ToolStripMenuItem EditFind;
        public System.Windows.Forms.ToolStripMenuItem EditReplace;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        public System.Windows.Forms.ToolStripMenuItem EditSelectAll;
        public System.Windows.Forms.ToolStripMenuItem EditInvertSelection;
        public System.Windows.Forms.ToolStripMenuItem AddMenu;
        public System.Windows.Forms.ToolStripMenuItem AddMedia;
        public System.Windows.Forms.ToolStripMenuItem AddFolder;
        public System.Windows.Forms.ToolStripMenuItem AddLibrary;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        public System.Windows.Forms.ToolStripMenuItem AddRecentFolder;
        public System.Windows.Forms.ToolStripMenuItem AddRecentLibrary;
        public System.Windows.Forms.ToolStripMenuItem ViewMenu;
        public System.Windows.Forms.ToolStripMenuItem WindowMenu;
        public System.Windows.Forms.ToolStripMenuItem WindowNew;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        public System.Windows.Forms.ToolStripMenuItem HelpMenu;
        public System.Windows.Forms.ToolStripMenuItem HelpAbout;
        public System.Windows.Forms.StatusStrip StatusBar;
        public System.Windows.Forms.ToolStripContainer ToolStripContainer;
        public System.Windows.Forms.SplitContainer SplitContainerLeft;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        public System.Windows.Forms.ToolStripSplitButton tbFindReplace;
        public System.Windows.Forms.ToolStripMenuItem ViewArtistAlbum;
        public System.Windows.Forms.ToolStripMenuItem ViewArtist;
        public System.Windows.Forms.ToolStripMenuItem ViewAlbum;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        public System.Windows.Forms.ToolStripMenuItem ViewYear;
        public System.Windows.Forms.ToolStripMenuItem ViewGenre;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        public System.Windows.Forms.ToolStripMenuItem ViewTitle;
        public System.Windows.Forms.GroupBox FindReplacePanel;
        public FindReplaceControl FindReplaceControl;
        public System.Windows.Forms.ToolStripMenuItem tbFind;
        public System.Windows.Forms.ToolStripMenuItem tbReplace;
        public Controls.FilterControl FilterControl;
        public System.Windows.Forms.ToolStripMenuItem EditFilter;
        public System.Windows.Forms.GroupBox FilterPanel;
        public System.Windows.Forms.ContextMenuStrip FindReplacePopupMenu;
        public System.Windows.Forms.ToolStripMenuItem PopupFindNext;
        public System.Windows.Forms.ToolStripMenuItem PopupFindPrevious;
        public System.Windows.Forms.ToolStripMenuItem PopupFindAll;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem13;
        public System.Windows.Forms.ToolStripMenuItem PopupReplaceNext;
        public System.Windows.Forms.ToolStripMenuItem PopupReplaceAll;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem15;
        public System.Windows.Forms.ToolStripMenuItem PopupCloseFindReplace;
        public System.Windows.Forms.ToolStripMenuItem PopupMatchCase;
        public System.Windows.Forms.ToolStripMenuItem PopupWholeWord;
        public System.Windows.Forms.ToolStripMenuItem PopupUseRegex;
        public System.Windows.Forms.ToolStripSeparator PopupReplaceSeparator;
        public System.Windows.Forms.ToolStripMenuItem PopupSearchFields;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem17;
        public System.Windows.Forms.ToolStripButton tbFilter;
        public System.Windows.Forms.ContextMenuStrip FilterPopupMenu;
        public System.Windows.Forms.ToolStripMenuItem PopupFilterCase;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem18;
        public System.Windows.Forms.ToolStripMenuItem PopupFilterApply;
        public System.Windows.Forms.ToolStripMenuItem PopupFilterClear;
        public System.Windows.Forms.ToolStripMenuItem PopupFilterEdit;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem19;
        public System.Windows.Forms.ToolStripMenuItem PopupFilterClose;
        public System.Windows.Forms.ToolStripMenuItem PopupPreserveCase;
        public System.Windows.Forms.ContextMenuStrip PlayerPopupMenu;
        public System.Windows.Forms.ToolStripMenuItem PlayerPopupSelectColumns;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        public System.Windows.Forms.ToolStripSplitButton tbPlay;
        public System.Windows.Forms.ToolStripMenuItem tbAddToQueue;
        public System.Windows.Forms.ToolStripMenuItem tbNewPlaylist;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        public System.Windows.Forms.ToolStripMenuItem AddOptions;
        public System.Windows.Forms.ToolStripMenuItem ViewCustom;
        public System.Windows.Forms.ToolStripStatusLabel StatusLabel;
    }
}

