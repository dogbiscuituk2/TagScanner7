﻿namespace TagScanner.Controllers.Mru
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Models;
    using Properties;

    public class MruMediaController : MruMenuController
    {
        #region Constructor

        public MruMediaController(Controller parent, ContextMenuStrip parentMenu) :
            base(parent, "MediaMRU", parentMenu?.Items)
        {
            var filter = Settings.Default.MediaFilter;
            _openFileDialog = new OpenFileDialog { Filter = filter, Multiselect = true, Title = Resources.Select_the_media_file_s__to_add };
            _folderBrowserDialog = new FolderBrowserDialog { Description = Resources.Select_the_media_folder_to_add };
        }

        #endregion

        #region Private Fields

        private readonly FolderBrowserDialog _folderBrowserDialog;
        private readonly OpenFileDialog _openFileDialog;

        #endregion

        #region Public Methods

        public void AddFiles()
        {
            if (_openFileDialog.ShowDialog(Owner) == DialogResult.OK)
                AddFiles(_openFileDialog.FileNames);
        }

        public void AddFiles(string[] paths)
        {
            var folders = paths.Where(p => Directory.Exists(p));
            var files = paths.Except(folders);
            if (files.Any())
            {
                var progress = CreateNewProgress();
                Task.Run(() => MainModel.AddFiles(files.ToArray(), progress));
            }
            if (folders.Any())
            {
                var filter = GetFilter();
                foreach (var folder in folders)
                    AddFolder(folder, filter);
            }
        }

        public void AddFolder()
        {
            if (_folderBrowserDialog.ShowDialog(Owner) != DialogResult.OK) return;
            var folderPath = _folderBrowserDialog.SelectedPath;
            var filter = GetFilter();
            AddItem(MakeItem(folderPath, filter));
            AddFolder(folderPath, filter);
        }

        #endregion

        #region Protected Methods

        protected override void Reuse(ToolStripItem menuItem)
        {
            var item = menuItem.Tag.ToString();
            var itemParts = item.Split('|');
            var folderPath = itemParts[0];
            if (Directory.Exists(folderPath))
                AddFolder(folderPath, itemParts[1]);
            else if (
                MessageBox.Show(
                    Owner,
                    string.Format(Resources.Folder___0___no_longer_exists__Remove_from_menu_, folderPath),
                    Resources.Add_Recent_Folder, MessageBoxButtons.YesNo) == DialogResult.Yes)
                RemoveItem(item);
        }

        #endregion

        #region Private Methods

        private void AddFolder(string folderPath, string filter)
        {
            var progress = CreateNewProgress();
            Task.Run(() => MainModel.AddFolder(folderPath, filter, progress));
        }

        private IProgress<ProgressEventArgs> CreateNewProgress() => MainFormController.StatusController.CreateNewProgress();
        private string GetFilter() => _openFileDialog.Filter.Split('|')[2 * _openFileDialog.FilterIndex - 1];
        private static string MakeItem(string folderPath, string filter) => string.Concat(folderPath, '|', filter);

        #endregion
    }
}
