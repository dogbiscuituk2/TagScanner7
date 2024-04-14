namespace TagScanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using TagScanner.Commands;

    [DefaultProperty("Title")]
    public class Selection : IWork
    {
        #region Constructor

        public Selection(IEnumerable<Work> works) => Works = works;

        #endregion

        #region Public Fields

        public readonly IEnumerable<Work> Works;

        #endregion

        #region Events

        public event EventHandler
            BeginUpdate,
            EndUpdate;

        private void OnBeginUpdate()
        {
            var beginUpdate = BeginUpdate;
            beginUpdate?.Invoke(this, EventArgs.Empty);
        }

        private void OnEndUpdate()
        {
            var endUpdate = EndUpdate;
            endUpdate?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region IWork

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
                SetValue(p => p.Album = value);
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
                SetValue(p => p.AlbumArtists = value);
                _albumArtists = null;
                _firstAlbumArtist = null;
                _joinedAlbumArtists = null;
            }
        }

        #endregion
        #region AlbumArtistsCount

        [Browsable(false)]
        [Category(Personnel)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An integer indicating the number of band(s) or artist(s) credited in the creation of the entire album or collection containing the media described by the selected item(s), or zero if none are present.")]
        [DisplayName("# Album Artists")]
        [ReadOnly(true)]
        [Uses(Tag.AlbumArtists)]
        public int AlbumArtistsCount => AlbumArtists.Length;

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
                SetValue(p => p.AlbumArtistsSort = value);
                _albumArtistsSort = null;
                _firstAlbumArtistSort = null;
            }
        }

        #endregion
        #region AlbumArtistsSortCount

        [Browsable(false)]
        [Category(Personnel)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An integer indicating the number of band(s) or artist(s) credited in the creation of the entire album or collection containing the media described by the selected item(s), or zero if none are present.")]
        [DisplayName("# Album Artists (sorted)")]
        [ReadOnly(true)]
        [Uses(Tag.AlbumArtistsSort)]
        public int AlbumArtistsSortCount => AlbumArtistsSort.Length;

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
                SetValue(p => p.AlbumSort = value);
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
                SetValue(p => p.AmazonId = value);
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
                SetValue(p => p.Artists = value);
                _artists = null;
                _firstArtist = null;
                _joinedArtists = null;
            }
        }

        #endregion
        #region ArtistsCount

        [Browsable(false)]
        [Category(Personnel)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An integer indicating the number of performers or artists who performed in the media described by the selected item(s), or zero if none are present. (Obsolete. For album artists, use AlbumArtistsCount. For track artists, use PerformersCount.)")]
        [DisplayName("# Artists")]
        [Obsolete("Obsolete. For album artists, use AlbumArtistsCount. For track artists, use PerformersCount.")]
        [ReadOnly(true)]
        [Uses(Tag.Artists)]
        public int ArtistsCount => Artists.Length;

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
                SetValue(p => p.BeatsPerMinute = value);
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
                SetValue(p => p.Comment = value);
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
                SetValue(p => p.Composers = value);
                _composers = null;
                _firstComposer = null;
                _joinedComposers = null;
            }
        }

        #endregion
        #region ComposersCount

        [Browsable(false)]
        [Category(Personnel)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An integer indicating the number of composers of the media represented by the selected item(s), or zero if none are present.")]
        [DisplayName("# Composers")]
        [ReadOnly(true)]
        [Uses(Tag.Composers)]
        public int ComposersCount => Composers.Length;

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
                SetValue(p => p.ComposersSort = value);
                _composersSort = null;
                _firstComposerSort = null;
            }
        }

        #endregion
        #region ComposersSortCount

        [Browsable(false)]
        [Category(Personnel)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An integer indicating the number of composers of the media represented by the selected item(s), or zero if none are present.")]
        [DisplayName("# Composers (sorted)")]
        [ReadOnly(true)]
        [Uses(Tag.ComposersSort)]
        public int ComposersSortCount => ComposersSort.Length;

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
                SetValue(p => p.Conductor = value);
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
                SetValue(p => p.Copyright = value);
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
                SetValue(p => p.DiscCount = value);
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
                SetValue(p => p.DiscNumber = value);
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

        private FileStatus _fileStatus;
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
        [DisplayName("1st Album Artist")]
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
        [DisplayName("1st Album Artist (sorted)")]
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
        [DisplayName("1st Artist")]
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
        [DisplayName("1st Composer")]
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
        [DisplayName("1st Composer (sorted)")]
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
        [DisplayName("1st Genre")]
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
        [DisplayName("1st Performer")]
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
        [DisplayName("1st Performer (sorted)")]
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
                SetValue(p => p.Genres = value);
                _genres = null;
                _firstGenre = null;
                _joinedGenres = null;
                _isClassical = Logical.Unknown;
            }
        }

        #endregion
        #region GenresCount

        [Browsable(false)]
        [Category(Category)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An integer indicating the number of genres of the media represented by the selected item(s), or zero if none are present.")]
        [DisplayName("# Genres")]
        [ReadOnly(true)]
        [Uses(Tag.Genres)]
        public int GenresCount => Genres.Length;

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
                SetValue(p => p.Grouping = value);
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
                SetValue(p => p.ImageAltitude = value);
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
                SetValue(p => p.ImageCreator = value);
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
                SetValue(p => p.ImageDateTime = value);
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
                SetValue(p => p.ImageExposureTime = value);
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
                SetValue(p => p.ImageFNumber = value);
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
                SetValue(p => p.ImageFocalLength = value);
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
                SetValue(p => p.ImageFocalLengthIn35mmFilm = value);
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
                SetValue(p => p.ImageISOSpeedRatings = value);
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
                SetValue(p => p.ImageKeywords = value);
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
                SetValue(p => p.ImageLatitude = value);
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
                SetValue(p => p.ImageLongitude = value);
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
                SetValue(p => p.ImageMake = value);
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
                SetValue(p => p.ImageModel = value);
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
                SetValue(p => p.ImageOrientation = value);
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
                SetValue(p => p.ImageRating = value);
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
                SetValue(p => p.ImageSoftware = value);
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

        private Logical _isClassical;
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

        private Logical _isEmpty;
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
                SetValue(p => p.Lyrics = value);
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
                SetValue(p => p.MusicBrainzArtistId = value);
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
                SetValue(p => p.MusicBrainzDiscId = value);
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
                SetValue(p => p.MusicBrainzReleaseArtistId = value);
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
                SetValue(p => p.MusicBrainzReleaseCountry = value);
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
                SetValue(p => p.MusicBrainzReleaseId = value);
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
                SetValue(p => p.MusicBrainzReleaseStatus = value);
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
                SetValue(p => p.MusicBrainzReleaseType = value);
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
                SetValue(p => p.MusicBrainzTrackId = value);
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
                SetValue(p => p.MusicIpId = value);
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
                SetValue(p => p.Performers = value);
                _performers = null;
                _firstPerformer = null;
                _joinedPerformers = null;
            }
        }

        #endregion
        #region PerformersCount

        [Browsable(false)]
        [Category(Personnel)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An integer indicating the number of performers or artists who performed in the media described by the selected item(s), or zero if none are present.")]
        [DisplayName("# Performers")]
        [ReadOnly(true)]
        [Uses(Tag.Performers)]
        public int PerformersCount => Performers.Length;

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
                SetValue(p => p.PerformersSort = value);
                _performersSort = null;
                _firstPerformerSort = null;
                _joinedPerformersSort = null;
            }
        }

        #endregion
        #region PerformersSortCount

        [Browsable(false)]
        [Category(Personnel)]
        [Column(50)]
        [DefaultValue(0)]
        [Description("An integer indicating the number of performers or artists who performed in the media described by the selected item(s), or zero if none are present.")]
        [DisplayName("# Performers (sorted)")]
        [ReadOnly(true)]
        [Uses(Tag.PerformersSort)]
        public int PerformersSortCount => PerformersSort.Length;

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

        private Picture[] _pictures;
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

        private Logical _possiblyCorrupt;
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
        public int SelectedAlbumsCount => Works.Select(f => f.Album).Distinct().Count();

        #endregion
        #region SelectedArtistsCount

        [Browsable(true)]
        [Category(Selected)]
        [Column(50)]
        [Description("The number of unique artists in the current selection.")]
        [DisplayName("# Selected Artists")]
        [ReadOnly(true)]
        public int SelectedArtistsCount => Works.SelectMany(f => f.Performers).Distinct().Count();

        #endregion
        #region SelectedFoldersCount

        [Browsable(true)]
        [Category(Selected)]
        [Column(50)]
        [Description("The number of distinct folders containing one or more items from the selection.")]
        [DisplayName("# Selected Folders")]
        [ReadOnly(true)]
        public int SelectedFoldersCount => Works.Select(p => Path.GetDirectoryName(p.FilePath)).Distinct().Count();

        #endregion
        #region SelectedGenresCount

        [Browsable(true)]
        [Category(Selected)]
        [Column(50)]
        [Description("The number of unique genres in the current selection.")]
        [DisplayName("# Selected Genres")]
        [ReadOnly(true)]
        public int SelectedGenresCount => Works.SelectMany(f => f.Genres).Distinct().Count();

        #endregion
        #region SelectedWorksCount

        [Browsable(true)]
        [Category(Selected)]
        [Column(50)]
        [Description("The total number of works in the current selection.")]
        [DisplayName("# Selected Works")]
        [ReadOnly(true)]
        public int SelectedWorksCount => Works.Count();

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
                SetValue(p => p.Title = value);
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
                SetValue(p => p.TitleSort = value);
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
                SetValue(p => p.TrackCount = value);
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
                SetValue(p => p.TrackNumber = value);
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
                SetValue(p => p.Year = value);
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

        #region Categories

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

        #region Tag Accessors (private methods)

        private DateTime GetDateTime(Func<IWork, DateTime> getDateTime, ref DateTime result)
        {
            if (result == DateTime.MaxValue)
            {
                result = DateTime.MinValue;
                if (Works != null)
                {
                    var first = true;
                    foreach (var value in Works.Select(getDateTime))
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

        private double GetDouble(Func<IWork, double> getDouble, ref double result)
        {
            if (result == double.MaxValue)
            {
                result = 0;
                if (Works != null)
                {
                    var first = true;
                    foreach (var value in Works.Select(getDouble))
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

        private string GetFileOrCommonFolderPath(Func<IWork, string> getString, ref string result)
        {
            if (result == null)
            {
                result = string.Empty;
                if (Works != null && Works.Any())
                {
                    // The following adapted from http://rosettacode.org/wiki/Find_common_directory_path#C.23
                    var path = result;
                    var paths = Works.Select(getString).ToList();
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

        private FileStatus GetFileStatus(Func<IWork, FileStatus> getFileStatus, ref FileStatus result)
        {
            if (result == FileStatus.Unknown && Works != null)
                result = Works
                    .Select(getFileStatus)
                    .Aggregate(result, (p, q) => p | q);
            return result;
        }

        private TagLib.Image.ImageOrientation GetImageOrientation(
            Func<IWork, TagLib.Image.ImageOrientation> getImageOrientation,
            ref TagLib.Image.ImageOrientation result)
        {
            if (result == TagLib.Image.ImageOrientation.None)
            {
                var first = true;
                foreach (var value in Works.Select(getImageOrientation))
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

        private int GetInt(Func<IWork, int> getInt, ref int result)
        {
            if (result == int.MaxValue)
            {
                result = 0;
                if (Works != null)
                {
                    var first = true;
                    foreach (var value in Works.Select(getInt))
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

        private Logical GetLogical(Func<IWork, Logical> getLogical, ref Logical result)
        {
            if (result == Logical.Unknown && Works != null)
                foreach (var value in Works.Select(getLogical))
                {
                    result |= value;
                    if (result == (Logical.Yes | Logical.No))
                        break;
                }
            return result;
        }

        private long GetLong(Func<IWork, long> getLong, ref long result, bool sum)
        {
            if (result == long.MaxValue)
            {
                result = 0;
                if (Works != null)
                {
                    var first = true;
                    foreach (var value in Works.Select(getLong))
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

        private TagLib.MediaTypes GetMediaTypes(Func<IWork, TagLib.MediaTypes> getMediaTypes, ref TagLib.MediaTypes result)
        {
            if (result == AllMediaTypes)
            {
                result = 0;
                if (Works != null)
                    result = Works
                        .Select(getMediaTypes)
                        .Aggregate(result, (current, mediaTypes) => current | mediaTypes);
            }
            return result;
        }

        private Picture[] GetPictures(Func<IWork, Picture[]> getPictures, ref Picture[] result)
        {
            if (result == null)
            {
                var pictureList = new List<Picture>();
                if (Works != null)
                    foreach (var pictures in Works
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

        private string GetString(Func<IWork, string> getString, ref string result)
        {
            if (result == null)
            {
                result = string.Empty;
                var first = true;
                foreach (var value in Works.Select(getString))
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

        private string[] GetStringArray(Func<IWork, string[]> getStringArray, ref string[] result)
        {
            if (result == null)
            {
                var values = new List<string>();
                if (Works != null)
                {
                    try
                    {
                        values.AddRange(Works?.SelectMany(getStringArray)?.Distinct() ?? Array.Empty<string>());
                    }
                    catch (NullReferenceException)
                    {
                    }
                }
                result = values.ToArray();
            }
            return result;
        }

        private TagLib.TagTypes GetTagTypes(Func<IWork, TagLib.TagTypes> getTagTypes, ref TagLib.TagTypes result)
        {
            if (result == TagLib.TagTypes.AllTags)
            {
                result = 0;
                if (Works != null)
                    result = Works
                        .Select(getTagTypes)
                        .Aggregate(result, (current, tagTypes) => current | tagTypes);
            }
            return result;
        }

        private TimeSpan GetTimeSpan(Func<IWork, TimeSpan> getTimeSpan, ref TimeSpan result)
        {
            if (result == TimeSpan.MaxValue)
            {
                result = TimeSpan.Zero;
                if (Works != null)
                    result = Works
                        .Select(getTimeSpan)
                        .Aggregate(result, (current, timeSpan) => current + timeSpan);
            }
            return result;
        }

        private void SetValue(Action<IWork> setValue)
        {
            var beginEnd = Works.Count() > 1;
            if (beginEnd)
                OnBeginUpdate();
            foreach (var file in Works)
                setValue(file);
            if (beginEnd)
                OnEndUpdate();
        }

        #endregion
    }
}
