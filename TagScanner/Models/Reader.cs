namespace TagScanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Utils;

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
                try
                {
                    filePathLists.Add(filePathList);
                    _trackCount += filePathList.Count();
                }
                catch (Exception exception)
                {
                    exception.LogException();
                }
            }
            foreach (var filePathList in filePathLists.Where(filePathList => !DoAddTracks(filePathList)))
                break;
        }

        public void AddTracks(IEnumerable<string> filePathList)
        {
            _trackCount += filePathList.Count();
            DoAddTracks(filePathList);
        }

        #region State

        public readonly List<string> ExistingFilePaths;
        public readonly List<Track> Tracks = new List<Track>();
        private int _trackIndex, _trackCount;
        private readonly IProgress<ProgressEventArgs> _progress;

        #endregion

        private bool DoAddTrack(string filePath)
        {
            Track track = null;
            try
            {
                if (!ExistingFilePaths.Contains(filePath))
                {
                    track = new Track(filePath);
                    Tracks.Add(track);
                    ExistingFilePaths.Add(filePath);
                }
                _trackIndex++;
            }
            catch (Exception exception)
            {
                exception.LogException();
                _trackCount--;
            }
            var progressEventArgs = new ProgressEventArgs(_trackIndex, _trackCount, filePath, track);
            _progress.Report(progressEventArgs);
            return progressEventArgs.Continue;
        }

        private bool DoAddTracks(IEnumerable<string> filePaths)
        {
            try
            {
                return filePaths.FirstOrDefault(p => !DoAddTrack(p)) == null;
            }
            catch (Exception exception)
            {
                exception.LogException();
                return false;
            }
        }
    }
}
