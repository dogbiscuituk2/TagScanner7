namespace TagScanner.Controllers
{
    using System.Windows.Forms;
    using Forms;
    using Models;

    public class FileFilterController : Controller
    {
        #region Constructor

        public FileFilterController(Controller parent) : base(parent) { }

        #endregion

        #region Public Properties

        public FileFilterDialog View => _fileFilterDialog ?? (_fileFilterDialog = new FileFilterDialog());

        #endregion

        #region Public Methods

        public bool Execute(ref FileFilter filter)
        {
            Process(filter, loading: true);
            var ok = View.ShowDialog(Owner) == DialogResult.OK;
            if (ok)
                filter = Process(new FileFilter(), loading: false);
            return ok;
        }

        #endregion

        #region Private Fields

        private FileFilterDialog _fileFilterDialog;

        #endregion

        #region Private Methods

        private FileFilter Process(FileFilter filter, bool loading)
        {
            ProcessCheckBox(View.cbCreatedMin, FileFilterFlags.DateCreatedMin);
            ProcessCheckBox(View.cbCreatedMax, FileFilterFlags.DateCreatedMax);
            ProcessCheckBox(View.cbCreatedUtc, FileFilterFlags.DateCreatedUtc);
            ProcessCheckBox(View.cbModifiedMin, FileFilterFlags.DateModifiedMin);
            ProcessCheckBox(View.cbModifiedMax, FileFilterFlags.DateModifiedMax);
            ProcessCheckBox(View.cbModifiedUtc, FileFilterFlags.DateModifiedUtc);
            ProcessCheckBox(View.cbAccessedMin, FileFilterFlags.DateAccessedMin);
            ProcessCheckBox(View.cbAccessedMax, FileFilterFlags.DateAccessedMax);
            ProcessCheckBox(View.cbAccessedUtc, FileFilterFlags.DateAccessedUtc);
            ProcessCheckBox(View.cbFileSizeMin, FileFilterFlags.FileSizeMin);
            ProcessCheckBox(View.cbFileSizeMax, FileFilterFlags.FileSizeMax);

            if (loading)
            {
                View.dtpCreatedMin.Value = filter.DateCreatedMin;
                View.dtpCreatedMax.Value = filter.DateCreatedMax;
                View.dtpModifiedMin.Value = filter.DateModifiedMin;
                View.dtpModifiedMax.Value = filter.DateModifiedMax;
                View.dtpAccessedMin.Value = filter.DateAccessedMin;
                View.dtpAccessedMax.Value = filter.DateAccessedMax;
                View.seFileSizeMin.Value = filter.FileSizeMin;
                View.seFileSizeMax.Value = filter.FileSizeMax;
            }
            else
            {
                filter.DateCreatedMin = View.dtpCreatedMin.Value;
                filter.DateCreatedMax = View.dtpCreatedMax.Value;
                filter.DateModifiedMin = View.dtpModifiedMin.Value;
                filter.DateModifiedMax = View.dtpModifiedMax.Value;
                filter.DateAccessedMin = View.dtpAccessedMin.Value;
                filter.DateAccessedMax = View.dtpAccessedMax.Value;
                filter.FileSizeMin = (long)View.seFileSizeMin.Value;
                filter.FileSizeMax = (long)View.seFileSizeMax.Value;
            }

            ProcessComboBox(View.cbAttrReadOnly, FileFilterFlags.ReadOnlyTrue, FileFilterFlags.ReadOnlyFalse);
            ProcessComboBox(View.cbAttrHidden, FileFilterFlags.HiddenTrue, FileFilterFlags.HiddenFalse);
            ProcessComboBox(View.cbAttrSystem, FileFilterFlags.SystemTrue, FileFilterFlags.SystemFalse);
            ProcessComboBox(View.cbAttrArchive, FileFilterFlags.ArchiveTrue, FileFilterFlags.ArchiveFalse);

            return filter;

            void ProcessCheckBox(CheckBox control, FileFilterFlags flag)
            {
                if (loading)
                    control.Checked = GetFlag(flag);
                else
                    SetFlag(control.Checked ? flag : 0);
            }

            void ProcessComboBox(ComboBox control, FileFilterFlags yes, FileFilterFlags no)
            {
                if (loading)
                    control.SelectedIndex = GetFlag(yes) ? 1 : GetFlag(no) ? 2 : 0;
                else
                    switch (control.SelectedIndex)
                    {
                        case 1: SetFlag(yes); break;
                        case 2: SetFlag(no); break;
                    }
            }

            bool GetFlag(FileFilterFlags flag) => (filter.Flags & flag) != 0;
            void SetFlag(FileFilterFlags flag) => filter.Flags |= flag;
        }

        #endregion
    }
}
