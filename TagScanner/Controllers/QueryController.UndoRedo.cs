namespace TagScanner.Controllers
{
    using Models;

    public partial class QueryController
    {
        # region Protected Methods

        protected override int Redo(Query query, bool spoof = false)
        {
            return 0;
        }

        protected override int Undo(Query query)
        {
            return 0;
        }

        #endregion
    }
}
