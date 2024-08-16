namespace TagScanner.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    using Models;

    partial class QueryController
    {
        #region Protected Methods

        protected override void Do(Query query, bool undo, bool spoof)
        {
            SaveState(undo, query.Verb, query.Stags, query.Clause);
            query.Apply(this);
        }

        #endregion

        #region Private Methods

        private void Run(Verb verb, IEnumerable<Stag> stags)
        {
            SaveState(undo: false, verb, stags, FocusedClause);
            RedoStack.Clear();
            DumpStacks();
        }

        private void SaveState(bool undo, Verb verb, IEnumerable<Stag> stags, string clause) =>
            Push(
                new Query(
                    GetSelectedTags(),
                    GetSorts(),
                    GetGroupByTags())
                {
                    Undo = !undo,
                    Verb = verb,
                    Stags = stags.ToList(),
                    Clause = clause,
                },
            !undo);

        #endregion
    }
}
