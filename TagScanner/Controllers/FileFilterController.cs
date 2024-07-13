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
                var middleColumn = new Control[] { _view.lblUpTo, DtpCreatedMax, DtpModifiedMax, DtpAccessedMax };
                var rightColumn = new Control[] { _view.lblUtc, CbCreatedUtc, CbModifiedUtc, CbAccessedUtc, CbUseAutocorrect };

                if (_useTimes != value)
                {
                    _useTimes = value;
                    var delta = UseTimes ? 52 : -52;
                    var customFormat = UseTimes ? _dateTimeFormat : _dateFormat;
                    AdjustControls(dateTimePickers, p => { ((DateTimePicker)p).CustomFormat = customFormat; p.Width += delta; });
                    AdjustControls(middleColumn, p => { p.Left += delta; });
                    delta *= 2;
                    AdjustControls(rightColumn, p => { p.Left += delta; });
                    _view.MainPanel.Width += delta;
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
                if (SeFileSizeMin.Value > SeFileSizeMax.Value && SeFileSizeMax.Value > 0)
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
            CbUseAutocorrect = _view.cbUseAutocorrect;

            CbFileSizeUnit = _view.cbUnit;

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

            InitDates(DateTime.Today, DtpCreatedMin, DtpModifiedMin, DtpAccessedMin);
            InitDates(DateTime.Today.AddDays(1).AddTicks(-1), DtpCreatedMax, DtpModifiedMax, DtpAccessedMax);

            System.Diagnostics.Debug.WriteLine(DtpCreatedMin.Value);

            SeFileSizeMin.Maximum = SeFileSizeMax.Maximum = uint.MaxValue;
            FileSizeUnit = 0;

            DtpCreatedMin.ValueChanged += (sender, e) => DateChanged(FileFlags.CreatedMin);
            DtpCreatedMax.ValueChanged += (sender, e) => DateChanged(FileFlags.CreatedMax);
            CbCreatedUtc.CheckedChanged += (sender, e) => SetFlag(FileFlags.CreatedUtc, CbCreatedUtc.Checked);

            DtpModifiedMin.ValueChanged += (sender, e) => DateChanged(FileFlags.ModifiedMin);
            DtpModifiedMax.ValueChanged += (sender, e) => DateChanged(FileFlags.ModifiedMax);
            CbModifiedUtc.CheckedChanged += (sender, e) => SetFlag(FileFlags.ModifiedUtc, CbModifiedUtc.Checked);

            DtpAccessedMin.ValueChanged += (sender, e) => DateChanged(FileFlags.AccessedMin);
            DtpAccessedMax.ValueChanged += (sender, e) => DateChanged(FileFlags.AccessedMax);
            CbAccessedUtc.CheckedChanged += (sender, e) => SetFlag(FileFlags.AccessedUtc, CbAccessedUtc.Checked);

            SeFileSizeMin.ValueChanged += (sender, e) => AdjustFileSize(FileFlags.FileSizeMin);
            SeFileSizeMax.ValueChanged += (sender, e) => AdjustFileSize(FileFlags.FileSizeMax);
            CbFileSizeUnit.SelectedValueChanged += (sender, e) => AdjustFileSizeUnit();

            new ErrorController(this,
                DtpCreatedMin, DtpCreatedMax,
                DtpModifiedMin, DtpModifiedMax,
                DtpAccessedMin, DtpAccessedMax,
                SeFileSizeMin, SeFileSizeMax);

            void InitDates(DateTime dateTime, params DateTimePicker[] controls)
            {
                foreach (var control in controls)
                {
                    control.Value = dateTime;
                    control.Checked = false;
                }
            }
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
            MessageBoxIcon.None);
        }

        #endregion

        #region Private Fields

        private const string
            _dateFormat = "yyyy-MM-dd",
            _timeFormat = "HH:mm:ss",
            _dateTimeFormat = _dateFormat + " " + _timeFormat;

        private FileOptions _fileOptions = new FileOptions();
        private bool _updating;
        private bool _useTimes = false;
        private FileFilterControl _view;

        private CheckBox
            CbCreatedUtc, CbModifiedUtc, CbAccessedUtc,
            CbUseAutocorrect;

        private ComboBox
            CbFileSizeUnit, CbReadOnly, CbHidden, CbSystem, CbArchive, CbCompressed, CbEncrypted;

        private DateTimePicker
            DtpCreatedMin, DtpCreatedMax,
            DtpModifiedMin, DtpModifiedMax,
            DtpAccessedMin, DtpAccessedMax;

        private NumericUpDown
            SeFileSizeMin, SeFileSizeMax;

        #endregion

        #region Private Properties

        private int FileSizeUnit
        {
            get => CbFileSizeUnit.SelectedIndex;
            set => CbFileSizeUnit.SelectedIndex = value;
        }

        private FileFlags Flags
        {
            get => _fileOptions.Flags;
            set => _fileOptions.Flags = value;
        }

        #endregion

        #region Private Methods

        private void DateChanged(FileFlags flag)
        {
            DateChanged();
            UpdateUI();

            void DateChanged()
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
                var minChanged = (flag & FileFlags.Min) != 0;
                var control = minChanged ? min : max;
                SetFlag(flag, control.Checked);
                if (!UseAutocorrect || DatesOK(min, max) || _updating)
                    return;
                _updating = true;
                if (minChanged)
                    max.Value = min.Value;
                else
                    min.Value = max.Value;
                _updating = false;
            }
        }

        private void AdjustFileSize(FileFlags flag)
        {
            AdjustFileSize();
            UpdateUI();

            void AdjustFileSize()
            {
                if (!UseAutocorrect || FileSizesOK() || _updating)
                    return;
                _updating = true;
                if ((flag & FileFlags.Min) != 0)
                    SeFileSizeMin.Value = SeFileSizeMax.Value;
                else
                    SeFileSizeMax.Value = SeFileSizeMin.Value;
                _updating = false;
            }
        }

        private void AdjustFileSizeUnit()
        {
            SeFileSizeMin.DecimalPlaces = SeFileSizeMax.DecimalPlaces = FileSizeUnit > 0 ? 2 : 0;
            UpdateUI();
        }

        private void AutocorrectDates()
        {
            AutocorrectDate(DtpCreatedMin, DtpCreatedMax);
            AutocorrectDate(DtpModifiedMin, DtpModifiedMax);
            AutocorrectDate(DtpAccessedMin, DtpAccessedMax);
            UpdateUI();

            void AutocorrectDate(DateTimePicker min, DateTimePicker max)
            {
                if (DatesOK(min, max))
                    return;
                _updating = true;
                (max.Value, min.Value) = (min.Value, max.Value);
                _updating = false;
            }
        }

        private void AutocorrectFileSize()
        {
            if (FileSizesOK())
                return;
            _updating = true;
            (SeFileSizeMin.Value, SeFileSizeMax.Value) = (SeFileSizeMax.Value, SeFileSizeMin.Value);
            _updating = false;
            UpdateUI();
        }

        private bool DatesOK(DateTimePicker min, DateTimePicker max) => !min.Checked || !max.Checked || min.Value <= max.Value;
        private bool FileSizesOK() => SeFileSizeMin.Value == 0 || SeFileSizeMax.Value == 0 || SeFileSizeMin.Value <= SeFileSizeMax.Value;

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

            if (read)
            {
                _fileOptions.CreatedMin = DtpCreatedMin.Value;
                _fileOptions.CreatedMax = DtpCreatedMax.Value;
                _fileOptions.ModifiedMin = DtpModifiedMin.Value;
                _fileOptions.ModifiedMax = DtpModifiedMax.Value;
                _fileOptions.AccessedMin = DtpAccessedMin.Value;
                _fileOptions.AccessedMax = DtpAccessedMax.Value;
                _fileOptions.FileSizeMin = (int)SeFileSizeMin.Value;
                _fileOptions.FileSizeMax = (int)SeFileSizeMax.Value;
                _fileOptions.FileSizeUnit = FileSizeUnit;
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
                FileSizeUnit = _fileOptions.FileSizeUnit;
            }

            ProcessComboBox(CbReadOnly, FileFlags.ReadOnlyTrue, FileFlags.ReadOnlyFalse);
            ProcessComboBox(CbHidden, FileFlags.HiddenTrue, FileFlags.HiddenFalse);
            ProcessComboBox(CbSystem, FileFlags.SystemTrue, FileFlags.SystemFalse);
            ProcessComboBox(CbArchive, FileFlags.ArchiveTrue, FileFlags.ArchiveFalse);
            ProcessComboBox(CbCompressed, FileFlags.CompressedTrue, FileFlags.CompressedFalse);
            ProcessComboBox(CbEncrypted, FileFlags.EncryptedTrue, FileFlags.EncryptedFalse);

            if (!read)
                UpdateUI();

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
            //UpdateUI();
        }

        private void UpdateUI()
        {
            _view.edFilter.Text = FilterString;
        }

        #endregion
    }
}
