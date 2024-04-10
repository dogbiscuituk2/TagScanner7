namespace TagScanner.Views
{
	partial class LibraryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LibraryForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.GridElementHost = new System.Windows.Forms.Integration.ElementHost();
            this.GridPopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.GridPopupPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.GridPopupPlayAddToQueue = new System.Windows.Forms.ToolStripMenuItem();
            this.GridPopupPlayNewPlaylist = new System.Windows.Forms.ToolStripMenuItem();
            this.GridPopupMoreActions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.GridPopupTags = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterGroupBox = new System.Windows.Forms.GroupBox();
            this.FilterComboBox = new System.Windows.Forms.ComboBox();
            this.btnFilterBuild = new System.Windows.Forms.Button();
            this.cbFilterApply = new System.Windows.Forms.CheckBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabTags = new System.Windows.Forms.TabPage();
            this.PropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.PropertyGridPopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PropertyGridPopupTagVisibility = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPlayer = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.PlaylistElementHost = new System.Windows.Forms.Integration.ElementHost();
            this.FilterPopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.FileNewLibrary = new System.Windows.Forms.ToolStripMenuItem();
            this.FileNewWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.FileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.FileReopen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.FileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.FileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.EditMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.EditSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.EditInvertSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.EditFind = new System.Windows.Forms.ToolStripMenuItem();
            this.EditReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewGroupBy = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewByArtistAlbum = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewByArtist = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewByAlbum = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.ViewByYear = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewByGenre = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewByNoGrouping = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.ViewRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.AddMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AddMedia = new System.Windows.Forms.ToolStripMenuItem();
            this.AddFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.AddRecentFolders = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.AddFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.AddFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.MediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.FileClose = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.GridPopupMenu.SuspendLayout();
            this.FilterGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.TabControl.SuspendLayout();
            this.tabTags.SuspendLayout();
            this.PropertyGridPopupMenu.SuspendLayout();
            this.tabPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.GridElementHost);
            this.splitContainer1.Panel1.Controls.Add(this.FilterGroupBox);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(915, 688);
            this.splitContainer1.SplitterDistance = 638;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 7;
            // 
            // GridElementHost
            // 
            this.GridElementHost.ContextMenuStrip = this.GridPopupMenu;
            this.GridElementHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridElementHost.Location = new System.Drawing.Point(4, 0);
            this.GridElementHost.Margin = new System.Windows.Forms.Padding(0);
            this.GridElementHost.Name = "GridElementHost";
            this.GridElementHost.Size = new System.Drawing.Size(634, 640);
            this.GridElementHost.TabIndex = 0;
            this.GridElementHost.Text = "GridContainerHost";
            this.GridElementHost.Child = null;
            // 
            // GridPopupMenu
            // 
            this.GridPopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GridPopupPlay,
            this.GridPopupMoreActions,
            this.toolStripMenuItem6,
            this.GridPopupTags});
            this.GridPopupMenu.Name = "PopupMenu";
            this.GridPopupMenu.Size = new System.Drawing.Size(166, 76);
            // 
            // GridPopupPlay
            // 
            this.GridPopupPlay.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GridPopupPlayAddToQueue,
            this.GridPopupPlayNewPlaylist});
            this.GridPopupPlay.Name = "GridPopupPlay";
            this.GridPopupPlay.Size = new System.Drawing.Size(165, 22);
            this.GridPopupPlay.Text = "&Play";
            // 
            // GridPopupPlayAddToQueue
            // 
            this.GridPopupPlayAddToQueue.Name = "GridPopupPlayAddToQueue";
            this.GridPopupPlayAddToQueue.Size = new System.Drawing.Size(148, 22);
            this.GridPopupPlayAddToQueue.Text = "Add to &Queue";
            // 
            // GridPopupPlayNewPlaylist
            // 
            this.GridPopupPlayNewPlaylist.Name = "GridPopupPlayNewPlaylist";
            this.GridPopupPlayNewPlaylist.Size = new System.Drawing.Size(148, 22);
            this.GridPopupPlayNewPlaylist.Text = "&New Playlist";
            // 
            // GridPopupMoreActions
            // 
            this.GridPopupMoreActions.Name = "GridPopupMoreActions";
            this.GridPopupMoreActions.Size = new System.Drawing.Size(165, 22);
            this.GridPopupMoreActions.Text = "&More Actions...";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(162, 6);
            // 
            // GridPopupTags
            // 
            this.GridPopupTags.Name = "GridPopupTags";
            this.GridPopupTags.Size = new System.Drawing.Size(165, 22);
            this.GridPopupTags.Text = "Select &Columns...";
            // 
            // FilterGroupBox
            // 
            this.FilterGroupBox.Controls.Add(this.FilterComboBox);
            this.FilterGroupBox.Controls.Add(this.btnFilterBuild);
            this.FilterGroupBox.Controls.Add(this.cbFilterApply);
            this.FilterGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FilterGroupBox.Location = new System.Drawing.Point(4, 640);
            this.FilterGroupBox.Name = "FilterGroupBox";
            this.FilterGroupBox.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.FilterGroupBox.Size = new System.Drawing.Size(634, 48);
            this.FilterGroupBox.TabIndex = 1;
            this.FilterGroupBox.TabStop = false;
            this.FilterGroupBox.Text = "Filter";
            // 
            // FilterComboBox
            // 
            this.FilterComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterComboBox.FormattingEnabled = true;
            this.FilterComboBox.Location = new System.Drawing.Point(66, 18);
            this.FilterComboBox.Name = "FilterComboBox";
            this.FilterComboBox.Size = new System.Drawing.Size(497, 25);
            this.FilterComboBox.TabIndex = 0;
            // 
            // btnFilterBuild
            // 
            this.btnFilterBuild.AutoSize = true;
            this.btnFilterBuild.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFilterBuild.Location = new System.Drawing.Point(563, 18);
            this.btnFilterBuild.Name = "btnFilterBuild";
            this.btnFilterBuild.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnFilterBuild.Size = new System.Drawing.Size(71, 26);
            this.btnFilterBuild.TabIndex = 1;
            this.btnFilterBuild.Text = "Build...";
            this.btnFilterBuild.UseVisualStyleBackColor = true;
            // 
            // cbFilterApply
            // 
            this.cbFilterApply.AutoSize = true;
            this.cbFilterApply.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbFilterApply.Location = new System.Drawing.Point(0, 18);
            this.cbFilterApply.Name = "cbFilterApply";
            this.cbFilterApply.Padding = new System.Windows.Forms.Padding(3);
            this.cbFilterApply.Size = new System.Drawing.Size(66, 26);
            this.cbFilterApply.TabIndex = 2;
            this.cbFilterApply.Text = "Apply";
            this.cbFilterApply.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.PictureBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.TabControl);
            this.splitContainer2.Size = new System.Drawing.Size(272, 688);
            this.splitContainer2.SplitterDistance = 178;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // PictureBox
            // 
            this.PictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBox.Location = new System.Drawing.Point(0, 0);
            this.PictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(272, 178);
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
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
            this.TabControl.Size = new System.Drawing.Size(272, 505);
            this.TabControl.TabIndex = 0;
            // 
            // tabTags
            // 
            this.tabTags.BackColor = System.Drawing.SystemColors.Control;
            this.tabTags.Controls.Add(this.PropertyGrid);
            this.tabTags.Location = new System.Drawing.Point(4, 26);
            this.tabTags.Margin = new System.Windows.Forms.Padding(0);
            this.tabTags.Name = "tabTags";
            this.tabTags.Size = new System.Drawing.Size(264, 475);
            this.tabTags.TabIndex = 0;
            this.tabTags.Text = "Tags";
            // 
            // PropertyGrid
            // 
            this.PropertyGrid.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.PropertyGrid.ContextMenuStrip = this.PropertyGridPopupMenu;
            this.PropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.PropertyGrid.Margin = new System.Windows.Forms.Padding(0);
            this.PropertyGrid.Name = "PropertyGrid";
            this.PropertyGrid.Size = new System.Drawing.Size(264, 475);
            this.PropertyGrid.TabIndex = 0;
            // 
            // PropertyGridPopupMenu
            // 
            this.PropertyGridPopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PropertyGridPopupTagVisibility});
            this.PropertyGridPopupMenu.Name = "PropertyGridPopupMenu";
            this.PropertyGridPopupMenu.Size = new System.Drawing.Size(141, 26);
            // 
            // PropertyGridPopupTagVisibility
            // 
            this.PropertyGridPopupTagVisibility.Name = "PropertyGridPopupTagVisibility";
            this.PropertyGridPopupTagVisibility.Size = new System.Drawing.Size(140, 22);
            this.PropertyGridPopupTagVisibility.Text = "Select &Tags...";
            // 
            // tabPlayer
            // 
            this.tabPlayer.Controls.Add(this.splitContainer3);
            this.tabPlayer.Location = new System.Drawing.Point(4, 26);
            this.tabPlayer.Margin = new System.Windows.Forms.Padding(4);
            this.tabPlayer.Name = "tabPlayer";
            this.tabPlayer.Padding = new System.Windows.Forms.Padding(4);
            this.tabPlayer.Size = new System.Drawing.Size(264, 475);
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
            this.splitContainer3.Size = new System.Drawing.Size(256, 471);
            this.splitContainer3.SplitterDistance = 128;
            this.splitContainer3.SplitterWidth = 5;
            this.splitContainer3.TabIndex = 1;
            // 
            // PlaylistElementHost
            // 
            this.PlaylistElementHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlaylistElementHost.Location = new System.Drawing.Point(0, 0);
            this.PlaylistElementHost.Margin = new System.Windows.Forms.Padding(4);
            this.PlaylistElementHost.Name = "PlaylistElementHost";
            this.PlaylistElementHost.Size = new System.Drawing.Size(256, 128);
            this.PlaylistElementHost.TabIndex = 0;
            this.PlaylistElementHost.Text = "elementHost1";
            this.PlaylistElementHost.Child = null;
            // 
            // FilterPopupMenu
            // 
            this.FilterPopupMenu.Name = "FilterPopupMenu";
            this.FilterPopupMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.EditMenu,
            this.GroupMenu,
            this.AddMenu,
            this.HelpMenu});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.MainMenu.Size = new System.Drawing.Size(915, 25);
            this.MainMenu.TabIndex = 0;
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
            this.toolStripMenuItem5,
            this.FileClose,
            this.FileExit});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 19);
            this.FileMenu.Text = "&File";
            // 
            // FileNew
            // 
            this.FileNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileNewLibrary,
            this.FileNewWindow});
            this.FileNew.Name = "FileNew";
            this.FileNew.ShortcutKeyDisplayString = "";
            this.FileNew.Size = new System.Drawing.Size(197, 22);
            this.FileNew.Text = "&New";
            // 
            // FileNewLibrary
            // 
            this.FileNewLibrary.Name = "FileNewLibrary";
            this.FileNewLibrary.ShortcutKeyDisplayString = "^N";
            this.FileNewLibrary.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.FileNewLibrary.Size = new System.Drawing.Size(134, 22);
            this.FileNewLibrary.Text = "Library";
            // 
            // FileNewWindow
            // 
            this.FileNewWindow.Name = "FileNewWindow";
            this.FileNewWindow.Size = new System.Drawing.Size(134, 22);
            this.FileNewWindow.Text = "Window";
            // 
            // FileOpen
            // 
            this.FileOpen.Name = "FileOpen";
            this.FileOpen.ShortcutKeyDisplayString = "^O";
            this.FileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.FileOpen.Size = new System.Drawing.Size(197, 22);
            this.FileOpen.Text = "&Open...";
            // 
            // FileReopen
            // 
            this.FileReopen.Name = "FileReopen";
            this.FileReopen.Size = new System.Drawing.Size(197, 22);
            this.FileReopen.Text = "&Reopen";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(194, 6);
            // 
            // FileSave
            // 
            this.FileSave.Name = "FileSave";
            this.FileSave.ShortcutKeyDisplayString = "^S";
            this.FileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.FileSave.Size = new System.Drawing.Size(197, 22);
            this.FileSave.Text = "&Save";
            // 
            // FileSaveAs
            // 
            this.FileSaveAs.Name = "FileSaveAs";
            this.FileSaveAs.Size = new System.Drawing.Size(197, 22);
            this.FileSaveAs.Text = "Save &As...";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(194, 6);
            // 
            // FileExit
            // 
            this.FileExit.Name = "FileExit";
            this.FileExit.ShortcutKeyDisplayString = "Alt+F4";
            this.FileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.FileExit.Size = new System.Drawing.Size(197, 22);
            this.FileExit.Text = "Close All && E&xit";
            // 
            // EditMenu
            // 
            this.EditMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditSelectAll,
            this.EditInvertSelection,
            this.toolStripMenuItem2,
            this.EditFind,
            this.EditReplace});
            this.EditMenu.Name = "EditMenu";
            this.EditMenu.Size = new System.Drawing.Size(39, 19);
            this.EditMenu.Text = "&Edit";
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
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 6);
            // 
            // EditFind
            // 
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
            // GroupMenu
            // 
            this.GroupMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewFilter,
            this.ViewGroupBy,
            this.toolStripMenuItem7,
            this.ViewRefresh});
            this.GroupMenu.Name = "GroupMenu";
            this.GroupMenu.Size = new System.Drawing.Size(44, 19);
            this.GroupMenu.Text = "&View";
            // 
            // ViewFilter
            // 
            this.ViewFilter.Name = "ViewFilter";
            this.ViewFilter.Size = new System.Drawing.Size(132, 22);
            this.ViewFilter.Text = "&Filter...";
            // 
            // ViewGroupBy
            // 
            this.ViewGroupBy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewByArtistAlbum,
            this.ViewByArtist,
            this.ViewByAlbum,
            this.toolStripMenuItem4,
            this.ViewByYear,
            this.ViewByGenre,
            this.ViewByNoGrouping});
            this.ViewGroupBy.Name = "ViewGroupBy";
            this.ViewGroupBy.Size = new System.Drawing.Size(132, 22);
            this.ViewGroupBy.Text = "&Group by";
            // 
            // ViewByArtistAlbum
            // 
            this.ViewByArtistAlbum.Name = "ViewByArtistAlbum";
            this.ViewByArtistAlbum.Size = new System.Drawing.Size(143, 22);
            this.ViewByArtistAlbum.Text = "&Artist/Album";
            // 
            // ViewByArtist
            // 
            this.ViewByArtist.Name = "ViewByArtist";
            this.ViewByArtist.Size = new System.Drawing.Size(143, 22);
            this.ViewByArtist.Text = "A&rtist";
            // 
            // ViewByAlbum
            // 
            this.ViewByAlbum.Name = "ViewByAlbum";
            this.ViewByAlbum.Size = new System.Drawing.Size(143, 22);
            this.ViewByAlbum.Text = "A&lbum";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(140, 6);
            // 
            // ViewByYear
            // 
            this.ViewByYear.Name = "ViewByYear";
            this.ViewByYear.Size = new System.Drawing.Size(143, 22);
            this.ViewByYear.Text = "&Year";
            // 
            // ViewByGenre
            // 
            this.ViewByGenre.Name = "ViewByGenre";
            this.ViewByGenre.Size = new System.Drawing.Size(143, 22);
            this.ViewByGenre.Text = "&Genre";
            // 
            // ViewByNoGrouping
            // 
            this.ViewByNoGrouping.Name = "ViewByNoGrouping";
            this.ViewByNoGrouping.Size = new System.Drawing.Size(143, 22);
            this.ViewByNoGrouping.Text = "&No grouping";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(129, 6);
            // 
            // ViewRefresh
            // 
            this.ViewRefresh.Name = "ViewRefresh";
            this.ViewRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.ViewRefresh.Size = new System.Drawing.Size(132, 22);
            this.ViewRefresh.Text = "&Refresh";
            // 
            // AddMenu
            // 
            this.AddMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddMedia,
            this.AddFolder,
            this.toolStripMenuItem3,
            this.AddRecentFolders});
            this.AddMenu.Name = "AddMenu";
            this.AddMenu.Size = new System.Drawing.Size(41, 19);
            this.AddMenu.Text = "&Add";
            // 
            // AddMedia
            // 
            this.AddMedia.Name = "AddMedia";
            this.AddMedia.Size = new System.Drawing.Size(151, 22);
            this.AddMedia.Text = "&Media...";
            // 
            // AddFolder
            // 
            this.AddFolder.Name = "AddFolder";
            this.AddFolder.Size = new System.Drawing.Size(151, 22);
            this.AddFolder.Text = "&Folder...";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(148, 6);
            // 
            // AddRecentFolders
            // 
            this.AddRecentFolders.Name = "AddRecentFolders";
            this.AddRecentFolders.Size = new System.Drawing.Size(151, 22);
            this.AddRecentFolders.Text = "&Recent Folders";
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
            this.HelpAbout.Name = "HelpAbout";
            this.HelpAbout.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.HelpAbout.Size = new System.Drawing.Size(126, 22);
            this.HelpAbout.Text = "&About";
            // 
            // AddFolderDialog
            // 
            this.AddFolderDialog.Description = "Select the folder to add";
            // 
            // AddFileDialog
            // 
            this.AddFileDialog.Multiselect = true;
            this.AddFileDialog.Title = "Select the media file(s) to add";
            // 
            // StatusBar
            // 
            this.StatusBar.Location = new System.Drawing.Point(0, 713);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.StatusBar.Size = new System.Drawing.Size(915, 22);
            this.StatusBar.TabIndex = 9;
            this.StatusBar.Text = "Status";
            // 
            // MediaPlayer
            // 
            this.MediaPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MediaPlayer.Enabled = true;
            this.MediaPlayer.Location = new System.Drawing.Point(0, 0);
            this.MediaPlayer.Margin = new System.Windows.Forms.Padding(4);
            this.MediaPlayer.Name = "MediaPlayer";
            this.MediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MediaPlayer.OcxState")));
            this.MediaPlayer.Size = new System.Drawing.Size(256, 338);
            this.MediaPlayer.TabIndex = 0;
            // 
            // FileClose
            // 
            this.FileClose.Name = "FileClose";
            this.FileClose.ShortcutKeyDisplayString = "^F4";
            this.FileClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this.FileClose.Size = new System.Drawing.Size(197, 22);
            this.FileClose.Text = "Close Window";
            // 
            // LibraryForm
            // 
            this.AcceptButton = this.btnFilterBuild;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 735);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.StatusBar);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.MainMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LibraryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "ID3 Tag Explorer";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.GridPopupMenu.ResumeLayout(false);
            this.FilterGroupBox.ResumeLayout(false);
            this.FilterGroupBox.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.TabControl.ResumeLayout(false);
            this.tabTags.ResumeLayout(false);
            this.PropertyGridPopupMenu.ResumeLayout(false);
            this.tabPlayer.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.SplitContainer splitContainer1;
		public System.Windows.Forms.SplitContainer splitContainer2;
		public System.Windows.Forms.PictureBox PictureBox;
		public System.Windows.Forms.MenuStrip MainMenu;
		public System.Windows.Forms.ToolStripMenuItem FileMenu;
		public System.Windows.Forms.ToolStripMenuItem FileExit;
		public System.Windows.Forms.ToolStripMenuItem EditMenu;
		public System.Windows.Forms.ToolStripMenuItem EditSelectAll;
		public System.Windows.Forms.ToolStripMenuItem EditInvertSelection;
		public System.Windows.Forms.ToolStripMenuItem GroupMenu;
		public System.Windows.Forms.ToolStripMenuItem HelpMenu;
		public System.Windows.Forms.ToolStripMenuItem HelpAbout;
		public System.Windows.Forms.FolderBrowserDialog AddFolderDialog;
		public System.Windows.Forms.OpenFileDialog AddFileDialog;
		public System.Windows.Forms.StatusStrip StatusBar;
		public System.Windows.Forms.ToolStripMenuItem FileNew;
		public System.Windows.Forms.ToolStripMenuItem FileOpen;
		public System.Windows.Forms.ToolStripMenuItem FileSave;
		public System.Windows.Forms.ToolStripMenuItem FileSaveAs;
		public System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		public System.Windows.Forms.ToolStripMenuItem AddMenu;
		public System.Windows.Forms.ToolStripMenuItem AddMedia;
		public System.Windows.Forms.ToolStripMenuItem AddFolder;
		public System.Windows.Forms.ToolStripMenuItem AddRecentFolders;
		public System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		public System.Windows.Forms.ToolStripMenuItem FileReopen;
		public System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
		public System.Windows.Forms.ContextMenuStrip GridPopupMenu;
		public System.Windows.Forms.ToolStripMenuItem GridPopupTags;
		public System.Windows.Forms.TabControl TabControl;
		public System.Windows.Forms.TabPage tabTags;
		public System.Windows.Forms.PropertyGrid PropertyGrid;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
		public System.Windows.Forms.ToolStripMenuItem GridPopupPlay;
		public AxWMPLib.AxWindowsMediaPlayer MediaPlayer;
		public System.Windows.Forms.TabPage tabPlayer;
        public System.Windows.Forms.ContextMenuStrip PropertyGridPopupMenu;
		public System.Windows.Forms.ToolStripMenuItem PropertyGridPopupTagVisibility;
        public System.Windows.Forms.SplitContainer splitContainer3;
		public System.Windows.Forms.ToolStripMenuItem GridPopupPlayAddToQueue;
		public System.Windows.Forms.ToolStripMenuItem GridPopupPlayNewPlaylist;
		public System.Windows.Forms.Integration.ElementHost PlaylistElementHost;
		public System.Windows.Forms.ToolStripMenuItem ViewRefresh;
        public System.Windows.Forms.ContextMenuStrip FilterPopupMenu;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        public System.Windows.Forms.ToolStripMenuItem EditFind;
        public System.Windows.Forms.ToolStripMenuItem EditReplace;
        public System.Windows.Forms.ToolStripMenuItem ViewGroupBy;
        public System.Windows.Forms.ToolStripMenuItem ViewByArtist;
        public System.Windows.Forms.ToolStripMenuItem ViewByAlbum;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        public System.Windows.Forms.ToolStripMenuItem ViewByYear;
        public System.Windows.Forms.ToolStripMenuItem ViewByArtistAlbum;
        public System.Windows.Forms.ToolStripMenuItem ViewByGenre;
        public System.Windows.Forms.ToolStripMenuItem ViewByNoGrouping;
        public System.Windows.Forms.ToolStripMenuItem ViewFilter;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        public System.Windows.Forms.Integration.ElementHost GridElementHost;
        public System.Windows.Forms.GroupBox FilterGroupBox;
        public System.Windows.Forms.ComboBox FilterComboBox;
        public System.Windows.Forms.CheckBox cbFilterApply;
        public System.Windows.Forms.Button btnFilterBuild;
        public System.Windows.Forms.ToolStripMenuItem GridPopupMoreActions;
        public System.Windows.Forms.ToolStripMenuItem FileNewLibrary;
        public System.Windows.Forms.ToolStripMenuItem FileNewWindow;
        public System.Windows.Forms.ToolStripMenuItem FileClose;
    }
}

