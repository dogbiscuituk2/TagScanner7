namespace TagScanner.Controllers
{
    using System.Collections.Generic;

    public abstract class UndoRedoController<T> : Controller
    {
        #region Constructor

        public UndoRedoController(Controller parent) : base(parent)
        {
            UndoStack = new Stack<T>();
            RedoStack = new Stack<T>();
        }

        #endregion

        #region Protected Fields

        protected readonly Stack<T> UndoStack, RedoStack;

        #endregion

        #region Protected Properties

        protected bool CanRedo => RedoStack.Count > 0;
        protected bool CanUndo => UndoStack.Count > 0;

        #endregion

        #region Protected Methods

        protected int Undo() => CanUndo ? Undo(UndoStack.Pop()) : 0;
        protected int Redo() => CanRedo ? Redo(RedoStack.Pop()) : 0;

        protected abstract int Undo(T t);
        protected abstract int Redo(T t, bool spoof = false);

        #endregion
    }
}
