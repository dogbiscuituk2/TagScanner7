namespace TagScanner.Controllers
{
    using Models;

    partial class QueryController
    {
        #region Protected Methods

        protected override void Do(Query query, bool undo, bool spoof)
        {
            Foo(undo);
            SetQuery(query);
        }

        #endregion

        #region Private Methods

        private void TakeSnapshot(Act act)
        {
            _lastAct = $"{act}";
            Foo(undo: false);
            RedoStack.Clear();
            DumpStacks();
        }

        private void Foo(bool undo) => Foo(GetQuery(), undo);

        #endregion
    }
}
