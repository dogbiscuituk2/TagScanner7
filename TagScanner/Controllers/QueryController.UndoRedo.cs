namespace TagScanner.Controllers
{
    using Core;
    using Models;

    partial class QueryController
    {
        #region Protected Methods

        protected override void Do(Query query, bool undo, bool spoof)
        {
            Push(undo);
            SetQuery(query);
        }

        #endregion

        #region Private Methods

        private void Run(Verb verb)
        {
            _verb = verb;
            Push(undo: false);
            RedoStack.Clear();
            DumpStacks();
        }

        private void Push(bool undo) => Push(GetQuery(undo), undo);

        #endregion
    }
}
