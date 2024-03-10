namespace TagScanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    [Serializable]
    public class Model
    {
        #region Public Interface

        private Library _library = new Library();
        public Library Library
        {
            get => _library;
            set
            {
                _library = value;
                OnWorksChanged();
            }
        }

        public List<string> Folders => Library.Folders;

        public List<Work> Works => Library.Works;

        private bool _modified;
        public bool Modified
        {
            get => _modified;
            set
            {
                if (Modified != value)
                {
                    _modified = value;
                    OnModifiedChanged();
                }
            }
        }

        public int AddFiles(string[] filePaths, IProgress<ProgressEventArgs> progress) => ReadWorks(p => p.AddWorks(filePaths), progress);

        public int AddFolder(string folderPath, string filter, IProgress<ProgressEventArgs> progress)
        {
            var folder = string.Concat(folderPath, '|', filter);
            if (!Folders.Contains(folder))
                Folders.Add(folder);
            return ReadWorks(p => p.AddFolder(folderPath, filter.Split(';')), progress);
        }

        public void Clear()
        {
            Library.Clear();
            OnWorksChanged();
        }

        public bool ProcessWork(Work work)
        {
            switch (work.FileStatus)
            {
                case FileStatus.New: return AddWork(work);
                case FileStatus.Pending: return SaveWork(work);
                case FileStatus.New | FileStatus.Pending: return AddAndSaveWork(work);
                case FileStatus.Updated: return LoadWork(work);
                case FileStatus.Deleted: return DropWork(work);
                default: return false;
            }
        }

        public void Work_PropertyChanged(object sender, PropertyChangedEventArgs e) => Modified = true;

        public event EventHandler ModifiedChanged;
        public event EventHandler WorksChanged;

        #endregion

        #region Private Implementation

        private bool AddWork(Work work)
        {
            work.IsNew = false;
            return true;
        }

        private bool AddAndSaveWork(Work work) => AddWork(work) && SaveWork(work);

        private bool DropWork(Work work) => Works.Remove(work);

        private bool LoadWork(Work work)
        {
            work.Load();
            return true;
        }

        protected virtual void OnModifiedChanged()
        {
            var modifiedChanged = ModifiedChanged;
            if (modifiedChanged != null)
                modifiedChanged(this, EventArgs.Empty);
        }

        protected virtual void OnWorksChanged()
        {
            var worksChanged = WorksChanged;
            if (worksChanged != null)
                WorksChanged(this, EventArgs.Empty);
        }

        private int ReadWorks(Action<Reader> action, IProgress<ProgressEventArgs> progress)
        {
            var existingFilePaths = Works.Select(t => t.FilePath).ToList();
            var reader = new Reader(existingFilePaths, progress);
            action(reader);
            var works = reader.Works;
            Works.AddRange(works);
            OnWorksChanged();
            return works.Count;
        }

        private bool SaveWork(Work work)
        {
            work.Save();
            return true;
        }

        #endregion
    }
}
