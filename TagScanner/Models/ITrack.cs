using TagScanner.Models;

namespace TagScanner.Models
{
    using System;
    using TagLib;
    using TagLib.Image;

    public interface ITrack
    {
        string Album { get; set; }
        string[] AlbumArtists { get; set; }
        int AlbumArtistsCount { get; }
        string[] AlbumArtistsSort { get; set; }
        string AlbumGain { get; set; } // ReplayGain
        string AlbumPeak { get; set; } // ReplayGain
        string AlbumSort { get; set; }
        string AmazonId { get; set; }
        string[] Artists { get; set; } // Obsolete
        int ArtistsCount { get; } // Obsolete
        int AudioBitrate { get; }
        int AudioChannels { get; }
        int AudioSampleRate { get; }
        int BeatsPerMinute { get; set; }
        int BitsPerSample { get; }
        string Century { get; }
        string Codecs { get; }
        string Comment { get; set; }
        string[] Composers { get; set; }
        int ComposersCount { get; }
        string[] ComposersSort { get; set; }
        string Conductor { get; set; }
        string Copyright { get; set; }
        string Decade { get; }
        string Description { get; }
        int DiscCount { get; set; }
        int DiscNumber { get; set; }
        string DiscOf { get; }
        string DiscTrack { get; }
        TimeSpan Duration { get; }
        DateTime FileAccessed { get; }
        DateTime FileAccessedUtc { get; }
        string FileAttrs { get; }
        Logical FileAttrArchive { get; }
        Logical FileAttrCompressed { get; }
        Logical FileAttrEncrypted { get; }
        Logical FileAttrHidden { get; }
        Logical FileAttrReadOnly { get; }
        Logical FileAttrSystem { get; }
        DateTime FileCreated { get; }
        DateTime FileCreatedUtc { get; }
        string FileExtension { get; }
        string FileName { get; }
        string FileNameWithoutExtension { get; }
        string FilePath { get; }
        long FileSize { get; }
        DateTime FileModified { get; }
        DateTime FileModifiedUtc { get; }
        Status Status { get; }
        string FirstAlbumArtist { get; }
        string FirstAlbumArtistSort { get; }
        string FirstArtist { get; } // Obsolete
        string FirstComposer { get; }
        string FirstComposerSort { get; }
        string FirstGenre { get; }
        string FirstPerformer { get; }
        string FirstPerformerSort { get; }
        string FolderPath { get; }
        string[] Genres { get; set; }
        int GenresCount { get; }
        string Grouping { get; set; }
        double ImageAltitude { get; set; }
        string ImageCreator { get; set; }
        DateTime ImageDateTime { get; set; }
        double ImageExposureTime { get; set; }
        double ImageFNumber { get; set; }
        double ImageFocalLength { get; set; }
        int ImageFocalLengthIn35mmFilm { get; set; }
        int ImageISOSpeedRatings { get; set; }
        string[] ImageKeywords { get; set; }
        double ImageLatitude { get; set; }
        double ImageLongitude { get; set; }
        string ImageMake { get; set; }
        string ImageModel { get; set; }
        ImageOrientation ImageOrientation { get; set; }
        int ImageRating { get; set; }
        string ImageSoftware { get; set; }
        long InvariantEndPosition { get; }
        long InvariantStartPosition { get; }
        Logical IsClassical { get; }
        Logical IsEmpty { get; }
        string JoinedAlbumArtists { get; }
        string JoinedArtists { get; } // Obsolete
        string JoinedComposers { get; }
        string JoinedGenres { get; }
        string JoinedPerformers { get; }
        string JoinedPerformersSort { get; }
        string Lyrics { get; set; }
        MediaTypes MediaTypes { get; }
        string Millennium { get; }
        string MimeType { get; }
        string MusicBrainzArtistId { get; set; }
        string MusicBrainzDiscId { get; set; }
        string MusicBrainzReleaseArtistId { get; set; }
        string MusicBrainzReleaseCountry { get; set; }
        string MusicBrainzReleaseId { get; set; }
        string MusicBrainzReleaseStatus { get; set; }
        string MusicBrainzReleaseType { get; set; }
        string MusicBrainzTrackId { get; set; }
        string MusicIpId { get; set; }
        string[] Performers { get; set; }
        int PerformersCount { get; }
        string[] PerformersSort { get; set; }
        int PhotoHeight { get; }
        int PhotoQuality { get; }
        int PhotoWidth { get; }
        Picture[] Pictures { get; }
        int PicturesCount { get; }
        Logical PossiblyCorrupt { get; }
        TagTypes TagTypes { get; }
        TagTypes TagTypesOnDisk { get; }
        string Title { get; set; }
        string TitleSort { get; set; }
        int TrackCount { get; set; }
        string TrackGain { get; set; } // ReplayGain
        int TrackNumber { get; set; }
        string TrackOf { get; }
        string TrackPeak { get; set; } // ReplayGain
        int VideoHeight { get; }
        int VideoWidth { get; }
        int Year { get; set; }
        string YearAlbum { get; }
    }
}
