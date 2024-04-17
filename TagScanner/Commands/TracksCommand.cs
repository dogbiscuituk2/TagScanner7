namespace TagScanner.Commands
{
    using System.Collections.Generic;
    using Models;

    public abstract class TracksCommand : Command
    {
        public TracksCommand(List<Track> tracks, bool add): base()
        {
            Tracks = tracks;
            Add = add;
        }

        protected bool Add;
        protected List<Track> Tracks { get; }

        public override string UndoAction => GetAction(undo: true);
        public override string RedoAction => GetAction(undo: false);

        public override void Invert() { Add = !Add; }

        public override bool Run(Model model)
        {
            model.AddRemoveTracks(Tracks, add: Add);
            return true;
        }

        public override string ToString() => $"{(Add ? "Add" : "Remove")} {null}";

        private string GetAction(bool undo) => $"{(Add ^ undo ? "add" : "remove")} Tracks";
    }

    public class TracksAddCommand : TracksCommand
    {
        public TracksAddCommand(List<Track> tracks) : base(tracks, add: true) { }
    }

    public class TracksRemoveCommand : TracksCommand
    {
        public TracksRemoveCommand(List<Track> tracks) : base(tracks, add: false) { }
    }
}
