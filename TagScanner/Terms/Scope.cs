namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Scope
    {
        #region Public Methods

        public Variable FindVariable(string key) => _variables.ContainsKey(key) ? _variables[key] : null;
        public Variable MakeVariable(string key) { var variable = new Variable(key); _variables.Add(key, variable); return variable; }
        public override string ToString() =>
            _variables.Any()
            ? _variables.Select(p => p.Value.Declaration).Aggregate((p, q) => $"{p}; {q}")
            : string.Empty;

        #endregion

        #region Private Fields

        private readonly Dictionary<string, Variable> _variables = new Dictionary<string, Variable>();

        #endregion
    }
}
