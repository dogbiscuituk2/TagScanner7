namespace TagScanner.Menus
{
    using System;
    using System.Windows.Forms;
    using Models;
    using Terms;

    public class MenuRouter
    {
        #region Constructor

        public MenuRouter(ToolStripDropDownItem termMenu, ToolStripDropDown popupMenu)
        {
            var items = popupMenu.Items;
            MenuMaker.AddAllTerms(items, MenuRouter_TermClick);
            items.Add(new ToolStripMenuItem("Modify...", null, MenuRouter_TermModifyClick));
            items.Add(new ToolStripMenuItem("Delete...", null, MenuRouter_TermDeleteClick));
            termMenu.DropDown = popupMenu;
        }

        #endregion

        #region Internal Events

        public event EventHandler<CastEventArgs> CastClick;
        public event EventHandler<ConstantEventArgs> ConstantClick;
        public event EventHandler<FieldEventArgs> FieldClick;
        public event EventHandler<FunctionEventArgs> FunctionClick;
        public event EventHandler<OperationEventArgs> OperationClick;
        public event EventHandler TermDeleteClick, TermModifyClick;
        public event EventHandler TestTermsClick;

        #endregion

        #region Private Methods

        private void OnConstantClick(int value) => ConstantClick?.Invoke(this, new ConstantEventArgs(value));
        private void OnFieldClick(Tag tag) => FieldClick?.Invoke(this, new FieldEventArgs(tag));
        private void OnOperationClick(Op op) => OperationClick?.Invoke(this, new OperationEventArgs(op));
        private void OnFunctionClick(Fn fn) => FunctionClick?.Invoke(this, new FunctionEventArgs(fn));
        private void OnCastClick(Type type) => CastClick?.Invoke(this, new CastEventArgs(type));
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
                case Fn fn:
                    OnFunctionClick(fn);
                    break;
                case Type type:
                    OnCastClick(type);
                    break;
                case null:
                    OnTestTermsClick();
                    break;
            }
        }

        #endregion
    }
}
