namespace TagScanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>
    /// Reading Stag data for the purposes of a (potentially sorted) Tag-based Drag/Drop or Clipboard operation.
    /// </summary>
    public static class StagData
    {
        #region Public Methods

        public static void CopyToClipboard(this Control control) => Clipboard.SetDataObject(control?.GetSelectedStags());

        public static List<Stag> FromClipboard() => ClipboardData?.GetStags() ?? new List<Stag>();

        public static List<Stag> GetAllStags(this ListView listView) =>
            listView.Items.Cast<ListViewItem>().Select(p => new Stag((Tag)p.Tag, p.ImageIndex)).ToList();

        public static List<Stag> GetSelectedStags(this Control control)
        {
            var list = new List<Stag>();
            if (control is ListView listView)
                list.AddRange(listView.SelectedItems.Cast<ListViewItem>().Select(p => new Stag((Tag)p.Tag, p.ImageIndex)));
            else if (control is TreeView treeView)
                Visit(treeView.SelectedNode);
            return list;

            void Visit(TreeNode parent)
            {
                if (parent.Tag is Tag tag)
                    list.Add(new Stag(tag));
                else
                {
                    var nodes = parent.Nodes;
                    if (nodes.Count > 0)
                        foreach (TreeNode child in nodes)
                            Visit(child);
                }
            }
        }

        public static bool IsOnClipboard() => ClipboardData?.HasStags() ?? false;

        public static StagItem[] ToItems(this IEnumerable<Stag> stags) => stags?.Select(stag => new StagItem(stag)).ToArray();

        public static List<Stag> ToStags(this IDataObject data) => data?.GetStags() ?? new List<Stag>();

        #endregion

        #region Private Properties

        private static Type StagsType => typeof(List<Stag>);

        #endregion

        #region Private Methods

        private static IDataObject ClipboardData => Clipboard.GetDataObject();

        private static List<Stag> GetStags(this IDataObject data) => (List<Stag>)data?.GetData(StagsType);

        private static bool HasStags(this IDataObject data) => data?.GetDataPresent(StagsType) ?? false;

        #endregion
    }
}
