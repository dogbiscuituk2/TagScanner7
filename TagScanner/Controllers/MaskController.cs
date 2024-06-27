namespace TagScanner.Controllers
{
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

        public MaskDialog View => _maskDialog ?? CreateView();

        #endregion

        #region Public Methods

        public bool Execute(ref Mask mask)
        {
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

        #endregion

        #region Event Handlers

        private void AddOptions_Click(object sender, System.EventArgs e)
        {
            var mask = new Mask();
            Execute(ref mask);
        }

        private void CheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            UpdateUI();
        }

        #endregion

        #region Private Methods

        private MaskDialog CreateView()
        {
            _maskDialog = new MaskDialog();
            _maskTreeController = new TriStateTreeController(View.TreeView);
            View.cbCreatedMin.CheckedChanged += CheckBox_CheckedChanged;
            View.cbModifiedMin.CheckedChanged += CheckBox_CheckedChanged;
            View.cbAccessedMin.CheckedChanged += CheckBox_CheckedChanged;
            View.cbFileSizeMin.CheckedChanged += CheckBox_CheckedChanged;
            View.cbCreatedMax.CheckedChanged += CheckBox_CheckedChanged;
            View.cbModifiedMax.CheckedChanged += CheckBox_CheckedChanged;
            View.cbAccessedMax.CheckedChanged += CheckBox_CheckedChanged;
            View.cbFileSizeMax.CheckedChanged += CheckBox_CheckedChanged;
            return _maskDialog;
        }

        private Mask Process(Mask mask, bool loading)
        {
            ProcessCheckBox(View.cbCreatedMin, MaskFlags.DateCreatedMin);
            ProcessCheckBox(View.cbCreatedMax, MaskFlags.DateCreatedMax);
            ProcessCheckBox(View.cbCreatedUtc, MaskFlags.DateCreatedUtc);
            ProcessCheckBox(View.cbModifiedMin, MaskFlags.DateModifiedMin);
            ProcessCheckBox(View.cbModifiedMax, MaskFlags.DateModifiedMax);
            ProcessCheckBox(View.cbModifiedUtc, MaskFlags.DateModifiedUtc);
            ProcessCheckBox(View.cbAccessedMin, MaskFlags.DateAccessedMin);
            ProcessCheckBox(View.cbAccessedMax, MaskFlags.DateAccessedMax);
            ProcessCheckBox(View.cbAccessedUtc, MaskFlags.DateAccessedUtc);
            ProcessCheckBox(View.cbFileSizeMin, MaskFlags.FileSizeMin);
            ProcessCheckBox(View.cbFileSizeMax, MaskFlags.FileSizeMax);

            if (loading)
            {
                View.dtpCreatedMin.Value = mask.DateCreatedMin;
                View.dtpCreatedMax.Value = mask.DateCreatedMax;
                View.dtpModifiedMin.Value = mask.DateModifiedMin;
                View.dtpModifiedMax.Value = mask.DateModifiedMax;
                View.dtpAccessedMin.Value = mask.DateAccessedMin;
                View.dtpAccessedMax.Value = mask.DateAccessedMax;
                //View.meFileSizeMin.Text = mask.FileSizeMin.ToString();
                //View.meFileSizeMax.Text = mask.FileSizeMax.ToString();
            }
            else
            {
                mask.DateCreatedMin = View.dtpCreatedMin.Value;
                mask.DateCreatedMax = View.dtpCreatedMax.Value;
                mask.DateModifiedMin = View.dtpModifiedMin.Value;
                mask.DateModifiedMax = View.dtpModifiedMax.Value;
                mask.DateAccessedMin = View.dtpAccessedMin.Value;
                mask.DateAccessedMax = View.dtpAccessedMax.Value;

                //mask.FileSizeMin = long.Parse(View.meFileSizeMin.Text);
                //mask.FileSizeMax = long.Parse(View.meFileSizeMax.Text);
            }

            ProcessComboBox(View.cbAttrReadOnly, MaskFlags.ReadOnlyTrue, MaskFlags.ReadOnlyFalse);
            ProcessComboBox(View.cbAttrHidden, MaskFlags.HiddenTrue, MaskFlags.HiddenFalse);
            ProcessComboBox(View.cbAttrSystem, MaskFlags.SystemTrue, MaskFlags.SystemFalse);
            ProcessComboBox(View.cbAttrArchive, MaskFlags.ArchiveTrue, MaskFlags.ArchiveFalse);

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
            View.dtpCreatedMin.Enabled = View.cbCreatedMin.Checked;
            View.dtpModifiedMin.Enabled = View.cbModifiedMin.Checked;
            View.dtpAccessedMin.Enabled = View.cbAccessedMin.Checked;
            View.dtpCreatedMax.Enabled = View.cbCreatedMax.Checked;
            View.dtpModifiedMax.Enabled = View.cbModifiedMax.Checked;
            View.dtpAccessedMax.Enabled = View.cbAccessedMax.Checked;

            //View.seFileSizeMin.Enabled = View.cbFileSizeMin.Checked;
            //View.seFileSizeMax.Enabled = View.cbFileSizeMax.Checked;
        }

        #endregion
    }
}
