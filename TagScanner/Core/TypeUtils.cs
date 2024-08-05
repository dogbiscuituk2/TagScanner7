namespace TagScanner.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TagScanner.Models;

    public static class TypeUtils
    {
        public static Logical AsLogical(this bool value) => value ? Logical.Yes : Logical.No;

        /// <summary>
        /// Find the "best" type to represent the result of a dyadic operation using the given operands.
        /// </summary>
        /// <param name="type1">The first term of the dyadic operation.</param>
        /// <param name="type2">The second term of the dyadic operation.</param>
        /// <returns>Type that can be used to hold the operation's result.</returns>
        public static Type GetCommonType(this Type type1, Type type2)
        {
            // If these two types are the same, then just use that common type.
            if (type1 == type2) return type1;
            // If either type is null, then use the other.
            if (type1 == null) return type2;
            if (type2 == null) return type1;
            // If either type is "object", then use "object".
            if (IsType(typeof(object), type1, type2))
                return typeof(object);
            // If one is a value type and the other not, then use "object".
            if (type1.IsValueType ^ type2.IsValueType)
                return typeof(object);
            // Otherwise, use the "wider" of the two different non-null types.
            return MatchType(typeof(double), type1, type2) // Type "double" absorbs any "float", "int" or "long".
                ?? MatchType(typeof(float), type1, type2) // Type "float" absorbs any "long" or "int".
                ?? MatchType(typeof(long), type1, type2) // Type "long" absorbs any "int".
                ?? MatchType(typeof(string), type1, type2); // Type "string" absorbs any "char".

            bool IsType(Type t, Type t1, Type t2) => t == t1 || t == t2;
            Type MatchType(Type t, Type t1, Type t2) => t == t1 || t == t2 ? t : null;
        }

        public static Type GetCompatibleType(this IEnumerable<Type> types)
        {
            if (!types.Any())
                return null;
            var result = types.First();
            foreach (var type in types.Skip(1))
                result = result.GetCommonType(type);
            return result;
        }
    }
}
