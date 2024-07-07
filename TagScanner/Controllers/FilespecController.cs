namespace TagScanner.Controllers
{
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Forms;
    using Utils;

    public class FilespecController : Controller, IGetErrors
    {
        #region Constructor

        public FilespecController(Controller parent) : base(parent) { }

        #endregion

        #region Public Properties

        public string Description
        {
            get => CbDescription.Text;
            set => CbDescription.Text = value;
        }

        public ErrorProvider ErrorProvider => Dialog.ErrorProvider;

        public string Filespec
        {
            get => CbFilespec.Text;
            set => CbFilespec.Text = value;
        }

        #endregion

        #region Public Methods

        public bool Execute(string prompt, int level, ref string description, ref string filespec)
        {
            if (Dialog == null)
            {
                Dialog = new FileFormatDialog();
                ErrorController = new ErrorController(this, CbDescription, CbFilespec);
            }
            Dialog.Text = prompt;
            Description = description;
            Filespec = filespec;
            CbFilespec.Enabled = level == 2;
            var ok = Dialog.ShowDialog(Owner) == DialogResult.OK;
            if (ok)
            {
                description = Description;
                filespec = Filespec;
            }
            return ok;
        }

        public string GetErrors(Control control)
        {
            var errors = new StringBuilder();
            if (control == CbDescription)
            {
                if (string.IsNullOrWhiteSpace(CbDescription.Text))
                    errors.AppendLine("Description cannot be blank.");
            }
            if (control == CbFilespec && control.Enabled)
            {
                var text = CbFilespec.Text;
                if (string.IsNullOrWhiteSpace(text))
                    errors.AppendLine("Filespec(s) cannot be blank.");
                if (text.Split('|').Any(p => !p.IsValidFilePath()))
                    errors.AppendLine($"Invalid character(s) in Filespec(s).");
            }
            return errors.ToString().Trim();
        }

        #endregion

        #region Private Fields

        private FileFormatDialog Dialog;
        private ErrorController ErrorController;

        #endregion

        #region Private Properties

        private Control CbDescription => Dialog.cbDescription;
        private Control CbFilespec => Dialog.cbFilespec;

        #endregion
    }
}
