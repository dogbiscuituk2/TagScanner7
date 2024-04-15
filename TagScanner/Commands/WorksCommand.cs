namespace TagScanner.Commands
{
    public abstract class WorksCommand : Command
    {
        public WorksCommand(bool add): base() { Adding = add; }

        protected bool Adding;

        public override string UndoAction => GetAction(undo: true);
        public override string RedoAction => GetAction(undo: false);

        public override void Invert() { Adding = !Adding; }

        public override bool Run()
        {
            return true;
        }

        public override string ToString() => $"{(Adding ? "Add" : "Remove")} {null}";

        private string GetAction(bool undo) => $"Works {(Adding ^ undo ? "addition" : "removal")}";
    }

    public class WorksAddCommand : WorksCommand
    {
        public WorksAddCommand() : base(add: true) { }
    }

    public class WorksRemoveCommand : WorksCommand
    {
        public WorksRemoveCommand() : base(add: false) { }
    }
}
