namespace TagScanner.Controllers
{
    using System.Linq;
    using System.Windows.Forms;
    using TagScanner.Controllers.Mru;
    using Views;

    public class DragDropController : Controller
    {
        #region Constructor

        public DragDropController(Controller parent) : base(parent)
        {
            PrepareMainForm();
            PrepareTable();
        }

        #endregion

        #region Private Properties

        private MainForm MainForm => MainFormController.View;
        private MainFormController MainFormController => (MainFormController)Parent;
        private MruMediaController MediaController => MainFormController.MediaController;
        private System.Windows.Controls.DataGrid Table => TableController.DataGrid;
        private WpfTableController TableController => MainFormController.TableController;

        #endregion

        #region Event Handlers

        private void MainForm_DragDrop(object sender, DragEventArgs e) => DragDrop(GetFilePaths(e.Data));

        private void MainForm_DragOver(object sender, DragEventArgs e) =>
            e.Effect = DragOver(e.Data)
            ? DragDropEffects.Move
            : DragDropEffects.None;

        private void Table_Drop(object sender, System.Windows.DragEventArgs e) => DragDrop(GetFilePaths(e.Data));

        private void Table_DragOver(object sender, System.Windows.DragEventArgs e) =>
            e.Effects = DragOver(e.Data)
            ? System.Windows.DragDropEffects.Copy
            : System.Windows.DragDropEffects.None;

        #endregion

        #region Private Methods

        private void DragDrop(string[] paths) => MediaController.AddFiles(paths);

        private bool DragOver(IDataObject dataObject) => PathsExist(GetFilePaths(dataObject));

        private bool DragOver(System.Windows.IDataObject dataObject) => PathsExist(GetFilePaths(dataObject));

        private string[] GetFilePaths(IDataObject dataObject) => dataObject.GetData("FileDrop") as string[];

        private string[] GetFilePaths(System.Windows.IDataObject dataObject) => dataObject.GetData("FileDrop") as string[];

        private bool PathsExist(string[] paths) => paths != null && paths.Any();

        private void PrepareMainForm()
        {
            MainForm.AllowDrop = true;
            MainForm.DragDrop += MainForm_DragDrop;
            MainForm.DragOver += MainForm_DragOver;
        }

        private void PrepareTable()
        {
            Table.AllowDrop = true;
            Table.DragOver += Table_DragOver;
            Table.Drop += Table_Drop;
        }

        #endregion
    }
}
