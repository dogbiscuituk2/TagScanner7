namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Windows.Forms;
    using TagScanner.Menus;
    using TagScanner.Models;
    using TagScanner.Terms;
    using TagScanner.Views;

    public class FilterFormController : Controller
    {
        #region Constructor

        public FilterFormController(LibraryFormController parent) : base(parent)
        {
            TermTreeViewController = new TermTreeViewController(this, TreeView);

            MenuRouter = new MenuRouter(TermMenuItems);
            MenuRouter.ConstantClick += MenuRouter_ConstantClick;
            MenuRouter.FieldClick += MenuRouter_FieldClick;
            MenuRouter.FunctionClick += MenuRouter_FunctionClick;
            MenuRouter.OperationClick += MenuRouter_OperationClick;

            TermMenu.DropDownOpening += TermMenu_DropDownOpening;
            TreeView.MouseDown += TreeView_MouseDown;

            TagPickerController tagPickerController = new TagPickerController(View.FieldComboBox);
            OperatorPickerController operatorPickerController = new OperatorPickerController(View.OperatorComboBox);

            PopupMenu.Opening += PopupMenu_Opening;
            View.btnAddRoot.Click += BtnAddRoot_Click;
        }

        #endregion

        #region Public Methods

        public void Show() => View.ShowDialog(Form);

        #endregion

        #region Private Fields

        private MenuRouter MenuRouter;
        private ContextMenuStrip PopupMenu => View.PopupMenu;
        private ToolStripItemCollection PopupMenuItems => PopupMenu.Items;
        private ToolStripMenuItem TermMenu => View.TermMenu;
        private ToolStripItemCollection TermMenuItems => TermMenu.DropDownItems;
        private TermTreeViewController TermTreeViewController;
        private TreeView TreeView => View.TreeView;
        private FilterForm _view;

        #endregion

        #region Event Handlers

        private void MenuRouter_ConstantClick(object sender, ConstantEventArgs e) => AddConstant();
        private void MenuRouter_FieldClick(object sender, FieldEventArgs e) => AddField(e.TagProps);
        private void MenuRouter_FunctionClick(object sender, FunctionEventArgs e) => AddFunction(e.Method);
        private void MenuRouter_OperationClick(object sender, OperationEventArgs e) => AddOperation(e.Operation);
        private void TermClick(object sender, EventArgs e) { }
        private void TermMenu_DropDownOpening(object sender, EventArgs e) => MovePopupItemsToMainMenu();
        private void TreeView_MouseDown(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Right) MoveMainMenuItemsToPopup(); }

        private void PopupMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var nodeSelected = TermTreeViewController.HasSelection;

        }

        private void BtnAddRoot_Click(object sender, System.EventArgs e)
        {
            Constant
                one = (Constant)1,
                two = (Constant)2,
                three = (Constant)3,
                four = (Constant)4,
                five = (Constant)5;
            var term1 = new Operation(Tag.Album, '=', "Greatest Hits");
            var term2 = new Operation(Tag.JoinedPerformers, "!=", "ABBA");
            var term3 = new Operation("<", 1999, Tag.Year, 2001);
            var term4 = new Operation(Tag.Title, "<=", "Money Money Money");
            var term5 = one + two + three + four + five;
            var term = (term1 | term2) & (term3 | term4) & term5;
            TermTreeViewController.AddRoot(term);
        }

        #endregion

        #region Private Properties

        private FilterForm View => _view ?? CreateFilterForm();

        private FilterForm CreateFilterForm() => _view = new FilterForm();

        #endregion

        #region Private Methods

        private void AddConstant() => TermTreeViewController.AddConstant();
        private void AddField(TagProps tagProps) => TermTreeViewController.AddField(tagProps);
        private void AddFunction(KeyValuePair<string, MethodInfo> method) => TermTreeViewController.AddFunction(method);
        private void AddOperation(KeyValuePair<Op, OpInfo> operation) => TermTreeViewController.AddOperation(operation);
        private void MovePopupItemsToMainMenu() => MenuRouter.MoveItems(PopupMenuItems, TermMenuItems);
        private void MoveMainMenuItemsToPopup() => MenuRouter.MoveItems(TermMenuItems, PopupMenuItems);
        
        #endregion
    }
}
