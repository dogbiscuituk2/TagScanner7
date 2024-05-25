namespace TagScanner.Terms
{
    using System.Collections.Generic;

    public class Scope
    {
        public Variable FindVariable(string key) => _variables.ContainsKey(key) ? _variables[key] : null;
        public Variable MakeVariable(string key) { var variable = new Variable(key); _variables.Add(key, variable); return variable; }

        private readonly Dictionary<string, Variable> _variables = new Dictionary<string, Variable>();
    }
}
