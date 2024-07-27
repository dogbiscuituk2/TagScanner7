namespace TagScanner.Commands
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Controllers;
    using Forms;
    using Utils;

    public class CommandProcessor : UndoRedoController<Command>
    {
        #region Constructor

        public CommandProcessor(Controller parent) : base(parent)
        {
            UpdateAction = UpdateUI;
            AddHandlers(MainForm.EditUndo, MainForm.tbUndo, EditUndo_Click, EditUndo_DropDownOpening);
            AddHandlers(MainForm.EditRedo, MainForm.tbRedo, EditRedo_Click, EditRedo_DropDownOpening);

            void AddHandlers(ToolStripMenuItem item, ToolStripSplitButton button, EventHandler click, EventHandler dropDownOpening)
            {
                item.Click += click;
                button.ButtonClick += click;
                item.DropDownOpening += dropDownOpening;
                button.DropDownOpening += dropDownOpening;
            }
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
        public override int Run(Command command, bool spoof = false)
        {
            if (Busy || command == null)
                return 0;
            if (LastSave > UndoStack.Count)
                LastSave = -1;
            RedoStack.Clear();
            return Redo(command, spoof);
        }

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

        #region Event Handlers

        private void EditUndo_DropDownOpening(object sender, EventArgs e) => PopulateMenu(undo: true);
        private void EditRedo_DropDownOpening(object sender, EventArgs e) => PopulateMenu(undo: false);

        private static void Menu_MouseEnter(object sender, EventArgs e) => HighlightMenu((ToolStripItem)sender);
        private static void Menu_Paint(object sender, PaintEventArgs e) => HighlightMenu((ToolStripItem)sender);

        #endregion

        #region Private Fields

        private bool Busy;

        #endregion

        #region Private Properties

        private string UndoAction => UndoStack.Peek().ToString();
        private string RedoAction => RedoStack.Peek().ToString();

        #endregion

        #region Private Methods

        protected override int Undo(Command command) => DoCommand(command, undo: true, spoof: false);
        protected override int Redo(Command command, bool spoof = false) => DoCommand(command, undo: false, spoof);

        private void UpdateUI() => AppController.UpdateUI(MainFormController);

        private int DoCommand(Command command, bool undo, bool spoof = false)
        {
            var result = command.TracksCount;
            if (!spoof)
            {
                Busy = true;
                result = command.Do(MainModel);
                Busy = false;
            }
            if (result > 0)
            {
                var stack = undo ? RedoStack : UndoStack;
                stack.Push(command);
                UpdateUI();
            }
            return result;
        }

        private static void HighlightMenu(ToolStripItem activeItem)
        {
            if (!activeItem.Selected)
                return;
            var items = activeItem.GetCurrentParent().Items;
            var index = items.IndexOf(activeItem);
            foreach (ToolStripItem item in items)
                item.BackColor = Color.FromKnownColor(items.IndexOf(item) <= index
                    ? KnownColor.GradientActiveCaption
                    : KnownColor.Control);
        }

        private void PopulateMenu(bool undo)
        {
            var commands = (undo ? UndoStack : RedoStack).ToArray();
            var menuItems = (undo ? MainForm.UndoPopupMenu : MainForm.RedoPopupMenu).Items; ;
            var handler = undo ? (EventHandler)UndoMultiple : RedoMultiple;
            const int MaxItems = 20;
            menuItems.Clear();
            for (int n = 0; n < Math.Min(commands.Length, MaxItems); n++)
            {
                var command = commands[n];
                var item = new ToolStripMenuItem(command.ToString().Escape(), null, handler) { Tag = command };
                item.MouseEnter += Menu_MouseEnter;
                item.Paint += Menu_Paint;
                menuItems.Add(item);
            }
        }

        #endregion
    }
}
