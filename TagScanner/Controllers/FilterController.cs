namespace TagScanner.Controllers
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Controls;
    using Core;
    using Forms;
    using Parsing;

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
            MainForm.FilterPopupMenu.Opening += FilterPopupMenu_Opening;
            MainForm.PopupFilterApply.Click += TbApply_Click;
            MainForm.PopupFilterClear.Click += TbClear_Click;
            MainForm.PopupFilterClose.Click += TbClose_Click;
            MainForm.PopupFilterEdit.Click += TbEdit_Click;

            TbCaseSensitive.Click += TbCaseSensitive_Click;
            CbFilter.DropDown += CbFilter_DropDown;
            TbApply.Click += TbApply_Click;
            TbClear.Click += TbClear_Click;
            TbEdit.Click += TbEdit_Click;
            TbClose.Click += TbClose_Click;

            View.Resize += View_Resize;
        }

        #endregion

        #region Public Methods

        public void ApplyFilter()
        {
            var filter = CbFilter.Text;
            if (string.IsNullOrWhiteSpace(filter))
                return;
            if (Parser.TryParse(filter, out var term, out var exception, CaseSensitive))
            {
                MainTableController.SetFilter(term);
                int
                    all = MainTableController.TracksCountAll,
                    visible = MainTableController.TracksCountVisible;
                UpdateFilterStatus(all > 0 ? $"on. {visible} of {all} items(s) shown." : "no items present.");
                AppController.UpdateFilterItems(CbFilter.Items, CbFilter.Text);
            }
            else
                UpdateFilterStatus(exception.GetAllInformation());
        }

        public void UpdateAutoComplete() => CbFilter.AutoCompleteCustomSource = MainAutoCompleter.GetFilterAutoCompleteItems();

        #endregion

        #region Private Fields

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

        #region Private Properties

        private bool CaseSensitive { get => TbCaseSensitive.Checked; set => TbCaseSensitive.Checked = value; }
        private FilterControl View => MainForm.FilterControl;

        #endregion

        #region Event Handlers

        private void CbFilter_DropDown(object sender, EventArgs e) => AppController.GetFilterItems(CbFilter.Items);
        private void EditFilter_Click(object sender, EventArgs e) => Show();
        private void FilterPopupMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e) => MainForm.PopupFilterCase.Checked = CaseSensitive;
        private void TbApply_Click(object sender, EventArgs e) => ApplyFilter();
        private void TbCaseSensitive_Click(object sender, EventArgs e) => ToggleCaseSensitive();
        private void TbClear_Click(object sender, EventArgs e) => ClearFilter();
        private void TbClose_Click(object sender, EventArgs e) => Hide();
        private void TbEdit_Click(object sender, EventArgs e) => EditFilter();
        private void View_Resize(object sender, EventArgs e) => Resize();

        #endregion

        #region Private Methods

        private void EditFilter() => ScriptFormController.ShowModal(CbFilter.Text);
        private void Hide() => Show(false);
        private void Resize() => CbFilter.Size = new Size(View.Width - 118, CbFilter.Height);
        private void ToggleCaseSensitive() => CaseSensitive ^= true;
        private void UpdateFilterStatus(string status) => ParentControl.Text = $"Filter: {status}";

        private void ClearFilter()
        {
            CbFilter.Text = string.Empty;
            MainTableController.ClearFilter();
            UpdateFilterStatus($"off. {MainTableController.TracksCountAll} Tracks shown.");
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

        #endregion
    }
}
