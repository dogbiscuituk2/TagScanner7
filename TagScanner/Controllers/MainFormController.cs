﻿namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Commands;
    using Models;
    using Mru;
    using Properties;
    using Streaming;
    using Terms;
    using Utils;
    using Views;

    public class MainFormController : Controller
    {
        #region Constructor

        public MainFormController() : base(null)
        {
            View = new MainForm();
            Model = new Model();
            Model.TracksAdd += Model_TracksAdd;
            Model.TracksEdit += Model_TracksEdit;
            CommandProcessor = new CommandProcessor(this);
            FilterController = new FilterController(this);
            LibraryGridController = new TableController(this, View.GridElementHost);
            LibraryGridController.SelectionChanged += LibraryGridController_SelectionChanged;
            MediaController = new MruMediaController(this, View.RecentFolderPopupMenu);
            MruLibraryController = new MruLibraryController(this, View.RecentLibraryPopupMenu);
            MruLibraryController.FilePathChanged += PersistenceController_FilePathChanged;
            MruLibraryController.FileSaving += PersistenceController_FileSaving;
            PlayerController = new PlayerController(this);
            PictureController = new PictureController(View.PictureBox, View.PropertyGrid, PlayerController.PlaylistGrid);
            PropertyGridController = new PropertyGridController(this);
            StatusController = new StatusController(this);
            ModifiedChanged();
            UpdateUI();
        }

        #endregion

        protected override IWin32Window Owner => View;

        #region View

        private MainForm _view;
        public MainForm View
        {
            get => _view;
            set
            {
                _view = value;

                View.FileMenu.DropDownOpening += Menu_DropDownOpening;
                View.tbOpen.DropDownOpening += Menu_DropDownOpening;
                View.tbSave.DropDownOpening += Menu_DropDownOpening;
                View.AddMenu.DropDownOpening += Menu_DropDownOpening;
                View.tbAdd.DropDownOpening += Menu_DropDownOpening;

                View.FileReopen.DropDownOpening += FileReopen_DropDownOpening;
                View.tbReopen.DropDownOpening += FileReopen_DropDownOpening;
                View.AddRecentLibrary.DropDownOpening += AddRecentLibrary_DropDownOpening;
                View.tbAddRecentLibrary.DropDownOpening += AddRecentLibrary_DropDownOpening;

                View.FileNew.Click += FileNewLibrary_Click;
                View.tbNewLibrary.Click += FileNewLibrary_Click;
                View.tbNew.ButtonClick += FileNewLibrary_Click;
                View.tbNewWindow.Click += FileNewWindow_Click;
                View.WindowNew.Click += FileNewWindow_Click;

                View.FileOpen.Click += FileOpen_Click;
                View.tbOpen.ButtonClick += FileOpen_Click;
                View.tbOpenLibrary.Click += FileOpen_Click;

                View.FileSave.Click += FileSave_Click;
                View.tbSaveLibrary.Click += FileSave_Click;
                View.FileSaveAs.Click += FileSaveAs_Click;
                View.tbSave.ButtonClick += FileSaveAs_Click;
                View.tbSaveAs.Click += FileSaveAs_Click;

                View.FileClose.Click += FileClose_Click;
                View.FileExit.Click += FileExit_Click;

                View.EditCut.Click += EditCut_Click;
                View.tbCut.Click += EditCut_Click;
                View.TablePopupCut.Click += EditCut_Click;
                View.EditCopy.Click += EditCopy_Click;
                View.tbCopy.Click += EditCopy_Click;
                View.TablePopupCopy.Click += EditCopy_Click;
                View.EditPaste.Click += EditPaste_Click;
                View.tbPaste.Click += EditPaste_Click;
                View.TablePopupPaste.Click += EditPaste_Click;
                View.EditDelete.Click += EditDelete_Click;
                View.tbDelete.Click += EditDelete_Click;
                View.TablePopupDelete.Click += EditDelete_Click;

                View.EditSelectAll.Click += EditSelectAll_Click;
                View.EditInvertSelection.Click += EditInvertSelection_Click;

                View.ViewRefresh.Click += ViewRefresh_Click;

                View.WindowMenu.DropDownOpening += ViewWindow_DropDownOpening;

                View.AddMedia.Click += AddMedia_Click;
                View.tbAddMedia.Click += AddMedia_Click;
                View.AddFolder.Click += AddFolder_Click;
                View.tbAddFolder.Click += AddFolder_Click;
                View.tbAdd.ButtonClick += AddFolder_Click;
                View.tbAdd.DropDownOpening += TbAdd_DropDownOpening;

                View.tbAddRecentFolder.DropDown = View.AddRecentFolder.DropDown;

                View.HelpAbout.Click += HelpAbout_Click;

                View.TablePopupMenu.Opening += GridPopupMenu_Opening;
                View.TablePopupTags.Click += PopupTags_Click;
                View.TablePopupMoreActions.Click += GridPopupMoreOptions_Click;

                View.Shown += View_Shown;
                View.FormClosed += View_FormClosed;
                View.FormClosing += View_FormClosing;
            }
        }

        #endregion

        #region Fields

        public readonly Model Model;

        public readonly CommandProcessor CommandProcessor;
        public readonly FilterController FilterController;
        public readonly TableController LibraryGridController;
        public readonly MruMediaController MediaController;
        public readonly MruLibraryController MruLibraryController;
        public readonly PictureController PictureController;
        public readonly PlayerController PlayerController;
        public readonly PropertyGridController PropertyGridController;
        public readonly StatusController StatusController;

        #endregion

        #region Properties

        public string FilePath
        {
            get => MruLibraryController.FilePath;
            set => MruLibraryController.FilePath = value;
        }

        private Selection Selection => LibraryGridController.Selection;

        #endregion

        #region Methods

        public void EnablePaste(bool enable) =>
            View.EditPaste.Enabled = View.tbPaste.Enabled = View.TablePopupPaste.Enabled = enable;

        public void UpdateLocalUI()
        {
            // Window Caption
            View.Text = MruLibraryController.WindowCaption;
            // File Operations
            View.FileReopen.Enabled = View.tbReopen.Enabled =
                View.AddRecentLibrary.Enabled = View.tbAddRecentLibrary.Enabled =
                View.RecentLibraryPopupMenu.Items.Count > 0;
            var enabled = CommandProcessor.IsModified;
            View.FileSave.Enabled = View.tbSaveLibrary.Enabled = enabled;
            View.AddRecentFolder.Enabled = View.tbAddRecentFolder.Enabled =
                View.RecentFolderPopupMenu.Items.Count > 0;
            // Clipboard Menu Items
            View.EditCut.Enabled = View.tbCut.Enabled = View.TablePopupCut.Enabled =
                View.EditCopy.Enabled = View.tbCopy.Enabled = View.TablePopupCopy.Enabled =
                View.EditDelete.Enabled = View.tbDelete.Enabled = View.TablePopupDelete.Enabled =
                Selection.Tracks.Any();
            // Property Grid
            PropertyGridController.SetSelection(LibraryGridController.Selection);
        }

        public void TracksAdd(Selection selection)
        {
            if (View.InvokeRequired)
                View.Invoke(new Action<Selection>(TracksAdd), selection);
            else
                CommandProcessor.Run(new TracksAddCommand(selection), spoof: false);
        }

        public void TracksEdit(Selection selection, Tag tag, List<object> values)
        {
            if (View.InvokeRequired)
                View.Invoke(new Action<Selection, Tag, List<object>>(TracksEdit), tag, selection, values);
            else
                CommandProcessor.Run(new TracksEditCommand(selection, tag, values), spoof: true);
        }

        public void TracksRemove(Selection selection)
        {
            if (View.InvokeRequired)
                View.Invoke(new Action<Selection>(TracksRemove), selection);
            else
                CommandProcessor.Run(new TracksRemoveCommand(selection), spoof: false);
        }

        #endregion

        #region Main Menu

        #region File

        private void Menu_DropDownOpening(object sender, EventArgs e) => UpdateUI();

        private void FileNewLibrary_Click(object sender, EventArgs e)
        {
            var filePath = FilePath;
            if (MruLibraryController.Clear())
                FilePath = filePath.IsValidFilePath() ? AppController.GetTempFileName() : filePath;
        }

        private void FileNewWindow_Click(object sender, EventArgs e) => AppController.NewWindow();
        private void FileOpen_Click(object sender, EventArgs e) => MruLibraryController.Open();
        private void FileReopen_DropDownOpening(object sender, EventArgs e) => MruLibraryController.ResetLibrary = true;
        private void FileSave_Click(object sender, EventArgs e) => MruLibraryController.Save();
        private void FileSaveAs_Click(object sender, EventArgs e) => MruLibraryController.SaveAs();
        private void FileClose_Click(object sender, EventArgs e) => View.Close();
        private void FileExit_Click(object sender, EventArgs e) => AppController.Shutdown();

        #endregion

        #region Edit

        private void EditCut_Click(object sender, EventArgs e) => Cut();
        private void EditCopy_Click(object sender, EventArgs e) => Copy();
        private void EditPaste_Click(object sender, EventArgs e) => Paste();
        private void EditDelete_Click(object sender, EventArgs e) => Delete();
        private void EditSelectAll_Click(object sender, EventArgs e) => LibraryGridController.SelectAll();
        private void EditInvertSelection_Click(object sender, EventArgs e) => LibraryGridController.InvertSelection();

        #endregion

        #region View

        private void ViewWindow_DropDownOpening(object sender, EventArgs e) => AppController.PopulateWindowMenu(View.WindowMenu);
        private void ViewRefresh_Click(object sender, EventArgs e) { }

        #endregion

        #region Add

        private void AddMedia_Click(object sender, EventArgs e) => MediaController.AddFiles();
        private void AddFolder_Click(object sender, EventArgs e) => MediaController.AddFolder();
        private void AddRecentLibrary_DropDownOpening(object sender, EventArgs e) => MruLibraryController.ResetLibrary = false;
        private void TbAdd_DropDownOpening(object sender, EventArgs e) => View.tbAddRecentFolder.Enabled = View.AddRecentFolder.Enabled;

        #endregion

        #region Help

        private void HelpAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(View,
                $"{Application.CompanyName}{Environment.NewLine}{Application.ProductName}{Environment.NewLine}Version {Application.ProductVersion}",
                string.Concat("About ", Application.ProductName));
        }

        #endregion

        #endregion

        #region Popup Menus

        private void GridPopupMenu_Opening(object sender, CancelEventArgs e) => View.TablePopupMoreActions.Enabled = LibraryGridController.Selection.SelectedFoldersCount == 1;
        private void GridPopupMoreOptions_Click(object sender, EventArgs e) => LibraryGridController.PopupShellContextMenu();
        private void PopupTags_Click(object sender, EventArgs e) => LibraryGridController.EditTagVisibility();

        #endregion

        #region Event Handlers

        private void LibraryGridController_SelectionChanged(object sender, EventArgs e) => UpdateUI();
        private void Model_ModifiedChanged(object sender, EventArgs e) => ModifiedChanged();
        private void Model_TracksAdd(object sender, SelectionEventArgs e) => TracksAdd(e.Selection);
        private void Model_TracksEdit(object sender, SelectionEditEventArgs e) => TracksEdit(e.Selection, e.Tag, e.Values);
        private void PersistenceController_FileSaving(object sender, CancelEventArgs e) => e.Cancel = !ContinueSaving();
        private void View_FormClosed(object sender, FormClosedEventArgs e) => AppController.CloseWindow(this);

        private void View_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !MruLibraryController.SaveIfModified();
            if (!e.Cancel)
                FilterController.RegistryWrite();
        }

        private void View_Shown(object sender, EventArgs e) => View.ActiveControl = View.FilterComboBox;

        #endregion

        #region Private Methods

        private bool ContinueSaving()
        {
            var tracks = Model.Tracks.Where(t => (t.FileStatus & FileStatus.Changed) != 0).ToList();
            if (!tracks.Any())
                return true;
            var message = new StringBuilder();
            Say(message, tracks, FileStatus.Changed, Resources.TracksChanged);
            Say(message, tracks, FileStatus.New, Resources.TracksAdded);
            Say(message, tracks, FileStatus.Updated, Resources.TracksUpdated);
            Say(message, tracks, FileStatus.Pending, Resources.TracksPending);
            Say(message, tracks, FileStatus.Deleted, Resources.TracksDeleted);
            message.Append(Resources.ConfirmSync);
            var decision = MessageBox.Show(
                View,
                message.ToString(),
                Resources.ConfirmSyncCaption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
            if (decision)
                foreach (var track in tracks)
                    ProcessTrack(track);
            return decision;
        }

        private void Copy() => CopyToClipboard();

        private void CopyToClipboard()
        {
            using (var stream = new MemoryStream())
            {
                Streamer.SaveToStream(stream, Selection.Tracks, StreamFormat.Xml);
                stream.Seek(0, SeekOrigin.Begin);
                using (var streamReader = new StreamReader(stream))
                {
                    var text = streamReader.ReadToEnd();
                    Clipboard.SetText(text);
                }
                stream.Close();
            }
        }

        private void Cut() { Copy(); Delete(); }

        private void Delete() => TracksRemove(Selection);

        private void ModifiedChanged() => UpdateUI();

        private void Paste() => PasteFromClipboard();

        private void PasteFromClipboard()
        {
            if (!Clipboard.ContainsText())
                return;
            var text = Clipboard.GetText();
            var tempFileName = Path.GetTempFileName();
            using (var stream = new FileStream(tempFileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(text);
                    writer.Flush();
                }
                stream.Close();
            }
            using (var stream = new FileStream(tempFileName, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    var value = Streamer.LoadFromStream(stream, typeof(List<Track>), StreamFormat.Xml);
                    if (value is List<Track> tracks)
                        TracksAdd(new Selection(tracks));
                }
                catch (Exception exception)
                {
                    exception.ShowDialog(View);
                }
                finally
                {
                    stream.Close();
                    File.Delete(tempFileName);
                }
            }
        }

        private void PersistenceController_FilePathChanged(object sender, EventArgs e) => UpdateUI();

        private bool ProcessTrack(Track track)
        {
            var result = false;
            try
            {
                result = Model.ProcessTrack(track);
            }
            catch (IOException ex)
            {
                MessageBox.Show(View, ex.Message, "Error streaming media", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        private void Say(StringBuilder message, List<Track> tracks, FileStatus status, string format)
        {
            var count = tracks.Count(t => (t.FileStatus & status) != 0);
            if (count > 0)
                message.AppendFormat(format, count);
        }

        private void UpdateUI() => AppController.UpdateUI(this);

        #endregion
    }
}
