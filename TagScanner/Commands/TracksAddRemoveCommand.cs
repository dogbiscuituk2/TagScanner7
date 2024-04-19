namespace TagScanner.Commands
{
    using System.Collections.Generic;
    using Models;

    public abstract class TracksAddRemoveCommand : Command
    {
        public TracksAddRemoveCommand(List<Track> tracks, bool add)
        {
            Tracks = tracks;
            Add = add;
        }

        protected bool Add;

        protected override void Invert() { Add = !Add; }

        public override bool Run(Model model)
        {
            model.AddRemoveTracks(Tracks, add: Add);
            return true;
        }

        public override string ToString() => $"{(Add ? "Add" : "Remove")} {Summary}";
    }

    public class TracksAddCommand : TracksAddRemoveCommand
    {
        public TracksAddCommand(List<Track> tracks) : base(tracks, add: true) { }
    }

    public class TracksRemoveCommand : TracksAddRemoveCommand
    {
        public TracksRemoveCommand(List<Track> tracks) : base(tracks, add: false) { }
    }
}
