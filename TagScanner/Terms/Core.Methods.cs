namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;

    public static partial class Core
    {
        #region Public Properties

        public static MethodDictionary Methods => _methodDictionary ?? GetMethods();

        #endregion

        #region Private Fields

        private static MethodDictionary _methodDictionary;

        #endregion

        #region Private Methods

        private static MethodDictionary GetMethods() => _methodDictionary = new MethodDictionary
        {
            { "Compare", FindMethodInfo(typeof(string), true, "Compare", typeof(string), typeof(string)) },
            { "Concat_2", FindMethodInfo(typeof(string), true, "Concat", typeof(string), typeof(string)) },
            { "Concat_3", FindMethodInfo(typeof(string), true, "Concat", typeof(string), typeof(string), typeof(string)) },
            { "Concat_4", FindMethodInfo(typeof(string), true, "Concat", typeof(string), typeof(string), typeof(string), typeof(string)) },
            { "Contains", FindMethodInfo(typeof(string), false, "Contains", typeof(string)) },
            { "EndsWith", FindMethodInfo(typeof(string), false, "EndsWith", typeof(string)) },
            { "Equals", FindMethodInfo(typeof(object), false, "Equals", typeof(object)) },
            { "Format", FindMethodInfo(typeof(string), true, "Format", typeof(string), typeof(object[])) },
            { "Length", FindMethodInfo(typeof(string), false, "get_Length") },
            { "IndexOf", FindMethodInfo(typeof(string), false, "IndexOf", typeof(char)) },
            { "Insert", FindMethodInfo(typeof(string), false, "Insert", typeof(int), typeof(string)) },
            { "IsEmpty", FindMethodInfo(typeof(string), true, "IsNullOrWhiteSpace", typeof(string)) },
            { "Match$", FindMethodInfo(typeof(Regex), true, "IsMatch", typeof(string), typeof(string)) },
            { "LastIndexOf", FindMethodInfo(typeof(string), false, "LastIndexOf", typeof(char)) },
            { "Lowercase", FindMethodInfo(typeof(string), false, "ToLowerInvariant") },
            { "Max", FindMethodInfo(typeof(Math), true, "Max", typeof(double), typeof(double)) },
            { "Min", FindMethodInfo(typeof(Math), true, "Min", typeof(double), typeof(double)) },
            { "Power", FindMethodInfo(typeof(Math), true, "Pow", typeof(double), typeof(double)) },
            { "Remove", FindMethodInfo(typeof(string), false, "Remove", typeof(int), typeof(int)) },
            { "Replace", FindMethodInfo(typeof(string), false, "Replace", typeof(string), typeof(string)) },
            { "Replace$", FindMethodInfo(typeof(Regex), true, "Replace", typeof(string), typeof(string), typeof(string)) },
            { "Round", FindMethodInfo(typeof(Math), true, "Round", typeof(double)) },
            { "Sign", FindMethodInfo(typeof(Math), true, "Sign", typeof(double)) },
            { "StartsWith", FindMethodInfo(typeof(string), false, "StartsWith", typeof(string)) },
            { "Substring", FindMethodInfo(typeof(string), false, "Substring", typeof(int), typeof(int)) },
            { "ToString", FindMethodInfo(typeof(object), false, "ToString") },
            { "Trim", FindMethodInfo(typeof(string), false, "Trim") },
            { "Truncate", FindMethodInfo(typeof(Math), true, "Truncate", typeof(double)) },
            { "Uppercase", FindMethodInfo(typeof(string), false, "ToUpperInvariant") },
        };

        private static MethodInfo FindMethodInfo(Type declaringType, bool isStatic, string name,
            params Type[] paramTypes) => declaringType
            .GetMethods(BindingFlags.Public | (isStatic ? BindingFlags.Static : BindingFlags.Instance))
            .Single(p => p.Name == name && p.GetParamTypes().SequenceEqual(paramTypes));

        private static string GetParams(this MethodInfo method)
        {
            var names = method.GetParamTypeNames();
            return names.Any() ? names.Aggregate((p, q) => $"{p}, {q}") : string.Empty;
        }

        private static IEnumerable<string> GetParamTypeNames(this MethodInfo method) => method.GetParamTypes().Select(t => t.Name);
        private static IEnumerable<Type> GetParamTypes(this MethodInfo method) => method.GetParameters().Select(p => p.ParameterType);

        #endregion
    }

    #region Utility Classes

    public class MethodDictionary : Dictionary<string, MethodInfo> { }

    #endregion
}
