namespace TagScanner.Controllers.Mru
{
    using System.IO;
    using System.Windows.Forms;
    using System.Xml.Serialization;
    using Models;

    public class MruLibraryController : MruSdiController
    {
        public MruLibraryController(Model model, ToolStripMenuItem recentMenuItem)
            : base(model, Properties.Settings.Default.LibraryFilter, "LibraryMRU", recentMenuItem) { }

        internal new Model Model
        {
            get => (Model)base.Model;
            set => base.Model = value;
        }

        internal string WindowCaption
        {
            get
            {
                var text = Path.GetFileNameWithoutExtension(FilePath);
                if (string.IsNullOrWhiteSpace(text))
                    text = "(untitled)";
                var modified = Model.Modified;
                if (modified)
                    text = string.Concat("* ", text);
                text = string.Concat(text, " - ", Application.ProductName);
                return text;
            }
        }

        protected override void ClearDocument() => Model.Clear();

        protected override bool LoadFromStream(Stream stream, string format)
        {
            var result = false;
            if (LoadDocument(stream, format) is Library library)
            {
                Model.Library = library;
                foreach (var work in Model.Works)
                    work.PropertyChanged += Model.Work_PropertyChanged;
                result = true;
            }
            return result;
        }

        protected override bool SaveToStream(Stream stream, string format) => SaveDocument(stream, format, Model.Library);

        protected override XmlSerializer GetXmlSerializer() => new XmlSerializer(typeof(Library));
    }
}
