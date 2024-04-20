namespace TagScanner.Commands
{
    using Models;

    public abstract class TracksAddRemoveCommand : Command
    {
        public TracksAddRemoveCommand(Selection selection, bool add) : base(selection) => Add = add;

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
        public TracksAddCommand(Selection selection) : base(selection, add: true) { }
    }

    public class TracksRemoveCommand : TracksAddRemoveCommand
    {
        public TracksRemoveCommand(Selection selection) : base(selection, add: false) { }
    }
}
