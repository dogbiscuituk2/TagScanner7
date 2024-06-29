namespace TagScanner.Controllers
{
    using System.Windows.Forms;
    using Forms;

    public class FileFormatController : Controller
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

        #region Private Fields

        private FileFormatDialog _dialog;

        #endregion

        #region Private Properties

        private Control CbDescription => Dialog.cbDescription;
        private Control CbFilespec => Dialog.cbFilespec;
        private FileFormatDialog Dialog => _dialog ?? (_dialog = new FileFormatDialog());

        #endregion
    }
}
