namespace TagScanner.Controllers.Wpf
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using Models;
    using Terms;
    using ValueConverters;

    public abstract class WpfGridController : Controller
    {
        #region Constructor

        protected WpfGridController(Controller parent) : base(parent) { }

        #endregion

        #region Public Properties

        public abstract DataGrid DataGrid { get; }

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

        public ListCollectionView ListCollectionView
        {
            get => (ListCollectionView)DataGrid.ItemsSource;
            set => DataGrid.ItemsSource = value;
        }

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

        public List<Tag> VisibleTags
        {
            get => _visibleTags;
            set
            {
                _visibleTags = value;
                InitVisibleTags();
            }
        }

        #endregion

        #region Protected Methods

        protected virtual void EditTagVisibility(string detail)
        {
            var ok = new QueryController(this).Execute($"Select the Columns to display in the {detail} Table", ReadQueryFromGrid());
            if (ok)
                WriteQueryToGrid(new Query(VisibleTags, Sorts, Groups));
        }

        protected virtual DataGridBoundColumn GetColumn(TagInfo tagInfo)
        {
            var column = tagInfo.Column.Type == ColumnType.CheckBox
                ? (DataGridBoundColumn)new DataGridCheckBoxColumn()
                : new DataGridTextColumn();
            column.Binding = new Binding(tagInfo.Name)
            {
                Mode = tagInfo.CanWrite ? BindingMode.TwoWay : BindingMode.OneWay,
                Converter = GetConverter(tagInfo)
            };
            column.CellStyle = tagInfo.Column.Alignment == Alignment.Far
                ? _rightAlignStyle ?? (_rightAlignStyle = GetNewRightAlignStyle())
                : null;
            column.Header = tagInfo;
            column.Width = tagInfo.Column.Width;
            return column;
        }

        protected virtual IValueConverter GetConverter(TagInfo tagInfo)
        {
            switch (tagInfo.TypeName)
            {
                case TagType.DateTime: return new DateConverter();
                //case TagType.Logical: return new LogicalConverter();
                case TagType.Strings: return new StringsConverter();
                case TagType.TimeSpan: return new TimeConverter();
            }
            switch (tagInfo.Tag)
            {
                case Tag.FileSize:
                    return new FileSizeConverter();
            }
            return null;
        }

        protected virtual void InitColumns()
        {
            DataGrid.Columns.Clear();
            var columns = Tags.Values.Select(GetColumn)?.Where(c => c != null);
            if (columns != null)
                foreach (var column in columns)
                    DataGrid.Columns.Add(column);
            DataGrid.GridLinesVisibility = DataGridGridLinesVisibility.Vertical;
        }

        protected virtual void InitSortsAndGroups()
        {
            InitSorts();
            InitGroups();
        }

        protected virtual Query ReadQueryFromGrid() => new Query(_visibleTags, _sorts, _groups);

        protected virtual void WriteQueryToGrid(Query query)
        {
            VisibleTags = query.Tags; // .Union(VisibleTags).ToList();
            _groups = query.Groups;
            _sorts = query.Sorts.Union(_groups.Select(p => new SortDescription($"{p}", ListSortDirection.Ascending)));
            InitSortsAndGroups();
        }

        #endregion

        #region Private Fields

        private IEnumerable<Tag> _groups = new List<Tag>();
        private IEnumerable<SortDescription> _sorts = new List<SortDescription>();

        private static Style _rightAlignStyle;
        private List<Tag> _visibleTags = new List<Tag>();

        #endregion

        #region Private Methods

        private static Style GetNewRightAlignStyle()
        {
            _rightAlignStyle = new Style(typeof(DataGridCell));
            _rightAlignStyle.Setters.Add(new Setter
            {
                Property = FrameworkElement.HorizontalAlignmentProperty,
                Value = HorizontalAlignment.Right
            });
            return _rightAlignStyle;
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

        private void InitVisibleTags()
        {
            foreach (var column in DataGrid.Columns)
            {
                column.DisplayIndex = 0;
                column.Visibility = Visibility.Collapsed;
            }
            var displayIndex = 0;
            foreach (var tag in VisibleTags)
            {
                var column = DataGrid.Columns.Single(p => ((TagInfo)p.Header).Name == tag.ToString());
                column.DisplayIndex = displayIndex++;
                column.Visibility = Visibility.Visible;
            }
        }

        #endregion
    }
}
