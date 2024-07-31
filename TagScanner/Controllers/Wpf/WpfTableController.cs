namespace TagScanner.Controllers.Wpf
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Forms.Integration;
    using Commands;
    using Forms;
    using Menus;
    using Models;
    using Terms;

    public class WpfTableController : WpfGridController
    {
        #region Constructor

        public WpfTableController(Controller parent, ElementHost view) : base(parent)
        {
            _updater = new UpdateController(OnSelectionChanged);
            MainModel.TracksChanged += Model_TracksChanged;
            View = view;
        }

        #endregion

        #region Public Properties

        public override DataGrid DataGrid => ((GridElement)View.Child).DataGrid;

        public ListCollectionView ListCollectionView
        {
            get => (ListCollectionView)DataGrid.ItemsSource;
            set => DataGrid.ItemsSource = value;
        }

        public Selection Selection
        {
            get => _selection ?? (_selection = GetSelection());
            set
            {
                _updater.Pause();
                DataGrid.SelectedItems.Clear();
                value.Tracks.ForEach(p => DataGrid.SelectedItems.Add(p));
                _updater.Resume();
            }
        }

        public int TracksCountAll => MainModel.Tracks.Count;
        public int TracksCountVisible => ListCollectionView.Count;

        #endregion

        #region Public Events

        public event EventHandler SelectionChanged;

        #endregion

        #region Public Methods

        public void ClearFilter() => ListCollectionView.Filter = null;
        public void SetFilter(Term term) => ListCollectionView.Filter = p => term.Predicate((Track)p);

        public void InvertSelection()
        {
            var allItems = DataGrid.Items;
            var selectedItems = DataGrid.SelectedItems;
            var total = allItems.Count;
            var selection = selectedItems.Cast<object>().ToList();
            var oldCount = selection.Count;
            var newCount = total - oldCount;
            _updater.Pause();
            if (newCount < oldCount)
            {
                selection = allItems.Cast<object>().Except(selection).ToList();
                selectedItems.Clear();
                selection.ForEach(p => selectedItems.Add(p));
            }
            else
            {
                DataGrid.SelectAll();
                selection.ForEach(p => selectedItems.Remove(p));
            }
            _updater.Resume();
        }

        public void PopupShellContextMenu()
        {
            var menu = new ShellContextMenu();
            menu.ShowContextMenu(GetSelectedFileInfos(), System.Windows.Forms.Cursor.Position);
        }

        public void SelectAll()
        {
            _updater.Pause();
            DataGrid.SelectAll();
            _updater.Resume();
        }

        #endregion

        #region Protected Methods

        protected virtual void OnSelectionChanged()
        {
            if (UpdatingSelectionCount != 0) return;
            InvalidateSelection();
            SelectionChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Private Fields

        private Selection _selection;
        private UpdateController _updater;
        private ElementHost _view;

        #endregion

        #region Private Properties

        private int UpdatingSelectionCount { get; set; }

        private ElementHost View
        {
            get => _view;
            set
            {
                _view = value;

                MainForm.TablePopupMenu.Opening += GridPopupMenu_Opening;
                MainForm.TablePopupSelectColumns.Click += PopupSelectColumns_Click;
                MainForm.TablePopupMoreActions.Click += GridPopupMoreOptions_Click;

                MainForm.ViewMenu.DropDownOpening += GroupByMenu_DropDownOpening;
                MainForm.ViewArtistAlbum.Click += ViewArtistAlbum_Click;
                MainForm.ViewArtist.Click += ViewArtist_Click;
                MainForm.ViewAlbum.Click += ViewAlbum_Click;
                MainForm.ViewYear.Click += ViewYear_Click;
                MainForm.ViewGenre.Click += ViewGenre_Click;
                MainForm.ViewTitle.Click += ViewTitle_Click;
                MainForm.ViewCustom.Click += PopupSelectColumns_Click;

                View.Child = new GridElement();
                CreateColumns();
                DataGrid.CellEditEnding += Grid_CellEditEnding;
                DataGrid.SelectionChanged += Grid_SelectionChanged;
                RefreshDataSource();
                Query = Query.ByTitle;
            }
        }

        #endregion

        #region Event Handlers

        private void GridPopupMoreOptions_Click(object sender, EventArgs e) => PopupShellContextMenu();
        private void Grid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e) => CellEdit(e);
        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e) => OnSelectionChanged();
        private void Model_TracksChanged(object sender, EventArgs e) => RefreshDataSource();
        private void PopupSelectColumns_Click(object sender, EventArgs e) => EditTagVisibility("Media");
        private void ViewArtistAlbum_Click(object sender, EventArgs e) => Query = Query.ByArtistAlbum;
        private void ViewArtist_Click(object sender, EventArgs e) => Query = Query.ByArtist;
        private void ViewAlbum_Click(object sender, EventArgs e) => Query = Query.ByAlbum;
        private void ViewYear_Click(object sender, EventArgs e) => Query = Query.ByYear;
        private void ViewGenre_Click(object sender, EventArgs e) => Query = Query.ByGenre;
        private void ViewTitle_Click(object sender, EventArgs e) => Query = Query.ByTitle;

        private void GridPopupMenu_Opening(object sender, CancelEventArgs e) =>
            MainForm.TablePopupMoreActions.Enabled = Selection.SelectedFoldersCount == 1;

        private void GroupByMenu_DropDownOpening(object sender, EventArgs e)
        {
            MainForm.ViewCustom.Checked = !(
                (MainForm.ViewArtistAlbum.Checked = QueryMatches(Query.ByArtistAlbum)) |
                (MainForm.ViewArtist.Checked = QueryMatches(Query.ByArtist)) |
                (MainForm.ViewAlbum.Checked = QueryMatches(Query.ByAlbum)) |
                (MainForm.ViewYear.Checked = QueryMatches(Query.ByYear)) |
                (MainForm.ViewGenre.Checked = QueryMatches(Query.ByGenre)) |
                (MainForm.ViewTitle.Checked = QueryMatches(Query.ByTitle)));
        }

        private void Selection_TracksEdit(object sender, SelectionEditEventArgs e) =>
            MainFormController.TracksEdit(e.Selection, e.Tag, e.Values);

        #endregion

        #region Private Methods

        private void CellEdit(DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Cancel)
                e.Cancel = true;
            if (e.Cancel)
                return;
            var track = e.Row.DataContext as Track;
            var tag = ((TagInfo)e.Column.Header).Tag;
            var text = ((TextBox)e.EditingElement).Text;
            Run(new EditCommand(track, tag, new List<object> { text }));
        }


        private FileInfo[] GetSelectedFileInfos() => Selection.Tracks.Select(p => new FileInfo(p.FilePath)).ToArray();

        private Selection GetSelection()
        {
            var selection = new Selection(DataGrid.SelectedItems.OfType<Track>());
            selection.TracksEdit += Selection_TracksEdit;
            return selection;
        }

        private void InvalidateSelection() => _selection = null;

        private bool QueryMatches(Query query) => Groups.SequenceEqual(query.Groups);

        private void RefreshDataSource()
        {
            if (View.InvokeRequired)
                View.Invoke(new Action(RefreshDataSource));
            else
            {
                ListCollectionView = new ListCollectionView(MainModel.Tracks);
                InitSortsAndGroups();
            }
        }

        #endregion
    }
}
