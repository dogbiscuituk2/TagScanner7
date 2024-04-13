namespace TagScanner.Views
{
	partial class LibraryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LibraryForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.GridElementHost = new System.Windows.Forms.Integration.ElementHost();
            this.GridPopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.GridPopupPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.GridPopupPlayAddToQueue = new System.Windows.Forms.ToolStripMenuItem();
            this.GridPopupPlayNewPlaylist = new System.Windows.Forms.ToolStripMenuItem();
            this.GridPopupMoreActions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.GridPopupTags = new System.Windows.Forms.ToolStripMenuItem();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.FilterGroupBox = new System.Windows.Forms.GroupBox();
            this.FilterComboBox = new System.Windows.Forms.ComboBox();
            this.CaseSensitiveCheckBox = new System.Windows.Forms.CheckBox();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
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
            this.MediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.FilterPopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MainMenu = new TagScanner.Controls.FirstClickMenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.FileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.FileReopen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.FileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.FileClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
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
            this.EditSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.EditInvertSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.AddMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AddMedia = new System.Windows.Forms.ToolStripMenuItem();
            this.AddFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.AddRecentFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenu = new System.Windows.Forms.ToolStripMenuItem();
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
            this.WindowMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.WindowNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.AddFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.AddFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbNew = new System.Windows.Forms.ToolStripSplitButton();
            this.tbNewLibrary = new System.Windows.Forms.ToolStripMenuItem();
            this.tbNewWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tbOpen = new System.Windows.Forms.ToolStripSplitButton();
            this.tbOpenLibrary = new System.Windows.Forms.ToolStripMenuItem();
            this.tbReopen = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSave = new System.Windows.Forms.ToolStripSplitButton();
            this.tbSaveLibrary = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbUndo = new System.Windows.Forms.ToolStripSplitButton();
            this.tbRedo = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tbCut = new System.Windows.Forms.ToolStripButton();
            this.tbCopy = new System.Windows.Forms.ToolStripButton();
            this.tbPaste = new System.Windows.Forms.ToolStripButton();
            this.tbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbAdd = new System.Windows.Forms.ToolStripSplitButton();
            this.tbAddMedia = new System.Windows.Forms.ToolStripMenuItem();
            this.tbAddFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
            this.tbAddRecentFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.modelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.worksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.albumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.albumArtistsCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.albumArtistsSortCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.albumGainDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.albumPeakDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.albumSortDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amazonIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.artistsCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.audioBitrateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.audioChannelsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.audioSampleRateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.beatsPerMinuteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bitsPerSampleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.centuryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codecsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.composersCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.composersSortCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conductorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.copyrightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.decadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discOfDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discTrackDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileAttributesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileCreationTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileCreationTimeUtcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileExtensionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileLastAccessTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileLastAccessTimeUtcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileLastWriteTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileLastWriteTimeUtcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileNameWithoutExtensionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filePathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstAlbumArtistDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstAlbumArtistSortDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstArtistDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstComposerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstComposerSortDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstGenreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstPerformerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstPerformerSortDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genresCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageAltitudeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageCreatorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageDateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageExposureTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageFNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageFocalLengthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageFocalLengthIn35mmFilmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageISOSpeedRatingsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageLatitudeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageLongitudeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageMakeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageModelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageOrientationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageRatingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageSoftwareDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invariantEndPositionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invariantStartPositionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isClassicalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isEmptyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.joinedAlbumArtistsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.joinedArtistsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.joinedComposersDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.joinedGenresDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.joinedPerformersDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.joinedPerformersSortDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lyricsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mediaTypesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.millenniumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mimeTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.musicBrainzArtistIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.musicBrainzDiscIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.musicBrainzReleaseArtistIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.musicBrainzReleaseCountryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.musicBrainzReleaseIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.musicBrainzReleaseStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.musicBrainzReleaseTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.musicBrainzTrackIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.musicIpIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.performersCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.performersSortCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.photoHeightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.photoQualityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.photoWidthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picturesCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.possiblyCorruptDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagTypesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagTypesOnDiskDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleSortDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trackCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trackGainDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trackNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trackOfDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trackPeakDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.videoHeightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.videoWidthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearAlbumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.GridPopupMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).BeginInit();
            this.MainMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.worksBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(33, 25);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer4);
            this.splitContainer1.Panel1.Controls.Add(this.FilterGroupBox);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(591, 394);
            this.splitContainer1.SplitterDistance = 410;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 7;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(4, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.GridElementHost);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.DataGridView);
            this.splitContainer4.Size = new System.Drawing.Size(406, 346);
            this.splitContainer4.SplitterDistance = 173;
            this.splitContainer4.TabIndex = 2;
            // 
            // GridElementHost
            // 
            this.GridElementHost.ContextMenuStrip = this.GridPopupMenu;
            this.GridElementHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridElementHost.Location = new System.Drawing.Point(0, 0);
            this.GridElementHost.Margin = new System.Windows.Forms.Padding(0);
            this.GridElementHost.Name = "GridElementHost";
            this.GridElementHost.Size = new System.Drawing.Size(406, 173);
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
            // DataGridView
            // 
            this.DataGridView.AutoGenerateColumns = false;
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.albumDataGridViewTextBoxColumn,
            this.albumArtistsCountDataGridViewTextBoxColumn,
            this.albumArtistsSortCountDataGridViewTextBoxColumn,
            this.albumGainDataGridViewTextBoxColumn,
            this.albumPeakDataGridViewTextBoxColumn,
            this.albumSortDataGridViewTextBoxColumn,
            this.amazonIdDataGridViewTextBoxColumn,
            this.artistsCountDataGridViewTextBoxColumn,
            this.audioBitrateDataGridViewTextBoxColumn,
            this.audioChannelsDataGridViewTextBoxColumn,
            this.audioSampleRateDataGridViewTextBoxColumn,
            this.beatsPerMinuteDataGridViewTextBoxColumn,
            this.bitsPerSampleDataGridViewTextBoxColumn,
            this.centuryDataGridViewTextBoxColumn,
            this.codecsDataGridViewTextBoxColumn,
            this.commentDataGridViewTextBoxColumn,
            this.composersCountDataGridViewTextBoxColumn,
            this.composersSortCountDataGridViewTextBoxColumn,
            this.conductorDataGridViewTextBoxColumn,
            this.copyrightDataGridViewTextBoxColumn,
            this.decadeDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.discCountDataGridViewTextBoxColumn,
            this.discNumberDataGridViewTextBoxColumn,
            this.discOfDataGridViewTextBoxColumn,
            this.discTrackDataGridViewTextBoxColumn,
            this.durationDataGridViewTextBoxColumn,
            this.fileAttributesDataGridViewTextBoxColumn,
            this.fileCreationTimeDataGridViewTextBoxColumn,
            this.fileCreationTimeUtcDataGridViewTextBoxColumn,
            this.fileExtensionDataGridViewTextBoxColumn,
            this.fileLastAccessTimeDataGridViewTextBoxColumn,
            this.fileLastAccessTimeUtcDataGridViewTextBoxColumn,
            this.fileLastWriteTimeDataGridViewTextBoxColumn,
            this.fileLastWriteTimeUtcDataGridViewTextBoxColumn,
            this.fileNameDataGridViewTextBoxColumn,
            this.fileNameWithoutExtensionDataGridViewTextBoxColumn,
            this.filePathDataGridViewTextBoxColumn,
            this.fileSizeDataGridViewTextBoxColumn,
            this.fileStatusDataGridViewTextBoxColumn,
            this.firstAlbumArtistDataGridViewTextBoxColumn,
            this.firstAlbumArtistSortDataGridViewTextBoxColumn,
            this.firstArtistDataGridViewTextBoxColumn,
            this.firstComposerDataGridViewTextBoxColumn,
            this.firstComposerSortDataGridViewTextBoxColumn,
            this.firstGenreDataGridViewTextBoxColumn,
            this.firstPerformerDataGridViewTextBoxColumn,
            this.firstPerformerSortDataGridViewTextBoxColumn,
            this.genresCountDataGridViewTextBoxColumn,
            this.groupingDataGridViewTextBoxColumn,
            this.imageAltitudeDataGridViewTextBoxColumn,
            this.imageCreatorDataGridViewTextBoxColumn,
            this.imageDateTimeDataGridViewTextBoxColumn,
            this.imageExposureTimeDataGridViewTextBoxColumn,
            this.imageFNumberDataGridViewTextBoxColumn,
            this.imageFocalLengthDataGridViewTextBoxColumn,
            this.imageFocalLengthIn35mmFilmDataGridViewTextBoxColumn,
            this.imageISOSpeedRatingsDataGridViewTextBoxColumn,
            this.imageLatitudeDataGridViewTextBoxColumn,
            this.imageLongitudeDataGridViewTextBoxColumn,
            this.imageMakeDataGridViewTextBoxColumn,
            this.imageModelDataGridViewTextBoxColumn,
            this.imageOrientationDataGridViewTextBoxColumn,
            this.imageRatingDataGridViewTextBoxColumn,
            this.imageSoftwareDataGridViewTextBoxColumn,
            this.invariantEndPositionDataGridViewTextBoxColumn,
            this.invariantStartPositionDataGridViewTextBoxColumn,
            this.isClassicalDataGridViewTextBoxColumn,
            this.isEmptyDataGridViewTextBoxColumn,
            this.joinedAlbumArtistsDataGridViewTextBoxColumn,
            this.joinedArtistsDataGridViewTextBoxColumn,
            this.joinedComposersDataGridViewTextBoxColumn,
            this.joinedGenresDataGridViewTextBoxColumn,
            this.joinedPerformersDataGridViewTextBoxColumn,
            this.joinedPerformersSortDataGridViewTextBoxColumn,
            this.lyricsDataGridViewTextBoxColumn,
            this.mediaTypesDataGridViewTextBoxColumn,
            this.millenniumDataGridViewTextBoxColumn,
            this.mimeTypeDataGridViewTextBoxColumn,
            this.musicBrainzArtistIdDataGridViewTextBoxColumn,
            this.musicBrainzDiscIdDataGridViewTextBoxColumn,
            this.musicBrainzReleaseArtistIdDataGridViewTextBoxColumn,
            this.musicBrainzReleaseCountryDataGridViewTextBoxColumn,
            this.musicBrainzReleaseIdDataGridViewTextBoxColumn,
            this.musicBrainzReleaseStatusDataGridViewTextBoxColumn,
            this.musicBrainzReleaseTypeDataGridViewTextBoxColumn,
            this.musicBrainzTrackIdDataGridViewTextBoxColumn,
            this.musicIpIdDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.performersCountDataGridViewTextBoxColumn,
            this.performersSortCountDataGridViewTextBoxColumn,
            this.photoHeightDataGridViewTextBoxColumn,
            this.photoQualityDataGridViewTextBoxColumn,
            this.photoWidthDataGridViewTextBoxColumn,
            this.picturesCountDataGridViewTextBoxColumn,
            this.possiblyCorruptDataGridViewTextBoxColumn,
            this.tagTypesDataGridViewTextBoxColumn,
            this.tagTypesOnDiskDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.titleSortDataGridViewTextBoxColumn,
            this.trackCountDataGridViewTextBoxColumn,
            this.trackGainDataGridViewTextBoxColumn,
            this.trackNumberDataGridViewTextBoxColumn,
            this.trackOfDataGridViewTextBoxColumn,
            this.trackPeakDataGridViewTextBoxColumn,
            this.videoHeightDataGridViewTextBoxColumn,
            this.videoWidthDataGridViewTextBoxColumn,
            this.yearDataGridViewTextBoxColumn,
            this.yearAlbumDataGridViewTextBoxColumn});
            this.DataGridView.DataSource = this.worksBindingSource;
            this.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView.Location = new System.Drawing.Point(0, 0);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.Size = new System.Drawing.Size(406, 169);
            this.DataGridView.TabIndex = 0;
            // 
            // FilterGroupBox
            // 
            this.FilterGroupBox.Controls.Add(this.FilterComboBox);
            this.FilterGroupBox.Controls.Add(this.CaseSensitiveCheckBox);
            this.FilterGroupBox.Controls.Add(this.ApplyButton);
            this.FilterGroupBox.Controls.Add(this.ClearButton);
            this.FilterGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FilterGroupBox.Location = new System.Drawing.Point(4, 346);
            this.FilterGroupBox.Name = "FilterGroupBox";
            this.FilterGroupBox.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.FilterGroupBox.Size = new System.Drawing.Size(406, 48);
            this.FilterGroupBox.TabIndex = 1;
            this.FilterGroupBox.TabStop = false;
            this.FilterGroupBox.Text = "Filter";
            // 
            // FilterComboBox
            // 
            this.FilterComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterComboBox.FormattingEnabled = true;
            this.FilterComboBox.Location = new System.Drawing.Point(115, 18);
            this.FilterComboBox.Name = "FilterComboBox";
            this.FilterComboBox.Size = new System.Drawing.Size(192, 25);
            this.FilterComboBox.TabIndex = 0;
            // 
            // CaseSensitiveCheckBox
            // 
            this.CaseSensitiveCheckBox.AutoSize = true;
            this.CaseSensitiveCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.CaseSensitiveCheckBox.Location = new System.Drawing.Point(0, 18);
            this.CaseSensitiveCheckBox.Name = "CaseSensitiveCheckBox";
            this.CaseSensitiveCheckBox.Padding = new System.Windows.Forms.Padding(3);
            this.CaseSensitiveCheckBox.Size = new System.Drawing.Size(115, 26);
            this.CaseSensitiveCheckBox.TabIndex = 2;
            this.CaseSensitiveCheckBox.Text = "Case Sensitive";
            this.CaseSensitiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // ApplyButton
            // 
            this.ApplyButton.AutoSize = true;
            this.ApplyButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ApplyButton.Location = new System.Drawing.Point(307, 18);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(51, 26);
            this.ApplyButton.TabIndex = 1;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            // 
            // ClearButton
            // 
            this.ClearButton.AutoSize = true;
            this.ClearButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ClearButton.Location = new System.Drawing.Point(358, 18);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(48, 26);
            this.ClearButton.TabIndex = 3;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
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
            this.splitContainer2.Size = new System.Drawing.Size(176, 394);
            this.splitContainer2.SplitterDistance = 101;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // PictureBox
            // 
            this.PictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBox.Location = new System.Drawing.Point(0, 0);
            this.PictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(176, 101);
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
            this.TabControl.Size = new System.Drawing.Size(176, 288);
            this.TabControl.TabIndex = 0;
            // 
            // tabTags
            // 
            this.tabTags.BackColor = System.Drawing.SystemColors.Control;
            this.tabTags.Controls.Add(this.PropertyGrid);
            this.tabTags.Location = new System.Drawing.Point(4, 26);
            this.tabTags.Margin = new System.Windows.Forms.Padding(0);
            this.tabTags.Name = "tabTags";
            this.tabTags.Size = new System.Drawing.Size(168, 258);
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
            this.PropertyGrid.Size = new System.Drawing.Size(168, 258);
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
            this.tabPlayer.Location = new System.Drawing.Point(4, 22);
            this.tabPlayer.Margin = new System.Windows.Forms.Padding(4);
            this.tabPlayer.Name = "tabPlayer";
            this.tabPlayer.Padding = new System.Windows.Forms.Padding(4);
            this.tabPlayer.Size = new System.Drawing.Size(168, 262);
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
            this.splitContainer3.Size = new System.Drawing.Size(160, 254);
            this.splitContainer3.SplitterDistance = 69;
            this.splitContainer3.SplitterWidth = 5;
            this.splitContainer3.TabIndex = 1;
            // 
            // PlaylistElementHost
            // 
            this.PlaylistElementHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlaylistElementHost.Location = new System.Drawing.Point(0, 0);
            this.PlaylistElementHost.Margin = new System.Windows.Forms.Padding(4);
            this.PlaylistElementHost.Name = "PlaylistElementHost";
            this.PlaylistElementHost.Size = new System.Drawing.Size(160, 69);
            this.PlaylistElementHost.TabIndex = 0;
            this.PlaylistElementHost.Text = "elementHost1";
            this.PlaylistElementHost.Child = null;
            // 
            // MediaPlayer
            // 
            this.MediaPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MediaPlayer.Enabled = true;
            this.MediaPlayer.Location = new System.Drawing.Point(0, 0);
            this.MediaPlayer.Margin = new System.Windows.Forms.Padding(4);
            this.MediaPlayer.Name = "MediaPlayer";
            this.MediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MediaPlayer.OcxState")));
            this.MediaPlayer.Size = new System.Drawing.Size(160, 180);
            this.MediaPlayer.TabIndex = 0;
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
            this.AddMenu,
            this.ViewMenu,
            this.WindowMenu,
            this.HelpMenu});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.MainMenu.Size = new System.Drawing.Size(624, 25);
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
            this.toolStripMenuItem9,
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
            this.FileNew.Size = new System.Drawing.Size(136, 22);
            this.FileNew.Text = "&New";
            // 
            // FileOpen
            // 
            this.FileOpen.Image = global::TagScanner.Properties.Resources.openHS;
            this.FileOpen.Name = "FileOpen";
            this.FileOpen.ShortcutKeyDisplayString = "^O";
            this.FileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.FileOpen.Size = new System.Drawing.Size(136, 22);
            this.FileOpen.Text = "&Open...";
            // 
            // FileReopen
            // 
            this.FileReopen.Name = "FileReopen";
            this.FileReopen.Size = new System.Drawing.Size(136, 22);
            this.FileReopen.Text = "&Reopen";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(133, 6);
            // 
            // FileSave
            // 
            this.FileSave.Image = global::TagScanner.Properties.Resources.saveHS;
            this.FileSave.Name = "FileSave";
            this.FileSave.ShortcutKeyDisplayString = "^S";
            this.FileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.FileSave.Size = new System.Drawing.Size(136, 22);
            this.FileSave.Text = "&Save";
            // 
            // FileSaveAs
            // 
            this.FileSaveAs.Name = "FileSaveAs";
            this.FileSaveAs.Size = new System.Drawing.Size(136, 22);
            this.FileSaveAs.Text = "Save &As...";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(133, 6);
            // 
            // FileClose
            // 
            this.FileClose.Name = "FileClose";
            this.FileClose.ShortcutKeyDisplayString = "^F4";
            this.FileClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this.FileClose.Size = new System.Drawing.Size(136, 22);
            this.FileClose.Text = "Close";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(133, 6);
            // 
            // FileExit
            // 
            this.FileExit.Name = "FileExit";
            this.FileExit.ShortcutKeyDisplayString = "Alt+F4";
            this.FileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.FileExit.Size = new System.Drawing.Size(136, 22);
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
            this.EditDelete.Name = "EditDelete";
            this.EditDelete.ShortcutKeyDisplayString = "Del";
            this.EditDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
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
            // AddMenu
            // 
            this.AddMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddMedia,
            this.AddFolder,
            this.toolStripMenuItem3,
            this.AddRecentFolder});
            this.AddMenu.Name = "AddMenu";
            this.AddMenu.Size = new System.Drawing.Size(41, 19);
            this.AddMenu.Text = "&Add";
            // 
            // AddMedia
            // 
            this.AddMedia.Name = "AddMedia";
            this.AddMedia.Size = new System.Drawing.Size(146, 22);
            this.AddMedia.Text = "&Media...";
            // 
            // AddFolder
            // 
            this.AddFolder.Name = "AddFolder";
            this.AddFolder.Size = new System.Drawing.Size(146, 22);
            this.AddFolder.Text = "&Folder...";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(143, 6);
            // 
            // AddRecentFolder
            // 
            this.AddRecentFolder.Name = "AddRecentFolder";
            this.AddRecentFolder.Size = new System.Drawing.Size(146, 22);
            this.AddRecentFolder.Text = "&Recent Folder";
            // 
            // ViewMenu
            // 
            this.ViewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewFilter,
            this.ViewGroupBy,
            this.toolStripMenuItem7,
            this.ViewRefresh});
            this.ViewMenu.Name = "ViewMenu";
            this.ViewMenu.Size = new System.Drawing.Size(44, 19);
            this.ViewMenu.Text = "&View";
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
            this.StatusBar.Location = new System.Drawing.Point(0, 419);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.StatusBar.Size = new System.Drawing.Size(624, 22);
            this.StatusBar.TabIndex = 9;
            this.StatusBar.Text = "Status";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.tbAdd});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(33, 394);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
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
            this.tbNew.Size = new System.Drawing.Size(30, 20);
            this.tbNew.Text = "tbNew";
            // 
            // tbNewLibrary
            // 
            this.tbNewLibrary.Name = "tbNewLibrary";
            this.tbNewLibrary.ShortcutKeyDisplayString = "^N";
            this.tbNewLibrary.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tbNewLibrary.Size = new System.Drawing.Size(171, 22);
            this.tbNewLibrary.Text = "New Library";
            // 
            // tbNewWindow
            // 
            this.tbNewWindow.Name = "tbNewWindow";
            this.tbNewWindow.ShortcutKeyDisplayString = "^W";
            this.tbNewWindow.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.tbNewWindow.Size = new System.Drawing.Size(171, 22);
            this.tbNewWindow.Text = "New Window";
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
            this.tbOpen.Size = new System.Drawing.Size(30, 20);
            this.tbOpen.Text = "tbOpen";
            // 
            // tbOpenLibrary
            // 
            this.tbOpenLibrary.Name = "tbOpenLibrary";
            this.tbOpenLibrary.ShortcutKeyDisplayString = "^O";
            this.tbOpenLibrary.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tbOpenLibrary.Size = new System.Drawing.Size(136, 22);
            this.tbOpenLibrary.Text = "&Open...";
            // 
            // tbReopen
            // 
            this.tbReopen.Name = "tbReopen";
            this.tbReopen.Size = new System.Drawing.Size(136, 22);
            this.tbReopen.Text = "&Reopen";
            // 
            // tbSave
            // 
            this.tbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSave.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbSaveLibrary,
            this.tbSaveAs});
            this.tbSave.Image = global::TagScanner.Properties.Resources.saveHS;
            this.tbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSave.Name = "tbSave";
            this.tbSave.Size = new System.Drawing.Size(30, 20);
            this.tbSave.Text = "tbSave";
            // 
            // tbSaveLibrary
            // 
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(30, 6);
            // 
            // tbUndo
            // 
            this.tbUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbUndo.Image = global::TagScanner.Properties.Resources.Edit_UndoHS;
            this.tbUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbUndo.Name = "tbUndo";
            this.tbUndo.Size = new System.Drawing.Size(30, 20);
            this.tbUndo.Text = "tbUndo";
            // 
            // tbRedo
            // 
            this.tbRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbRedo.Image = global::TagScanner.Properties.Resources.Edit_RedoHS;
            this.tbRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbRedo.Name = "tbRedo";
            this.tbRedo.Size = new System.Drawing.Size(30, 20);
            this.tbRedo.Text = "tbRedo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(30, 6);
            // 
            // tbCut
            // 
            this.tbCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCut.Image = global::TagScanner.Properties.Resources.CutHS;
            this.tbCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbCut.Name = "tbCut";
            this.tbCut.Size = new System.Drawing.Size(30, 20);
            this.tbCut.Text = "tbCut";
            // 
            // tbCopy
            // 
            this.tbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCopy.Image = global::TagScanner.Properties.Resources.CopyHS;
            this.tbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbCopy.Name = "tbCopy";
            this.tbCopy.Size = new System.Drawing.Size(30, 20);
            this.tbCopy.Text = "tbCopy";
            // 
            // tbPaste
            // 
            this.tbPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbPaste.Image = global::TagScanner.Properties.Resources.PasteHS;
            this.tbPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbPaste.Name = "tbPaste";
            this.tbPaste.Size = new System.Drawing.Size(30, 20);
            this.tbPaste.Text = "tbPaste";
            // 
            // tbDelete
            // 
            this.tbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbDelete.Image = global::TagScanner.Properties.Resources.Delete;
            this.tbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbDelete.Name = "tbDelete";
            this.tbDelete.Size = new System.Drawing.Size(30, 20);
            this.tbDelete.Text = "tbDelete";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(30, 6);
            // 
            // tbAdd
            // 
            this.tbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbAddMedia,
            this.tbAddFolder,
            this.toolStripMenuItem12,
            this.tbAddRecentFolder});
            this.tbAdd.Image = global::TagScanner.Properties.Resources.action_add_16xLG;
            this.tbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbAdd.Name = "tbAdd";
            this.tbAdd.Size = new System.Drawing.Size(30, 20);
            this.tbAdd.Text = "toolStripSplitButton1";
            // 
            // tbAddMedia
            // 
            this.tbAddMedia.Name = "tbAddMedia";
            this.tbAddMedia.Size = new System.Drawing.Size(171, 22);
            this.tbAddMedia.Text = "Add Media...";
            // 
            // tbAddFolder
            // 
            this.tbAddFolder.Name = "tbAddFolder";
            this.tbAddFolder.Size = new System.Drawing.Size(171, 22);
            this.tbAddFolder.Text = "Add Folder...";
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(168, 6);
            // 
            // tbAddRecentFolder
            // 
            this.tbAddRecentFolder.Name = "tbAddRecentFolder";
            this.tbAddRecentFolder.Size = new System.Drawing.Size(171, 22);
            this.tbAddRecentFolder.Text = "Add Recent Folder";
            // 
            // modelBindingSource
            // 
            this.modelBindingSource.DataSource = typeof(TagScanner.Models.Model);
            // 
            // worksBindingSource
            // 
            this.worksBindingSource.DataMember = "Works";
            this.worksBindingSource.DataSource = this.modelBindingSource;
            // 
            // albumDataGridViewTextBoxColumn
            // 
            this.albumDataGridViewTextBoxColumn.DataPropertyName = "Album";
            this.albumDataGridViewTextBoxColumn.HeaderText = "Album";
            this.albumDataGridViewTextBoxColumn.Name = "albumDataGridViewTextBoxColumn";
            // 
            // albumArtistsCountDataGridViewTextBoxColumn
            // 
            this.albumArtistsCountDataGridViewTextBoxColumn.DataPropertyName = "AlbumArtistsCount";
            this.albumArtistsCountDataGridViewTextBoxColumn.HeaderText = "AlbumArtistsCount";
            this.albumArtistsCountDataGridViewTextBoxColumn.Name = "albumArtistsCountDataGridViewTextBoxColumn";
            this.albumArtistsCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // albumArtistsSortCountDataGridViewTextBoxColumn
            // 
            this.albumArtistsSortCountDataGridViewTextBoxColumn.DataPropertyName = "AlbumArtistsSortCount";
            this.albumArtistsSortCountDataGridViewTextBoxColumn.HeaderText = "AlbumArtistsSortCount";
            this.albumArtistsSortCountDataGridViewTextBoxColumn.Name = "albumArtistsSortCountDataGridViewTextBoxColumn";
            this.albumArtistsSortCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // albumGainDataGridViewTextBoxColumn
            // 
            this.albumGainDataGridViewTextBoxColumn.DataPropertyName = "AlbumGain";
            this.albumGainDataGridViewTextBoxColumn.HeaderText = "AlbumGain";
            this.albumGainDataGridViewTextBoxColumn.Name = "albumGainDataGridViewTextBoxColumn";
            // 
            // albumPeakDataGridViewTextBoxColumn
            // 
            this.albumPeakDataGridViewTextBoxColumn.DataPropertyName = "AlbumPeak";
            this.albumPeakDataGridViewTextBoxColumn.HeaderText = "AlbumPeak";
            this.albumPeakDataGridViewTextBoxColumn.Name = "albumPeakDataGridViewTextBoxColumn";
            // 
            // albumSortDataGridViewTextBoxColumn
            // 
            this.albumSortDataGridViewTextBoxColumn.DataPropertyName = "AlbumSort";
            this.albumSortDataGridViewTextBoxColumn.HeaderText = "AlbumSort";
            this.albumSortDataGridViewTextBoxColumn.Name = "albumSortDataGridViewTextBoxColumn";
            // 
            // amazonIdDataGridViewTextBoxColumn
            // 
            this.amazonIdDataGridViewTextBoxColumn.DataPropertyName = "AmazonId";
            this.amazonIdDataGridViewTextBoxColumn.HeaderText = "AmazonId";
            this.amazonIdDataGridViewTextBoxColumn.Name = "amazonIdDataGridViewTextBoxColumn";
            // 
            // artistsCountDataGridViewTextBoxColumn
            // 
            this.artistsCountDataGridViewTextBoxColumn.DataPropertyName = "ArtistsCount";
            this.artistsCountDataGridViewTextBoxColumn.HeaderText = "ArtistsCount";
            this.artistsCountDataGridViewTextBoxColumn.Name = "artistsCountDataGridViewTextBoxColumn";
            this.artistsCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // audioBitrateDataGridViewTextBoxColumn
            // 
            this.audioBitrateDataGridViewTextBoxColumn.DataPropertyName = "AudioBitrate";
            this.audioBitrateDataGridViewTextBoxColumn.HeaderText = "AudioBitrate";
            this.audioBitrateDataGridViewTextBoxColumn.Name = "audioBitrateDataGridViewTextBoxColumn";
            // 
            // audioChannelsDataGridViewTextBoxColumn
            // 
            this.audioChannelsDataGridViewTextBoxColumn.DataPropertyName = "AudioChannels";
            this.audioChannelsDataGridViewTextBoxColumn.HeaderText = "AudioChannels";
            this.audioChannelsDataGridViewTextBoxColumn.Name = "audioChannelsDataGridViewTextBoxColumn";
            // 
            // audioSampleRateDataGridViewTextBoxColumn
            // 
            this.audioSampleRateDataGridViewTextBoxColumn.DataPropertyName = "AudioSampleRate";
            this.audioSampleRateDataGridViewTextBoxColumn.HeaderText = "AudioSampleRate";
            this.audioSampleRateDataGridViewTextBoxColumn.Name = "audioSampleRateDataGridViewTextBoxColumn";
            // 
            // beatsPerMinuteDataGridViewTextBoxColumn
            // 
            this.beatsPerMinuteDataGridViewTextBoxColumn.DataPropertyName = "BeatsPerMinute";
            this.beatsPerMinuteDataGridViewTextBoxColumn.HeaderText = "BeatsPerMinute";
            this.beatsPerMinuteDataGridViewTextBoxColumn.Name = "beatsPerMinuteDataGridViewTextBoxColumn";
            // 
            // bitsPerSampleDataGridViewTextBoxColumn
            // 
            this.bitsPerSampleDataGridViewTextBoxColumn.DataPropertyName = "BitsPerSample";
            this.bitsPerSampleDataGridViewTextBoxColumn.HeaderText = "BitsPerSample";
            this.bitsPerSampleDataGridViewTextBoxColumn.Name = "bitsPerSampleDataGridViewTextBoxColumn";
            // 
            // centuryDataGridViewTextBoxColumn
            // 
            this.centuryDataGridViewTextBoxColumn.DataPropertyName = "Century";
            this.centuryDataGridViewTextBoxColumn.HeaderText = "Century";
            this.centuryDataGridViewTextBoxColumn.Name = "centuryDataGridViewTextBoxColumn";
            this.centuryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codecsDataGridViewTextBoxColumn
            // 
            this.codecsDataGridViewTextBoxColumn.DataPropertyName = "Codecs";
            this.codecsDataGridViewTextBoxColumn.HeaderText = "Codecs";
            this.codecsDataGridViewTextBoxColumn.Name = "codecsDataGridViewTextBoxColumn";
            // 
            // commentDataGridViewTextBoxColumn
            // 
            this.commentDataGridViewTextBoxColumn.DataPropertyName = "Comment";
            this.commentDataGridViewTextBoxColumn.HeaderText = "Comment";
            this.commentDataGridViewTextBoxColumn.Name = "commentDataGridViewTextBoxColumn";
            // 
            // composersCountDataGridViewTextBoxColumn
            // 
            this.composersCountDataGridViewTextBoxColumn.DataPropertyName = "ComposersCount";
            this.composersCountDataGridViewTextBoxColumn.HeaderText = "ComposersCount";
            this.composersCountDataGridViewTextBoxColumn.Name = "composersCountDataGridViewTextBoxColumn";
            this.composersCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // composersSortCountDataGridViewTextBoxColumn
            // 
            this.composersSortCountDataGridViewTextBoxColumn.DataPropertyName = "ComposersSortCount";
            this.composersSortCountDataGridViewTextBoxColumn.HeaderText = "ComposersSortCount";
            this.composersSortCountDataGridViewTextBoxColumn.Name = "composersSortCountDataGridViewTextBoxColumn";
            this.composersSortCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // conductorDataGridViewTextBoxColumn
            // 
            this.conductorDataGridViewTextBoxColumn.DataPropertyName = "Conductor";
            this.conductorDataGridViewTextBoxColumn.HeaderText = "Conductor";
            this.conductorDataGridViewTextBoxColumn.Name = "conductorDataGridViewTextBoxColumn";
            // 
            // copyrightDataGridViewTextBoxColumn
            // 
            this.copyrightDataGridViewTextBoxColumn.DataPropertyName = "Copyright";
            this.copyrightDataGridViewTextBoxColumn.HeaderText = "Copyright";
            this.copyrightDataGridViewTextBoxColumn.Name = "copyrightDataGridViewTextBoxColumn";
            // 
            // decadeDataGridViewTextBoxColumn
            // 
            this.decadeDataGridViewTextBoxColumn.DataPropertyName = "Decade";
            this.decadeDataGridViewTextBoxColumn.HeaderText = "Decade";
            this.decadeDataGridViewTextBoxColumn.Name = "decadeDataGridViewTextBoxColumn";
            this.decadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // discCountDataGridViewTextBoxColumn
            // 
            this.discCountDataGridViewTextBoxColumn.DataPropertyName = "DiscCount";
            this.discCountDataGridViewTextBoxColumn.HeaderText = "DiscCount";
            this.discCountDataGridViewTextBoxColumn.Name = "discCountDataGridViewTextBoxColumn";
            // 
            // discNumberDataGridViewTextBoxColumn
            // 
            this.discNumberDataGridViewTextBoxColumn.DataPropertyName = "DiscNumber";
            this.discNumberDataGridViewTextBoxColumn.HeaderText = "DiscNumber";
            this.discNumberDataGridViewTextBoxColumn.Name = "discNumberDataGridViewTextBoxColumn";
            // 
            // discOfDataGridViewTextBoxColumn
            // 
            this.discOfDataGridViewTextBoxColumn.DataPropertyName = "DiscOf";
            this.discOfDataGridViewTextBoxColumn.HeaderText = "DiscOf";
            this.discOfDataGridViewTextBoxColumn.Name = "discOfDataGridViewTextBoxColumn";
            this.discOfDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // discTrackDataGridViewTextBoxColumn
            // 
            this.discTrackDataGridViewTextBoxColumn.DataPropertyName = "DiscTrack";
            this.discTrackDataGridViewTextBoxColumn.HeaderText = "DiscTrack";
            this.discTrackDataGridViewTextBoxColumn.Name = "discTrackDataGridViewTextBoxColumn";
            this.discTrackDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // durationDataGridViewTextBoxColumn
            // 
            this.durationDataGridViewTextBoxColumn.DataPropertyName = "Duration";
            this.durationDataGridViewTextBoxColumn.HeaderText = "Duration";
            this.durationDataGridViewTextBoxColumn.Name = "durationDataGridViewTextBoxColumn";
            // 
            // fileAttributesDataGridViewTextBoxColumn
            // 
            this.fileAttributesDataGridViewTextBoxColumn.DataPropertyName = "FileAttributes";
            this.fileAttributesDataGridViewTextBoxColumn.HeaderText = "FileAttributes";
            this.fileAttributesDataGridViewTextBoxColumn.Name = "fileAttributesDataGridViewTextBoxColumn";
            // 
            // fileCreationTimeDataGridViewTextBoxColumn
            // 
            this.fileCreationTimeDataGridViewTextBoxColumn.DataPropertyName = "FileCreationTime";
            this.fileCreationTimeDataGridViewTextBoxColumn.HeaderText = "FileCreationTime";
            this.fileCreationTimeDataGridViewTextBoxColumn.Name = "fileCreationTimeDataGridViewTextBoxColumn";
            // 
            // fileCreationTimeUtcDataGridViewTextBoxColumn
            // 
            this.fileCreationTimeUtcDataGridViewTextBoxColumn.DataPropertyName = "FileCreationTimeUtc";
            this.fileCreationTimeUtcDataGridViewTextBoxColumn.HeaderText = "FileCreationTimeUtc";
            this.fileCreationTimeUtcDataGridViewTextBoxColumn.Name = "fileCreationTimeUtcDataGridViewTextBoxColumn";
            // 
            // fileExtensionDataGridViewTextBoxColumn
            // 
            this.fileExtensionDataGridViewTextBoxColumn.DataPropertyName = "FileExtension";
            this.fileExtensionDataGridViewTextBoxColumn.HeaderText = "FileExtension";
            this.fileExtensionDataGridViewTextBoxColumn.Name = "fileExtensionDataGridViewTextBoxColumn";
            this.fileExtensionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fileLastAccessTimeDataGridViewTextBoxColumn
            // 
            this.fileLastAccessTimeDataGridViewTextBoxColumn.DataPropertyName = "FileLastAccessTime";
            this.fileLastAccessTimeDataGridViewTextBoxColumn.HeaderText = "FileLastAccessTime";
            this.fileLastAccessTimeDataGridViewTextBoxColumn.Name = "fileLastAccessTimeDataGridViewTextBoxColumn";
            // 
            // fileLastAccessTimeUtcDataGridViewTextBoxColumn
            // 
            this.fileLastAccessTimeUtcDataGridViewTextBoxColumn.DataPropertyName = "FileLastAccessTimeUtc";
            this.fileLastAccessTimeUtcDataGridViewTextBoxColumn.HeaderText = "FileLastAccessTimeUtc";
            this.fileLastAccessTimeUtcDataGridViewTextBoxColumn.Name = "fileLastAccessTimeUtcDataGridViewTextBoxColumn";
            // 
            // fileLastWriteTimeDataGridViewTextBoxColumn
            // 
            this.fileLastWriteTimeDataGridViewTextBoxColumn.DataPropertyName = "FileLastWriteTime";
            this.fileLastWriteTimeDataGridViewTextBoxColumn.HeaderText = "FileLastWriteTime";
            this.fileLastWriteTimeDataGridViewTextBoxColumn.Name = "fileLastWriteTimeDataGridViewTextBoxColumn";
            // 
            // fileLastWriteTimeUtcDataGridViewTextBoxColumn
            // 
            this.fileLastWriteTimeUtcDataGridViewTextBoxColumn.DataPropertyName = "FileLastWriteTimeUtc";
            this.fileLastWriteTimeUtcDataGridViewTextBoxColumn.HeaderText = "FileLastWriteTimeUtc";
            this.fileLastWriteTimeUtcDataGridViewTextBoxColumn.Name = "fileLastWriteTimeUtcDataGridViewTextBoxColumn";
            // 
            // fileNameDataGridViewTextBoxColumn
            // 
            this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "FileName";
            this.fileNameDataGridViewTextBoxColumn.HeaderText = "FileName";
            this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
            this.fileNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fileNameWithoutExtensionDataGridViewTextBoxColumn
            // 
            this.fileNameWithoutExtensionDataGridViewTextBoxColumn.DataPropertyName = "FileNameWithoutExtension";
            this.fileNameWithoutExtensionDataGridViewTextBoxColumn.HeaderText = "FileNameWithoutExtension";
            this.fileNameWithoutExtensionDataGridViewTextBoxColumn.Name = "fileNameWithoutExtensionDataGridViewTextBoxColumn";
            this.fileNameWithoutExtensionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // filePathDataGridViewTextBoxColumn
            // 
            this.filePathDataGridViewTextBoxColumn.DataPropertyName = "FilePath";
            this.filePathDataGridViewTextBoxColumn.HeaderText = "FilePath";
            this.filePathDataGridViewTextBoxColumn.Name = "filePathDataGridViewTextBoxColumn";
            // 
            // fileSizeDataGridViewTextBoxColumn
            // 
            this.fileSizeDataGridViewTextBoxColumn.DataPropertyName = "FileSize";
            this.fileSizeDataGridViewTextBoxColumn.HeaderText = "FileSize";
            this.fileSizeDataGridViewTextBoxColumn.Name = "fileSizeDataGridViewTextBoxColumn";
            // 
            // fileStatusDataGridViewTextBoxColumn
            // 
            this.fileStatusDataGridViewTextBoxColumn.DataPropertyName = "FileStatus";
            this.fileStatusDataGridViewTextBoxColumn.HeaderText = "FileStatus";
            this.fileStatusDataGridViewTextBoxColumn.Name = "fileStatusDataGridViewTextBoxColumn";
            this.fileStatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // firstAlbumArtistDataGridViewTextBoxColumn
            // 
            this.firstAlbumArtistDataGridViewTextBoxColumn.DataPropertyName = "FirstAlbumArtist";
            this.firstAlbumArtistDataGridViewTextBoxColumn.HeaderText = "FirstAlbumArtist";
            this.firstAlbumArtistDataGridViewTextBoxColumn.Name = "firstAlbumArtistDataGridViewTextBoxColumn";
            // 
            // firstAlbumArtistSortDataGridViewTextBoxColumn
            // 
            this.firstAlbumArtistSortDataGridViewTextBoxColumn.DataPropertyName = "FirstAlbumArtistSort";
            this.firstAlbumArtistSortDataGridViewTextBoxColumn.HeaderText = "FirstAlbumArtistSort";
            this.firstAlbumArtistSortDataGridViewTextBoxColumn.Name = "firstAlbumArtistSortDataGridViewTextBoxColumn";
            // 
            // firstArtistDataGridViewTextBoxColumn
            // 
            this.firstArtistDataGridViewTextBoxColumn.DataPropertyName = "FirstArtist";
            this.firstArtistDataGridViewTextBoxColumn.HeaderText = "FirstArtist";
            this.firstArtistDataGridViewTextBoxColumn.Name = "firstArtistDataGridViewTextBoxColumn";
            // 
            // firstComposerDataGridViewTextBoxColumn
            // 
            this.firstComposerDataGridViewTextBoxColumn.DataPropertyName = "FirstComposer";
            this.firstComposerDataGridViewTextBoxColumn.HeaderText = "FirstComposer";
            this.firstComposerDataGridViewTextBoxColumn.Name = "firstComposerDataGridViewTextBoxColumn";
            // 
            // firstComposerSortDataGridViewTextBoxColumn
            // 
            this.firstComposerSortDataGridViewTextBoxColumn.DataPropertyName = "FirstComposerSort";
            this.firstComposerSortDataGridViewTextBoxColumn.HeaderText = "FirstComposerSort";
            this.firstComposerSortDataGridViewTextBoxColumn.Name = "firstComposerSortDataGridViewTextBoxColumn";
            // 
            // firstGenreDataGridViewTextBoxColumn
            // 
            this.firstGenreDataGridViewTextBoxColumn.DataPropertyName = "FirstGenre";
            this.firstGenreDataGridViewTextBoxColumn.HeaderText = "FirstGenre";
            this.firstGenreDataGridViewTextBoxColumn.Name = "firstGenreDataGridViewTextBoxColumn";
            // 
            // firstPerformerDataGridViewTextBoxColumn
            // 
            this.firstPerformerDataGridViewTextBoxColumn.DataPropertyName = "FirstPerformer";
            this.firstPerformerDataGridViewTextBoxColumn.HeaderText = "FirstPerformer";
            this.firstPerformerDataGridViewTextBoxColumn.Name = "firstPerformerDataGridViewTextBoxColumn";
            // 
            // firstPerformerSortDataGridViewTextBoxColumn
            // 
            this.firstPerformerSortDataGridViewTextBoxColumn.DataPropertyName = "FirstPerformerSort";
            this.firstPerformerSortDataGridViewTextBoxColumn.HeaderText = "FirstPerformerSort";
            this.firstPerformerSortDataGridViewTextBoxColumn.Name = "firstPerformerSortDataGridViewTextBoxColumn";
            // 
            // genresCountDataGridViewTextBoxColumn
            // 
            this.genresCountDataGridViewTextBoxColumn.DataPropertyName = "GenresCount";
            this.genresCountDataGridViewTextBoxColumn.HeaderText = "GenresCount";
            this.genresCountDataGridViewTextBoxColumn.Name = "genresCountDataGridViewTextBoxColumn";
            this.genresCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // groupingDataGridViewTextBoxColumn
            // 
            this.groupingDataGridViewTextBoxColumn.DataPropertyName = "Grouping";
            this.groupingDataGridViewTextBoxColumn.HeaderText = "Grouping";
            this.groupingDataGridViewTextBoxColumn.Name = "groupingDataGridViewTextBoxColumn";
            // 
            // imageAltitudeDataGridViewTextBoxColumn
            // 
            this.imageAltitudeDataGridViewTextBoxColumn.DataPropertyName = "ImageAltitude";
            this.imageAltitudeDataGridViewTextBoxColumn.HeaderText = "ImageAltitude";
            this.imageAltitudeDataGridViewTextBoxColumn.Name = "imageAltitudeDataGridViewTextBoxColumn";
            // 
            // imageCreatorDataGridViewTextBoxColumn
            // 
            this.imageCreatorDataGridViewTextBoxColumn.DataPropertyName = "ImageCreator";
            this.imageCreatorDataGridViewTextBoxColumn.HeaderText = "ImageCreator";
            this.imageCreatorDataGridViewTextBoxColumn.Name = "imageCreatorDataGridViewTextBoxColumn";
            // 
            // imageDateTimeDataGridViewTextBoxColumn
            // 
            this.imageDateTimeDataGridViewTextBoxColumn.DataPropertyName = "ImageDateTime";
            this.imageDateTimeDataGridViewTextBoxColumn.HeaderText = "ImageDateTime";
            this.imageDateTimeDataGridViewTextBoxColumn.Name = "imageDateTimeDataGridViewTextBoxColumn";
            // 
            // imageExposureTimeDataGridViewTextBoxColumn
            // 
            this.imageExposureTimeDataGridViewTextBoxColumn.DataPropertyName = "ImageExposureTime";
            this.imageExposureTimeDataGridViewTextBoxColumn.HeaderText = "ImageExposureTime";
            this.imageExposureTimeDataGridViewTextBoxColumn.Name = "imageExposureTimeDataGridViewTextBoxColumn";
            // 
            // imageFNumberDataGridViewTextBoxColumn
            // 
            this.imageFNumberDataGridViewTextBoxColumn.DataPropertyName = "ImageFNumber";
            this.imageFNumberDataGridViewTextBoxColumn.HeaderText = "ImageFNumber";
            this.imageFNumberDataGridViewTextBoxColumn.Name = "imageFNumberDataGridViewTextBoxColumn";
            // 
            // imageFocalLengthDataGridViewTextBoxColumn
            // 
            this.imageFocalLengthDataGridViewTextBoxColumn.DataPropertyName = "ImageFocalLength";
            this.imageFocalLengthDataGridViewTextBoxColumn.HeaderText = "ImageFocalLength";
            this.imageFocalLengthDataGridViewTextBoxColumn.Name = "imageFocalLengthDataGridViewTextBoxColumn";
            // 
            // imageFocalLengthIn35mmFilmDataGridViewTextBoxColumn
            // 
            this.imageFocalLengthIn35mmFilmDataGridViewTextBoxColumn.DataPropertyName = "ImageFocalLengthIn35mmFilm";
            this.imageFocalLengthIn35mmFilmDataGridViewTextBoxColumn.HeaderText = "ImageFocalLengthIn35mmFilm";
            this.imageFocalLengthIn35mmFilmDataGridViewTextBoxColumn.Name = "imageFocalLengthIn35mmFilmDataGridViewTextBoxColumn";
            // 
            // imageISOSpeedRatingsDataGridViewTextBoxColumn
            // 
            this.imageISOSpeedRatingsDataGridViewTextBoxColumn.DataPropertyName = "ImageISOSpeedRatings";
            this.imageISOSpeedRatingsDataGridViewTextBoxColumn.HeaderText = "ImageISOSpeedRatings";
            this.imageISOSpeedRatingsDataGridViewTextBoxColumn.Name = "imageISOSpeedRatingsDataGridViewTextBoxColumn";
            // 
            // imageLatitudeDataGridViewTextBoxColumn
            // 
            this.imageLatitudeDataGridViewTextBoxColumn.DataPropertyName = "ImageLatitude";
            this.imageLatitudeDataGridViewTextBoxColumn.HeaderText = "ImageLatitude";
            this.imageLatitudeDataGridViewTextBoxColumn.Name = "imageLatitudeDataGridViewTextBoxColumn";
            // 
            // imageLongitudeDataGridViewTextBoxColumn
            // 
            this.imageLongitudeDataGridViewTextBoxColumn.DataPropertyName = "ImageLongitude";
            this.imageLongitudeDataGridViewTextBoxColumn.HeaderText = "ImageLongitude";
            this.imageLongitudeDataGridViewTextBoxColumn.Name = "imageLongitudeDataGridViewTextBoxColumn";
            // 
            // imageMakeDataGridViewTextBoxColumn
            // 
            this.imageMakeDataGridViewTextBoxColumn.DataPropertyName = "ImageMake";
            this.imageMakeDataGridViewTextBoxColumn.HeaderText = "ImageMake";
            this.imageMakeDataGridViewTextBoxColumn.Name = "imageMakeDataGridViewTextBoxColumn";
            // 
            // imageModelDataGridViewTextBoxColumn
            // 
            this.imageModelDataGridViewTextBoxColumn.DataPropertyName = "ImageModel";
            this.imageModelDataGridViewTextBoxColumn.HeaderText = "ImageModel";
            this.imageModelDataGridViewTextBoxColumn.Name = "imageModelDataGridViewTextBoxColumn";
            // 
            // imageOrientationDataGridViewTextBoxColumn
            // 
            this.imageOrientationDataGridViewTextBoxColumn.DataPropertyName = "ImageOrientation";
            this.imageOrientationDataGridViewTextBoxColumn.HeaderText = "ImageOrientation";
            this.imageOrientationDataGridViewTextBoxColumn.Name = "imageOrientationDataGridViewTextBoxColumn";
            // 
            // imageRatingDataGridViewTextBoxColumn
            // 
            this.imageRatingDataGridViewTextBoxColumn.DataPropertyName = "ImageRating";
            this.imageRatingDataGridViewTextBoxColumn.HeaderText = "ImageRating";
            this.imageRatingDataGridViewTextBoxColumn.Name = "imageRatingDataGridViewTextBoxColumn";
            // 
            // imageSoftwareDataGridViewTextBoxColumn
            // 
            this.imageSoftwareDataGridViewTextBoxColumn.DataPropertyName = "ImageSoftware";
            this.imageSoftwareDataGridViewTextBoxColumn.HeaderText = "ImageSoftware";
            this.imageSoftwareDataGridViewTextBoxColumn.Name = "imageSoftwareDataGridViewTextBoxColumn";
            // 
            // invariantEndPositionDataGridViewTextBoxColumn
            // 
            this.invariantEndPositionDataGridViewTextBoxColumn.DataPropertyName = "InvariantEndPosition";
            this.invariantEndPositionDataGridViewTextBoxColumn.HeaderText = "InvariantEndPosition";
            this.invariantEndPositionDataGridViewTextBoxColumn.Name = "invariantEndPositionDataGridViewTextBoxColumn";
            // 
            // invariantStartPositionDataGridViewTextBoxColumn
            // 
            this.invariantStartPositionDataGridViewTextBoxColumn.DataPropertyName = "InvariantStartPosition";
            this.invariantStartPositionDataGridViewTextBoxColumn.HeaderText = "InvariantStartPosition";
            this.invariantStartPositionDataGridViewTextBoxColumn.Name = "invariantStartPositionDataGridViewTextBoxColumn";
            // 
            // isClassicalDataGridViewTextBoxColumn
            // 
            this.isClassicalDataGridViewTextBoxColumn.DataPropertyName = "IsClassical";
            this.isClassicalDataGridViewTextBoxColumn.HeaderText = "IsClassical";
            this.isClassicalDataGridViewTextBoxColumn.Name = "isClassicalDataGridViewTextBoxColumn";
            this.isClassicalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isEmptyDataGridViewTextBoxColumn
            // 
            this.isEmptyDataGridViewTextBoxColumn.DataPropertyName = "IsEmpty";
            this.isEmptyDataGridViewTextBoxColumn.HeaderText = "IsEmpty";
            this.isEmptyDataGridViewTextBoxColumn.Name = "isEmptyDataGridViewTextBoxColumn";
            this.isEmptyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // joinedAlbumArtistsDataGridViewTextBoxColumn
            // 
            this.joinedAlbumArtistsDataGridViewTextBoxColumn.DataPropertyName = "JoinedAlbumArtists";
            this.joinedAlbumArtistsDataGridViewTextBoxColumn.HeaderText = "JoinedAlbumArtists";
            this.joinedAlbumArtistsDataGridViewTextBoxColumn.Name = "joinedAlbumArtistsDataGridViewTextBoxColumn";
            // 
            // joinedArtistsDataGridViewTextBoxColumn
            // 
            this.joinedArtistsDataGridViewTextBoxColumn.DataPropertyName = "JoinedArtists";
            this.joinedArtistsDataGridViewTextBoxColumn.HeaderText = "JoinedArtists";
            this.joinedArtistsDataGridViewTextBoxColumn.Name = "joinedArtistsDataGridViewTextBoxColumn";
            // 
            // joinedComposersDataGridViewTextBoxColumn
            // 
            this.joinedComposersDataGridViewTextBoxColumn.DataPropertyName = "JoinedComposers";
            this.joinedComposersDataGridViewTextBoxColumn.HeaderText = "JoinedComposers";
            this.joinedComposersDataGridViewTextBoxColumn.Name = "joinedComposersDataGridViewTextBoxColumn";
            // 
            // joinedGenresDataGridViewTextBoxColumn
            // 
            this.joinedGenresDataGridViewTextBoxColumn.DataPropertyName = "JoinedGenres";
            this.joinedGenresDataGridViewTextBoxColumn.HeaderText = "JoinedGenres";
            this.joinedGenresDataGridViewTextBoxColumn.Name = "joinedGenresDataGridViewTextBoxColumn";
            // 
            // joinedPerformersDataGridViewTextBoxColumn
            // 
            this.joinedPerformersDataGridViewTextBoxColumn.DataPropertyName = "JoinedPerformers";
            this.joinedPerformersDataGridViewTextBoxColumn.HeaderText = "JoinedPerformers";
            this.joinedPerformersDataGridViewTextBoxColumn.Name = "joinedPerformersDataGridViewTextBoxColumn";
            // 
            // joinedPerformersSortDataGridViewTextBoxColumn
            // 
            this.joinedPerformersSortDataGridViewTextBoxColumn.DataPropertyName = "JoinedPerformersSort";
            this.joinedPerformersSortDataGridViewTextBoxColumn.HeaderText = "JoinedPerformersSort";
            this.joinedPerformersSortDataGridViewTextBoxColumn.Name = "joinedPerformersSortDataGridViewTextBoxColumn";
            // 
            // lyricsDataGridViewTextBoxColumn
            // 
            this.lyricsDataGridViewTextBoxColumn.DataPropertyName = "Lyrics";
            this.lyricsDataGridViewTextBoxColumn.HeaderText = "Lyrics";
            this.lyricsDataGridViewTextBoxColumn.Name = "lyricsDataGridViewTextBoxColumn";
            // 
            // mediaTypesDataGridViewTextBoxColumn
            // 
            this.mediaTypesDataGridViewTextBoxColumn.DataPropertyName = "MediaTypes";
            this.mediaTypesDataGridViewTextBoxColumn.HeaderText = "MediaTypes";
            this.mediaTypesDataGridViewTextBoxColumn.Name = "mediaTypesDataGridViewTextBoxColumn";
            // 
            // millenniumDataGridViewTextBoxColumn
            // 
            this.millenniumDataGridViewTextBoxColumn.DataPropertyName = "Millennium";
            this.millenniumDataGridViewTextBoxColumn.HeaderText = "Millennium";
            this.millenniumDataGridViewTextBoxColumn.Name = "millenniumDataGridViewTextBoxColumn";
            this.millenniumDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mimeTypeDataGridViewTextBoxColumn
            // 
            this.mimeTypeDataGridViewTextBoxColumn.DataPropertyName = "MimeType";
            this.mimeTypeDataGridViewTextBoxColumn.HeaderText = "MimeType";
            this.mimeTypeDataGridViewTextBoxColumn.Name = "mimeTypeDataGridViewTextBoxColumn";
            // 
            // musicBrainzArtistIdDataGridViewTextBoxColumn
            // 
            this.musicBrainzArtistIdDataGridViewTextBoxColumn.DataPropertyName = "MusicBrainzArtistId";
            this.musicBrainzArtistIdDataGridViewTextBoxColumn.HeaderText = "MusicBrainzArtistId";
            this.musicBrainzArtistIdDataGridViewTextBoxColumn.Name = "musicBrainzArtistIdDataGridViewTextBoxColumn";
            // 
            // musicBrainzDiscIdDataGridViewTextBoxColumn
            // 
            this.musicBrainzDiscIdDataGridViewTextBoxColumn.DataPropertyName = "MusicBrainzDiscId";
            this.musicBrainzDiscIdDataGridViewTextBoxColumn.HeaderText = "MusicBrainzDiscId";
            this.musicBrainzDiscIdDataGridViewTextBoxColumn.Name = "musicBrainzDiscIdDataGridViewTextBoxColumn";
            // 
            // musicBrainzReleaseArtistIdDataGridViewTextBoxColumn
            // 
            this.musicBrainzReleaseArtistIdDataGridViewTextBoxColumn.DataPropertyName = "MusicBrainzReleaseArtistId";
            this.musicBrainzReleaseArtistIdDataGridViewTextBoxColumn.HeaderText = "MusicBrainzReleaseArtistId";
            this.musicBrainzReleaseArtistIdDataGridViewTextBoxColumn.Name = "musicBrainzReleaseArtistIdDataGridViewTextBoxColumn";
            // 
            // musicBrainzReleaseCountryDataGridViewTextBoxColumn
            // 
            this.musicBrainzReleaseCountryDataGridViewTextBoxColumn.DataPropertyName = "MusicBrainzReleaseCountry";
            this.musicBrainzReleaseCountryDataGridViewTextBoxColumn.HeaderText = "MusicBrainzReleaseCountry";
            this.musicBrainzReleaseCountryDataGridViewTextBoxColumn.Name = "musicBrainzReleaseCountryDataGridViewTextBoxColumn";
            // 
            // musicBrainzReleaseIdDataGridViewTextBoxColumn
            // 
            this.musicBrainzReleaseIdDataGridViewTextBoxColumn.DataPropertyName = "MusicBrainzReleaseId";
            this.musicBrainzReleaseIdDataGridViewTextBoxColumn.HeaderText = "MusicBrainzReleaseId";
            this.musicBrainzReleaseIdDataGridViewTextBoxColumn.Name = "musicBrainzReleaseIdDataGridViewTextBoxColumn";
            // 
            // musicBrainzReleaseStatusDataGridViewTextBoxColumn
            // 
            this.musicBrainzReleaseStatusDataGridViewTextBoxColumn.DataPropertyName = "MusicBrainzReleaseStatus";
            this.musicBrainzReleaseStatusDataGridViewTextBoxColumn.HeaderText = "MusicBrainzReleaseStatus";
            this.musicBrainzReleaseStatusDataGridViewTextBoxColumn.Name = "musicBrainzReleaseStatusDataGridViewTextBoxColumn";
            // 
            // musicBrainzReleaseTypeDataGridViewTextBoxColumn
            // 
            this.musicBrainzReleaseTypeDataGridViewTextBoxColumn.DataPropertyName = "MusicBrainzReleaseType";
            this.musicBrainzReleaseTypeDataGridViewTextBoxColumn.HeaderText = "MusicBrainzReleaseType";
            this.musicBrainzReleaseTypeDataGridViewTextBoxColumn.Name = "musicBrainzReleaseTypeDataGridViewTextBoxColumn";
            // 
            // musicBrainzTrackIdDataGridViewTextBoxColumn
            // 
            this.musicBrainzTrackIdDataGridViewTextBoxColumn.DataPropertyName = "MusicBrainzTrackId";
            this.musicBrainzTrackIdDataGridViewTextBoxColumn.HeaderText = "MusicBrainzTrackId";
            this.musicBrainzTrackIdDataGridViewTextBoxColumn.Name = "musicBrainzTrackIdDataGridViewTextBoxColumn";
            // 
            // musicIpIdDataGridViewTextBoxColumn
            // 
            this.musicIpIdDataGridViewTextBoxColumn.DataPropertyName = "MusicIpId";
            this.musicIpIdDataGridViewTextBoxColumn.HeaderText = "MusicIpId";
            this.musicIpIdDataGridViewTextBoxColumn.Name = "musicIpIdDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // performersCountDataGridViewTextBoxColumn
            // 
            this.performersCountDataGridViewTextBoxColumn.DataPropertyName = "PerformersCount";
            this.performersCountDataGridViewTextBoxColumn.HeaderText = "PerformersCount";
            this.performersCountDataGridViewTextBoxColumn.Name = "performersCountDataGridViewTextBoxColumn";
            this.performersCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // performersSortCountDataGridViewTextBoxColumn
            // 
            this.performersSortCountDataGridViewTextBoxColumn.DataPropertyName = "PerformersSortCount";
            this.performersSortCountDataGridViewTextBoxColumn.HeaderText = "PerformersSortCount";
            this.performersSortCountDataGridViewTextBoxColumn.Name = "performersSortCountDataGridViewTextBoxColumn";
            this.performersSortCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // photoHeightDataGridViewTextBoxColumn
            // 
            this.photoHeightDataGridViewTextBoxColumn.DataPropertyName = "PhotoHeight";
            this.photoHeightDataGridViewTextBoxColumn.HeaderText = "PhotoHeight";
            this.photoHeightDataGridViewTextBoxColumn.Name = "photoHeightDataGridViewTextBoxColumn";
            // 
            // photoQualityDataGridViewTextBoxColumn
            // 
            this.photoQualityDataGridViewTextBoxColumn.DataPropertyName = "PhotoQuality";
            this.photoQualityDataGridViewTextBoxColumn.HeaderText = "PhotoQuality";
            this.photoQualityDataGridViewTextBoxColumn.Name = "photoQualityDataGridViewTextBoxColumn";
            // 
            // photoWidthDataGridViewTextBoxColumn
            // 
            this.photoWidthDataGridViewTextBoxColumn.DataPropertyName = "PhotoWidth";
            this.photoWidthDataGridViewTextBoxColumn.HeaderText = "PhotoWidth";
            this.photoWidthDataGridViewTextBoxColumn.Name = "photoWidthDataGridViewTextBoxColumn";
            // 
            // picturesCountDataGridViewTextBoxColumn
            // 
            this.picturesCountDataGridViewTextBoxColumn.DataPropertyName = "PicturesCount";
            this.picturesCountDataGridViewTextBoxColumn.HeaderText = "PicturesCount";
            this.picturesCountDataGridViewTextBoxColumn.Name = "picturesCountDataGridViewTextBoxColumn";
            this.picturesCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // possiblyCorruptDataGridViewTextBoxColumn
            // 
            this.possiblyCorruptDataGridViewTextBoxColumn.DataPropertyName = "PossiblyCorrupt";
            this.possiblyCorruptDataGridViewTextBoxColumn.HeaderText = "PossiblyCorrupt";
            this.possiblyCorruptDataGridViewTextBoxColumn.Name = "possiblyCorruptDataGridViewTextBoxColumn";
            this.possiblyCorruptDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tagTypesDataGridViewTextBoxColumn
            // 
            this.tagTypesDataGridViewTextBoxColumn.DataPropertyName = "TagTypes";
            this.tagTypesDataGridViewTextBoxColumn.HeaderText = "TagTypes";
            this.tagTypesDataGridViewTextBoxColumn.Name = "tagTypesDataGridViewTextBoxColumn";
            // 
            // tagTypesOnDiskDataGridViewTextBoxColumn
            // 
            this.tagTypesOnDiskDataGridViewTextBoxColumn.DataPropertyName = "TagTypesOnDisk";
            this.tagTypesOnDiskDataGridViewTextBoxColumn.HeaderText = "TagTypesOnDisk";
            this.tagTypesOnDiskDataGridViewTextBoxColumn.Name = "tagTypesOnDiskDataGridViewTextBoxColumn";
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            // 
            // titleSortDataGridViewTextBoxColumn
            // 
            this.titleSortDataGridViewTextBoxColumn.DataPropertyName = "TitleSort";
            this.titleSortDataGridViewTextBoxColumn.HeaderText = "TitleSort";
            this.titleSortDataGridViewTextBoxColumn.Name = "titleSortDataGridViewTextBoxColumn";
            // 
            // trackCountDataGridViewTextBoxColumn
            // 
            this.trackCountDataGridViewTextBoxColumn.DataPropertyName = "TrackCount";
            this.trackCountDataGridViewTextBoxColumn.HeaderText = "TrackCount";
            this.trackCountDataGridViewTextBoxColumn.Name = "trackCountDataGridViewTextBoxColumn";
            // 
            // trackGainDataGridViewTextBoxColumn
            // 
            this.trackGainDataGridViewTextBoxColumn.DataPropertyName = "TrackGain";
            this.trackGainDataGridViewTextBoxColumn.HeaderText = "TrackGain";
            this.trackGainDataGridViewTextBoxColumn.Name = "trackGainDataGridViewTextBoxColumn";
            // 
            // trackNumberDataGridViewTextBoxColumn
            // 
            this.trackNumberDataGridViewTextBoxColumn.DataPropertyName = "TrackNumber";
            this.trackNumberDataGridViewTextBoxColumn.HeaderText = "TrackNumber";
            this.trackNumberDataGridViewTextBoxColumn.Name = "trackNumberDataGridViewTextBoxColumn";
            // 
            // trackOfDataGridViewTextBoxColumn
            // 
            this.trackOfDataGridViewTextBoxColumn.DataPropertyName = "TrackOf";
            this.trackOfDataGridViewTextBoxColumn.HeaderText = "TrackOf";
            this.trackOfDataGridViewTextBoxColumn.Name = "trackOfDataGridViewTextBoxColumn";
            this.trackOfDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // trackPeakDataGridViewTextBoxColumn
            // 
            this.trackPeakDataGridViewTextBoxColumn.DataPropertyName = "TrackPeak";
            this.trackPeakDataGridViewTextBoxColumn.HeaderText = "TrackPeak";
            this.trackPeakDataGridViewTextBoxColumn.Name = "trackPeakDataGridViewTextBoxColumn";
            // 
            // videoHeightDataGridViewTextBoxColumn
            // 
            this.videoHeightDataGridViewTextBoxColumn.DataPropertyName = "VideoHeight";
            this.videoHeightDataGridViewTextBoxColumn.HeaderText = "VideoHeight";
            this.videoHeightDataGridViewTextBoxColumn.Name = "videoHeightDataGridViewTextBoxColumn";
            // 
            // videoWidthDataGridViewTextBoxColumn
            // 
            this.videoWidthDataGridViewTextBoxColumn.DataPropertyName = "VideoWidth";
            this.videoWidthDataGridViewTextBoxColumn.HeaderText = "VideoWidth";
            this.videoWidthDataGridViewTextBoxColumn.Name = "videoWidthDataGridViewTextBoxColumn";
            // 
            // yearDataGridViewTextBoxColumn
            // 
            this.yearDataGridViewTextBoxColumn.DataPropertyName = "Year";
            this.yearDataGridViewTextBoxColumn.HeaderText = "Year";
            this.yearDataGridViewTextBoxColumn.Name = "yearDataGridViewTextBoxColumn";
            // 
            // yearAlbumDataGridViewTextBoxColumn
            // 
            this.yearAlbumDataGridViewTextBoxColumn.DataPropertyName = "YearAlbum";
            this.yearAlbumDataGridViewTextBoxColumn.HeaderText = "YearAlbum";
            this.yearAlbumDataGridViewTextBoxColumn.Name = "yearAlbumDataGridViewTextBoxColumn";
            this.yearAlbumDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // LibraryForm
            // 
            this.AcceptButton = this.ApplyButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
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
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.GridPopupMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).EndInit();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.worksBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.SplitContainer splitContainer1;
		public System.Windows.Forms.SplitContainer splitContainer2;
		public System.Windows.Forms.PictureBox PictureBox;
		public System.Windows.Forms.ToolStripMenuItem FileMenu;
		public System.Windows.Forms.ToolStripMenuItem FileExit;
		public System.Windows.Forms.ToolStripMenuItem EditMenu;
		public System.Windows.Forms.ToolStripMenuItem EditSelectAll;
		public System.Windows.Forms.ToolStripMenuItem EditInvertSelection;
		public System.Windows.Forms.ToolStripMenuItem ViewMenu;
		public System.Windows.Forms.ToolStripMenuItem HelpMenu;
		public System.Windows.Forms.ToolStripMenuItem HelpAbout;
		public System.Windows.Forms.FolderBrowserDialog AddFolderDialog;
		public System.Windows.Forms.OpenFileDialog AddFileDialog;
		public System.Windows.Forms.StatusStrip StatusBar;
		public System.Windows.Forms.ToolStripMenuItem FileOpen;
		public System.Windows.Forms.ToolStripMenuItem FileSave;
		public System.Windows.Forms.ToolStripMenuItem FileSaveAs;
		public System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		public System.Windows.Forms.ToolStripMenuItem AddMenu;
		public System.Windows.Forms.ToolStripMenuItem AddMedia;
		public System.Windows.Forms.ToolStripMenuItem AddFolder;
		public System.Windows.Forms.ToolStripMenuItem AddRecentFolder;
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
        public System.Windows.Forms.CheckBox CaseSensitiveCheckBox;
        public System.Windows.Forms.Button ApplyButton;
        public System.Windows.Forms.ToolStripMenuItem GridPopupMoreActions;
        public System.Windows.Forms.ToolStripMenuItem FileClose;
        public Controls.FirstClickMenuStrip MainMenu;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        public System.Windows.Forms.Button ClearButton;
        public System.Windows.Forms.ToolStripMenuItem WindowMenu;
        public System.Windows.Forms.ToolStripMenuItem FileNew;
        public System.Windows.Forms.ToolStripMenuItem WindowNew;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        public System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripSplitButton tbNew;
        public System.Windows.Forms.ToolStripSplitButton tbOpen;
        public System.Windows.Forms.ToolStripSplitButton tbSave;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripSplitButton tbUndo;
        public System.Windows.Forms.ToolStripSplitButton tbRedo;
        public System.Windows.Forms.ToolStripButton tbCut;
        public System.Windows.Forms.ToolStripButton tbCopy;
        public System.Windows.Forms.ToolStripButton tbPaste;
        public System.Windows.Forms.ToolStripButton tbDelete;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripMenuItem tbNewLibrary;
        public System.Windows.Forms.ToolStripMenuItem tbNewWindow;
        public System.Windows.Forms.ToolStripMenuItem tbOpenLibrary;
        public System.Windows.Forms.ToolStripMenuItem tbReopen;
        public System.Windows.Forms.ToolStripMenuItem tbSaveLibrary;
        public System.Windows.Forms.ToolStripMenuItem tbSaveAs;
        public System.Windows.Forms.ToolStripMenuItem EditUndo;
        public System.Windows.Forms.ToolStripMenuItem EditRedo;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
        public System.Windows.Forms.ToolStripMenuItem EditCut;
        public System.Windows.Forms.ToolStripMenuItem EditCopy;
        public System.Windows.Forms.ToolStripMenuItem EditPaste;
        public System.Windows.Forms.ToolStripMenuItem EditDelete;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem11;
        public System.Windows.Forms.ToolStripSplitButton tbAdd;
        public System.Windows.Forms.ToolStripMenuItem tbAddMedia;
        public System.Windows.Forms.ToolStripMenuItem tbAddFolder;
        public System.Windows.Forms.ToolStripMenuItem tbAddRecentFolder;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem12;
        public System.Windows.Forms.SplitContainer splitContainer4;
        public System.Windows.Forms.DataGridView DataGridView;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.DataGridViewTextBoxColumn albumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn albumArtistsCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn albumArtistsSortCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn albumGainDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn albumPeakDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn albumSortDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amazonIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn artistsCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn audioBitrateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn audioChannelsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn audioSampleRateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn beatsPerMinuteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bitsPerSampleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn centuryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codecsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn composersCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn composersSortCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn conductorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn copyrightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn decadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discOfDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discTrackDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileAttributesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileCreationTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileCreationTimeUtcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileExtensionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileLastAccessTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileLastAccessTimeUtcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileLastWriteTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileLastWriteTimeUtcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameWithoutExtensionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn filePathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstAlbumArtistDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstAlbumArtistSortDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstArtistDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstComposerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstComposerSortDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstGenreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstPerformerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstPerformerSortDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn genresCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imageAltitudeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imageCreatorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imageDateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imageExposureTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imageFNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imageFocalLengthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imageFocalLengthIn35mmFilmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imageISOSpeedRatingsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imageLatitudeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imageLongitudeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imageMakeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imageModelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imageOrientationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imageRatingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imageSoftwareDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invariantEndPositionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invariantStartPositionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isClassicalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isEmptyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn joinedAlbumArtistsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn joinedArtistsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn joinedComposersDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn joinedGenresDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn joinedPerformersDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn joinedPerformersSortDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lyricsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mediaTypesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn millenniumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mimeTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn musicBrainzArtistIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn musicBrainzDiscIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn musicBrainzReleaseArtistIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn musicBrainzReleaseCountryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn musicBrainzReleaseIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn musicBrainzReleaseStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn musicBrainzReleaseTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn musicBrainzTrackIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn musicIpIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn performersCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn performersSortCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn photoHeightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn photoQualityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn photoWidthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn picturesCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn possiblyCorruptDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tagTypesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tagTypesOnDiskDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleSortDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn trackCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn trackGainDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn trackNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn trackOfDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn trackPeakDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn videoHeightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn videoWidthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yearAlbumDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource worksBindingSource;
        private System.Windows.Forms.BindingSource modelBindingSource;
    }
}

