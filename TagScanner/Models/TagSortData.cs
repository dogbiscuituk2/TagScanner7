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
        public static IEnumerable<TagSort> GetData(this ListViewItem item) =>
            new[] { new TagSort(item.Tag, item.StateImageIndex) };

        public static IEnumerable<TagSort> GetData(this ListViewItems items) =>
            items.Cast<ListViewItem>().Select(p => new TagSort(p.Tag, p.StateImageIndex));

        /// <summary>
        /// Get the Tag-based data from a TreeNode which may be a root, a category, or a leaf.
        /// </summary>
        /// <param name="node">The "ancestor" TreeNode.</param>
        /// <returns>All Tags attached to the ancestor and/or its leaves.</returns>
        public static IEnumerable<TagSort> GetData(this TreeNode node)
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

        /// <summary>
        /// Get the Tag-based data from an IDataObject containing one of the following formats:
        /// TreeNode, LisrtViewItem, or ListView.SelectedListViewItemCollection.
        /// </summary>
        /// <param name="data">The source IDataObject.</param>
        /// <returns>All Tags attached to the IDataObject.</returns>
        public static IEnumerable<TagSort> GetData(this IDataObject data) =>
            data.GetData(typeof(TreeNode)) is TreeNode node ? node.GetData() :
            data.GetData(typeof(ListViewItem)) is ListViewItem item ? item.GetData() :
            data.GetData(typeof(ListViewItems)) is ListViewItems items ? items.GetData() :
            Array.Empty<TagSort>();
    }
}
