namespace TagScanner.Terms
{
    public class Number
    {
        public Number(double value) => Value = value;

        public double Value { get; set; }

        public static implicit operator Number(int value) => new Number(value);
        public static implicit operator Number(long value) => new Number(value);
        public static implicit operator Number(double value) => new Number(value);
        public static implicit operator int(Number number) => (int)number.Value;
        public static implicit operator long(Number number) => (long)number.Value;
        public static implicit operator double(Number number) => number.Value;
    }
}
