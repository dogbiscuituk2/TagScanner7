namespace TagScanner.Controllers.Wpf
{
    using System.Collections.Generic;
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

        #endregion

        #region Protected Methods

        protected void EditTagVisibility(string detail)
        {
            var visibleTags = VisibleTags.ToList();
            var ok = new QueryController(this).Execute($"Select the Columns to display in the {detail} Table", visibleTags);
            if (ok)
                VisibleTags = VisibleTags.Intersect(visibleTags).Union(visibleTags).ToList();
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
                case TagType.DateTime: return new DateTimeConverter();
                //case TagType.Logical: return new LogicalConverter();
                case TagType.Strings: return new StringsConverter();
                case TagType.TimeSpan: return new TimeSpanConverter();
            }
            switch (tagInfo.Tag)
            {
                case Tag.FileSize:
                    return new FileSizeConverter();
            }
            return null;
        }

        protected void InitColumns()
        {
            DataGrid.Columns.Clear();
            var columns = Tags.Values.Select(GetColumn)?.Where(c => c != null);
            if (columns != null)
                foreach (var column in columns)
                    DataGrid.Columns.Add(column);
            DataGrid.GridLinesVisibility = DataGridGridLinesVisibility.Vertical;
        }

        #endregion

        #region Private Fields

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
    }
}
