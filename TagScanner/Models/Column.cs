namespace TagScanner.Models
{
    public class Column
    {
        public Column(int width, Alignment alignment = Alignment.Default, ColumnType type = ColumnType.Text)
        {
            _width = width;
            _alignment = alignment;
            _type = type;
        }

        public Alignment Alignment
        {
            get => _alignment;
            set => _alignment = value;
        }

        public ColumnType Type => _type;
        public int Width => _width;

        private Alignment _alignment;
        private ColumnType _type;
        private int _width;
    }
}
