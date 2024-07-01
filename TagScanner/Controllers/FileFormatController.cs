namespace TagScanner.Controllers
{
    using System.Windows.Forms;
    using Forms;

    public class FileFormatController : Controller, IGetError
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

        public string Filespec
        {
            get => CbFilespec.Text;
            set => CbFilespec.Text = value;
        }

        #endregion

        #region Public Methods

        public bool Execute(string prompt, ref string description, ref string filespec)
        {
            if (Dialog == null)
            {
                Dialog = new FileFormatDialog();
                ErrorController = new ErrorController(this, CbDescription, CbFilespec);
            }
            Dialog.Text = prompt;
            Description = description;
            Filespec = filespec;
            var ok = Dialog.ShowDialog(Owner) == DialogResult.OK;
            if (ok)
            {
                description = Description;
                filespec = Filespec;
            }
            return ok;
        }

        public string GetError(Control control) =>
            control == CbDescription && string.IsNullOrWhiteSpace(CbDescription.Text) ?
            "Description cannot be blank." :
            control == CbFilespec && string.IsNullOrWhiteSpace(CbFilespec.Text) ?
            "Filespec cannot be blank." :
            string.Empty;

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
