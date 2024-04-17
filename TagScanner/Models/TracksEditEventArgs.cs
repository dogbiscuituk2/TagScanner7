namespace TagScanner.Models
{
    using System;
    using System.Collections.Generic;

    public class TracksEditEventArgs : TracksEventArgs
    {
        public TracksEditEventArgs(Tag tag, List<Track> tracks, List<object> values) : base(tracks)
        {
            Tag = tag;
            Values = values;
        }

        public Tag Tag { get; private set; }
        public List<object> Values { get; private set; }
    }
}
