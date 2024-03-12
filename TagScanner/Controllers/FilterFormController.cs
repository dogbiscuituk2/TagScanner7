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

    public class FilterFormController : Controller
    {
        #region Constructor

        public FilterFormController(LibraryFormController parent) : base(parent)
        {
            _termTreeViewController = new TermTreeViewController(this, TreeView);

            _menuRouter = new MenuRouter(TermMenuItems);
            _menuRouter.ConstantClick += MenuRouter_ConstantClick;
            _menuRouter.FieldClick += MenuRouter_FieldClick;
            _menuRouter.FunctionClick += MenuRouter_FunctionClick;
            _menuRouter.OperationClick += MenuRouter_OperationClick;

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

        private readonly MenuRouter _menuRouter;
        private readonly TermTreeViewController _termTreeViewController;
        private FilterForm _view;

        #endregion

        #region Private Properties

        private ContextMenuStrip PopupMenu => View.PopupMenu;
        private ToolStripItemCollection PopupMenuItems => PopupMenu.Items;
        private TreeView TreeView => View.TreeView;
        private ToolStripMenuItem TermMenu => View.TermMenu;
        private ToolStripItemCollection TermMenuItems => TermMenu.DropDownItems;
        private FilterForm View => _view ?? CreateFilterForm();

        #endregion

        #region Event Handlers

        private void MenuRouter_ConstantClick(object sender, ConstantEventArgs e) => AddConstant();
        private void MenuRouter_FieldClick(object sender, FieldEventArgs e) => AddField(e.TagProps);
        private void MenuRouter_FunctionClick(object sender, FunctionEventArgs e) => AddFunction(e.Method);
        private void MenuRouter_OperationClick(object sender, OperationEventArgs e) => AddOperation(e.Operation);
        private void TermMenu_DropDownOpening(object sender, EventArgs e) => MovePopupItemsToMainMenu();
        private void TreeView_MouseDown(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Right) MoveMainMenuItemsToPopup(); }

        private void PopupMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var nodeSelected = _termTreeViewController.HasSelection;

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
            var term6 = new Constant("123") + new Constant("456") + new Constant("789") + new Constant("abc") + new Constant("def");
            var term = (term1 | term2) & (term3 | term4) & term5 & term6;
            _termTreeViewController.AddRoot(term);
        }

        #endregion

        #region Private Methods

        private void AddConstant() => _termTreeViewController.AddConstant();
        private void AddField(TagProps tagProps) => _termTreeViewController.AddField(tagProps);
        private void AddFunction(KeyValuePair<string, MethodInfo> method) => _termTreeViewController.AddFunction(method);
        private void AddOperation(KeyValuePair<Op, OpInfo> operation) => _termTreeViewController.AddOperation(operation);
        private FilterForm CreateFilterForm() => _view = new FilterForm();
        private void MovePopupItemsToMainMenu() => MenuRouter.MoveItems(PopupMenuItems, TermMenuItems);
        private void MoveMainMenuItemsToPopup() => MenuRouter.MoveItems(TermMenuItems, PopupMenuItems);
        
        #endregion
    }
}
