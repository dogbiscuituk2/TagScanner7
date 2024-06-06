namespace TagScanner.Controllers.Mru
{
    public class MruFilterController : MruStringsController
    {
        #region Constructor

        public MruFilterController(Controller parent) : base(parent, "FilterMRU") { }

        #endregion
    }
}
