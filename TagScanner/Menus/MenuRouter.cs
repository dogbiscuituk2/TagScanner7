namespace TagScanner.Menus
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using Models;
    using Terms;

    public class MenuRouter
    {
        public MenuRouter(ToolStripItemCollection items) => MenuMaker.AddAllTerms(items, MenuRouter_TermClick);
        
        public static void MoveItems(ToolStripItemCollection from, ToolStripItemCollection to) => to.AddRange(from.OfType<ToolStripItem>().ToArray());

        public event EventHandler<ConstantEventArgs> ConstantClick;
        public event EventHandler<FieldEventArgs> FieldClick;
        public event EventHandler<FunctionEventArgs> FunctionClick;
        public event EventHandler<OperationEventArgs> OperationClick;

        protected virtual void OnConstantClick() => ConstantClick?.Invoke(this, new ConstantEventArgs());
        protected virtual void OnFieldClick(TagProps tagProps) => FieldClick?.Invoke(this, new FieldEventArgs(tagProps));
        protected virtual void OnOperationClick(KeyValuePair<Op, OpInfo> op) => OperationClick?.Invoke(this, new OperationEventArgs(op));
        protected virtual void OnFunctionClick(KeyValuePair<string, MethodInfo> method) => FunctionClick?.Invoke(this, new FunctionEventArgs(method));

        private void MenuRouter_TermClick(object sender, EventArgs e)
        {
            var tag = ((ToolStripMenuItem)sender).Tag;
            switch (tag)
            {
                case null:
                    OnConstantClick();
                    break;
                case TagProps field:
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
    }
}
