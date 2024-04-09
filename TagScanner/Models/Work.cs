namespace TagScanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Xml;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using Terms;
    using Utils;

    [Serializable]
    public class Work : IWork, INotifyPropertyChanged
    {
        #region Public Interface

        #region Constructors

        public Work() { }

        public Work(string filePath) : this()
        {
            FilePath = filePath;
            Load();
            IsNew = true;
        }

        #endregion

        #region Properties

        private bool FileExists => File.Exists(FilePath);

        [NonSerialized, XmlIgnore]
        public bool IsModified;

        [NonSerialized, XmlIgnore]
        public bool IsNew;

        #endregion

        #region IWork

        private string _album;
        public string Album
        {
            get => Get(_album);
            set => Set(ref _album, value, Tag.Album);
        }

        private string[] _albumArtists;
        public string[] AlbumArtists
        {
            get => Get(_albumArtists);
            set => Set(ref _albumArtists, value, Tag.AlbumArtists);
        }

        [JsonIgnore, XmlIgnore]
        public int AlbumArtistsCount => AlbumArtists.Length;

        private string[] _albumArtistsSort;
        public string[] AlbumArtistsSort
        {
            get => Get(_albumArtistsSort);
            set => Set(ref _albumArtistsSort, value, Tag.AlbumArtistsSort);
        }

        public int AlbumArtistsSortCount => AlbumArtistsSort.Length;

        private string _albumGain;
        public string AlbumGain
        {
            get => Get(_albumGain);
            set => Set(ref _albumGain, value, Tag.AlbumGain);
        }

        private string _albumPeak;
        public string AlbumPeak
        {
            get => Get(_albumPeak);
            set => Set(ref _albumPeak, value, Tag.AlbumPeak);
        }

        private string _albumSort;
        public string AlbumSort
        {
            get => Get(_albumSort);
            set => Set(ref _albumSort, value, Tag.AlbumSort);
        }

        private string _amazonId;
        public string AmazonId
        {
            get => Get(_amazonId);
            set => Set(ref _amazonId, value, Tag.AmazonId);
        }

        private string[] _artists;
        public string[] Artists
        {
            get => Get(_artists);
            set => Set(ref _artists, value, Tag.Artists);
        }

        [JsonIgnore, XmlIgnore]
        public int ArtistsCount => Artists.Length;

        public int AudioBitrate { get; set; }
        public int AudioChannels { get; set; }
        public int AudioSampleRate { get; set; }

        private int _beatsPerMinute;
        [DefaultValue(0)]
        public int BeatsPerMinute
        {
            get => _beatsPerMinute;
            set
            {
                if (BeatsPerMinute != value)
                {
                    _beatsPerMinute = value;
                    OnPropertyChanged(Tag.BeatsPerMinute);
                }
            }
        }

        public int BitsPerSample { get; set; }

        [JsonIgnore, XmlIgnore]
        public string Century => Year > 0 ? ((long)(Year + 99) / 100).AsOrdinal() : string.Empty;

        private string _codecs;
        public string Codecs
        {
            get => Get(_codecs);
            set => Set(ref _codecs, value, Tag.Codecs);
        }

        private string _comment;
        public string Comment
        {
            get => Get(_comment);
            set => Set(ref _comment, value, Tag.Comment);
        }

        private string[] _composers;
        public string[] Composers
        {
            get => Get(_composers);
            set => Set(ref _composers, value, Tag.Composers);
        }

        [JsonIgnore, XmlIgnore]
        public int ComposersCount => Composers.Length;

        private string[] _composersSort;
        public string[] ComposersSort
        {
            get => Get(_composersSort);
            set => Set(ref _composersSort, value, Tag.ComposersSort);
        }

        [JsonIgnore, XmlIgnore]
        public int ComposersSortCount => ComposersSort.Length;

        private string _conductor;
        public string Conductor
        {
            get => Get(_conductor);
            set => Set(ref _conductor, value, Tag.Conductor);
        }

        private string _copyright;
        public string Copyright
        {
            get => Get(_copyright);
            set => Set(ref _copyright, value, Tag.Copyright);
        }

        [JsonIgnore, XmlIgnore]
        public string Decade => Year > 0 ? $"{Year / 10}0s" : string.Empty;

        private string _description;
        public string Description
        {
            get => Get(_description);
            set => Set(ref _description, value, Tag.Description);
        }

        [DefaultValue(0)]
        private int _discCount;
        public int DiscCount
        {
            get => _discCount;
            set
            {
                if (DiscCount != value)
                {
                    _discCount = value;
                    OnPropertyChanged(Tag.DiscCount);
                }
            }
        }

        [DefaultValue(0)]
        private int _discNumber;
        public int DiscNumber
        {
            get => _discNumber;
            set
            {
                if (DiscNumber != value)
                {
                    _discNumber = value;
                    OnPropertyChanged(Tag.DiscNumber);
                }
            }
        }

        [JsonIgnore, XmlIgnore]
        public string DiscOf => NumberOfTotal(DiscNumber, DiscCount, 1);

        [JsonIgnore, XmlIgnore]
        public string DiscTrack => $"{DiscOf} - {TrackOf}";

        [XmlIgnore]
        public TimeSpan Duration { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonIgnore]
        [XmlElement(DataType = "duration", ElementName = "Duration")]
        public string DurationString
        {
            get => XmlConvert.ToString(Duration);
            set => Duration = string.IsNullOrWhiteSpace(value) ? TimeSpan.Zero : XmlConvert.ToTimeSpan(value);
        }

        public string FileAttributes { get; set; }
        public DateTime FileCreationTime { get; set; }
        public DateTime FileCreationTimeUtc { get; set; }

        [JsonIgnore, XmlIgnore]
        public string FileExtension => Path.GetExtension(FilePath);

        public DateTime FileLastAccessTime { get; set; }
        public DateTime FileLastAccessTimeUtc { get; set; }
        public DateTime FileLastWriteTime { get; set; }
        public DateTime FileLastWriteTimeUtc { get; set; }

        [JsonIgnore, XmlIgnore]
        public string FileName => Path.GetFileName(FilePath);

        [JsonIgnore, XmlIgnore]
        public string FileNameWithoutExtension => Path.GetFileNameWithoutExtension(FilePath);

        public string FilePath { get; set; }
        public long FileSize { get; set; }

        [JsonIgnore, XmlIgnore]
        public FileStatus FileStatus
        {
            get
            {
                if (!FileExists)
                    return FileStatus.Deleted;
                if (IsNew)
                    return IsModified ? FileStatus.New | FileStatus.Pending : FileStatus.New;
                if (IsModified)
                    return FileStatus.Pending;
                // TODO: check for resolution inaccuracies & daylight saving time transitions.
                var elapsedTime = FileLastWriteTimeUtc - File.GetLastWriteTimeUtc(FilePath);
                switch (Math.Sign(elapsedTime.Ticks))
                {
                    case +1:
                        return FileStatus.Pending;
                    case -1:
                        return FileStatus.Updated;
                }
                return FileStatus.Current;
            }
        }

        private string _firstAlbumArtist;
        public string FirstAlbumArtist
        {
            get => Get(_firstAlbumArtist);
            set => Set(ref _firstAlbumArtist, value, Tag.FirstAlbumArtist);
        }

        private string _firstAlbumArtistSort;
        public string FirstAlbumArtistSort
        {
            get => Get(_firstAlbumArtistSort);
            set => Set(ref _firstAlbumArtistSort, value, Tag.FirstAlbumArtistSort);
        }

        private string _firstArtist;
        public string FirstArtist
        {
            get => Get(_firstArtist);
            set => Set(ref _firstArtist, value, Tag.FirstArtist);
        }

        private string _firstComposer;
        public string FirstComposer
        {
            get => Get(_firstComposer);
            set => Set(ref _firstComposer, value, Tag.FirstComposer);
        }

        private string _firstComposerSort;
        public string FirstComposerSort
        {
            get => Get(_firstComposerSort);
            set => Set(ref _firstComposerSort, value, Tag.FirstComposerSort);
        }

        private string _firstGenre;
        public string FirstGenre
        {
            get => Get(_firstGenre);
            set => Set(ref _firstGenre, value, Tag.FirstGenre);
        }

        private string _firstPerformer;
        public string FirstPerformer
        {
            get => Get(_firstPerformer);
            set => Set(ref _firstPerformer, value, Tag.FirstPerformer);
        }

        private string _firstPerformerSort;
        public string FirstPerformerSort
        {
            get => Get(_firstPerformerSort);
            set => Set(ref _firstPerformerSort, value, Tag.FirstPerformerSort);
        }

        private string[] _genres;
        public string[] Genres
        {
            get => Get(_genres);
            set => Set(ref _genres, value, Tag.Genres);
        }

        [JsonIgnore, XmlIgnore]
        public int GenresCount => Genres.Length;

        private string _grouping;
        public string Grouping
        {
            get => Get(_grouping);
            set => Set(ref _grouping, value, Tag.Grouping);
        }

        [DefaultValue(0)] public double ImageAltitude { get; set; }

        private string _imageCreator;
        public string ImageCreator
        {
            get => Get(_imageCreator);
            set => Set(ref _imageCreator, value, Tag.ImageCreator);
        }

        public DateTime ImageDateTime { get; set; }

        [DefaultValue(0)] public double ImageExposureTime { get; set; }
        [DefaultValue(0)] public double ImageFNumber { get; set; }
        [DefaultValue(0)] public double ImageFocalLength { get; set; }
        [DefaultValue(0)] public int ImageFocalLengthIn35mmFilm { get; set; }
        [DefaultValue(0)] public int ImageISOSpeedRatings { get; set; }

        private string[] _imageKeywords;
        public string[] ImageKeywords
        {
            get => Get(_imageKeywords);
            set => Set(ref _imageKeywords, value, Tag.ImageKeywords);
        }

        [DefaultValue(0)] public double ImageLatitude { get; set; }
        [DefaultValue(0)] public double ImageLongitude { get; set; }

        private string _imageMake;
        public string ImageMake
        {
            get => Get(_imageMake);
            set => Set(ref _imageMake, value, Tag.ImageMake);
        }

        private string _imageModel;
        public string ImageModel
        {
            get => Get(_imageModel);
            set => Set(ref _imageModel, value, Tag.ImageModel);
        }

        [DefaultValue(TagLib.Image.ImageOrientation.None)]
        public TagLib.Image.ImageOrientation ImageOrientation { get; set; }

        [DefaultValue(0)] public int ImageRating { get; set; }

        private string _imageSoftware;
        public string ImageSoftware
        {
            get => Get(_imageSoftware);
            set => Set(ref _imageSoftware, value, Tag.ImageSoftware);
        }

        public long InvariantEndPosition { get; set; }
        public long InvariantStartPosition { get; set; }

        [JsonIgnore, XmlIgnore]
        public Logical IsClassical => (FirstGenre == "Classical").AsLogical();

        private bool _isEmpty;
        public Logical IsEmpty => _isEmpty.AsLogical();

        private string _joinedAlbumArtists;
        public string JoinedAlbumArtists
        {
            get => Get(_joinedAlbumArtists);
            set => Set(ref _joinedAlbumArtists, value, Tag.JoinedAlbumArtists);
        }

        private string _joinedArtists;
        public string JoinedArtists
        {
            get => Get(_joinedArtists);
            set => Set(ref _joinedArtists, value, Tag.JoinedArtists);
        }

        private string _joinedComposers;
        public string JoinedComposers
        {
            get => Get(_joinedComposers);
            set => Set(ref _joinedComposers, value, Tag.JoinedComposers);
        }

        private string _joinedGenres;
        public string JoinedGenres
        {
            get => Get(_joinedGenres);
            set => Set(ref _joinedGenres, value, Tag.JoinedGenres);
        }

        private string _joinedPerformers;
        public string JoinedPerformers
        {
            get => Get(_joinedPerformers);
            set => Set(ref _joinedPerformers, value, Tag.JoinedPerformers);
        }

        private string _joinedPerformersSort;
        public string JoinedPerformersSort
        {
            get => Get(_joinedPerformersSort);
            set => Set(ref _joinedPerformersSort, value, Tag.JoinedPerformersSort);
        }

        private string _lyrics;
        public string Lyrics
        {
            get => Get(_lyrics);
            set => Set(ref _lyrics, value, Tag.Lyrics);
        }

        public TagLib.MediaTypes MediaTypes { get; set; }

        [JsonIgnore, XmlIgnore]
        public string Millennium => Year > 0 ? ((long)(Year + 999) / 1000).AsOrdinal() : string.Empty;

        private string _mimeType;
        public string MimeType
        {
            get => Get(_mimeType);
            set => Set(ref _mimeType, value, Tag.MimeType);
        }

        private string _musicBrainzArtistId;
        public string MusicBrainzArtistId
        {
            get => Get(_musicBrainzArtistId);
            set => Set(ref _musicBrainzArtistId, value, Tag.MusicBrainzArtistId);
        }

        private string _musicBrainzDiscId;
        public string MusicBrainzDiscId
        {
            get => Get(_musicBrainzDiscId);
            set => Set(ref _musicBrainzDiscId, value, Tag.MusicBrainzDiscId);
        }

        private string _musicBrainzReleaseArtistId;
        public string MusicBrainzReleaseArtistId
        {
            get => Get(_musicBrainzReleaseArtistId);
            set => Set(ref _musicBrainzReleaseArtistId, value, Tag.MusicBrainzReleaseArtistId);
        }

        private string _musicBrainzReleaseCountry;
        public string MusicBrainzReleaseCountry
        {
            get => Get(_musicBrainzReleaseCountry);
            set => Set(ref _musicBrainzReleaseCountry, value, Tag.MusicBrainzReleaseCountry);
        }

        private string _musicBrainzReleaseId;
        public string MusicBrainzReleaseId
        {
            get => Get(_musicBrainzReleaseId);
            set => Set(ref _musicBrainzReleaseId, value, Tag.MusicBrainzReleaseId);
        }

        private string _musicBrainzReleaseStatus;
        public string MusicBrainzReleaseStatus
        {
            get => Get(_musicBrainzReleaseStatus);
            set => Set(ref _musicBrainzReleaseStatus, value, Tag.MusicBrainzReleaseStatus);
        }

        private string _musicBrainzReleaseType;
        public string MusicBrainzReleaseType
        {
            get => Get(_musicBrainzReleaseType);
            set => Set(ref _musicBrainzReleaseType, value, Tag.MusicBrainzReleaseType);
        }

        private string _musicBrainzTrackId;
        public string MusicBrainzTrackId
        {
            get => Get(_musicBrainzTrackId);
            set => Set(ref _musicBrainzTrackId, value, Tag.MusicBrainzTrackId);
        }

        private string _musicIpId;
        public string MusicIpId
        {
            get => Get(_musicIpId);
            set => Set(ref _musicIpId, value, Tag.MusicIpId);
        }

        public string Name { get; set; }

        private string[] _performers;
        public string[] Performers
        {
            get => Get(_performers);
            set => Set(ref _performers, value, Tag.Performers);
        }

        [JsonIgnore, XmlIgnore]
        public int PerformersCount => Performers.Length;

        private string[] _performersSort;
        public string[] PerformersSort
        {
            get => Get(_performersSort);
            set => Set(ref _performersSort, value, Tag.PerformersSort);
        }

        [JsonIgnore, XmlIgnore]
        public int PerformersSortCount => PerformersSort.Length;

        [DefaultValue(0)] public int PhotoHeight { get; set; }
        [DefaultValue(0)] public int PhotoQuality { get; set; }
        [DefaultValue(0)] public int PhotoWidth { get; set; }

        private Picture[] _pictures;
        public Picture[] Pictures
        {
            get => Get(_pictures);
            set => Set(ref _pictures, value, Tag.Pictures);
        }

        [NonSerialized]
        private int _picturesCount;
        [JsonIgnore, XmlIgnore]
        public int PicturesCount => _picturesCount;

        private bool _possiblyCorrupt;
        public Logical PossiblyCorrupt => _possiblyCorrupt.AsLogical();

        public TagLib.TagTypes TagTypes { get; set; }
        public TagLib.TagTypes TagTypesOnDisk { get; set; }

        private string _title;
        public string Title
        {
            get => Get(_title);
            set => Set(ref _title, value, Tag.Title);
        }

        private string _titleSort;
        public string TitleSort
        {
            get => Get(_titleSort);
            set => Set(ref _titleSort, value, Tag.TitleSort);
        }

        private int _trackCount;
        [DefaultValue(0)]
        public int TrackCount
        {
            get => _trackCount;
            set
            {
                if (TrackCount != value)
                {
                    _trackCount = value;
                    OnPropertyChanged(Tag.TrackCount);
                }
            }
        }

        private string _trackGain;
        public string TrackGain
        {
            get => Get(_trackGain);
            set => Set(ref _trackGain, value, Tag.TrackGain);
        }

        private int _trackNumber;
        [DefaultValue(0)]
        public int TrackNumber
        {
            get => _trackNumber;
            set
            {
                if (TrackNumber != value)
                {
                    _trackNumber = value;
                    OnPropertyChanged(Tag.TrackNumber);
                }
            }
        }

        [JsonIgnore, XmlIgnore]
        public string TrackOf => NumberOfTotal(TrackNumber, TrackCount, 2);

        private string _trackPeak;
        public string TrackPeak
        {
            get => Get(_trackPeak);
            set => Set(ref _trackPeak, value, Tag.TrackPeak);
        }

        [DefaultValue(0)] public int VideoHeight { get; set; }
        [DefaultValue(0)] public int VideoWidth { get; set; }

        private int _year;
        [DefaultValue(0)]
        public int Year
        {
            get => _year;
            set
            {
                if (Year != value)
                {
                    _year = value;
                    OnPropertyChanged(Tag.Year);
                }
            }
        }

        [JsonIgnore, XmlIgnore]
        public string YearAlbum => $"{Year} - {Album}";

        #endregion

        #region INotifyPropertyChanged

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        public object GetPropertyValue(Tag tag) => GetPropertyValue(tag.ToString());
        public object GetPropertyValue(string propertyName) => GetPropertyInfo(propertyName).GetValue(this);

        public void Load()
        {
            ReadMetadata();
            using (var file = GetTagLibFile())
                ReadFile(file);
            IsModified = false;
        }

        public void Save()
        {
            using (var file = GetTagLibFile())
            {
                WriteTag(file.Tag);
                file.Save();
            }
            Load();
        }

        public void SetPropertyValue(string propertyName, object value)
        {
            GetPropertyInfo(propertyName).SetValue(this, value);
            OnPropertyChanged(propertyName);
        }

        public override string ToString() => $"{JoinedPerformers} | {YearAlbum} | {TrackOf} {Title} ({Duration.AsString(false)}) {FileSize.AsString(true)}";

        #endregion

        #endregion

        #region Private Methods

        private string Get(string field) => field ?? string.Empty;

        private T[] Get<T>(T[] field) => field ?? Array.Empty<T>();

        private static PropertyInfo GetPropertyInfo(string propertyName) => typeof(Work).GetProperty(propertyName);

        private TagLib.File GetTagLibFile() => TagLib.File.Create(FilePath);

        private void InvokeHandler(PropertyChangedEventHandler propertyChanged, Tag propertyTag) => InvokeHandler(propertyChanged, propertyTag.ToString());

        private void InvokeHandler(PropertyChangedEventHandler propertyChanged, string propertyName)
        {
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            foreach (var dependentPropertyName in Tags.GetDependencyNames(propertyName))
                InvokeHandler(propertyChanged, dependentPropertyName);
        }

        protected virtual void OnPropertyChanged(Tag propertyTag) => OnPropertyChanged(propertyTag.ToString());

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged == null) // Are we just now streaming in, using XML?
                return; // Yes: then property accessors should have no side effects.
            IsModified = true;
            InvokeHandler(propertyChanged, propertyName);
            InvokeHandler(propertyChanged, Tag.FileStatus);
        }

        private void ReadFile(TagLib.File file)
        {
            if (file == null)
                return;
            InvariantEndPosition = file.InvariantEndPosition;
            InvariantStartPosition = file.InvariantStartPosition;
            MimeType = file.MimeType;
            Name = file.Name;
            _possiblyCorrupt = file.PossiblyCorrupt;
            TagTypes = file.TagTypes;
            TagTypesOnDisk = file.TagTypesOnDisk;
            ReadProperties(file.Properties);
            ReadTag(file.Tag);
        }

        private void ReadMetadata()
        {
            FileSize = new FileInfo(FilePath).Length;
            FileAttributes = File.GetAttributes(FilePath).ToString();
            FileCreationTime = File.GetCreationTimeUtc(FilePath);
            FileLastWriteTime = File.GetLastWriteTimeUtc(FilePath);
            FileLastAccessTime = File.GetLastAccessTimeUtc(FilePath);
            FileCreationTimeUtc = File.GetCreationTimeUtc(FilePath);
            FileLastWriteTimeUtc = File.GetLastWriteTimeUtc(FilePath);
            FileLastAccessTimeUtc = File.GetLastAccessTimeUtc(FilePath);
        }

        private void ReadProperties(TagLib.Properties properties)
        {
            if (properties == null)
                return;
            AudioBitrate = properties.AudioBitrate;
            AudioChannels = properties.AudioChannels;
            AudioSampleRate = properties.AudioSampleRate;
            BitsPerSample = properties.BitsPerSample;
            Codecs = properties.Codecs
                .Where(c => c != null)
                .Select(c => $"{c.MediaTypes} ({c.Description} - {c.Duration:g})")
                .Aggregate((s, t) => s + "; " + t);
            Description = properties.Description;
            Duration = properties.Duration;
            MediaTypes = properties.MediaTypes; // 0 = None, 1 = Audio, 2 = Video, 4 = Photo, 8 = Text.
            PhotoHeight = properties.PhotoHeight;
            PhotoQuality = properties.PhotoQuality;
            PhotoWidth = properties.PhotoWidth;
            VideoHeight = properties.VideoHeight;
            VideoWidth = properties.VideoWidth;
        }

        private void ReadTag(TagLib.Tag tag)
        {
            if (tag == null)
                return;
            _album = tag.Album;
            _albumArtists = tag.AlbumArtists;
            _albumArtistsSort = tag.AlbumArtistsSort;
            _albumSort = tag.AlbumSort;
            _amazonId = tag.AmazonId;
#pragma warning disable 612, 618
            _artists = tag.Artists;
#pragma warning restore 612, 618
            _beatsPerMinute = (int)tag.BeatsPerMinute;
            _comment = tag.Comment;
            _composers = tag.Composers;
            _composersSort = tag.ComposersSort;
            _conductor = tag.Conductor;
            _copyright = tag.Copyright;
            _discNumber = (int)tag.Disc;
            _discCount = (int)tag.DiscCount;
            FirstAlbumArtist = tag.FirstAlbumArtist;
            FirstAlbumArtistSort = tag.FirstAlbumArtistSort;
#pragma warning disable 612, 618
            FirstArtist = tag.FirstArtist;
#pragma warning restore 612, 618
            FirstComposer = tag.FirstComposer;
            FirstComposerSort = tag.FirstComposerSort;
            FirstGenre = tag.FirstGenre;
            FirstPerformer = tag.FirstPerformer;
            FirstPerformerSort = tag.FirstPerformerSort;
            _genres = tag.Genres;
            _grouping = tag.Grouping;
            _isEmpty = tag.IsEmpty;
            JoinedAlbumArtists = tag.JoinedAlbumArtists;
#pragma warning disable 612, 618
            JoinedArtists = tag.JoinedArtists;
#pragma warning restore 612, 618
            JoinedComposers = tag.JoinedComposers;
            JoinedGenres = tag.JoinedGenres;
            JoinedPerformers = tag.JoinedPerformers;
            JoinedPerformersSort = tag.JoinedPerformersSort;
            _lyrics = tag.Lyrics;
            _musicBrainzArtistId = tag.MusicBrainzArtistId;
            _musicBrainzDiscId = tag.MusicBrainzDiscId;
            _musicBrainzReleaseArtistId = tag.MusicBrainzReleaseArtistId;
            _musicBrainzReleaseCountry = tag.MusicBrainzReleaseCountry;
            _musicBrainzReleaseId = tag.MusicBrainzReleaseId;
            _musicBrainzReleaseStatus = tag.MusicBrainzReleaseStatus;
            _musicBrainzReleaseType = tag.MusicBrainzReleaseType;
            _musicBrainzTrackId = tag.MusicBrainzTrackId;
            _musicIpId = tag.MusicIpId;
            _performers = tag.Performers;
            _performersSort = tag.PerformersSort;
            _picturesCount = tag.Pictures.Length;
            var pictureIndex = 0;
            Pictures = tag.Pictures.Select(p => new Picture(FilePath, pictureIndex++, p)).ToArray();
            _title = tag.Title;
            _titleSort = tag.TitleSort;
            _trackNumber = (int)tag.Track;
            _trackCount = (int)tag.TrackCount;
            _year = (int)tag.Year;
            ReadTagExtra(tag);
        }

        private void ReadTagExtra(TagLib.Tag tag)
        {
            if (tag is TagLib.CombinedTag combinedTag) // Including subtype TagLib.NonContainer.Tag
                ReadTagUserText(combinedTag);
            else if (tag is TagLib.Asf.Tag asfTag)
                ReadTagUserTextAsf(asfTag);
            else if (tag is TagLib.Image.ImageTag imageTag)
                ReadTagImageData(imageTag);
        }

        private void ReadTagImageData(TagLib.Image.ImageTag tag)
        {
            ImageAltitude = tag.Altitude ?? 0;
            ImageCreator = tag.Creator;
            ImageDateTime = tag.DateTime ?? DateTime.MinValue;
            ImageExposureTime = tag.ExposureTime ?? 0;
            ImageFNumber = tag.FNumber ?? 0;
            ImageFocalLength = tag.FocalLength ?? 0;
            ImageFocalLengthIn35mmFilm = (int)(tag.FocalLengthIn35mmFilm ?? 0);
            ImageISOSpeedRatings = (int)(tag.ISOSpeedRatings ?? 0);
            ImageKeywords = tag.Keywords;
            ImageLatitude = tag.Latitude ?? 0;
            ImageLongitude = tag.Longitude ?? 0;
            ImageMake = tag.Make;
            ImageModel = tag.Model;
            ImageOrientation = tag.Orientation;
            ImageRating = (int)(tag.Rating ?? 0);
            ImageSoftware = tag.Software;
        }

        private void ReadTagUserText(TagLib.CombinedTag tag)
        {
            var id3v2Tag = tag.Tags.OfType<TagLib.Id3v2.Tag>().FirstOrDefault();
            if (id3v2Tag != null)
                foreach (var frame in id3v2Tag.OfType<TagLib.Id3v2.UserTextInformationFrame>())
                    SetUserValue(frame.Description, frame.Text.FirstOrDefault());
        }

        private void ReadTagUserTextAsf(TagLib.Asf.Tag tag)
        {
            foreach (var frame in tag)
                SetUserValue(frame.Name, frame.ToString());
        }

        private void SetUserValue(string name, string value)
        {
            switch (name)
            {
                case "replaygain_album_gain": AlbumGain = value; break;
                case "replaygain_album_peak": AlbumPeak = value; break;
                case "replaygain_track_gain": TrackGain = value; break;
                case "replaygain_track_peak": TrackPeak = value; break;
            }
        }

        private void WriteTag(TagLib.Tag tag)
        {
            if (tag == null)
                return;
            tag.Album = _album;
            tag.AlbumArtists = _albumArtists;
            tag.AlbumArtistsSort = _albumArtistsSort;
            tag.AlbumSort = _albumSort;
            tag.AmazonId = _amazonId;
#pragma warning disable 612, 618
            tag.Artists = _artists;
#pragma warning restore 612, 618
            tag.BeatsPerMinute = (uint)_beatsPerMinute;
            tag.Comment = _comment;
            tag.Composers = _composers;
            tag.ComposersSort = _composersSort;
            tag.Conductor = _conductor;
            tag.Copyright = _copyright;
            tag.Disc = (uint)_discNumber;
            tag.DiscCount = (uint)_discCount;
            tag.Genres = _genres;
            tag.Grouping = _grouping;
            tag.Lyrics = _lyrics;
            tag.MusicBrainzArtistId = _musicBrainzArtistId;
            tag.MusicBrainzDiscId = _musicBrainzDiscId;
            tag.MusicBrainzReleaseArtistId = _musicBrainzReleaseArtistId;
            tag.MusicBrainzReleaseCountry = _musicBrainzReleaseCountry;
            tag.MusicBrainzReleaseId = _musicBrainzReleaseId;
            tag.MusicBrainzReleaseStatus = _musicBrainzReleaseStatus;
            tag.MusicBrainzReleaseType = _musicBrainzReleaseType;
            tag.MusicBrainzTrackId = _musicBrainzTrackId;
            tag.MusicIpId = _musicIpId;
            tag.Performers = _performers;
            tag.PerformersSort = _performersSort;
            tag.Title = _title;
            tag.TitleSort = _titleSort;
            tag.Track = (uint)_trackNumber;
            tag.TrackCount = (uint)_trackCount;
            tag.Year = (uint)_year;
            if (tag is TagLib.Image.ImageTag imageTag)
                WriteTagImageData(imageTag);
        }

        private void WriteTagImageData(TagLib.Image.ImageTag imageTag)
        {
            imageTag.Altitude = ImageAltitude;
            imageTag.Creator = ImageCreator;
            imageTag.DateTime = ImageDateTime;
            imageTag.ExposureTime = ImageExposureTime;
            imageTag.FNumber = ImageFNumber;
            imageTag.FocalLength = ImageFocalLength;
            imageTag.FocalLengthIn35mmFilm = (uint)ImageFocalLengthIn35mmFilm;
            imageTag.ISOSpeedRatings = (uint)ImageISOSpeedRatings;
            imageTag.Keywords = ImageKeywords;
            imageTag.Latitude = ImageLatitude;
            imageTag.Longitude = ImageLongitude;
            imageTag.Make = ImageMake;
            imageTag.Model = ImageModel;
            imageTag.Orientation = ImageOrientation;
            imageTag.Rating = (uint)ImageRating;
            imageTag.Software = ImageSoftware;
        }

        private static string NumberOfTotal(int number, int total, int digits)
        {
            number = Math.Max(number, 1);
            total = Math.Max(number, total);
            digits = Math.Max(digits, total.ToString().Length);
            return string.Format($"{{0:D{digits}}}/{{1:D{digits}}}", number, total);
        }

        private static bool SequenceEqual<T>(IEnumerable<T> x, IEnumerable<T> y) =>
            x != null ? y != null && x.SequenceEqual(y) : y == null;

        private void Set(ref string field, string value, Tag tag)
        {
            if (field == value) return;
            field = value;
            OnPropertyChanged(tag);
        }

        private void Set<T>(ref T[] field, T[] value, Tag tag)
        {
            if (SequenceEqual(field, value)) return;
            field = value;
            OnPropertyChanged(tag);
        }

        #endregion
    }
}
