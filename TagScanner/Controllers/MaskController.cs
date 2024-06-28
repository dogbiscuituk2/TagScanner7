namespace TagScanner.Controllers
{
    using System;
    using System.Windows.Forms;
    using Forms;
    using Models;

    public class MaskController : Controller
    {
        #region Constructor

        public MaskController(Controller parent) : base(parent)
        {
            MainForm.AddOptions.Click += AddOptions_Click;
        }

        #endregion

        #region Public Properties

        public MaskDialog View => _maskDialog;

        #endregion

        #region Public Methods

        public bool Execute(ref Mask mask)
        {
            if (View == null)
                CreateView();
            Process(mask, loading: true);
            UpdateUI();
            var ok = View.ShowDialog(Owner) == DialogResult.OK;
            if (ok)
                mask = Process(new Mask(), loading: false);
            return ok;
        }

        #endregion

        #region Private Fields

        private MaskDialog _maskDialog;
        private TriStateTreeController _maskTreeController;
        private bool _updating;

        private CheckBox
            CbCreatedMin, CbCreatedMax, CbCreatedUtc,
            CbModifiedMin, CbModifiedMax, CbModifiedUtc,
            CbAccessedMin, CbAccessedMax, CbAccessedUtc,
            CbFileSizeMin, CbFileSizeMax;

        private ComboBox
            CbReadOnly, CbHidden, CbSystem, CbArchive;

        private DateTimePicker
            DtpCreatedMin, DtpCreatedMax,
            DtpModifiedMin, DtpModifiedMax,
            DtpAccessedMin, DtpAccessedMax;

        private NumericUpDown
            SeFileSizeMin, SeFileSizeMax;

        #endregion

        #region Event Handlers

        private void AddOptions_Click(object sender, EventArgs e)
        {
            var mask = new Mask();
            Execute(ref mask);
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e) => UpdateUI();

        #endregion

        #region Private Methods

        private void AdjustDate(DateTimePicker min, DateTimePicker max, bool lower)
        {
            if (!_updating)
            {
                _updating = true;
                if (lower)
                {
                    if (min.Value > max.Value)
                        min.Value = max.Value;
                }
                else
                {
                    if (max.Value < min.Value)
                        max.Value = min.Value;
                }
                _updating = false;
            }
        }

        private void AdjustFileSize(bool lower)
        {
            if (!_updating)
            {
                _updating = true;
                decimal
                    min = SeFileSizeMin.Value,
                    max = SeFileSizeMax.Value;
                if (lower)
                    SeFileSizeMin.Value = Math.Min(min, max);
                else
                    SeFileSizeMax.Value = Math.Max(min, max);
                _updating = false;
            }
            AdjustIncrement(SeFileSizeMin);
            AdjustIncrement(SeFileSizeMax);
        }

        private void AdjustIncrement(NumericUpDown control) =>
            control.Increment = Math.Max(1, Math.Truncate(control.Value / 100));

        private MaskDialog CreateView()
        {
            _maskDialog = new MaskDialog();
            _maskTreeController = new TriStateTreeController(View.TreeView);

            CbCreatedMin = View.cbCreatedMin;
            CbCreatedMax = View.cbCreatedMax;
            CbCreatedUtc = View.cbCreatedUtc;
            CbModifiedMin = View.cbModifiedMin;
            CbModifiedMax = View.cbModifiedMax;
            CbModifiedUtc = View.cbModifiedUtc;
            CbAccessedMin = View.cbAccessedMin;
            CbAccessedMax = View.cbAccessedMax;
            CbAccessedUtc = View.cbAccessedUtc;
            CbFileSizeMin = View.cbFileSizeMin;
            CbFileSizeMax = View.cbFileSizeMax;

            CbReadOnly = View.cbAttrReadOnly;
            CbHidden = View.cbAttrHidden;
            CbSystem = View.cbAttrSystem;
            CbArchive = View.cbAttrArchive;

            DtpCreatedMin = View.dtpCreatedMin;
            DtpCreatedMax = View.dtpCreatedMax;
            DtpModifiedMin = View.dtpModifiedMin;
            DtpModifiedMax = View.dtpModifiedMax;
            DtpAccessedMin = View.dtpAccessedMin;
            DtpAccessedMax = View.dtpAccessedMax;

            SeFileSizeMin = View.seFileSizeMin;
            SeFileSizeMax = View.seFileSizeMax;

            SeFileSizeMin.Maximum = SeFileSizeMax.Maximum = ulong.MaxValue;

            CbCreatedMin.CheckedChanged += CheckBox_CheckedChanged;
            CbModifiedMin.CheckedChanged += CheckBox_CheckedChanged;
            CbAccessedMin.CheckedChanged += CheckBox_CheckedChanged;
            CbFileSizeMin.CheckedChanged += CheckBox_CheckedChanged;
            CbCreatedMax.CheckedChanged += CheckBox_CheckedChanged;
            CbModifiedMax.CheckedChanged += CheckBox_CheckedChanged;
            CbAccessedMax.CheckedChanged += CheckBox_CheckedChanged;
            CbFileSizeMax.CheckedChanged += CheckBox_CheckedChanged;

            DtpCreatedMin.ValueChanged += (sender, e) => AdjustDate(DtpCreatedMin, DtpCreatedMax, lower: false);
            DtpCreatedMax.ValueChanged += (sender, e) => AdjustDate(DtpCreatedMin, DtpCreatedMax, lower: true);
            DtpModifiedMin.ValueChanged += (sender, e) => AdjustDate(DtpModifiedMin, DtpModifiedMax, lower: false);
            DtpModifiedMax.ValueChanged += (sender, e) => AdjustDate(DtpModifiedMin, DtpModifiedMax, lower: true);
            DtpAccessedMin.ValueChanged += (sender, e) => AdjustDate(DtpAccessedMin, DtpAccessedMax, lower: false);
            DtpAccessedMax.ValueChanged += (sender, e) => AdjustDate(DtpAccessedMin, DtpAccessedMax, lower: true);

            SeFileSizeMin.ValueChanged += (sender, e) => AdjustFileSize(lower: false);
            SeFileSizeMax.ValueChanged += (sender, e) => AdjustFileSize(lower: true);

            return _maskDialog;
        }

        private Mask Process(Mask mask, bool loading)
        {
            ProcessCheckBox(CbCreatedMin, MaskFlags.DateCreatedMin);
            ProcessCheckBox(CbCreatedMax, MaskFlags.DateCreatedMax);
            ProcessCheckBox(CbCreatedUtc, MaskFlags.DateCreatedUtc);
            ProcessCheckBox(CbModifiedMin, MaskFlags.DateModifiedMin);
            ProcessCheckBox(CbModifiedMax, MaskFlags.DateModifiedMax);
            ProcessCheckBox(CbModifiedUtc, MaskFlags.DateModifiedUtc);
            ProcessCheckBox(CbAccessedMin, MaskFlags.DateAccessedMin);
            ProcessCheckBox(CbAccessedMax, MaskFlags.DateAccessedMax);
            ProcessCheckBox(CbAccessedUtc, MaskFlags.DateAccessedUtc);
            ProcessCheckBox(CbFileSizeMin, MaskFlags.FileSizeMin);
            ProcessCheckBox(CbFileSizeMax, MaskFlags.FileSizeMax);

            if (loading)
            {
                DtpCreatedMin.Value = mask.DateCreatedMin;
                DtpCreatedMax.Value = mask.DateCreatedMax;
                DtpModifiedMin.Value = mask.DateModifiedMin;
                DtpModifiedMax.Value = mask.DateModifiedMax;
                DtpAccessedMin.Value = mask.DateAccessedMin;
                DtpAccessedMax.Value = mask.DateAccessedMax;
                SeFileSizeMin.Value = mask.FileSizeMin;
                SeFileSizeMax.Value = mask.FileSizeMax;
            }
            else
            {
                mask.DateCreatedMin = DtpCreatedMin.Value;
                mask.DateCreatedMax = DtpCreatedMax.Value;
                mask.DateModifiedMin = DtpModifiedMin.Value;
                mask.DateModifiedMax = DtpModifiedMax.Value;
                mask.DateAccessedMin = DtpAccessedMin.Value;
                mask.DateAccessedMax = DtpAccessedMax.Value;
                mask.FileSizeMin = (ulong)SeFileSizeMin.Value;
                mask.FileSizeMax = (ulong)SeFileSizeMax.Value;
            }

            ProcessComboBox(CbReadOnly, MaskFlags.ReadOnlyTrue, MaskFlags.ReadOnlyFalse);
            ProcessComboBox(CbHidden, MaskFlags.HiddenTrue, MaskFlags.HiddenFalse);
            ProcessComboBox(CbSystem, MaskFlags.SystemTrue, MaskFlags.SystemFalse);
            ProcessComboBox(CbArchive, MaskFlags.ArchiveTrue, MaskFlags.ArchiveFalse);

            return mask;

            void ProcessCheckBox(CheckBox control, MaskFlags flag)
            {
                if (loading)
                    control.Checked = GetFlag(flag);
                else
                    SetFlag(control.Checked ? flag : 0);
            }

            void ProcessComboBox(ComboBox control, MaskFlags yes, MaskFlags no)
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

            bool GetFlag(MaskFlags flag) => (mask.Flags & flag) != 0;
            void SetFlag(MaskFlags flag) => mask.Flags |= flag;
        }

        private void UpdateUI()
        {
            DtpCreatedMin.Enabled = CbCreatedMin.Checked;
            DtpModifiedMin.Enabled = CbModifiedMin.Checked;
            DtpAccessedMin.Enabled = CbAccessedMin.Checked;
            DtpCreatedMax.Enabled = CbCreatedMax.Checked;
            DtpModifiedMax.Enabled = CbModifiedMax.Checked;
            DtpAccessedMax.Enabled = CbAccessedMax.Checked;
            SeFileSizeMin.Enabled = CbFileSizeMin.Checked;
            SeFileSizeMax.Enabled = CbFileSizeMax.Checked;
        }

        #endregion
    }
}
