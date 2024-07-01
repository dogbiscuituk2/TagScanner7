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
            Controls = controls;
            Form = Controls.First().FindForm();
            Init();
        }

        #endregion

        #region Private Fields

        private readonly Control[] Controls;
        private readonly Form Form;

        #endregion

        #region Private Properties

        private ErrorProvider ErrorProvider => Getter.ErrorProvider;
        private IGetError Getter => Parent as IGetError;

        #endregion

        #region Event Handlers

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Form.DialogResult == DialogResult.OK)
            {
                var errors = Controls.Select(p => GetError(p)).Where(q => !string.IsNullOrEmpty(q));
                if (e.Cancel = errors.Any())
                    MessageBox.Show(
                        Form,
                        errors.Aggregate((p, q) => $"{p}{Environment.NewLine}{q}"),
                        "Data Validation Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Private Methods

        private void Init()
        {
            foreach (var control in Controls)
            {
                SetIconAlignment(control, ErrorIconAlignment.MiddleRight);
                SetIconPadding(control, 4);
                control.Validated += (sender, e) => SetError((Control)sender, GetError(control));
            }
            Form.FormClosing += Form_FormClosing;
        }

        private string GetError(Control control) => Getter.GetError(control);
        private void SetError(Control control, string value) => ErrorProvider.SetError(control, value);
        private void SetIconAlignment(Control control, ErrorIconAlignment alignment) => ErrorProvider.SetIconAlignment(control, alignment);
        private void SetIconPadding(Control control, int padding) => ErrorProvider.SetIconPadding(control, padding);

        #endregion
    }
}
