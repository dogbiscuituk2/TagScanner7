namespace TagScanner.Controllers
{
    using System.Linq;

    partial class QueryController
    {
        #region Protected Methods

        protected override void Do(bool undo)
        {
            var stack = GetStack(undo);
            if (stack.Any())
            {
                GetStack(!undo).Push(GetQuery());
                SetQuery(stack.Pop());
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
