namespace TagScanner.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using TagScanner.Models;
    using TagScanner.ValueConverters;

    public abstract class GridController: Controller
    {
        public GridController(Controller parent) : base(parent) { }

        public abstract DataGrid DataGrid { get; }

        protected virtual DataGridBoundColumn GetColumn(TagProps tagProps)
        {
            var column = tagProps.Column.Type == ColumnType.CheckBox
                ? (DataGridBoundColumn)new DataGridCheckBoxColumn()
                : new DataGridTextColumn();
            column.Binding = new Binding(tagProps.Name)
            {
                Mode = tagProps.CanWrite ? BindingMode.TwoWay : BindingMode.OneWay,
                Converter = GetConverter(tagProps)
            };
            column.CellStyle = tagProps.Column.Alignment == Alignment.Far
                ? _rightAlignStyle ?? (_rightAlignStyle = GetNewRightAlignStyle())
                : null;
            column.Header = tagProps;
            column.Width = tagProps.Column.Width;
            return column;
        }

        protected virtual IValueConverter GetConverter(TagProps tagProps)
        {
            switch (tagProps.TypeName)
            {
                case TagType.DateTime: return new DateTimeConverter();
                case TagType.Logical: return new LogicalConverter();
                case TagType.Strings: return new StringsConverter();
                case TagType.TimeSpan: return new TimeSpanConverter();
            }
            return null;
        }

        protected abstract IEnumerable<TagProps> GetTagProps();

        protected void InitColumns()
        {
            DataGrid.Columns.Clear();
            foreach (var column in GetTagProps().Select(GetColumn).Where(c => c != null))
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
