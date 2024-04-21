namespace TagScanner.Controllers
{
    using System.Linq;
    using System.Windows.Controls;
    using Views;

    public class DragDropController : Controller
    {
        public DragDropController(Controller parent) : base(parent)
        {
            DataGrid.DragEnter += DataGrid_DragEnter;
            DataGrid.DragLeave += DataGrid_DragLeave;
            DataGrid.DragOver += DataGrid_DragOver;
            DataGrid.AllowDrop = true;
        }

        private void DataGrid_DragOver(object sender, System.Windows.DragEventArgs e)
        {
            return;
        }

        private void DataGrid_DragLeave(object sender, System.Windows.DragEventArgs e)
        {
            return;
        }

        private void DataGrid_DragEnter(object sender, System.Windows.DragEventArgs e)
        {
            var data = e.Data;
            var formats = data.GetFormats();
            if (formats.Contains(DataFormatFileDrop))
            {
                string[] filePaths = data.GetData(DataFormatFileDrop) as string[];
                return;
            }
        }

        private const string DataFormatFileDrop = "FileDrop";

        private DataGrid DataGrid => GridController.DataGrid;
        private GridController GridController => MainFormController.LibraryGridController;
        private MainForm View => MainFormController.View;
        private MainFormController MainFormController => (MainFormController)Parent;
    }
}
