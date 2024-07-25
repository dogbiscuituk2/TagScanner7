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

        public ListCollectionView ListCollectionView
        {
            get => (ListCollectionView)DataGrid.ItemsSource;
            set => DataGrid.ItemsSource = value;
        }

        #endregion

        #region Protected Properties

        protected IEnumerable<Tag> Columns
        {
            get => _columns;
            set
            {
                _columns = value;
                InitColumns();
            }
        }

        protected IEnumerable<Tag> Groups
        {
            get => _groups;
            set
            {
                _groups = value;
                InitGroups();
            }
        }

        protected IEnumerable<SortDescription> Sorts
        {
            get => _sorts;
            set
            {
                _sorts = value;
                InitSorts();
            }
        }

        #endregion

        #region Protected Methods

        protected virtual void EditTagVisibility(string detail)
        {
            var query = Query;
            if (new QueryController(this).Execute($"Select the Columns to display in the {detail} Table", query))
                Query = query;
        }

        protected virtual DataGridBoundColumn CreateColumn(TagInfo tagInfo)
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

        protected virtual void CreateColumns()
        {
            DataGrid.Columns.Clear();
            var columns = Tags.Values.Select(CreateColumn)?.Where(c => c != null);
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

        protected Query Query
        {
            get => new Query(Columns, Sorts, Groups);
            set => WriteQueryToGrid(value);
        }

        protected virtual void WriteQueryToGrid(Query query)
        {
            Columns = query.Tags;
            Groups = query.Groups;
            Sorts = query.Sorts.Union(Groups.Select(p => new SortDescription($"{p}", ListSortDirection.Ascending)));
        }

        #endregion

        #region Private Fields

        private IEnumerable<Tag>
            _columns = new List<Tag>(),
            _groups = new List<Tag>();

        private IEnumerable<SortDescription> _sorts = new List<SortDescription>();

        private static Style _rightAlignStyle;

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

        private void InitColumns()
        {
            foreach (var column in DataGrid.Columns)
            {
                column.DisplayIndex = 0;
                column.Visibility = Visibility.Collapsed;
            }
            var displayIndex = 0;
            foreach (var tag in Columns)
            {
                var column = DataGrid.Columns.Single(p => ((TagInfo)p.Header).Name == tag.ToString());
                column.DisplayIndex = displayIndex++;
                column.Visibility = Visibility.Visible;
            }
        }

        private void InitGroups()
        {
            var groups = ListCollectionView?.GroupDescriptions;
            if (groups == null) return;
            groups.Clear();
            foreach (Tag group in Groups)
                groups.Add(new PropertyGroupDescription($"{group}"));
        }

        private void InitSorts()
        {
            var sorts = ListCollectionView?.SortDescriptions;
            if (sorts == null) return;
            sorts.Clear();
            foreach (var sort in Sorts)
                sorts.Add(sort);
        }

        #endregion
    }
}
