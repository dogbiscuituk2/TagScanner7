namespace TagScanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Logging;

    public class Reader
    {
        public Reader(List<string> existingFilePaths, IProgress<ProgressEventArgs> progress)
        {
            ExistingFilePaths = existingFilePaths;
            _progress = progress;
        }

        public void AddFolder(string folderPath, IEnumerable<string> searchPatterns)
        {
            if (!Directory.Exists(folderPath))
                return;
            var filePathLists = new List<IEnumerable<string>>();
            foreach (var searchPattern in searchPatterns)
            {
                var filePathList = Directory.EnumerateFiles(folderPath, searchPattern, SearchOption.AllDirectories);
                _workCount += filePathList.Count();
                filePathLists.Add(filePathList);
            }
            foreach (var filePathList in filePathLists.Where(filePathList => !DoAddWorks(filePathList)))
                break;
        }

        public void AddWorks(IEnumerable<string> filePathList)
        {
            _workCount += filePathList.Count();
            DoAddWorks(filePathList);
        }

        #region State

        public readonly List<string> ExistingFilePaths;
        public readonly List<Work> Works = new List<Work>();
        private int _workIndex, _workCount;
        private readonly IProgress<ProgressEventArgs> _progress;

        #endregion

        private bool DoAddWork(string filePath)
        {
            Work work = null;
            try
            {
                if (!ExistingFilePaths.Contains(filePath))
                {
                    ExistingFilePaths.Add(filePath);
                    work = new Work(filePath);
                    Works.Add(work);
                }
                _workIndex++;
            }
            catch (Exception ex)
            {
                Logger.LogException(ex, filePath);
                _workCount--;
            }
            var progressEventArgs = new ProgressEventArgs(_workIndex, _workCount, filePath, work);
            _progress.Report(progressEventArgs);
            return progressEventArgs.Continue;
        }

        private bool DoAddWorks(IEnumerable<string> filePathList) => filePathList.FirstOrDefault(p => !DoAddWork(p)) == null;
    }
}
