namespace TagScanner.Controllers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Models;

    internal class TagsListViewController : TagsViewController, IComparer
    {
        #region Public Interface IComparer

        public int Compare(object x, object y) => string.CompareOrdinal(GetValue(x), GetValue(y)) * (_sortDescending ? -1 : +1);

        #endregion

        #region Internal Interface

        internal TagsListViewController(Controller parent) : base(parent) { }

        internal override Control Control => ListView;
        internal ListView ListView => Dialog.ListView;

        internal void InitListView()
        {
            Items.Clear();
            foreach (var tag in Tags.AllTags)
            {
                var item = Items.Add(tag.DisplayName);
                item.Name = tag.Name;
                item.ToolTipText = tag.Details;
                item.Tag = tag;
                var subItems = item.SubItems;
                subItems.Add(tag.Category);
                subItems.Add(tag.TypeName);
                subItems.Add(tag.CanWrite ? "Yes" : "No");
                if (!tag.CanWrite)
                    item.ForeColor = Color.FromKnownColor(KnownColor.GrayText);
            }
            ListView.ColumnClick += (sender, e) => SortByColumn(e.Column);
            ListView.ListViewItemSorter = this;
            Dialog.ListMenu.DropDownOpening += (sender, e) => InitListMenu();
        }

        #endregion

        #region Private/Protected Implementation

        private int _sortColumn;
        private bool _sortDescending;

        private ListViewGroupCollection Groups => ListView.Groups;
        private ListView.ListViewItemCollection Items => ListView.Items;

        private IEnumerable<string> GetGroupHeaders() =>
            Items.Cast<ListViewItem>().Select(item => (TagProps)item.Tag).Select(GetGroupHeader).Distinct().OrderBy(p => p);

        private string GetValue(object o) => _sortColumn == 0 ? ((ListViewItem)o).Text : ((ListViewItem)o).SubItems[_sortColumn].Text;

        protected override IEnumerable<string> GetVisibleTags()
        {
            var result = new List<string>();
            result.AddRange(Dialog.ListView.Items.Cast<ListViewItem>().Where(t => t.Checked).Select(t => t.Name));
            return result;
        }

        private void ReadCheckBoxes(List<string> visibleTagNames)
        {
            visibleTagNames.Clear();
            visibleTagNames.AddRange(GetVisibleTags());
        }

        protected override void InitGroups()
        {
            ListView.ShowGroups = GroupTagsBy == GroupTagsBy.Category || GroupTagsBy == GroupTagsBy.DataType;
            Groups.Clear();
            foreach (var header in GetGroupHeaders())
                Groups.Add(NewGroup(header));
            foreach (ListViewItem item in Items)
                item.Group = Groups.Cast<ListViewGroup>().First(p => p.Header == GetGroupHeader((TagProps)item.Tag));
        }

        private void InitListMenu()
        {
            var list = ListView.Visible;
            Dialog.ListAlphabetically.Checked = list && GroupTagsBy == GroupTagsBy.None && ListView.View == View.Details;
            Dialog.ListByCategory.Checked = list && GroupTagsBy == GroupTagsBy.Category;
            Dialog.ListByDataType.Checked = list && GroupTagsBy == GroupTagsBy.DataType;
            Dialog.ListNamesOnly.Checked = list && GroupTagsBy == GroupTagsBy.None && ListView.View == View.List;
        }

        private static ListViewGroup NewGroup(string header) => new ListViewGroup(header) { HeaderAlignment = HorizontalAlignment.Right };

        protected override void SetVisibleTags(IEnumerable<string> visibleTagNames)
        {
            var items = Items.Cast<ListViewItem>();
            foreach (var tag in Tags.AllTags)
            {
                var name = tag.Name;
                var item = items.FirstOrDefault(p => p.Name == name);
                if (item != null)
                    item.Checked = visibleTagNames.Contains(name);
            }
        }

        private void SortByColumn(int column)
        {
            if (_sortColumn != column)
            {
                _sortColumn = column;
                _sortDescending = false;
            }
            else
                _sortDescending = !_sortDescending;
            ListView.Sort();
        }

        #endregion
    }
}
