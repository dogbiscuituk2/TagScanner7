namespace TagScanner.Controllers
{
    using System.Windows.Forms;
    using Forms;

    public class InputBoxController : Controller
    {
        #region Constructor

        public InputBoxController(Controller parent) : base(parent) { }

        #endregion

        #region Public Methods

        public string Execute(string prompt)
        {
            InputBox.Text = prompt;
            return InputBox.ShowDialog(Owner) == DialogResult.OK ? InputBox.Text : null;
        }

        #endregion

        #region Private Fields

        private InputBox _inputBox;

        #endregion

        #region Private Properties

        private InputBox InputBox => _inputBox ?? (_inputBox = new InputBox());

        #endregion
    }
}
