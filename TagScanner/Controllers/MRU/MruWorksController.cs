namespace TagScanner.Controllers.MRU
{
    using Models;
    using System.Windows.Forms;

    internal abstract class MruWorksController : MruSdiController
    {
        internal MruWorksController(IModel model, string filter, string subKeyName, ToolStripMenuItem recentMenuItem)
            : base(model, filter, subKeyName, recentMenuItem) { }

        internal new Model Model
        {
            get => base.Model as Model;
            set => base.Model = value;
        }
    }
}
