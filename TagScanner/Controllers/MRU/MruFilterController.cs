namespace TagScanner.Controllers.Mru
{
    using System;

    public class MruFilterController : MruStringsController
    {
        public MruFilterController(Controller parent) : base(parent, "FilterMRU") { }
    }
}
