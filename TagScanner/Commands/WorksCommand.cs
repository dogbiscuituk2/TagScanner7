namespace TagScanner.Commands
{
    using System.Collections.Generic;
    using Models;

    public abstract class WorksCommand : Command
    {
        public WorksCommand(List<Work> works, bool add): base()
        {
            Works = works;
            Add = add;
        }

        protected bool Add;
        protected List<Work> Works { get; }

        public override string UndoAction => GetAction(undo: true);
        public override string RedoAction => GetAction(undo: false);

        public override void Invert() { Add = !Add; }

        public override bool Run(Model model)
        {
            model.AddRemoveWorks(Works, add: Add);
            return true;
        }

        public override string ToString() => $"{(Add ? "Add" : "Remove")} {null}";

        private string GetAction(bool undo) => $"{(Add ^ undo ? "add" : "remove")} Works";
    }

    public class WorksAddCommand : WorksCommand
    {
        public WorksAddCommand(List<Work> works) : base(works, add: true) { }
    }

    public class WorksRemoveCommand : WorksCommand
    {
        public WorksRemoveCommand(List<Work> works) : base(works, add: false) { }
    }
}
