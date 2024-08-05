namespace TagScanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Core;

    public class Reader
    {
        public Reader(Model model, List<string> existingFilePaths, IProgress<ProgressEventArgs> progress)
        {
            _model = model;
            _existingFilePaths = existingFilePaths;
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

        public readonly List<string> _existingFilePaths;
        public readonly List<Track> _tracks = new List<Track>();
        private Model _model;
        private int _trackIndex, _trackCount;
        private readonly IProgress<ProgressEventArgs> _progress;

        #endregion

        private bool DoAddTrack(string filePath)
        {
            Track track = null;
            try
            {
                if (!_existingFilePaths.Contains(filePath))
                {
                    track = Track.FromPath(filePath, _model.FileChecksFilter);
                    if (track != null)
                    {
                        _tracks.Add(track);
                        _existingFilePaths.Add(filePath);
                    }
                    else
                        _trackCount--;
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
