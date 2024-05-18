namespace TagScanner.Controllers
{
    using System.Windows.Forms;
    using Views;

    public class InputBoxController : Controller
    {
        public InputBoxController(Controller parent) : base(parent) { }

        public string Execute(string prompt)
        {
            InputBox.Text = prompt;
            return InputBox.ShowDialog(Owner) == DialogResult.OK ? InputBox.Text : null;
        }

        private InputBox _inputBox;
        private InputBox InputBox => _inputBox ?? (_inputBox = new InputBox());
    }
}
