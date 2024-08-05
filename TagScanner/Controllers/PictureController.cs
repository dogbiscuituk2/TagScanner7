namespace TagScanner.Controllers
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using NReco.VideoConverter;
    using Core;

    public class PictureController
    {
        #region Constructor

        public PictureController(PictureBox pictureBox, PropertyGrid propertyGrid, System.Windows.Controls.DataGrid playlistGrid)
        {
            PictureBox = pictureBox;
            PropertyGrid = propertyGrid;
            PlaylistGrid = playlistGrid;
        }

        #endregion

        #region Private Fields

        private PictureBox _pictureBox;
        private System.Windows.Controls.DataGrid _playlistGrid;
        private PropertyGrid _propertyGrid;

        private static readonly RotateFlipType[] RotateFlipTypes =
        {
            RotateFlipType.RotateNoneFlipNone,
            RotateFlipType.RotateNoneFlipNone,
            RotateFlipType.RotateNoneFlipY,
            RotateFlipType.Rotate180FlipNone,
            RotateFlipType.RotateNoneFlipX,
            RotateFlipType.Rotate90FlipY,
            RotateFlipType.Rotate90FlipNone,
            RotateFlipType.Rotate90FlipX,
            RotateFlipType.Rotate270FlipNone
        };

        #endregion

        #region Private Properties

        private PictureBox PictureBox
        {
            get => _pictureBox;
            set
            {
                _pictureBox = value;
                PictureBox.Resize += PictureBox_Resize;
            }
        }

        private System.Windows.Controls.DataGrid PlaylistGrid
        {
            get => _playlistGrid;
            set
            {
                _playlistGrid = value;
                PlaylistGrid.SelectionChanged += PlaylistGrid_SelectionChanged;
            }
        }

        private PropertyGrid PropertyGrid
        {
            get => _propertyGrid;
            set
            {
                _propertyGrid = value;
                PropertyGrid.SelectedGridItemChanged += PropertyGrid_SelectedGridItemChanged;
                PropertyGrid.SelectedObjectsChanged += PropertyGrid_SelectedObjectsChanged;
            }
        }

        #endregion

        #region Event Handlers

        private void PictureBox_Resize(object sender, EventArgs e) => InitSizeMode();
        private void PlaylistGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) => InitPictureFromTrack(PlaylistGrid.SelectedItem);
        private void PropertyGrid_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e) => InitPicture();
        private void PropertyGrid_SelectedObjectsChanged(object sender, EventArgs e) => InitPicture();

        #endregion

        #region Private Methods

        private Image GetImageFromFile(string filePath, TagLib.Image.ImageOrientation orientation)
        {
            Image image;
            try { image = Image.FromFile(filePath); }
            catch (OutOfMemoryException ex) { ex.LogException(); return null; }
            var rotateFlipType = GetRotateFlipType(orientation);
            if (rotateFlipType != RotateFlipType.RotateNoneFlipNone)
                image.RotateFlip(rotateFlipType);
            return image;
        }

        private Image GetImageFromTrack(ITrack track)
        {
            if (track == null) return null;
            var pictures = track.Pictures;
            if (pictures != null)
            {
                var picture = pictures.FirstOrDefault(p => p != null);
                if (picture != null)
                    return picture.GetImage();
            }
            var filePath = track.FilePath;
            return string.IsNullOrWhiteSpace(filePath) || filePath.EndsWith(@"\")
                ? null
                : (track.MediaTypes & TagLib.MediaTypes.Photo) != 0
                ? GetImageFromFile(filePath, track.ImageOrientation)
                : (track.MediaTypes & TagLib.MediaTypes.Video) != 0 ? GetVideoThumbnail(filePath, track.Duration.TotalSeconds / 10) : null;
        }

        /// <summary>
        /// Given the EXIF orientation of an image, compute the rotation and/or reflection (flip)
        /// required to transform the image to standard "top left" orientation.
        /// </summary>
        /// <param name="orientation">The EXIF orientation of the image.</param>
        /// <returns>The System.Drawing.RotateFlipType value needed to "correct" the image.</returns>
        private static RotateFlipType GetRotateFlipType(TagLib.Image.ImageOrientation orientation) => RotateFlipTypes[(int)orientation];

        private static Image GetVideoThumbnail(string filePath, double frameTimeSeconds)
        {
            var videoConverter = new FFMpegConverter();
            using (var stream = new MemoryStream())
            {
                videoConverter.GetVideoThumbnail(filePath, stream, (float)frameTimeSeconds);
                return Image.FromStream(stream);
            }
        }

        private void InitPicture()
        {
            // If a Picture is selected in the PropertyGrid,
            // then use that particular Picture.
            var gridItem = PropertyGrid.SelectedGridItem;
            var picture = gridItem?.Value as Picture;
            if (picture != null)
            {
                SetPicture(picture);
                return;
            }
            // If no Picture is selected in the PropertyGrid,
            // then use the first Picture in the selection, if any.
            InitPictureFromTrack(PropertyGrid.SelectedObject);
        }

        private void InitPictureFromTrack(object track) => SetImage(GetImageFromTrack(track as ITrack));

        private void InitSizeMode()
        {
            var image = PictureBox.Image;
            if (image != null)
                PictureBox.SizeMode =
                    image.Width > PictureBox.Width || image.Height > PictureBox.Height
                        ? PictureBoxSizeMode.Zoom
                        : PictureBoxSizeMode.CenterImage;
        }

        private void SetImage(Image image)
        {
            PictureBox.Image = image;
            InitSizeMode();
        }

        private void SetPicture(Picture picture) => SetImage(picture?.GetImage());

        #endregion
    }
}
