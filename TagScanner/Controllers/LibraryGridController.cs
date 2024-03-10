namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Forms.Integration;
    using TagScanner.Models;
    using TagScanner.ValueConverters;
    using TagScanner.Views;

    public class LibraryGridController : GridController
    {
        #region Constructor

        public LibraryGridController(LibraryFormController parent, Model model, ElementHost view) : base(parent)
        {
            Model = model;
            View = view;
        }

        #endregion

        #region Model

        private Model _model;
        public Model Model
        {
            get => _model;
            set
            {
                _model = value;
                Model.WorksChanged += Model_WorksChanged;
            }
        }

        private void Model_WorksChanged(object sender, EventArgs e) => RefreshDataSource();

        #endregion

        #region View

        private ElementHost _view;
        private ElementHost View
        {
            get => _view;
            set
            {
                _view = value;
                View.Child = new GridElement();
                InitColumns();
                DataGrid.SelectionChanged += Grid_SelectionChanged;
                RefreshDataSource();
            }
        }

        public override DataGrid DataGrid { get { return ((GridElement)View.Child).DataGrid; } }

        private ListCollectionView ListCollectionView
        {
            get => (ListCollectionView)DataGrid.ItemsSource;
            set => DataGrid.ItemsSource = value;
        }

        private void RefreshDataSource()
        {
            if (View.InvokeRequired)
                View.Invoke(new Action(RefreshDataSource));
            else
            {
                ListCollectionView = new ListCollectionView(Model.Works);
                InitGroups();
            }
        }

        #endregion

        #region Columns

        public void EditTagVisibility()
        {
            var gridVisibleTags = VisibleTagNames.ToList();
            var ok = new TagsController(this).Execute("Select the Columns to display in the Media Table", gridVisibleTags);
            if (ok)
                VisibleTagNames = VisibleTagNames.Intersect(gridVisibleTags).Union(gridVisibleTags);
        }

        protected override IValueConverter GetConverter(TagProps tagProps)
        {
            var result = base.GetConverter(tagProps);
            if (result == null)
                switch (tagProps.Name)
                {
                    case Tags.FileSize:
                        return new FileSizeConverter();
                }
            return result;
        }

        protected override IEnumerable<TagProps> GetTagProps() => Tags.AllTags;

        private IEnumerable<string> _visibleTagNames = new[] { Tags.FilePath };
        public IEnumerable<string> VisibleTagNames
        {
            get => _visibleTagNames;
            set
            {
                if (VisibleTagNames.SequenceEqual(value))
                    return;
                _visibleTagNames = value;
                InitVisibleTags();
            }
        }

        private void InitVisibleTags()
        {
            foreach (var column in DataGrid.Columns)
                column.Visibility = Visibility.Collapsed;
            var displayIndex = 0;
            foreach (var name in VisibleTagNames)
            {
                var column = DataGrid.Columns.Single(c => ((TagProps)c.Header).Name == name);
                column.DisplayIndex = displayIndex++;
                column.Visibility = Visibility.Visible;
            }
        }

        #endregion

        #region Sorting and Grouping

        private IEnumerable<SortDescription> _sortDescriptions = new SortDescription[0];
        public IEnumerable<SortDescription> SortDescriptions
        {
            get => _sortDescriptions;
            set
            {
                if (!SortDescriptions.SequenceEqual(value))
                {
                    _sortDescriptions = value;
                    InitGroups();
                }
            }
        }

        private IEnumerable<string> _groupDescriptions = new string[0];
        public IEnumerable<string> GroupDescriptions
        {
            get => _groupDescriptions;
            set
            {
                if (!GroupDescriptions.SequenceEqual(value))
                {
                    _groupDescriptions = value;
                    InitGroups();
                }
            }
        }

        private void InitGroups()
        {
            //var sortDescriptions = ListCollectionView.SortDescriptions;
            //sortDescriptions.Clear();
            //foreach (var sortDescription in SortDescriptions)
            //	sortDescriptions.Add(sortDescription);
            var groupDescriptions = ListCollectionView.GroupDescriptions;
            groupDescriptions.Clear();
            foreach (var groupDescription in GroupDescriptions)
                groupDescriptions.Add(new PropertyGroupDescription(groupDescription));
        }

        #endregion

        #region Selection

        private Selection _selection;
        public Selection Selection => _selection ?? (_selection = GetSelection());

        public event EventHandler SelectionChanged;

        private int UpdatingSelectionCount { get; set; }

        private void InvalidateSelection() => _selection = null;

        private void BeginUpdateSelection() => UpdatingSelectionCount++;

        private void EndUpdateSelection()
        {
            UpdatingSelectionCount--;
            OnSelectionChanged();
        }

        protected virtual void OnSelectionChanged()
        {
            if (UpdatingSelectionCount == 0)
            {
                InvalidateSelection();
                SelectionChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public void SelectAll()
        {
            BeginUpdateSelection();
            DataGrid.SelectAll();
            EndUpdateSelection();
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

        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e) => OnSelectionChanged();

        private Selection GetSelection() => new Selection(DataGrid.SelectedItems.Cast<Work>());

        #endregion

        #region Presets

        private static readonly IEnumerable<string>
            VisibleTagsDefault = new[] { Tags.DiscTrack, Tags.Title, Tags.Duration, Tags.FileSize },
            VisibleTagsExtended = VisibleTagsDefault.Union(new[] { Tags.JoinedPerformers, Tags.Album });

        public void ViewByAlbum() => SetQuery(VisibleTagsDefault, new[] { Tags.Album }, new[] { Tags.DiscNumber, Tags.TrackNumber });
        public void ViewByArtist() => SetQuery(new[] { Tags.YearAlbum, Tags.DiscTrack, Tags.Title, Tags.Duration, Tags.FileSize }, new[] { Tags.JoinedPerformers }, new[] { Tags.DiscNumber, Tags.TrackNumber });
        public void ViewByArtistAlbum() => SetQuery(VisibleTagsDefault, new[] { Tags.JoinedPerformers, Tags.YearAlbum }, new[] { Tags.DiscNumber, Tags.TrackNumber });
        public void ViewByGenre() => SetQuery(VisibleTagsDefault, new[] { Tags.JoinedGenres, Tags.JoinedPerformers, Tags.YearAlbum }, new[] { Tags.DiscNumber, Tags.TrackNumber });
        public void ViewByNone() => SetQuery(VisibleTagsExtended, new string[0], new[] { Tags.DiscNumber, Tags.TrackNumber });
        public void ViewByYear() => SetQuery(VisibleTagsExtended, new[] { Tags.DiscNumber, Tags.Decade, Tags.Year }, new[] { Tags.DiscNumber, Tags.TrackNumber });

        private void SetQuery(
            IEnumerable<string> visibleTags,
            IEnumerable<string> groupDescriptions,
            IEnumerable<string> sortDescriptions)
        {
            VisibleTagNames = visibleTags.Union(VisibleTagNames);
            _sortDescriptions = sortDescriptions.Select(s => new SortDescription(s, ListSortDirection.Ascending));
            _groupDescriptions = groupDescriptions;
            InitGroups();
        }

        #endregion
    }
}
