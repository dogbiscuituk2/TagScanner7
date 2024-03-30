namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Models;
    using Mru;
    using Properties;
    using Terms;
    using Views;

    public class LibraryFormController : Controller
    {
        #region Lifetime Management

        public LibraryFormController(Controller parent) : base(parent)
        {
            View = new LibraryForm();
            Model = new Model();
            Model.ModifiedChanged += Model_ModifiedChanged;
            LibraryGridController = new LibraryGridController(this, Model, View.GridElementHost);
            LibraryGridController.SelectionChanged += LibraryGridController_SelectionChanged;
            StatusController = new StatusController(Model, View.StatusBar);
            PersistenceController = new MruLibraryController(Model, View.FileReopen);
            PersistenceController.FilePathChanged += PersistenceController_FilePathChanged;
            PersistenceController.FileSaving += PersistenceController_FileSaving;
            MediaController = new MruMediaController(this, View.AddRecentFolders);
            PlayerController = new PlayerController(this, null);
            FilterFormController = new FilterFormController(this);
            new PictureController(View.PictureBox, View.PropertyGrid, PlayerController.PlaylistGrid);
            ModifiedChanged();
            LibraryGridController.ViewByArtist();
            UpdatePropertyGrid();
        }

        #endregion

        #region View

        private LibraryForm _view;
        internal LibraryForm View
        {
            get => _view;
            set
            {
                _view = value;
                View.FileMenu.DropDownOpening += FileMenu_DropDownOpening;
                View.FileNew.Click += FileNew_Click;
                View.FileOpen.Click += FileOpen_Click;
                View.FileSave.Click += FileSave_Click;
                View.FileSaveAs.Click += FileSaveAs_Click;
                View.FileExit.Click += FileExit_Click;
                View.EditSelectAll.Click += EditSelectAll_Click;
                View.EditInvertSelection.Click += EditInvertSelection_Click;
                View.ViewFilter.Click += ViewFilter_Click;
                View.ViewByArtistAlbum.Click += ViewByArtistAlbum_Click;
                View.ViewByArtist.Click += ViewByArtist_Click;
                View.ViewByGenre.Click += ViewByGenre_Click;
                View.ViewByYear.Click += ViewByYear_Click;
                View.ViewByAlbum.Click += ViewByAlbum_Click;
                View.ViewByNoGrouping.Click += ViewByNone_Click;
                View.ViewRefresh.Click += ViewRefresh_Click;
                View.AddMedia.Click += AddMedia_Click;
                View.AddFolder.Click += AddFolder_Click;
                View.HelpAbout.Click += HelpAbout_Click;
                View.GridPopupTags.Click += PopupTags_Click;
                View.PropertyGridPopupTagVisibility.Click += PropertyGridPopupTagVisibility_Click;
                View.FormClosing += FormClosing;
            }
        }

        internal override Form Form => View;

        #endregion

        #region Fields

        internal readonly Model Model;
        internal readonly LibraryGridController LibraryGridController;
        internal readonly MruMediaController MediaController;
        internal readonly MruLibraryController PersistenceController;
        internal readonly PlayerController PlayerController;
        internal readonly FilterFormController FilterFormController;
        internal readonly StatusController StatusController;

        #endregion

        #region Main Menu

        #region File

        private void FileMenu_DropDownOpening(object sender, EventArgs e) => View.FileSave.Enabled = Model.Modified;
        private void FileNew_Click(object sender, EventArgs e) => PersistenceController.Clear();
        private void FileOpen_Click(object sender, EventArgs e) => PersistenceController.Open();
        private void FileSave_Click(object sender, EventArgs e) => PersistenceController.Save();
        private void FileSaveAs_Click(object sender, EventArgs e) => PersistenceController.SaveAs();
        private void FileExit_Click(object sender, EventArgs e) => View.Close();

        #endregion

        #region Edit

        private void EditSelectAll_Click(object sender, EventArgs e) => LibraryGridController.SelectAll();
        private void EditInvertSelection_Click(object sender, EventArgs e) => LibraryGridController.InvertSelection();
        private void ViewFilter_Click(object sender, EventArgs e) => FilterFormController.Execute();

        #endregion

        #region View

        private void ViewByArtistAlbum_Click(object sender, EventArgs e) => LibraryGridController.ViewByArtistAlbum();
        private void ViewByArtist_Click(object sender, EventArgs e) => LibraryGridController.ViewByArtist();
        private void ViewByAlbum_Click(object sender, EventArgs e) => LibraryGridController.ViewByAlbum();
        private void ViewByNone_Click(object sender, EventArgs e) => LibraryGridController.ViewByNone();
        private void ViewByGenre_Click(object sender, EventArgs e) => LibraryGridController.ViewByGenre();
        private void ViewByYear_Click(object sender, EventArgs e) => LibraryGridController.ViewByYear();
        private void ViewRefresh_Click(object sender, EventArgs e) => MediaController.Rescan();

        #endregion

        #region Add

        private void AddMedia_Click(object sender, EventArgs e) => MediaController.AddFiles();
        private void AddFolder_Click(object sender, EventArgs e) => MediaController.AddFolder();

        #endregion

        #region Help

        private void HelpAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                $"{Application.CompanyName}\n{Application.ProductName}\nVersion {Application.ProductVersion}",
                string.Concat("About ", Application.ProductName));
        }

        #endregion

        #endregion

        #region Popup Menus

        private void PopupTags_Click(object sender, EventArgs e) => LibraryGridController.EditTagVisibility();
        private void PropertyGridPopupTagVisibility_Click(object sender, EventArgs e) => SelectPropertyGridTags();

        #endregion

        #region Event Handlers

        private void FormClosing(object sender, FormClosingEventArgs e) => e.Cancel = !PersistenceController.SaveIfModified();
        private void LibraryGridController_SelectionChanged(object sender, EventArgs e) => UpdatePropertyGrid();
        private void Model_ModifiedChanged(object sender, EventArgs e) => ModifiedChanged();

        private void PersistenceController_FileSaving(object sender, CancelEventArgs e) => e.Cancel = !ContinueSaving();

        private void ModifiedChanged() => View.Text = PersistenceController.WindowCaption;

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
                message.ToString(),
                Resources.ConfirmSyncCaption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
            if (decision)
                foreach (var work in works)
                    ProcessWork(work);
            return decision;
        }

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

        private void PersistenceController_FilePathChanged(object sender, EventArgs e) => View.Text = PersistenceController.WindowCaption;

        #endregion

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

        private void UpdatePropertyGrid() => View.PropertyGrid.SelectedObject = LibraryGridController.Selection;
    }
}
