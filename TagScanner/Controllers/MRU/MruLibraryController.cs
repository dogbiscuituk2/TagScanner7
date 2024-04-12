namespace TagScanner.Controllers.Mru
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using Models;
    using Streaming;

    public class MruLibraryController : MruSdiController
    {
        #region Constructor

        public MruLibraryController(Model model, ToolStripMenuItem recentMenuItem, IWin32Window owner)
            : base(model, Properties.Settings.Default.LibraryFilter, "LibraryMRU", recentMenuItem, owner) { }

        #endregion

        #region Properties

        public new Model Model
        {
            get => (Model)base.Model;
            set => base.Model = value;
        }

        public string WindowCaption
        {
            get
            {
                var text = FilePath;
                try
                {
                    text = Path.GetFileNameWithoutExtension(text);
                }
                catch (ArgumentException) { }
                var modified = Model.Modified;
                if (modified)
                    text = string.Concat("* ", text);
                text = string.Concat(text, " - ", Application.ProductName);
                return text;
            }
        }

        #endregion

        #region Methods

        protected override void ClearDocument() => Model.Clear();

        protected override bool LoadFromStream(Stream stream, StreamFormat format)
        {
            var result = false;
            if (LoadDocument(stream, typeof(Library), format) is Library library)
            {
                Model.Library = library;
                foreach (var work in Model.Works)
                    work.WorkEdit += Model.Work_Edit;
                result = true;
            }
            return result;
        }

        protected override bool SaveToStream(Stream stream, StreamFormat format) => SaveDocument(stream, Model.Library, format);

        #endregion
    }
}
