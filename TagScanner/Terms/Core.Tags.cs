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

        public static List<Tag> BrowsableTags => Tags.Keys.Where(p => Tags.Values[p].Browsable).ToList();

        #endregion

        #region Public Methods

        public static IEnumerable<Tag> GetDependencies(this Tag tag)
        {
            var tags = Tags.Keys.Where(p => p.Uses(tag));
            foreach (var t in tags.ToList())
                tags = tags.Union(GetDependencies(t));
            return tags;
        }

        public static bool Uses(this Tag user, Tag used)
        {
            var uses = Tags[user].Uses;
            return uses != null && uses.Contains(used);
        }

        public static IEnumerable<string> GetDependencyNames(this string name) => Tags[name].Tag.GetDependencies().Select(p => Tags[p].Name);

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
        #endregion
    }

    #region Utility Classes

    public class TagDictionary : Dictionary<Tag, TagInfo>
    {
    }

    public static class Tags
    {
        static Tags() => _tags = GetTags();

        public static IEnumerable<Tag> Keys => _tags.Keys;
        public static IEnumerable<TagInfo> Values => _tags.Values;


        private static Dictionary<Tag, TagInfo> _tags;

        private static TagDictionary GetTags()
        {
            var _tagDictionary = new TagDictionary();
            var props = typeof(Selection).GetProperties();
            foreach (Tag tag in Enum.GetValues(typeof(Tag)))
            {
                var name = tag.ToString();
                var prop = props.Single(p => p.Name == name);
                var category = GetCategory(tag);
                if (category == Selection.Selected)
                    continue;
                var tagInfo = new TagInfo
                {
                    Browsable = GetBrowsable(tag),
                    CanRead = prop.CanRead,
                    CanWrite = prop.CanWrite,
                    Category = category,
                    Column = GetColumn(tag),
                    Details = GetDescription(tag),
                    DisplayName = GetDisplayName(tag),
                    Name = name,
                    ReadOnly = GetReadOnly(tag),
                    Tag = tag,
                    Type = prop.PropertyType,
                    Uses = GetUses(tag),
                };
                tagInfo.AdjustAlignment();
                _tagDictionary.Add(tag, tagInfo);
            }
            return _tagDictionary;
        }

        private static bool GetBrowsable(Tag tag) => (bool)UseField(tag, typeof(BrowsableAttribute), "browsable");
        private static string GetCategory(Tag tag) => (string)UseField(tag, typeof(CategoryAttribute), "categoryValue");
        private static Column GetColumn(Tag tag) => (Column)UseField(tag, typeof(ColumnAttribute), "_column");
        private static string GetDescription(Tag tag) => (string)UseField(tag, typeof(DescriptionAttribute), "description");
        private static string GetDisplayName(Tag tag) => (string)UseField(tag, typeof(DisplayNameAttribute), "_displayName");
        private static bool GetReadOnly(Tag tag) => (bool)UseField(tag, typeof(ReadOnlyAttribute), "isReadOnly");
        private static Tag[] GetUses(Tag tag) => (Tag[])UseField(tag, typeof(UsesAttribute), "_propertyNames");

        private static void SetBrowsable(Tag tag, bool value)
        {
            var property = _tags[tag];
            if (property.Browsable != value)
            {
                UseField(tag, typeof(BrowsableAttribute), "browsable", value);
                property.Browsable = value;
            }
        }

        private static object UseField(Tag tag, Type attributeType, string fieldName, object value = null)
        {
            var attributes = TypeDescriptor.GetProperties(typeof(Selection))[tag.ToString()].Attributes[attributeType];
            var fieldInfo = attributeType.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            if (value == null)
                value = fieldInfo?.GetValue(attributes);
            else
                fieldInfo?.SetValue(attributes, value);
            return value;
        }


    }

    #endregion
}
