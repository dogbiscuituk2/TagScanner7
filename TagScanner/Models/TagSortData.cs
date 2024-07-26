namespace TagScanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using ListViewItems = System.Windows.Forms.ListView.SelectedListViewItemCollection;

    /// <summary>
    /// Reading the data from an IDataObject for the purposes of a Tag-based Drag/Drop or Clipboard operation.
    /// </summary>
    public static class TagSortData
    {
        /// <summary>
        /// Get the Tag-based data from an IDataObject containing one of the following formats:
        /// TreeNode, LisrtViewItem, or ListView.SelectedListViewItemCollection.
        /// </summary>
        /// <param name="data">The source IDataObject.</param>
        /// <returns>All Tags attached to the IDataObject.</returns>
        public static IEnumerable<TagSort> GetTagSortData(this IDataObject data) =>
            data.GetData(typeof(TreeNode)) is TreeNode node ? node.GetTagSortData() :
            data.GetData(typeof(ListViewItem)) is ListViewItem item ? item.GetTagSortData() :
            data.GetData(typeof(ListViewItems)) is ListViewItems items ? items.GetTagSortData() :
            Array.Empty<TagSort>();

        /// <summary>
        /// Get the Tag-based data from a TreeNode which may be a root, a category, or a leaf.
        /// </summary>
        /// <param name="node">The "ancestor" TreeNode.</param>
        /// <returns>All Tags attached to the ancestor and/or its leaves.</returns>
        public static IEnumerable<TagSort> GetTagSortData(this TreeNode node)
        {
            var data = new List<TagSort>();
            Visit(node);
            return data;

            void Visit(TreeNode parent)
            {
                if (parent.Tag is Tag tag)
                    data.Add(new TagSort(tag));
                else
                {
                    var nodes = parent.Nodes;
                    if (nodes.Count > 0)
                        foreach (TreeNode child in nodes)
                            Visit(child);
                }
            }
        }

        public static IEnumerable<ListViewItem> GetTagSortItems(this IDataObject data) =>
            data.GetData(typeof(TreeNode)) is TreeNode node ? node.GetTagSortItems() :
            data.GetData(typeof(ListViewItem)) is ListViewItem item ? new[] { item } :
            data.GetData(typeof(ListViewItems)) is ListViewItems items ? items.Cast<ListViewItem>() :
            Array.Empty<ListViewItem>();

        public static IEnumerable<ListViewItem> GetTagSortItems(this ListViewItems items) =>
            items.Cast<ListViewItem>();

        public static IEnumerable<ListViewItem> GetTagSortItems(this TreeNode node) =>
            node.GetTagSortData().ToTagSortItems();

        public static bool HasTagSortData(this IDataObject data) => data.GetTagSortData().Any();

        public static IEnumerable<TagSort> GetTagSortData(this ListViewItem item) =>
            new[] { new TagSort(item.Tag, item.StateImageIndex) };

        public static IEnumerable<TagSort> GetTagSortData(this ListViewItems items) =>
            items.Cast<ListViewItem>().Select(p => new TagSort(p.Tag, p.StateImageIndex));

        public static IEnumerable<ListViewItem> ToTagSortItems(this IEnumerable<TagSort> data) =>
            data.Select(p => new TagListItem(p.Tag));
    }
}
