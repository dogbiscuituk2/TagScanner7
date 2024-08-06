namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using Core;

    public abstract class UndoRedoController<TCommand> : Controller where TCommand : class, ICommand
    {
        #region Constructor

        protected UndoRedoController(Controller parent) : base(parent)
        {
            UndoStack = new Stack<TCommand>();
            RedoStack = new Stack<TCommand>();
        }

        #endregion

        #region Public Properties

        public bool IsModified => LastSave != UndoStack.Count;

        #endregion

        #region Public Methods

        public void Clear()
        {
            LastSave = 0;
            UndoStack.Clear();
            RedoStack.Clear();
            Updater.Run();
        }

        public void UpdateLocalUI()
        {
            if (Paused)
                return;
            UndoMenuItem.Enabled = UndoButton.Enabled = CanUndo;
            RedoMenuItem.Enabled = RedoButton.Enabled = CanRedo;
            string
                undo = CanUndo ? UndoAction : "Undo",
                redo = CanRedo ? RedoAction : "Redo";
            UndoMenuItem.Text = $"&{undo}";
            RedoMenuItem.Text = $"&{redo}";
            UndoButton.ToolTipText = $"{undo}";
            RedoButton.ToolTipText = $"{redo}";
        }

        #endregion

        #region Protected Fields

        protected int LastSave;

        protected readonly Stack<TCommand> UndoStack, RedoStack;

        #endregion

        #region Protected Properties

        protected ToolStripMenuItem UndoMenuItem
        {
            get => _undoMenuItem;
            set => InitMenuItem(_undoMenuItem = value, undo: true);
        }

        protected ToolStripMenuItem RedoMenuItem
        {
            get => _redoMenuItem;
            set => InitMenuItem(_redoMenuItem = value, undo: false);
        }

        protected ToolStripSplitButton UndoButton
        {
            get => _undoButton;
            set => InitSplitButton(_undoButton = value, undo: true);
        }

        protected ToolStripSplitButton RedoButton
        {
            get => _redoButton;
            set => InitSplitButton(_redoButton = value, undo: false);
        }

        protected bool Busy;
        protected bool Paused => Updater.Paused;

        protected bool CanRedo => RedoStack.Count > 0;
        protected bool CanUndo => UndoStack.Count > 0;

        protected string UndoAction => UndoStack.Peek().ToString();
        protected string RedoAction => RedoStack.Peek().ToString();

        protected Action UpdateAction
        {
            get => Updater.Action;
            set => Updater.Action = value;
        }

        #endregion

        #region Protected Methods

        protected int Do(TCommand command, bool spoof)
        {
            if (Busy || command == null)
                return 0;
            if (LastSave > UndoStack.Count)
                LastSave = -1;
            RedoStack.Clear();
            return Redo(command, spoof);
        }

        protected virtual int Do(TCommand command, bool undo, bool spoof = false)
        {
            var stack = undo ? RedoStack : UndoStack;
            stack.Push(command);
            UpdateAction();
            return 0;
        }

        protected void Init(Action updateAction,
            ToolStripMenuItem undoMenuItem, ToolStripMenuItem redoMenuItem,
            ToolStripSplitButton undoButton, ToolStripSplitButton redoButton)
        {
            UpdateAction = updateAction;
            UndoMenuItem = undoMenuItem;
            RedoMenuItem = redoMenuItem;
            UndoButton = undoButton;
            RedoButton = redoButton;
        }

        protected virtual int Redo(TCommand command, bool spoof = false) => Do(command, undo: false, spoof);
        protected virtual int Undo(TCommand command) => Do(command, undo: true, spoof: false);

        #endregion

        #region Private Fields

        private ToolStripMenuItem _undoMenuItem, _redoMenuItem;
        private ToolStripSplitButton _undoButton, _redoButton;

        private readonly UpdateController Updater = new UpdateController(null);

        #endregion

        #region Private Methods

        private void DoMultiple(object item, bool undo)
        {
            var peek = (TCommand)((ToolStripItem)item).Tag;
            if (undo)
                do Undo(); while (RedoStack.Peek() != peek);
            else
                do Redo(); while (UndoStack.Peek() != peek);
        }

        private void DoSingle(bool undo)
        {
            if (undo)
                Undo();
            else
                Redo();
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

        private void InitDropDownItem(ToolStripDropDownItem item, bool undo) =>
            item.DropDownOpening += (sender, e) => PopulateMenu(undo);

        private void InitMenuItem(ToolStripMenuItem item, bool undo)
        {
            item.Click += (sender, e) => DoSingle(undo);
            InitDropDownItem(item, undo);
        }

        private void InitSplitButton(ToolStripSplitButton button, bool undo)
        {
            button.ButtonClick += (sender, e) => DoSingle(undo);
            InitDropDownItem(button, undo);
        }

        private void PopulateMenu(bool undo)
        {
            var commands = (undo ? UndoStack : RedoStack).ToArray();
            var menuItems = (undo ? MainForm.UndoPopupMenu : MainForm.RedoPopupMenu).Items;
            var handler = (EventHandler)((sender, e) => DoMultiple(sender, undo));
            const int MaxItems = 20;
            menuItems.Clear();
            for (int n = 0; n < Math.Min(commands.Length, MaxItems); n++)
            {
                var command = commands[n];
                var item = new ToolStripMenuItem(command.ToString().Escape(), null, handler) { Tag = command };
                item.MouseEnter += (sender, e) => HighlightMenu((ToolStripItem)sender);
                item.Paint += (sender, e) => HighlightMenu((ToolStripItem)sender);
                menuItems.Add(item);
            }
        }

        private int Redo() => CanRedo ? Redo(RedoStack.Pop()) : 0;
        private int Undo() => CanUndo ? Undo(UndoStack.Pop()) : 0;

        #endregion
    }
}
