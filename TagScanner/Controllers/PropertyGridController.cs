namespace TagScanner.Controllers
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Forms;
    using Models;

    public class PropertyGridController : Controller
    {
        #region Constructor

        public PropertyGridController(Controller parent) : base(parent)
        {
            MainForm.PropertyGridPopupTagVisibility.Click += PropertyGridPopupTagVisibility_Click;
            MainForm.PropertyGridPopupRefresh.Click += PropertyGridPopupRefresh_Click;
        }

        #endregion

        #region Public Methods

        public void SetSelection(Selection selection)
        {
            PropertyGrid.SelectedObject = selection;
            PropertyGrid.Enabled = selection != null && selection.Tracks.Any();
            Refresh();
        }

        #endregion

        #region Private Properties

        private PropertyGrid PropertyGrid => MainForm.PropertyGrid;

        #endregion

        #region Event Handlers

        private void PropertyGridPopupRefresh_Click(object sender, EventArgs e) => Refresh();
        private void PropertyGridPopupTagVisibility_Click(object sender, EventArgs e) => SelectPropertyGridTags();

        #endregion

        #region Private Methods

        private void Refresh()
        {
            if (PropertyGrid.SelectedObject is Selection selection)
                selection.Invalidate();
            PropertyGrid.Refresh();
        }

        private void SelectPropertyGridTags()
        {
            var visibleTags = Tags.BrowsableTags;
            var ok = new QueryController(this).Execute("Select the Tags to display in the Details Panel", "Tags", visibleTags);
            if (ok)
            {
                Tags.WriteBrowsableTags(visibleTags);
                Refresh();
            }
        }

        #endregion
    }
}
