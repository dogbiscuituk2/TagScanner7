﻿namespace TagScanner.Controllers
{
    using System;
    using Terms;
    using Utils;
    using Views;

    public class FilterController : Controller
    {
        public FilterController(Controller parent) : base(parent)
        {
            View.ViewFilter.Click += ViewFilter_Click;
            View.ApplyButton.Click += ApplyButton_Click;
            View.ClearButton.Click += ClearButton_Click;
        }

        private FilterFormController FilterFormController = new FilterFormController(null);
        private LibraryFormController LibraryFormController => (LibraryFormController)Parent;
        private LibraryGridController LibraryGridController => LibraryFormController.LibraryGridController; 
        private LibraryForm View => LibraryFormController.View;

        private void ApplyButton_Click(object sender, EventArgs e) => UpdateFilter();
        private void ClearButton_Click(object sender, EventArgs e) => ClearFilter();
        private void ViewFilter_Click(object sender, EventArgs e) => LaunchFilterBuilder();

        private void ClearFilter()
        {
            View.FilterComboBox.Text = string.Empty;
            LibraryGridController.ClearFilter();
            UpdateFilterStatus($"{LibraryGridController.WorksCountAll} Works shown.");
        }

        private void LaunchFilterBuilder() => FilterFormController.Execute(View.FilterComboBox.Text);

        private void UpdateFilter()
        {
            var filter = View.FilterComboBox.Text;
            if (string.IsNullOrWhiteSpace(filter))
                return;
            if (new Parser().TryParse(filter, out var term, out var exception, caseSensitive: View.CaseSensitiveCheckBox.Checked))
            {
                LibraryGridController.SetFilter(term);
                UpdateFilterStatus(
                    $"{LibraryGridController.WorksCountVisible} of {LibraryGridController.WorksCountAll} Works shown.");
                UpdateFilters();
            }
            else
                UpdateFilterStatus(exception.GetAllInformation());
        }

        private void UpdateFilters()
        {
            var editor = View.FilterComboBox;
            var filter = editor.Text;
            var filters = editor.Items;
            if (filters.Contains(filter))
                filters.Remove(filter);
            filters.Insert(0, filter);
            editor.Text = filter;
        }

        private void UpdateFilterStatus(string status) => View.FilterGroupBox.Text = $"Filter: {status}";
    }
}
