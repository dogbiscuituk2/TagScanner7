namespace TagScanner.Controllers.Mru
{
    using System;
    using System.Collections.Generic;
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
            if (!(LoadDocument(stream, typeof(List<Track>), format) is List<Track> newTracks))
                return false;
            if (!Merging)
            {
                Model.Library = new Selection(newTracks);
                return true;
            }
            var oldTracks = Model.Library.Tracks;
            newTracks.RemoveAll(p => oldTracks.Any(q => q.FilePath == p.FilePath));
            if (!newTracks.Any())
                return false;
            CommandProcessor.Run(new AddCommand(new Selection(newTracks)), spoof: false);
            return true;
        }

        protected override bool SaveToStream(Stream stream, StreamFormat format) =>
            SaveDocument(stream, Model.Library.Tracks, format);

        #endregion
    }
}
