namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    using Forms;
    using Models;

    public class QueryController : Controller
    {
        #region Constructors

        public QueryController(Controller parent) : this(parent, p => true) { }

        public QueryController(Controller parent, Func<Tag, bool> tagFilter) : base(parent)
        {
            AvailableTags = Tags.Keys.Where(tagFilter);

            _queryListViewController = new QueryListViewController(this, Dialog.ListView);
            _queryTreeViewController = new QueryTreeViewController(this, Dialog.TreeView);

            TreeAlphabetically = Dialog.TreeAlphabetically;
            TreeByCategory = Dialog.TreeByCategory;
            TreeByDataType = Dialog.TreeByDataType;

            ListAlphabetically = Dialog.ListAlphabetically;
            ListByCategory = Dialog.ListByCategory;
            ListByDataType = Dialog.ListByDataType;
            ListNamesOnly = Dialog.ListNamesOnly;

            tbTreeAlpha = Dialog.tbTreeAlpha;
            tbTreeCat = Dialog.tbTreeCat;
            tbTreeType = Dialog.tbTreeType;

            tbListAlpha = Dialog.tbListAlpha;
            tbListCat = Dialog.tbListCat;
            tbListType = Dialog.tbListType;
            tbListNames = Dialog.tbListNames;

            PopupMenu = Dialog.PopupMenu;
            PopupMoveUp = Dialog.PopupMoveUp;
            PopupMoveDown = Dialog.PopupMoveDown;
            PopupSelect = Dialog.PopupSelect;
            PopupSort = Dialog.PopupSort;
            PopupSortAscending = Dialog.PopupSortAscending;
            PopupSortDescending = Dialog.PopupSortDescending;
            PopupGroup = Dialog.PopupGroup;
            PopupCut = Dialog.PopupCut;
            PopupCopy = Dialog.PopupCopy;
            PopupPaste = Dialog.PopupPaste;
            PopupDelete = Dialog.PopupDelete;

            TreeView = Dialog.TreeView;
            ListView = Dialog.ListView;
            LvSelect = Dialog.lvSelect;
            LvOrderBy = Dialog.lvOrderBy;
            LvGroupBy = Dialog.lvGroupBy;

            _queryTreeViewController.InitView();

            TreeAlphabetically.Click += TreeAlphabetically_Click;
            TreeByCategory.Click += TreeByCategory_Click;
            TreeByDataType.Click += TreeByDataType_Click;
            tbTreeAlpha.Click += TreeAlphabetically_Click;
            tbTreeCat.Click += TreeByCategory_Click;
            tbTreeType.Click += TreeByDataType_Click;

            _queryListViewController.InitView();

            ListAlphabetically.Click += ListAlphabetically_Click;
            ListByCategory.Click += ListByCategory_Click;
            ListByDataType.Click += ListByDataType_Click;
            ListNamesOnly.Click += ListNamesOnly_Click;
            tbListAlpha.Click += ListAlphabetically_Click;
            tbListCat.Click += ListByCategory_Click;
            tbListType.Click += ListByDataType_Click;
            tbListNames.Click += ListNamesOnly_Click;

            TreeView.GotFocus += Control_GotFocus;
            ListView.GotFocus += Control_GotFocus;
            LvSelect.GotFocus += Control_GotFocus;
            LvOrderBy.GotFocus += Control_GotFocus;
            LvGroupBy.GotFocus += Control_GotFocus;

            PopupMenu.Opening += PopupTargetMenu_Opening;
            PopupMoveUp.Click += PopupMoveUp_Click;
            PopupMoveDown.Click += PopupMoveDown_Click;
            PopupSelect.Click += PopupSelect_Click;
            PopupSortAscending.Click += PopupSortAscending_Click;
            PopupSortDescending.Click += PopupSortDescending_Click;
            PopupGroup.Click += PopupGroup_Click;
            PopupCut.Click += PopupCut_Click;
            PopupCopy.Click += PopupCopy_Click;
            PopupPaste.Click += PopupPaste_Click;
            PopupDelete.Click += PopupDelete_Click;

            UseTreeView(TagGrouping.Category);
        }

        #endregion

        #region Public Properties

        public IEnumerable<Tag> AvailableTags { get; private set; }

        #endregion

        #region Public Fields

        public TagGrouping TagGrouping;

        #endregion

        #region Public Methods

        public bool Execute(string caption, Query query)
        {
            Dialog.Text = caption;
            SetTags(query.Tags);
            SetSorts(query.Sorts);
            SetGroups(query.Groups);
            var ok = Dialog.ShowDialog(Owner) == DialogResult.OK;
            if (ok)
                query.Init(ActiveController.GetSelectedTags(), GetSorts(), GetGroups());
            return ok;
        }

        public bool Execute(string caption, List<Tag> selectedTags)
        {
            Dialog.Text = caption;
            SetTags(selectedTags);
            var ok = Dialog.ShowDialog(Owner) == DialogResult.OK;
            if (ok)
            {
                selectedTags.Clear();
                selectedTags.AddRange(ActiveController.GetSelectedTags());
            }
            return ok;
        }

        public void UpdateSelection()
        {
            UpdateTags(LvSelect, GetTags());
            UpdateSorts(LvOrderBy, GetSorts());
            UpdateTags(LvGroupBy, GetGroups());

            void UpdateSorts(ListView view, IEnumerable<SortDescription> sorts)
            {
                if (view == null)
                    return;
                view.Clear();
                view.Items.AddRange(sorts.Select(p => new TagListItem(p)).ToArray());
            }

            void UpdateTags(ListView view, IEnumerable<Tag> tags)
            {
                if (view == null)
                    return;
                view.Clear();
                view.Items.AddRange(tags.Select(p => new TagListItem(p)).ToArray());
            }
        }

        #endregion

        #region Private Fields

        private Control Focus;
        private bool MultiColumn;
        private readonly ContextMenuStrip PopupMenu;
        private readonly TreeView TreeView;
        private readonly ListView ListView, LvSelect, LvOrderBy, LvGroupBy;
        private static QueryDialog _dialog;
        private readonly QueryListViewController _queryListViewController;
        private readonly QueryTreeViewController _queryTreeViewController;

        private readonly ToolStripMenuItem
            ListAlphabetically,
            ListByCategory,
            ListByDataType,
            ListNamesOnly,
            TreeAlphabetically,
            TreeByCategory,
            TreeByDataType,
            PopupMoveUp,
            PopupMoveDown,
            PopupSelect,
            PopupSort,
            PopupSortAscending,
            PopupSortDescending,
            PopupGroup,
            PopupCut,
            PopupCopy,
            PopupPaste,
            PopupDelete;

        private readonly ToolStripButton
            tbListAlpha,
            tbListCat,
            tbListType,
            tbListNames,
            tbTreeAlpha,
            tbTreeCat,
            tbTreeType;

        #endregion

        #region Private Properties

        private QueryViewController ActiveController =>
            _queryListViewController.Active
            ? _queryListViewController
            : (QueryViewController)_queryTreeViewController;

        private QueryDialog Dialog => _dialog ?? CreateDialog();

        private ListView FocusedListView => Focus as ListView;

        #endregion

        #region Event Handlers

        private void Control_GotFocus(object sender, EventArgs e) => Focus = sender as Control;
        private void ListAlphabetically_Click(object sender, EventArgs e) => UseListView(TagGrouping.None);
        private void ListByCategory_Click(object sender, EventArgs e) => UseListView(TagGrouping.Category);
        private void ListByDataType_Click(object sender, EventArgs e) => UseListView(TagGrouping.DataType);
        private void ListNamesOnly_Click(object sender, EventArgs e) => UseListView(TagGrouping.None, true);
        private void TreeAlphabetically_Click(object sender, EventArgs e) => UseTreeView(TagGrouping.None);
        private void TreeByCategory_Click(object sender, EventArgs e) => UseTreeView(TagGrouping.Category);
        private void TreeByDataType_Click(object sender, EventArgs e) => UseTreeView(TagGrouping.DataType);

        private void PopupCopy_Click(object sender, EventArgs e) => ActiveTargetExecute(Act.Copy);
        private void PopupCut_Click(object sender, EventArgs e) => ActiveTargetExecute(Act.Cut);
        private void PopupDelete_Click(object sender, EventArgs e) => ActiveTargetExecute(Act.Delete);
        private void PopupGroup_Click(object sender, EventArgs e) => ActiveTargetExecute(Act.Group);
        private void PopupMoveDown_Click(object sender, EventArgs e) => ActiveTargetExecute(Act.MoveDown);
        private void PopupMoveUp_Click(object sender, EventArgs e) => ActiveTargetExecute(Act.MoveUp);
        private void PopupPaste_Click(object sender, EventArgs e) => ActiveTargetExecute(Act.Paste);
        private void PopupSelect_Click(object sender, EventArgs e) => ActiveTargetExecute(Act.Select);
        private void PopupSortAscending_Click(object sender, EventArgs e) => ActiveTargetExecute(Act.SortAscending);
        private void PopupSortDescending_Click(object sender, EventArgs e) => ActiveTargetExecute(Act.SortDescending);
        private void PopupTargetMenu_Opening(object sender, CancelEventArgs e) => UpdateMenu();

        #endregion

        #region Private Methods

        private void ActiveTargetExecute(Act act)
        {
            FocusedListView.BeginUpdate();
            var items = FocusedListView.Items;
            var count = items.Count;
            var selection = FocusedListView.SelectedIndices.Cast<int>().ToList();
            DoAct();
            FocusedListView.EndUpdate();
            UpdateMenu();

            void DoAct()
            {
                switch (act)
                {
                    case Act.MoveUp: DoMove(down: false); return;
                    case Act.MoveDown: DoMove(down: true); return;
                    case Act.Cut: DoCopy(); DoDelete(); return;
                    case Act.Copy: DoCopy(); return;
                    case Act.Paste: DoPaste(); return;
                    case Act.Delete: DoDelete(); return;
                }
            }

            void DoCopy() => Clipboard.SetDataObject(FocusedListView.SelectedItems);

            void DoDelete()
            {
                for (int index = count - 1; index >= 0; index--)
                    if (selection.Contains(index))
                        items.RemoveAt(index);
            }

            void DoMove(bool down)
            {
                int index;
                if (down) for (index = count - 1; index > 0; index--) { if (selection.Contains(index - 1)) Swap(); }
                else for (index = 1; index < count; index++) { if (selection.Contains(index)) Swap(); }

                void Swap()
                {
                    var item = items[index - 1];
                    items.RemoveAt(index - 1);
                    items.Insert(index, item);
                }
            }

            void DoPaste()
            {
                var data = Clipboard.GetDataObject()?.GetTagSortItems();
                if (data != null)
                    items.AddRange(data.ToArray());
            }
        }

        private QueryDialog CreateDialog()
        {
            _dialog = new QueryDialog();
            MainTagDragDropController.Add
                (
                _dialog.ListView,
                _dialog.TreeView,
                _dialog.lvSelect,
                _dialog.lvOrderBy,
                _dialog.lvGroupBy
                );
            return Dialog;
        }

        private IEnumerable<Tag> GetGroups() => LvGroupBy.Items.Cast<ListViewItem>().Select(p => (Tag)p.Tag);
        private IEnumerable<SortDescription> GetSorts() => LvOrderBy.Items.Cast<TagListItem>().Select(p => new SortDescription(p.Name, p.Direction));
        private IEnumerable<Tag> GetTags() => ActiveController.GetSelectedTags();

        private IEnumerable<TagSort> GetTagSortData() => FocusedListView != null
            ? FocusedListView.SelectedItems.GetTagSortData()
            : TreeView?.SelectedNode?.GetTagSortData()
            ?? Array.Empty<TagSort>();

        private void PassiveTargetExecute(Act act)
        {
            DoAct();
            UpdateMenu();

            void DoAct()
            {
                switch (act)
                {
                    case Act.Select: DoSelect(); return;
                    case Act.SortAscending: DoSortAscending(); return;
                    case Act.SortDescending: DoSortDescending(); return;
                    case Act.Group: DoGroup(); return;
                }
            }

            void DoSelect()
            {
            }

            void DoSortAscending()
            {
            }

            void DoSortDescending()
            {
            }

            void DoGroup()
            {
            }
        }

        private void SetGroups(IEnumerable<Tag> tags) => LvGroupBy.Items.AddRange(tags.Select(p => new TagListItem(p)).ToArray());
        private void SetSorts(IEnumerable<SortDescription> sorts) => LvOrderBy.Items.AddRange(sorts.Select(p => new TagListItem(p)).ToArray());
        private void SetTags(IEnumerable<Tag> selectedTags) => ActiveController.SetSelectedTags(selectedTags);

        private void UpdateMenu()
        {
            bool
                hasFocus = Focus != null,
                canDrop = new[] { LvSelect, LvOrderBy, LvGroupBy }.Contains(Focus),

                canSelect = Focus != LvSelect,
                canSort = Focus != LvOrderBy,
                canGroup = Focus != LvGroupBy,
                canCut = canDrop,
                canCopy = hasFocus,
                canPaste = canDrop,
                canDelete = canDrop,
                canMoveUp = canDrop,
                canMoveDown = canDrop;

            AdjustMenu((p, q) => p.Visible = q);
            PopupPaste.Visible = canDrop;

            var indices = FocusedListView != null
                ? FocusedListView.SelectedIndices.Cast<int>()
                : new int[] { };
            var hasSelection = indices.Any();

            int
                total = FocusedListView != null ? FocusedListView.Items.Count : 0,
                count = indices.Count();

            canMoveUp &= count > 0 && indices.Max() >= count;
            canMoveDown &= count > 0 && indices.Min() < total - count;

            AdjustMenu((p, q) => p.Enabled = q && hasSelection);
            PopupPaste.Enabled = canDrop && Clipboard.GetDataObject().HasTagSortData();

            void AdjustMenu(Action<ToolStripMenuItem, bool> action)
            {
                action(PopupSelect, canSelect);
                action(PopupSort, canSort);
                action(PopupSortAscending, canSort);
                action(PopupSortDescending, canSort);
                action(PopupGroup, canGroup);
                action(PopupCut, canCut);
                action(PopupCopy, canCopy);
                action(PopupDelete, canDelete);
                action(PopupMoveUp, canMoveUp);
                action(PopupMoveDown, canMoveDown);
            }
        }

        private void UpdateUI()
        {
            bool tree = _queryTreeViewController.Active;
            TreeAlphabetically.Checked = tbTreeAlpha.Checked = tree && TagGrouping == TagGrouping.None; ;
            TreeByCategory.Checked = tbTreeCat.Checked = tree && TagGrouping == TagGrouping.Category;
            TreeByDataType.Checked = tbTreeType.Checked = tree && TagGrouping == TagGrouping.DataType;
            ListAlphabetically.Checked = tbListAlpha.Checked = !tree && TagGrouping == TagGrouping.None && !MultiColumn;
            ListByCategory.Checked = tbListCat.Checked = !tree && TagGrouping == TagGrouping.Category;
            ListByDataType.Checked = tbListType.Checked = !tree && TagGrouping == TagGrouping.DataType;
            ListNamesOnly.Checked = tbListNames.Checked = !tree && TagGrouping == TagGrouping.None && MultiColumn;
            UpdateMenu();
        }

        private void UseListView(TagGrouping tagGrouping, bool multiColumn = false) => UseView(useTree: false, tagGrouping, multiColumn);
        private void UseTreeView(TagGrouping tagGrouping) => UseView(useTree: true, tagGrouping);

        private void UseView(bool useTree, TagGrouping tagGrouping, bool multiColumn = false)
        {
            var selectedTags = GetTags();
            TagGrouping = tagGrouping;
            MultiColumn = multiColumn;
            _queryListViewController.ViewMode = multiColumn ? View.List : View.Details;
            _queryListViewController.Active = !useTree;
            _queryTreeViewController.Active = useTree;
            SetTags(selectedTags);
            UpdateUI();
        }

        #endregion

        #region Private Enums

        private enum Act
        {
            None,
            MoveUp,
            MoveDown,
            Select,
            SortAscending,
            SortDescending,
            Group,
            Cut,
            Copy,
            Paste,
            Delete,
        }

        #endregion
    }
}
