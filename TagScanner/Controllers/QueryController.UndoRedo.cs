namespace TagScanner.Controllers
{
    using Core;
    using Models;

    partial class QueryController
    {
        #region Protected Methods

        protected override void Do(Query query, bool undo, bool spoof)
        {
            SaveState(query.Verb, undo);
            query.Apply(this);
        }

        #endregion

        #region Private Methods

        private void Run(Verb verb)
        {
            SaveState(verb, undo: false);
            RedoStack.Clear();
            DumpStacks();
        }

        private void SaveState(Verb verb, bool undo)
        {
            _verb = verb;
            var query = new Query(GetSelectedTags(), GetSorts(), GetGroupByTags())
            {
                Clause = FocusedClause,
                Undo = !undo,
                Verb = _verb,
            };
            Push(query, !undo);
        }

        #endregion
    }
}
