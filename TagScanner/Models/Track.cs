namespace TagScanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text.Json.Serialization;
    using System.Xml;
    using System.Xml.Serialization;
    using Utils;

    [Serializable]
    public class Track : ITrack
    {
        #region Constructors

        public Track() { }

        public static Track FromPath(string filePath, Func<Track, bool> filter = null)
        {
            var track = new Track();
            track._filePath = filePath;
            if (track.Load(filter))
            {
                track.IsNew = true;
                return track;
            }
            return null;
        }

        #endregion

        #region Properties

        private bool FileExists => File.Exists(FilePath);

        [NonSerialized, XmlIgnore] public bool IsModified;
        [NonSerialized, XmlIgnore] public bool IsNew;

        #endregion

        #region ITrack

        private string _album = string.Empty;
        [DefaultValue("")]
        public string Album
        {
            get => Get(_album);
            set => Set(ref _album, value);
        }

        private string[] _albumArtists = Array.Empty<string>();
        public string[] AlbumArtists
        {
            get => Get(_albumArtists);
            set => Set(ref _albumArtists, value);
        }

        [JsonIgnore, XmlIgnore]
        public int AlbumArtistsCount => AlbumArtists.Length;

        private string[] _albumArtistsSort = Array.Empty<string>();
        public string[] AlbumArtistsSort
        {
            get => Get(_albumArtistsSort);
            set => Set(ref _albumArtistsSort, value);
        }

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

        private string[] _artists = Array.Empty<string>();
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

        private int _audioSampleRate;
        [DefaultValue(0)]
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
        public string Century => Year > 0 ? ((ulong)(Year + 99) / 100).AsOrdinal() : string.Empty;

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

        private string[] _composers = Array.Empty<string>();
        public string[] Composers
        {
            get => Get(_composers);
            set => Set(ref _composers, value);
        }

        [JsonIgnore, XmlIgnore]
        public int ComposersCount => Composers.Length;

        private string[] _composersSort = Array.Empty<string>();
        public string[] ComposersSort
        {
            get => Get(_composersSort);
            set => Set(ref _composersSort, value);
        }

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
        [JsonIgnore, XmlIgnore] public TimeSpan Duration
        {
            get => _duration;
            set => Set(ref _duration, value);
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement(DataType = "duration", ElementName = "Duration")]
        public string DurationString
        {
            get => XmlConvert.ToString(Duration);
            set => Duration = string.IsNullOrWhiteSpace(value) ? TimeSpan.Zero : XmlConvert.ToTimeSpan(value);
        }

        private DateTime _fileAccessed;
        public DateTime FileAccessed
        {
            get => _fileAccessed;
            set => Set(ref _fileAccessed, value);
        }

        private DateTime _fileAccessedUtc;
        public DateTime FileAccessedUtc
        {
            get => _fileAccessedUtc;
            set => Set(ref _fileAccessedUtc, value);
        }

        private string _fileAttrs = string.Empty;
        [DefaultValue("")]
        public string FileAttrs
        {
            get => Get(_fileAttrs);
            set => Set(ref _fileAttrs, value);
        }

        [JsonIgnore, XmlIgnore] public Logical FileAttrArchive => HasAttr(FileAttributes.Archive);
        [JsonIgnore, XmlIgnore] public Logical FileAttrCompressed => HasAttr(FileAttributes.Compressed);
        [JsonIgnore, XmlIgnore] public Logical FileAttrEncrypted => HasAttr(FileAttributes.Encrypted);
        [JsonIgnore, XmlIgnore] public Logical FileAttrHidden => HasAttr(FileAttributes.Hidden);
        [JsonIgnore, XmlIgnore] public Logical FileAttrReadOnly => HasAttr(FileAttributes.ReadOnly);
        [JsonIgnore, XmlIgnore] public Logical FileAttrSystem => HasAttr(FileAttributes.System);

        private DateTime _fileCreated;
        public DateTime FileCreated
        {
            get => _fileCreated;
            set => Set(ref _fileCreated, value);
        }

        private DateTime _fileCreatedUtc;
        public DateTime FileCreatedUtc
        {
            get => _fileCreatedUtc;
            set => Set(ref _fileCreatedUtc, value);
        }

        [JsonIgnore, XmlIgnore]
        public string FileExtension => Path.GetExtension(FilePath);

        private DateTime _fileModified;
        public DateTime FileModified
        {
            get => _fileModified;
            set => Set(ref _fileModified, value);
        }

        private DateTime _fileModifiedUtc;
        public DateTime FileModifiedUtc
        {
            get => _fileModifiedUtc;
            set => Set(ref _fileModifiedUtc, value);
        }

        [JsonIgnore, XmlIgnore]
        public string FileName => Path.GetFileName(FilePath);

        [JsonIgnore, XmlIgnore]
        public string FileNameWithoutExtension => Path.GetFileNameWithoutExtension(FilePath);

        private string _filePath = string.Empty;
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
        public Status Status
        {
            get
            {
                if (!FileExists)
                    return Status.Deleted;
                if (IsNew)
                    return IsModified ? Status.New | Status.Pending : Status.New;
                if (IsModified)
                    return Status.Pending;
                // TODO: check for resolution inaccuracies & daylight saving time transitions.
                var elapsedTime = FileModifiedUtc - File.GetLastWriteTimeUtc(FilePath);
                switch (Math.Sign(elapsedTime.Ticks))
                {
                    case +1:
                        return Status.Pending;
                    case -1:
                        return Status.Updated;
                }
                return Status.Current;
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

        [JsonIgnore, XmlIgnore]
        public string FolderPath => Path.GetDirectoryName(FilePath);

        private string[] _genres = Array.Empty<string>();
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

        private string[] _imageKeywords = Array.Empty<string>();
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
        public string Millennium => Year > 0 ? ((ulong)(Year + 999) / 1000).AsOrdinal() : string.Empty;

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

        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        private string[] _performers = Array.Empty<string>();
        public string[] Performers
        {
            get => Get(_performers);
            set => Set(ref _performers, value);
        }

        [JsonIgnore, XmlIgnore]
        public int PerformersCount => Performers.Length;

        private string[] _performersSort = Array.Empty<string>();
        public string[] PerformersSort
        {
            get => Get(_performersSort);
            set => Set(ref _performersSort, value);
        }

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
            set => Set(ref _pictures, value ?? Array.Empty<Picture>());
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

        public bool ChangeValue(Tag tag, ref object value)
        {
            var oldValue = GetPropertyValue(tag);
            var result = !Equals(oldValue, value);
            if (result)
            {
                SetPropertyValue(tag, value);
                value = oldValue;
            }
            return result;
        }

        public object GetPropertyValue(Tag tag)
        {
            switch (tag)
            {
                case Tag.Album: return Album;
                case Tag.AlbumArtists: return AlbumArtists;
                case Tag.AlbumArtistsCount: return AlbumArtistsCount;
                case Tag.AlbumArtistsSort: return AlbumArtistsSort;
                case Tag.AlbumGain: return AlbumGain;
                case Tag.AlbumPeak: return AlbumPeak;
                case Tag.AlbumSort: return AlbumSort;
                case Tag.AmazonId: return AmazonId;
                case Tag.Artists: return Artists;
                case Tag.ArtistsCount: return ArtistsCount;
                case Tag.AudioBitrate: return AudioBitrate;
                case Tag.AudioChannels: return AudioChannels;
                case Tag.AudioSampleRate: return AudioSampleRate;
                case Tag.BeatsPerMinute: return BeatsPerMinute;
                case Tag.BitsPerSample: return BitsPerSample;
                case Tag.Century: return Century;
                case Tag.Codecs: return Codecs;
                case Tag.Comment: return Comment;
                case Tag.Composers: return Composers;
                case Tag.ComposersCount: return ComposersCount;
                case Tag.ComposersSort: return ComposersSort;
                case Tag.Conductor: return Conductor;
                case Tag.Copyright: return Copyright;
                case Tag.Decade: return Decade;
                case Tag.Description: return Description;
                case Tag.DiscCount: return DiscCount;
                case Tag.DiscNumber: return DiscNumber;
                case Tag.DiscOf: return DiscOf;
                case Tag.DiscTrack: return DiscTrack;
                case Tag.Duration: return Duration;
                case Tag.FileAttrs: return FileAttrs;
                case Tag.FileCreated: return FileCreated;
                case Tag.FileCreatedUtc: return FileCreatedUtc;
                case Tag.FileExtension: return FileExtension;
                case Tag.FileAccessed: return FileAccessed;
                case Tag.FileAccessedUtc: return FileAccessedUtc;
                case Tag.FileModified: return FileModified;
                case Tag.FileModifiedUtc: return FileModifiedUtc;
                case Tag.FileName: return FileName;
                case Tag.FileNameWithoutExtension: return FileNameWithoutExtension;
                case Tag.FilePath: return FilePath;
                case Tag.FileSize: return FileSize;
                case Tag.Status: return Status;
                case Tag.FirstAlbumArtist: return FirstAlbumArtist;
                case Tag.FirstAlbumArtistSort: return FirstAlbumArtistSort;
                case Tag.FirstArtist: return FirstArtist;
                case Tag.FirstComposer: return FirstComposer;
                case Tag.FirstComposerSort: return FirstComposerSort;
                case Tag.FirstGenre: return FirstGenre;
                case Tag.FirstPerformer: return FirstPerformer;
                case Tag.FirstPerformerSort: return FirstPerformerSort;
                case Tag.Genres: return Genres;
                case Tag.GenresCount: return GenresCount;
                case Tag.Grouping: return Grouping;
                case Tag.ImageAltitude: return ImageAltitude;
                case Tag.ImageCreator: return ImageCreator;
                case Tag.ImageDateTime: return ImageDateTime;
                case Tag.ImageExposureTime: return ImageExposureTime;
                case Tag.ImageFNumber: return ImageFNumber;
                case Tag.ImageFocalLength: return ImageFocalLength;
                case Tag.ImageFocalLengthIn35mmFilm: return ImageFocalLengthIn35mmFilm;
                case Tag.ImageISOSpeedRatings: return ImageISOSpeedRatings;
                case Tag.ImageKeywords: return ImageKeywords;
                case Tag.ImageLatitude: return ImageLatitude;
                case Tag.ImageLongitude: return ImageLongitude;
                case Tag.ImageMake: return ImageMake;
                case Tag.ImageModel: return ImageModel;
                case Tag.ImageOrientation: return ImageOrientation;
                case Tag.ImageRating: return ImageRating;
                case Tag.ImageSoftware: return ImageSoftware;
                case Tag.InvariantEndPosition: return InvariantEndPosition;
                case Tag.InvariantStartPosition: return InvariantStartPosition;
                case Tag.IsClassical: return IsClassical;
                case Tag.IsEmpty: return IsEmpty;
                case Tag.JoinedAlbumArtists: return JoinedAlbumArtists;
                case Tag.JoinedArtists: return JoinedArtists;
                case Tag.JoinedComposers: return JoinedComposers;
                case Tag.JoinedGenres: return JoinedGenres;
                case Tag.JoinedPerformers: return JoinedPerformers;
                case Tag.JoinedPerformersSort: return JoinedPerformersSort;
                case Tag.Lyrics: return Lyrics;
                case Tag.MediaTypes: return MediaTypes;
                case Tag.Millennium: return Millennium;
                case Tag.MimeType: return MimeType;
                case Tag.MusicBrainzArtistId: return MusicBrainzArtistId;
                case Tag.MusicBrainzDiscId: return MusicBrainzDiscId;
                case Tag.MusicBrainzReleaseArtistId: return MusicBrainzReleaseArtistId;
                case Tag.MusicBrainzReleaseCountry: return MusicBrainzReleaseCountry;
                case Tag.MusicBrainzReleaseId: return MusicBrainzReleaseId;
                case Tag.MusicBrainzReleaseStatus: return MusicBrainzReleaseStatus;
                case Tag.MusicBrainzReleaseType: return MusicBrainzReleaseType;
                case Tag.MusicBrainzTrackId: return MusicBrainzTrackId;
                case Tag.MusicIpId: return MusicIpId;
                case Tag.Performers: return Performers;
                case Tag.PerformersCount: return PerformersCount;
                case Tag.PerformersSort: return PerformersSort;
                case Tag.PhotoHeight: return PhotoHeight;
                case Tag.PhotoQuality: return PhotoQuality;
                case Tag.PhotoWidth: return PhotoWidth;
                case Tag.Pictures: return Pictures;
                case Tag.PicturesCount: return PicturesCount;
                case Tag.PossiblyCorrupt: return PossiblyCorrupt;
                case Tag.TagTypes: return TagTypes;
                case Tag.TagTypesOnDisk: return TagTypesOnDisk;
                case Tag.Title: return Title;
                case Tag.TitleSort: return TitleSort;
                case Tag.TrackCount: return TrackCount;
                case Tag.TrackGain: return TrackGain;
                case Tag.TrackNumber: return TrackNumber;
                case Tag.TrackOf: return TrackOf;
                case Tag.TrackPeak: return TrackPeak;
                case Tag.VideoHeight: return VideoHeight;
                case Tag.VideoWidth: return VideoWidth;
                case Tag.Year: return Year;
                case Tag.YearAlbum: return YearAlbum;
                default: return null;
            }
        }

        private object SetPropertyValue(Tag tag, object value)
        {
            switch (tag)
            {
                case Tag.Album: return Album = (string)value;
                case Tag.AlbumArtists: return AlbumArtists = (string[])value;
                case Tag.AlbumArtistsSort: return AlbumArtistsSort = (string[])value;
                case Tag.AlbumGain: return AlbumGain = (string)value;
                case Tag.AlbumPeak: return AlbumPeak = (string)value;
                case Tag.AlbumSort: return AlbumSort = (string)value;
                case Tag.AmazonId: return AmazonId = (string)value;
                case Tag.Artists: return Artists = (string[])value;
                case Tag.AudioBitrate: return AudioBitrate = (int)value;
                case Tag.AudioChannels: return AudioChannels = (int)value;
                case Tag.AudioSampleRate: return AudioSampleRate = (int)value;
                case Tag.BeatsPerMinute: return BeatsPerMinute = (int)value;
                case Tag.BitsPerSample: return BitsPerSample = (int)value;
                case Tag.Codecs: return Codecs = (string)value;
                case Tag.Comment: return Comment = (string)value;
                case Tag.Composers: return Composers = (string[])value;
                case Tag.ComposersSort: return ComposersSort = (string[])value;
                case Tag.Conductor: return Conductor = (string)value;
                case Tag.Copyright: return Copyright = (string)value;
                case Tag.Description: return Description = (string)value;
                case Tag.DiscCount: return DiscCount = (int)value;
                case Tag.DiscNumber: return DiscNumber = (int)value;
                case Tag.Duration: return Duration = (TimeSpan)value;
                case Tag.FileAttrs: return FileAttrs = (string)value;
                case Tag.FileCreated: return FileCreated = (DateTime)value;
                case Tag.FileCreatedUtc: return FileCreatedUtc = (DateTime)value;
                case Tag.FileAccessed: return FileAccessed = (DateTime)value;
                case Tag.FileAccessedUtc: return FileAccessedUtc = (DateTime)value;
                case Tag.FileModified: return FileModified = (DateTime)value;
                case Tag.FileModifiedUtc: return FileModifiedUtc = (DateTime)value;
                case Tag.FilePath: return FilePath = (string)value;
                case Tag.FileSize: return FileSize = (long)value;
                case Tag.FirstAlbumArtist: return FirstAlbumArtist = (string)value;
                case Tag.FirstAlbumArtistSort: return FirstAlbumArtistSort = (string)value;
                case Tag.FirstArtist: return FirstArtist = (string)value;
                case Tag.FirstComposer: return FirstComposer = (string)value;
                case Tag.FirstComposerSort: return FirstComposerSort = (string)value;
                case Tag.FirstGenre: return FirstGenre = (string)value;
                case Tag.FirstPerformer: return FirstPerformer = (string)value;
                case Tag.FirstPerformerSort: return FirstPerformerSort = (string)value;
                case Tag.Genres: return Genres = (string[])value;
                case Tag.Grouping: return Grouping = (string)value;
                case Tag.ImageAltitude: return ImageAltitude = (double)value;
                case Tag.ImageCreator: return ImageCreator = (string)value;
                case Tag.ImageDateTime: return ImageDateTime = (DateTime)value;
                case Tag.ImageExposureTime: return ImageExposureTime = (double)value;
                case Tag.ImageFNumber: return ImageFNumber = (double)value;
                case Tag.ImageFocalLength: return ImageFocalLength = (double)value;
                case Tag.ImageFocalLengthIn35mmFilm: return ImageFocalLengthIn35mmFilm = (int)value;
                case Tag.ImageISOSpeedRatings: return ImageISOSpeedRatings = (int)value;
                case Tag.ImageKeywords: return ImageKeywords = (string[])value;
                case Tag.ImageLatitude: return ImageLatitude = (double)value;
                case Tag.ImageLongitude: return ImageLongitude = (double)value;
                case Tag.ImageMake: return ImageMake = (string)value;
                case Tag.ImageModel: return ImageModel = (string)value;
                case Tag.ImageOrientation: return ImageOrientation = (TagLib.Image.ImageOrientation)value;
                case Tag.ImageRating: return ImageRating = (int)value;
                case Tag.ImageSoftware: return ImageSoftware = (string)value;
                case Tag.InvariantEndPosition: return InvariantEndPosition = (long)value;
                case Tag.InvariantStartPosition: return InvariantStartPosition = (long)value;
                case Tag.IsEmpty: return IsEmpty = (Logical)value;
                case Tag.JoinedAlbumArtists: return JoinedAlbumArtists = (string)value;
                case Tag.JoinedArtists: return JoinedArtists = (string)value;
                case Tag.JoinedComposers: return JoinedComposers = (string)value;
                case Tag.JoinedGenres: return JoinedGenres = (string)value;
                case Tag.JoinedPerformers: return JoinedPerformers = (string)value;
                case Tag.JoinedPerformersSort: return JoinedPerformersSort = (string)value;
                case Tag.Lyrics: return Lyrics = (string)value;
                case Tag.MediaTypes: return MediaTypes = (TagLib.MediaTypes)value;
                case Tag.MimeType: return MimeType = (string)value;
                case Tag.MusicBrainzArtistId: return MusicBrainzArtistId = (string)value;
                case Tag.MusicBrainzDiscId: return MusicBrainzDiscId = (string)value;
                case Tag.MusicBrainzReleaseArtistId: return MusicBrainzReleaseArtistId = (string)value;
                case Tag.MusicBrainzReleaseCountry: return MusicBrainzReleaseCountry = (string)value;
                case Tag.MusicBrainzReleaseId: return MusicBrainzReleaseId = (string)value;
                case Tag.MusicBrainzReleaseStatus: return MusicBrainzReleaseStatus = (string)value;
                case Tag.MusicBrainzReleaseType: return MusicBrainzReleaseType = (string)value;
                case Tag.MusicBrainzTrackId: return MusicBrainzTrackId = (string)value;
                case Tag.MusicIpId: return MusicIpId = (string)value;
                case Tag.Performers: return Performers = (string[])value;
                case Tag.PerformersSort: return PerformersSort = (string[])value;
                case Tag.PhotoHeight: return PhotoHeight = (int)value;
                case Tag.PhotoQuality: return PhotoQuality = (int)value;
                case Tag.PhotoWidth: return PhotoWidth = (int)value;
                case Tag.Pictures: return Pictures = (Picture[])value;
                case Tag.PossiblyCorrupt: return PossiblyCorrupt = (Logical)value;
                case Tag.TagTypes: return TagTypes = (TagLib.TagTypes)value;
                case Tag.TagTypesOnDisk: return TagTypesOnDisk = (TagLib.TagTypes)value;
                case Tag.Title: return Title = (string)value;
                case Tag.TitleSort: return TitleSort = (string)value;
                case Tag.TrackCount: return TrackCount = (int)value;
                case Tag.TrackGain: return TrackGain = (string)value;
                case Tag.TrackNumber: return TrackNumber = (int)value;
                case Tag.TrackPeak: return TrackPeak = (string)value;
                case Tag.VideoHeight: return VideoHeight = (int)value;
                case Tag.VideoWidth: return VideoWidth = (int)value;
                case Tag.Year: return Year = (int)value;
                default: throw new NotImplementedException();
            }
        }

        public bool Load() => Load(p => true);

        public bool Load(Func<Track, bool> fileOptionsFilter)
        {
            ReadFileMetadata();
            var result = fileOptionsFilter == null || fileOptionsFilter(this);
            if (result)
            {
                using (var file = GetTagLibFile())
                    ReadTagFile(file);
                IsModified = false;
            }
            return result;
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
            _fileAttrs = File.GetAttributes(FilePath).ToString();
            _fileCreated = File.GetCreationTimeUtc(FilePath);
            _fileModified = File.GetLastWriteTimeUtc(FilePath);
            _fileAccessed = File.GetLastAccessTimeUtc(FilePath);
            _fileCreatedUtc = File.GetCreationTimeUtc(FilePath);
            _fileModifiedUtc = File.GetLastWriteTimeUtc(FilePath);
            _fileAccessedUtc = File.GetLastAccessTimeUtc(FilePath);
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

        private void ReadTagUserText(TagLib.CombinedTag combinedTag)
        {
            var id3v2Tag = combinedTag.Tags.OfType<TagLib.Id3v2.Tag>().FirstOrDefault();
            if (id3v2Tag != null)
                foreach (var frame in id3v2Tag.OfType<TagLib.Id3v2.UserTextInformationFrame>())
                    ReadUserValue(frame.Description, frame.Text.FirstOrDefault());
        }

        private void ReadTagUserTextAsf(TagLib.Asf.Tag asfTag)
        {
            foreach (var frame in asfTag)
                ReadUserValue(frame.Name, frame.ToString());
        }

        private void ReadUserValue(string name, string value)
        {
            switch (name)
            {
                case RgAlbumGain: _albumGain = value; break;
                case RgAlbumPeak: _albumPeak = value; break;
                case RgTrackGain: _trackGain = value; break;
                case RgTrackPeak: _trackPeak = value; break;
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
            WriteTagExtra(tag);
        }

        private void WriteTagExtra(TagLib.Tag tag)
        {
            if (tag is TagLib.CombinedTag combinedTag) // Including subtype TagLib.NonContainer.Tag
                WriteTagUserText(combinedTag);
            else if (tag is TagLib.Asf.Tag asfTag)
                WriteTagUserTextAsf(asfTag);
            else if (tag is TagLib.Image.ImageTag imageTag)
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

        private void WriteTagUserText(TagLib.CombinedTag combinedTag)
        {
            var id3v2Tag = combinedTag.Tags.OfType<TagLib.Id3v2.Tag>().FirstOrDefault();
            if (id3v2Tag != null)
                foreach (var frame in id3v2Tag.OfType<TagLib.Id3v2.UserTextInformationFrame>())
                    switch (frame.Description)
                    {
                        case RgAlbumGain: frame.Text = new[] { _albumGain }; break;
                        case RgAlbumPeak: frame.Text = new[] { _albumPeak }; break;
                        case RgTrackGain: frame.Text = new[] { _trackGain }; break;
                        case RgTrackPeak: frame.Text = new[] { _trackPeak }; break;
                    }
        }

        private void WriteTagUserTextAsf(TagLib.Asf.Tag asfTag)
        {
            WriteUserValue(asfTag, RgAlbumGain, _albumGain);
            WriteUserValue(asfTag, RgAlbumPeak, _albumPeak);
            WriteUserValue(asfTag, RgTrackGain, _trackGain);
            WriteUserValue(asfTag, RgTrackPeak, _trackPeak);
        }

        private void WriteUserValue(TagLib.Asf.Tag asfTag, string name, string value) =>
            asfTag.SetDescriptors(name, new TagLib.Asf.ContentDescriptor(name, value));

        #endregion

        #region Get / Set Property Values

        private string Get(string field) => field ?? string.Empty;
        private T[] Get<T>(T[] field) => field;

        private static string GetNumberOfTotal(int number, int total, int digits)
        {
            number = Math.Max(number, 1);
            total = Math.Max(number, total);
            digits = Math.Max(digits, total.ToString().Length);
            return string.Format($"{{0:D{digits}}}/{{1:D{digits}}}", number, total);
        }

        private Logical HasAttr(FileAttributes attribute) => FileAttrs.Contains($"{attribute}").AsLogical();
        private static bool SequenceEqual<T>(IEnumerable<T> x, IEnumerable<T> y) => x != null ? y != null && x.SequenceEqual(y) : y == null;
        private void Set<T>(ref T field, T value) => Set(ref field, value, !Equals(field, value));
        private void Set<T>(ref T[] field, T[] value) => Set(ref field, value, !SequenceEqual(field, value));

        private void Set<T>(ref T field, T value, bool condition)
        {
            if (condition)
            {
                field = value;
                IsModified = true;
            }
        }

        #endregion

        #region Private Fields

        private const string
            RgAlbumGain = "replaygain_album_gain",
            RgAlbumPeak = "replaygain_album_peak",
            RgTrackGain = "replaygain_track_gain",
            RgTrackPeak = "replaygain_track_peak";

        #endregion
    }
}
