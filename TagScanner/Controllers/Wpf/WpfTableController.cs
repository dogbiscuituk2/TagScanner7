﻿namespace TagScanner.Controllers.Wpf
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Forms.Integration;
    using Forms;
    using Menus;
    using Models;
    using Terms;
    using ValueConverters;

    public class WpfTableController : WpfGridController
    {
        #region Constructor

        public WpfTableController(Controller parent, ElementHost view) : base(parent)
        {
            MainModel.TracksChanged += Model_TracksChanged;
            View = view;
        }

        #endregion

        #region Model

        private void Model_TracksChanged(object sender, EventArgs e) => RefreshDataSource();

        #endregion

        #region Views

        private ElementHost _view;
        private ElementHost View
        {
            get => _view;
            set
            {
                _view = value;
                MainForm.GroupByMenu.DropDownOpening += GroupByMenu_DropDownOpening;
                MainForm.GroupByArtistAlbum.Click += GroupByArtistAlbum_Click;
                MainForm.GroupByArtist.Click += GroupByArtist_Click;
                MainForm.GroupByAlbum.Click += GroupByAlbum_Click;
                MainForm.GroupByYear.Click += GroupByYear_Click;
                MainForm.GroupByGenre.Click += GroupByGenre_Click;
                MainForm.GroupByTitle.Click += GroupByTitle_Click;
                View.Child = new GridElement();
                InitColumns();
                DataGrid.SelectionChanged += Grid_SelectionChanged;
                RefreshDataSource();
                SetQuery(Query.ByTitle);
            }
        }

        public override DataGrid DataGrid => ((GridElement)View.Child).DataGrid;

        public ListCollectionView ListCollectionView
        {
            get => (ListCollectionView)DataGrid.ItemsSource;
            set => DataGrid.ItemsSource = value;
        }

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

        private void GroupByMenu_DropDownOpening(object sender, EventArgs e)
        {
            MainForm.GroupByArtistAlbum.Checked = QueryMatches(Query.ByArtistAlbum);
            MainForm.GroupByArtist.Checked = QueryMatches(Query.ByArtist);
            MainForm.GroupByAlbum.Checked = QueryMatches(Query.ByAlbum);
            MainForm.GroupByYear.Checked = QueryMatches(Query.ByYear);
            MainForm.GroupByGenre.Checked = QueryMatches(Query.ByGenre);
            MainForm.GroupByTitle.Checked = QueryMatches(Query.ByTitle);
        }

        private void GroupByArtistAlbum_Click(object sender, EventArgs e) => SetQuery(Query.ByArtistAlbum);
        private void GroupByArtist_Click(object sender, EventArgs e) => SetQuery(Query.ByArtist);
        private void GroupByAlbum_Click(object sender, EventArgs e) => SetQuery(Query.ByAlbum);
        private void GroupByYear_Click(object sender, EventArgs e) => SetQuery(Query.ByYear);
        private void GroupByGenre_Click(object sender, EventArgs e) => SetQuery(Query.ByGenre);
        private void GroupByTitle_Click(object sender, EventArgs e) => SetQuery(Query.ByTitle);

        #endregion

        #region Columns

        public void EditTagVisibility()
        {
            var visibleTags = VisibleTags.ToList();
            var ok = new TagsController(this).Execute("Select the Columns to display in the Media Table", visibleTags);
            if (ok)
                VisibleTags = VisibleTags.Intersect(visibleTags).Union(visibleTags).ToList();
        }

        protected override IValueConverter GetConverter(TagInfo tagInfo)
        {
            var result = base.GetConverter(tagInfo);
            if (result != null) return result;
            switch (tagInfo.Tag)
            {
                case Tag.FileSize:
                    return new FileSizeConverter();
            }
            return null;
        }

        private List<Tag> _visibleTags = new List<Tag>{ Tag.FilePath };
        public List<Tag> VisibleTags
        {
            get => _visibleTags;
            set
            {
                if (VisibleTags.SequenceEqual(value))
                    return;
                _visibleTags = value;
                InitVisibleTags();
            }
        }

        private void InitVisibleTags()
        {
            foreach (var column in DataGrid.Columns)
                column.Visibility = Visibility.Collapsed;
            var displayIndex = 0;
            foreach (var tag in VisibleTags)
            {
                var column = DataGrid.Columns.Single(c => ((TagInfo)c.Header).Name == tag.ToString());
                column.DisplayIndex = displayIndex++;
                column.Visibility = Visibility.Visible;
            }
        }

        #endregion

        #region Filtering

        public void ClearFilter() => ListCollectionView.Filter = null;
        public void SetFilter(Term term) => ListCollectionView.Filter = p => term.Predicate((Track)p);

        public int TracksCountAll => MainModel.Tracks.Count;
        public int TracksCountVisible => ListCollectionView.Count;

        #endregion

        #region Sorting and Grouping

        private IEnumerable<SortDescription> _sorts = new List<SortDescription>();
        public IEnumerable<SortDescription> Sorts
        {
            get => _sorts;
            set
            {
                if (Sorts.SequenceEqual(value)) return;
                _sorts = value;
                InitSortsAndGroups();
            }
        }

        private IEnumerable<Tag> _groups = new List<Tag>();
        public IEnumerable<Tag> Groups
        {
            get => _groups;
            set
            {
                if (Groups.SequenceEqual(value)) return;
                _groups = value;
                InitSortsAndGroups();
            }
        }

        private void InitGroups()
        {
            var groups = ListCollectionView.GroupDescriptions;
            if (groups == null) return;
            groups.Clear();
            foreach (var group in Groups)
                groups.Add(new PropertyGroupDescription($"{group}"));
        }

        private void InitSorts()
        {
            var sorts = ListCollectionView.SortDescriptions;
            if (sorts == null) return;
            sorts.Clear();
            foreach (var sort in Sorts)
                sorts.Add(sort);
        }

        private void InitSortsAndGroups()
        {
            InitSorts();
            InitGroups();
        }

        #endregion

        #region Selection

        private Selection _selection;
        public Selection Selection
        {
            get => _selection ?? (_selection = GetSelection());
            set
            {
                BeginUpdateSelection();
                DataGrid.SelectedItems.Clear();
                foreach (var track in value.Tracks)
                    DataGrid.SelectedItems.Add(track);
                EndUpdateSelection();
            }
        }

        public event EventHandler SelectionChanged;

        private int UpdatingSelectionCount { get; set; }

        private void InvalidateSelection() => _selection = null;

        private void BeginUpdateSelection() => UpdatingSelectionCount++;

        private void EndUpdateSelection()
        {
            UpdatingSelectionCount--;
            OnSelectionChanged();
        }

        public void InvertSelection()
        {
            var allItems = DataGrid.Items;
            var selectedItems = DataGrid.SelectedItems;
            var total = allItems.Count;
            var selection = selectedItems.Cast<object>().ToList();
            var oldCount = selection.Count;
            var newCount = total - oldCount;
            BeginUpdateSelection();
            if (newCount < oldCount)
            {
                selection = allItems.Cast<object>().Except(selection).ToList();
                selectedItems.Clear();
                foreach (var item in selection)
                    selectedItems.Add(item);
            }
            else
            {
                DataGrid.SelectAll();
                foreach (var item in selection)
                    selectedItems.Remove(item);
            }
            EndUpdateSelection();
        }

        protected virtual void OnSelectionChanged()
        {
            if (UpdatingSelectionCount != 0) return;
            InvalidateSelection();
            SelectionChanged?.Invoke(this, EventArgs.Empty);
        }

        public void PopupShellContextMenu()
        {
            var menu = new ShellContextMenu();
            menu.ShowContextMenu(GetSelectedFileInfos(), System.Windows.Forms.Cursor.Position);
        }

        public void SelectAll()
        {
            BeginUpdateSelection();
            DataGrid.SelectAll();
            EndUpdateSelection();
        }

        private FileInfo[] GetSelectedFileInfos() => Selection.Tracks.Select(p => new FileInfo(p.FilePath)).ToArray();

        private Selection GetSelection()
        {
            var selection = new Selection(DataGrid.SelectedItems.OfType<Track>());
            selection.TracksEdit += Selection_TracksEdit;
            return selection;
        }

        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e) => OnSelectionChanged();

        private void Selection_TracksEdit(object sender, SelectionEditEventArgs e) =>
            MainFormController.TracksEdit(e.Selection, e.Tag, e.Values);

        #endregion

        #region Find / Replace

        private Selection _findResults;
        public Selection FindResults
        {
            get => _selection;
            set => _selection = value;
        }

        #endregion

        #region Presets

        private void SetQuery(Query query)
        {
            VisibleTags = query.Tags.Union(VisibleTags).ToList();
            _groups = query.Groups;
            _sorts = _groups.Union(query.Sorts).Select(p => new SortDescription($"{p}", ListSortDirection.Ascending));
            InitSortsAndGroups();
        }

        #endregion
    }
}
