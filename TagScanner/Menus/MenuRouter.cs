namespace TagScanner.Menus
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using TagScanner.Models;
    using TagScanner.Terms;

    public class MenuRouter
    {
        public MenuRouter(ToolStripItemCollection items)
        {
            MenuMakerBasic.AddAllTerms(items, MenuRouter_TermClick);
            TermClick += MenuRouter_TermClick;
        }

        public void FilterItems(Filter action, params Type[] types) => Items.FilterItems(action, types);

        public static void MoveItems(ToolStripItemCollection from, ToolStripItemCollection to) => to.AddRange(from.OfType<ToolStripItem>().ToArray());

        public event EventHandler TermClick;
        public event EventHandler<ConstantEventArgs> ConstantClick;
        public event EventHandler<FieldEventArgs> FieldClick;
        public event EventHandler<FunctionEventArgs> FunctionClick;
        public event EventHandler<OperationEventArgs> OperationClick;

        protected virtual void OnConstantClick() => ConstantClick?.Invoke(this, new ConstantEventArgs());
        protected virtual void OnFieldClick(TagProps tagProps) => FieldClick?.Invoke(this, new FieldEventArgs(tagProps));
        protected virtual void OnOperationClick(KeyValuePair<Op, OpInfo> op) => OperationClick?.Invoke(this, new OperationEventArgs(op));
        protected virtual void OnFunctionClick(KeyValuePair<string, MethodInfo> method) => FunctionClick?.Invoke(this, new FunctionEventArgs(method));

        private ToolStripItemCollection Items;

        private void MenuRouter_TermClick(object sender, EventArgs e)
        {
            var tag = ((ToolStripMenuItem)sender).Tag;
            if (tag == null) OnConstantClick();
            else if (tag is TagProps field) OnFieldClick(field);
            else if (tag is KeyValuePair<Op, OpInfo> operation) OnOperationClick(operation);
            else if (tag is KeyValuePair<string, MethodInfo> function) OnFunctionClick(function);
        }
    }
}
