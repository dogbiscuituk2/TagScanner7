namespace TagScanner.Controllers
{
    using System;
    using Terms;
    using Utils;
    using Views;

    public class FilterController : Controller
    {
        public FilterController(Controller parent) : base(parent)
        {
            View.CaseSensitiveCheckBox.CheckStateChanged += CbFilterApply_CheckStateChanged;
            View.FilterComboBox.TextChanged += FilterComboBox_TextChanged;
            View.ViewFilter.Click += ViewFilter_Click;
            View.ApplyButton.Click += BtnFilterBuild_Click;
        }

        private FilterFormController FilterFormController = new FilterFormController(null);
        private LibraryFormController LibraryFormController => (LibraryFormController)Parent;
        private LibraryGridController LibraryGridController => LibraryFormController.LibraryGridController; 
        private LibraryForm View => LibraryFormController.View;

        private void BtnFilterBuild_Click(object sender, EventArgs e) => LaunchFilterBuilder();
        private void CbFilterApply_CheckStateChanged(object sender, EventArgs e) => UpdateFilter();
        private void FilterComboBox_TextChanged(object sender, EventArgs e) => UpdateFilter();
        private void ViewFilter_Click(object sender, EventArgs e) => LaunchFilterBuilder();

        private void LaunchFilterBuilder() => FilterFormController.Execute(View.FilterComboBox.Text);

        private void UpdateFilter()
        {
            if (View.CaseSensitiveCheckBox.Checked)
                if (new Parser().TryParse(View.FilterComboBox.Text, out var term, out var exception))
                {
                    LibraryGridController.SetFilter(term);
                    UpdateFilterStatus($"{LibraryGridController.WorksCountVisible} of {LibraryGridController.WorksCountAll} Works shown.");
                }
                else
                    UpdateFilterStatus(exception.GetAllInformation());
            else
            {
                LibraryGridController.ClearFilter();
                UpdateFilterStatus($"{LibraryGridController.WorksCountAll} Works shown.");
            }
        }

        private void UpdateFilterStatus(string status) => View.FilterGroupBox.Text = $"Filter: {status}";

    }
}
