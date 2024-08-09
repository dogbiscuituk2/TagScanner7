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
    }
}
