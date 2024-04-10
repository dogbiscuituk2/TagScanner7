namespace TagScanner.Controllers.Mru
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Models;
    using Properties;

    public class MruMediaController : MruController
    {
        public MruMediaController(LibraryFormController libraryFormController, ToolStripMenuItem recentMenuItem)
            : base("MediaMRU", recentMenuItem)
        {
            _libraryFormController = libraryFormController;
            _model = libraryFormController.Model;
            var filter = Settings.Default.MediaFilter;
            _openFileDialog = new OpenFileDialog { Filter = filter, Multiselect = true, Title = Resources.Select_the_media_file_s__to_add };
            _folderBrowserDialog = new FolderBrowserDialog { Description = Resources.Select_the_media_folder_to_add };
        }

        private readonly Model _model;
        private IWin32Window Owner => _libraryFormController.View;

        public void AddFiles()
        {
            if (_openFileDialog.ShowDialog(Owner) == DialogResult.OK)
                AddFiles(_openFileDialog.FileNames);
        }

        public void AddFolder()
        {
            if (_folderBrowserDialog.ShowDialog(Owner) != DialogResult.OK) return;
            var folderPath = _folderBrowserDialog.SelectedPath;
            var filter = _openFileDialog.Filter.Split('|')[2 * _openFileDialog.FilterIndex - 1];
            AddItem(MakeItem(folderPath, filter));
            AddFolder(folderPath, filter);
        }

        public void Rescan()
        {
            foreach (var folderParts in _model.Folders.Select(folder => folder.Split('|')))
                AddFolder(folderParts[0], folderParts[1]);
        }

        protected override void Reopen(ToolStripItem menuItem)
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

        private readonly FolderBrowserDialog _folderBrowserDialog;
        private readonly OpenFileDialog _openFileDialog;
        private readonly LibraryFormController _libraryFormController;

        private void AddFiles(string[] filePaths)
        {
            var progress = CreateNewProgress();
            Task.Run(() => _model.AddFiles(filePaths, progress));
        }

        private void AddFolder(string folderPath, string filter)
        {
            var progress = CreateNewProgress();
            Task.Run(() => _model.AddFolder(folderPath, filter, progress));
        }

        private IProgress<ProgressEventArgs> CreateNewProgress() => _libraryFormController.StatusController.CreateNewProgress();

        private static string MakeItem(string folderPath, string filter) => string.Concat(folderPath, '|', filter);
    }
}
