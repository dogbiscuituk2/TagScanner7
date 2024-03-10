namespace TagScanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;

    public static class Tags
    {
        #region Public Interface

        #region Tag Names

        public const string
            Album = "Album",
            AlbumArtists = "AlbumArtists",
            AlbumArtistsCount = "AlbumArtistsCount",
            AlbumArtistsSort = "AlbumArtistsSort",
            AlbumArtistsSortCount = "AlbumArtistsSortCount",
            AlbumGain = "AlbumGain",
            AlbumPeak = "AlbumPeak",
            AlbumSort = "AlbumSort",
            AmazonId = "AmazonId",
            Artists = "Artists",
            ArtistsCount = "ArtistsCount",
            AudioBitrate = "AudioBitrate",
            AudioChannels = "AudioChannels",
            AudioSampleRate = "AudioSampleRate",
            BeatsPerMinute = "BeatsPerMinute",
            BitsPerSample = "BitsPerSample",
            Century = "Century",
            Codecs = "Codecs",
            Comment = "Comment",
            Composers = "Composers",
            ComposersCount = "ComposersCount",
            ComposersSort = "ComposersSort",
            ComposersSortCount = "ComposersSortCount",
            Conductor = "Conductor",
            Copyright = "Copyright",
            Decade = "Decade",
            Description = "Description",
            DiscCount = "DiscCount",
            DiscNumber = "DiscNumber",
            DiscOf = "DiscOf",
            DiscTrack = "DiscTrack",
            Duration = "Duration",
            FileAttributes = "FileAttributes",
            FileCreationTime = "FileCreationTime",
            FileCreationTimeUtc = "FileCreationTimeUtc",
            FileExtension = "FileExtension",
            FileLastAccessTime = "FileLastAccessTime",
            FileLastAccessTimeUtc = "FileLastAccessTimeUtc",
            FileLastWriteTime = "FileLastWriteTime",
            FileLastWriteTimeUtc = "FileLastWriteTimeUtc",
            FileName = "FileName",
            FileNameWithoutExtension = "FileNameWithoutExtension",
            FilePath = "FilePath",
            FileSize = "FileSize",
            FileStatus = "FileStatus",
            FirstAlbumArtist = "FirstAlbumArtist",
            FirstAlbumArtistSort = "FirstAlbumArtistSort",
            FirstArtist = "FirstArtist",
            FirstComposer = "FirstComposer",
            FirstComposerSort = "FirstComposerSort",
            FirstGenre = "FirstGenre",
            FirstPerformer = "FirstPerformer",
            FirstPerformerSort = "FirstPerformerSort",
            Genres = "Genres",
            GenresCount = "GenresCount",
            Grouping = "Grouping",
            ImageAltitude = "ImageAltitude",
            ImageCreator = "ImageCreator",
            ImageDateTime = "ImageDateTime",
            ImageExposureTime = "ImageExposureTime",
            ImageFNumber = "ImageFNumber",
            ImageFocalLength = "ImageFocalLength",
            ImageFocalLengthIn35mmFilm = "ImageFocalLengthIn35mmFilm",
            ImageISOSpeedRatings = "ImageISOSpeedRatings",
            ImageKeywords = "ImageKeywords",
            ImageLatitude = "ImageLatitude",
            ImageLongitude = "ImageLongitude",
            ImageMake = "ImageMake",
            ImageModel = "ImageModel",
            ImageOrientation = "ImageOrientation",
            ImageRating = "ImageRating",
            ImageSoftware = "ImageSoftware",
            InvariantEndPosition = "InvariantEndPosition",
            InvariantStartPosition = "InvariantStartPosition",
            IsClassical = "IsClassical",
            IsEmpty = "IsEmpty",
            JoinedAlbumArtists = "JoinedAlbumArtists",
            JoinedArtists = "JoinedArtists",
            JoinedComposers = "JoinedComposers",
            JoinedGenres = "JoinedGenres",
            JoinedPerformers = "JoinedPerformers",
            JoinedPerformersSort = "JoinedPerformersSort",
            Lyrics = "Lyrics",
            MediaTypes = "MediaTypes",
            Millennium = "Millennium",
            MimeType = "MimeType",
            MusicBrainzArtistId = "MusicBrainzArtistId",
            MusicBrainzDiscId = "MusicBrainzDiscId",
            MusicBrainzReleaseArtistId = "MusicBrainzReleaseArtistId",
            MusicBrainzReleaseCountry = "MusicBrainzReleaseCountry",
            MusicBrainzReleaseId = "MusicBrainzReleaseId",
            MusicBrainzReleaseStatus = "MusicBrainzReleaseStatus",
            MusicBrainzReleaseType = "MusicBrainzReleaseType",
            MusicBrainzTrackId = "MusicBrainzTrackId",
            MusicIpId = "MusicIpId",
            Performers = "Performers",
            PerformersCount = "PerformersCount",
            PerformersSort = "PerformersSort",
            PerformersSortCount = "PerformersSortCount",
            PhotoHeight = "PhotoHeight",
            PhotoQuality = "PhotoQuality",
            PhotoWidth = "PhotoWidth",
            Pictures = "Pictures",
            PicturesCount = "PicturesCount",
            PossiblyCorrupt = "PossiblyCorrupt",
            TagTypes = "TagTypes",
            TagTypesOnDisk = "TagTypesOnDisk",
            Title = "Title",
            TitleSort = "TitleSort",
            TrackCount = "TrackCount",
            TrackGain = "TrackGain",
            TrackNumber = "TrackNumber",
            TrackOf = "TrackOf",
            TrackPeak = "TrackPeak",
            VideoHeight = "VideoHeight",
            VideoWidth = "VideoWidth",
            Year = "Year",
            YearAlbum = "YearAlbum";

        #endregion

        public static List<TagProps> AllTags;

        public static IEnumerable<string> AllTagNames => AllTags.Select(p => p.Name);

        public static IEnumerable<string> BrowsableTagNames => BrowsableTags.Select(p => p.Name);
        public static IEnumerable<string> FrequentlyUsedTagNames => FrequentlyUsedTags.Select(p => p.Name);
        public static IEnumerable<string> ReadableTagNames => ReadableTags.Select(p => p.Name);
        public static IEnumerable<string> SortableTagNames => SortableTags.Select(p => p.Name);
        public static IEnumerable<string> StringTagNames => StringTags.Select(p => p.Name);
        public static IEnumerable<string> TextTagNames => TextTags.Select(p => p.Name);
        public static IEnumerable<string> WritableTagNames => WritableTags.Select(p => p.Name);
        public static IEnumerable<string> WritableStringTagNames => WritableStringTags.Select(p => p.Name);
        public static IEnumerable<string> WritableTextTagNames => WritableTextTags.Select(p => p.Name);

        public static IEnumerable<TagProps> BrowsableTags => AllTags.Where(p => p.Browsable);
        public static IEnumerable<TagProps> FrequentlyUsedTags => AllTags.Where(p => p.FrequentlyUsed);
        public static IEnumerable<TagProps> ReadableTags => AllTags.Where(p => p.CanRead);
        public static IEnumerable<TagProps> SortableTags => AllTags.Where(p => p.CanSort);
        public static IEnumerable<TagProps> StringTags => AllTags.Where(p => p.IsString);
        public static IEnumerable<TagProps> TextTags => AllTags.Where(p => p.IsText);
        public static IEnumerable<TagProps> WritableTags => AllTags.Where(p => p.CanWrite);
        public static IEnumerable<TagProps> WritableStringTags => StringTags.Where(p => p.CanWrite);
        public static IEnumerable<TagProps> WritableTextTags => TextTags.Where(p => p.CanWrite);

        public static TagProps GetProps(this string propertyName) => AllTags.Single(p => p.Name == propertyName);

        public static bool Browsable(this string name) => name.GetProps().Browsable;
        public static bool CanRead(this string name) => name.GetProps().CanRead;
        public static bool CanSort(this string name) => name.GetProps().CanSort;
        public static bool CanWrite(this string name) => name.GetProps().CanWrite;
        public static string Category(this string name) => name.GetProps().Category;
        public static string Details(this string name) => name.GetProps().Details;
        public static string DisplayName(this string name) => name.GetProps().DisplayName;
        public static bool FrequentlyUsed(this string name) => name.GetProps().FrequentlyUsed;
        public static bool IsString(this string name) => name.GetProps().IsString;
        public static bool IsText(this string name) => name.GetProps().IsText;
        public static bool ReadOnly(this string name) => name.GetProps().ReadOnly;
        public static Type Type(this string name) => name.GetProps().Type;
        public static string TypeName(this string name) => name.GetProps().TypeName;

        public static IEnumerable<TagProps> GetDependencies(string name) => AllTags.Where(p => p.Uses.Contains(name));
        public static IEnumerable<string> GetDependencyNames(string name) => GetDependencies(name).Select(p => p.Name);

        public static string TagNameToLabel(string name) => AllTags.FirstOrDefault(p => p.Name == name)?.DisplayName;
        public static string TagLabelToName(string label) => AllTags.FirstOrDefault(p => p.DisplayName == label)?.Name;
        public static Type TagType(this string name) => AllTags.Single(p => p.Name == name).Type;

        public static void WriteBrowsableTags(IEnumerable<string> names)
        {
            foreach (var name in AllTagNames) SetBrowsable(name, names.Contains(name));
        }

        #endregion

        #region Private Implementation

        static Tags()
        {
            AllTags = new List<TagProps>();
            foreach (var info in typeof(Selection).GetProperties())
            {
                string
                    name = info.Name,
                    category = GetCategory(name);
                if (category == Selection.Selected)
                    continue;
                var tagProps = new TagProps
                {
                    Browsable = GetBrowsable(name),
                    CanRead = info.CanRead,
                    CanWrite = info.CanWrite,
                    Category = category,
                    Column = GetColumn(name),
                    Details = GetDescription(name),
                    DisplayName = GetDisplayName(name),
                    FrequentlyUsed = GetFrequentlyUsed(name),
                    Name = name,
                    ReadOnly = GetReadOnly(name),
                    Type = info.PropertyType,
                    Uses = GetUses(name),
                };
                tagProps.AdjustAlignment();
                AllTags.Add(tagProps);
            }
        }

        private static bool GetBrowsable(string name) => (bool)UseField(name, typeof(BrowsableAttribute), "browsable");
        private static string GetCategory(string name) => (string)UseField(name, typeof(CategoryAttribute), "categoryValue");
        private static Column GetColumn(string name) => (Column)UseField(name, typeof(ColumnAttribute), "_column");
        private static string GetDescription(string name) => (string)UseField(name, typeof(DescriptionAttribute), "description");
        private static string GetDisplayName(string name) => (string)UseField(name, typeof(DisplayNameAttribute), "_displayName");
        private static bool GetFrequentlyUsed(string name) => (bool)UseField(name, typeof(FrequentlyUsedAttribute), "_frequentlyUsed");
        private static bool GetReadOnly(string name) => (bool)UseField(name, typeof(ReadOnlyAttribute), "isReadOnly");
        private static IEnumerable<string> GetUses(string name) => (IEnumerable<string>)UseField(name, typeof(UsesAttribute), "_propertyNames");

        private static object UseField(string name, Type attrType, string field, object value = null) => typeof(Selection).UseField(name, attrType, field, value);

        public static object UseField(this Type type, string propName, Type attrType, string field, object value = null)
        {
            var attr = TypeDescriptor.GetProperties(type)[propName].Attributes[attrType];
            var info = attrType.GetField(field, BindingFlags.NonPublic | BindingFlags.Instance);
            if (value == null)
                value = info.GetValue(attr);
            else
                info.SetValue(attr, value);
            return value;
        }

        private static void SetBrowsable(string name, bool value)
        {
            var property = name.GetProps();
            if (property.Browsable != value)
            {
                UseField(name, typeof(BrowsableAttribute), "browsable", value);
                property.Browsable = value;
            }
        }

        #endregion
    }
}
