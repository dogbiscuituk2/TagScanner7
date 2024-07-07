namespace TagScanner.Controllers
{
    using System;
    using System.Windows.Forms;
    using Forms;

    public class FileOptionsController : Controller
    {
        #region Constructor

        public FileOptionsController(Controller parent) : base(parent)
        {
            FileFilterController = new FileFilterController(this);
            FileSchemaController = new FileSchemaController(this);
            MainForm.AddOptions.Click += AddOptions_Click;
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

        private FileFilterController FileFilterController;
        private FileSchemaController FileSchemaController;

        private FileOptionsDialog View;

        private ToolStripMenuItem
            PopupAdd, PopupEdit, PopupDelete;

        #endregion

        #region Event Handlers

        private void AddOptions_Click(object sender, EventArgs e) => Execute();

        #endregion

        #region Private Methods

        private void AfterExecute()
        {
            FileFilterController.AfterExecute();
            FileSchemaController.AfterExecute();
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
            View = new FileOptionsDialog();
            FileSchemaController.SetView(View.TreeView);
            FileFilterController.SetView(View.FileFilterControl);

            PopupAdd = View.PopupAdd;
            PopupEdit = View.PopupEdit;
            PopupDelete = View.PopupDelete;

            PopupAdd.Click += (sender, e) => FileSchemaController.Add();
            PopupEdit.Click += (sender, e) => FileSchemaController.Edit();
            PopupDelete.Click += (sender, e) => FileSchemaController.Remove();
        }

        private void UpdateUI() => PopupDelete.Enabled = FileSchemaController.SelectedNode?.Level > 0;

        #endregion
    }
}
