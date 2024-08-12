﻿namespace TagScanner.Controllers
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
        public override void Run(Command command, bool spoof = false)
        {
            if (Busy || command == null)
                return;
            if (LastSave > UndoStack.Count)
                LastSave = -1;
            base.Run(command, spoof);
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
