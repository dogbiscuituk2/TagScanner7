namespace TagScanner.Controllers
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
    using Menus;
    using Models;
    using Terms;
    using ValueConverters;
    using Views;

    public class LibraryGridController : GridController
    {
        #region Constructor

        public LibraryGridController(Controller parent, ElementHost view) : base(parent)
        {
            Model.WorksChanged += Model_WorksChanged;
            View = view;
        }

        #endregion

        #region Properties

        private LibraryForm LibraryForm => LibraryFormController.View;
        private LibraryFormController LibraryFormController => (LibraryFormController)Parent;
        private Model Model => LibraryFormController.Model;

        #endregion

        #region Model

        private void Model_WorksChanged(object sender, EventArgs e) => RefreshDataSource();

        #endregion

        #region Views

        private ElementHost _view;
        private ElementHost View
        {
            get => _view;
            set
            {
                _view = value;

                LibraryForm.ViewByArtistAlbum.Click += ViewByArtistAlbum_Click;
                LibraryForm.ViewByArtist.Click += ViewByArtist_Click;
                LibraryForm.ViewByGenre.Click += ViewByGenre_Click;
                LibraryForm.ViewByYear.Click += ViewByYear_Click;
                LibraryForm.ViewByAlbum.Click += ViewByAlbum_Click;
                LibraryForm.ViewByNoGrouping.Click += ViewByNone_Click;

                View.Child = new GridElement();
                InitColumns();
                DataGrid.SelectionChanged += Grid_SelectionChanged;
                RefreshDataSource();

                ViewByArtistAlbum();
            }
        }

        public override DataGrid DataGrid => ((GridElement)View.Child).DataGrid;

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
                ClearFilter();
                InitSortsAndGroups();
            }
        }

        private void ViewByArtistAlbum_Click(object sender, EventArgs e) => ViewByArtistAlbum();
        private void ViewByArtist_Click(object sender, EventArgs e) => ViewByArtist();
        private void ViewByAlbum_Click(object sender, EventArgs e) => ViewByAlbum();
        private void ViewByNone_Click(object sender, EventArgs e) => ViewByNone();
        private void ViewByGenre_Click(object sender, EventArgs e) => ViewByGenre();
        private void ViewByYear_Click(object sender, EventArgs e) => ViewByYear();

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
        public void SetFilter(Term term) => ListCollectionView.Filter = p => term.Predicate((Work)p);

        public int WorksCountAll => Model.Works.Count;
        public int WorksCountVisible => ListCollectionView.Count;

        #endregion

        #region Sorting and Grouping

        private IEnumerable<SortDescription> _sorts = Array.Empty<SortDescription>();
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

        private IEnumerable<Tag> _groups = Array.Empty<Tag>();
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
                groups.Add(new PropertyGroupDescription(group.ToString()));
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
            var selectionChanged = SelectionChanged;
            selectionChanged?.Invoke(this, EventArgs.Empty);
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

        private FileInfo[] GetSelectedFileInfos() => Selection.Works.Select(p => new FileInfo(p.FilePath)).ToArray();

        private Selection GetSelection()
        {
            var selection = new Selection(DataGrid.SelectedItems.Cast<Work>());
            selection.WorksEdit += Selection_WorksEdit;
            return selection;
        }

        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e) => OnSelectionChanged();

        private void Selection_WorksEdit(object sender, WorksEditEventArgs e) =>
            LibraryFormController.WorksEdit(e.Tag, e.Works, e.Values);

        #endregion

        #region Presets

        private void ViewByArtistAlbum() => SetQuery(Tags.Data1, Tags.GroupByArtistAlbum, Tags.SortByNumber);
        private void ViewByArtist() => SetQuery(Tags.Data3, Tags.GroupByArtist, Tags.SortByAlbum);
        private void ViewByAlbum() => SetQuery(Tags.Data1, Tags.GroupByAlbum, Tags.SortByNumber);
        private void ViewByYear() => SetQuery(Tags.Data2, Tags.GroupByYear, Tags.SortByNumber);
        private void ViewByGenre() => SetQuery(Tags.Data1, Tags.GroupByGenre, Tags.SortByNumber);
        private void ViewByNone() => SetQuery(Tags.Data4, Tags.GroupByNone, Tags.SortByTitle);

        private void SetQuery(Tag[] tags, Tag[] groups, Tag[] sorts)
        {
            VisibleTags = tags.Union(VisibleTags).ToList();
            _groups = groups;
            _sorts = groups.Union(sorts).Select(p => new SortDescription($"{p}", ListSortDirection.Ascending));
            InitSortsAndGroups();
        }

        #endregion
    }
}
