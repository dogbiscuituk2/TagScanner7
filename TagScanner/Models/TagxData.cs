namespace TagScanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>
    /// Reading Tagx data for the purposes of a Tag-based Drag/Drop or Clipboard operation.
    /// </summary>
    public static class TagxData
    {
        #region Public Methods

        public static void CopyToClipboard(this Control control) => Clipboard.SetDataObject(control?.GetSelectedTagx());

        public static List<Tagx> FromClipboard() => ClipboardData?.GetTagx() ?? new List<Tagx>();

        public static List<Tagx> GetAllTagx(this ListView listView)
        {
            return listView.Items.Cast<ListViewItem>().Select(p => new Tagx((Tag)p.Tag, p.StateImageIndex)).ToList();
        }

        public static List<Tagx> GetSelectedTagx(this Control control)
        {
            var list = new List<Tagx>();
            if (control is ListView listView)
                list.AddRange(listView.SelectedItems.Cast<ListViewItem>().Select(p => new Tagx((Tag)p.Tag, p.StateImageIndex)));
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

        public static TagxItem[] ToItems(this IEnumerable<Tagx> tags) => tags?.Select(tag => new TagxItem(tag)).ToArray();

        public static List<Tagx> ToTagxList(this IDataObject data) => data?.GetTagx() ?? new List<Tagx>();

        //public static List<TagxItem> ItemsFromClipboard() => FromClipboard()?.ToItems();

        //public static List<TagxItem> ItemsFromDataObject(this IDataObject data) => data?.GetTagx()?.ToItems();

        #endregion

        #region Private Properties

        private static Type TagxListType => typeof(List<Tagx>);

        #endregion

        #region Private Methods

        private static IDataObject ClipboardData => Clipboard.GetDataObject();

        private static List<Tagx> GetTagx(this IDataObject data) => (List<Tagx>)data?.GetData(TagxListType);

        private static bool HasTagx(this IDataObject data) => data?.GetDataPresent(TagxListType) ?? false;

        #endregion
    }
}
