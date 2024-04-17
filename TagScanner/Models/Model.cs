namespace TagScanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

        public int AddFiles(string[] filePaths, IProgress<ProgressEventArgs> progress) => ReadWorks(p => p.AddWorks(filePaths), progress);

        public int AddFolder(string folderPath, string fileFilter, IProgress<ProgressEventArgs> progress)
        {
            var folder = string.Concat(folderPath, '|', fileFilter);
            if (!Folders.Contains(folder))
                Folders.Add(folder);
            return ReadWorks(p => p.AddFolder(folderPath, fileFilter.Split(';')), progress);
        }

        public void AddRemoveWorks(List<Work> works, bool add)
        {
            if (add)
                Works.AddRange(works);
            else
                Works.RemoveAll(p => works.Contains(p));
            OnWorksChanged();
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

        public void Work_Edit(object sender, WorksEditEventArgs e)
        {
            var workEdit = WorksEdit;
            workEdit?.Invoke(sender, e);
        }

        public event EventHandler<WorksEventArgs> WorksAdd;
        public event EventHandler<WorksEditEventArgs> WorksEdit;
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

        protected virtual void OnWorksAdd(List<Work> works)
        {
            var worksAdd = WorksAdd;
            worksAdd?.Invoke(this, new WorksEventArgs(works));
            OnWorksChanged();
        }

        protected virtual void OnWorksChanged()
        {
            var worksChanged = WorksChanged;
            worksChanged?.Invoke(this, EventArgs.Empty);
        }

        private int ReadWorks(Action<Reader> action, IProgress<ProgressEventArgs> progress)
        {
            var existingFilePaths = Works.Select(t => t.FilePath).ToList();
            var reader = new Reader(existingFilePaths, progress);
            action(reader);
            var works = reader.Works;
            var count = works.Count;
            if (count > 0)
                OnWorksAdd(works);
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
