namespace TagScanner.Controllers.Mru
{
    using System.IO;
    using System.Windows.Forms;
    using Models;

    public class MruLibraryController : MruSdiController
    {
        public MruLibraryController(Model model, ToolStripMenuItem recentMenuItem)
            : base(model, Properties.Settings.Default.LibraryFilter, "LibraryMRU", recentMenuItem) { }

        public new Model Model
        {
            get => (Model)base.Model;
            set => base.Model = value;
        }

        public string WindowCaption
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

        protected override bool LoadFromStream(Stream stream)
        {
            var result = false;
            if (LoadDocument(stream) is Library library)
            {
                Model.Library = library;
                foreach (var work in Model.Works)
                    work.PropertyChanged += Model.Work_PropertyChanged;
                result = true;
            }
            return result;
        }

        protected override bool SaveToStream(Stream stream) => SaveDocument(stream, Model.Library);
    }
}
