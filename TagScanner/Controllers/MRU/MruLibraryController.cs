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
            var result = false;
            if (LoadDocument(stream, typeof(Library), format) is Library library)
            {
                var newTracks = library.Tracks;
                if (!ResetLibrary)
                {
                    var oldTracks = Model.Library.Tracks;
                    newTracks = newTracks.Where(p => oldTracks.FirstOrDefault(q => q.FilePath == p.FilePath) == null).ToList();
                    if (!newTracks.Any())
                        return false;
                }
                foreach (var track in newTracks)
                    track.Edit += Model.Track_Edit;
                if (ResetLibrary)
                    Model.Library = library;
                else
                    CommandProcessor.Run(new TracksAddCommand(newTracks), spoof: false);
                result = true;
            }
            return result;
        }

        protected override bool SaveToStream(Stream stream, StreamFormat format) => SaveDocument(stream, Model.Library, format);

        #endregion
    }
}
