namespace TagScanner.Controllers.Mru
{
    public class MruFilterController : MruStringsController
    {
        public MruFilterController(Controller parent) : base(parent, "FilterMRU") { }
    }
}
