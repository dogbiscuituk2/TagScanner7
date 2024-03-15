namespace TagScanner.Controllers
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Data;
    using System.Windows.Forms;
    using AxWMPLib;
    using WMPLib;
    using Models;
    using Views;
    
    internal class PlayerController : GridController
    {
        internal PlayerController(LibraryFormController libraryFormController, ToolStripDropDownItem recentMenu) : base(libraryFormController)
        {
            View.GridPopupPlayAddToQueue.Click += PlaylistAddToQueue_Click;
            View.GridPopupPlayNewPlaylist.Click += PlaylistCreateNew_Click;
            View.PlaylistElementHost.Child = new GridElement();
            DataGrid.AutoGenerateColumns = false;
            InitColumns();
            DataGrid.ItemsSource = new ListCollectionView(_currentPlaylist);
            Player.CurrentItemChange += Player_CurrentItemChange;
        }

        internal System.Windows.Controls.DataGrid PlaylistGrid => DataGrid;

        private LibraryFormController LibraryFormController => (LibraryFormController)Parent;

        private LibraryForm View => LibraryFormController.View;

        private AxWindowsMediaPlayer Player => View.MediaPlayer;

        internal override System.Windows.Controls.DataGrid DataGrid => ((GridElement)View.PlaylistElementHost.Child).DataGrid;

        private readonly ObservableCollection<Work> _currentPlaylist = new ObservableCollection<Work>();

        private void PlaylistAddToQueue_Click(object sender, EventArgs e) => PlaySelection(newPlaylist: false);

        private void PlaylistCreateNew_Click(object sender, EventArgs e) => PlaySelection(newPlaylist: true);

        private void PlaySelection(bool newPlaylist)
        {
            var works = LibraryFormController.LibraryGridController.Selection.Works;
            var worksArray = works as Work[] ?? works.ToArray();
            if (!worksArray.Any())
                return;
            if (newPlaylist)
            {
                _currentPlaylist.Clear();
                Player.currentPlaylist = Player.newPlaylist(string.Empty, string.Empty);
            }
            foreach (var work in worksArray)
            {
                _currentPlaylist.Add(work);
                Player.currentPlaylist.appendItem(Player.newMedia(work.FilePath));
            }
            Player.Ctlcontrols.play();
            View.TabControl.SelectedTab = View.tabPlayer;
        }

        private void Player_CurrentItemChange(object sender, _WMPOCXEvents_CurrentItemChangeEvent e) => UpdatePlaylist(e.pdispMedia as IWMPMedia);

        private void UpdatePlaylist(IWMPMedia currentItem)
        {
            foreach (var work in _currentPlaylist)
                if (work.FilePath == currentItem.sourceURL)
                {
                    DataGrid.SelectedItems.Clear();
                    DataGrid.SelectedItems.Add(work);
                    break;
                }
        }
    }
}
