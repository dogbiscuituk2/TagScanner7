namespace TagScanner.Controllers
{
    using System.Text;
    using System.Windows.Forms;
    using Forms;

    public class FileFormatController : Controller, IGetErrors
    {
        #region Constructor

        public FileFormatController(Controller parent) : base(parent) { }

        #endregion

        #region Public Properties

        public string Description
        {
            get => CbDescription.Text;
            set => CbDescription.Text = value;
        }

        public ErrorProvider ErrorProvider => Dialog.ErrorProvider;

        public string Filespecs
        {
            get => CbFilespecs.Text;
            set => CbFilespecs.Text = value;
        }

        #endregion

        #region Public Methods

        public bool Execute(string prompt, ref string description, ref string filespecs)
        {
            if (Dialog == null)
            {
                Dialog = new FileFormatDialog();
                ErrorController = new ErrorController(this, CbDescription, CbFilespecs);
            }
            Dialog.Text = prompt;
            Description = description;
            Filespecs = filespecs;
            var ok = Dialog.ShowDialog(Owner) == DialogResult.OK;
            if (ok)
            {
                description = Description;
                filespecs = Filespecs;
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
            if (control == CbFilespecs)
            {
                var text = CbFilespecs.Text;
                if (string.IsNullOrWhiteSpace(text))
                    errors.AppendLine("Filespec(s) cannot be blank.");
                var foo = text.Split('|');

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
        private Control CbFilespecs => Dialog.cbFilespecs;

        #endregion
    }
}
