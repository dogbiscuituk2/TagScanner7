namespace TagScanner.Controllers.MRU
{
    using System.IO;
    using System.Windows.Forms;
    using TagScanner.Models;

    internal class MruFilterController : MruSdiController
    {
        public MruFilterController(IModel model, string filter, string subKeyName, ToolStripMenuItem recentMenuItem) : base(model, filter, subKeyName, recentMenuItem)
        {
        }

        protected override void ClearDocument()
        {
            throw new System.NotImplementedException();
        }

        protected override bool LoadFromStream(Stream stream, string format)
        {
            return true;
        }

        protected override bool SaveToStream(Stream stream, string format)
        {
            return true;
        }
    }
}
