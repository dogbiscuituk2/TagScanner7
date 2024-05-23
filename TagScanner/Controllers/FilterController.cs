namespace TagScanner.Controllers
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Controls;
    using Forms;
    using Terms;
    using Utils;

    public class FilterController : Controller
    {
        #region Constructor

        public FilterController(Controller parent) : base(parent)
        {
            ScriptFormController = new ScriptFormController(this);

            ParentControl = View.Parent;
            TbCaseSensitive = View.tbCaseSensitive;
            CbFilter = View.cbFilter;
            TbApply = View.tbApply;
            TbClear = View.tbClear;
            TbEdit = View.tbEdit;
            TbClose = View.tbClose;

            Hide();

            MainForm.EditFilter.Click += EditFilter_Click;
            MainForm.tbFilter.Click += EditFilter_Click;

            TbCaseSensitive.Click += TbCaseSensitive_Click;
            CbFilter.DropDown += CbFilter_DropDown;
            TbApply.Click += TbApply_Click;
            TbClear.Click += TbClear_Click;
            TbEdit.Click += TbEdit_Click;
            TbClose.Click += TbClose_Click;

            View.Resize += View_Resize;
        }

        #endregion

        #region Fields

        private readonly Control ParentControl;
        private ScriptFormController ScriptFormController;

        private readonly ToolStripButton
            TbCaseSensitive,
            TbApply,
            TbClear,
            TbEdit,
            TbClose;

        private readonly ToolStripComboBox
            CbFilter;

        #endregion

        #region Properties

        private bool CaseSensitive { get => TbCaseSensitive.Checked; set => TbCaseSensitive.Checked = value; }
        private FilterControl View => MainForm.FilterControl;

        #endregion

        #region Event Handlers

        private void CbFilter_DropDown(object sender, EventArgs e) => AppController.GetFilterItems(CbFilter.Items);
        private void EditFilter_Click(object sender, System.EventArgs e) => Show();
        private void TbApply_Click(object sender, EventArgs e) => UpdateFilter();
        private void TbCaseSensitive_Click(object sender, EventArgs e) => ToggleCaseSensitive();
        private void TbClear_Click(object sender, EventArgs e) => ClearFilter();
        private void TbClose_Click(object sender, System.EventArgs e) => Hide();
        private void TbEdit_Click(object sender, EventArgs e) => EditFilter();
        private void View_Resize(object sender, EventArgs e) => Resize();

        #endregion

        #region Private Methods

        private void EditFilter() => ScriptFormController.ShowModal(Owner, CbFilter.Text);
        private void Hide() => Show(false);
        private void Resize() => CbFilter.Size = new Size(View.Width - 118, CbFilter.Height);
        private void ToggleCaseSensitive() => CaseSensitive ^= true;
        private void UpdateFilterStatus(string status) => ParentControl.Text = $"Filter: {status}";

        private void ClearFilter()
        {
            CbFilter.Text = string.Empty;
            MainTableController.ClearFilter();
            UpdateFilterStatus($"{MainTableController.TracksCountAll} Tracks shown.");
        }

        private void Show(bool visible = true)
        {
            ParentControl.Visible = visible;
            if (visible)
            {
                ParentControl.Size = new Size(ParentControl.Width, 48);
                CbFilter.Focus();
            }
        }

        private void UpdateFilter()
        {
            var filter = CbFilter.Text;
            if (string.IsNullOrWhiteSpace(filter))
                return;
            if (Parser.TryParse(filter, out var term, out var exception, CaseSensitive))
            {
                MainTableController.SetFilter(term);
                UpdateFilterStatus($"{MainTableController.TracksCountVisible} of {MainTableController.TracksCountAll} Tracks shown.");
                AppController.UpdateFilterItems(CbFilter.Items, CbFilter.Text);
            }
            else
                UpdateFilterStatus(exception.GetAllInformation());

        }

        #endregion
    }
}
