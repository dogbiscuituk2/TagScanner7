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

        internal event EventHandler<ConstantEventArgs> ConstantClick;
        internal event EventHandler<FieldEventArgs> FieldClick;
        internal event EventHandler<FunctionEventArgs> FunctionClick;
        internal event EventHandler<OperationEventArgs> OperationClick;
        internal event EventHandler TermDeleteClick, TermModifyClick;
        internal event EventHandler TestTermsClick;

        #endregion

        #region Private Methods

        private void OnConstantClick(int value) => ConstantClick?.Invoke(this, new ConstantEventArgs(value));
        private void OnFieldClick(Tag tag) => FieldClick?.Invoke(this, new FieldEventArgs(tag));
        private void OnOperationClick(Op op) => OperationClick?.Invoke(this, new OperationEventArgs(op));
        private void OnFunctionClick(string key) => FunctionClick?.Invoke(this, new FunctionEventArgs(key));
        private void OnTestTermsClick() => TestTermsClick?.Invoke(this, EventArgs.Empty);
        private void MenuRouter_TermDeleteClick(object sender, EventArgs e) => TermDeleteClick?.Invoke(this, e);
        private void MenuRouter_TermModifyClick(object sender, EventArgs e) => TermModifyClick?.Invoke(this, e);

        private void MenuRouter_TermClick(object sender, EventArgs e)
        {
            switch (((ToolStripMenuItem)sender).Tag)
            {
                case int value:
                    OnConstantClick(value);
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
                case null:
                    OnTestTermsClick();
                    break;
            }
        }

        #endregion
    }
}
