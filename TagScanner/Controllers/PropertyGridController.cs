namespace TagScanner.Controllers
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Models;
    using TagScanner.Terms;
    using Views;

    public class PropertyGridController : Controller
    {
        public PropertyGridController(Controller parent) : base(parent)
        {
            MainForm.PropertyGridPopupTagVisibility.Click += PropertyGridPopupTagVisibility_Click;
            MainForm.PropertyGridPopupRefresh.Click += PropertyGridPopupRefresh_Click;
        }

        private MainForm MainForm => MainFormController.View;
        private MainFormController MainFormController => (MainFormController)Parent;
        private PropertyGrid PropertyGrid => MainFormController.View.PropertyGrid;

        public void SetSelection(Selection selection)
        {
            PropertyGrid.SelectedObject = selection;
            PropertyGrid.Enabled = selection != null && selection.Tracks.Any();
            Refresh();
        }

        private void Refresh()
        {
            if (PropertyGrid.SelectedObject is Selection selection)
                selection.Invalidate();
            PropertyGrid.Refresh();
        }

        private void SelectPropertyGridTags()
        {
            var visibleTags = Tags.BrowsableTags;
            var ok = new TagsController(this).Execute("Select the Tags to display in the Details Panel", visibleTags);
            if (ok)
            {
                Tags.WriteBrowsableTags(visibleTags);
                Refresh();
            }
        }

        private void PropertyGridPopupRefresh_Click(object sender, EventArgs e) => Refresh();
        private void PropertyGridPopupTagVisibility_Click(object sender, EventArgs e) => SelectPropertyGridTags();
    }
}
