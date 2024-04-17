namespace TagScanner.Controllers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Models;
    using Terms;

    public class TagsListController : TagsViewController, IComparer
    {
        #region Public Interface

        public TagsListController(Controller parent) : base(parent) { }

        public override Control Control => ListView;
        public ListView ListView => Dialog.ListView;

        public void InitListView()
        {
            Items.Clear();
            foreach (var tag in Tags.Keys)
            {
                var item = Items.Add(tag.DisplayName());
                item.Name = tag.Name();
                item.ToolTipText = tag.Details();
                item.Tag = tag;
                var subItems = item.SubItems;
                subItems.Add(tag.Category());
                subItems.Add(tag.TypeName());
                subItems.Add(tag.CanWrite() ? "Yes" : "No");
                if (!tag.CanWrite())
                    item.ForeColor = Color.FromKnownColor(KnownColor.GrayText);
            }
            ListView.ColumnClick += (sender, e) => SortByColumn(e.Column);
            ListView.ListViewItemSorter = this;
            Dialog.ListMenu.DropDownOpening += (sender, e) => InitListMenu();
        }

        #endregion

        #region Public Interface IComparer

        public int Compare(object x, object y) => string.CompareOrdinal(GetValue(x), GetValue(y)) * (_sortDescending ? -1 : +1);

        #endregion

        #region Private/Protected Implementation

        private int _sortColumn;
        private bool _sortDescending;

        private ListViewGroupCollection Groups => ListView.Groups;
        private ListView.ListViewItemCollection Items => ListView.Items;

        private IEnumerable<string> GetGroupHeaders() =>
            Items.Cast<ListViewItem>().Select(item => (Tag)item.Tag).Select(GetGroupHeader).Distinct().OrderBy(p => p);

        private string GetValue(object o) => _sortColumn == 0 ? ((ListViewItem)o).Text : ((ListViewItem)o).SubItems[_sortColumn].Text;

        public override List<Tag> GetVisibleTags()
        {
            var result = new List<Tag>();
            result.AddRange(Dialog.ListView.Items.Cast<ListViewItem>().Where(t => t.Checked).Select(t => (Tag)t.Tag));
            return result;
        }

        protected override void InitGroups()
        {
            ListView.ShowGroups = GroupTagsBy == GroupTagsBy.Category || GroupTagsBy == GroupTagsBy.DataType;
            Groups.Clear();
            foreach (var header in GetGroupHeaders())
                Groups.Add(NewGroup(header));
            foreach (ListViewItem item in Items)
                item.Group = Groups.Cast<ListViewGroup>().First(p => p.Header == GetGroupHeader((Tag)item.Tag));
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

        public override void SetVisibleTags(List<Tag> visibleTags)
        {
            var items = Items.Cast<ListViewItem>();
            foreach (var tag in Tags.Keys)
            {
                var item = items.FirstOrDefault(p => (Tag)p.Tag == tag);
                if (item != null)
                    item.Checked = visibleTags.Contains(tag);
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
