namespace TagScanner.Models
{
    using System;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>
    /// Reading the data from an IDataObject for the purposes of a Tag-based Drag/Drop or Clipboard operation.
    /// </summary>
    public static class TagxData
    {
        #region Public Methods

        public static void CopyToClipboard(this Control control) => Clipboard.SetDataObject(control.GetTagxData());

        public static TagxList GetTagxData(this Control control)
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

        public static bool IsOnClipboard() => ClipboardData?.HasTagxData() ?? false;
        
        public static TagxItemList ItemsFromClipboard() => FromClipboard().ToTagxItems();

        public static TagxItemList ItemsFromDataObject(this IDataObject data) => data.GetTagxData().ToTagxItems();

        #endregion

        #region Private Properties

        private static readonly Type TagxListType = typeof(TagxList);

        #endregion

        #region Private Methods

        private static IDataObject ClipboardData => Clipboard.GetDataObject();

        private static TagxList FromClipboard() => ClipboardData.GetTagxData();

        private static TagxList GetTagxData(this IDataObject data) => (TagxList)data.GetData(TagxListType);

        private static bool HasTagxData(this IDataObject data) => data.GetDataPresent(TagxListType);

        private static TagxItemList ToTagxItems(this TagxList tags) => (TagxItemList)tags.Select(tag => new TagxItem(tag)).ToList();

        #endregion
    }
}
