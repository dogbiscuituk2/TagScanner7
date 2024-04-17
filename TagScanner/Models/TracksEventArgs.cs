namespace TagScanner.Models
{
    using System.Collections.Generic;

    public class TracksEventArgs
    {
        public TracksEventArgs(List<Track> tracks) : base()
        {
            Tracks = tracks;
        }

        public List<Track> Tracks { get; private set; }
    }
}
