namespace TagScanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;

    [DefaultProperty("Title")]
    public class Selection : ITrack
    {
        #region Constructors

        public Selection() => Tracks = new List<Track>();
        public Selection(IEnumerable<Track> tracks) => Tracks = tracks.ToList();

        #endregion

        #region Public Fields

        public List<Track> Tracks { get; private set; }

        public const string
            Category = "Category",
            Details = "Details",
            File = "File",
            Format = "Format",
            Image = "Image",
            Media = "Media",
            Metadata = "Metadata",
            Personnel = "Personnel",
            ReplayGain = "Replay Gain",
            Selected = "Selection";

        #endregion

        #region Public Methods

        public void Add(IEnumerable<Track> tracks) => Tracks.AddRange(tracks);
        public void Clear() => Tracks.Clear();
        public void Remove(IEnumerable<Track> tracks) => Tracks.RemoveAll(p => tracks.Contains(p));

        public void Invalidate()
        {
            InvalidateDateTimeFields();
            InvalidateDoubleFields();
            InvalidateIntegerFields();
            InvalidateLongFields();
            InvalidateMiscellaneousFields();
            InvalidateStringFields();
            InvalidateStringsFields();
        }

        #endregion

        #region ITrack

        #region Album

        private string _album;
        [Browsable(true)]
        [Category(Details)]
        [Column(160)]
        [Description("A string containing the album name of the media represented by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("Album")]
        public string Album
        {
            get => GetString(p => p.Album, ref _album);
            set
            {
                SetValue(Tag.Album, p => p.Album, p => p.Album = value);
                _album = null;
                _yearAlbum = null;
            }
        }

        #endregion
        #region AlbumArtists

        private string[] _albumArtists;
        [Browsable(true)]
        [Category(Personnel)]
        [Column(160)]
        [Description("A string array containing the band(s) or artist(s) credited in the creation of the entire album or collection containing the media described by the selected item(s), or an empty array if no value is present.")]
        [DisplayName("Album Artists")]
        public string[] AlbumArtists
        {
            get => GetStringArray(p => p.AlbumArtists, ref _albumArtists);
            set
            {
                SetValue(Tag.AlbumArtists, p => p.AlbumArtists, p => p.AlbumArtists = value);
                _albumArtists = null;
                _firstAlbumArtist = null;
                _joinedAlbumArtists = null;
            }
        }

        #endregion
        #region AlbumArtistsCount

        private int _albumArtistsCount = int.MaxValue;
        [Browsable(false)]
        [Category(Personnel)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An integer indicating the number of band(s) or artist(s) credited in the creation of the entire album or collection containing the media described by the selected item(s), or zero if none are present.")]
        [DisplayName("# Album Artists")]
        [ReadOnly(true)]
        [Uses(Tag.AlbumArtists)]
        public int AlbumArtistsCount => GetInt(p => p.AlbumArtistsCount, ref _albumArtistsCount);

        #endregion
        #region AlbumArtistsSort

        private string[] _albumArtistsSort;
        [Browsable(false)]
        [Category(Personnel)]
        [Column(160)]
        [Description("A string array containing the sort names for the band or artist who is credited in the creation of the entire album or collection containing the media described by the selected item(s), or an empty array if no value is present.")]
        [DisplayName("Album Artists (sorted)")]
        public string[] AlbumArtistsSort
        {
            get => GetStringArray(p => p.AlbumArtistsSort, ref _albumArtistsSort);
            set
            {
                SetValue(Tag.AlbumArtistsSort, p => p.AlbumArtistsSort, p => p.AlbumArtistsSort = value);
                _albumArtistsSort = null;
                _firstAlbumArtistSort = null;
            }
        }

        #endregion
        #region AlbumArtistsSortCount

        private int _albumArtistsSortCount = int.MaxValue;
        [Browsable(false)]
        [Category(Personnel)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An integer indicating the number of band(s) or artist(s) credited in the creation of the entire album or collection containing the media described by the selected item(s), or zero if none are present.")]
        [DisplayName("# Album Artists (sorted)")]
        [ReadOnly(true)]
        [Uses(Tag.AlbumArtistsSort)]
        public int AlbumArtistsSortCount => GetInt(p => p.AlbumArtistsSortCount, ref _albumArtistsSortCount);

        #endregion
        #region AlbumGain

        private string _albumGain;
        [Browsable(true)]
        [Category(ReplayGain)]
        [Column(80, Alignment.Far)]
        [Description("A string containing the Album Gain setting in decibels for the selected item(s), as determined by the ReplayGain utility.")]
        [DisplayName("Album Gain")]
        public string AlbumGain => GetString(p => p.AlbumGain, ref _albumGain);

        #endregion
        #region AlbumPeak

        private string _albumPeak;
        [Browsable(true)]
        [Category(ReplayGain)]
        [Column(80, Alignment.Far)]
        [Description("A string containing the Album Peak setting for the selected item(s), as determined by the ReplayGain utility.")]
        [DisplayName("Album Peak")]
        public string AlbumPeak => GetString(p => p.AlbumPeak, ref _albumPeak);

        #endregion
        #region AlbumSort

        private string _albumSort;
        [Browsable(false)]
        [Category(Details)]
        [Column(160)]
        [Description("A string containing the sort names for the Album Title in the media described by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("Album (sort by)")]
        public string AlbumSort
        {
            get => GetString(p => p.AlbumSort, ref _albumSort);
            set
            {
                SetValue(Tag.AlbumSort, p => p.AlbumSort, p => p.AlbumSort = value);
                _albumSort = null;
            }
        }

        #endregion
        #region AmazonId

        private string _amazonId;
        [Browsable(false)]
        [Category(Metadata)]
        [Description("A string containing the Amazon ID for the media described by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("Amazon ID")]
        public string AmazonId
        {
            get => GetString(p => p.AmazonId, ref _amazonId);
            set
            {
                SetValue(Tag.AmazonId, p => p.AmazonId, p => p.AmazonId = value);
                _amazonId = null;
            }
        }

        #endregion
        #region Artists

        private string[] _artists;
        [Browsable(false)]
        [Category(Personnel)]
        [Column(160)]
        [Description("A string array containing the performers or artists who performed in the media described by the selected item(s), or an empty array if no value is present. (Obsolete. For album artists, use AlbumArtists. For track artists, use Performers.)")]
        [DisplayName("Artists")]
        [Obsolete("Obsolete. For album artists, use AlbumArtists. For track artists, use Performers.")]
        public string[] Artists
        {
            get => GetStringArray(p => p.Artists, ref _artists);
            set
            {
                SetValue(Tag.Artists, p => p.Artists, p => p.Artists = value);
                _artists = null;
                _firstArtist = null;
                _joinedArtists = null;
            }
        }

        #endregion
        #region ArtistsCount

        private int _artistsCount = int.MaxValue;
        [Browsable(false)]
        [Category(Personnel)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An integer indicating the number of performers or artists who performed in the media described by the selected item(s), or zero if none are present. (Obsolete. For album artists, use AlbumArtistsCount. For track artists, use PerformersCount.)")]
        [DisplayName("# Artists")]
        [Obsolete("Obsolete. For album artists, use AlbumArtistsCount. For track artists, use PerformersCount.")]
        [ReadOnly(true)]
        [Uses(Tag.Artists)]
        public int ArtistsCount => GetInt(p => p.ArtistsCount, ref _artistsCount);

        #endregion
        #region AudioBitrate

        private int _audioBitrate = int.MaxValue;
        [Browsable(true)]
        [Category(Format)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An integer containing the bit rate of the audio represented by the selected item(s). This value is equal to the first non-zero audio bit rate.")]
        [DisplayName("Audio Bit Rate")]
        [ReadOnly(true)]
        public int AudioBitrate => GetInt(p => p.AudioBitrate, ref _audioBitrate);

        #endregion
        #region AudioChannels

        private int _audioChannels = int.MaxValue;
        [Browsable(false)]
        [Category(Format)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An integer containing the number of channels in the audio represented by the selected item(s). This value is equal to the first non-zero audio channel count.")]
        [DisplayName("# Audio Channels")]
        [ReadOnly(true)]
        public int AudioChannels => GetInt(p => p.AudioChannels, ref _audioChannels);

        #endregion
        #region AudioSampleRate

        private int _audioSampleRate = int.MaxValue;
        [Browsable(false)]
        [Category(Format)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An integer containing the sample rate of the audio represented by the selected item(s). This value is equal to the first non-zero audio sample rate.")]
        [DisplayName("Audio Sample Rate")]
        [ReadOnly(true)]
        public int AudioSampleRate => GetInt(p => p.AudioSampleRate, ref _audioSampleRate);

        #endregion
        #region BeatsPerMinute

        private int _beatsPerMinute = int.MaxValue;
        [Browsable(true)]
        [Category(Details)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An unsigned integer containing the number of beats per minute in the audio of the media represented by the selected item(s), or zero if not specified.")]
        [DisplayName("BPM")]
        public int BeatsPerMinute
        {
            get => GetInt(p => p.BeatsPerMinute, ref _beatsPerMinute);
            set
            {
                SetValue(Tag.BeatsPerMinute, p => p.BeatsPerMinute, p => p.BeatsPerMinute = value);
                _beatsPerMinute = value;
            }
        }

        #endregion
        #region BitsPerSample

        private int _bitsPerSample = int.MaxValue;
        [Browsable(false)]
        [Category(Format)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An integer value containing the number of bits per sample in the audio represented by the selected item(s). This value is equal to the first non-zero quantization.")]
        [DisplayName("Bits Per Sample")]
        [ReadOnly(true)]
        public int BitsPerSample => GetInt(p => p.BitsPerSample, ref _bitsPerSample);

        #endregion
        #region Century

        private string _century;
        [Browsable(false)]
        [Category(Category)]
        [Column(50)]
        [Description("A string containing the century that the media represented by the selected item(s) was created, or zero if no value is present.")]
        [DisplayName("Century")]
        [ReadOnly(true)]
        [Uses(Tag.Year)]
        public string Century => GetString(p => p.Century, ref _century);

        #endregion
        #region Codecs

        private string _codecs;
        [Browsable(false)]
        [Category(Format)]
        [Column(100)]
        [Description("A string containing a description of the media represented by the selected item(s). The value contains the summaries of the codecs separated by semicolons.")]
        [DisplayName("Codecs")]
        [ReadOnly(true)]
        public string Codecs => GetString(p => p.Codecs, ref _codecs);

        #endregion
        #region Comment

        private string _comment;
        [Browsable(true)]
        [Category(Details)]
        [Column(160)]
        [Description("A string containing user comments on the media represented by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("Comments")]
        public string Comment
        {
            get => GetString(p => p.Comment, ref _comment);
            set
            {
                SetValue(Tag.Comment, p => p.Comment, p => p.Comment = value);
                _comment = null;
            }
        }

        #endregion
        #region Composers

        private string[] _composers;
        [Browsable(true)]
        [Category(Personnel)]
        [Column(160)]
        [Description("A string array containing the composers of the media represented by the selected item(s), or an empty array if no value is present.")]
        [DisplayName("Composers")]
        public string[] Composers
        {
            get => GetStringArray(p => p.Composers, ref _composers);
            set
            {
                SetValue(Tag.Composers, p => p.Composers, p => p.Composers = value);
                _composers = null;
                _firstComposer = null;
                _joinedComposers = null;
            }
        }

        #endregion
        #region ComposersCount

        private int _composersCount = int.MaxValue;
        [Browsable(false)]
        [Category(Personnel)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An integer indicating the number of composers of the media represented by the selected item(s), or zero if none are present.")]
        [DisplayName("# Composers")]
        [ReadOnly(true)]
        [Uses(Tag.Composers)]
        public int ComposersCount => GetInt(p => p.ComposersCount, ref _composersCount);

        #endregion
        #region ComposersSort

        private string[] _composersSort;
        [Browsable(false)]
        [Category(Personnel)]
        [Description("A string array containing the sort names for the Composers in the media described by the selected item(s), or an empty array if no value is present.")]
        [DisplayName("Composers (sorted)")]
        public string[] ComposersSort
        {
            get => GetStringArray(p => p.ComposersSort, ref _composersSort);
            set
            {
                SetValue(Tag.ComposersSort, p => p.ComposersSort, p => p.ComposersSort = value);
                _composersSort = null;
                _firstComposerSort = null;
            }
        }

        #endregion
        #region ComposersSortCount

        private int _composersSortCount = int.MaxValue;
        [Browsable(false)]
        [Category(Personnel)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An integer indicating the number of composers of the media represented by the selected item(s), or zero if none are present.")]
        [DisplayName("# Composers (sorted)")]
        [ReadOnly(true)]
        [Uses(Tag.ComposersSort)]
        public int ComposersSortCount => GetInt(p => p.ComposersSortCount, ref _composersSortCount);

        #endregion
        #region Conductor

        private string _conductor;
        [Browsable(true)]
        [Category(Personnel)]
        [Column(160)]
        [Description("A string containing the conductor or director of the media represented by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("Conductor")]
        public string Conductor
        {
            get => GetString(p => p.Conductor, ref _conductor);
            set
            {
                SetValue(Tag.Conductor, p => p.Conductor, p => p.Conductor = value);
                _conductor = null;
            }
        }

        #endregion
        #region Copyright

        private string _copyright;
        [Browsable(true)]
        [Category(Details)]
        [Column(160)]
        [Description("A string containing the copyright information for the media represented by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("Copyright")]
        public string Copyright
        {
            get => GetString(p => p.Copyright, ref _copyright);
            set
            {
                SetValue(Tag.Copyright, p => p.Copyright, p => p.Copyright = value);
                _copyright = null;
            }
        }

        #endregion
        #region Decade

        private string _decade;
        [Browsable(false)]
        [Category(Category)]
        [Column(50)]
        [Description("A string containing the decade that the media represented by the selected item(s) was created, or zero if no value is present. Following popular usage, years ending in '0' are treated as the start of a decade.")]
        [DisplayName("Decade")]
        [ReadOnly(true)]
        [Uses(Tag.Year)]
        public string Decade => GetString(p => p.Decade, ref _decade);

        #endregion
        #region Description

        private string _description;
        [Browsable(true)]
        [Category(Format)]
        [Column(160)]
        [Description("A string containing a description of the media represented by the selected item(s). The value contains the descriptions of the codecs joined by colons.")]
        [DisplayName("Media Description")]
        [ReadOnly(true)]
        public string Description => GetString(p => p.Description, ref _description);

        #endregion
        #region DiscCount

        private int _discCount = int.MaxValue;
        [Browsable(true)]
        [Category(Media)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An unsigned integer containing the number of discs in the boxed set containing the media represented by the selected item(s), or zero if not specified.")]
        [DisplayName("# Discs")]
        public int DiscCount
        {
            get => GetInt(p => p.DiscCount, ref _discCount);
            set
            {
                SetValue(Tag.DiscCount, p => p.DiscCount, p => p.DiscCount = value);
                _discCount = value;
            }
        }

        #endregion
        #region DiscNumber

        private int _discNumber = int.MaxValue;
        [Browsable(true)]
        [Category(Media)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An unsigned integer containing the number of the disc containing the media represented by the selected item(s) in the boxed set.")]
        [DisplayName("Disc #")]
        public int DiscNumber
        {
            get => GetInt(p => p.DiscNumber, ref _discNumber);
            set
            {
                SetValue(Tag.DiscNumber, p => p.DiscNumber, p => p.DiscNumber = value);
                _discNumber = value;
            }
        }

        #endregion
        #region DiscOf

        private string _discOf;
        [Browsable(false)]
        [Category(Media)]
        [Column(50, Alignment.Far)]
        [Description("A string containing both the number of the disc, and the total number of discs in the boxed set, containing the media represented by the selected item(s).")]
        [DisplayName("Disc # of #")]
        [ReadOnly(true)]
        [Uses(Tag.DiscNumber, Tag.DiscCount)]
        public string DiscOf => GetString(p => p.DiscOf, ref _discOf);

        #endregion
        #region DiscTrack

        private string _discTrack;
        [Browsable(false)]
        [Category(Media)]
        [Column(80, Alignment.Far)]
        [Description("A string containing the track number, the total number of tracks, the disc number, and the total number of discs in the boxed set, containing the media represented by the selected item(s).")]
        [DisplayName("Disc & Track #")]
        [ReadOnly(true)]
        [Uses(Tag.DiscCount, Tag.DiscNumber, Tag.TrackCount, Tag.TrackNumber)]
        public string DiscTrack => GetString(p => p.DiscTrack, ref _discTrack);

        #endregion
        #region Duration

        private TimeSpan _duration = TimeSpan.MaxValue;
        [Browsable(true)]
        [Category(Details)]
        [Column(50)]
        [Description("A TimeSpan containing the duration of the media represented by the selected item(s). If the duration was set in the constructor, that value is returned. Otherwise, the longest codec duration is used.")]
        [DisplayName("Duration")]
        [ReadOnly(true)]
        public TimeSpan Duration => GetTimeSpan(p => p.Duration, ref _duration);

        #endregion
        #region FileAttributes

        private string _fileAttributes;
        [Browsable(false)]
        [Category(File)]
        [Description("A string representing the filesystem attributes of the file containing the selected media.")]
        [DisplayName("File Attributes")]
        [ReadOnly(true)]
        public string FileAttributes => GetString(p => p.FileAttributes, ref _fileAttributes);

        #endregion
        #region FileCreationTime

        private DateTime _fileCreationTime = DateTime.MaxValue;
        [Browsable(false)]
        [Category(File)]
        [Column(100)]
        [Description("A DateTime value representing the date and time of creation of the file containing the selected media.")]
        [DisplayName("File Created")]
        [ReadOnly(true)]
        public DateTime FileCreationTime => GetDateTime(p => p.FileCreationTime, ref _fileCreationTime);

        #endregion
        #region FileCreationTimeUtc

        private DateTime _fileCreationTimeUtc = DateTime.MaxValue;
        [Browsable(false)]
        [Category(File)]
        [Column(100)]
        [Description("A DateTime value representing the date and time of creation of the file containing the selected media, expressed in Coordinated Universal Time (UTC).")]
        [DisplayName("File Created (UTC)")]
        [ReadOnly(true)]
        public DateTime FileCreationTimeUtc => GetDateTime(p => p.FileCreationTimeUtc, ref _fileCreationTimeUtc);

        #endregion
        #region FileExtension

        private string _fileExtension;
        [Browsable(false)]
        [Category(File)]
        [Column(50)]
        [Description("A string containing just the file extension portion of the full path to the media file in the filesystem.")]
        [DisplayName("File Extension")]
        [ReadOnly(true)]
        public string FileExtension => GetString(p => p.FileExtension, ref _fileExtension);

        #endregion
        #region FileLastAccessTime

        private DateTime _fileLastAccessTime = DateTime.MaxValue;
        [Browsable(false)]
        [Category(File)]
        [Column(100)]
        [Description("A DateTime value representing the date and time of last access of the file containing the selected media.")]
        [DisplayName("File Accessed")]
        [ReadOnly(true)]
        public DateTime FileLastAccessTime => GetDateTime(p => p.FileLastAccessTime, ref _fileLastAccessTime);

        #endregion
        #region FileLastAccessTimeUtc

        private DateTime _fileLastAccessTimeUtc = DateTime.MaxValue;
        [Browsable(false)]
        [Category(File)]
        [Column(100)]
        [Description("A DateTime value representing the date and time of last access of the file containing the selected media, expressed in Coordinated Universal Time (UTC).")]
        [DisplayName("File Accessed (UTC)")]
        [ReadOnly(true)]
        public DateTime FileLastAccessTimeUtc => GetDateTime(p => p.FileLastAccessTimeUtc, ref _fileLastAccessTimeUtc);

        #endregion
        #region FileLastWriteTime

        private DateTime _fileLastWriteTime = DateTime.MaxValue;
        [Browsable(false)]
        [Category(File)]
        [Column(100)]
        [Description("A DateTime value representing the date and time of last writing of the file containing the selected media.")]
        [DisplayName("File Modified")]
        [ReadOnly(true)]
        public DateTime FileLastWriteTime => GetDateTime(p => p.FileLastWriteTime, ref _fileLastWriteTime);

        #endregion
        #region FileLastWriteTimeUtc

        private DateTime _fileLastWriteTimeUtc = DateTime.MaxValue;
        [Browsable(false)]
        [Category(File)]
        [Column(100)]
        [Description("A DateTime value representing the date and time of last writing of the file containing the selected media, expressed in Coordinated Universal Time (UTC).")]
        [DisplayName("File Modified (UTC)")]
        [ReadOnly(true)]
        public DateTime FileLastWriteTimeUtc => GetDateTime(p => p.FileLastWriteTimeUtc, ref _fileLastWriteTimeUtc);

        #endregion
        #region FileName

        private string _fileName;
        [Browsable(false)]
        [Category(File)]
        [Column(160)]
        [Description("A string containing just the file name portion (including any extension) of the full path to the media file in the filesystem.")]
        [DisplayName("File Name")]
        [ReadOnly(true)]
        public string FileName => GetString(p => p.FileName, ref _fileName);

        #endregion
        #region FileNameWithoutExtension

        private string _fileNameWithoutExtension;
        [Browsable(false)]
        [Category(File)]
        [Column(160)]
        [Description("A string containing just the file name portion (excluding any extension) of the full path to the media file in the filesystem.")]
        [DisplayName("File Name (no ext)")]
        [ReadOnly(true)]
        public string FileNameWithoutExtension => GetString(p => p.FileNameWithoutExtension, ref _fileNameWithoutExtension);

        #endregion
        #region FilePath

        private string _filePath;
        [Browsable(true)]
        [Category(File)]
        [Column(320)]
        [Description("A string containing the full path to the media file or folder in the filesystem.")]
        [DisplayName("File Path")]
        [ReadOnly(true)]
        public string FilePath => GetFileOrCommonFolderPath(p => p.FilePath, ref _filePath);

        #endregion
        #region FileSize

        private long _fileSize = long.MaxValue;
        [Browsable(true)]
        [Category(File)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("A long integer containing the byte length of the media file in the filesystem.")]
        [DisplayName("File Size")]
        [ReadOnly(true)]
        public long FileSize => GetLong(p => p.FileSize, ref _fileSize, true); // Files.Sum(f => f.FileSize);

        #endregion
        #region FileStatus

        private FileStatus _fileStatus = FileStatus.Unknown;
        [Browsable(true)]
        [Category(File)]
        [Column(50)]
        [Description("An enumeration value containing the combined FileStatus values of all items in the selection. Possible values are:\r\n\r\n"
                     + "-- Unknown: the item has no recognised FileStatus value.\r\n"
                     + "-- Current: the item's library entry exactly matches its media file.\r\n"
                     + "-- New: the item's media file does not yet have a corresponding saved library entry.\r\n"
                     + "-- Pending: the item's library entry contains more recent edits than its media file.\r\n"
                     + "-- Updated: the item's media file contains more recent edits than its library entry.\r\n"
                     + "-- Deleted: the item's media file no longer exists; its library entry is orphaned.\r\n"
                     + "-- Changed: the item's status is a combination of New, Pending, Updated and/or Deleted.\r\n\r\n"
                     + "During the synchronization process, Changed items are processed as follows:\r\n\r\n"
                     + "-- New items are added to the library.\r\n"
                     + "-- Pending edits are applied to the corresponding media files.\r\n"
                     + "-- Updated items have their library entries brought up to date.\r\n"
                     + "-- Deleted items are removed from the library.")]
        [DisplayName("File Status")]
        [ReadOnly(true)]
        public FileStatus FileStatus => GetFileStatus(p => p.FileStatus, ref _fileStatus);

        #endregion
        #region FirstAlbumArtist

        private string _firstAlbumArtist;
        [Browsable(false)]
        [Category(Personnel)]
        [Column(160)]
        [Description("A string containing the first band or artist who is credited in the creation of the entire album or collection containing the media described by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("First Album Artist")]
        [ReadOnly(true)]
        [Uses(Tag.AlbumArtists)]
        public string FirstAlbumArtist => GetString(p => p.FirstAlbumArtist, ref _firstAlbumArtist);

        #endregion
        #region FirstAlbumArtistSort

        private string _firstAlbumArtistSort;
        [Browsable(false)]
        [Category(Personnel)]
        [Column(160)]
        [Description("A string containing the sort names for the first band or artist who is credited in the creation of the entire album or collection containing the media described by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("First Album Artist (sorted)")]
        [ReadOnly(true)]
        [Uses(Tag.AlbumArtistsSort)]
        public string FirstAlbumArtistSort => GetString(p => p.FirstAlbumArtistSort, ref _firstAlbumArtistSort);

        #endregion
        #region FirstArtist

        private string _firstArtist;
        [Browsable(false)]
        [Category(Personnel)]
        [Column(160)]
        [Description("A string containing the sort name for the first performer or artist who performed in the media described by the selected item(s), or an empty string if no value is present. (Obsolete. For album artists, use FirstAlbumArtist. For track artists, use FirstPerformer.)")]
        [DisplayName("First Artist")]
        [Obsolete("Obsolete. For album artists, use FirstAlbumArtist. For track artists, use FirstPerformer.")]
        [ReadOnly(true)]
        [Uses(Tag.Artists)]
        public string FirstArtist => GetString(p => p.FirstArtist, ref _firstArtist);

        #endregion
        #region FirstComposer

        private string _firstComposer;
        [Browsable(false)]
        [Category(Personnel)]
        [Column(160)]
        [Description("A string containing the first composer of the media represented by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("First Composer")]
        [ReadOnly(true)]
        [Uses(Tag.Composers)]
        public string FirstComposer => GetString(p => p.FirstComposer, ref _firstComposer);

        #endregion
        #region FirstComposerSort

        private string _firstComposerSort;
        [Browsable(false)]
        [Category(Personnel)]
        [Column(160)]
        [Description("A string containing the sort name for first composer of the media represented by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("First Composer (sorted)")]
        [ReadOnly(true)]
        [Uses(Tag.ComposersSort)]
        public string FirstComposerSort => GetString(p => p.FirstComposerSort, ref _firstComposerSort);

        #endregion
        #region FirstGenre

        private string _firstGenre;
        [Browsable(false)]
        [Category(Category)]
        [Column(160)]
        [Description("A string containing the first genre of the media represented by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("First Genre")]
        [ReadOnly(true)]
        [Uses(Tag.Genres)]
        public string FirstGenre => GetString(p => p.FirstGenre, ref _firstGenre);

        #endregion
        #region FirstPerformer

        private string _firstPerformer;
        [Browsable(false)]
        [Category(Personnel)]
        [Column(160)]
        [Description("A string containing the first performer or artist who performed in the media described by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("First Performer")]
        [ReadOnly(true)]
        [Uses(Tag.Performers)]
        public string FirstPerformer => GetString(p => p.FirstPerformer, ref _firstPerformer);

        #endregion
        #region FirstPerformerSort

        private string _firstPerformerSort;
        [Browsable(false)]
        [Category(Personnel)]
        [Column(160)]
        [Description("A string containing the sort name for the first performer or artist who performed in the media described by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("First Performer (sorted)")]
        [ReadOnly(true)]
        [Uses(Tag.PerformersSort)]
        public string FirstPerformerSort => GetString(p => p.FirstPerformerSort, ref _firstPerformerSort);

        #endregion
        #region Genres

        private string[] _genres;
        [Browsable(true)]
        [Category(Category)]
        [Column(160)]
        [Description("A string array containing the genres of the media represented by the selected item(s), or an empty array if no value is present.")]
        [DisplayName("Genres")]
        public string[] Genres
        {
            get => GetStringArray(p => p.Genres, ref _genres);
            set
            {
                SetValue(Tag.Genres, p => p.Genres, p => p.Genres = value);
                _genres = null;
                _firstGenre = null;
                _joinedGenres = null;
                _isClassical = Logical.Unknown;
            }
        }

        #endregion
        #region GenresCount

        private int _genresCount = int.MaxValue;
        [Browsable(false)]
        [Category(Category)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An integer indicating the number of genres of the media represented by the selected item(s), or zero if none are present.")]
        [DisplayName("# Genres")]
        [ReadOnly(true)]
        [Uses(Tag.Genres)]
        public int GenresCount => GetInt(p => p.GenresCount, ref _genresCount);

        #endregion
        #region Grouping

        private string _grouping;
        [Browsable(false)]
        [Category(Category)]
        [Column(160)]
        [Description("A string containing the grouping on the album which the media in the selected item(s) belongs to, or an empty string if no value is present.")]
        [DisplayName("Grouping")]
        public string Grouping
        {
            get => GetString(p => p.Grouping, ref _grouping);
            set
            {
                SetValue(Tag.Grouping, p => p.Grouping, p => p.Grouping = value);
                _grouping = null;
            }
        }

        #endregion
        #region ImageAltitude

        private double _imageAltitude = double.MaxValue;
        [Browsable(false)]
        [Category(Image)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("The altitude, in metres, of the GPS coordinate where the current image was taken. A positive value is above sea level, a negative value below sea level.")]
        [DisplayName("Image Altitude")]
        public double ImageAltitude
        {
            get => GetDouble(p => p.ImageAltitude, ref _imageAltitude);
            set
            {
                SetValue(Tag.ImageAltitude, p => p.ImageAltitude, p => p.ImageAltitude = value);
                _imageAltitude = value;
            }
        }

        #endregion
        #region ImageCreator

        private string _imageCreator;
        [Browsable(false)]
        [Category(Image)]
        [Description("The name of the creator associated with the image.")]
        [DisplayName("Image Creator")]
        public string ImageCreator
        {
            get => GetString(p => p.ImageCreator, ref _imageCreator);
            set
            {
                SetValue(Tag.ImageCreator, p => p.ImageCreator, p => p.ImageCreator = value);
                _imageCreator = value;
            }
        }

        #endregion
        #region ImageDateTime

        private DateTime _imageDateTime = DateTime.MaxValue;
        [Browsable(false)]
        [Category(Image)]
        [Column(100)]
        [Description("The time when the image was taken.")]
        [DisplayName("Image Date/Time")]
        public DateTime ImageDateTime
        {
            get => GetDateTime(p => p.ImageDateTime, ref _imageDateTime);
            set
            {
                SetValue(Tag.ImageDateTime, p => p.ImageDateTime, p => p.ImageDateTime = value);
                _imageDateTime = value;
            }
        }

        #endregion
        #region ImageExposureTime

        private double _imageExposureTime = double.MaxValue;
        [Browsable(false)]
        [Category(Image)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("The image exposure time, in seconds.")]
        [DisplayName("Image Exposure Time")]
        public double ImageExposureTime
        {
            get => GetDouble(p => p.ImageExposureTime, ref _imageExposureTime);
            set
            {
                SetValue(Tag.ImageExposureTime, p => p.ImageExposureTime, p => p.ImageExposureTime = value);
                _imageExposureTime = value;
            }
        }

        #endregion
        #region ImageFNumber

        private double _imageFNumber = double.MaxValue;
        [Browsable(false)]
        [Category(Image)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("The F number with which the image was taken.")]
        [DisplayName("Image 'F' Number")]
        public double ImageFNumber
        {
            get => GetDouble(p => p.ImageFNumber, ref _imageFNumber);
            set
            {
                SetValue(Tag.ImageFNumber, p => p.ImageFNumber, p => p.ImageFNumber = value);
                _imageFNumber = value;
            }
        }

        #endregion
        #region ImageFocalLength

        private double _imageFocalLength = double.MaxValue;
        [Browsable(false)]
        [Category(Image)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("The focal length, in millimetres, with which the image was taken.")]
        [DisplayName("Image Focal Length")]
        public double ImageFocalLength
        {
            get => GetDouble(p => p.ImageFocalLength, ref _imageFocalLength);
            set
            {
                SetValue(Tag.ImageFocalLength, p => p.ImageFocalLength, p => p.ImageFocalLength = value);
                _imageFocalLength = value;
            }
        }

        #endregion
        #region ImageFocalLengthIn35mmFilm

        private int _imageFocalLengthIn35mmFilm = int.MaxValue;
        [Browsable(false)]
        [Category(Image)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("The focal length with which the image was taken, assuming a 35mm film camera.")]
        [DisplayName("Image Focal Length (35mm)")]
        public int ImageFocalLengthIn35mmFilm
        {
            get => GetInt(p => p.ImageFocalLengthIn35mmFilm, ref _imageFocalLengthIn35mmFilm);
            set
            {
                SetValue(Tag.ImageFocalLengthIn35mmFilm, p => p.ImageFocalLengthIn35mmFilm, p => p.ImageFocalLengthIn35mmFilm = value);
                _imageFocalLengthIn35mmFilm = value;
            }
        }

        #endregion
        #region ImageISOSpeedRatings

        private int _imageISOSpeedRatings = int.MaxValue;
        [Browsable(false)]
        [Category(Image)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("The ISO speed, as defined in ISO 12232, with which the image was taken.")]
        [DisplayName("Image ISO Speed")]
        public int ImageISOSpeedRatings
        {
            get => GetInt(p => p.ImageISOSpeedRatings, ref _imageISOSpeedRatings);
            set
            {
                SetValue(Tag.ImageISOSpeedRatings, p => p.ImageISOSpeedRatings, p => p.ImageISOSpeedRatings = value);
                _imageISOSpeedRatings = value;
            }
        }

        #endregion
        #region ImageKeywords

        private string[] _imageKeywords;
        [Browsable(false)]
        [Category(Image)]
        [Description("The list of keywords associated with the image.")]
        [DisplayName("Image Keywords")]
        public string[] ImageKeywords
        {
            get => GetStringArray(p => p.ImageKeywords, ref _imageKeywords);
            set
            {
                SetValue(Tag.ImageKeywords, p => p.ImageKeywords, p => p.ImageKeywords = value);
                _imageKeywords = value;
            }
        }

        #endregion
        #region ImageLatitude

        private double _imageLatitude = double.MaxValue;
        [Browsable(false)]
        [Category(Image)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("The latitude of the GPS coordinate where the current image was taken. Latitude ranges from -90.0 to +90.0 degrees.")]
        [DisplayName("Image Latitude")]
        public double ImageLatitude
        {
            get => GetDouble(p => p.ImageLatitude, ref _imageLatitude);
            set
            {
                SetValue(Tag.ImageLatitude, p => p.ImageLatitude, p => p.ImageLatitude = value);
                _imageLatitude = value;
            }
        }

        #endregion
        #region ImageLongitude

        private double _imageLongitude = double.MaxValue;
        [Browsable(false)]
        [Category(Image)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("The longitude of the GPS coordinate where the current image was taken. Longitude ranges from -180.0 to +180.0 degrees.")]
        [DisplayName("Image Longitude")]
        public double ImageLongitude
        {
            get => GetDouble(p => p.ImageLongitude, ref _imageLongitude);
            set
            {
                SetValue(Tag.ImageLongitude, p => p.ImageLongitude, p => p.ImageLongitude = value);
                _imageLongitude = value;
            }
        }

        #endregion
        #region ImageMake

        private string _imageMake;
        [Browsable(false)]
        [Category(Image)]
        [Description("The name of the manufacture of the recording equipment with which the image was taken.")]
        [DisplayName("Image Make")]
        public string ImageMake
        {
            get => GetString(p => p.ImageMake, ref _imageMake);
            set
            {
                SetValue(Tag.ImageMake, p => p.ImageMake, p => p.ImageMake = value);
                _imageMake = value;
            }
        }

        #endregion
        #region ImageModel

        private string _imageModel;
        [Browsable(false)]
        [Category(Image)]
        [Description("The model name and/or number of the recording equipment with which the image was taken.")]
        [DisplayName("Image Model")]
        public string ImageModel
        {
            get => GetString(p => p.ImageModel, ref _imageModel);
            set
            {
                SetValue(Tag.ImageModel, p => p.ImageModel, p => p.ImageModel = value);
                _imageModel = value;
            }
        }

        #endregion
        #region ImageOrientation

        private TagLib.Image.ImageOrientation _imageOrientation = TagLib.Image.ImageOrientation.None;
        [Browsable(false)]
        [Category(Image)]
        [DefaultValue(TagLib.Image.ImageOrientation.None)]
        [Description("The orientation of the image.")]
        [DisplayName("Image Orientation")]
        public TagLib.Image.ImageOrientation ImageOrientation
        {
            get => GetImageOrientation(p => p.ImageOrientation, ref _imageOrientation);
            set
            {
                SetValue(Tag.ImageOrientation, p => p.ImageOrientation, p => p.ImageOrientation = value);
                _imageOrientation = value;
            }
        }

        #endregion
        #region ImageRating

        private int _imageRating = int.MaxValue;
        [Browsable(false)]
        [Category(Image)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("The rating of the image.")]
        [DisplayName("Image Rating")]
        public int ImageRating
        {
            get => GetInt(p => p.ImageRating, ref _imageRating);
            set
            {
                SetValue(Tag.ImageRating, p => p.ImageRating, p => p.ImageRating = value);
                _imageRating = value;
            }
        }

        #endregion
        #region ImageSoftware

        private string _imageSoftware;
        [Browsable(false)]
        [Category(Image)]
        [Description("The name of the software with which the image was created.")]
        [DisplayName("Image Software")]
        public string ImageSoftware
        {
            get => GetString(p => p.ImageSoftware, ref _imageSoftware);
            set
            {
                SetValue(Tag.ImageSoftware, p => p.ImageSoftware, p => p.ImageSoftware = value);
                _imageSoftware = value;
            }
        }

        #endregion
        #region InvariantEndPosition

        private long _invariantEndPosition = long.MaxValue;
        [Browsable(false)]
        [Category(Format)]
        [Column(80)]
        [DefaultValue(0)]
        [Description("A long integer containing the position at which the invariant portion of the selected item(s) ends.")]
        [DisplayName("Invariant End Position")]
        [ReadOnly(true)]
        public long InvariantEndPosition => GetLong(p => p.InvariantEndPosition, ref _invariantEndPosition, false);

        #endregion
        #region InvariantStartPosition

        private long _invariantStartPosition = long.MaxValue;
        [Browsable(false)]
        [Category(Format)]
        [Column(80)]
        [DefaultValue(0)]
        [Description("A long integer containing the position at which the invariant portion of the selected item(s) begins.")]
        [DisplayName("Invariant Start Position")]
        [ReadOnly(true)]
        public long InvariantStartPosition => GetLong(p => p.InvariantStartPosition, ref _invariantStartPosition, false);

        #endregion
        #region IsClassical

        private Logical _isClassical = Logical.Unknown;
        [Browsable(false)]
        [Category(Category)]
        [Column(50)]
        [Description("A bool indicating whether or not the first genre of the selected item(s) is 'Classical'.")]
        [DisplayName("Classical?")]
        [ReadOnly(true)]
        [Uses(Tag.Genres)]
        public Logical IsClassical => GetLogical(p => p.IsClassical, ref _isClassical);

        #endregion
        #region IsEmpty

        private Logical _isEmpty = Logical.Unknown;
        [Browsable(false)]
        [Category(Format)]
        [Column(50)]
        [Description("A bool indicating whether the selected item(s) contains any tag values.")]
        [DisplayName("Empty?")]
        [ReadOnly(true)]
        public Logical IsEmpty => GetLogical(p => p.IsEmpty, ref _isEmpty);

        #endregion
        #region JoinedAlbumArtists

        private string _joinedAlbumArtists;
        [Browsable(true)]
        [Category(Personnel)]
        [Column(160)]
        [Description("A string containing the artist(s) credited in the creation of the entire album or collection containing the media described by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("Album Artist")]
        [ReadOnly(true)]
        [Uses(Tag.AlbumArtists)]
        public string JoinedAlbumArtists => GetString(p => p.JoinedAlbumArtists, ref _joinedAlbumArtists);

        #endregion
        #region JoinedArtists

        private string _joinedArtists;
        [Browsable(false)]
        [Category(Personnel)]
        [Column(160)]
        [Description("A string containing the sort names for the performers or artists who performed in the media described by the selected item(s), or an empty string if no value is present. (Obsolete. For album artists, use JoinedAlbumArtists. For track artists, use JoinedPerformers.)")]
        [DisplayName("Artists (joined)")]
        [Obsolete("Obsolete. For album artists, use JoinedAlbumArtists. For track artists, use JoinedPerformers.")]
        [ReadOnly(true)]
        [Uses(Tag.Artists)]
        public string JoinedArtists => GetString(p => p.JoinedArtists, ref _joinedArtists);

        #endregion
        #region JoinedComposers

        private string _joinedComposers;
        [Browsable(true)]
        [Category(Personnel)]
        [Column(160)]
        [Description("A string containing the composers of the media represented by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("Composer")]
        [ReadOnly(true)]
        [Uses(Tag.Composers)]
        public string JoinedComposers => GetString(p => p.JoinedComposers, ref _joinedComposers);

        #endregion
        #region JoinedGenres

        private string _joinedGenres;
        [Browsable(true)]
        [Category(Category)]
        [Column(160)]
        [Description("A string containing the genres of the media represented by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("Genre")]
        [ReadOnly(true)]
        [Uses(Tag.Genres)]
        public string JoinedGenres => GetString(p => p.JoinedGenres, ref _joinedGenres);

        #endregion
        #region JoinedPerformers

        private string _joinedPerformers;
        [Browsable(true)]
        [Category(Personnel)]
        [Column(160)]
        [Description("A string containing the performers or artists who performed in the media described by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("Artist")]
        [ReadOnly(true)]
        [Uses(Tag.Performers)]
        public string JoinedPerformers => GetString(p => p.JoinedPerformers, ref _joinedPerformers);

        #endregion
        #region JoinedPerformersSort

        private string _joinedPerformersSort;
        [Browsable(false)]
        [Category(Personnel)]
        [Column(160)]
        [Description("A string containing the sort names for the performers or artists who performed in the media described by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("Performers (joined, sorted)")]
        [ReadOnly(true)]
        [Uses(Tag.PerformersSort)]
        public string JoinedPerformersSort => GetString(p => p.JoinedPerformersSort, ref _joinedPerformersSort);

        #endregion
        #region Lyrics

        private string _lyrics;
        [Browsable(false)]
        [Category(Details)]
        [Column(320)]
        [Description("A string containing the lyrics or script of the media represented by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("Lyrics")]
        public string Lyrics
        {
            get => GetString(p => p.Lyrics, ref _lyrics);
            set
            {
                SetValue(Tag.Lyrics, p => p.Lyrics, p => p.Lyrics = value);
                _lyrics = null;
            }
        }

        #endregion
        #region MediaTypes

        const TagLib.MediaTypes AllMediaTypes = (TagLib.MediaTypes)15;
        private TagLib.MediaTypes _mediaTypes = AllMediaTypes;
        [Browsable(false)]
        [Category(Format)]
        [Description("Gets the media types contained in the selected item(s).")]
        [DisplayName("Media Types")]
        [ReadOnly(true)]
        public TagLib.MediaTypes MediaTypes => GetMediaTypes(p => p.MediaTypes, ref _mediaTypes);

        #endregion
        #region Millennium

        private string _millennium;
        [Browsable(false)]
        [Category(Category)]
        [Column(50)]
        [Description("A string containing the millennium that the media represented by the selected item(s) was created, or zero if no value is present.")]
        [DisplayName("Millennium")]
        [ReadOnly(true)]
        [Uses(Tag.Year)]
        public string Millennium => GetString(p => p.Millennium, ref _millennium);

        #endregion
        #region MimeType

        private string _mimeType;
        [Browsable(false)]
        [Category(Format)]
        [Column(50)]
        [Description("A string containing the MimeType of the media represented by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("Mime Type")]
        [ReadOnly(true)]
        public string MimeType => GetString(p => p.MimeType, ref _mimeType);

        #endregion
        #region MusicBrainzArtistId

        private string _musicBrainzArtistId;
        [Browsable(false)]
        [Category(Metadata)]
        [Description("A string containing the MusicBrainz Artist ID for the media described by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("MusicBrainz Artist ID")]
        public string MusicBrainzArtistId
        {
            get => GetString(p => p.MusicBrainzArtistId, ref _musicBrainzArtistId);
            set
            {
                SetValue(Tag.MusicBrainzArtistId, p => p.MusicBrainzArtistId, p => p.MusicBrainzArtistId = value);
                _musicBrainzArtistId = null;
            }
        }

        #endregion
        #region MusicBrainzDiscId

        private string _musicBrainzDiscId;
        [Browsable(false)]
        [Category(Metadata)]
        [Description("A string containing the MusicBrainz Disc ID for the media described by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("MusicBrainz Disc ID")]
        public string MusicBrainzDiscId
        {
            get => GetString(p => p.MusicBrainzDiscId, ref _musicBrainzDiscId);
            set
            {
                SetValue(Tag.MusicBrainzDiscId, p => p.MusicBrainzDiscId, p => p.MusicBrainzDiscId = value);
                _musicBrainzDiscId = null;
            }
        }

        #endregion
        #region MusicBrainzReleaseArtistId

        private string _musicBrainzReleaseArtistId;
        [Browsable(false)]
        [Category(Metadata)]
        [Description("A string containing the MusicBrainz Release Artist ID for the media described by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("MusicBrainz Release Artist ID")]
        public string MusicBrainzReleaseArtistId
        {
            get => GetString(p => p.MusicBrainzReleaseArtistId, ref _musicBrainzReleaseArtistId);
            set
            {
                SetValue(Tag.MusicBrainzReleaseArtistId, p => p.MusicBrainzReleaseArtistId, p => p.MusicBrainzReleaseArtistId = value);
                _musicBrainzReleaseArtistId = null;
            }
        }

        #endregion
        #region MusicBrainzReleaseCountry

        private string _musicBrainzReleaseCountry;
        [Browsable(false)]
        [Category(Metadata)]
        [Description("A string containing the MusicBrainz Release Country for the media described by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("MusicBrainz Release Country")]
        public string MusicBrainzReleaseCountry
        {
            get => GetString(p => p.MusicBrainzReleaseCountry, ref _musicBrainzReleaseCountry);
            set
            {
                SetValue(Tag.MusicBrainzReleaseCountry, p => p.MusicBrainzReleaseCountry, p => p.MusicBrainzReleaseCountry = value);
                _musicBrainzReleaseCountry = null;
            }
        }

        #endregion
        #region MusicBrainzReleaseId

        private string _musicBrainzReleaseId;
        [Browsable(false)]
        [Category(Metadata)]
        [Description("A string containing the MusicBrainz Release ID for the media described by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("MusicBrainz Release ID")]
        public string MusicBrainzReleaseId
        {
            get => GetString(p => p.MusicBrainzReleaseId, ref _musicBrainzReleaseId);
            set
            {
                SetValue(Tag.MusicBrainzReleaseId, p => p.MusicBrainzReleaseId, p => p.MusicBrainzReleaseId = value);
                _musicBrainzReleaseId = null;
            }
        }

        #endregion
        #region MusicBrainzReleaseStatus

        private string _musicBrainzReleaseStatus;
        [Browsable(false)]
        [Category(Metadata)]
        [Description("A string containing the MusicBrainz Release Status for the media described by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("MusicBrainz Release Status")]
        public string MusicBrainzReleaseStatus
        {
            get => GetString(p => p.MusicBrainzReleaseStatus, ref _musicBrainzReleaseStatus);
            set
            {
                SetValue(Tag.MusicBrainzReleaseStatus, p => p.MusicBrainzReleaseStatus, p => p.MusicBrainzReleaseStatus = value);
                _musicBrainzReleaseStatus = null;
            }
        }

        #endregion
        #region MusicBrainzReleaseType

        private string _musicBrainzReleaseType;
        [Browsable(false)]
        [Category(Metadata)]
        [Description("A string containing the MusicBrainz Release Type for the media described by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("MusicBrainz Release Type")]
        public string MusicBrainzReleaseType
        {
            get => GetString(p => p.MusicBrainzReleaseType, ref _musicBrainzReleaseType);
            set
            {
                SetValue(Tag.MusicBrainzReleaseType, p => p.MusicBrainzReleaseType, p => p.MusicBrainzReleaseType = value);
                _musicBrainzReleaseType = null;
            }
        }

        #endregion
        #region MusicBrainzTrackId

        private string _musicBrainzTrackId;
        [Browsable(false)]
        [Category(Metadata)]
        [Description("A string containing the MusicBrainz Track ID for the media described by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("MusicBrainz Track ID")]
        public string MusicBrainzTrackId
        {
            get => GetString(p => p.MusicBrainzTrackId, ref _musicBrainzTrackId);
            set
            {
                SetValue(Tag.MusicBrainzTrackId, p => p.MusicBrainzTrackId, p => p.MusicBrainzTrackId = value);
                _musicBrainzTrackId = null;
            }
        }

        #endregion
        #region MusicIpId

        private string _musicIpId;
        [Browsable(false)]
        [Category(Metadata)]
        [Description("A string containing the MusicIP PUID for the media described by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("MusicIP PUID")]
        public string MusicIpId
        {
            get => GetString(p => p.MusicIpId, ref _musicIpId);
            set
            {
                SetValue(Tag.MusicIpId, p => p.MusicIpId, p => p.MusicIpId = value);
                _musicIpId = null;
            }
        }

        #endregion
        #region Performers

        private string[] _performers;
        [Browsable(true)]
        [Category(Personnel)]
        [Column(160)]
        [Description("A string array containing the performers or artists who performed in the media described by the selected item(s), or an empty array if no value is present.")]
        [DisplayName("Performers")]
        public string[] Performers
        {
            get => GetStringArray(p => p.Performers, ref _performers);
            set
            {
                SetValue(Tag.Performers, p => p.Performers, p => p.Performers = value);
                _performers = null;
                _firstPerformer = null;
                _joinedPerformers = null;
            }
        }

        #endregion
        #region PerformersCount

        private int _performersCount = int.MaxValue;
        [Browsable(false)]
        [Category(Personnel)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An integer indicating the number of performers or artists who performed in the media described by the selected item(s), or zero if none are present.")]
        [DisplayName("# Performers")]
        [ReadOnly(true)]
        [Uses(Tag.Performers)]
        public int PerformersCount => GetInt(p => p.PerformersCount, ref _performersCount);

        #endregion
        #region PerformersSort

        private string[] _performersSort;
        [Browsable(false)]
        [Category(Personnel)]
        [Column(160)]
        [Description("A string array containing the sort names for the performers or artists who performed in the media described by the selected item(s), or an empty array if no value is present.")]
        [DisplayName("Performers (sorted)")]
        public string[] PerformersSort
        {
            get => GetStringArray(p => p.PerformersSort, ref _performersSort);
            set
            {
                SetValue(Tag.PerformersSort, p => p.PerformersSort, p => p.PerformersSort = value);
                _performersSort = null;
                _firstPerformerSort = null;
                _joinedPerformersSort = null;
            }
        }

        #endregion
        #region PerformersSortCount

        private int _performersSortCount = int.MaxValue;
        [Browsable(false)]
        [Category(Personnel)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An integer indicating the number of performers or artists who performed in the media described by the selected item(s), or zero if none are present.")]
        [DisplayName("# Performers (sorted)")]
        [ReadOnly(true)]
        [Uses(Tag.PerformersSort)]
        public int PerformersSortCount => GetInt(p => p.PerformersSortCount, ref _performersSortCount);

        #endregion
        #region PhotoHeight

        private int _photoHeight = int.MaxValue;
        [Browsable(false)]
        [Category(Media)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An integer value containing the height of the photo represented by the selected item(s).")]
        [DisplayName("Photo Height")]
        [ReadOnly(true)]
        public int PhotoHeight => GetInt(p => p.PhotoHeight, ref _photoHeight);

        #endregion
        #region PhotoQuality

        private int _photoQuality = int.MaxValue;
        [Browsable(false)]
        [Category(Media)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An integer containing the (format specific) quality indicator of the photo represented by the selected item(s). A value of 0 means that there was no quality indicator for the format or the file.")]
        [DisplayName("Photo Quality")]
        [ReadOnly(true)]
        public int PhotoQuality => GetInt(p => p.PhotoQuality, ref _photoQuality);

        #endregion                                                                                                                                                                                                                                                                                                                       r
        #region PhotoWidth

        private int _photoWidth = int.MaxValue;
        [Browsable(false)]
        [Category(Media)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An integer value containing the width of the photo represented by the selected item(s).")]
        [DisplayName("Photo Width")]
        [ReadOnly(true)]
        public int PhotoWidth => GetInt(p => p.PhotoWidth, ref _photoWidth);

        #endregion
        #region Pictures

        private Picture[] _pictures = null;
        [Browsable(true)]
        [Category(Media)]
        [Column(50)]
        [Description("A Picture array containing the embedded pictures in the selected item(s).")]
        [DisplayName("Pictures")]
        [ReadOnly(true)]
        public Picture[] Pictures => GetPictures(p => p.Pictures, ref _pictures);

        #endregion
        #region PicturesCount

        private int _picturesCount = int.MaxValue;
        [Browsable(false)]
        [Category(Media)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An integer indicating the number of embedded pictures in the selected item(s), or zero if none are present.")]
        [DisplayName("# Pictures")]
        [ReadOnly(true)]
        [Uses(Tag.Pictures)]
        public int PicturesCount => GetInt(p => p.PicturesCount, ref _picturesCount);

        #endregion
        #region PossiblyCorrupt

        private Logical _possiblyCorrupt = Logical.Unknown;
        [Browsable(false)]
        [Category(Format)]
        [Column(50)]
        [Description("A bool indicating whether the selected item(s) contains any tag values.")]
        [DisplayName("Possibly Corrupt?")]
        [ReadOnly(true)]
        public Logical PossiblyCorrupt => GetLogical(p => p.PossiblyCorrupt, ref _possiblyCorrupt);

        #endregion
        #region SelectedAlbumsCount

        [Browsable(true)]
        [Category(Selected)]
        [Column(50)]
        [Description("The number of unique album titles in the current selection.")]
        [DisplayName("# Selected Albums")]
        [ReadOnly(true)]
        public int SelectedAlbumsCount => Tracks.Select(f => f.Album).Distinct().Count();

        #endregion
        #region SelectedArtistsCount

        [Browsable(true)]
        [Category(Selected)]
        [Column(50)]
        [Description("The number of unique artists in the current selection.")]
        [DisplayName("# Selected Artists")]
        [ReadOnly(true)]
        public int SelectedArtistsCount => Tracks.SelectMany(f => f.Performers).Distinct().Count();

        #endregion
        #region SelectedFoldersCount

        [Browsable(true)]
        [Category(Selected)]
        [Column(50)]
        [Description("The number of distinct folders containing one or more items from the selection.")]
        [DisplayName("# Selected Folders")]
        [ReadOnly(true)]
        public int SelectedFoldersCount
        {
            get
            {
                try
                {
                    return Tracks.Select(p => Path.GetDirectoryName(p.FilePath)).Distinct().Count();
                }
                catch (ArgumentException)
                {
                    return 0;
                }
            }
        }

        #endregion
        #region SelectedGenresCount

        [Browsable(true)]
        [Category(Selected)]
        [Column(50)]
        [Description("The number of unique genres in the current selection.")]
        [DisplayName("# Selected Genres")]
        [ReadOnly(true)]
        public int SelectedGenresCount => Tracks.SelectMany(f => f.Genres).Distinct().Count();

        #endregion
        #region SelectedTracksCount

        [Browsable(true)]
        [Category(Selected)]
        [Column(50)]
        [Description("The total number of tracks in the current selection.")]
        [DisplayName("# Selected Tracks")]
        [ReadOnly(true)]
        public int SelectedTracksCount => Tracks.Count();

        #endregion
        #region TagTypes

        private TagLib.TagTypes _tagTypes = TagLib.TagTypes.AllTags;
        [Browsable(false)]
        [Category(Format)]
        [Description("Gets the tag types contained in the selected item(s).")]
        [DisplayName("Tag Types")]
        [ReadOnly(true)]
        public TagLib.TagTypes TagTypes => GetTagTypes(p => p.TagTypes, ref _tagTypes);

        #endregion
        #region TagTypesOnDisk

        private TagLib.TagTypes _tagTypesOnDisk = TagLib.TagTypes.AllTags;
        [Browsable(false)]
        [Category(Format)]
        [Description("Gets the tag types contained in the physical file represented by the selected item(s).")]
        [DisplayName("Tag Types on Disk")]
        [ReadOnly(true)]
        public TagLib.TagTypes TagTypesOnDisk => GetTagTypes(p => p.TagTypesOnDisk, ref _tagTypesOnDisk);

        #endregion
        #region Title

        private string _title;
        [Browsable(true)]
        [Category(Details)]
        [Column(160)]
        [Description("A string containing the title for the media described by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("Title")]
        public string Title
        {
            get => GetString(p => p.Title, ref _title);
            set
            {
                SetValue(Tag.Title, p => p.Title, p => p.Title = value);
                _title = null;
            }
        }

        #endregion
        #region TitleSort

        private string _titleSort;
        [Browsable(false)]
        [Category(Details)]
        [Column(160)]
        [Description("A string containing the sort name for the Title of the media described by the selected item(s), or an empty string if no value is present.")]
        [DisplayName("Title (sort by)")]
        public string TitleSort
        {
            get => GetString(p => p.TitleSort, ref _titleSort);
            set
            {
                SetValue(Tag.TitleSort, p => p.TitleSort, p => p.TitleSort = value);
                _titleSort = null;
            }
        }

        #endregion
        #region TrackCount

        private int _trackCount = int.MaxValue;
        [Browsable(true)]
        [Category(Media)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An unsigned integer containing the number of tracks in the album containing the media represented by the selected item(s), or zero if not specified.")]
        [DisplayName("# Tracks")]
        public int TrackCount
        {
            get => GetInt(p => p.TrackCount, ref _trackCount);
            set
            {
                SetValue(Tag.TrackCount, p => p.TrackCount, p => p.TrackCount = value);
                _trackCount = value;
            }
        }

        #endregion
        #region TrackGain

        private string _trackGain;
        [Browsable(true)]
        [Category(ReplayGain)]
        [Column(80, Alignment.Far)]
        [Description("A string containing the Track Gain setting in decibels for the selected item(s), as determined by the ReplayGain utility.")]
        [DisplayName("Track Gain")]
        public string TrackGain => GetString(p => p.TrackGain, ref _trackGain);

        #endregion
        #region TrackNumber

        private int _trackNumber = int.MaxValue;
        [Browsable(true)]
        [Category(Media)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An unsigned integer containing the position of the media represented by the selected item(s) in its containing album, or zero if not specified.")]
        [DisplayName("Track #")]
        public int TrackNumber
        {
            get => GetInt(p => p.TrackNumber, ref _trackNumber);
            set
            {
                SetValue(Tag.TrackNumber, p => p.TrackNumber, p => p.TrackNumber = value);
                _trackNumber = value;
            }
        }

        #endregion
        #region TrackOf

        private string _trackOf;
        [Browsable(false)]
        [Category(Media)]
        [Column(50, Alignment.Far)]
        [Description("A string containing both the number of the track, and the total number of tracks in the album, containing the media represented by the selected item(s).")]
        [DisplayName("Track # of #")]
        [ReadOnly(true)]
        [Uses(Tag.TrackNumber, Tag.TrackCount)]
        public string TrackOf => GetString(p => p.TrackOf, ref _trackOf);

        #endregion
        #region TrackPeak

        private string _trackPeak;
        [Browsable(true)]
        [Category(ReplayGain)]
        [Column(80, Alignment.Far)]
        [Description("A string containing the Track Peak setting for the selected item(s), as determined by the ReplayGain utility.")]
        [DisplayName("Track Peak")]
        public string TrackPeak => GetString(p => p.TrackPeak, ref _trackPeak);

        #endregion
        #region VideoHeight

        private int _videoHeight = int.MaxValue;
        [Browsable(false)]
        [Category(Media)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An integer containing the height of the video represented by the selected item(s).")]
        [DisplayName("Video Height")]
        [ReadOnly(true)]
        public int VideoHeight => GetInt(p => p.VideoHeight, ref _videoHeight);

        #endregion
        #region VideoWidth

        private int _videoWidth = int.MaxValue;
        [Browsable(false)]
        [Category(Media)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An integer containing the width of the video represented by the selected item(s).")]
        [DisplayName("Video Width")]
        [ReadOnly(true)]
        public int VideoWidth => GetInt(p => p.VideoWidth, ref _videoWidth);

        #endregion
        #region Year

        private int _year = int.MaxValue;
        [Browsable(true)]
        [Category(Category)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An unsigned integer containing the year that the media represented by the selected item(s) was created, or zero if no value is present.")]
        [DisplayName("Year")]
        public int Year
        {
            get => GetInt(p => p.Year, ref _year);
            set
            {
                SetValue(Tag.Year, p => p.Year, p => p.Year = value);
                _year = value;
                _decade = null;
                _century = null;
                _millennium = null;
                _yearAlbum = null;
            }
        }

        #endregion
        #region YearAlbum

        private string _yearAlbum;
        [Browsable(false)]
        [Category(Details)]
        [Column(160)]
        [Description("A string containing both the year of release and the title of the album of the media represented by the selected item(s).")]
        [DisplayName("Year/Album")]
        [ReadOnly(true)]
        [Uses(Tag.Album, Tag.Year)]
        public string YearAlbum => GetString(p => p.YearAlbum, ref _yearAlbum);

        #endregion

        #endregion

        #region Events

        [field: NonSerialized]
        public event EventHandler<SelectionEditEventArgs> TracksEdit;

        protected virtual void OnTracksEdit(Tag tag, List<object> values) =>
            TracksEdit?.Invoke(this, new SelectionEditEventArgs(this, tag, values));

        #endregion

        #region Private Methods)

        private DateTime GetDateTime(Func<Track, DateTime> getDateTime, ref DateTime result)
        {
            if (result == DateTime.MaxValue)
            {
                result = DateTime.MinValue;
                if (Tracks != null)
                {
                    var first = true;
                    foreach (var value in Tracks.Select(getDateTime))
                    {
                        if (first)
                        {
                            result = value;
                            first = false;
                        }
                        else if (result != value)
                        {
                            result = DateTime.MinValue;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        private double GetDouble(Func<Track, double> getDouble, ref double result)
        {
            if (result == double.MaxValue)
            {
                result = 0;
                if (Tracks != null)
                {
                    var first = true;
                    foreach (var value in Tracks.Select(getDouble))
                    {
                        if (first)
                        {
                            result = value;
                            first = false;
                        }
                        else if (result != value)
                        {
                            result = 0;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        private string GetFileOrCommonFolderPath(Func<Track, string> getString, ref string result)
        {
            if (result == null)
            {
                result = string.Empty;
                if (Tracks != null && Tracks.Any())
                {
                    // The following adapted from http://rosettacode.org/wiki/Find_common_directory_path#C.23
                    var path = result;
                    var paths = Tracks.Select(getString).ToList();
                    var segments = paths.First(s => s.Length == paths.Max(t => t.Length)).Split('\\').ToList();
                    for (var index = 0; index < segments.Count; index++)
                    {
                        var segment = segments[index];
                        if (!paths.All(s => s.StartsWith(path + segment)))
                            break;
                        path += segment;
                        if (index < segments.Count - 1)
                            path += "\\";
                    }
                    result = path;
                }
            }
            return result;
        }

        private FileStatus GetFileStatus(Func<Track, FileStatus> getFileStatus, ref FileStatus result)
        {
            if (result == FileStatus.Unknown && Tracks != null)
                result = Tracks
                    .Select(getFileStatus)
                    .Aggregate(result, (p, q) => p | q);
            return result;
        }

        private TagLib.Image.ImageOrientation GetImageOrientation(
            Func<Track, TagLib.Image.ImageOrientation> getImageOrientation,
            ref TagLib.Image.ImageOrientation result)
        {
            if (result == TagLib.Image.ImageOrientation.None)
            {
                var first = true;
                foreach (var value in Tracks.Select(getImageOrientation))
                    if (first)
                    {
                        result = value;
                        first = false;
                    }
                    else if (result != value)
                    {
                        result = TagLib.Image.ImageOrientation.None;
                        break;
                    }
            }
            return result;
        }

        private int GetInt(Func<Track, int> getInt, ref int result)
        {
            if (result == int.MaxValue)
            {
                result = 0;
                if (Tracks != null)
                {
                    var first = true;
                    foreach (var value in Tracks.Select(getInt))
                    {
                        if (first)
                        {
                            result = value;
                            first = false;
                        }
                        else if (result != value)
                        {
                            result = 0;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        private Logical GetLogical(Func<Track, Logical> getLogical, ref Logical result)
        {
            if (result == Logical.Unknown && Tracks != null)
                foreach (var value in Tracks.Select(getLogical))
                {
                    result |= value;
                    if (result == (Logical.Yes | Logical.No))
                        break;
                }
            return result;
        }

        private long GetLong(Func<Track, long> getLong, ref long result, bool sum)
        {
            if (result == long.MaxValue)
            {
                result = 0;
                if (Tracks != null)
                {
                    var first = true;
                    foreach (var value in Tracks.Select(getLong))
                        if (first)
                        {
                            result = value;
                            first = false;
                        }
                        else if (sum)
                            result += value;
                        else if (result != value)
                        {
                            result = 0;
                            break;
                        }
                }
            }
            return result;
        }

        private TagLib.MediaTypes GetMediaTypes(Func<Track, TagLib.MediaTypes> getMediaTypes, ref TagLib.MediaTypes result)
        {
            if (result == AllMediaTypes)
            {
                result = 0;
                if (Tracks != null)
                    result = Tracks
                        .Select(getMediaTypes)
                        .Aggregate(result, (current, mediaTypes) => current | mediaTypes);
            }
            return result;
        }

        private Picture[] GetPictures(Func<Track, Picture[]> getPictures, ref Picture[] result)
        {
            if (result == null)
            {
                var pictureList = new List<Picture>();
                if (Tracks != null)
                    foreach (var pictures in Tracks
                        .Select(getPictures)
                        .Where(p => p != null))
                    {
                        pictureList.AddRange(pictures);
                        if (pictureList.Any())
                            break;
                    }
                result = pictureList.ToArray();
            }
            return result;
        }

        private string GetString(Func<Track, string> getString, ref string result)
        {
            if (result == null)
            {
                result = string.Empty;
                var first = true;
                foreach (var value in Tracks.Select(getString))
                    if (first)
                    {
                        result = value;
                        first = false;
                    }
                    else if (result != value)
                    {
                        result = string.Empty;
                        break;
                    }
            }
            return result;
        }

        private string[] GetStringArray(Func<Track, string[]> getStringArray, ref string[] result)
        {
            if (result == null)
            {
                var values = new List<string>();
                if (Tracks != null)
                {
                    try
                    {
                        values.AddRange(Tracks?.SelectMany(getStringArray)?.Distinct() ?? Array.Empty<string>());
                    }
                    catch (NullReferenceException)
                    {
                    }
                }
                result = values.ToArray();
            }
            return result;
        }

        private TagLib.TagTypes GetTagTypes(Func<Track, TagLib.TagTypes> getTagTypes, ref TagLib.TagTypes result)
        {
            if (result == TagLib.TagTypes.AllTags)
            {
                result = 0;
                if (Tracks != null)
                    result = Tracks
                        .Select(getTagTypes)
                        .Aggregate(result, (current, tagTypes) => current | tagTypes);
            }
            return result;
        }

        private TimeSpan GetTimeSpan(Func<Track, TimeSpan> getTimeSpan, ref TimeSpan result)
        {
            if (result == TimeSpan.MaxValue)
            {
                result = TimeSpan.Zero;
                if (Tracks != null)
                    result = Tracks
                        .Select(getTimeSpan)
                        .Aggregate(result, (current, timeSpan) => current + timeSpan);
            }
            return result;
        }

        private void InvalidateDateTimeFields() // 7 fields
        {
            _fileCreationTime =
                _fileCreationTimeUtc =
                _fileLastAccessTime =
                _fileLastAccessTimeUtc =
                _fileLastWriteTime =
                _fileLastWriteTimeUtc =
                _imageDateTime =
                DateTime.MaxValue;
        }

        private void InvalidateDoubleFields() // 6 fields
        {
            _imageAltitude =
                _imageExposureTime =
                _imageFNumber =
                _imageFocalLength =
                _imageLatitude =
                _imageLongitude =
                double.MaxValue;
        }

        private void InvalidateIntegerFields() // 27 fields
        {
            _albumArtistsCount =
                _albumArtistsSortCount =
                _artistsCount =
                _audioBitrate =
                _audioChannels =
                _audioSampleRate =
                _beatsPerMinute =
                _bitsPerSample =
                _composersCount =
                _composersSortCount =
                _discCount =
                _discNumber =
                _genresCount =
                _imageFocalLengthIn35mmFilm =
                _imageISOSpeedRatings =
                _imageRating =
                _performersCount =
                _performersSortCount =
                _photoHeight =
                _photoQuality =
                _photoWidth =
                _picturesCount =
                _trackCount =
                _trackNumber =
                _videoHeight =
                _videoWidth =
                _year =
                int.MaxValue;
        }

        private void InvalidateLongFields() // 3 fields
        {
            _fileSize =
                _invariantEndPosition =
                _invariantStartPosition =
                long.MaxValue;
        }

        private void InvalidateMiscellaneousFields() // 10 fields
        {
            _duration = TimeSpan.MaxValue;
            _fileStatus = FileStatus.Unknown;
            _imageOrientation = TagLib.Image.ImageOrientation.None;
            _isClassical = _isEmpty = _possiblyCorrupt = Logical.Unknown;
            _mediaTypes = AllMediaTypes;
            _pictures = null;
            _tagTypes = _tagTypesOnDisk = TagLib.TagTypes.AllTags;
        }

        private void InvalidateStringFields() // 56 fields
        {
            _album =
                _albumGain =
                _albumPeak =
                _albumSort =
                _amazonId =
                _century =
                _codecs =
                _comment =
                _conductor =
                _copyright =
                _decade =
                _description =
                _discOf =
                _discTrack =
                _fileAttributes =
                _fileExtension =
                _fileName =
                _fileNameWithoutExtension =
                _filePath =
                _firstAlbumArtist =
                _firstAlbumArtistSort =
                _firstArtist =
                _firstComposer =
                _firstComposerSort =
                _firstGenre =
                _firstPerformer =
                _firstPerformerSort =
                _grouping =
                _imageCreator =
                _imageMake =
                _imageModel =
                _imageSoftware =
                _joinedAlbumArtists =
                _joinedArtists =
                _joinedComposers =
                _joinedGenres =
                _joinedPerformers =
                _joinedPerformersSort =
                _lyrics =
                _millennium =
                _mimeType =
                _musicBrainzArtistId =
                _musicBrainzDiscId =
                _musicBrainzReleaseArtistId =
                _musicBrainzReleaseCountry =
                _musicBrainzReleaseId =
                _musicBrainzReleaseStatus =
                _musicBrainzReleaseType =
                _musicBrainzTrackId =
                _musicIpId =
                _title =
                _titleSort =
                _trackGain =
                _trackOf =
                _trackPeak =
                _yearAlbum =
                null;
        }

        private void InvalidateStringsFields() // 9 fields
        {
            _albumArtists =
                _albumArtistsSort =
                _artists =
                _composers =
                _composersSort =
                _genres =
                _imageKeywords =
                _performers =
                _performersSort =
                null;
        }

        private void SetValue(Tag tag, Func<Track, object> getValue, Action<Track> setValue)
        {
            var values = new List<object>();
            foreach (var track in Tracks)
            {
                values.Add(getValue(track));
                setValue(track);
            }
            OnTracksEdit(tag, values);
        }

        #endregion
    }
}
