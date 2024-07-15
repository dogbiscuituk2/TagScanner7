namespace TagScanner.Controllers
{
    using System.Windows.Forms;

    public class TriStateCheckedListController : Controller
    {
        #region Constructor

        public TriStateCheckedListController(Controller parent, CheckedListBox control) : base(parent)
        {
            _control = control;
        }

        #endregion

        #region Private Fields

        private CheckedListBox _control;

        #endregion
    }
}
