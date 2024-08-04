﻿namespace TagScanner.Controllers
{
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Models;

    public partial class QueryController
    {
        #region Private Fields

        private Control _source;

        #endregion

        #region Event Handlers

        private void View_DragDrop(object sender, DragEventArgs e) => DragDrop((ListView)sender, e);
        private void View_DragOver(object sender, DragEventArgs e) => DragOver((ListView)sender, e);
        private void View_ItemDrag(object sender, ItemDragEventArgs e) => ItemDrag((Control)sender, e);
        private void View_MouseDown(object sender, MouseEventArgs e) => MouseDown((ListView)sender, e);
        private void View_QueryContinueDrag(object sender, QueryContinueDragEventArgs e) => QueryContinueDrag((Control)sender, e);

        #endregion

        #region Private Methods

        private void AddDragControls(params Control[] controls) => Array.ForEach(controls, control =>
        {
            if (control is ListView listView)
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
            else if (control is TreeView treeView)
                treeView.ItemDrag += View_ItemDrag;
        });

        private void DoDragDrop(ListView listView, DragEventArgs e, bool drop)
        {
            listView.Focus();
            var point = listView.PointToClient(new Point(e.X, e.Y));
            var target = listView.GetItemAt(point.X, point.Y);
            var index = target?.Index ?? listView.Items.Count;
            var selection = listView.SelectedIndices;
            if (!selection.Cast<int>().SequenceEqual(new[] { index }))
            {
                selection.Clear();
                if (target != null)
                    selection.Add(index);
            }
            e.Effect = listView == _source ? DragDropEffects.Move : DragDropEffects.Copy;
            if (drop)
            {
                var data = e.Data;
                var formats = e.Data.GetFormats();
                Merge(e.Data.ItemsFromDataObject());
            }
        }

        private void DragDrop(ListView listView, DragEventArgs e) => DoDragDrop(listView, e, drop: true);
        private void DragOver(ListView listView, DragEventArgs e) => DoDragDrop(listView, e, drop: false);

        private void ItemDrag(Control control, ItemDragEventArgs e)
        {
            _source = control;
            control.DoDragDrop(Focus.GetTagx(), DragDropEffects.All);
        }

        private void MouseDown(Control control, MouseEventArgs e)
        {
        }

        private void QueryContinueDrag(Control control, QueryContinueDragEventArgs e)
        {
        }

        #endregion
    }
}
