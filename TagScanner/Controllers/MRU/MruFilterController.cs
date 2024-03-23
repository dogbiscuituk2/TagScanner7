namespace TagScanner.Controllers.Mru
{
    using System.IO;
    using System.Windows.Forms;
    using System.Xml.Serialization;
    using Models;
    using Terms;

    public class MruFilterController : MruSdiController
    {
        public MruFilterController(IModel model, ToolStripMenuItem recentMenuItem)
            : base(model, Properties.Settings.Default.LibraryFilter, "FilterMRU", recentMenuItem) { }

        internal Filter Filter
        {
            get => (Filter)Model;
            set => Model = value;
        }

        protected override void ClearDocument() => Filter.Clear();

        protected override bool LoadFromStream(Stream stream, string format)
        {
            var result = false;
            if (LoadDocument(stream, format) is Conjunction root)
            {
                Filter.Root = root;
                result = true;
            }
            return result;
        }

        protected override bool SaveToStream(Stream stream, string format) => SaveDocument(stream, format, Filter.Root);

        protected override XmlSerializer GetXmlSerializer() => new XmlSerializer(typeof(Conjunction));
    }
}
