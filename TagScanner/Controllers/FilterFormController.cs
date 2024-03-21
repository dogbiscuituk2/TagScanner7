namespace TagScanner.Controllers
{
    using System;
    using System.Windows.Forms;
    using Menus;
    using Models;
    using Terms;
    using Utils;
    using Views;

    internal class FilterFormController : Controller
    {
        #region Constructor

        internal FilterFormController(Controller parent) : base(parent)
        {
            TermTreeViewController = new TermTreeViewController(this, TreeView);
            TermTreeViewController.Inks = Inks._16inks;
            View.ViewCollapseAll.Click += ViewCollapseAll_Click;
            View.ViewExpandAll.Click += ViewExpandAll_Click;
            MenuRouter = new MenuRouter(TermMenu, PopupMenu);
            MenuRouter.ConstantClick += MenuRouter_ConstantClick;
            MenuRouter.FieldClick += MenuRouter_FieldClick;
            MenuRouter.FunctionClick += MenuRouter_FunctionClick;
            MenuRouter.OperationClick += MenuRouter_OperationClick;
            MenuRouter.TestTermsClick += MenuRouter_TestTermsClick;
        }

        #endregion

        #region Internal Methods

        internal bool Execute()
        {
            var result = View.ShowDialog(Form);
            return result == DialogResult.OK;
        }

        #endregion

        #region Private Fields

        private FilterForm _view;

        #endregion

        #region Private Properties

        private MenuRouter MenuRouter { get; }
        private ContextMenuStrip PopupMenu => View.PopupMenu;
        private ToolStripMenuItem TermMenu => View.TermMenu;
        private TermTreeViewController TermTreeViewController { get; }
        private TreeView TreeView => View.TreeView;
        private FilterForm View => _view ?? CreateFilterForm();

        #endregion

        #region Event Handlers

        private void MenuRouter_ConstantClick(object sender, EventArgs e) => AddConstant();
        private void MenuRouter_FieldClick(object sender, FieldEventArgs e) => AddField(e.Tag);
        private void MenuRouter_FunctionClick(object sender, FunctionEventArgs e) => AddFunction(e.Key);
        private void MenuRouter_OperationClick(object sender, OperationEventArgs e) => AddOperation(e.Op);
        private void MenuRouter_TestTermsClick(object sender, EventArgs e) => AddTestTerms();
        private void ViewCollapseAll_Click(object sender, EventArgs e) => TermTreeViewController.CollapseAll();
        private void ViewExpandAll_Click(object sender, EventArgs e) => TermTreeViewController.ExpandAll();

        #endregion

        #region Private Methods

        private void AddConstant() => TermTreeViewController.AddConstant();
        private void AddField(Tag tag) => TermTreeViewController.AddField(tag);
        private void AddFunction(string key) => TermTreeViewController.AddFunction(key);
        private void AddOperation(Op op) => TermTreeViewController.AddOperation(op);
        private void AddTestTerms() => TermTreeViewController.AddTestTerms();
        private FilterForm CreateFilterForm() => _view = new FilterForm();
        
        #endregion
    }
}
