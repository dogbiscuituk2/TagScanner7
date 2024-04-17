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

        public MruLibraryController(Controller parent, ContextMenuStrip parentMenu)
            : base(parent, Properties.Settings.Default.LibraryFilter, "LibraryMRU", parentMenu.Items) { }

        #endregion

        #region Properties

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
                if (CommandProcessor.IsModified)
                    text = string.Concat("* ", text);
                text = string.Concat(text, " - ", Application.ProductName);
                return text;
            }
        }

        #endregion

        #region Methods

        protected override void ClearDocument() => Model.Clear();

        protected override bool AddFromStream(Stream stream, StreamFormat format)
        {
            var result = false;
            if (LoadDocument(stream, typeof(Library), format) is Library library)
            {

                Model.Library = library;

                foreach (var track in Model.Tracks)
                    track.Edit += Model.Track_Edit;
                result = true;
            }
            return result;
        }

        protected override bool LoadFromStream(Stream stream, StreamFormat format)
        {
            var result = false;
            if (LoadDocument(stream, typeof(Library), format) is Library library)
            {
                Model.Library = library;
                foreach (var track in Model.Tracks)
                    track.Edit += Model.Track_Edit;
                result = true;
            }
            return result;
        }

        protected override bool SaveToStream(Stream stream, StreamFormat format) => SaveDocument(stream, Model.Library, format);

        #endregion
    }
}
