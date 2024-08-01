namespace TagScanner.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>
    /// Reading Tagx data for the purposes of a Tag-based Drag/Drop or Clipboard operation.
    /// </summary>
    public static class TagxData
    {
        #region Public Methods

        public static void CopyToClipboard(this Control control) => Clipboard.SetDataObject(control?.GetTagx());

        public static List<Tagx> GetTagx(this Control control)
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

        public static bool IsOnClipboard() => ClipboardData?.HasTagx() ?? false;
        
        public static TagxItemList ItemsFromClipboard() => FromClipboard()?.ToItems();

        public static TagxItemList ItemsFromDataObject(this IDataObject data) => data?.GetTagx()?.ToItems();

        #endregion

        #region Private Properties

        //private static readonly Type TagxListType = typeof(TagxList);

        #endregion

        #region Private Methods

        private static IDataObject ClipboardData => Clipboard.GetDataObject();

        private static List<Tagx> FromClipboard() => ClipboardData?.GetTagx();

        //private static TagxList GetTagx(this IDataObject data) => (TagxList)data?.GetData(TagxListType);

        private static List<Tagx> GetTagx(this IDataObject data)
        {
            var list = data?.GetData(typeof(List<Tagx>));
            var formats = data.GetFormats();
            return(List<Tagx>)list;
        }

        private static bool HasTagx(this IDataObject data) => data?.GetDataPresent(typeof(List<Tagx>)) ?? false;

        private static TagxItemList ToItems(this List<Tagx> tags) => (TagxItemList)tags?.Select(tag => new TagxItem(tag)).ToList();

        #endregion
    }
}
