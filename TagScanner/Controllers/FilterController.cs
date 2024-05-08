﻿namespace TagScanner.Controllers
{
    using System;
    using System.Windows.Forms;
    using Terms;
    using Utils;
    using Views;
    using Wpf;

    public class FilterController : Controller
    {
        public FilterController(Controller parent) : base(parent)
        {
            //View.ViewFilter.Click += ViewFilter_Click;
            View.ApplyButton.Click += ApplyButton_Click;
            View.ClearButton.Click += ClearButton_Click;
            View.EditButton.Click += EditButton_Click;
            FilterComboBox.DropDown += FilterComboBox_DropDown;
            FilterFormController = new FilterFormController(this);
            ScriptFormController = new ScriptFormController(this);
        }

        private ComboBox FilterComboBox => View.FilterComboBox;
        private FilterFormController FilterFormController;
        private WpfTableController LibraryGridController => MainFormController.TableController;
        private MainForm View => MainFormController.View;
        private ScriptFormController ScriptFormController;

        private void ApplyButton_Click(object sender, EventArgs e) => UpdateFilter();
        private void ClearButton_Click(object sender, EventArgs e) => ClearFilter();
        private void EditButton_Click(object sender, EventArgs e) => EditFilter();

        private void FilterComboBox_DropDown(object sender, EventArgs e) => AppController.GetFilterItems(FilterComboBox);
        //private void ViewFilter_Click(object sender, EventArgs e) => LaunchFilterBuilder();

        private void ClearFilter()
        {
            FilterComboBox.Text = string.Empty;
            LibraryGridController.ClearFilter();
            UpdateFilterStatus($"{LibraryGridController.TracksCountAll} Tracks shown.");
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
            if (new Parser().TryParse(filter, out var term, out var exception, caseSensitive: View.CaseSensitiveCheckBox.Checked))
            {
                LibraryGridController.SetFilter(term);
                UpdateFilterStatus($"{LibraryGridController.TracksCountVisible} of {LibraryGridController.TracksCountAll} Tracks shown.");
                AppController.UpdateFilterItems(FilterComboBox);
            }
            else
                UpdateFilterStatus(exception.GetAllInformation());
        }

        private void UpdateFilterStatus(string status) => View.FilterGroupBox.Text = $"Filter: {status}";
    }
}
