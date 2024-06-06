namespace TagScanner.Commands
{
    using Models;

    public abstract class AddRemoveCommand : Command
    {
        #region Constructor

        public AddRemoveCommand(Selection selection, bool add) : base(selection) => Add = add;

        #endregion

        #region Public Methods

        public override int Run(Model model) => model.AddRemoveTracks(Tracks, add: Add);
        public override string ToString() => $"{(Add ? "Add" : "Remove")} {Summary}";

        #endregion

        #region Protected Fields

        protected bool Add;

        #endregion

        #region Protected Methods

        protected override void Invert() { Add = !Add; }

        #endregion
    }

    public class AddCommand : AddRemoveCommand
    {
        #region Constructor

        public AddCommand(Selection selection) : base(selection, add: true) { }

        #endregion
    }

    public class RemoveCommand : AddRemoveCommand
    {
        #region Constructor

        public RemoveCommand(Selection selection) : base(selection, add: false) { }

        #endregion
    }
}
