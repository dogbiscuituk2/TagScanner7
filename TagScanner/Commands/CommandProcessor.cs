namespace TagScanner.Commands
{
    using Controllers;
    using Forms;

    public class CommandProcessor : UndoRedoController<Command>
    {
        #region Constructor

        public CommandProcessor(Controller parent) : base(parent)
        {
            UpdateAction = UpdateUI;
            InitUI(undo: true, MainForm.EditUndo, MainForm.tbUndo);
            InitUI(undo: false, MainForm.EditRedo, MainForm.tbRedo);
        }

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
        public override int Run(Command command, bool spoof = false) => Do(command, spoof);

        public void UpdateLocalUI()
        {
            if (Paused)
                return;
            MainForm.EditUndo.Enabled = MainForm.tbUndo.Enabled = CanUndo;
            MainForm.EditRedo.Enabled = MainForm.tbRedo.Enabled = CanRedo;
            string
                undo = CanUndo ? UndoAction : "Undo",
                redo = CanRedo ? RedoAction : "Redo";
            MainForm.EditUndo.Text = $"&{undo}";
            MainForm.EditRedo.Text = $"&{redo}";
            MainForm.tbUndo.ToolTipText = $"{undo}";
            MainForm.tbRedo.ToolTipText = $"{redo}";
        }

        #endregion

        #region Private Methods

        private void UpdateUI() => AppController.UpdateUI(MainFormController);

        protected override int Do(Command command, bool undo, bool spoof = false)
        {
            var result = command.TracksCount;
            if (!spoof)
            {
                Busy = true;
                result = command.Do(MainModel);
                Busy = false;
            }
            if (result > 0)
                base.Do(command, undo, spoof);
            return result;
        }

        #endregion
    }
}
