namespace TagScanner.Terms
{
    using System.Collections.Generic;

    public class EqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y) => string.Compare(x, y, ignoreCase: true) == 0;
        public int GetHashCode(string obj) => obj.GetHashCode();
    }
}
