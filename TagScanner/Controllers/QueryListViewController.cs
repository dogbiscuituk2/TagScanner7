namespace TagScanner.Controllers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Models;

    public class QueryListViewController : QueryViewController, IComparer
    {
        #region Constructor

        public QueryListViewController(QueryController parent, ListView listView) : base(parent, listView)
        {
            ListView.ColumnWidthChanged += (sender, e) => ListView.Invalidate();

            ListView.OwnerDraw = false; // Here be dragons.
            ListView.DrawColumnHeader += ListView_DrawColumnHeader;
            ListView.DrawItem += ListView_DrawItem;
            ListView.DrawSubItem += ListView_DrawSubItem;
        }

        #endregion

        #region Public Properties

        public View ViewMode
        {
            get => ListView.View;
            set => ListView.View = value;
        }

        #endregion

        #region Public Methods

        public int Compare(object x, object y) => string.CompareOrdinal(GetValue(x), GetValue(y)) * (_sortDescending ? -1 : +1);

        public void InitView()
        {
            InitItems();
            ListView.ColumnClick += (sender, e) => SortByColumn(e.Column);
            ListView.ListViewItemSorter = this;
        }

        public void ShowView(View view)
        {
            Active = true;
            ListView.View = view;
        }

        #endregion

        #region Protected Methods

        protected override void InitGroups()
        {
            ListView.ShowGroups = TagGrouping == TagGrouping.Category || TagGrouping == TagGrouping.DataType;
            Groups.Clear();
            foreach (var header in GetGroupHeaders())
                Groups.Add(NewGroup(header));
            foreach (ListViewItem item in Items)
                item.Group = Groups.Cast<ListViewGroup>().First(p => p.Header == GetGroupHeader((Tag)item.Tag));
        }

        #endregion

        #region Private Fields

        private int _sortColumn;
        private bool _sortDescending;

        #endregion

        #region Private Properties

        private ListViewGroupCollection Groups => ListView.Groups;
        private ListView.ListViewItemCollection Items => ListView.Items;
        private ListView ListView => (ListView)Control;

        #endregion

        #region Event Handlers

        private void ListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e) =>
            e.DrawDefault = true;

        private void ListView_DrawItem(object sender, DrawListViewItemEventArgs e) =>
            DrawItem(e.Graphics, e.Bounds, e.Item.Text, e.Item.Tag, e.State);

        private void ListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e) =>
            DrawItem(e.Graphics, e.Bounds, e.SubItem.Text, e.Item.Tag, e.ItemState);

        #endregion

        #region Private Methods

        private void DrawItem(Graphics graphics, Rectangle bounds, string text, object tag, ListViewItemStates state)
        {
            if (bounds.IsEmpty)
                return;
            GetColours((state & ListViewItemStates.Selected) != 0, ((Tag)tag).CanWrite(), out Color fore, out Color back);
            graphics.FillRectangle(new SolidBrush(back), bounds);
            graphics.DrawString(text, ListView.Font, new SolidBrush(fore), bounds);
        }

        private IEnumerable<string> GetGroupHeaders() =>
            Items.Cast<ListViewItem>().Select(item => (Tag)item.Tag).Select(GetGroupHeader).Distinct().OrderBy(p => p);

        private string GetValue(object o) => _sortColumn == 0 ? ((ListViewItem)o).Text : ((ListViewItem)o).SubItems[_sortColumn].Text;

        private void InitItems()
        {
            var foo = ListView.View;

            Items.Clear();
            foreach (var tag in AvailableTags)
            {
                var item = Items.Add(tag.DisplayName());
                item.Name = tag.Name();
                item.ToolTipText = tag.Details();
                item.Tag = tag;
                var subItems = item.SubItems;
                subItems.Add(tag.Category());
                subItems.Add(tag.TypeName());
                subItems.Add(tag.CanWrite() ? "Yes" : "No");
                subItems.Add(tag.CanSort() ? "Yes" : "No");
                if (!tag.CanWrite())
                    item.ForeColor = ReadOnlyColour;
            }
        }

        private static ListViewGroup NewGroup(string header) => new ListViewGroup(header) { HeaderAlignment = HorizontalAlignment.Right };

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
