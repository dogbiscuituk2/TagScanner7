namespace TagScanner.Controllers.Mru
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

        #region Fields & Properties

        private readonly FolderBrowserDialog _folderBrowserDialog;
        private readonly OpenFileDialog _openFileDialog;

        private LibraryFormController LibraryFormController => (LibraryFormController)Parent;
        private Model Model => LibraryFormController.Model;

        #endregion

        #region Methods

        public void AddFiles()
        {
            if (_openFileDialog.ShowDialog(Owner) == DialogResult.OK)
                AddFiles(_openFileDialog.FileNames);
        }

        private void AddFiles(string[] filePaths)
        {
            var progress = CreateNewProgress();
            Task.Run(() => Model.AddFiles(filePaths, progress));
        }

        public void AddFolder()
        {
            if (_folderBrowserDialog.ShowDialog(Owner) != DialogResult.OK) return;
            var folderPath = _folderBrowserDialog.SelectedPath;
            var filter = _openFileDialog.Filter.Split('|')[2 * _openFileDialog.FilterIndex - 1];
            AddItem(MakeItem(folderPath, filter));
            AddFolder(folderPath, filter);
        }

        private void AddFolder(string folderPath, string filter)
        {
            var progress = CreateNewProgress();
            Task.Run(() => Model.AddFolder(folderPath, filter, progress));
        }

        private IProgress<ProgressEventArgs> CreateNewProgress() => LibraryFormController.StatusController.CreateNewProgress();

        private static string MakeItem(string folderPath, string filter) => string.Concat(folderPath, '|', filter);

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

        /*
        public void Rescan()
        {
            foreach (var folderParts in Model.Folders.Select(folder => folder.Split('|')))
                AddFolder(folderParts[0], folderParts[1]);
        }
        */

        #endregion
    }
}
