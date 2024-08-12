namespace TagScanner.Controllers
{
    partial class QueryController
    {
        #region Protected Methods

        protected override void Redo()
        {
            if (CanRedo)
            {
                UndoStack.Push(GetQuery());
                SetQuery(RedoStack.Pop());
                DumpStacks();
            }
        }

        protected override void Undo()
        {
            if (CanUndo)
            {
                RedoStack.Push(GetQuery());
                SetQuery(UndoStack.Pop());
                DumpStacks();
            }
        }

        #endregion

        #region Private Methods

        private void TakeSnapshot(Act act)
        {
            _lastAct = $"{act}";
            UndoStack.Push(GetQuery());
            RedoStack.Clear();
            DumpStacks();
        }

        #endregion
    }
}
