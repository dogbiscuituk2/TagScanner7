namespace TagScanner.Menus
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Windows.Forms;
    using Models;
    using Terms;

    internal class MenuRouter
    {
        #region Constructor

        internal MenuRouter(ToolStripDropDownItem termMenu, ToolStripDropDown popupMenu)
        {
            var items = popupMenu.Items;
            MenuMaker.AddAllTerms(items, MenuRouter_TermClick);
            items.Add(new ToolStripMenuItem("Modify...", null, MenuRouter_TermModifyClick));
            items.Add(new ToolStripMenuItem("Delete...", null, MenuRouter_TermDeleteClick));
            termMenu.DropDown = popupMenu;
        }

        #endregion

        #region Internal Events

        internal event EventHandler ConstantClick, TermModifyClick, TermDeleteClick;
        internal event EventHandler<FieldEventArgs> FieldClick;
        internal event EventHandler<FunctionEventArgs> FunctionClick;
        internal event EventHandler<OperationEventArgs> OperationClick;

        #endregion

        #region Private Methods

        private void OnConstantClick() => ConstantClick?.Invoke(this, EventArgs.Empty);
        private void OnFieldClick(TagInfo tagInfo) => FieldClick?.Invoke(this, new FieldEventArgs(tagInfo));
        private void OnOperationClick(KeyValuePair<Op, OpInfo> op) => OperationClick?.Invoke(this, new OperationEventArgs(op));
        private void OnFunctionClick(KeyValuePair<string, MethodInfo> method) => FunctionClick?.Invoke(this, new FunctionEventArgs(method));
        private void MenuRouter_TermDeleteClick(object sender, EventArgs e) => TermDeleteClick?.Invoke(this, e);
        private void MenuRouter_TermModifyClick(object sender, EventArgs e) => TermModifyClick?.Invoke(this, e);

        private void MenuRouter_TermClick(object sender, EventArgs e)
        {
            var tag = ((ToolStripMenuItem)sender).Tag;
            switch (tag)
            {
                case null:
                    OnConstantClick();
                    break;
                case TagInfo field:
                    OnFieldClick(field);
                    break;
                case KeyValuePair<Op, OpInfo> operation:
                    OnOperationClick(operation);
                    break;
                case KeyValuePair<string, MethodInfo> function:
                    OnFunctionClick(function);
                    break;
            }
        }

        #endregion
    }
}
