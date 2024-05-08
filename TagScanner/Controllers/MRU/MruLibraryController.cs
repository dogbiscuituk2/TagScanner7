namespace TagScanner.Controllers.Mru
{
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

        #endregion

        #region Methods

        protected override void ClearDocument() => MainModel.Clear();

        protected override bool LoadFromStream(Stream stream, StreamFormat format)
        {
            if (!(LoadDocument(stream, typeof(List<Track>), format) is List<Track> newTracks))
                return false;
            if (!Merging)
            {
                MainModel.Library = new Selection(newTracks);
                return true;
            }
            var oldTracks = MainModel.Library.Tracks;
            newTracks.RemoveAll(p => oldTracks.Any(q => q.FilePath == p.FilePath));
            if (!newTracks.Any())
                return false;
            MainCommandProcessor.Run(new AddCommand(new Selection(newTracks)), spoof: false);
            return true;
        }

        protected override bool SaveToStream(Stream stream, StreamFormat format) =>
            SaveDocument(stream, MainModel.Library.Tracks, format);

        #endregion
    }
}
