namespace TagScanner.Controllers
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

    public class LibraryFormController : Controller
    {
        #region Constructor

        public LibraryFormController() : base(null)
        {
            View = new LibraryForm();
            Model = new Model();
            Model.WorksAdd += Model_WorksAdd;
            Model.WorksEdit += Model_WorksEdit;
            CommandProcessor = new CommandProcessor(this);
            LibraryGridController = new LibraryGridController(this, Model, View.GridElementHost);
            LibraryGridController.SelectionChanged += LibraryGridController_SelectionChanged;
            StatusController = new StatusController(this);
            PersistenceController = new MruLibraryController(this, View.RecentLibraryPopupMenu, View);
            PersistenceController.FilePathChanged += PersistenceController_FilePathChanged;
            PersistenceController.FileSaving += PersistenceController_FileSaving;
            MediaController = new MruMediaController(this, View.RecentFolderPopupMenu);
            PlayerController = new PlayerController(this, null);
            FilterController = new FilterController(this);
            PictureController = new PictureController(View.PictureBox, View.PropertyGrid, PlayerController.PlaylistGrid);
            ModifiedChanged();
            UpdatePropertyGrid();
        }

        #endregion

        protected override IWin32Window Owner => View;

        #region View

        private LibraryForm _view;
        public LibraryForm View
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
                View.EditCopy.Click += EditCopy_Click;
                View.tbCopy.Click += EditCopy_Click;
                View.EditPaste.Click += EditPaste_Click;
                View.tbPaste.Click += EditPaste_Click;
                View.EditDelete.Click += EditDelete_Click;
                View.tbDelete.Click += EditDelete_Click;

                View.EditSelectAll.Click += EditSelectAll_Click;
                View.EditInvertSelection.Click += EditInvertSelection_Click;

                View.ViewRefresh.Click += ViewRefresh_Click;

                View.WindowMenu.DropDownOpening += ViewWindow_DropDownOpening;

                View.AddMedia.Click += AddMedia_Click;
                View.tbAddMedia.Click += AddMedia_Click;
                View.AddFolder.Click += AddFolder_Click;
                View.tbAddFolder.Click += AddFolder_Click;
                View.tbAdd.ButtonClick += AddFolder_Click;
                View.AddLibrary.Click += AddLibrary_Click;
                View.tbAddLibrary.Click += AddLibrary_Click;
                View.tbAdd.DropDownOpening += TbAdd_DropDownOpening;

                View.tbAddRecentFolder.DropDown = View.AddRecentFolder.DropDown;

                View.HelpAbout.Click += HelpAbout_Click;

                View.GridPopupMenu.Opening += GridPopupMenu_Opening;
                View.GridPopupTags.Click += PopupTags_Click;
                View.GridPopupMoreActions.Click += GridPopupMoreOptions_Click;
                View.PropertyGridPopupTagVisibility.Click += PropertyGridPopupTagVisibility_Click;

                View.Shown += View_Shown;
                View.FormClosed += View_FormClosed;
                View.FormClosing += View_FormClosing;
            }
        }

        #endregion

        #region Fields

        public readonly Model Model;
        public readonly CommandProcessor CommandProcessor;
        public readonly LibraryGridController LibraryGridController;
        public readonly MruMediaController MediaController;
        public readonly MruLibraryController PersistenceController;
        public readonly PictureController PictureController;
        public readonly PlayerController PlayerController;
        public readonly FilterController FilterController;
        public readonly StatusController StatusController;

        #endregion

        #region Properties

        public string FilePath
        {
            get => PersistenceController.FilePath;
            set => PersistenceController.FilePath = value;
        }

        private Selection Selection => LibraryGridController.Selection;

        #endregion

        #region Methods

        public void WorksAdd(List<Work> works)
        {
            if (View.InvokeRequired)
                View.Invoke(new Action<List<Work>>(WorksAdd), works);
            else
                CommandProcessor.Run(new WorksAddCommand(works), spoof: false);
        }

        public void WorksEdit(Tag tag, List<Work> works, List<object> values)
        {
            if (View.InvokeRequired)
                View.Invoke(new Action<Tag, List<Work>, List<object>>(WorksEdit), tag, works, values);
            else
                CommandProcessor.Run(new WorksEditCommand(tag, works, values), spoof: true);
        }

        public void WorksRemove(List<Work> works)
        {
            if (View.InvokeRequired)
                View.Invoke(new Action<List<Work>>(WorksRemove), works);
            else
                CommandProcessor.Run(new WorksRemoveCommand(works), spoof: false);
        }

        #endregion

        #region Main Menu

        #region File

        private void Menu_DropDownOpening(object sender, EventArgs e) => UpdateMenus();

        private void FileNewLibrary_Click(object sender, EventArgs e)
        {
            var filePath = FilePath;
            if (PersistenceController.Clear())
                FilePath = filePath.IsValidFilePath() ? AppController.GetTempFileName() : filePath;
        }

        private void FileNewWindow_Click(object sender, EventArgs e) => AppController.NewWindow();
        private void FileOpen_Click(object sender, EventArgs e) => PersistenceController.Open();
        private void FileSave_Click(object sender, EventArgs e) => PersistenceController.Save();
        private void FileSaveAs_Click(object sender, EventArgs e) => PersistenceController.SaveAs();
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
        private void ViewRefresh_Click(object sender, EventArgs e) => MediaController.Rescan();

        #endregion

        #region Add

        private void AddMedia_Click(object sender, EventArgs e) => MediaController.AddFiles();
        private void AddFolder_Click(object sender, EventArgs e) => MediaController.AddFolder();
        private void AddLibrary_Click(object sender, EventArgs e) => PersistenceController.AddLibrary();
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

        private void GridPopupMenu_Opening(object sender, CancelEventArgs e) => View.GridPopupMoreActions.Enabled = LibraryGridController.Selection.SelectedFoldersCount == 1;
        private void GridPopupMoreOptions_Click(object sender, EventArgs e) => LibraryGridController.PopupShellContextMenu();
        private void PopupTags_Click(object sender, EventArgs e) => LibraryGridController.EditTagVisibility();
        private void PropertyGridPopupTagVisibility_Click(object sender, EventArgs e) => SelectPropertyGridTags();

        #endregion

        #region Event Handlers

        private void LibraryGridController_SelectionChanged(object sender, EventArgs e) => UpdatePropertyGrid();
        private void Model_ModifiedChanged(object sender, EventArgs e) => ModifiedChanged();
        private void Model_WorksAdd(object sender, WorksEventArgs e) => WorksAdd(e.Works);
        private void Model_WorksEdit(object sender, WorksEditEventArgs e) => WorksEdit(e.Tag, e.Works, e.Values);
        private void PersistenceController_FileSaving(object sender, CancelEventArgs e) => e.Cancel = !ContinueSaving();
        private void View_FormClosed(object sender, FormClosedEventArgs e) => AppController.CloseWindow(this);

        private void View_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !PersistenceController.SaveIfModified();
            if (!e.Cancel)
                FilterController.RegistryWrite();
        }

        private void View_Shown(object sender, EventArgs e) => View.ActiveControl = View.FilterComboBox;

        #endregion

        #region Private Methods

        private bool ContinueSaving()
        {
            var works = Model.Works.Where(t => (t.FileStatus & FileStatus.Changed) != 0).ToList();
            if (!works.Any())
                return true;
            var message = new StringBuilder();
            Say(message, works, FileStatus.Changed, Resources.WorksChanged);
            Say(message, works, FileStatus.New, Resources.WorksAdded);
            Say(message, works, FileStatus.Updated, Resources.WorksUpdated);
            Say(message, works, FileStatus.Pending, Resources.WorksPending);
            Say(message, works, FileStatus.Deleted, Resources.WorksDeleted);
            message.Append(Resources.ConfirmSync);
            var decision = MessageBox.Show(
                View,
                message.ToString(),
                Resources.ConfirmSyncCaption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
            if (decision)
                foreach (var work in works)
                    ProcessWork(work);
            return decision;
        }

        private void Copy() => CopyToClipboard();

        private void CopyToClipboard()
        {
            using (var stream = new MemoryStream())
            {
                var data = Selection.Works.ToList();
                Streamer.SaveToStream(stream, data, StreamFormat.Xml);
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

        private void Delete() => WorksRemove(Selection.Works.ToList());

        private void ModifiedChanged() => View.Text = PersistenceController.WindowCaption;

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
                    var value = Streamer.LoadFromStream(stream, typeof(List<Work>), StreamFormat.Xml);
                    if (value is List<Work> works)
                        WorksAdd(works);
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

        private void PersistenceController_FilePathChanged(object sender, EventArgs e) => View.Text = PersistenceController.WindowCaption;

        private bool ProcessWork(Work work)
        {
            var result = false;
            try
            {
                result = Model.ProcessWork(work);
            }
            catch (IOException ex)
            {
                MessageBox.Show(View, ex.Message, "Error streaming media", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        private void Say(StringBuilder message, List<Work> works, FileStatus status, string format)
        {
            var count = works.Count(t => (t.FileStatus & status) != 0);
            if (count > 0)
                message.AppendFormat(format, count);
        }

        private void SelectPropertyGridTags()
        {
            var visibleTags = Tags.BrowsableTags;
            var ok = new TagsController(this).Execute("Select the Tags to display in the Details Panel", visibleTags);
            if (ok)
            {
                Tags.WriteBrowsableTags(visibleTags);
                UpdatePropertyGrid();
            }
        }

        private void UpdateMenus()
        {
            View.FileReopen.Enabled = View.tbReopen.Enabled =
                View.AddRecentLibrary.Enabled = View.tbAddRecentLibrary.Enabled =
                View.RecentLibraryPopupMenu.Items.Count > 0;
            var enabled = CommandProcessor.IsModified && FilePath.IsValidFilePath();
            View.FileSave.Enabled = View.tbSaveLibrary.Enabled = enabled;
            View.AddRecentFolder.Enabled = View.tbAddRecentFolder.Enabled =
                View.RecentFolderPopupMenu.Items.Count > 0;
            View.EditCut.Enabled = View.tbCut.Enabled =
                View.EditCopy.Enabled = View.tbCopy.Enabled =
                View.EditDelete.Enabled = View.tbDelete.Enabled = Selection.Works.Any();
        }

        private void UpdatePropertyGrid()
        {
            UpdateMenus();
            View.PropertyGrid.SelectedObject = LibraryGridController.Selection;
        }

        #endregion
    }
}
