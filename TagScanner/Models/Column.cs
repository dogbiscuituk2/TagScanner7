namespace TagScanner.Models
{
    public class Column
    {
        public Column(int width, Alignment alignment = Alignment.Default, ColumnType type = ColumnType.Text)
        {
            Width = width;
            Alignment = alignment;
            Type = type;
        }

        public Alignment Alignment { get; set; }
        public ColumnType Type { get; }
        public int Width { get; }
    }
}
