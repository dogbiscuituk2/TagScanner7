﻿namespace TagScanner.Models
{
    using System;
    using Core;

    /// <summary>
    /// This application uses the TagLib# library to access (both read and write) metadata in media files, including video, audio, and photo formats.
    /// In the TagLib# library source code and API, the term "Tag" refers to a structure containing most of the metadata for the given media.
    /// By contrast, the term "Tag" in this application means any single item of metadata from that structure, e.g.track title, performer, duration, etc.
    /// These Tags have in turn their own metadata, indicating for example their runtime type, category, and so on.
    /// Such meta-metadata will be found in this class.
    /// </summary>
    public class TagInfo
    {
        public bool Browsable;
        public bool CanRead;
        public bool CanSort => !Type.IsArray;
        public bool CanWrite;
        public string Category;
        public Column Column;
        public string Details;
        public string DisplayName;
        public bool IsString => TypeName == TagType.String;
        public bool IsText => TypeName.StartsWith(TagType.String);
        public string Name;
        public bool ReadOnly;
        public Tag Tag;
        public Type Type;
        public string TypeName => Type.Name;
        public Tag[] Uses;

        public void AdjustAlignment()
        {
            if (Column.Alignment == Alignment.Default)
                Column.Alignment = GetDefaultAlignment(Type);
        }

        public override string ToString() => DisplayName;

        private static Alignment GetDefaultAlignment(Type type)
        {
            switch (type.Name)
            {
                case TagType.Int32:
                case TagType.Int64:
                case TagType.TimeSpan:
                    return Alignment.Far;
                case TagType.Boolean:
                case TagType.Logical:
                    return Alignment.Centre;
                default:
                    return Alignment.Near;
            }
        }
    }
}
