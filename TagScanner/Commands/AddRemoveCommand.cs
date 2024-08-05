namespace TagScanner.Commands
{
    using System.Collections.Generic;
    using Models;

    public abstract class AddRemoveCommand : Command
    {
        #region Constructors

        public AddRemoveCommand(Track track, bool add) : base(track) => Add = add;
        public AddRemoveCommand(IEnumerable<Track> tracks, bool add) : base(tracks) => Add = add;
        public AddRemoveCommand(Selection selection, bool add) : base(selection) => Add = add;

        #endregion

        #region Public Methods

        public override int Run(IModel model) => ((Model)model).AddRemoveTracks(Tracks, add: Add);
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
        #region Constructors

        public AddCommand(Track track) : base(track, add: true) { }
        public AddCommand(IEnumerable<Track> tracks) : base(tracks, add: true) { }
        public AddCommand(Selection selection) : base(selection, add: true) { }

        #endregion
    }

    public class RemoveCommand : AddRemoveCommand
    {
        #region Constructors

        public RemoveCommand(Track track) : base(track, add: true) { }
        public RemoveCommand(IEnumerable<Track> tracks) : base(tracks, add: true) { }
        public RemoveCommand(Selection selection) : base(selection, add: false) { }

        #endregion
    }
}
