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

        public bool UseTimes
        {
            get => _useTimes;
            set
            {
                if (_useTimes != value)
                {
                    _useTimes = value;
                    var dateTimePickers = new[] { DtpCreatedMin, DtpCreatedMax, DtpModifiedMin, DtpModifiedMax, DtpAccessedMin, DtpAccessedMax };
                    var middleColumn = new Control[] { _view.lblFrom, DtpCreatedMax, DtpModifiedMax, DtpAccessedMax };
                    var rightColumn = new Control[] { _view.lblUpTo, _view.lblUtc, CbCreatedUtc, CbModifiedUtc, CbAccessedUtc };
                    var delta = UseTimes ? 52 : -52;
                    var customFormat = UseTimes ? _dateTimeFormat : _dateFormat;
                    AdjustControls(dateTimePickers, p => { ((DateTimePicker)p).CustomFormat = customFormat; p.Width += delta; });
                    AdjustControls(middleColumn, p => { p.Left += delta; });
                    delta *= 2;
                    AdjustControls(rightColumn, p => { p.Left += delta; });
                    _view.MainPanel.Width += delta;
                    OnUseTimesChanged();
                    UpdateUI();
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

        #region Public Events

        public event EventHandler UseTimesChanged;

        #endregion

        #region Public Methods

        public void AfterExecute() => MainModel.FileOptionsFilter = GetFilterTerm().Filter;

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

        public string GetFilterString()
        {
            ReadFileOptionsFromControls().GetFilter(UseTimes, out string filterString);
            return filterString;
        }

        public Term GetFilterTerm() => ReadFileOptionsFromControls().GetFilter(UseTimes, out _);

        public void SetView(FileFilterControl view)
        {
            _view = view;

            CbUseTimes = _view.cbUseTimes;
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

            CbUseTimes.CheckedChanged += (sender, e) => UseTimes ^= true;

            DtpCreatedMin.ValueChanged += (sender, e) => DateChanged(FileFlags.CreatedMin);
            DtpCreatedMax.ValueChanged += (sender, e) => DateChanged(FileFlags.CreatedMax);
            CbCreatedUtc.CheckedChanged += (sender, e) => UpdateUI(); // SetFlag(FileFlags.CreatedUtc, CbCreatedUtc.Checked);

            DtpModifiedMin.ValueChanged += (sender, e) => DateChanged(FileFlags.ModifiedMin);
            DtpModifiedMax.ValueChanged += (sender, e) => DateChanged(FileFlags.ModifiedMax);
            CbModifiedUtc.CheckedChanged += (sender, e) => UpdateUI(); // SetFlag(FileFlags.ModifiedUtc, CbModifiedUtc.Checked);

            DtpAccessedMin.ValueChanged += (sender, e) => DateChanged(FileFlags.AccessedMin);
            DtpAccessedMax.ValueChanged += (sender, e) => DateChanged(FileFlags.AccessedMax);
            CbAccessedUtc.CheckedChanged += (sender, e) => UpdateUI(); // SetFlag(FileFlags.AccessedUtc, CbAccessedUtc.Checked);

            SeFileSizeMin.ValueChanged += (sender, e) => FileSizeChanged(FileFlags.FileSizeMin);
            SeFileSizeMax.ValueChanged += (sender, e) => FileSizeChanged(FileFlags.FileSizeMax);
            CbFileSizeUnit.SelectedValueChanged += (sender, e) => AdjustFileSizeUnit();

            CbReadOnly.SelectedIndexChanged += (sender, e) => UpdateUI();
            CbHidden.SelectedIndexChanged += (sender, e) => UpdateUI();
            CbSystem.SelectedIndexChanged += (sender, e) => UpdateUI();
            CbArchive.SelectedIndexChanged += (sender, e) => UpdateUI();
            CbCompressed.SelectedIndexChanged += (sender, e) => UpdateUI();
            CbEncrypted.SelectedIndexChanged += (sender, e) => UpdateUI();

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

        #endregion

        #region Protected Methods

        protected virtual void OnUseTimesChanged() => UseTimesChanged?.Invoke(this, EventArgs.Empty);

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
            CbUseTimes,
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
            set
            {
                if (Flags == value)
                    return;
                _fileOptions.Flags = value;
                UpdateUI();
            }
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

        private void FileSizeChanged(FileFlags flag)
        {
            FileSizeChanged();
            UpdateUI();

            void FileSizeChanged()
            {
                NumericUpDown min, max;
                (min, max) = (SeFileSizeMin, SeFileSizeMax);
                var minChanged = (flag & FileFlags.Min) != 0;
                var control = minChanged ? min : max;
                if (!UseAutocorrect || FileSizesOK() || _updating)
                    return;
                _updating = true;
                if (minChanged)
                    max.Value = min.Value;
                else
                    min.Value = max.Value;
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
            {
                _updating = true;
                (SeFileSizeMin.Value, SeFileSizeMax.Value) = (SeFileSizeMax.Value, SeFileSizeMin.Value);
                _updating = false;
            }
            UpdateUI();
        }

        private bool DatesOK(DateTimePicker min, DateTimePicker max) => !min.Checked || !max.Checked || min.Value <= max.Value;
        private bool FileSizesOK() => SeFileSizeMin.Value == 0 || SeFileSizeMax.Value == 0 || SeFileSizeMin.Value <= SeFileSizeMax.Value;

        private FileOptions ReadFileOptionsFromControls()
        {
            var fileOptions = new FileOptions();
            FileFlags flags = 0;

            ReadCheckBox(CbUseTimes, FileFlags.UseTimes);
            ReadCheckBoxDtp(DtpCreatedMin, FileFlags.CreatedMin);
            ReadCheckBoxDtp(DtpCreatedMax, FileFlags.CreatedMax);
            ReadCheckBox(CbCreatedUtc, FileFlags.CreatedUtc);
            ReadCheckBoxDtp(DtpModifiedMin, FileFlags.ModifiedMin);
            ReadCheckBoxDtp(DtpModifiedMax, FileFlags.ModifiedMax);
            ReadCheckBox(CbModifiedUtc, FileFlags.ModifiedUtc);
            ReadCheckBoxDtp(DtpAccessedMin, FileFlags.AccessedMin);
            ReadCheckBoxDtp(DtpAccessedMax, FileFlags.AccessedMax);
            ReadCheckBox(CbAccessedUtc, FileFlags.AccessedUtc);

            fileOptions.CreatedMin = DtpCreatedMin.Value;
            fileOptions.CreatedMax = DtpCreatedMax.Value;
            fileOptions.ModifiedMin = DtpModifiedMin.Value;
            fileOptions.ModifiedMax = DtpModifiedMax.Value;
            fileOptions.AccessedMin = DtpAccessedMin.Value;
            fileOptions.AccessedMax = DtpAccessedMax.Value;

            fileOptions.FileSizeMin = ReadSpinEdit(SeFileSizeMin, FileFlags.FileSizeMin);
            fileOptions.FileSizeMax = ReadSpinEdit(SeFileSizeMax, FileFlags.FileSizeMax);
            fileOptions.FileSizeUnit = FileSizeUnit;

            ReadComboBox(CbReadOnly, FileFlags.ReadOnlyTrue, FileFlags.ReadOnlyFalse);
            ReadComboBox(CbHidden, FileFlags.HiddenTrue, FileFlags.HiddenFalse);
            ReadComboBox(CbSystem, FileFlags.SystemTrue, FileFlags.SystemFalse);
            ReadComboBox(CbArchive, FileFlags.ArchiveTrue, FileFlags.ArchiveFalse);
            ReadComboBox(CbCompressed, FileFlags.CompressedTrue, FileFlags.CompressedFalse);
            ReadComboBox(CbEncrypted, FileFlags.EncryptedTrue, FileFlags.EncryptedFalse);

            fileOptions.Flags = flags;
            return fileOptions;

            void ReadCheckBox(CheckBox control, FileFlags flag) => SetFlag(control.Checked ? flag : 0);
            void ReadCheckBoxDtp(DateTimePicker control, FileFlags flag) => SetFlag(control.Checked ? flag : 0);

            void ReadComboBox(ComboBox control, FileFlags yes, FileFlags no)
            {
                switch (control.SelectedIndex)
                {
                    case 1: SetFlags(yes | no, yes); break;
                    case 2: SetFlags(yes | no, no); break;
                }
            }

            decimal ReadSpinEdit(NumericUpDown control, FileFlags flag)
            {
                var value = control.Value;
                SetFlag(flag, value != 0);
                return value;
            }

            void SetFlag(FileFlags mask, bool state = true) => flags = state ? flags | mask : flags & ~mask;
            void SetFlags(FileFlags mask, FileFlags state) => flags = flags & ~mask | state;
        }

        private void WriteFileOptionsToControls()
        {
            WriteCheckBox(CbUseTimes, FileFlags.UseTimes);
            WriteCheckBoxDtp(DtpCreatedMin, FileFlags.CreatedMin);
            WriteCheckBoxDtp(DtpCreatedMax, FileFlags.CreatedMax);
            WriteCheckBox(CbCreatedUtc, FileFlags.CreatedUtc);
            WriteCheckBoxDtp(DtpModifiedMin, FileFlags.ModifiedMin);
            WriteCheckBoxDtp(DtpModifiedMax, FileFlags.ModifiedMax);
            WriteCheckBox(CbModifiedUtc, FileFlags.ModifiedUtc);
            WriteCheckBoxDtp(DtpAccessedMin, FileFlags.AccessedMin);
            WriteCheckBoxDtp(DtpAccessedMax, FileFlags.AccessedMax);
            WriteCheckBox(CbAccessedUtc, FileFlags.AccessedUtc);

            DtpCreatedMin.Value = _fileOptions.CreatedMin;
            DtpCreatedMax.Value = _fileOptions.CreatedMax;
            DtpModifiedMin.Value = _fileOptions.ModifiedMin;
            DtpModifiedMax.Value = _fileOptions.ModifiedMax;
            DtpAccessedMin.Value = _fileOptions.AccessedMin;
            DtpAccessedMax.Value = _fileOptions.AccessedMax;
            SeFileSizeMin.Value = _fileOptions.FileSizeMin;
            SeFileSizeMax.Value = _fileOptions.FileSizeMax;
            FileSizeUnit = _fileOptions.FileSizeUnit;

            SeFileSizeMin.Value = _fileOptions.FileSizeMin;
            SeFileSizeMax.Value = _fileOptions.FileSizeMax;

            WriteComboBox(CbReadOnly, FileFlags.ReadOnlyTrue, FileFlags.ReadOnlyFalse);
            WriteComboBox(CbHidden, FileFlags.HiddenTrue, FileFlags.HiddenFalse);
            WriteComboBox(CbSystem, FileFlags.SystemTrue, FileFlags.SystemFalse);
            WriteComboBox(CbArchive, FileFlags.ArchiveTrue, FileFlags.ArchiveFalse);
            WriteComboBox(CbCompressed, FileFlags.CompressedTrue, FileFlags.CompressedFalse);
            WriteComboBox(CbEncrypted, FileFlags.EncryptedTrue, FileFlags.EncryptedFalse);

            UpdateUI();

            bool GetFlag(FileFlags flag) => (Flags & flag) != 0;

            void WriteCheckBox(CheckBox control, FileFlags flag) => control.Checked = GetFlag(flag);
            void WriteCheckBoxDtp(DateTimePicker control, FileFlags flag) => control.Checked = GetFlag(flag);
            void WriteComboBox(ComboBox control, FileFlags yes, FileFlags no) => control.SelectedIndex = GetFlag(yes) ? 1 : GetFlag(no) ? 2 : 0;
        }

        private void UpdateUI() => _view.edConditions.Text = GetFilterString();

        #endregion
    }
}
