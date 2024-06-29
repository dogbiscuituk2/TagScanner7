namespace TagScanner.Controllers
{
    using System.Windows.Forms;
    using Forms;

    public class InputDialogController : Controller
    {
        #region Constructor

        public InputDialogController(Controller parent) : base(parent) { }

        #endregion

        #region Public Methods

        public string Execute(string prompt, string value = "")
        {
            InputDialog.Text = prompt;
            InputDialog.Control.Text = value;
            return InputDialog.ShowDialog(Owner) == DialogResult.OK ? InputDialog.Control.Text : null;
        }

        #endregion

        #region Private Fields

        private InputDialog _inputDialog;

        #endregion

        #region Private Properties

        private InputDialog InputDialog => _inputDialog ?? (_inputDialog = new InputDialog());

        #endregion
    }
}
