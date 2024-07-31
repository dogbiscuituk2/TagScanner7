namespace TagScanner.Controllers.Wpf
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Data;
    using System.Windows.Forms;
    using AxWMPLib;
    using WMPLib;
    using Forms;
    using Models;

    public class WpfPlayerController : WpfGridController
    {
        #region Constructor

        public WpfPlayerController(Controller parent) : base(parent)
        {
            MainForm.tbPlay.ButtonClick += PlaylistAddToQueue_Click;
            MainForm.TablePopupPlayAddToQueue.Click += PlaylistAddToQueue_Click;
            MainForm.tbAddToQueue.Click += PlaylistAddToQueue_Click;
            MainForm.TablePopupPlayNewPlaylist.Click += PlaylistCreateNew_Click;
            MainForm.tbNewPlaylist.Click += PlaylistCreateNew_Click;
            MainForm.PlayerPopupSelectColumns.Click += PlayerPopupSelectColumns_Click;
            MainForm.PlaylistElementHost.Child = new GridElement();
            DataGrid.AutoGenerateColumns = false;
            CreateColumns();
            DataGrid.ItemsSource = new ListCollectionView(_currentPlaylist);
            Player.CurrentItemChange += Player_CurrentItemChange;
            Columns = new List<Tag> { Tag.Title, Tag.JoinedPerformers, Tag.YearAlbum, Tag.Duration, Tag.FileSize };
        }

        #endregion

        #region Public Properties

        public override System.Windows.Controls.DataGrid DataGrid => ((GridElement)MainForm.PlaylistElementHost.Child).DataGrid;

        public System.Windows.Controls.DataGrid PlaylistGrid => DataGrid;

        #endregion

        #region Private Fields

        private readonly ObservableCollection<Track> _currentPlaylist = new ObservableCollection<Track>();

        #endregion

        #region Private Properties

        private AxWindowsMediaPlayer Player => MainForm.MediaPlayer;

        #endregion

        #region Event Handlers

        private void Player_CurrentItemChange(object sender, _WMPOCXEvents_CurrentItemChangeEvent e) => UpdatePlaylist(e.pdispMedia as IWMPMedia);
        private void PlayerPopupSelectColumns_Click(object sender, EventArgs e) => EditTagVisibility("Player");
        private void PlaylistAddToQueue_Click(object sender, EventArgs e) => PlaySelection(newPlaylist: false);
        private void PlaylistCreateNew_Click(object sender, EventArgs e) => PlaySelection(newPlaylist: true);

        #endregion

        #region Private Methods

        private void PlaySelection(bool newPlaylist)
        {
            var tracks = MainTableController.Selection.Tracks.ToArray();
            if (!tracks.Any())
                return;
            if (newPlaylist)
            {
                _currentPlaylist.Clear();
                Player.currentPlaylist = Player.newPlaylist(string.Empty, string.Empty);
            }
            Array.ForEach(tracks, p =>
            {
                _currentPlaylist.Add(p);
                Player.currentPlaylist.appendItem(Player.newMedia(p.FilePath));
            });
            Player.Ctlcontrols.play();
            MainForm.TabControl.SelectedTab = MainForm.tabPlayer;
        }

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

        #endregion
    }
}
