namespace TagScanner.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>
    /// Reading the data from an IDataObject for the purposes of a Tag-based Drag/Drop or Clipboard operation.
    /// </summary>
    public static class TagxData
    {
        #region Public Methods

        public static List<Tagx> FromClipboard() => ClipboardData.GetTagxData();

        public static List<Tagx> GetTagxData(this Control control)
        {
            var list = new List<Tagx>();
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

        public static List<Tagx> GetTagxData(this IDataObject data) => (List<Tagx>)data.GetData(typeof(List<Tagx>));

        public static bool HasTagxData(this IDataObject data) => data.GetDataPresent(typeof(List<Tagx>));

        public static bool InClipboard() => ClipboardData?.HasTagxData() ?? false;

        public static List<TagxItem> ItemsFromClipboard() => FromClipboard().ToTagxItems();

        public static List<TagxItem> ItemsFromDataObject(this IDataObject data) => data.GetTagxData().ToTagxItems();

        public static void ToClipboard(this Control control) => Clipboard.SetDataObject(control.GetTagxData());

        #endregion

        #region Private Methods

        private static IDataObject ClipboardData => Clipboard.GetDataObject();

        private static List<TagxItem> ToTagxItems(this List<Tagx> tags) => tags.Select(p => new TagxItem(p)).ToList();

        #endregion
    }
}
