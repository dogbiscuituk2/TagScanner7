namespace TagScanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Terms;
    using Utils;

    public class Model
    {
        #region Fields & Properties

        private string _commonPath;
        public string CommonPath => _commonPath ?? (_commonPath = Utility.GetCommonPath(Tracks?.Select(p => p.FilePath)));

        public Func<Track, bool> FileChecksFilter { get; set; }

        private Selection _library = new Selection(new List<Track>());
        public Selection Library
        {
            get => _library;
            set
            {
                _library = value;
                OnTracksChanged();
            }
        }

        public List<Track> Tracks => Library.Tracks;

        #endregion

        #region Public Methods

        public int AddFiles(string[] filePaths, IProgress<ProgressEventArgs> progress) =>
            ReadTracks(p => p.AddTracks(filePaths), progress);

        public int AddFolder(string folderPath, string filespec, IProgress<ProgressEventArgs> progress)
        {
            var folder = string.Concat(folderPath, '|', filespec);
            return ReadTracks(p => p.AddFolder(folderPath, filespec.Split(';')), progress);
        }

        public int AddRemoveTracks(List<Track> tracks, bool add)
        {
            if (add)
                Tracks.AddRange(tracks);
            else
                Tracks.RemoveAll(p => tracks.Contains(p));
            OnTracksChanged();
            return tracks.Count;
        }

        public void Clear()
        {
            Library.Tracks.Clear();
            OnTracksChanged();
        }

        public bool ProcessTrack(Track track)
        {
            switch (track.Status)
            {
                case Status.New: return AddTrack(track);
                case Status.Pending: return SaveTrack(track);
                case Status.New | Status.Pending: return AddAndSaveTrack(track);
                case Status.Updated: return LoadTrack(track);
                case Status.Deleted: return DropTrack(track);
                default: return false;
            }
        }

        #endregion

        #region Events

        public event EventHandler<SelectionEventArgs> TracksAdd;
        public event EventHandler TracksChanged;
        public event EventHandler<SelectionEditEventArgs> TracksEdit;

        #endregion

        #region Private Methods

        private bool AddTrack(Track track)
        {
            track.IsNew = false;
            return true;
        }

        private bool AddAndSaveTrack(Track track) => AddTrack(track) && SaveTrack(track);

        private bool DropTrack(Track track) => Tracks.Remove(track);

        private bool LoadTrack(Track track)
        {
            track.Load();
            return true;
        }

        protected virtual void OnTracksAdd(Selection selection)
        {
            TracksAdd?.Invoke(this, new SelectionEventArgs(selection));
            OnTracksChanged();
        }

        protected virtual void OnTracksChanged()
        {
            _commonPath = null;
            TracksChanged?.Invoke(this, EventArgs.Empty);
        }

        private int ReadTracks(Action<Reader> action, IProgress<ProgressEventArgs> progress)
        {
            var existingFilePaths = Tracks.Select(t => t.FilePath).ToList();
            var reader = new Reader(this, existingFilePaths, progress);
            action(reader);
            var tracks = reader.Tracks;
            var count = tracks.Count;
            if (count > 0)
                OnTracksAdd(new Selection(tracks));
            return tracks.Count;
        }

        private bool SaveTrack(Track track)
        {
            track.Save();
            return true;
        }

        #endregion
    }
}
