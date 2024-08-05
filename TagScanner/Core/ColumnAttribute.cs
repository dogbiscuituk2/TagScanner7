namespace TagScanner.Core
{
    using System;

    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public ColumnAttribute(int width, Alignment alignment = Alignment.Default, ColumnType type = ColumnType.Text) =>
            _column = new Column(width, alignment, type);

        public static ColumnAttribute Default = new ColumnAttribute(80);

        private readonly Column _column;
    }
}
