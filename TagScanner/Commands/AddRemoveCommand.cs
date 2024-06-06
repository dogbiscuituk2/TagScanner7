namespace TagScanner.Commands
{
    using Models;

    public abstract class AddRemoveCommand : Command
    {
        #region Constructor

        public AddRemoveCommand(Selection selection, bool add) : base(selection) => Add = add;

        #endregion

        protected bool Add;

        protected override void Invert() { Add = !Add; }

        public override int Run(Model model) => model.AddRemoveTracks(Tracks, add: Add);
        public override string ToString() => $"{(Add ? "Add" : "Remove")} {Summary}";
    }

    public class AddCommand : AddRemoveCommand
    {
        public AddCommand(Selection selection) : base(selection, add: true) { }
    }

    public class RemoveCommand : AddRemoveCommand
    {
        public RemoveCommand(Selection selection) : base(selection, add: false) { }
    }
}
