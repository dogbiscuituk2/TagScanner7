namespace TagScanner.Tests
{
    using Models;
    using System;

    public class Mock : Work
    {
        public Mock(string artist, int year, string album, int trackNumber, string duration, string title) : base()
        {
            Performers = new[] { artist };
            Year = year;
            Album = album;
            TrackNumber = trackNumber;
            Duration = TimeSpan.Parse($"00:0{duration}");
            Title = title;
        }
    }
}