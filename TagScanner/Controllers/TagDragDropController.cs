namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public class TagDragDropController : Controller
    {
        #region Constructor

        public TagDragDropController(Controller parent, params Control[] controls) : base(parent) => Add(controls);

        #endregion

        #region Public Methods

        public void Add(params Control[] controls) => Process(controls, add: true);
        public void Remove(params Control[] controls) => Process(controls, add: false);

        #endregion

        #region Event Handlers

        private void View_DragDrop(object sender, DragEventArgs e) => DragDrop((ListView)sender, e);
        private void View_DragOver(object sender, DragEventArgs e) => DragOver((ListView)sender, e);
        private void View_ItemDrag(object sender, ItemDragEventArgs e) => ItemDrag((Control)sender, e);
        private void View_MouseDown(object sender, MouseEventArgs e) => MouseDown((ListView)sender, e);
        private void View_QueryContinueDrag(object sender, QueryContinueDragEventArgs e) => QueryContinueDrag((Control)sender, e);

        #endregion

        #region Private Methods

        private void DragDrop(ListView listView, DragEventArgs e)
        {
            var data = e.Data;
            var formats = data.GetFormats();
            object foo;
            foreach (var format in formats)
                foo = data.GetData(format);
        }

        private void DragOver(ListView listView, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            var foo = listView.InsertionMark;
        }

        private void ItemDrag(Control control, ItemDragEventArgs e)
        {
            if (control is ListView listView && listView.SelectedItems.Count > 1)
                listView.DoDragDrop(listView.SelectedItems, DragDropEffects.All);
            else
                control.DoDragDrop(e.Item, DragDropEffects.All);
        }

        private void MouseDown(Control control, MouseEventArgs e)
        {
        }

        private void Process(IEnumerable<Control> controls, bool add)
        {
            foreach (var control in controls)
                if (control is ListView listView)
                    Process(listView, add);
                else if (control is TreeView treeView)
                    Process(treeView, add);
                else
                    throw new NotImplementedException();
        }

        private void Process(ListView listView, bool add)
        {
            if (add)
            {
                listView.MouseDown += View_MouseDown;
                listView.ItemDrag += View_ItemDrag;
                listView.QueryContinueDrag += View_QueryContinueDrag;
                if (listView.AllowDrop)
                {
                    listView.DragDrop += View_DragDrop;
                    listView.DragOver += View_DragOver;
                }
            }
            else
            {
                listView.MouseDown -= View_MouseDown;
                listView.ItemDrag -= View_ItemDrag;
                listView.QueryContinueDrag -= View_QueryContinueDrag;
                if (listView.AllowDrop)
                {
                    listView.DragDrop -= View_DragDrop;
                    listView.DragOver -= View_DragOver;
                }
            }
        }

        private void Process(TreeView treeView, bool add)
        {
            if (add)
                treeView.ItemDrag += View_ItemDrag;
            else
                treeView.ItemDrag -= View_ItemDrag;
        }

        private void QueryContinueDrag(Control control, QueryContinueDragEventArgs e)
        {
        }

        #endregion
    }
}
