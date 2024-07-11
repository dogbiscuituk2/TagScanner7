﻿namespace TagScanner.Controllers
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

        #region Public Properties

        public bool UseTimes
        {
            get => FileFilterController.UseTimes;
            set
            {
                FileFilterController.UseTimes = value;
                View.RightPanel.Width = FileFilterController.ViewWidth;
            }
        }

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

        private FileOptionsDialog View;

        private ContextMenuStrip FilterPopupMenu;

        private ToolStripMenuItem
            SchemaPopupShowFormats,
            SchemaPopupAdd,
            SchemaPopupEdit,
            SchemaPopupDelete,
            FilterPopupShowFilter,
            FilterPopupUseTimes,
            FilterPopupUseAutocorrect;

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
            View = new FileOptionsDialog();
            FileSchemaController.SetView(View.TreeView);
            FileFilterController.SetView(View.FileFilterControl);

            SchemaPopupShowFormats = View.SchemaPopupShowFormats;
            SchemaPopupAdd = View.SchemaPopupAdd;
            SchemaPopupEdit = View.SchemaPopupEdit;
            SchemaPopupDelete = View.SchemaPopupDelete;
            FilterPopupMenu = View.FilterPopupMenu;
            FilterPopupShowFilter = View.FilterPopupShowFilter;
            FilterPopupUseTimes = View.FilterPopupUseTimes;
            FilterPopupUseAutocorrect = View.FilterPopupUseAutocorrect;

            SchemaPopupAdd.Click += (sender, e) => FileSchemaController.Add();
            SchemaPopupEdit.Click += (sender, e) => FileSchemaController.Edit();
            SchemaPopupDelete.Click += (sender, e) => FileSchemaController.Remove();
            SchemaPopupShowFormats.Click += (sender, e) => FileSchemaController.ShowFileFilter();
            FilterPopupUseTimes.Click += (sender, e) => UseTimes ^= true;
            FilterPopupMenu.Opening += (sender, e) => FilterPopupUseAutocorrect.Checked = UseAutocorrect;
            FilterPopupUseAutocorrect.Click += (sender, e) => UseAutocorrect ^= true;
            FilterPopupShowFilter.Click += (sender, e) => FileFilterController.ShowFilter();

            UseTimes = false;
        }

        private void UpdateUI() => SchemaPopupDelete.Enabled = FileSchemaController.SelectedNode?.Level > 0;

        #endregion
    }
}
