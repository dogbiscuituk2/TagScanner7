namespace TagScanner.Controllers
{
    using System;
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

        private ErrorProvider ErrorProvider => Getter.ErrorProvider;
        private IGetErrors Getter => Parent as IGetErrors;

        #endregion

        #region Event Handlers

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
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

        private string GetErrors(Control control) => Getter.GetErrors(control);
        private void SetError(Control control, string value) => ErrorProvider.SetError(control, value);
        private void SetIconAlignment(Control control, ErrorIconAlignment alignment) => ErrorProvider.SetIconAlignment(control, alignment);
        private void SetIconPadding(Control control, int padding) => ErrorProvider.SetIconPadding(control, padding);

        private bool Validate()
        {
            var errors = _controls.Select(p => GetErrors(p)).Where(q => !string.IsNullOrEmpty(q)).Distinct();
            if (!errors.Any())
                return true;
            var message = errors.Aggregate((p, q) => $"{p}{Environment.NewLine}{q}");
            return MessageBox.Show(_form,
                $"{message}{Environment.NewLine}{Environment.NewLine}Would you like to use Auto Validation?",
                "Data Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes;
        }

        #endregion
    }
}
