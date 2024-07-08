namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
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

        private bool Validate()
        {
            var errorList = GetErrorList();
            if (string.IsNullOrEmpty(errorList))
                return true;
            var canAutocorrect = Autocorrector != null;
            if (!canAutocorrect)
            {
                ShowMessage(string.Empty, MessageBoxButtons.OK);
                return false;
            }
            if (ShowMessage($"\n\nWould you like Autocorrect to make the necessary corrections?", MessageBoxButtons.YesNo) == DialogResult.No)
                return false;
            Autocorrector.DoAutocorrect();
            errorList = GetErrorList();
            if (string.IsNullOrEmpty(errorList))
                return true;
            ShowMessage($"\n\nAutocorrect failed. Please make the necessary corrections manually.", MessageBoxButtons.OK);
            return false;

            string GetErrorList()
            {
                var errors = _controls.Select(p => GetErrors(p)).Where(q => !string.IsNullOrEmpty(q)).Distinct();
                return errors.Any() ? errors.Aggregate((p, q) => $"{p}{Environment.NewLine}{q}") : string.Empty;
            }

            DialogResult ShowMessage(string question, MessageBoxButtons buttons) =>
                MessageBox.Show(_form, $"{errorList}{question}", "Data Validation", buttons, MessageBoxIcon.Error);
        }

        #endregion
    }
}
