namespace TagScanner.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Core;
    using Models;

    public abstract class Command : ICommand
    {
        #region Constructors

        protected Command(Track track) : this(new Selection(new[] { track })) { }
        protected Command(IEnumerable<Track> tracks) : this(new Selection(tracks)) { }
        protected Command(Selection selection) => Selection = selection;

        #endregion

        #region Public Properties

        public string Summary
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
            set { }
        }

        public int TracksCount => Tracks.Count;

        #endregion

        #region Public Methods

        public virtual void Apply(IModel model)
        {
            Run(model);
            Invert();
        }

        public abstract void Run(IModel model);

        #endregion

        #region Protected Properties

        protected Selection Selection { get; }
        protected List<Track> Tracks => Selection.Tracks;

        #endregion

        #region Protected Methods

        protected virtual void Invert() { }

        #endregion
    }
}
