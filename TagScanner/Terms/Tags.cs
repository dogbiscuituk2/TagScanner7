namespace TagScanner.Terms
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System;
    using Models;

    public static class Tags
    {
        public static Tag[] Keys { get; }
        public static TagInfo[] Values { get; }

        public static TagInfo GetInfo(this Tag tag) => TagDictionary[tag];
        public static TagInfo GetInfo(this string tagName) => Values.Single(p => p.Name == tagName);

        public static IEnumerable<Tag> GetDependencies(this Tag tag)
        {
            var tags = Keys.Where(p => p.Uses(tag));
            foreach (var t in tags.ToList())
                tags = tags.Union(GetDependencies(t));
            return tags;
        }

        public static bool Browsable(this Tag tag) => TagDictionary[tag].Browsable;
        public static string Details(this Tag tag) => TagDictionary[tag].Details;
        public static string DisplayName(this Tag tag) => TagDictionary[tag].DisplayName;
        public static Type Type(this Tag tag) => TagDictionary[tag].Type;
        public static Tag[] Uses(this Tag tag) => TagDictionary[tag].Uses;

        public static void SetBrowsable(this Tag tag, bool value)
        {
            var property = TagDictionary[tag];
            if (property.Browsable == value) return;
            UseField(tag, typeof(BrowsableAttribute), "browsable", value);
            property.Browsable = value;
        }

        static Tags()
        {
            TagDictionary = new Dictionary<Tag, TagInfo>();
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
                TagDictionary.Add(tag, tagInfo);
            }
            Keys = TagDictionary.Keys.ToArray();
            Values = TagDictionary.Values.ToArray();
        }

        private static readonly Dictionary<Tag, TagInfo> TagDictionary;

        private static bool GetBrowsable(Tag tag) => (bool)UseField(tag, typeof(BrowsableAttribute), "browsable");
        private static string GetCategory(Tag tag) => (string)UseField(tag, typeof(CategoryAttribute), "categoryValue");
        private static Column GetColumn(Tag tag) => (Column)UseField(tag, typeof(ColumnAttribute), "_column");
        private static string GetDescription(Tag tag) => (string)UseField(tag, typeof(DescriptionAttribute), "description");
        private static string GetDisplayName(Tag tag) => (string)UseField(tag, typeof(DisplayNameAttribute), "_displayName");
        private static bool GetReadOnly(Tag tag) => (bool)UseField(tag, typeof(ReadOnlyAttribute), "isReadOnly");
        private static Tag[] GetUses(Tag tag) => (Tag[])UseField(tag, typeof(UsesAttribute), "_propertyNames");

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
}
