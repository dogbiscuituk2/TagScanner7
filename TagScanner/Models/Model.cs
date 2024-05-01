namespace TagScanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Utils;

    public class Model
    {
        #region Fields & Properties

        private string _commonPath;
        public string CommonPath => _commonPath ?? (_commonPath = Utility.GetCommonPath(Tracks?.Select(p => p.FilePath)));

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

        public int AddFiles(string[] filePaths, IProgress<ProgressEventArgs> progress) => ReadTracks(p => p.AddTracks(filePaths), progress);

        public int AddFolder(string folderPath, string fileFilter, IProgress<ProgressEventArgs> progress)
        {
            var folder = string.Concat(folderPath, '|', fileFilter);
            return ReadTracks(p => p.AddFolder(folderPath, fileFilter.Split(';')), progress);
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
            switch (track.FileStatus)
            {
                case FileStatus.New: return AddTrack(track);
                case FileStatus.Pending: return SaveTrack(track);
                case FileStatus.New | FileStatus.Pending: return AddAndSaveTrack(track);
                case FileStatus.Updated: return LoadTrack(track);
                case FileStatus.Deleted: return DropTrack(track);
                default: return false;
            }
        }

        #endregion

        #region Events

        public event EventHandler<SelectionEventArgs> TracksAdd;
        public event EventHandler<SelectionEditEventArgs> TracksEdit;
        public event EventHandler TracksChanged;

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
            var reader = new Reader(existingFilePaths, progress);
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
