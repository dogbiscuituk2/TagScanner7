namespace TagScanner.Menus
{
    using System;
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
        private void OnFieldClick(Tag tag) => FieldClick?.Invoke(this, new FieldEventArgs(tag));
        private void OnOperationClick(Op op) => OperationClick?.Invoke(this, new OperationEventArgs(op));
        private void OnFunctionClick(string key) => FunctionClick?.Invoke(this, new FunctionEventArgs(key));
        private void MenuRouter_TermDeleteClick(object sender, EventArgs e) => TermDeleteClick?.Invoke(this, e);
        private void MenuRouter_TermModifyClick(object sender, EventArgs e) => TermModifyClick?.Invoke(this, e);

        private void MenuRouter_TermClick(object sender, EventArgs e)
        {
            var foo = ((ToolStripMenuItem)sender).Tag;
            switch (foo)
            {
                case null:
                    OnConstantClick();
                    break;
                case Tag tag:
                    OnFieldClick(tag);
                    break;
                case Op op:
                    OnOperationClick(op);
                    break;
                case string key:
                    OnFunctionClick(key);
                    break;
            }
        }

        #endregion
    }
}
