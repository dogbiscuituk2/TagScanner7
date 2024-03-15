namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using Models;

    public static partial class Core
    {
        #region Public Properties

        public static List<Tag> BrowsableTags => Tags.Keys.Where(p => p.Browsable()).ToList();

        #endregion

        #region Public Methods

        public static bool Uses(this Tag user, Tag used)
        {
            var uses = user.Uses();
            return uses != null && uses.Contains(used);
        }

        public static IEnumerable<string> GetDependencyNames(this string name) => name.GetInfo().Tag.GetDependencies().Select(p => p.ToString());

        public static string Say(this Type type)
        {
            if (type.IsArray)
                return $"{type.GetElementType().Say()}[]";
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Boolean: return "condition";
                case TypeCode.Char: return "character";
                case TypeCode.Double: return "number";
                case TypeCode.Int32: return "integer";
                case TypeCode.Int64: return "long";
                case TypeCode.Object: return "this";
                case TypeCode.String: return "string";
                default: return type.Name;
            }
        }

        public static void WriteBrowsableTags(List<Tag> tags)
        {
            foreach (var tag in Tags.Keys) tag.SetBrowsable(tags.Contains(tag));
        }
    }


    #endregion
}
