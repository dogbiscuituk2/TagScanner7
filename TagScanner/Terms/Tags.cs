namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using Models;

    public static class Tags
    {
        #region Static Constructor

        static Tags()
        {
            _tagToInfo = new Dictionary<Tag, TagInfo>();
            _displayNameToInfo = new Dictionary<string, TagInfo>();
            var props = typeof(Selection).GetProperties();
            foreach (Tag tag in Enum.GetValues(typeof(Tag)))
            {
                var name = $"{tag}";
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
                _tagToInfo.Add(tag, tagInfo);
                _displayNameToInfo.Add(tagInfo.DisplayName, tagInfo);
            }
            Keys = _tagToInfo.Keys.ToArray();
            Values = _tagToInfo.Values.ToArray();
        }

        #endregion

        #region Public Properties

        public static List<Tag> BrowsableTags => Keys.Where(p => p.Browsable()).ToList();
        public static Tag[] Keys { get; }
        public static TagInfo[] Values { get; }
        public static IEnumerable<string> FieldNames => Keys.Select(p => p.DisplayName());

        #endregion

        #region Public Methods

        public static IEnumerable<Tag> GetDependencies(this Tag tag)
        {
            var tags = Keys.Where(p => p.Uses(tag));
            foreach (var t in tags.ToList())
                tags = tags.Union(GetDependencies(t));
            return tags;
        }

        public static IEnumerable<string> GetDependencyNames(this string name) =>
            name.TagNameToTag().GetDependencies().Select(p => p.ToString());

        public static bool Uses(this Tag user, Tag used)
        {
            var uses = user.Uses();
            return uses != null && uses.Contains(used);
        }

        public static Tag DisplayNameToTag(this string displayName) => displayName.DisplayNameToTagInfo().Tag;
        public static TagInfo DisplayNameToTagInfo(this string displayName) => _displayNameToInfo[displayName];
        public static Tag TagNameToTag(this string tagName) => (Tag)Enum.Parse(typeof(Tag), tagName);
        public static TagInfo TagNameToTagInfo(this string tagName) => tagName.TagNameToTag().TagToTagInfo();
        public static TagInfo TagToTagInfo(this Tag tag) => _tagToInfo[tag];

        public static bool Browsable(this Tag tag) => tag.TagToTagInfo().Browsable;
        public static bool CanRead(this Tag tag) => tag.TagToTagInfo().CanRead;
        public static bool CanSort(this Tag tag) => tag.TagToTagInfo().CanSort;
        public static bool CanWrite(this Tag tag) => tag.TagToTagInfo().CanWrite;
        public static string Category(this Tag tag) => tag.TagToTagInfo().Category;
        public static Column Column(this Tag tag) => tag.TagToTagInfo().Column;
        public static string Details(this Tag tag) => tag.TagToTagInfo().Details;
        public static string DisplayName(this Tag tag) => tag.TagToTagInfo().DisplayName;
        public static string Name(this Tag tag) => tag.TagToTagInfo().Name;
        public static bool ReadOnly(this Tag tag) => tag.TagToTagInfo().ReadOnly;
        public static Type Type(this Tag tag) => tag.TagToTagInfo().Type;
        public static string TypeName(this Tag tag) => tag.TagToTagInfo().TypeName;
        public static Tag[] Uses(this Tag tag) => tag.TagToTagInfo().Uses;

        public static void SetBrowsable(this Tag tag, bool value)
        {
            var property = _tagToInfo[tag];
            if (property.Browsable == value) return;
            UseField(tag, typeof(BrowsableAttribute), "browsable", value);
            property.Browsable = value;
        }

        public static void WriteBrowsableTags(List<Tag> tags)
        {
            foreach (var tag in Keys) tag.SetBrowsable(tags.Contains(tag));
        }

        #endregion

        #region Private Fields

        private static readonly Dictionary<Tag, TagInfo> _tagToInfo;
        private static readonly Dictionary<string, TagInfo> _displayNameToInfo;

        #endregion

        #region Private Methods

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

        #endregion
    }
}
