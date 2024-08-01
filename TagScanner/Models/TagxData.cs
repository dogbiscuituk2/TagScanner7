namespace TagScanner.Models
{
    using System;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>
    /// Reading Tagx data for the purposes of a Tag-based Drag/Drop or Clipboard operation.
    /// </summary>
    public static class TagxData
    {
        #region Public Methods

        public static void CopyToClipboard(this Control control) => Clipboard.SetDataObject(control?.GetTagx());

        public static TagxList GetTagx(this Control control)
        {
            var list = new TagxList();
            if (control is ListView listView)
                list.AddRange(listView.SelectedItems.Cast<ListViewItem>().Select(p => new Tagx(p.Tag, p.StateImageIndex)));
            else if (control is TreeView treeView)
                Visit(treeView.SelectedNode);
            return list;

            void Visit(TreeNode parent)
            {
                if (parent.Tag is Tag tag)
                    list.Add(new Tagx(tag));
                else
                {
                    var nodes = parent.Nodes;
                    if (nodes.Count > 0)
                        foreach (TreeNode child in nodes)
                            Visit(child);
                }
            }
        }

        public static bool IsOnClipboard() => ClipboardData?.HasTagx() ?? false;
        
        public static TagxItemList ItemsFromClipboard() => FromClipboard()?.ToItems();

        public static TagxItemList ItemsFromDataObject(this IDataObject data) => data?.GetTagx()?.ToItems();

        #endregion

        #region Private Properties

        private static readonly Type TagxListType = typeof(TagxList);

        #endregion

        #region Private Methods

        private static IDataObject ClipboardData => Clipboard.GetDataObject();

        private static TagxList FromClipboard() => ClipboardData?.GetTagx();

        private static TagxList GetTagx(this IDataObject data) => (TagxList)data?.GetData(TagxListType);

        private static bool HasTagx(this IDataObject data) => data?.GetDataPresent(TagxListType) ?? false;

        private static TagxItemList ToItems(this TagxList tags) => (TagxItemList)tags?.Select(tag => new TagxItem(tag)).ToList();

        #endregion
    }
}
