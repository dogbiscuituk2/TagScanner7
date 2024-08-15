namespace TagScanner.Controllers
{
    using Core;
    using Models;

    partial class QueryController
    {
        #region Protected Methods

        protected override void Do(Query query, bool undo, bool spoof)
        {
            _verb = query.Verb;
            Push(!undo);
            query.Apply(this);
        }

        #endregion

        #region Private Methods

        private void Run(Verb verb)
        {
            _verb = verb;
            Push(undo: true);
            RedoStack.Clear();
            DumpStacks();
        }

        private void Push(bool undo) => Push(GetQuery(undo), undo);

        #endregion
    }
}
