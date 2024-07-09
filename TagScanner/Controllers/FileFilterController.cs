namespace TagScanner.Controllers
{
    using System;
    using System.Text;
    using System.Windows.Forms;
    using Controls;
    using Models;

    public class FileFilterController : Controller, IGetErrors, IAutocorrect
    {
        #region Constructor

        public FileFilterController(Controller parent) : base(parent) { }

        #endregion

        #region Public Properties

        public ErrorProvider ErrorProvider { get; private set; } = new ErrorProvider();

        #endregion

        #region Public Methods

        public void AfterExecute() => Process(loading: false);
        public void BeforeExecute() => Process(loading: true);

        public void DoAutocorrect()
        {
            _useAutocorrect = true;
            AdjustCreatedDate(lower: true);
            AdjustModifiedDate(lower: true);
            AdjustAccessedDate(lower: true);
            AdjustFileSize(lower: true);
        }

        public void SetView(FileFilterControl view)
        {
            View = view;

            CbCreatedUtc = View.cbCreatedUtc;
            CbModifiedUtc = View.cbModifiedUtc;
            CbAccessedUtc = View.cbAccessedUtc;
            CbFileSizeMin = View.cbFileSizeMin;
            CbFileSizeMax = View.cbFileSizeMax;

            CbReadOnly = View.cbAttrReadOnly;
            CbHidden = View.cbAttrHidden;
            CbSystem = View.cbAttrSystem;
            CbArchive = View.cbAttrArchive;
            CbCompressed = View.cbAttrCompressed;
            CbEncrypted = View.cbAttrEncrypted;

            DtpCreatedMin = View.dtpCreatedMin;
            DtpCreatedMax = View.dtpCreatedMax;
            DtpModifiedMin = View.dtpModifiedMin;
            DtpModifiedMax = View.dtpModifiedMax;
            DtpAccessedMin = View.dtpAccessedMin;
            DtpAccessedMax = View.dtpAccessedMax;

            SeFileSizeMin = View.seFileSizeMin;
            SeFileSizeMax = View.seFileSizeMax;

            DtpCreatedMin.Value = DtpModifiedMin.Value = DtpAccessedMin.Value =
                DtpCreatedMax.Value = DtpModifiedMax.Value = DtpAccessedMax.Value = DateTime.Today;

            SeFileSizeMin.Maximum = SeFileSizeMax.Maximum = ulong.MaxValue;

            DtpCreatedMin.ValueChanged += (sender, e) => AdjustCreatedDate(lower: true);
            DtpCreatedMax.ValueChanged += (sender, e) => AdjustCreatedDate(lower: false);
            DtpModifiedMin.ValueChanged += (sender, e) => AdjustModifiedDate(lower: true);
            DtpModifiedMax.ValueChanged += (sender, e) => AdjustModifiedDate(lower: false);
            DtpAccessedMin.ValueChanged += (sender, e) => AdjustAccessedDate(lower: true);
            DtpAccessedMax.ValueChanged += (sender, e) => AdjustAccessedDate(lower: false);
            CbFileSizeMin.CheckedChanged += (sender, e) => AdjustFileSize(lower: true);
            CbFileSizeMax.CheckedChanged += (sender, e) => AdjustFileSize(lower: false);
            SeFileSizeMin.ValueChanged += (sender, e) => AdjustFileSize(lower: true);
            SeFileSizeMax.ValueChanged += (sender, e) => AdjustFileSize(lower: false);

            new ErrorController(this,
                DtpCreatedMin, DtpCreatedMax,
                DtpModifiedMin, DtpModifiedMax,
                DtpAccessedMin, DtpAccessedMax,
                SeFileSizeMin, SeFileSizeMax);
        }

        public string GetErrors(Control control)
        {
            var errors = new StringBuilder();
            if (control == DtpCreatedMin || control == DtpCreatedMax)
                CheckDates(DtpCreatedMin, DtpCreatedMax, "Created");
            if (control == DtpModifiedMin || control == DtpModifiedMax)
                CheckDates(DtpModifiedMin, DtpModifiedMax, "Modified");
            if (control == DtpAccessedMin || control == DtpAccessedMax)
                CheckDates(DtpAccessedMin, DtpAccessedMax, "Accessed");
            if (control == SeFileSizeMin || control == SeFileSizeMax)
                if (CbFileSizeMin.Checked && CbFileSizeMax.Checked && SeFileSizeMin.Value > SeFileSizeMax.Value)
                    errors.AppendLine("The minimum File Size cannot be greater than the maximum.");
            return errors.ToString().Trim();

            void CheckDates(DateTimePicker min, DateTimePicker max, string which)
            {
                if (!DatesOK(min, max))
                    errors.AppendLine($"The first {which} Date cannot be later than the last.");
            }
        }

        #endregion

        #region Private Fields

        private readonly FileOptions FileOptions = new FileOptions();
        private bool _updating;
        private FileFilterControl View;

        private CheckBox
            CbCreatedUtc, CbModifiedUtc, CbAccessedUtc,
            CbFileSizeMin, CbFileSizeMax;

        private ComboBox
            CbReadOnly, CbHidden, CbSystem, CbArchive, CbCompressed, CbEncrypted;

        private DateTimePicker
            DtpCreatedMin, DtpCreatedMax,
            DtpModifiedMin, DtpModifiedMax,
            DtpAccessedMin, DtpAccessedMax;

        private NumericUpDown
            SeFileSizeMin, SeFileSizeMax;

        private bool _useAutocorrect;

        #endregion

        #region Private Methods

        private void AdjustCreatedDate(bool lower) => AdjustDate(DtpCreatedMin, DtpCreatedMax, lower);
        private void AdjustModifiedDate(bool lower) => AdjustDate(DtpModifiedMin, DtpModifiedMax, lower);
        private void AdjustAccessedDate(bool lower) => AdjustDate(DtpAccessedMin, DtpAccessedMax, lower);

        private void AdjustDate(DateTimePicker min, DateTimePicker max, bool lower)
        {
            if (!_useAutocorrect || DatesOK(min, max))
                return;
            _updating = true;
            if (lower)
                min.Value = max.Value;
            else
                max.Value = min.Value;
            _updating = false;
        }

        private void AdjustFileSize(bool lower)
        {
            Update(CbFileSizeMin, SeFileSizeMin);
            Update(CbFileSizeMax, SeFileSizeMax);

            if (!_useAutocorrect || FileSizesOK())
                return;

            _updating = true;
            if (lower)
                SeFileSizeMin.Value = SeFileSizeMax.Value;
            else
                SeFileSizeMax.Value = SeFileSizeMin.Value;
            _updating = false;

            void Update(CheckBox checkBox, NumericUpDown spinEdit)
            {
                spinEdit.Enabled = checkBox.Checked;
                spinEdit.Increment = Math.Max(1, Math.Truncate(spinEdit.Value / 100));
            }
        }

        private bool DatesOK(DateTimePicker min, DateTimePicker max) => !min.Checked || !max.Checked || min.Value <= max.Value;
        private bool FileSizesOK() => !CbFileSizeMin.Checked || !CbFileSizeMax.Checked || SeFileSizeMin.Value <= SeFileSizeMax.Value;

        private void Process(bool loading)
        {
            ProcessDtpCheckBox(DtpCreatedMin, FileFlags.CreatedMin);
            ProcessDtpCheckBox(DtpCreatedMax, FileFlags.CreatedMax);
            ProcessCheckBox(CbCreatedUtc, FileFlags.CreatedUtc);
            ProcessDtpCheckBox(DtpModifiedMin, FileFlags.ModifiedMin);
            ProcessDtpCheckBox(DtpModifiedMax, FileFlags.ModifiedMax);
            ProcessCheckBox(CbModifiedUtc, FileFlags.ModifiedUtc);
            ProcessDtpCheckBox(DtpAccessedMin, FileFlags.AccessedMin);
            ProcessDtpCheckBox(DtpAccessedMax, FileFlags.AccessedMax);
            ProcessCheckBox(CbAccessedUtc, FileFlags.AccessedUtc);
            ProcessCheckBox(CbFileSizeMin, FileFlags.FileSizeMin);
            ProcessCheckBox(CbFileSizeMax, FileFlags.FileSizeMax);

            if (loading)
            {
                DtpCreatedMin.Value = FileOptions.CreatedMin;
                DtpCreatedMax.Value = FileOptions.CreatedMax;
                DtpModifiedMin.Value = FileOptions.ModifiedMin;
                DtpModifiedMax.Value = FileOptions.ModifiedMax;
                DtpAccessedMin.Value = FileOptions.AccessedMin;
                DtpAccessedMax.Value = FileOptions.AccessedMax;
                SeFileSizeMin.Value = FileOptions.FileSizeMin;
                SeFileSizeMax.Value = FileOptions.FileSizeMax;
            }
            else
            {
                FileOptions.CreatedMin = DtpCreatedMin.Value;
                FileOptions.CreatedMax = DtpCreatedMax.Value;
                FileOptions.ModifiedMin = DtpModifiedMin.Value;
                FileOptions.ModifiedMax = DtpModifiedMax.Value;
                FileOptions.AccessedMin = DtpAccessedMin.Value;
                FileOptions.AccessedMax = DtpAccessedMax.Value;
                FileOptions.FileSizeMin = (ulong)SeFileSizeMin.Value;
                FileOptions.FileSizeMax = (ulong)SeFileSizeMax.Value;
            }

            ProcessComboBox(CbReadOnly, FileFlags.ReadOnlyTrue, FileFlags.ReadOnlyFalse);
            ProcessComboBox(CbHidden, FileFlags.HiddenTrue, FileFlags.HiddenFalse);
            ProcessComboBox(CbSystem, FileFlags.SystemTrue, FileFlags.SystemFalse);
            ProcessComboBox(CbArchive, FileFlags.ArchiveTrue, FileFlags.ArchiveFalse);
            ProcessComboBox(CbCompressed, FileFlags.CompressedTrue, FileFlags.CompressedFalse);
            ProcessComboBox(CbEncrypted, FileFlags.EncryptedTrue, FileFlags.EncryptedFalse);

            if (!loading)
            {
                var filterTerm = FileOptions.GetFilter();
                MainModel.FileOptionsFilter = filterTerm.Filter;
            }

            void ProcessCheckBox(CheckBox control, FileFlags flag)
            {
                if (loading)
                    control.Checked = GetFlag(flag);
                else
                    SetFlag(control.Checked ? flag : 0);
            }

            void ProcessDtpCheckBox(DateTimePicker control, FileFlags flag)
            {
                if (loading)
                    control.Checked = GetFlag(flag);
                else
                    SetFlag(control.Checked ? flag : 0);
            }

            void ProcessComboBox(ComboBox control, FileFlags yes, FileFlags no)
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

            bool GetFlag(FileFlags flag) => (FileOptions.Flags & flag) != 0;
            void SetFlag(FileFlags flag) => FileOptions.Flags |= flag;
        }

        #endregion
    }
}
