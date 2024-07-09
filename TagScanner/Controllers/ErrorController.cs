namespace TagScanner.Controllers
{
    using System.Linq;
    using System.Windows.Forms;

    public class ErrorController : Controller
    {
        #region Constructor

        public ErrorController(Controller parent, params Control[] controls) : base(parent)
        {
            _controls = controls;
            _form = _controls.First().FindForm();
            Init();
        }

        #endregion

        #region Private Fields

        private readonly Control[] _controls;
        private readonly Form _form;

        #endregion

        #region Private Properties

        private IAutocorrect Autocorrector => Parent as IAutocorrect;
        private ErrorProvider ErrorProvider => Getter?.ErrorProvider;
        private IGetErrors Getter => Parent as IGetErrors;

        #endregion

        #region Event Handlers

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Notice that closing is cancelled even when autocorrect succeeds.
            // This lets the user inspect the results of the autocorrect operation.
            if (_form.DialogResult == DialogResult.OK)
                e.Cancel = !Validate();
        }

        #endregion

        #region Private Methods

        private void Init()
        {
            foreach (var control in _controls)
            {
                SetIconAlignment(control, ErrorIconAlignment.MiddleRight);
                SetIconPadding(control, 4);
                control.Validated += (sender, e) => SetError((Control)sender, GetErrors(control));
            }
            _form.FormClosing += Form_FormClosing;
        }

        private string GetErrors(Control control) => Getter?.GetErrors(control);
        private void SetError(Control control, string value) => ErrorProvider?.SetError(control, value);
        private void SetIconAlignment(Control control, ErrorIconAlignment alignment) => ErrorProvider?.SetIconAlignment(control, alignment);
        private void SetIconPadding(Control control, int padding) => ErrorProvider?.SetIconPadding(control, padding);

        /// <summary>
        /// 
        /// </summary>
        /// <returns>True if all data values pass validation. 
        /// False if any value fails, or if autocorrect was invoked (even when successful - 
        /// this lets the user inspect the results of the autocorrect operation).</returns>
        private bool Validate()
        {
            var errors = string.Empty;
            if (!Errors())
                return true;
            if (Autocorrector == null)
                return Ask(string.Empty, MessageBoxButtons.OK);
            if (Ask($"\n\nWould you like to use Autocorrect?", MessageBoxButtons.YesNo))
            {
                Autocorrector.DoAutocorrect();
                if (Errors())
                    Ask($"\n\nAutocorrect failed. Please correct manually.", MessageBoxButtons.OK);
            }
            return false;

            bool Ask(string message, MessageBoxButtons buttons) =>
                MessageBox.Show(_form, $"{errors}{message}", "Data Validation", buttons, MessageBoxIcon.Error) == DialogResult.Yes;

            bool Errors()
            {
                var list = _controls.Select(p => GetErrors(p)).Where(q => !string.IsNullOrEmpty(q)).Distinct();
                var result = list.Any();
                if (result) errors = list.Aggregate((p, q) => $"{p}\n{q}");
                return result;
            }
        }

        #endregion
    }
}
