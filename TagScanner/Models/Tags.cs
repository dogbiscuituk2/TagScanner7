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
            Album = nameof(IWork.Album),
            AlbumArtists = nameof(IWork.AlbumArtists),
            AlbumArtistsCount = nameof(IWork.AlbumArtistsCount),
            AlbumArtistsSort = nameof(IWork.AlbumArtistsSort),
            AlbumArtistsSortCount = nameof(IWork.AlbumArtistsSortCount),
            AlbumGain = nameof(IWork.AlbumGain),
            AlbumPeak = nameof(IWork.AlbumPeak),
            AlbumSort = nameof(IWork.AlbumSort),
            AmazonId = nameof(IWork.AmazonId),
            Artists = nameof(IWork.Artists),
            ArtistsCount = nameof(IWork.ArtistsCount),
            AudioBitrate = nameof(IWork.AudioBitrate),
            AudioChannels = nameof(IWork.AudioChannels),
            AudioSampleRate = nameof(IWork.AudioSampleRate),
            BeatsPerMinute = nameof(IWork.BeatsPerMinute),
            BitsPerSample = nameof(IWork.BitsPerSample),
            Century = nameof(IWork.Century),
            Codecs = nameof(IWork.Codecs),
            Comment = nameof(IWork.Comment),
            Composers = nameof(IWork.Composers),
            ComposersCount = nameof(IWork.ComposersCount),
            ComposersSort = nameof(IWork.ComposersSort),
            ComposersSortCount = nameof(IWork.ComposersSortCount),
            Conductor = nameof(IWork.Conductor),
            Copyright = nameof(IWork.Copyright),
            Decade = nameof(IWork.Decade),
            Description = nameof(IWork.Description),
            DiscCount = nameof(IWork.DiscCount),
            DiscNumber = nameof(IWork.DiscNumber),
            DiscOf = nameof(IWork.DiscOf),
            DiscTrack = nameof(IWork.DiscTrack),
            Duration = nameof(IWork.Duration),
            FileAttributes = nameof(IWork.FileAttributes),
            FileCreationTime = nameof(IWork.FileCreationTime),
            FileCreationTimeUtc = nameof(IWork.FileCreationTimeUtc),
            FileExtension = nameof(IWork.FileExtension),
            FileLastAccessTime = nameof(IWork.FileLastAccessTime),
            FileLastAccessTimeUtc = nameof(IWork.FileLastAccessTimeUtc),
            FileLastWriteTime = nameof(IWork.FileLastWriteTime),
            FileLastWriteTimeUtc = nameof(IWork.FileLastWriteTimeUtc),
            FileName = nameof(IWork.FileName),
            FileNameWithoutExtension = nameof(IWork.FileNameWithoutExtension),
            FilePath = nameof(IWork.FilePath),
            FileSize = nameof(IWork.FileSize),
            FileStatus = nameof(IWork.FileStatus),
            FirstAlbumArtist = nameof(IWork.FirstAlbumArtist),
            FirstAlbumArtistSort = nameof(IWork.FirstAlbumArtistSort),
            FirstArtist = nameof(IWork.FirstArtist),
            FirstComposer = nameof(IWork.FirstComposer),
            FirstComposerSort = nameof(IWork.FirstComposerSort),
            FirstGenre = nameof(IWork.FirstGenre),
            FirstPerformer = nameof(IWork.FirstPerformer),
            FirstPerformerSort = nameof(IWork.FirstPerformerSort),
            Genres = nameof(IWork.Genres),
            GenresCount = nameof(IWork.GenresCount),
            Grouping = nameof(IWork.Grouping),
            ImageAltitude = nameof(IWork.ImageAltitude),
            ImageCreator = nameof(IWork.ImageCreator),
            ImageDateTime = nameof(IWork.ImageDateTime),
            ImageExposureTime = nameof(IWork.ImageExposureTime),
            ImageFNumber = nameof(IWork.ImageFNumber),
            ImageFocalLength = nameof(IWork.ImageFocalLength),
            ImageFocalLengthIn35mmFilm = nameof(IWork.ImageFocalLengthIn35mmFilm),
            ImageISOSpeedRatings = nameof(IWork.ImageISOSpeedRatings),
            ImageKeywords = nameof(IWork.ImageKeywords),
            ImageLatitude = nameof(IWork.ImageLatitude),
            ImageLongitude = nameof(IWork.ImageLongitude),
            ImageMake = nameof(IWork.ImageMake),
            ImageModel = nameof(IWork.ImageModel),
            ImageOrientation = nameof(IWork.ImageOrientation),
            ImageRating = nameof(IWork.ImageRating),
            ImageSoftware = nameof(IWork.ImageSoftware),
            InvariantEndPosition = nameof(IWork.InvariantEndPosition),
            InvariantStartPosition = nameof(IWork.InvariantStartPosition),
            IsClassical = nameof(IWork.IsClassical),
            IsEmpty = nameof(IWork.IsEmpty),
            JoinedAlbumArtists = nameof(IWork.JoinedAlbumArtists),
            JoinedArtists = nameof(IWork.JoinedArtists),
            JoinedComposers = nameof(IWork.JoinedComposers),
            JoinedGenres = nameof(IWork.JoinedGenres),
            JoinedPerformers = nameof(IWork.JoinedPerformers),
            JoinedPerformersSort = nameof(IWork.JoinedPerformersSort),
            Lyrics = nameof(IWork.Lyrics),
            MediaTypes = nameof(IWork.MediaTypes),
            Millennium = nameof(IWork.Millennium),
            MimeType = nameof(IWork.MimeType),
            MusicBrainzArtistId = nameof(IWork.MusicBrainzArtistId),
            MusicBrainzDiscId = nameof(IWork.MusicBrainzDiscId),
            MusicBrainzReleaseArtistId = nameof(IWork.MusicBrainzReleaseArtistId),
            MusicBrainzReleaseCountry = nameof(IWork.MusicBrainzReleaseCountry),
            MusicBrainzReleaseId = nameof(IWork.MusicBrainzReleaseId),
            MusicBrainzReleaseStatus = nameof(IWork.MusicBrainzReleaseStatus),
            MusicBrainzReleaseType = nameof(IWork.MusicBrainzReleaseType),
            MusicBrainzTrackId = nameof(IWork.MusicBrainzTrackId),
            MusicIpId = nameof(IWork.MusicIpId),
            Performers = nameof(IWork.Performers),
            PerformersCount = nameof(IWork.PerformersCount),
            PerformersSort = nameof(IWork.PerformersSort),
            PerformersSortCount = nameof(IWork.PerformersSortCount),
            PhotoHeight = nameof(IWork.PhotoHeight),
            PhotoQuality = nameof(IWork.PhotoQuality),
            PhotoWidth = nameof(IWork.PhotoWidth),
            Pictures = nameof(IWork.Pictures),
            PicturesCount = nameof(IWork.PicturesCount),
            PossiblyCorrupt = nameof(IWork.PossiblyCorrupt),
            TagTypes = nameof(IWork.TagTypes),
            TagTypesOnDisk = nameof(IWork.TagTypesOnDisk),
            Title = nameof(IWork.Title),
            TitleSort = nameof(IWork.TitleSort),
            TrackCount = nameof(IWork.TrackCount),
            TrackGain = nameof(IWork.TrackGain),
            TrackNumber = nameof(IWork.TrackNumber),
            TrackOf = nameof(IWork.TrackOf),
            TrackPeak = nameof(IWork.TrackPeak),
            VideoHeight = nameof(IWork.VideoHeight),
            VideoWidth = nameof(IWork.VideoWidth),
            Year = nameof(IWork.Year),
            YearAlbum = nameof(IWork.YearAlbum);

        #endregion

        public static List<TagProps> AllTags;

        public static IEnumerable<string> AllTagNames => AllTags.Select(p => p.Name);

        public static IEnumerable<string> BrowsableTagNames => BrowsableTags.Select(p => p.Name);

        public static IEnumerable<TagProps> BrowsableTags => AllTags.Where(p => p.Browsable);
        public static IEnumerable<TagProps> StringTags => AllTags.Where(p => p.IsString);
        public static IEnumerable<TagProps> TextTags => AllTags.Where(p => p.IsText);

        public static TagProps GetProps(this string propertyName) => AllTags.Single(p => p.Name == propertyName);

        public static IEnumerable<TagProps> GetDependencies(string name) => AllTags.Where(p => p.DirectUses.Contains(name));
        public static IEnumerable<string> GetDependencyNames(string name) => GetDependencies(name).Select(p => p.Name);

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
                    DirectUses = GetDirectUses(name),
                    DisplayName = GetDisplayName(name),
                    FrequentlyUsed = GetFrequentlyUsed(name),
                    Name = name,
                    ReadOnly = GetReadOnly(name),
                    Type = info.PropertyType,
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
        private static IEnumerable<string> GetDirectUses(string name) => (IEnumerable<string>)UseField(name, typeof(UsesAttribute), "_propertyNames");

        private static object UseField(string name, Type attrType, string field, object value = null) => typeof(Selection).UseField(name, attrType, field, value);

        public static object UseField(this Type type, string propName, Type attrType, string field, object value = null)
        {
            var attr = TypeDescriptor.GetProperties(type)[propName].Attributes[attrType];
            var info = attrType.GetField(field, BindingFlags.NonPublic | BindingFlags.Instance);
            if (value == null)
                value = info?.GetValue(attr);
            else
                info?.SetValue(attr, value);
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
