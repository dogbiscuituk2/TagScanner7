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
    using Utils;

    [Serializable]
    public class Work : IWork
    {
        #region Constructors

        public Work() { }

        public Work(string filePath) : this()
        {
            _filePath = filePath;
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

        [field: NonSerialized]
        public event EventHandler<WorksEditEventArgs> Edit;

        #endregion

        #region IWork

        private string _album = string.Empty;
        [DefaultValue("")]
        public string Album
        {
            get => Get(_album);
            set => Set(ref _album, value);
        }

        private string[] _albumArtists;
        public string[] AlbumArtists
        {
            get => Get(_albumArtists);
            set => Set(ref _albumArtists, value);
        }

        [JsonIgnore, XmlIgnore]
        public int AlbumArtistsCount => AlbumArtists.Length;

        private string[] _albumArtistsSort;
        public string[] AlbumArtistsSort
        {
            get => Get(_albumArtistsSort);
            set => Set(ref _albumArtistsSort, value);
        }

        public int AlbumArtistsSortCount => AlbumArtistsSort.Length;

        private string _albumGain = string.Empty;
        [DefaultValue("")]
        public string AlbumGain
        {
            get => Get(_albumGain);
            set => Set(ref _albumGain, value);
        }

        private string _albumPeak = string.Empty;
        [DefaultValue("")]
        public string AlbumPeak
        {
            get => Get(_albumPeak);
            set => Set(ref _albumPeak, value);
        }

        private string _albumSort = string.Empty;
        [DefaultValue("")]
        public string AlbumSort
        {
            get => Get(_albumSort);
            set => Set(ref _albumSort, value);
        }

        private string _amazonId = string.Empty;
        [DefaultValue("")]
        public string AmazonId
        {
            get => Get(_amazonId);
            set => Set(ref _amazonId, value);
        }

        private string[] _artists;
        public string[] Artists
        {
            get => Get(_artists);
            set => Set(ref _artists, value);
        }

        [JsonIgnore, XmlIgnore]
        public int ArtistsCount => Artists.Length;

        private int _audioBitrate;
        public int AudioBitrate
        {
            get => _audioBitrate;
            set => Set(ref _audioBitrate, value);
        }

        private int _audioChannels;
        public int AudioChannels
        {
            get => _audioChannels;
            set => Set(ref _audioChannels, value);
        }

        private int _audioSampleRate = 44100;
        [DefaultValue(44100)]
        public int AudioSampleRate
        {
            get => _audioSampleRate;
            set => Set(ref _audioSampleRate, value);
        }

        private int _beatsPerMinute;
        [DefaultValue(0)]
        public int BeatsPerMinute
        {
            get => _beatsPerMinute;
            set => Set(ref _beatsPerMinute, value);
        }

        private int _bitsPerSample;
        [DefaultValue(0)]
        public int BitsPerSample
        {
            get => _bitsPerSample;
            set => Set(ref _bitsPerSample, value);
        }

        [JsonIgnore, XmlIgnore]
        public string Century => Year > 0 ? ((long)(Year + 99) / 100).AsOrdinal() : string.Empty;

        private string _codecs = string.Empty;
        [DefaultValue("")]
        public string Codecs
        {
            get => Get(_codecs);
            set => Set(ref _codecs, value);
        }

        private string _comment = string.Empty;
        [DefaultValue("")]
        public string Comment
        {
            get => Get(_comment);
            set => Set(ref _comment, value);
        }

        private string[] _composers;
        public string[] Composers
        {
            get => Get(_composers);
            set => Set(ref _composers, value);
        }

        [JsonIgnore, XmlIgnore]
        public int ComposersCount => Composers.Length;

        private string[] _composersSort;
        public string[] ComposersSort
        {
            get => Get(_composersSort);
            set => Set(ref _composersSort, value);
        }

        [JsonIgnore, XmlIgnore]
        public int ComposersSortCount => ComposersSort.Length;

        private string _conductor = string.Empty;
        [DefaultValue("")]
        public string Conductor
        {
            get => Get(_conductor);
            set => Set(ref _conductor, value);
        }

        private string _copyright = string.Empty;
        [DefaultValue("")]
        public string Copyright
        {
            get => Get(_copyright);
            set => Set(ref _copyright, value);
        }

        [JsonIgnore, XmlIgnore]
        public string Decade => Year > 0 ? $"{Year / 10}0s" : string.Empty;

        private string _description = string.Empty;
        [DefaultValue("")]
        public string Description
        {
            get => Get(_description);
            set => Set(ref _description, value);
        }

        private int _discCount;
        [DefaultValue(0)]
        public int DiscCount
        {
            get => _discCount;
            set => Set(ref _discCount, value);
        }

        private int _discNumber;
        [DefaultValue(0)]
        public int DiscNumber
        {
            get => _discNumber;
            set => Set(ref _discNumber, value);
        }

        [JsonIgnore, XmlIgnore]
        public string DiscOf => GetNumberOfTotal(DiscNumber, DiscCount, 1);

        [JsonIgnore, XmlIgnore]
        public string DiscTrack => $"{DiscOf} - {TrackOf}";

        private TimeSpan _duration;
        [XmlIgnore] public TimeSpan Duration
        {
            get => _duration;
            set => Set(ref _duration, value);
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonIgnore]
        [XmlElement(DataType = "duration", ElementName = "Duration")]
        public string DurationString
        {
            get => XmlConvert.ToString(Duration);
            set => Duration = string.IsNullOrWhiteSpace(value) ? TimeSpan.Zero : XmlConvert.ToTimeSpan(value);
        }

        private string _fileAttributes = string.Empty;
        [DefaultValue("")]
        public string FileAttributes
        {
            get => Get(_fileAttributes);
            set => Set(ref _fileAttributes, value);
        }

        private DateTime _fileCreationTime;
        public DateTime FileCreationTime
        {
            get => _fileCreationTime;
            set => Set(ref _fileCreationTime, value);
        }

        private DateTime _fileCreationTimeUtc;
        public DateTime FileCreationTimeUtc
        {
            get => _fileCreationTimeUtc;
            set => Set(ref _fileCreationTimeUtc, value);
        }

        [JsonIgnore, XmlIgnore]
        public string FileExtension => Path.GetExtension(FilePath);

        private DateTime _fileLastAccessTime;
        public DateTime FileLastAccessTime
        {
            get => _fileLastAccessTime;
            set => Set(ref _fileLastAccessTime, value);
        }

        private DateTime _fileLastAccessTimeUtc;
        public DateTime FileLastAccessTimeUtc
        {
            get => _fileLastAccessTimeUtc;
            set => Set(ref _fileLastAccessTimeUtc, value);
        }

        private DateTime _fileLastWriteTime;
        public DateTime FileLastWriteTime
        {
            get => _fileLastWriteTime;
            set => Set(ref _fileLastWriteTime, value);
        }

        private DateTime _fileLastWriteTimeUtc;
        public DateTime FileLastWriteTimeUtc
        {
            get => _fileLastWriteTimeUtc;
            set => Set(ref _fileLastWriteTimeUtc, value);
        }

        [JsonIgnore, XmlIgnore]
        public string FileName => Path.GetFileName(FilePath);

        [JsonIgnore, XmlIgnore]
        public string FileNameWithoutExtension => Path.GetFileNameWithoutExtension(FilePath);

        private string _filePath;
        public string FilePath
        {
            get => Get(_filePath);
            set => Set(ref _filePath, value);
        }

        private long _fileSize;
        public long FileSize
        {
            get => _fileSize;
            set => Set(ref _fileSize, value);
        }

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

        private string _firstAlbumArtist = string.Empty;
        [DefaultValue("")]
        public string FirstAlbumArtist
        {
            get => Get(_firstAlbumArtist);
            set => Set(ref _firstAlbumArtist, value);
        }

        private string _firstAlbumArtistSort = string.Empty;
        [DefaultValue("")]
        public string FirstAlbumArtistSort
        {
            get => Get(_firstAlbumArtistSort);
            set => Set(ref _firstAlbumArtistSort, value);
        }

        private string _firstArtist = string.Empty;
        [DefaultValue("")]
        public string FirstArtist
        {
            get => Get(_firstArtist);
            set => Set(ref _firstArtist, value);
        }

        private string _firstComposer = string.Empty;
        [DefaultValue("")]
        public string FirstComposer
        {
            get => Get(_firstComposer);
            set => Set(ref _firstComposer, value);
        }

        private string _firstComposerSort = string.Empty;
        [DefaultValue("")]
        public string FirstComposerSort
        {
            get => Get(_firstComposerSort);
            set => Set(ref _firstComposerSort, value);
        }

        private string _firstGenre = string.Empty;
        [DefaultValue("")]
        public string FirstGenre
        {
            get => Get(_firstGenre);
            set => Set(ref _firstGenre, value);
        }

        private string _firstPerformer = string.Empty;
        [DefaultValue("")]
        public string FirstPerformer
        {
            get => Get(_firstPerformer);
            set => Set(ref _firstPerformer, value);
        }

        private string _firstPerformerSort = string.Empty;
        [DefaultValue("")]
        public string FirstPerformerSort
        {
            get => Get(_firstPerformerSort);
            set => Set(ref _firstPerformerSort, value);
        }

        private string[] _genres;
        public string[] Genres
        {
            get => Get(_genres);
            set => Set(ref _genres, value);
        }

        [JsonIgnore, XmlIgnore]
        public int GenresCount => Genres.Length;

        private string _grouping = string.Empty;
        [DefaultValue("")]
        public string Grouping
        {
            get => Get(_grouping);
            set => Set(ref _grouping, value);
        }

        private double _imageAltitude;
        [DefaultValue(0.0D)] public double ImageAltitude
        {
            get => _imageAltitude;
            set => Set(ref _imageAltitude, value);
        }

        private string _imageCreator = string.Empty;
        [DefaultValue("")]
        public string ImageCreator
        {
            get => Get(_imageCreator);
            set => Set(ref _imageCreator, value);
        }

        private DateTime _imageDateTime;
        public DateTime ImageDateTime
        {
            get => _imageDateTime;
            set => Set(ref _imageDateTime, value);
        }

        private double _imageExposureTime;
        [DefaultValue(0.0D)]
        public double ImageExposureTime
        {
            get => _imageExposureTime;
            set => Set(ref _imageExposureTime, value);
        }

        private double _imageFNumber;
        [DefaultValue(0.0D)]
        public double ImageFNumber
        {
            get => _imageFNumber;
            set => Set(ref _imageFNumber, value);
        }

        private double _imageFocalLength;
        [DefaultValue(0.0D)]
        public double ImageFocalLength
        {
            get => _imageFocalLength;
            set => Set(ref _imageFocalLength, value);
        }

        private int _imageFocalLengthIn35mmFilm;
        [DefaultValue(0)]
        public int ImageFocalLengthIn35mmFilm
        {
            get => _imageFocalLengthIn35mmFilm;
            set => Set(ref _imageFocalLengthIn35mmFilm, value);
        }

        private int _imageISOSpeedRatings;
        [DefaultValue(0)]
        public int ImageISOSpeedRatings
        {
            get => _imageISOSpeedRatings;
            set => Set(ref _imageISOSpeedRatings, value);
        }

        private string[] _imageKeywords;
        public string[] ImageKeywords
        {
            get => Get(_imageKeywords);
            set => Set(ref _imageKeywords, value);
        }

        private double _imageLatitude;
        [DefaultValue(0.0D)]
        public double ImageLatitude
        {
            get => _imageLatitude;
            set => Set(ref _imageLatitude, value);
        }

        private double _imageLongitude;
        [DefaultValue(0.0D)]
        public double ImageLongitude
        {
            get => _imageLongitude;
            set => Set(ref _imageLongitude, value);
        }

        private string _imageMake = string.Empty;
        [DefaultValue("")]
        public string ImageMake
        {
            get => Get(_imageMake);
            set => Set(ref _imageMake, value);
        }

        private string _imageModel = string.Empty;
        [DefaultValue("")]
        public string ImageModel
        {
            get => Get(_imageModel);
            set => Set(ref _imageModel, value);
        }

        private TagLib.Image.ImageOrientation _imageOrientation;
        [DefaultValue(TagLib.Image.ImageOrientation.None)]
        public TagLib.Image.ImageOrientation ImageOrientation
        {
            get => _imageOrientation;
            set => Set(ref _imageOrientation, value);
        }

        private int _imageRating;
        [DefaultValue(0)]
        public int ImageRating
        {
            get => _imageRating;
            set => Set(ref _imageRating, value);
        }

        private string _imageSoftware = string.Empty;
        [DefaultValue("")]
        public string ImageSoftware
        {
            get => Get(_imageSoftware);
            set => Set(ref _imageSoftware, value);
        }

        private long _invariantEndPosition;
        public long InvariantEndPosition
        {
            get => _invariantEndPosition;
            set => Set(ref _invariantEndPosition, value);
        }

        private long _invariantStartPosition;
        public long InvariantStartPosition
        {
            get => _invariantStartPosition;
            set => Set(ref _invariantStartPosition, value);
        }

        [JsonIgnore, XmlIgnore]
        public Logical IsClassical => (FirstGenre == "Classical").AsLogical();

        private bool _isEmpty;
        public Logical IsEmpty
        {
            get => _isEmpty.AsLogical();
            set => Set(ref _isEmpty, value == Logical.Yes);
        }

        private string _joinedAlbumArtists = string.Empty;
        [DefaultValue("")]
        public string JoinedAlbumArtists
        {
            get => Get(_joinedAlbumArtists);
            set => Set(ref _joinedAlbumArtists, value);
        }

        private string _joinedArtists = string.Empty;
        [DefaultValue("")]
        public string JoinedArtists
        {
            get => Get(_joinedArtists);
            set => Set(ref _joinedArtists, value);
        }

        private string _joinedComposers = string.Empty;
        [DefaultValue("")]
        public string JoinedComposers
        {
            get => Get(_joinedComposers);
            set => Set(ref _joinedComposers, value);
        }

        private string _joinedGenres = string.Empty;
        [DefaultValue("")]
        public string JoinedGenres
        {
            get => Get(_joinedGenres);
            set => Set(ref _joinedGenres, value);
        }

        private string _joinedPerformers = string.Empty;
        [DefaultValue("")]
        public string JoinedPerformers
        {
            get => Get(_joinedPerformers);
            set => Set(ref _joinedPerformers, value);
        }

        private string _joinedPerformersSort = string.Empty;
        [DefaultValue("")]
        public string JoinedPerformersSort
        {
            get => Get(_joinedPerformersSort);
            set => Set(ref _joinedPerformersSort, value);
        }

        private string _lyrics = string.Empty;
        [DefaultValue("")]
        public string Lyrics
        {
            get => Get(_lyrics);
            set => Set(ref _lyrics, value);
        }

        private TagLib.MediaTypes _mediaTypes;
        public TagLib.MediaTypes MediaTypes
        {
            get => _mediaTypes;
            set => Set(ref _mediaTypes, value);
        }

        [JsonIgnore, XmlIgnore]
        public string Millennium => Year > 0 ? ((long)(Year + 999) / 1000).AsOrdinal() : string.Empty;

        private string _mimeType = string.Empty;
        [DefaultValue("")]
        public string MimeType
        {
            get => Get(_mimeType);
            set => Set(ref _mimeType, value);
        }

        private string _musicBrainzArtistId = string.Empty;
        [DefaultValue("")]
        public string MusicBrainzArtistId
        {
            get => Get(_musicBrainzArtistId);
            set => Set(ref _musicBrainzArtistId, value);
        }

        private string _musicBrainzDiscId = string.Empty;
        [DefaultValue("")]
        public string MusicBrainzDiscId
        {
            get => Get(_musicBrainzDiscId);
            set => Set(ref _musicBrainzDiscId, value);
        }

        private string _musicBrainzReleaseArtistId = string.Empty;
        [DefaultValue("")]
        public string MusicBrainzReleaseArtistId
        {
            get => Get(_musicBrainzReleaseArtistId);
            set => Set(ref _musicBrainzReleaseArtistId, value);
        }

        private string _musicBrainzReleaseCountry = string.Empty;
        [DefaultValue("")]
        public string MusicBrainzReleaseCountry
        {
            get => Get(_musicBrainzReleaseCountry);
            set => Set(ref _musicBrainzReleaseCountry, value);
        }

        private string _musicBrainzReleaseId = string.Empty;
        [DefaultValue("")]
        public string MusicBrainzReleaseId
        {
            get => Get(_musicBrainzReleaseId);
            set => Set(ref _musicBrainzReleaseId, value);
        }

        private string _musicBrainzReleaseStatus = string.Empty;
        [DefaultValue("")]
        public string MusicBrainzReleaseStatus
        {
            get => Get(_musicBrainzReleaseStatus);
            set => Set(ref _musicBrainzReleaseStatus, value);
        }

        private string _musicBrainzReleaseType = string.Empty;
        [DefaultValue("")]
        public string MusicBrainzReleaseType
        {
            get => Get(_musicBrainzReleaseType);
            set => Set(ref _musicBrainzReleaseType, value);
        }

        private string _musicBrainzTrackId = string.Empty;
        [DefaultValue("")]
        public string MusicBrainzTrackId
        {
            get => Get(_musicBrainzTrackId);
            set => Set(ref _musicBrainzTrackId, value);
        }

        private string _musicIpId = string.Empty;
        [DefaultValue("")]
        public string MusicIpId
        {
            get => Get(_musicIpId);
            set => Set(ref _musicIpId, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        private string[] _performers;
        public string[] Performers
        {
            get => Get(_performers);
            set => Set(ref _performers, value);
        }

        [JsonIgnore, XmlIgnore]
        public int PerformersCount => Performers.Length;

        private string[] _performersSort;
        public string[] PerformersSort
        {
            get => Get(_performersSort);
            set => Set(ref _performersSort, value);
        }

        [JsonIgnore, XmlIgnore]
        public int PerformersSortCount => PerformersSort.Length;

        private int _photoHeight;
        [DefaultValue(0)]
        public int PhotoHeight
        {
            get => _photoHeight;
            set => Set(ref _photoHeight, value);
        }

        private int _photoQuality;
        [DefaultValue(0)]
        public int PhotoQuality
        {
            get => _photoQuality;
            set => Set(ref _photoQuality, value);
        }

        private int _photoWidth;
        [DefaultValue(0)]
        public int PhotoWidth
        {
            get => _photoWidth;
            set => Set(ref _photoWidth, value);
        }

        private Picture[] _pictures;
        public Picture[] Pictures
        {
            get => Get(_pictures);
            set => Set(ref _pictures, value);
        }

        [NonSerialized]
        private int _picturesCount;
        [JsonIgnore, XmlIgnore]
        public int PicturesCount => _picturesCount;

        private bool _possiblyCorrupt;
        public Logical PossiblyCorrupt
        {
            get => _possiblyCorrupt.AsLogical();
            set => Set(ref _possiblyCorrupt, value == Logical.Yes);
        }

        private TagLib.TagTypes _tagTypes;
        public TagLib.TagTypes TagTypes
        {
            get => _tagTypes;
            set => Set(ref _tagTypes, value);
        }

        private TagLib.TagTypes _tagTypesOnDisk;
        public TagLib.TagTypes TagTypesOnDisk
        {
            get => _tagTypesOnDisk;
            set => Set(ref _tagTypesOnDisk, value);
        }

        private string _title = string.Empty;
        [DefaultValue("")]
        public string Title
        {
            get => Get(_title);
            set => Set(ref _title, value);
        }

        private string _titleSort = string.Empty;
        [DefaultValue("")]
        public string TitleSort
        {
            get => Get(_titleSort);
            set => Set(ref _titleSort, value);
        }

        private int _trackCount;
        [DefaultValue(0)]
        public int TrackCount
        {
            get => _trackCount;
            set => Set(ref _trackCount, value);
        }

        private string _trackGain = string.Empty;
        [DefaultValue("")]
        public string TrackGain
        {
            get => Get(_trackGain);
            set => Set(ref _trackGain, value);
        }

        private int _trackNumber;
        [DefaultValue(0)]
        public int TrackNumber
        {
            get => _trackNumber;
            set => Set(ref _trackNumber, value);
        }

        [JsonIgnore, XmlIgnore]
        public string TrackOf => GetNumberOfTotal(TrackNumber, TrackCount, 2);

        private string _trackPeak = string.Empty;
        [DefaultValue("")]
        public string TrackPeak
        {
            get => Get(_trackPeak);
            set => Set(ref _trackPeak, value);
        }

        private int _videoHeight;
        [DefaultValue(0)]
        public int VideoHeight
        {
            get => _videoHeight;
            set => Set(ref _videoHeight, value);
        }

        private int _videoWidth;
        [DefaultValue(0)]
        public int VideoWidth
        {
            get => _videoWidth;
            set => Set(ref _videoWidth, value);
        }

        private int _year;
        [DefaultValue(0)]
        public int Year
        {
            get => _year;
            set => Set(ref _year, value);
        }

        [JsonIgnore, XmlIgnore]
        public string YearAlbum => $"{Year} - {Album}";

        #endregion

        #region Public Methods

        public object GetPropertyValue(Tag tag) => GetPropertyInfo(tag).GetValue(this);
        public void SetPropertyValue(Tag tag, object value) => GetPropertyInfo(tag).SetValue(this, value);

        public void Load()
        {
            ReadFileMetadata();
            using (var file = GetTagLibFile())
                ReadTagFile(file);
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

        public override string ToString() => $"{JoinedPerformers} | {YearAlbum} | {TrackOf} {Title} ({Duration.AsString(false)}) {FileSize.AsString(true)}";

        #endregion

        #region Read / Write Tag File

        private TagLib.File GetTagLibFile() => TagLib.File.Create(FilePath);

        private void ReadFileMetadata()
        {
            _fileSize = new FileInfo(FilePath).Length;
            _fileAttributes = File.GetAttributes(FilePath).ToString();
            _fileCreationTime = File.GetCreationTimeUtc(FilePath);
            _fileLastWriteTime = File.GetLastWriteTimeUtc(FilePath);
            _fileLastAccessTime = File.GetLastAccessTimeUtc(FilePath);
            _fileCreationTimeUtc = File.GetCreationTimeUtc(FilePath);
            _fileLastWriteTimeUtc = File.GetLastWriteTimeUtc(FilePath);
            _fileLastAccessTimeUtc = File.GetLastAccessTimeUtc(FilePath);
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
            _firstAlbumArtist = tag.FirstAlbumArtist;
            _firstAlbumArtistSort = tag.FirstAlbumArtistSort;
#pragma warning disable 612, 618
            _firstArtist = tag.FirstArtist;
#pragma warning restore 612, 618
            _firstComposer = tag.FirstComposer;
            _firstComposerSort = tag.FirstComposerSort;
            _firstGenre = tag.FirstGenre;
            _firstPerformer = tag.FirstPerformer;
            _firstPerformerSort = tag.FirstPerformerSort;
            _genres = tag.Genres;
            _grouping = tag.Grouping;
            _isEmpty = tag.IsEmpty;
            _joinedAlbumArtists = tag.JoinedAlbumArtists;
#pragma warning disable 612, 618
            _joinedArtists = tag.JoinedArtists;
#pragma warning restore 612, 618
            _joinedComposers = tag.JoinedComposers;
            _joinedGenres = tag.JoinedGenres;
            _joinedPerformers = tag.JoinedPerformers;
            _joinedPerformersSort = tag.JoinedPerformersSort;
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
            _pictures = tag.Pictures.Select(p => new Picture(FilePath, pictureIndex++, p)).ToArray();
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

        private void ReadTagFile(TagLib.File file)
        {
            if (file == null)
                return;
            _invariantEndPosition = file.InvariantEndPosition;
            _invariantStartPosition = file.InvariantStartPosition;
            _mimeType = file.MimeType;
            _name = file.Name;
            _possiblyCorrupt = file.PossiblyCorrupt;
            _tagTypes = file.TagTypes;
            _tagTypesOnDisk = file.TagTypesOnDisk;
            ReadTagProperties(file.Properties);
            ReadTag(file.Tag);
        }

        private void ReadTagImageData(TagLib.Image.ImageTag tag)
        {
            _imageAltitude = tag.Altitude ?? 0;
            _imageCreator = tag.Creator;
            _imageDateTime = tag.DateTime ?? DateTime.MinValue;
            _imageExposureTime = tag.ExposureTime ?? 0;
            _imageFNumber = tag.FNumber ?? 0;
            _imageFocalLength = tag.FocalLength ?? 0;
            _imageFocalLengthIn35mmFilm = (int)(tag.FocalLengthIn35mmFilm ?? 0);
            _imageISOSpeedRatings = (int)(tag.ISOSpeedRatings ?? 0);
            _imageKeywords = tag.Keywords;
            _imageLatitude = tag.Latitude ?? 0;
            _imageLongitude = tag.Longitude ?? 0;
            _imageMake = tag.Make;
            _imageModel = tag.Model;
            _imageOrientation = tag.Orientation;
            _imageRating = (int)(tag.Rating ?? 0);
            _imageSoftware = tag.Software;
        }

        private void ReadTagProperties(TagLib.Properties properties)
        {
            if (properties == null)
                return;
            _audioBitrate = properties.AudioBitrate;
            _audioChannels = properties.AudioChannels;
            _audioSampleRate = properties.AudioSampleRate;
            _bitsPerSample = properties.BitsPerSample;
            _codecs = properties.Codecs
                .Where(c => c != null)
                .Select(c => $"{c.MediaTypes} ({c.Description} - {c.Duration:g})")
                .Aggregate((s, t) => s + "; " + t);
            _description = properties.Description;
            _duration = properties.Duration;
            _mediaTypes = properties.MediaTypes; // 0 = None, 1 = Audio, 2 = Video, 4 = Photo, 8 = Text.
            _photoHeight = properties.PhotoHeight;
            _photoQuality = properties.PhotoQuality;
            _photoWidth = properties.PhotoWidth;
            _videoHeight = properties.VideoHeight;
            _videoWidth = properties.VideoWidth;
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

        #endregion

        #region Get / Set Property Values

        private string Get(string field) => field ?? string.Empty;
        private T[] Get<T>(T[] field) => field ?? Array.Empty<T>();
        private static PropertyInfo GetPropertyInfo(Tag tag) => typeof(Work).GetProperty($"{tag}");

        private static string GetNumberOfTotal(int number, int total, int digits)
        {
            number = Math.Max(number, 1);
            total = Math.Max(number, total);
            digits = Math.Max(digits, total.ToString().Length);
            return string.Format($"{{0:D{digits}}}/{{1:D{digits}}}", number, total);
        }

        private static bool SequenceEqual<T>(IEnumerable<T> x, IEnumerable<T> y) => x != null ? y != null && x.SequenceEqual(y) : y == null;

        private void Set<T>(ref T field, T value) => Set(ref field, value, !Equals(field, value));
        private void Set<T>(ref T[] field, T[] value) => Set(ref field, value, !SequenceEqual(field, value));

        private void Set<T>(ref T field, T value, bool condition)
        {
            if (condition)
                field = value;
        }

        private void SetUserValue(string name, string value)
        {
            switch (name)
            {
                case "replaygain_album_gain": _albumGain = value; break;
                case "replaygain_album_peak": _albumPeak = value; break;
                case "replaygain_track_gain": _trackGain = value; break;
                case "replaygain_track_peak": _trackPeak = value; break;
            }
        }

        #endregion
    }
}
