namespace TagScanner.Commands
{
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Command
    {
        public virtual bool Do(Model model)
        {
            var result = Run(model);
            Invert();
            return result;
        }

        protected List<Track> Tracks { get; set; }

        protected string Summary
        {
            get
            {
                IEnumerable<string>
                    albums = Tracks.Select(p => p.Album).Distinct(),
                    artists = Tracks.Select(p => p.JoinedPerformers).Distinct();
                string
                    album = albums.First(),
                    artist = artists.First();
                bool
                    sameAlbum = albums.Count() == 1,
                    sameArtist = artists.Count() == 1;
                if (Tracks.Count == 1)
                    return $"'{Tracks.First().Title}' by {artist} (from '{album}')";
                var s = new StringBuilder($"{Tracks.Count} ");
                if (sameAlbum)
                    s.Append($"'{album}' ");
                s.Append($"tracks by {artist}");
                if (!sameArtist)
                    s.Append(", etc.");
                return s.ToString();
            }
        }

        protected virtual void Invert() { }

        public abstract bool Run(Model model);
    }
}
