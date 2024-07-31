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
        public static bool InClipboard() => Clipboard.GetDataObject()?.HasTagxData() ?? false;

        public static List<Tagx> FromClipboard() => (List<Tagx>)Clipboard.GetDataObject()?.GetData(typeof(List<Tagx>));

        public static List<Tagx> FromControl(Control control)
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

        public static bool HasTagxData(this IDataObject data) => data.GetDataPresent(typeof(List<Tagx>));

        public static TagxItem[] l

        public static List<TagxItem> ToTagxItems(this List<Tagx> tags) => tags.Select(p => new TagxItem(p)).ToList();
    }
}
