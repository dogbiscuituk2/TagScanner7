namespace TagScanner.Controllers
{
    using System;
    using Commands;

    public class CommandProcessor : UndoRedoController<Command>
    {
        #region Constructor

        public CommandProcessor(Controller parent, Action action) : base(parent) =>
            Init(MainModel, action, MainForm.EditUndo, MainForm.EditRedo, MainForm.tbUndo, MainForm.tbRedo);

        #endregion

        #region Public Methods

        /// <summary>
        /// Run a command, pushing its memento on to the Undo stack.
        /// </summary>
        /// <param name="command">The command to run.</param>
        /// <param name="spoof">A flag indicating whether the command should actually be run. 
        /// If true, the command should be run as normal. 
        /// If false, the relevant properties have already been changed on the target, 
        /// so just log the memento to the Undo stack.</param>
        /// <returns>True if the command was run, and actually caused a property change.</returns>
        public void Run(Command command, bool spoof = false)
        {
            if (Busy || command == null)
                return;
            if (LastSave > UndoStack.Count)
                LastSave = -1;
            RedoStack.Clear();
            Redo(command, spoof);
        }

        #endregion

        #region Protected Properties

        protected override string RedoAction => CanRedo ? RedoStack.Peek().ToString() : base.RedoAction;
        protected override string UndoAction => CanUndo ? UndoStack.Peek().ToString() : base.UndoAction;

        #endregion

        #region Protected Methods

        protected override void Redo(Command command, bool spoof = false) => Do(command, undo: false, spoof);
        protected override void Undo(Command command) => Do(command, undo: true, spoof: false);

        #endregion

        #region Private Methods

        private void Do(Command command, bool undo, bool spoof)
        {
            if (!spoof)
            {
                Busy = true;
                command.Apply(Model);
                Busy = false;
            }
            var stack = undo ? RedoStack : UndoStack;
            stack.Push(command);
            UpdateAction();
            DumpStacks();
        }

        #endregion
    }
}
