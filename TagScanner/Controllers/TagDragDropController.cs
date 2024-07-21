namespace TagScanner.Controllers
{
    using System;
    using System.Windows.Forms;

    public class TagDragDropController : Controller
    {
        #region Constructor

        public TagDragDropController(Controller parent, params Control[] controls) : base(parent)
        {
            foreach (var control in controls)
                Add(control);
        }

        #endregion

        #region Public Methods

        public void Add(params Control[] controls)
        {
            foreach (var control in controls)
                ProcessControl(control, add: true);
        }

        public void Remove(params Control[] controls)
        {
            foreach (var control in controls)
                ProcessControl(control, add: false);
        }

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
        }

        private void ItemDrag(Control control, ItemDragEventArgs e)
        {
            if (control is ListView listView && listView.SelectedItems.Count > 1)
            {
                listView.DoDragDrop(listView.SelectedItems, DragDropEffects.All);
            }
            else
                control.DoDragDrop(e.Item, DragDropEffects.All);
        }

        private void MouseDown(Control control, MouseEventArgs e)
        {
        }

        private void ProcessControl(Control control, bool add)
        {
            if (control is ListView listView)
                ProcessListView(listView, add);
            else if (control is TreeView treeView)
                ProcessTreeView(treeView, add);
        }

        private void ProcessListView(ListView listView, bool add)
        {
            if (add)
            {
                listView.AllowDrop = true;
                listView.DragDrop += View_DragDrop;
                listView.DragOver += View_DragOver;
                listView.ItemDrag += View_ItemDrag;
                listView.MouseDown += View_MouseDown;
                listView.QueryContinueDrag += View_QueryContinueDrag;
            }
            else
            {
                listView.DragDrop -= View_DragDrop;
                listView.DragOver -= View_DragOver;
                listView.ItemDrag -= View_ItemDrag;
                listView.MouseDown -= View_MouseDown;
                listView.QueryContinueDrag -= View_QueryContinueDrag;
            }
        }

        private void ProcessTreeView(TreeView treeView, bool add)
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
