﻿namespace TagScanner.Controllers
{
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

        public bool Execute(bool force)
        {
            if (!force && _dontShowThisAgain)
                return true;
            if (View == null)
                CreateView();
            var control = View.cbDontShowThisAgain;
            control.Checked = _dontShowThisAgain;
            control.Visible = !force;
            BeforeExecute();
            var ok = View.ShowDialog(Owner) == DialogResult.OK;
            _dontShowThisAgain = force ? false : View.cbDontShowThisAgain.Checked;
            if (ok)
                AfterExecute();
            return ok;
        }

        #endregion

        #region Private Fields

        private bool _dontShowThisAgain;
        private readonly FileFilterController FileFilterController;
        private readonly FileSchemaController FileSchemaController;

        private FileChecksDialog View;

        private ToolStripMenuItem
            SchemaPopupAdd,
            SchemaPopupEdit,
            SchemaPopupDelete;

        #endregion

        #region Private Methods

        private void AfterExecute()
        {
            FileSchemaController.AfterExecute();
            FileFilterController.AfterExecute();
        }

        private void BeforeExecute()
        {
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
