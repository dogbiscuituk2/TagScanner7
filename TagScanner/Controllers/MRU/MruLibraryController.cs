namespace TagScanner.Controllers.Mru
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Commands;
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

        protected override bool LoadFromStream(Stream stream, StreamFormat format)
        {
            if (!(LoadDocument(stream, typeof(Selection), format) is Selection selection))
                return false;
            if (ResetLibrary)
            {
                Model.Library = selection;
                return true;
            }
            var tracks = Model.Library.Tracks;
            selection.Tracks.RemoveAll(p => tracks.Any(q => q.FilePath == p.FilePath));
            if (!selection.Tracks.Any())
                return false;
            CommandProcessor.Run(new TracksAddCommand(selection), spoof: false);
            return true;
        }

        protected override bool SaveToStream(Stream stream, StreamFormat format) => SaveDocument(stream, Model.Library, format);

        #endregion
    }
}
