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

    public class PlayerController : GridController
    {
        public PlayerController(MainFormController mainFormController) : base(mainFormController)
        {
            View.GridPopupPlayAddToQueue.Click += PlaylistAddToQueue_Click;
            View.GridPopupPlayNewPlaylist.Click += PlaylistCreateNew_Click;
            View.PlaylistElementHost.Child = new GridElement();
            DataGrid.AutoGenerateColumns = false;
            InitColumns();
            DataGrid.ItemsSource = new ListCollectionView(_currentPlaylist);
            Player.CurrentItemChange += Player_CurrentItemChange;
        }

        public System.Windows.Controls.DataGrid PlaylistGrid => DataGrid;

        private MainFormController MainFormController => (MainFormController)Parent;

        private MainForm View => MainFormController.View;

        private AxWindowsMediaPlayer Player => View.MediaPlayer;

        public override System.Windows.Controls.DataGrid DataGrid => ((GridElement)View.PlaylistElementHost.Child).DataGrid;

        private readonly ObservableCollection<Track> _currentPlaylist = new ObservableCollection<Track>();

        private void PlaylistAddToQueue_Click(object sender, EventArgs e) => PlaySelection(newPlaylist: false);

        private void PlaylistCreateNew_Click(object sender, EventArgs e) => PlaySelection(newPlaylist: true);

        private void PlaySelection(bool newPlaylist)
        {
            var tracks = MainFormController.LibraryGridController.Selection.Tracks.ToArray();
            if (!tracks.Any())
                return;
            if (newPlaylist)
            {
                _currentPlaylist.Clear();
                Player.currentPlaylist = Player.newPlaylist(string.Empty, string.Empty);
            }
            foreach (var track in tracks)
            {
                _currentPlaylist.Add(track);
                Player.currentPlaylist.appendItem(Player.newMedia(track.FilePath));
            }
            Player.Ctlcontrols.play();
            View.TabControl.SelectedTab = View.tabPlayer;
        }

        private void Player_CurrentItemChange(object sender, _WMPOCXEvents_CurrentItemChangeEvent e) => UpdatePlaylist(e.pdispMedia as IWMPMedia);

        private void UpdatePlaylist(IWMPMedia currentItem)
        {
            foreach (var track in _currentPlaylist)
                if (track.FilePath == currentItem.sourceURL)
                {
                    DataGrid.SelectedItems.Clear();
                    DataGrid.SelectedItems.Add(track);
                    break;
                }
        }
    }
}
