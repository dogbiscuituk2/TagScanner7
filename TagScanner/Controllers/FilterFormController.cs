namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Windows.Forms;
    using Menus;
    using Models;
    using Terms;
    using Views;

    internal class FilterFormController : Controller
    {
        #region Constructor

        internal FilterFormController(LibraryFormController parent) : base(parent)
        {
            TermTreeViewController = new TermTreeViewController(this, TreeView);
            MenuRouter = new MenuRouter(TermMenu, PopupMenu);
            MenuRouter.ConstantClick += MenuRouter_ConstantClick;
            MenuRouter.FieldClick += MenuRouter_FieldClick;
            MenuRouter.FunctionClick += MenuRouter_FunctionClick;
            MenuRouter.OperationClick += MenuRouter_OperationClick;
            PopupMenu.Opening += PopupMenu_Opening;
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
        private void MenuRouter_FieldClick(object sender, FieldEventArgs e) => AddField(e.TagProps);
        private void MenuRouter_FunctionClick(object sender, FunctionEventArgs e) => AddFunction(e.Method);
        private void MenuRouter_OperationClick(object sender, OperationEventArgs e) => AddOperation(e.Operation);

        private void PopupMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        #endregion

        #region Private Methods

        private void AddConstant() => TermTreeViewController.AddConstant();
        private void AddField(TagProps tagProps) => TermTreeViewController.AddField(tagProps);
        private void AddFunction(KeyValuePair<string, MethodInfo> method) => TermTreeViewController.AddFunction(method);
        private void AddOperation(KeyValuePair<Op, OpInfo> operation) => TermTreeViewController.AddOperation(operation);
        private FilterForm CreateFilterForm() => _view = new FilterForm();
        
        #endregion
    }
}
