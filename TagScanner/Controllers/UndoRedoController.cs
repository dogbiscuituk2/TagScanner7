namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using Utils;

    public abstract class UndoRedoController<T> : Controller where T : class
    {
        #region Constructor

        protected UndoRedoController(Controller parent) : base(parent)
        {
            UndoStack = new Stack<T>();
            RedoStack = new Stack<T>();
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

        #endregion

        #region Protected Fields

        protected int LastSave;

        protected readonly Stack<T> UndoStack, RedoStack;

        #endregion

        #region Protected Properties

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

        protected void InitUI(bool undo, params ToolStripDropDownItem[] items) => Array.ForEach(items, p =>
        {
            if (p is ToolStripSplitButton q)
                q.ButtonClick += (sender, e) => DoSingle(undo);
            else
                p.Click += (sender, e) => DoSingle(undo);
            p.DropDownOpening += (sender, e) => PopulateMenu(undo);
        });

        protected abstract int Undo(T t);
        protected abstract int Redo(T t, bool spoof = false);

        #endregion

        #region Private Fields

        private readonly UpdateController Updater = new UpdateController(null);

        #endregion

        #region Private Methods

        private void DoMultiple(object item, bool undo)
        {
            var peek = (T)((ToolStripItem)item).Tag;
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

        private int Undo() => CanUndo ? Undo(UndoStack.Pop()) : 0;
        private int Redo() => CanRedo ? Redo(RedoStack.Pop()) : 0;

        #endregion
    }
}
