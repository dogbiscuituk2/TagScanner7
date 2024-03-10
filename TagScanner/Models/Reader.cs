namespace TagScanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using TagScanner.Logging;

    public class Reader
    {
        public Reader(List<string> existingFilePaths, IProgress<ProgressEventArgs> progress)
        {
            ExistingFilePaths = existingFilePaths;
            Progress = progress;
        }

        public void AddFolder(string folderPath, IEnumerable<string> searchPatterns)
        {
            if (!Directory.Exists(folderPath))
                return;
            var filePathLists = new List<IEnumerable<string>>();
            foreach (var searchPattern in searchPatterns)
            {
                var filePathList = Directory.EnumerateFiles(folderPath, searchPattern, SearchOption.AllDirectories);
                WorkCount += filePathList.Count();
                filePathLists.Add(filePathList);
            }
            foreach (var filePathList in filePathLists)
                if (!DoAddWorks(filePathList))
                    break;
        }

        public void AddWorks(IEnumerable<string> filePathList)
        {
            WorkCount += filePathList.Count();
            DoAddWorks(filePathList);
        }

        #region State

        public readonly List<string> ExistingFilePaths;
        public readonly List<Work> Works = new List<Work>();
        private int WorkIndex, WorkCount;
        private readonly IProgress<ProgressEventArgs> Progress;

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
                WorkIndex++;
            }
            catch (Exception ex)
            {
                Logger.LogException(ex, filePath);
                WorkCount--;
            }
            var progressEventArgs = new ProgressEventArgs(WorkIndex, WorkCount, filePath, work);
            Progress.Report(progressEventArgs);
            return progressEventArgs.Continue;
        }

        private bool DoAddWorks(IEnumerable<string> filePathList) => filePathList.FirstOrDefault(p => !DoAddWork(p)) == null;
    }
}
