namespace TagScanner.Controllers
{
    using System;
    using System.Windows.Forms;
    using Terms;
    using Utils;
    using Views;

    public class FilterController : Controller
    {
        public FilterController(Controller parent) : base(parent)
        {
            //View.ViewFilter.Click += ViewFilter_Click;
            MainForm.ApplyButton.Click += ApplyButton_Click;
            MainForm.ClearButton.Click += ClearButton_Click;
            MainForm.EditButton.Click += EditButton_Click;
            FilterComboBox.DropDown += FilterComboBox_DropDown;
            FilterFormController = new FilterFormController(this);
            ScriptFormController = new ScriptFormController(this);
        }

        private ComboBox FilterComboBox => MainForm.FilterComboBox;
        private FilterFormController FilterFormController;
        private ScriptFormController ScriptFormController;

        private void ApplyButton_Click(object sender, EventArgs e) => UpdateFilter();
        private void ClearButton_Click(object sender, EventArgs e) => ClearFilter();
        private void EditButton_Click(object sender, EventArgs e) => EditFilter();

        private void FilterComboBox_DropDown(object sender, EventArgs e) => AppController.GetFilterItems(FilterComboBox);
        //private void ViewFilter_Click(object sender, EventArgs e) => LaunchFilterBuilder();

        private void ClearFilter()
        {
            FilterComboBox.Text = string.Empty;
            MainTableController.ClearFilter();
            UpdateFilterStatus($"{MainTableController.TracksCountAll} Tracks shown.");
        }

        private void EditFilter()
        {
            ScriptFormController.Execute();
        }

        private void LaunchFilterBuilder() => FilterFormController.Execute(FilterComboBox.Text);

        private void UpdateFilter()
        {
            var filter = FilterComboBox.Text;
            if (string.IsNullOrWhiteSpace(filter))
                return;
            if (new Parser().TryParse(filter, out var term, out var exception, caseSensitive: MainForm.CaseSensitiveCheckBox.Checked))
            {
                MainTableController.SetFilter(term);
                UpdateFilterStatus($"{MainTableController.TracksCountVisible} of {MainTableController.TracksCountAll} Tracks shown.");
                AppController.UpdateFilterItems(FilterComboBox);
            }
            else
                UpdateFilterStatus(exception.GetAllInformation());
        }

        private void UpdateFilterStatus(string status) => MainForm.FilterGroupBox.Text = $"Filter: {status}";
    }
}
