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

        public static TagDictionary Tags => _tagDictionary ?? GetTags();

        public static List<Tag> BrowsableTags => Tags.Keys.Where(p => Tags[p].Browsable).ToList();

        #endregion

        #region Public Methods

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
            foreach (var tag in Tags.Keys) SetBrowsable(tag, tags.Contains(tag));
        }

        #endregion

        #region Private Fields

        private static TagDictionary _tagDictionary;

        #endregion

        #region Private Methods

        private static TagDictionary GetTags()
        {
            _tagDictionary = new TagDictionary();
            var props = typeof(Selection).GetProperties();
            foreach (Tag tag in Enum.GetValues(typeof(Tag)))
            {
                var name = tag.ToString();
                var prop = props.Single(p => p.Name == name);
                var category = GetCategory(tag);
                if (category == Selection.Selected)
                    continue;
                var tagProps = new TagProps
                {
                    Browsable = GetBrowsable(tag),
                    CanRead = prop.CanRead,
                    CanWrite = prop.CanWrite,
                    Category = category,
                    Column = GetColumn(tag),
                    Details = GetDescription(tag),
                    DirectUses = GetDirectUses(tag),
                    DisplayName = GetDisplayName(tag),
                    FrequentlyUsed = GetFrequentlyUsed(tag),
                    Name = name,
                    ReadOnly = GetReadOnly(tag),
                    Type = prop.PropertyType,
                };
                tagProps.AdjustAlignment();
                _tagDictionary.Add(tag, tagProps);
            }
            return _tagDictionary;
        }

        private static bool GetBrowsable(Tag tag) => (bool)UseField(tag, typeof(BrowsableAttribute), "browsable");
        private static string GetCategory(Tag tag) => (string)UseField(tag, typeof(CategoryAttribute), "categoryValue");
        private static Column GetColumn(Tag tag) => (Column)UseField(tag, typeof(ColumnAttribute), "_column");
        private static string GetDescription(Tag tag) => (string)UseField(tag, typeof(DescriptionAttribute), "description");
        private static string GetDisplayName(Tag tag) => (string)UseField(tag, typeof(DisplayNameAttribute), "_displayName");
        private static bool GetFrequentlyUsed(Tag tag) => (bool)UseField(tag, typeof(FrequentlyUsedAttribute), "_frequentlyUsed");
        private static bool GetReadOnly(Tag tag) => (bool)UseField(tag, typeof(ReadOnlyAttribute), "isReadOnly");
        private static IEnumerable<string> GetDirectUses(Tag tag) => (IEnumerable<string>)UseField(tag, typeof(UsesAttribute), "_propertyNames");
        private static object UseField(Tag tag, Type attrType, string field, object value = null) => typeof(Selection).UseField(tag, attrType, field, value);

        private static void SetBrowsable(Tag tag, bool value)
        {
            var property = Tags[tag];
            if (property.Browsable != value)
            {
                UseField(tag, typeof(BrowsableAttribute), "browsable", value);
                property.Browsable = value;
            }
        }

        private static object UseField(this Type type, Tag tag, Type attrType, string field, object value = null)
        {
            var propName = tag.ToString();
            var attr = TypeDescriptor.GetProperties(type)[propName].Attributes[attrType];
            var info = attrType.GetField(field, BindingFlags.NonPublic | BindingFlags.Instance);
            if (value == null)
                value = info?.GetValue(attr);
            else
                info?.SetValue(attr, value);
            return value;
        }

        #endregion
    }

    #region Utility Classes

    public class TagDictionary : Dictionary<Tag, TagProps>
    {
        public TagProps this[string name] => this[(Tag)Enum.Parse(typeof(Tag), name)];
    }

    #endregion
}
