namespace TagScanner.Controllers
{
    using System;
    using System.Windows.Forms;
    using Forms;

    public class FileChecksController : Controller
    {
        #region Constructor

        public FileChecksController(Controller parent) : base(parent)
        {
            FileFilterController = new FileFilterController(this);
            FileFilterController.UseTimesChanged += (sender, e) => View.FileFilterPanel.Width = FileFilterController.ViewWidth;
            FileSchemaController = new FileSchemaController(this);
            MainForm.AddOptions.Click += AddOptions_Click;
        }

        #endregion

        #region Public Properties

        public bool UseAutocorrect
        {
            get => FileFilterController.UseAutocorrect;
            set => FileFilterController.UseAutocorrect = value;
        }

        #endregion

        #region Public Methods

        public bool Execute()
        {
            BeforeExecute();
            var ok = View.ShowDialog(Owner) == DialogResult.OK;
            if (ok)
                AfterExecute();
            return ok;
        }

        #endregion

        #region Private Fields

        private readonly FileFilterController FileFilterController;
        private readonly FileSchemaController FileSchemaController;

        private FileChecksDialog View;

        private ToolStripMenuItem
            SchemaPopupAdd,
            SchemaPopupEdit,
            SchemaPopupDelete;

        #endregion

        #region Event Handlers

        private void AddOptions_Click(object sender, EventArgs e) => Execute();

        #endregion

        #region Private Methods

        private void AfterExecute()
        {
            FileSchemaController.AfterExecute();
            FileFilterController.AfterExecute();
        }

        private void BeforeExecute()
        {
            if (View == null)
                CreateView();
            FileSchemaController.BeforeExecute();
            FileFilterController.BeforeExecute();
            UpdateUI();
        }

        private void CreateView()
        {
            View = new FileChecksDialog();
            FileSchemaController.SetView(View.TreeView, View.edFilespecs);
            FileFilterController.SetView(View.FileFilterControl);

            SchemaPopupAdd = View.SchemaPopupAdd;
            SchemaPopupEdit = View.SchemaPopupEdit;
            SchemaPopupDelete = View.SchemaPopupDelete;

            SchemaPopupAdd.Click += (sender, e) => FileSchemaController.Add();
            SchemaPopupEdit.Click += (sender, e) => FileSchemaController.Edit();
            SchemaPopupDelete.Click += (sender, e) => FileSchemaController.Remove();
        }

        private void UpdateUI() => SchemaPopupDelete.Enabled = FileSchemaController.SelectedNode?.Level > 0;

        #endregion
    }
}
