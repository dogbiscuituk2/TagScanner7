namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Data;
    using System.Windows.Forms;
    using AxWMPLib;
    using WMPLib;
    using TagScanner.Models;
    using TagScanner.Views;
    
    public class PlayerController : GridController
    {
        public PlayerController(LibraryFormController libraryFormController, ToolStripDropDownItem recentMenu) : base(libraryFormController)
        {
            View.GridPopupPlayAddToQueue.Click += PlaylistAddToQueue_Click;
            View.GridPopupPlayNewPlaylist.Click += PlaylistCreateNew_Click;
            View.PlaylistElementHost.Child = new GridElement();
            DataGrid.AutoGenerateColumns = false;
            InitColumns();
            DataGrid.ItemsSource = new ListCollectionView(CurrentPlaylist);
            Player.CurrentItemChange += Player_CurrentItemChange;
        }

        public System.Windows.Controls.DataGrid PlaylistGrid => DataGrid;

        private LibraryFormController _libraryFormController;
        private LibraryFormController LibraryFormController => (LibraryFormController)Parent;

        private LibraryForm View => LibraryFormController.View;

        private AxWindowsMediaPlayer Player => View.MediaPlayer;

        public override System.Windows.Controls.DataGrid DataGrid => ((GridElement)View.PlaylistElementHost.Child).DataGrid;

        private readonly ObservableCollection<Work> CurrentPlaylist = new ObservableCollection<Work>();

        private void PlaylistAddToQueue_Click(object sender, EventArgs e) => PlaySelection(newPlaylist: false);

        private void PlaylistCreateNew_Click(object sender, EventArgs e) => PlaySelection(newPlaylist: true);

        private void PlaySelection(bool newPlaylist)
        {
            var works = LibraryFormController.LibraryGridController.Selection.Works;
            if (!works.Any())
                return;
            if (newPlaylist)
            {
                CurrentPlaylist.Clear();
                Player.currentPlaylist = Player.newPlaylist(string.Empty, string.Empty);
            }
            foreach (var work in works)
            {
                CurrentPlaylist.Add(work);
                Player.currentPlaylist.appendItem(Player.newMedia(work.FilePath));
            }
            Player.Ctlcontrols.play();
            View.TabControl.SelectedTab = View.tabPlayer;
        }

        private void Player_CurrentItemChange(object sender, _WMPOCXEvents_CurrentItemChangeEvent e) => UpdatePlaylist(e.pdispMedia as IWMPMedia);

        private void UpdatePlaylist(IWMPMedia currentItem)
        {
            for (var index = 0; index < CurrentPlaylist.Count; index++)
                if (CurrentPlaylist[index].FilePath == currentItem.sourceURL)
                {
                    DataGrid.SelectedItems.Clear();
                    DataGrid.SelectedItems.Add(CurrentPlaylist[index]);
                    break;
                }
        }

        protected override IEnumerable<TagProps> GetTagProps() => new[] { Tags.Title, Tags.JoinedPerformers, Tags.Album }.Select(p => p.GetProps());
    }
}
