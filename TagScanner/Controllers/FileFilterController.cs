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
            get => GetFileOptions();
            private set => SetFileOptions(value);
        }

        public string FilterString
        {
            get
            {
                FileOptions.GetFilter(UseTimes, out string filterString);
                return filterString;
            }
        }

        public Term FilterTerm => FileOptions.GetFilter(UseTimes, out _);

        public bool UseTimes
        {
            get => _useTimes;
            set
            {
                var dateTimePickers = new[] { DtpCreatedMin, DtpCreatedMax, DtpModifiedMin, DtpModifiedMax, DtpAccessedMin, DtpAccessedMax };
                var middleColumn = new Control[] { _view.lblUpTo, DtpCreatedMax, DtpModifiedMax, DtpAccessedMax, CbFileSizeMax, SeFileSizeMax };
                var rightColumn = new Control[] { _view.lblUtc, CbCreatedUtc, CbModifiedUtc, CbAccessedUtc, CbUseAutocorrect };
                var spinEdits = new[] { SeFileSizeMin, SeFileSizeMax };

                if (_useTimes != value)
                {
                    _useTimes = value;
                    var delta = UseTimes ? 52 : -52;
                    var customFormat = UseTimes ? _dateTimeFormat : _dateFormat;
                    AdjustControls(dateTimePickers, p => { ((DateTimePicker)p).CustomFormat = customFormat; p.Width += delta; });
                    AdjustControls(spinEdits, p => { p.Width += delta; });
                    AdjustControls(middleColumn, p => { p.Left += delta; });
                    AdjustControls(rightColumn, p => { p.Left += 2 * delta; });
                    _view.MainPanel.Width += 2 * delta;
                }

                void AdjustControls(Control[] controls, Action<Control> action)
                {
                    foreach (var control in controls)
                        action(control);
                }
            }
        }

        public bool UseAutocorrect
        {
            get => CbUseAutocorrect.Checked;
            set => CbUseAutocorrect.Checked = value;
        }

        public int ViewWidth => _view.MainPanel.Width;

        #endregion

        #region Public Methods

        public void AfterExecute()
        {
            MainModel.FileOptionsFilter = FilterTerm.Filter;
        }

        public void BeforeExecute() { }

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

            DtpCreatedMin.Value = DtpModifiedMin.Value = DtpAccessedMin.Value = DateTime.Today;
            DtpCreatedMax.Value = DtpModifiedMax.Value = DtpAccessedMax.Value = DateTime.Today.AddDays(1).AddTicks(-1);

            System.Diagnostics.Debug.WriteLine(DtpCreatedMin.Value);

            SeFileSizeMin.Maximum = SeFileSizeMax.Maximum = ulong.MaxValue;

            DtpCreatedMin.ValueChanged += (sender, e) => DateChanged(FileFlags.CreatedMin);
            DtpCreatedMax.ValueChanged += (sender, e) => DateChanged(FileFlags.CreatedMax);
            CbCreatedUtc.CheckedChanged += (sender, e) => SetFlag(FileFlags.CreatedUtc, CbCreatedUtc.Checked);
            DtpModifiedMin.ValueChanged += (sender, e) => DateChanged(FileFlags.ModifiedMin);
            DtpModifiedMax.ValueChanged += (sender, e) => DateChanged(FileFlags.ModifiedMax);
            CbModifiedUtc.CheckedChanged += (sender, e) => SetFlag(FileFlags.ModifiedUtc, CbModifiedUtc.Checked);
            DtpAccessedMin.ValueChanged += (sender, e) => DateChanged(FileFlags.AccessedMin);
            DtpAccessedMax.ValueChanged += (sender, e) => DateChanged(FileFlags.AccessedMax);
            CbAccessedUtc.CheckedChanged += (sender, e) => SetFlag(FileFlags.AccessedUtc, CbAccessedUtc.Checked);
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
            var filter = FilterString;
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

        private const string
            _dateFormat = "yyyy-MM-dd",
            _timeFormat = "HH:mm:ss",
            _dateTimeFormat = _dateFormat + " " + _timeFormat;

        private FileOptions _fileOptions = new FileOptions();
        private bool _updating;
        private bool _useTimes = true;
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

        private void DateChanged(FileFlags flag)
        {
            DateTimePicker min, max;
            if ((flag & FileFlags.Created) != 0)
                (min, max) = (DtpCreatedMin, DtpCreatedMax);
            else if ((flag & FileFlags.Modified) != 0)
                (min, max) = (DtpModifiedMin, DtpModifiedMax);
            else if ((flag & FileFlags.Accessed) != 0)
                (min, max) = (DtpAccessedMin, DtpAccessedMax);
            else
                return;
            var lower = (flag & FileFlags.Min) != 0;
            var control = lower ? min : max;
            SetFlag(flag, control.Checked);
            if (!UseAutocorrect || DatesOK(min, max) || _updating)
                return;
            _updating = true;
            if (lower)
                max.Value = min.Value;
            else
                min.Value = max.Value;
            _updating = false;
        }

        private void AdjustFileSize(bool lower)
        {
            Update(CbFileSizeMin, SeFileSizeMin);
            Update(CbFileSizeMax, SeFileSizeMax);
            if (!UseAutocorrect || FileSizesOK() || _updating)
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

        private FileOptions GetFileOptions()
        {
            Process(read: true);
            return _fileOptions;
        }

        private void Process(bool read)
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

            if (read)
            {
                _fileOptions.CreatedMin = DtpCreatedMin.Value;
                _fileOptions.CreatedMax = DtpCreatedMax.Value;
                _fileOptions.ModifiedMin = DtpModifiedMin.Value;
                _fileOptions.ModifiedMax = DtpModifiedMax.Value;
                _fileOptions.AccessedMin = DtpAccessedMin.Value;
                _fileOptions.AccessedMax = DtpAccessedMax.Value;
                _fileOptions.FileSizeMin = (ulong)SeFileSizeMin.Value;
                _fileOptions.FileSizeMax = (ulong)SeFileSizeMax.Value;
            }
            else
            {
                DtpCreatedMin.Value = _fileOptions.CreatedMin;
                DtpCreatedMax.Value = _fileOptions.CreatedMax;
                DtpModifiedMin.Value = _fileOptions.ModifiedMin;
                DtpModifiedMax.Value = _fileOptions.ModifiedMax;
                DtpAccessedMin.Value = _fileOptions.AccessedMin;
                DtpAccessedMax.Value = _fileOptions.AccessedMax;
                SeFileSizeMin.Value = _fileOptions.FileSizeMin;
                SeFileSizeMax.Value = _fileOptions.FileSizeMax;
            }

            ProcessComboBox(CbReadOnly, FileFlags.ReadOnlyTrue, FileFlags.ReadOnlyFalse);
            ProcessComboBox(CbHidden, FileFlags.HiddenTrue, FileFlags.HiddenFalse);
            ProcessComboBox(CbSystem, FileFlags.SystemTrue, FileFlags.SystemFalse);
            ProcessComboBox(CbArchive, FileFlags.ArchiveTrue, FileFlags.ArchiveFalse);
            ProcessComboBox(CbCompressed, FileFlags.CompressedTrue, FileFlags.CompressedFalse);
            ProcessComboBox(CbEncrypted, FileFlags.EncryptedTrue, FileFlags.EncryptedFalse);

            void ProcessCheckBox(CheckBox control, FileFlags flag)
            {
                if (read)
                    SetFlag(control.Checked ? flag : 0);
                else
                    control.Checked = GetFlag(flag);
            }

            void ProcessDtpCheckBox(DateTimePicker control, FileFlags flag)
            {
                if (read)
                    SetFlag(control.Checked ? flag : 0);
                else
                    control.Checked = GetFlag(flag);
            }

            void ProcessComboBox(ComboBox control, FileFlags yes, FileFlags no)
            {
                if (read)
                    switch (control.SelectedIndex)
                    {
                        case 1: SetFlag(yes); break;
                        case 2: SetFlag(no); break;
                    }
                else
                    control.SelectedIndex = GetFlag(yes) ? 1 : GetFlag(no) ? 2 : 0;
            }
        }

        private bool GetFlag(FileFlags flag) => (Flags & flag) != 0;

        private FileFlags Flags
        {
            get => _fileOptions.Flags;
            set => _fileOptions.Flags = value;
        }

        private void SetFileOptions(FileOptions fileOptions)
        {
            _fileOptions = fileOptions ?? new FileOptions();
            Process(read: false);
        }

        private void SetFlag(FileFlags flag, bool state = true)
        {
            if (state)
                Flags |= flag;
            else
                Flags &= ~flag;
        }

        #endregion
    }
}
