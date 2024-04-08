namespace TagScanner.Tests
{
    using Models;
    using System;

    public class Mock : Work
    {
        public Mock(string artist, int year, string album, int trackNumber, string duration, string title) : base()
        {
            Album = album;
            Duration = TimeSpan.Parse($"00:0{duration}");
            JoinedAlbumArtists = artist;
            JoinedArtists = artist;
            JoinedComposers = artist;
            JoinedPerformers = artist;
            Performers = new[] { artist };
            TrackNumber = trackNumber;
            Title = title;
            Year = year;
        }
    }
}