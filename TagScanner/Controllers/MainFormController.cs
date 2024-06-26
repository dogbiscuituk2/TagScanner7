namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Commands;
    using Forms;
    using Models;
    using Mru;
    using Properties;
    using Streaming;
    using Terms;
    using Utils;
    using Wpf;

    public class MainFormController : Controller
    {
        #region Constructor

        public MainFormController() : base(null)
        {
            View = new MainForm();
            Model = new Model();
            Model.TracksAdd += Model_TracksAdd;
            Model.TracksChanged += Model_TracksChanged;
            Model.TracksEdit += Model_TracksEdit;
            CommandProcessor = new CommandProcessor(this);
            FilterController = new FilterController(this);
            TableController = new WpfTableController(this, View.GridElementHost);
            TableController.SelectionChanged += LibraryGridController_SelectionChanged;
            DragDropController = new DragDropController(this);
            MediaController = new MruMediaController(this, View.RecentFolderPopupMenu);
            LibraryController = new MruLibraryController(this, View.RecentLibraryPopupMenu);
            LibraryController.FilePathChanged += PersistenceController_FilePathChanged;
            LibraryController.FileSaving += PersistenceController_FileSaving;
            PlayerController = new WpfPlayerController(this);
            PictureController = new PictureController(View.PictureBox, View.PropertyGrid, PlayerController.PlaylistGrid);
            PropertyGridController = new PropertyGridController(this);
            StatusController = new StatusController(this);
            FindReplaceController = new FindReplaceController(this);
            AutoCompleter = new AutoCompleter(this, View.FindReplaceControl.cbFind, View.FindReplaceControl.cbReplace, View.FilterControl.cbFilter);
            FilterController.UpdateAutoComplete();
            ModifiedChanged();
            UpdateUI();
        }

        #endregion

        #region Public Fields

        public readonly AutoCompleter AutoCompleter;
        public readonly CommandProcessor CommandProcessor;
        public readonly DragDropController DragDropController;
        public readonly FilterController FilterController;
        public readonly FindReplaceController FindReplaceController;
        public readonly MruLibraryController LibraryController;
        public readonly MruMediaController MediaController;
        public readonly Model Model;
        public readonly PictureController PictureController;
        public readonly WpfPlayerController PlayerController;
        public readonly PropertyGridController PropertyGridController;
        public readonly StatusController StatusController;
        public readonly WpfTableController TableController;

        #endregion

        #region Public Properties

        public string FilePath
        {
            get => LibraryController.FilePath;
            set => LibraryController.FilePath = value;
        }

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

                View.WindowMenu.DropDownOpening += ViewWindow_DropDownOpening;

                View.AddMedia.Click += AddMedia_Click;
                View.tbAddMedia.Click += AddMedia_Click;
                View.AddFolder.Click += AddFolder_Click;
                View.tbAddFolder.Click += AddFolder_Click;
                View.AddLibrary.Click += AddLibrary_Click;
                View.tbAddLibrary.Click += AddLibrary_Click;
                View.tbAdd.ButtonClick += AddFolder_Click;
                View.tbAdd.DropDownOpening += TbAdd_DropDownOpening;
                View.tbAddRecentFolder.DropDown = View.AddRecentFolder.DropDown;

                View.HelpAbout.Click += HelpAbout_Click;

                View.FormClosed += View_FormClosed;
                View.FormClosing += View_FormClosing;
            }
        }

        #endregion

        #region Public Methods

        public void EnablePaste(bool enable) =>
            View.EditPaste.Enabled = View.tbPaste.Enabled = View.TablePopupPaste.Enabled = enable;

        public void TracksAdd(Selection selection)
        {
            if (View.InvokeRequired)
                View.Invoke(new Action<Selection>(TracksAdd), selection);
            else
                CommandProcessor.Run(new AddCommand(selection), spoof: false);
        }

        public void TracksChanged()
        {
            if (View.InvokeRequired)
                View.Invoke(new Action(TracksChanged));
            else
            {
                AutoCompleter.InvalidateFieldLists();
                FilterController.UpdateAutoComplete();
                FindReplaceController.UpdateAutoComplete();
            }
        }

        public void TracksEdit(Selection selection, Tag tag, List<object> values)
        {
            if (View.InvokeRequired)
                View.Invoke(new Action<Selection, Tag, List<object>>(TracksEdit), tag, selection, values);
            else
                CommandProcessor.Run(new EditCommand(selection, tag, values), spoof: true);
        }

        public void TracksRemove(Selection selection)
        {
            if (View.InvokeRequired)
                View.Invoke(new Action<Selection>(TracksRemove), selection);
            else
                CommandProcessor.Run(new RemoveCommand(selection), spoof: false);
        }

        public void UpdateLocalUI()
        {
            bool
                anyTracks = Selection.Tracks.Any(),
                canSave = CommandProcessor.IsModified,
                recentFolder = View.RecentFolderPopupMenu.Items.Count > 0,
                recentLibrary = View.RecentLibraryPopupMenu.Items.Count > 0;
            // Window Caption
            View.Text = LibraryController.WindowCaption;
            // File Operations
            View.FileReopen.Enabled = View.tbReopen.Enabled =
                View.AddRecentLibrary.Enabled = View.tbAddRecentLibrary.Enabled =
                recentLibrary;
            View.FileSave.Enabled = View.tbSaveLibrary.Enabled =
                canSave;
            View.AddRecentFolder.Enabled = View.tbAddRecentFolder.Enabled =
                recentFolder;
            // Edit & Play Items
            View.EditCut.Enabled = View.tbCut.Enabled = View.TablePopupCut.Enabled =
                View.EditCopy.Enabled = View.tbCopy.Enabled = View.TablePopupCopy.Enabled =
                View.EditDelete.Enabled = View.tbDelete.Enabled = View.TablePopupDelete.Enabled =
                View.TablePopupPlay.Enabled = View.TablePopupPlayAddToQueue.Enabled = View.TablePopupPlayNewPlaylist.Enabled =
                View.tbPlay.Enabled = View.tbAddToQueue.Enabled = View.tbNewPlaylist.Enabled =
                anyTracks;
            // Property Grid
            PropertyGridController.SetSelection(TableController.Selection);
        }

        #endregion

        #region Protected Properties

        protected override IWin32Window Owner => View;

        #endregion

        #region Private Fields

        private MainForm _view;

        #endregion

        #region Private Properties

        private Selection Selection => TableController.Selection;

        #endregion

        #region Event Handlers

        private void Menu_DropDownOpening(object sender, EventArgs e) => UpdateUI();

        private void FileNewLibrary_Click(object sender, EventArgs e) => NewLibrary();
        private void FileNewWindow_Click(object sender, EventArgs e) => AppController.NewWindow();
        private void FileOpen_Click(object sender, EventArgs e) => LibraryController.Open();
        private void FileReopen_DropDownOpening(object sender, EventArgs e) => LibraryController.Merging = false;
        private void FileSave_Click(object sender, EventArgs e) => LibraryController.Save();
        private void FileSaveAs_Click(object sender, EventArgs e) => LibraryController.SaveAs();
        private void FileClose_Click(object sender, EventArgs e) => View.Close();
        private void FileExit_Click(object sender, EventArgs e) => AppController.Shutdown();

        private void EditCut_Click(object sender, EventArgs e) => Cut();
        private void EditCopy_Click(object sender, EventArgs e) => Copy();
        private void EditPaste_Click(object sender, EventArgs e) => Paste();
        private void EditDelete_Click(object sender, EventArgs e) => Delete();
        private void EditSelectAll_Click(object sender, EventArgs e) => TableController.SelectAll();
        private void EditInvertSelection_Click(object sender, EventArgs e) => TableController.InvertSelection();

        private void ViewWindow_DropDownOpening(object sender, EventArgs e) => AppController.PopulateWindowMenu(View.WindowMenu);

        private void AddMedia_Click(object sender, EventArgs e) => MediaController.AddFiles();
        private void AddFolder_Click(object sender, EventArgs e) => MediaController.AddFolder();
        private void AddLibrary_Click(object sender, EventArgs e) => LibraryController.AddLibrary();
        private void AddRecentLibrary_DropDownOpening(object sender, EventArgs e) => LibraryController.Merging = true;
        private void TbAdd_DropDownOpening(object sender, EventArgs e) => View.tbAddRecentFolder.Enabled = View.AddRecentFolder.Enabled;

        private void HelpAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(View,
                $"{Application.CompanyName}{Environment.NewLine}{Application.ProductName}{Environment.NewLine}Version {Application.ProductVersion}",
                string.Concat("About ", Application.ProductName));
        }

        private void LibraryGridController_SelectionChanged(object sender, EventArgs e) => UpdateUI();
        private void Model_ModifiedChanged(object sender, EventArgs e) => ModifiedChanged();
        private void Model_TracksAdd(object sender, SelectionEventArgs e) => TracksAdd(e.Selection);
        private void Model_TracksChanged(object sender, EventArgs e) => TracksChanged();
        private void Model_TracksEdit(object sender, SelectionEditEventArgs e) => TracksEdit(e.Selection, e.Tag, e.Values);
        private void PersistenceController_FileSaving(object sender, CancelEventArgs e) => e.Cancel = !ContinueSaving();
        private void View_FormClosed(object sender, FormClosedEventArgs e) => AppController.CloseWindow(this);
        private void View_FormClosing(object sender, FormClosingEventArgs e) => e.Cancel = !LibraryController.SaveIfModified();

        #endregion

        #region Private Methods

        private bool ContinueSaving()
        {
            var tracks = Model.Tracks.Where(t => (t.Status & Status.Changed) != 0).ToList();
            if (!tracks.Any())
                return true;
            var message = new StringBuilder();
            Say(message, tracks, Status.Changed, Resources.TracksChanged);
            Say(message, tracks, Status.New, Resources.TracksAdded);
            Say(message, tracks, Status.Updated, Resources.TracksUpdated);
            Say(message, tracks, Status.Pending, Resources.TracksPending);
            Say(message, tracks, Status.Deleted, Resources.TracksDeleted);
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

        private void NewLibrary()
        {
            var filePath = FilePath;
            if (LibraryController.Clear())
                FilePath = filePath.IsValidFilePath() ? AppController.GetTempFileName() : filePath;
        }

        private void Paste() => PasteFromClipboard();

        private void PasteFileDropList()
        {
            StringCollection filePaths = Clipboard.GetFileDropList();
            MediaController.AddFiles(filePaths.OfType<string>().ToArray());
        }

        private void PasteXmlDocument()
        {
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

        private void PasteFromClipboard()
        {
            if (Clipboard.ContainsFileDropList())
                PasteFileDropList();
            else if (Clipboard.ContainsText())
                PasteXmlDocument();
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

        private static void Say(StringBuilder message, List<Track> tracks, Status status, string format)
        {
            var count = tracks.Count(t => (t.Status & status) != 0);
            if (count > 0)
                message.AppendFormat(format, count);
        }

        private void UpdateUI() => AppController.UpdateUI(this);

        #endregion
    }
}
