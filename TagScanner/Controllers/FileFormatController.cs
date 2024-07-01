namespace TagScanner.Controllers
{
    using System.Windows.Forms;
    using Forms;

    public class FileFormatController : ErrorProviderController
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
                InitErrorProvider(CbDescription);
                InitErrorProvider(CbFilespec);
                Dialog.FormClosing += Dialog_FormClosing;
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

        #endregion

        #region Protected Properties

        protected override ErrorProvider ErrorProvider => Dialog.ErrorProvider;

        #endregion

        #region Protected Methods

        protected override string GetError(Control control) =>
            control == CbDescription && string.IsNullOrWhiteSpace(CbDescription.Text) ?
            "Description cannot be blank" :
            control == CbFilespec && string.IsNullOrWhiteSpace(CbFilespec.Text) ?
            "Filespec cannot be blank" :
            string.Empty;

        #endregion

        private void Dialog_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        #region Private Fields

        private FileFormatDialog Dialog;

        #endregion

        #region Private Properties

        private Control CbDescription => Dialog.cbDescription;
        private Control CbFilespec => Dialog.cbFilespec;

        #endregion
    }
}
