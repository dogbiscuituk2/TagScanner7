namespace TagScanner.Commands
{
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Command
    {
        protected Command(Selection selection) => Selection = selection;

        public virtual int Do(Model model)
        {
            var result = Run(model);
            Invert();
            return result;
        }

        public int TracksCount => Tracks.Count;

        protected Selection Selection { get; }
        protected List<Track> Tracks => Selection.Tracks;

        protected string Summary
        {
            get
            {
                IEnumerable<string>
                    albums = Tracks.Select(p => p.Album).Where(p => !string.IsNullOrWhiteSpace(p)).Distinct(),
                    artists = Tracks.Select(p => p.JoinedPerformers).Where(p => !string.IsNullOrWhiteSpace(p)).Distinct();
                string
                    album = albums.FirstOrDefault(),
                    artist = artists.FirstOrDefault();
                var s = new StringBuilder();
                if (Tracks.Count == 1)
                {
                    var title = Tracks.First().Title;
                    s.Append(!string.IsNullOrWhiteSpace(title) ? $"'{title}'" : "one track");
                }
                else
                    s.Append($"{Tracks.Count} tracks");
                if (albums.Count() == 1)
                    s.Append($" from '{album}'");
                if (artists.Count() > 0)
                {
                    s.Append($" by {artist}");
                    if (artists.Count() > 1)
                        s.Append(", etc.");
                }
                return s.ToString();
            }
        }

        protected virtual void Invert() { }

        public abstract int Run(Model model);
    }
}
