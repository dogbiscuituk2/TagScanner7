﻿namespace TagScanner.Controllers
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

        public QueryListViewController(QueryController parent, ListView listView) : base(parent, listView) { }

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

        #region Private Methods

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
                if (!tag.CanWrite())
                    item.ForeColor = Color.FromKnownColor(KnownColor.GrayText);
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