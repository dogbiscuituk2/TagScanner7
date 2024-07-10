namespace TagScanner.Controllers
{
    using System;
    using System.Text;
    using System.Windows.Forms;
    using Controls;
    using Models;
    using Terms;

    public class FileFilterController : Controller, IGetErrors, IAutocorrect
    {
        #region Constructor

        public FileFilterController(Controller parent) : base(parent) { }

        #endregion

        #region Public Properties

        public ErrorProvider ErrorProvider { get; private set; } = new ErrorProvider();

        public FileOptions FileOptions
        {
            get => Process();
            private set => Process(value);
        }

        public Term FilterTerm => FileOptions.GetFilter();

        public bool UseAutocorrect
        {
            get => CbUseAutocorrect.Checked;
            set => CbUseAutocorrect.Checked = value;
        }

        #endregion

        #region Public Methods

        public void AfterExecute() => MainModel.FileOptionsFilter = FilterTerm.Filter;
        public void BeforeExecute() => FileOptions = new FileOptions();

        public void DoAutocorrect()
        {
            UseAutocorrect = true;
            AutocorrectDates();
            AutocorrectFileSize();
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

        public void SetView(FileFilterControl view)
        {
            _view = view;

            CbCreatedUtc = _view.cbCreatedUtc;
            CbModifiedUtc = _view.cbModifiedUtc;
            CbAccessedUtc = _view.cbAccessedUtc;
            CbFileSizeMin = _view.cbFileSizeMin;
            CbFileSizeMax = _view.cbFileSizeMax;
            CbUseAutocorrect = _view.cbUseAutocorrect;

            CbReadOnly = _view.cbAttrReadOnly;
            CbHidden = _view.cbAttrHidden;
            CbSystem = _view.cbAttrSystem;
            CbArchive = _view.cbAttrArchive;
            CbCompressed = _view.cbAttrCompressed;
            CbEncrypted = _view.cbAttrEncrypted;

            DtpCreatedMin = _view.dtpCreatedMin;
            DtpCreatedMax = _view.dtpCreatedMax;
            DtpModifiedMin = _view.dtpModifiedMin;
            DtpModifiedMax = _view.dtpModifiedMax;
            DtpAccessedMin = _view.dtpAccessedMin;
            DtpAccessedMax = _view.dtpAccessedMax;

            SeFileSizeMin = _view.seFileSizeMin;
            SeFileSizeMax = _view.seFileSizeMax;

            DtpCreatedMin.Value = DtpModifiedMin.Value = DtpAccessedMin.Value =
                DtpCreatedMax.Value = DtpModifiedMax.Value = DtpAccessedMax.Value = DateTime.Today;

            SeFileSizeMin.Maximum = SeFileSizeMax.Maximum = ulong.MaxValue;

            DtpCreatedMin.ValueChanged += (sender, e) => AdjustCreatedDate(lower: false);
            DtpCreatedMax.ValueChanged += (sender, e) => AdjustCreatedDate(lower: true);
            DtpModifiedMin.ValueChanged += (sender, e) => AdjustModifiedDate(lower: false);
            DtpModifiedMax.ValueChanged += (sender, e) => AdjustModifiedDate(lower: true);
            DtpAccessedMin.ValueChanged += (sender, e) => AdjustAccessedDate(lower: false);
            DtpAccessedMax.ValueChanged += (sender, e) => AdjustAccessedDate(lower: true);
            CbFileSizeMin.CheckedChanged += (sender, e) => AdjustFileSize(lower: false);
            CbFileSizeMax.CheckedChanged += (sender, e) => AdjustFileSize(lower: true);
            SeFileSizeMin.ValueChanged += (sender, e) => AdjustFileSize(lower: false);
            SeFileSizeMax.ValueChanged += (sender, e) => AdjustFileSize(lower: true);

            new ErrorController(this,
                DtpCreatedMin, DtpCreatedMax,
                DtpModifiedMin, DtpModifiedMax,
                DtpAccessedMin, DtpAccessedMax,
                SeFileSizeMin, SeFileSizeMax);
        }

        public void ShowFilter()
        {
            var filter = FilterTerm.ToString().Replace(" && ", "\n");
            if (string.IsNullOrWhiteSpace(filter))
                filter = "There are no filter conditions selected.";
            MessageBox.Show(
            Owner,
            filter,
            "Filter Conditions",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }

        #endregion

        #region Private Fields

        //private readonly FileOptions _fileOptions = new FileOptions();
        private bool _updating;
        private FileFilterControl _view;

        private CheckBox
            CbCreatedUtc, CbModifiedUtc, CbAccessedUtc,
            CbFileSizeMin, CbFileSizeMax,
            CbUseAutocorrect;

        private ComboBox
            CbReadOnly, CbHidden, CbSystem, CbArchive, CbCompressed, CbEncrypted;

        private DateTimePicker
            DtpCreatedMin, DtpCreatedMax,
            DtpModifiedMin, DtpModifiedMax,
            DtpAccessedMin, DtpAccessedMax;

        private NumericUpDown
            SeFileSizeMin, SeFileSizeMax;

        #endregion

        #region Private Methods

        private void AdjustCreatedDate(bool lower) => AdjustDate(DtpCreatedMin, DtpCreatedMax, lower);
        private void AdjustModifiedDate(bool lower) => AdjustDate(DtpModifiedMin, DtpModifiedMax, lower);
        private void AdjustAccessedDate(bool lower) => AdjustDate(DtpAccessedMin, DtpAccessedMax, lower);

        private void AdjustDate(DateTimePicker min, DateTimePicker max, bool lower)
        {
            if (!UseAutocorrect || DatesOK(min, max))
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
            if (!UseAutocorrect || FileSizesOK())
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

        private void AutocorrectDates()
        {
            AutocorrectDate(DtpCreatedMin, DtpCreatedMax);
            AutocorrectDate(DtpModifiedMin, DtpModifiedMax);
            AutocorrectDate(DtpAccessedMin, DtpAccessedMax);
        }

        private void AutocorrectDate(DateTimePicker min, DateTimePicker max)
        {
            if (DatesOK(min, max))
                return;
            _updating = true;
            (max.Value, min.Value) = (min.Value, max.Value);
            _updating = false;
        }

        private void AutocorrectFileSize()
        {
            if (FileSizesOK())
                return;
            _updating = true;
            (SeFileSizeMin.Value, SeFileSizeMax.Value) = (SeFileSizeMax.Value, SeFileSizeMin.Value);
            _updating = false;
        }

        private bool DatesOK(DateTimePicker min, DateTimePicker max) => !min.Checked || !max.Checked || min.Value <= max.Value;
        private bool FileSizesOK() => !CbFileSizeMin.Checked || !CbFileSizeMax.Checked || SeFileSizeMin.Value <= SeFileSizeMax.Value;

        private FileOptions Process(FileOptions fileOptions = null)
        {
            var saving = fileOptions == null;
            if (saving)
                fileOptions = new FileOptions();

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

            if (saving)
            {
                fileOptions.CreatedMin = DtpCreatedMin.Value;
                fileOptions.CreatedMax = DtpCreatedMax.Value;
                fileOptions.ModifiedMin = DtpModifiedMin.Value;
                fileOptions.ModifiedMax = DtpModifiedMax.Value;
                fileOptions.AccessedMin = DtpAccessedMin.Value;
                fileOptions.AccessedMax = DtpAccessedMax.Value;
                fileOptions.FileSizeMin = (ulong)SeFileSizeMin.Value;
                fileOptions.FileSizeMax = (ulong)SeFileSizeMax.Value;
            }
            else
            {
                DtpCreatedMin.Value = fileOptions.CreatedMin;
                DtpCreatedMax.Value = fileOptions.CreatedMax;
                DtpModifiedMin.Value = fileOptions.ModifiedMin;
                DtpModifiedMax.Value = fileOptions.ModifiedMax;
                DtpAccessedMin.Value = fileOptions.AccessedMin;
                DtpAccessedMax.Value = fileOptions.AccessedMax;
                SeFileSizeMin.Value = fileOptions.FileSizeMin;
                SeFileSizeMax.Value = fileOptions.FileSizeMax;
            }

            ProcessComboBox(CbReadOnly, FileFlags.ReadOnlyTrue, FileFlags.ReadOnlyFalse);
            ProcessComboBox(CbHidden, FileFlags.HiddenTrue, FileFlags.HiddenFalse);
            ProcessComboBox(CbSystem, FileFlags.SystemTrue, FileFlags.SystemFalse);
            ProcessComboBox(CbArchive, FileFlags.ArchiveTrue, FileFlags.ArchiveFalse);
            ProcessComboBox(CbCompressed, FileFlags.CompressedTrue, FileFlags.CompressedFalse);
            ProcessComboBox(CbEncrypted, FileFlags.EncryptedTrue, FileFlags.EncryptedFalse);

            return fileOptions;

            void ProcessCheckBox(CheckBox control, FileFlags flag)
            {
                if (saving)
                    SetFlag(control.Checked ? flag : 0);
                else
                    control.Checked = GetFlag(flag);
            }

            void ProcessDtpCheckBox(DateTimePicker control, FileFlags flag)
            {
                if (saving)
                    SetFlag(control.Checked ? flag : 0);
                else
                    control.Checked = GetFlag(flag);
            }

            void ProcessComboBox(ComboBox control, FileFlags yes, FileFlags no)
            {
                if (saving)
                    switch (control.SelectedIndex)
                    {
                        case 1: SetFlag(yes); break;
                        case 2: SetFlag(no); break;
                    }
                else
                    control.SelectedIndex = GetFlag(yes) ? 1 : GetFlag(no) ? 2 : 0;
            }

            bool GetFlag(FileFlags flag) => (fileOptions.Flags & flag) != 0;
            void SetFlag(FileFlags flag) => fileOptions.Flags |= flag;
        }

        #endregion
    }
}
