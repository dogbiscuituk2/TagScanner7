namespace TagScanner.Models
{
    public struct Logical
    {
        #region Public Properties

        public static Logical Yes = new Logical(true);
        public static Logical No = new Logical(false);
        public static Logical Unknown = new Logical(null);

        #endregion

        #region Public Operators

        public static Logical operator | (Logical left, Logical right)
        {
            if (left._value == true || right._value == true) return Yes;
            if (left._value == false && right._value == false) return No;
            return Unknown;
        }

        public static Logical operator &(Logical left, Logical right)
        {
            if (left._value == true && right._value == true) return Yes;
            if (left._value == false || right._value == false) return No;
            return Unknown;
        }

        public static bool operator ==(Logical left, Logical right) => left._value == right._value;
        public static bool operator !=(Logical left, Logical right) => !(left == right);

        #endregion

        #region Public Methods

        public override bool Equals(object obj) => obj is Logical that && this == that;
        public override int GetHashCode() => _value.GetHashCode();

        public override string ToString()
        {
            switch (_value)
            {
                case true: return "Yes";
                case false: return "No";
                default: return "Unknown";
            }
        }

        #endregion

        #region Private Fields

        private bool? _value;

        #endregion

        #region Private Constructor

        private Logical(bool? value) => _value = value;

        #endregion
    }
}
