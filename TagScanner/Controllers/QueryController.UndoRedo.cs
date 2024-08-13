namespace TagScanner.Controllers
{
    using Models;

    partial class QueryController
    {
        #region Protected Methods

        protected override void Do(Query query, bool undo, bool spoof)
        {
            GetStack(!undo).Push(GetQuery());
            SetQuery(query);
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
