namespace TagScanner.Controllers
{
    using System;
    using System.IO;
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

        public void AfterExecute() => MainModel.FileChecksFilter = GetFilterTerm().Filter;

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
            ReadFileChecksFromControls().GetFilter(UseTimes, out string filterString);
            return filterString;
        }

        public Term GetFilterTerm() => ReadFileChecksFromControls().GetFilter(UseTimes, out _);

        public void SetView(FileFilterControl view)
        {
            _view = view;

            CbUseTimes = _view.cbUseTimes;
            CbCreatedUtc = _view.cbCreatedUtc;
            CbModifiedUtc = _view.cbModifiedUtc;
            CbAccessedUtc = _view.cbAccessedUtc;
            CbUseAutocorrect = _view.cbUseAutocorrect;

            CbFileSizeUnit = _view.cbUnit;

            DtpCreatedMin = _view.dtpCreatedMin;
            DtpCreatedMax = _view.dtpCreatedMax;
            DtpModifiedMin = _view.dtpModifiedMin;
            DtpModifiedMax = _view.dtpModifiedMax;
            DtpAccessedMin = _view.dtpAccessedMin;
            DtpAccessedMax = _view.dtpAccessedMax;

            SeFileSizeMin = _view.seFileSizeMin;
            SeFileSizeMax = _view.seFileSizeMax;

            CbReadOnly = _view.cbReadOnly;
            CbHidden = _view.cbHidden;
            CbSystem = _view.cbSystem;
            CbArchive = _view.cbArchive;
            CbCompressed = _view.cbCompressed;
            CbEncrypted = _view.cbEncrypted;

            InitDates(DateTime.Today, DtpCreatedMin, DtpModifiedMin, DtpAccessedMin);
            InitDates(DateTime.Today.AddDays(1).AddTicks(-1), DtpCreatedMax, DtpModifiedMax, DtpAccessedMax);

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
            CbFileSizeUnit.SelectedIndexChanged += (sender, e) => AdjustFileSizeUnit();

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

        private FileChecks _fileChecks = new FileChecks();
        private bool _updating;
        private bool _useTimes = false;
        private FileFilterControl _view;

        private CheckBox
            CbCreatedUtc, CbModifiedUtc, CbAccessedUtc,
            CbReadOnly, CbHidden, CbSystem, CbArchive, CbCompressed, CbEncrypted,
            CbUseTimes, CbUseAutocorrect;

        private ComboBox CbFileSizeUnit;

        private DateTimePicker
            DtpCreatedMin, DtpCreatedMax,
            DtpModifiedMin, DtpModifiedMax,
            DtpAccessedMin, DtpAccessedMax;

        private NumericUpDown SeFileSizeMin, SeFileSizeMax;

        private int _prevFileSizeUnit;

        #endregion

        #region Private Properties

        private int FileSizeUnit
        {
            get => CbFileSizeUnit.SelectedIndex;
            set => CbFileSizeUnit.SelectedIndex = value;
        }

        private FileFlags Flags
        {
            get => _fileChecks.Flags;
            set
            {
                if (Flags == value)
                    return;
                _fileChecks.Flags = value;
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
            var shift = CbFileSizeUnit.SelectedIndex - _prevFileSizeUnit;
            decimal
                min = SeFileSizeMin.Value,
                max = SeFileSizeMax.Value,
                factor = 1L << Math.Abs(shift * 10);
            if (shift > 0)
                factor = 1 / factor;
            _updating = true;
            SeFileSizeMin.DecimalPlaces = SeFileSizeMax.DecimalPlaces = new[] { 0, 3, 5, 5, 5, 8, 11 }[FileSizeUnit];
            SeFileSizeMin.Maximum = SeFileSizeMax.Maximum = long.MaxValue / (decimal)(1L << FileSizeUnit * 10);
            SeFileSizeMin.Value = min * factor;
            SeFileSizeMax.Value = max * factor;
            _updating = false;
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

        private FileChecks ReadFileChecksFromControls()
        {
            var fileChecks = new FileChecks();
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

            fileChecks.CreatedMin = DtpCreatedMin.Value;
            fileChecks.CreatedMax = DtpCreatedMax.Value;
            fileChecks.ModifiedMin = DtpModifiedMin.Value;
            fileChecks.ModifiedMax = DtpModifiedMax.Value;
            fileChecks.AccessedMin = DtpAccessedMin.Value;
            fileChecks.AccessedMax = DtpAccessedMax.Value;

            fileChecks.FileSizeMin = ReadSpinEdit(SeFileSizeMin, FileFlags.FileSizeMin);
            fileChecks.FileSizeMax = ReadSpinEdit(SeFileSizeMax, FileFlags.FileSizeMax);
            fileChecks.FileSizeUnit = FileSizeUnit;

            ReadAttribute(FileAttributes.ReadOnly, FileFlags.ReadOnly);
            ReadAttribute(FileAttributes.Hidden, FileFlags.Hidden);
            ReadAttribute(FileAttributes.System, FileFlags.System);
            ReadAttribute(FileAttributes.Archive, FileFlags.Archive);
            ReadAttribute(FileAttributes.Compressed, FileFlags.Compressed);
            ReadAttribute(FileAttributes.Encrypted, FileFlags.Encrypted);

            fileChecks.Flags = flags;
            return fileChecks;

            void ReadAttribute(FileAttributes attr, FileFlags mask)
            {
                SetFlags(mask, StateToFlags());

                FileFlags StateToFlags()
                {
                    switch (GetCheckBox(attr).CheckState)
                    {
                        case CheckState.Checked: return mask & FileFlags.True;
                        case CheckState.Unchecked: return mask & FileFlags.False;
                        default: return 0;
                    }
                }
            }

            void ReadCheckBox(CheckBox control, FileFlags flag) => SetFlag(control.Checked ? flag : 0);
            void ReadCheckBoxDtp(DateTimePicker control, FileFlags flag) => SetFlag(control.Checked ? flag : 0);

            decimal ReadSpinEdit(NumericUpDown control, FileFlags flag)
            {
                var value = control.Value;
                SetFlag(flag, value != 0);
                return value;
            }

            void SetFlag(FileFlags mask, bool state = true) => flags = state ? flags | mask : flags & ~mask;
            void SetFlags(FileFlags mask, FileFlags state) => flags = flags & ~mask | state & mask;
        }


        private CheckBox GetCheckBox(FileAttributes attr)
        {
            switch (attr)
            {
                case FileAttributes.ReadOnly: return CbReadOnly;
                case FileAttributes.Hidden: return CbHidden;
                case FileAttributes.System: return CbSystem;
                case FileAttributes.Archive: return CbArchive;
                case FileAttributes.Compressed: return CbCompressed;
                case FileAttributes.Encrypted: return CbEncrypted;
                default: return null;
            }
        }

        private void WriteFileChecksToControls()
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

            DtpCreatedMin.Value = _fileChecks.CreatedMin;
            DtpCreatedMax.Value = _fileChecks.CreatedMax;
            DtpModifiedMin.Value = _fileChecks.ModifiedMin;
            DtpModifiedMax.Value = _fileChecks.ModifiedMax;
            DtpAccessedMin.Value = _fileChecks.AccessedMin;
            DtpAccessedMax.Value = _fileChecks.AccessedMax;
            SeFileSizeMin.Value = _fileChecks.FileSizeMin;
            SeFileSizeMax.Value = _fileChecks.FileSizeMax;
            FileSizeUnit = _fileChecks.FileSizeUnit;

            SeFileSizeMin.Value = _fileChecks.FileSizeMin;
            SeFileSizeMax.Value = _fileChecks.FileSizeMax;

            WriteAttribute(FileAttributes.ReadOnly, FileFlags.ReadOnly);
            WriteAttribute(FileAttributes.Hidden, FileFlags.Hidden);
            WriteAttribute(FileAttributes.System, FileFlags.System);
            WriteAttribute(FileAttributes.Archive, FileFlags.Archive);
            WriteAttribute(FileAttributes.Compressed, FileFlags.Compressed);
            WriteAttribute(FileAttributes.Encrypted, FileFlags.Encrypted);

            UpdateUI();

            bool GetFlag(FileFlags flag) => (Flags & flag) != 0;

            void WriteAttribute(FileAttributes attr, FileFlags flags)
            {
                GetCheckBox(attr).CheckState = FlagsToState();

                CheckState FlagsToState()
                {
                    flags &= Flags;
                    return
                        (flags & FileFlags.True) != 0 ? CheckState.Checked :
                        (flags & FileFlags.False) != 0 ? CheckState.Unchecked :
                        CheckState.Indeterminate;
                }
            }

            void WriteCheckBox(CheckBox control, FileFlags flag) => control.Checked = GetFlag(flag);
            void WriteCheckBoxDtp(DateTimePicker control, FileFlags flag) => control.Checked = GetFlag(flag);
        }

        private void UpdateUI()
        {
            _prevFileSizeUnit = CbFileSizeUnit.SelectedIndex;
            _view.edConditions.Text = GetFilterString();
        }

        #endregion
    }
}
