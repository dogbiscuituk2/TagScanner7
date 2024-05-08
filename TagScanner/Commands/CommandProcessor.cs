namespace TagScanner.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using Controllers;
    using Models;
    using TagScanner.Utils;
    using Views;

    public class CommandProcessor : Controller
    {
        #region Constructor

        public CommandProcessor(Controller parent) : base(parent)
        {
            UndoStack = new Stack<Command>();
            RedoStack = new Stack<Command>();
            AddHandlers(View.EditUndo, View.tbUndo, EditUndo_Click, EditUndo_DropDownOpening);
            AddHandlers(View.EditRedo, View.tbRedo, EditRedo_Click, EditRedo_DropDownOpening);

            void AddHandlers(ToolStripMenuItem item, ToolStripSplitButton button, EventHandler click, EventHandler dropDownOpening)
            {
                item.Click += click;
                button.ButtonClick += click;
                item.DropDownOpening += dropDownOpening;
                button.DropDownOpening += dropDownOpening;
            }
        }

        #endregion

        #region Fields

        private readonly Stack<Command> UndoStack, RedoStack;
        private int LastSave, UpdateCount;
        private bool Busy;

        #endregion

        #region Properties

        public bool IsModified => LastSave != UndoStack.Count;

        private Model Model => MainFormController.Model;
        private MainForm View => MainFormController.View;
        private List<Track> Tracks => Model.Tracks;

        #endregion

        #region Public Methods

        public void Clear()
        {
            LastSave = 0;
            UndoStack.Clear();
            RedoStack.Clear();
            UpdateUI();
        }

        /// <summary>
        /// Run a command, pushing its memento on to the Undo stack.
        /// </summary>
        /// <param name="command">The command to run.</param>
        /// <param name="spoof">A flag indicating whether the command should actually be run. 
        /// If true, the command should be run as normal. 
        /// If false, the relevant properties have already been changed on the target, 
        /// so just log the memento to the Undo stack.</param>
        /// <returns>True if the command was run, and actually caused a property change.</returns>
        public int Run(Command command, bool spoof = false)
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
            if (UpdateCount > 0)
                return;
            View.EditUndo.Enabled = View.tbUndo.Enabled = CanUndo;
            View.EditRedo.Enabled = View.tbRedo.Enabled = CanRedo;
            string
                undo = CanUndo ? UndoAction : "Undo",
                redo = CanRedo ? RedoAction : "Redo";
            View.EditUndo.Text = $"&{undo}";
            View.EditRedo.Text = $"&{redo}";
            View.tbUndo.ToolTipText = $"{undo}";
            View.tbRedo.ToolTipText = $"{redo}";
        }

        #endregion

        #region Private Methods

        private void EditUndo_Click(object sender, EventArgs e) => Undo();
        private void EditRedo_Click(object sender, EventArgs e) => Redo();

        private void EditUndo_DropDownOpening(object sender, EventArgs e) => PopulateMenu(undo: true);
        private void EditRedo_DropDownOpening(object sender, EventArgs e) => PopulateMenu(undo: false);

        private static void Menu_MouseEnter(object sender, EventArgs e) => HighlightMenu((ToolStripItem)sender);
        private static void Menu_Paint(object sender, PaintEventArgs e) => HighlightMenu((ToolStripItem)sender);

        private bool CanRedo => RedoStack.Count > 0;
        private bool CanUndo => UndoStack.Count > 0;

        private string UndoAction => UndoStack.Peek().ToString();
        private string RedoAction => RedoStack.Peek().ToString();

        private void BeginUpdate() { ++UpdateCount; }

        private int DoCommand(Command command, bool undo, bool spoof = false)
        {
            var result = command.TracksCount;
            if (!spoof)
            {
                Busy = true;
                result = command.Do(Model);
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

        private void EndUpdate()
        {
            if (--UpdateCount == 0)
                UpdateUI();
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
            var menuItems = (undo ? View.UndoPopupMenu : View.RedoPopupMenu).Items; ;
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

        private int Undo() => CanUndo ? Undo(UndoStack.Pop()) : 0;
        private int Redo() => CanRedo ? Redo(RedoStack.Pop()) : 0;

        private int Undo(Command command) => DoCommand(command, undo: true, spoof: false);
        private int Redo(Command command, bool spoof = false) => DoCommand(command, undo: false, spoof);

        private void RedoMultiple(object sender, EventArgs e)
        {
            BeginUpdate();
            var peek = ((ToolStripItem)sender).Tag;
            do Redo(); while (UndoStack.Peek() != peek);
            EndUpdate();
        }

        private void UndoMultiple(object sender, EventArgs e)
        {
            BeginUpdate();
            var peek = ((ToolStripItem)sender).Tag;
            do Undo(); while (RedoStack.Peek() != peek);
            EndUpdate();
        }

        private void UpdateUI() => AppController.UpdateUI(MainFormController);

        #endregion
    }
}
