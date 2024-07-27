namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public abstract class UndoRedoController<T> : Controller where T : class
    {
        #region Constructor

        public UndoRedoController(Controller parent) : base(parent)
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
            Update();
        }

        #endregion

        #region Protected Fields

        protected int LastSave;
        protected readonly Stack<T> UndoStack, RedoStack;

        #endregion

        #region Protected Properties

        protected bool CanRedo => RedoStack.Count > 0;
        protected bool CanUndo => UndoStack.Count > 0;
        protected bool Paused => Updater.Paused;

        protected Action UpdateAction
        {
            get => Updater.Action;
            set => Updater.Action = value;
        }

        #endregion

        #region Event Handlers

        protected void EditUndo_Click(object sender, EventArgs e) => Undo();
        protected void EditRedo_Click(object sender, EventArgs e) => Redo();

        protected void UndoMultiple(object sender, EventArgs e) => DoMultiple(sender, undo: true);
        protected void RedoMultiple(object sender, EventArgs e) => DoMultiple(sender, undo: false);

        #endregion

        #region Protected Methods

        protected int Undo() => CanUndo ? Undo(UndoStack.Pop()) : 0;
        protected int Redo() => CanRedo ? Redo(RedoStack.Pop()) : 0;

        protected abstract int Undo(T t);
        protected abstract int Redo(T t, bool spoof = false);

        protected void Update() => Updater.Run();

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

        #endregion
    }
}
