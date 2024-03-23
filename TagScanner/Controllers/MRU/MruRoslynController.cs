namespace TagScanner.Controllers.Mru
{
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Windows.Data;
    using System;
    using Microsoft.CodeAnalysis.CSharp.Scripting;
    using Microsoft.CodeAnalysis.Scripting;
    using Logging;
    using Models;
    using Views;
    using System.Reflection;

    public class MruRoslynController : MruController
    {
        public MruRoslynController(LibraryFormController libraryFormController) : base("Filters", libraryFormController.View.FilterPopupMenu)
        {
            LibraryFormController = libraryFormController;
            ApplyButton.Click += ApplyButton_Click;
            ClearButton.Click += ClearButton_Click;
        }

        private LibraryFormController LibraryFormController;

        private LibraryForm LibraryForm => LibraryFormController.View;
        private LibraryGridController LibraryGridController => LibraryFormController.LibraryGridController;
        private System.Windows.Controls.DataGrid DataGrid => LibraryGridController.DataGrid;
        private ListCollectionView ListCollectionView => (ListCollectionView)DataGrid.ItemsSource;
        private Button ApplyButton => LibraryForm.ApplyButton;
        private Button ClearButton => LibraryForm.ClearButton;
        private TextBox FilterTextBox => LibraryForm.FilterTextBox;

        private void ApplyButton_Click(object sender, EventArgs e) => ApplyFilter();
        private void ClearButton_Click(object sender, EventArgs e) => ClearFilter();

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        private void ApplyFilter() => ApplyFilterAsync(FilterTextBox.Text);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

        private async Task ApplyFilterAsync(string condition)
        {
            ListCollectionView.Filter = null;
            Func<IWork, bool> expression = null;
            try
            {
                expression = await CSharpScript.EvaluateAsync<Func<IWork, bool>>(condition, ScriptOptions);

                var foo = "123";
                var bar = foo.Contains("2");
            }
            catch (CompilationErrorException cex)
            {
                System.Diagnostics.Debug.WriteLine(cex.Diagnostics);
            }
            if (expression != null)
                try
                {
                    ListCollectionView.Filter += work => expression((IWork)work);
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex);
                }
        }

        private void ClearFilter()
        {
            FilterTextBox.Clear();
            ApplyFilter();
        }

        private static readonly ScriptOptions ScriptOptions =
            ScriptOptions.Default
            .AddReferences(Assembly.GetAssembly(typeof(IWork)))
            .AddImports("System");
    }
}
