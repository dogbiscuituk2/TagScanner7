namespace TagScanner.Terms
{
    using System.Collections.Generic;

    public class EqualityComparer : IEqualityComparer<string>
    {
        public EqualityComparer(bool caseSensitive) => _caseSensitive = caseSensitive;

        private readonly bool _caseSensitive;

        public bool Equals(string x, string y) => string.Compare(x, y, ignoreCase: !_caseSensitive) == 0;
        public int GetHashCode(string obj) => obj.GetHashCode();
    }
}
