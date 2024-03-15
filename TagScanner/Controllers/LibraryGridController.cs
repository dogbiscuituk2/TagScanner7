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
    using Models;
    using Terms;
    using ValueConverters;
    using Views;

    internal class LibraryGridController : GridController
    {
        #region Constructor

        internal LibraryGridController(LibraryFormController parent, Model model, ElementHost view) : base(parent)
        {
            Model = model;
            View = view;
        }

        #endregion

        #region Model

        private Model _model;
        internal Model Model
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

        internal override DataGrid DataGrid => ((GridElement)View.Child).DataGrid;

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

        internal void EditTagVisibility()
        {
            var gridVisibleTags = VisibleTags;
            var ok = new TagsController(this).Execute("Select the Columns to display in the Media Table", gridVisibleTags);
            if (ok)
                VisibleTags = VisibleTags.Intersect(gridVisibleTags).Union(gridVisibleTags).ToList();
        }

        protected override IValueConverter GetConverter(TagProps tagProps)
        {
            var result = base.GetConverter(tagProps);
            if (result != null) return result;
            switch (tagProps.Name)
            {
                case Tags.FileSize:
                    return new FileSizeConverter();
            }
            return null;
        }

        //protected override IEnumerable<TagProps> GetTagProps() => Tags.AllTags;

        private List<Tag> _visibleTags = new List<Tag>{ Tag.FilePath };
        internal List<Tag> VisibleTags
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
                var column = DataGrid.Columns.Single(c => ((TagProps)c.Header).Name == Core.Tags[tag].Name);
                column.DisplayIndex = displayIndex++;
                column.Visibility = Visibility.Visible;
            }
        }

        #endregion

        #region Sorting and Grouping

        private IEnumerable<SortDescription> _sortDescriptions = Array.Empty<SortDescription>();
        internal IEnumerable<SortDescription> SortDescriptions
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

        private IEnumerable<Tag> _groupDescriptions = Array.Empty<Tag>();
        internal IEnumerable<Tag> GroupDescriptions
        {
            get => _groupDescriptions;
            set
            {
                if (GroupDescriptions.SequenceEqual(value)) return;
                _groupDescriptions = value;
                InitGroups();
            }
        }

        private void InitGroups()
        {
            //var sortDescriptions = ListCollectionView.SortDescriptions;
            //sortDescriptions.Clear();
            //foreach (var sortDescription in SortDescriptions)
            //	sortDescriptions.Add(sortDescription);
            var groupDescriptions = ListCollectionView.GroupDescriptions;
            if (groupDescriptions != null)
            {
                groupDescriptions.Clear();
                foreach (var groupDescription in GroupDescriptions)
                    groupDescriptions.Add(new PropertyGroupDescription(Core.Tags[groupDescription].Name));
            }
        }

        #endregion

        #region Selection

        private Selection _selection;
        internal Selection Selection => _selection ?? (_selection = GetSelection());

        internal event EventHandler SelectionChanged;

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
            if (UpdatingSelectionCount != 0) return;
            InvalidateSelection();
            SelectionChanged?.Invoke(this, EventArgs.Empty);
        }

        internal void SelectAll()
        {
            BeginUpdateSelection();
            DataGrid.SelectAll();
            EndUpdateSelection();
        }

        internal void InvertSelection()
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

        private static readonly List<Tag>
            VisibleTagsDefault = new[] { Tag.DiscTrack, Tag.Title, Tag.Duration, Tag.FileSize }.ToList(),
            VisibleTagsExtended = new[] { Tag.DiscTrack, Tag.Title, Tag.Duration, Tag.FileSize, Tag.JoinedPerformers, Tag.Album }.ToList();
        
        internal void ViewByAlbum() => SetQuery(VisibleTagsDefault, new[] { Tag.Album }, new[] { Tag.DiscNumber, Tag.TrackNumber });
        internal void ViewByArtist() => SetQuery(new[] { Tag.YearAlbum, Tag.DiscTrack, Tag.Title, Tag.Duration, Tag.FileSize }, new[] { Tag.JoinedPerformers }, new[] { Tag.DiscNumber, Tag.TrackNumber });
        internal void ViewByArtistAlbum() => SetQuery(VisibleTagsDefault, new[] { Tag.JoinedPerformers, Tag.YearAlbum }, new[] { Tag.DiscNumber, Tag.TrackNumber });
        internal void ViewByGenre() => SetQuery(VisibleTagsDefault, new[] { Tag.JoinedGenres, Tag.JoinedPerformers, Tag.YearAlbum }, new[] { Tag.DiscNumber, Tag.TrackNumber });
        internal void ViewByNone() => SetQuery(VisibleTagsExtended, null, new[] { Tag.DiscNumber, Tag.TrackNumber });
        internal void ViewByYear() => SetQuery(VisibleTagsExtended, new[] { Tag.DiscNumber, Tag.Decade, Tag.Year }, new[] { Tag.DiscNumber, Tag.TrackNumber });

        private void SetQuery(IEnumerable<Tag> visibleTags, IEnumerable<Tag> groupDescriptions, IEnumerable<Tag> sortDescriptions)
        {
            VisibleTags = visibleTags.Union(VisibleTags).ToList();
            _sortDescriptions = sortDescriptions.Select(s => new SortDescription(Core.Tags[s].Name, ListSortDirection.Ascending));
            _groupDescriptions = groupDescriptions;
            InitGroups();
        }

        #endregion
    }
}
