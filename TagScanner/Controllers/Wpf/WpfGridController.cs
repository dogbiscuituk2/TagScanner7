namespace TagScanner.Controllers.Wpf
{
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using Models;
    using Terms;
    using ValueConverters;

    public abstract class WpfGridController: Controller
    {
        protected WpfGridController(Controller parent) : base(parent) { }

        public abstract DataGrid DataGrid { get; }

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
                case TagType.Logical: return new LogicalConverter();
                case TagType.Strings: return new StringsConverter();
                case TagType.TimeSpan: return new TimeSpanConverter();
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

        private static Style _rightAlignStyle;

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
    }
}
