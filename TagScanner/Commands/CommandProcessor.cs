namespace TagScanner.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using Controllers;
    using Models;
    using Views;

    public class CommandProcessor : Controller
    {
        #region Constructor

        public CommandProcessor(LibraryFormController parent) : base(parent)
        {
            UndoStack = new Stack<Command>();
            RedoStack = new Stack<Command>();
            AddHandlers(View.EditUndo, View.tbUndo, EditUndo_Click, EditUndo_DropDownOpening);
            AddHandlers(View.EditRedo, View.tbRedo, EditRedo_Click, EditRedo_DropDownOpening);
            UpdateMenu();

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

        private LibraryFormController LibraryFormController => (LibraryFormController)Parent;
        private Model Model => LibraryFormController.Model;
        private LibraryForm View => LibraryFormController.View;
        private List<Work> Works => Model.Works;

        #endregion

        #region Public Methods

        public void Clear()
        {
            LastSave = 0;
            UndoStack.Clear();
            RedoStack.Clear();
            UpdateMenu();
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
        public bool Run(Command command, bool spoof = false)
        {
            if (Busy || command == null)
                return false;
            if (LastSave > UndoStack.Count)
                LastSave = -1;
            RedoStack.Clear();
            var result = Redo(command, spoof);
            return result;
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

        private string UndoAction => UndoStack.Peek().UndoAction;
        private string RedoAction => RedoStack.Peek().RedoAction;

        private void BeginUpdate() { ++UpdateCount; }

        private bool DoCommand(Command command, bool undo, bool spoof = false)
        {
            Busy = true;
            var result = spoof || command.Do();
            Busy = false;
            if (!result)
                return false;
            var stack = undo ? RedoStack : UndoStack;
            stack.Push(command);
            UpdateMenu();
            return true;
        }

        private void EndUpdate()
        {
            if (--UpdateCount == 0)
                UpdateMenu();
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
                var item = new ToolStripMenuItem(command.ToString(), null, handler) { Tag = command };
                item.MouseEnter += Menu_MouseEnter;
                item.Paint += Menu_Paint;
                menuItems.Add(item);
            }
        }

        private bool Undo() => CanUndo && Undo(UndoStack.Pop());
        private bool Redo() => CanRedo && Redo(RedoStack.Pop());

        private bool Undo(Command command) => DoCommand(command, undo: true, spoof: false);
        private bool Redo(Command command, bool spoof = false) => DoCommand(command, undo: false, spoof);

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

        private void UpdateMenu()
        {
            if (UpdateCount > 0)
                return;
            View.EditUndo.Enabled = View.tbUndo.Enabled = CanUndo;
            View.EditRedo.Enabled = View.tbRedo.Enabled = CanRedo;
            string
                undo = CanUndo ? $"Undo {UndoAction}" : "Undo",
                redo = CanRedo ? $"Redo {RedoAction}" : "Redo";
            View.EditUndo.Text = $"&{undo}";
            View.EditRedo.Text = $"&{redo}";
            View.tbUndo.ToolTipText = $"{undo}";
            View.tbRedo.ToolTipText = $"{redo}";
        }

        #endregion
    }
}
