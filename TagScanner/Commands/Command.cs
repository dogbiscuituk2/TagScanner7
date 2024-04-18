namespace TagScanner.Commands
{
    using Models;
    using System.Collections.Generic;
    using System.Linq;

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
                    artists = Tracks.Select(p => p.JoinedPerformers).Distinct(),
                    albums = Tracks.Select(p => p.Album).Distinct();

                return Tracks.Count == 1
                    ? $"'{Tracks.First().Title}' ({GetDetails()})"
                    : $"{Tracks.Count} '{GetSummary()}' tracks";

                string GetDetails() => $"{artists.First()} - {albums.First()}";

                string GetSummary() => artists.Count() == 1
                    ? albums.Count() == 1 ? $"{GetDetails()}" : artists.First()
                    : albums.Count() == 1 ? albums.First() : "Various Artists";
            }
        }

        protected virtual void Invert() { }

        public abstract bool Run(Model model);
    }
}
