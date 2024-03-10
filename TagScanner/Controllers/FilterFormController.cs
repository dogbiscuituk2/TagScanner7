namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using TagScanner.Menus;
    using TagScanner.Models;
    using TagScanner.Terms;
    using TagScanner.Views;

    public class FilterFormController : Controller
    {
        #region Constructor

        public FilterFormController(LibraryFormController parent) : base(parent)
        {
            TermTreeViewController = new TermTreeViewController(this, View.TreeView);
            MenuRouter = new MenuRouter(View.PopupAdd.DropDownItems);
            MenuRouter.ConstantClick += MenuRouter_ConstantClick;
            MenuRouter.FieldClick += MenuRouter_FieldClick;
            MenuRouter.FunctionClick += MenuRouter_FunctionClick;
            MenuRouter.OperationClick += MenuRouter_OperationClick;

            TagPickerController tagPickerController = new TagPickerController(View.FieldComboBox);
            OperatorPickerController operatorPickerController = new OperatorPickerController(View.OperatorComboBox);

            View.PopupMenu.Opening += PopupMenu_Opening;
            View.PopupEdit.Click += PopupEditNode_Click;
            View.PopupDelete.Click += PopupDeleteNode_Click;
            View.btnAddRoot.Click += BtnAddRoot_Click;
        }

        #endregion

        #region Public Methods

        public void Show() => View.ShowDialog(Form);

        #endregion

        #region Private Fields

        private MenuRouter MenuRouter;
        private TermTreeViewController TermTreeViewController;
        private FilterForm _view;

        #endregion

        #region Event Handlers

        private void MenuRouter_ConstantClick(object sender, ConstantEventArgs e) => AddConstant();
        private void MenuRouter_FieldClick(object sender, FieldEventArgs e) => AddField(e.TagProps);
        private void MenuRouter_FunctionClick(object sender, FunctionEventArgs e) => AddFunction(e.Method);
        private void MenuRouter_OperationClick(object sender, OperationEventArgs e) => AddOperation(e.Operation);
        private void TermClick(object sender, EventArgs e) { }

        private void PopupMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var nodeSelected = TermTreeViewController.HasSelection;
            View.PopupAdd.Enabled = true;
            View.PopupEdit.Enabled = nodeSelected;
            View.PopupDelete.Enabled = nodeSelected;
        }

        private void PopupDeleteNode_Click(object sender, System.EventArgs e) => DeleteNode();
        private void PopupEditNode_Click(object sender, System.EventArgs e) => EditNode();

        private void BtnAddRoot_Click(object sender, System.EventArgs e)
        {
            Constant
                one = new Constant(1),
                two = new Constant(2),
                three = new Constant(3),
                four = new Constant(4),
                five = new Constant(5);
            var term1 = new Operation(new Field("Album"), '=', "Greatest Hits");
            var term2 = new Operation(new Field("JoinedPerformers"), "!=", "ABBA");
            var term3 = new Operation("<", 1999, new Field("Year"), 2001);
            var term4 = new Operation(new Field("Title"), "<=", "Money Money Money");
            var term5 = one + two + three + four + five;
            var term = (term1 | term2) & (term3 | term4) & term5;
            TermTreeViewController.AddRoot(term);
        }

        #endregion

        #region Private Methods

        private FilterForm View => _view ?? CreateFilterForm();

        private FilterForm CreateFilterForm() => _view = new FilterForm();

        private void DeleteNode() { }
        private void EditNode() { }

        private void AddConstant() => TermTreeViewController.AddConstant();
        private void AddField(TagProps tagProps) => TermTreeViewController.AddField(tagProps);
        private void AddFunction(KeyValuePair<string, MethodInfo> method) => TermTreeViewController.AddFunction(method);
        private void AddOperation(KeyValuePair<Op, OpInfo> operation) => TermTreeViewController.AddOperation(operation);
        
        #endregion
    }
}
