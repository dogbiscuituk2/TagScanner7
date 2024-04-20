namespace TagScanner.Controllers
{
    using System.Linq;
    using System.Windows.Forms;
    using Models;

    public class PropertyGridController : Controller
    {
        public PropertyGridController(Controller parent) : base(parent) { }

        private MainFormController MainFormController => (MainFormController)Parent;
        private PropertyGrid PropertyGrid => MainFormController.View.PropertyGrid;

        internal void SetSelection(Selection selection)
        {
            PropertyGrid.SelectedObject = selection;
            PropertyGrid.Enabled = selection != null && selection.Tracks.Any();
        }
    }
}
