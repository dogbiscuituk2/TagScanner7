namespace TagScanner.Controllers
{
    using Models;

    partial class QueryController
    {
        #region Protected Properties

        protected override string RedoAction => CanRedo ? $"Redo {RedoStack.Peek()}" : base.RedoAction;
        protected override string UndoAction => CanUndo ? $"Undo {UndoStack.Peek()}" : base.UndoAction;

        #endregion

        #region Protected Methods

        protected override void Redo(Query query, bool spoof = false)
        {
            UndoStack.Push(GetQuery());
            SetQuery(query);
            DumpStacks();
        }

        protected override void Undo(Query query)
        {
            RedoStack.Push(GetQuery());
            SetQuery(query);
            DumpStacks();
        }

        #endregion
    }
}
