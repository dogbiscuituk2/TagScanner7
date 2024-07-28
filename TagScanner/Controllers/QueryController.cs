namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    using Forms;
    using Models;

    public class QueryController : UndoRedoController<Query>
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
            PopupClear = Dialog.PopupClear;
            PopupSelectAll = Dialog.PopupSelectAll;
            PopupInvertSelection = Dialog.PopupInvertSelection;

            TbOK = Dialog.tbOK;
            TbCancel = Dialog.tbCancel;
            TbMoveUp = Dialog.tbMoveUp;
            TbMoveDown = Dialog.tbMoveDown;
            TbCut = Dialog.tbCut;
            TbCopy = Dialog.tbCopy;
            TbPaste = Dialog.tbPaste;
            TbDelete = Dialog.tbDelete;
            TbClear = Dialog.tbClear;
            TbUndo = Dialog.tbUndo;
            TbRedo = Dialog.tbRedo;
            TbTree = Dialog.tbTree;
            TbList = Dialog.tbList;

            TreeView = Dialog.TreeView;
            ListView = Dialog.ListView;
            LvSelect = Dialog.lvSelect;
            LvOrderBy = Dialog.lvOrderBy;
            LvGroupBy = Dialog.lvGroupBy;

            _queryTreeViewController.InitView();

            TreeAlphabetically.Click += TreeAlphabetically_Click;
            TreeByCategory.Click += TreeByCategory_Click;
            TreeByDataType.Click += TreeByDataType_Click;

            _queryListViewController.InitView();

            ListAlphabetically.Click += ListAlphabetically_Click;
            ListByCategory.Click += ListByCategory_Click;
            ListByDataType.Click += ListByDataType_Click;
            ListNamesOnly.Click += ListNamesOnly_Click;

            InitControls(TreeView, ListView, LvSelect, LvOrderBy, LvGroupBy);

            Dialog.FileSaveAndClose.Click += (sender, e) => Dialog.DialogResult = DialogResult.OK;
            Dialog.FileCloseWithoutSaving.Click += (sender, e) => Dialog.DialogResult = DialogResult.Cancel;

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
            PopupClear.Click += PopupClear_Click;
            PopupSelectAll.Click += PopupSelectAll_Click;
            PopupInvertSelection.Click += PopupInvertSelection_Click;

            UseTreeView(TagGrouping.Category);

            void InitControls(params Control[] controls)
            {
                foreach (var control in controls)
                {
                    control.GotFocus += Control_StateChanged;
                    if (control is TreeView treeView)
                        treeView.AfterSelect += Control_StateChanged;
                    else if (control is ListView listView)
                        listView.SelectedIndexChanged += Control_StateChanged;
                }
            }
        }

        #endregion

        #region Public Properties

        public IEnumerable<Tag> AvailableTags { get; private set; }

        #endregion

        #region Public Fields

        public TagGrouping TagGrouping;

        #endregion

        #region Public Methods

        public bool Execute(string caption, string detail, Query query)
        {
            SetSorts(query.Sorts);
            SetGroups(query.Groups);
            var ok = Execute(caption, detail, query.Tags, true);
            if (ok)
                query.Init(GetSelectedTags(), GetSorts(), GetGroups());
            return ok;
        }

        public bool Execute(string caption, string detail, List<Tag> selectedTags)
        {
            var ok = Execute(caption, detail, selectedTags, false);
            if (ok)
            {
                selectedTags.Clear();
                selectedTags.AddRange(GetSelectedTags());
            }
            return ok;
        }

        public void UpdateSelection()
        {
            UpdateTags(LvSelect, GetSelectedTags());
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

        # region Protected Methods

        protected override int Redo(Query query, bool spoof = false)
        {
            return 0;
        }

        protected override int Undo(Query query)
        {
            return 0;
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
            PopupDelete,
            PopupClear,
            PopupSelectAll,
            PopupInvertSelection;

        private readonly ToolStripButton
            TbOK,
            TbCancel,
            TbMoveUp,
            TbMoveDown,
            TbCut,
            TbCopy,
            TbPaste,
            TbDelete,
            TbClear;

        private readonly ToolStripSplitButton
            TbUndo,
            TbRedo,
            TbTree,
            TbList;

        #endregion

        #region Private Properties

        private QueryViewController ActiveController =>
            _queryListViewController.Active
            ? _queryListViewController
            : (QueryViewController)_queryTreeViewController;

        private QueryDialog Dialog => _dialog ?? CreateDialog();

        private ListView FocusedListView => Focus as ListView;

        private bool _sortAndGroup;
        private bool SortAndGroup
        {
            get => _sortAndGroup;
            set
            {
                _sortAndGroup = value;
                Dialog.lblOrderBy.Visible = LvOrderBy.Visible = value;
                Dialog.lblGroupBy.Visible = LvGroupBy.Visible = value;
                var styles = Dialog.TableLayoutPanel.ColumnStyles;
                if (SortAndGroup)
                    styles[0].Width = styles[1].Width = styles[2].Width = 100 / 3F;
                else
                {
                    styles[0].Width = 100;
                    styles[1].Width = styles[2].Width = 0;
                }
            }
        }

        #endregion

        #region Event Handlers

        private void Control_StateChanged(object sender, EventArgs e) { Focus = sender as Control; UpdateMenu(); }
        private void ListAlphabetically_Click(object sender, EventArgs e) => UseListView(TagGrouping.None);
        private void ListByCategory_Click(object sender, EventArgs e) => UseListView(TagGrouping.Category);
        private void ListByDataType_Click(object sender, EventArgs e) => UseListView(TagGrouping.DataType);
        private void ListNamesOnly_Click(object sender, EventArgs e) => UseListView(TagGrouping.None, true);
        private void TreeAlphabetically_Click(object sender, EventArgs e) => UseTreeView(TagGrouping.None);
        private void TreeByCategory_Click(object sender, EventArgs e) => UseTreeView(TagGrouping.Category);
        private void TreeByDataType_Click(object sender, EventArgs e) => UseTreeView(TagGrouping.DataType);

        private void PopupClear_Click(object sender, EventArgs e) => ActiveTargetExecute(Act.Clear);
        private void PopupCopy_Click(object sender, EventArgs e) => ActiveTargetExecute(Act.Copy);
        private void PopupCut_Click(object sender, EventArgs e) => ActiveTargetExecute(Act.Cut);
        private void PopupDelete_Click(object sender, EventArgs e) => ActiveTargetExecute(Act.Delete);
        private void PopupGroup_Click(object sender, EventArgs e) => ActiveTargetExecute(Act.Group);
        private void PopupInvertSelection_Click(object sender, EventArgs e) => ActiveTargetExecute(Act.InvertSelection);
        private void PopupMoveDown_Click(object sender, EventArgs e) => ActiveTargetExecute(Act.MoveDown);
        private void PopupMoveUp_Click(object sender, EventArgs e) => ActiveTargetExecute(Act.MoveUp);
        private void PopupPaste_Click(object sender, EventArgs e) => ActiveTargetExecute(Act.Paste);
        private void PopupSelect_Click(object sender, EventArgs e) => ActiveTargetExecute(Act.Select);
        private void PopupSelectAll_Click(object sender, EventArgs e) => ActiveTargetExecute(Act.SelectAll);
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
                    case Act.SelectAll: DoSelectAll(); return;
                    case Act.InvertSelection: DoInvertSelection(); return;
                }
            }

            void DoCopy() => Clipboard.SetDataObject(FocusedListView.SelectedItems);

            void DoDelete()
            {
                for (int index = count - 1; index >= 0; index--)
                    if (selection.Contains(index))
                        items.RemoveAt(index);
            }

            void DoInvertSelection() { foreach (ListViewItem item in items) item.Selected ^= true; }

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

            void DoSelectAll() { foreach (ListViewItem item in items) item.Selected = true; }
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

        private bool Execute(string caption, string detail, List<Tag> tags, bool sortAndGroup)
        {
            Dialog.Text = caption;
            Dialog.lblSelect.Text = detail;
            SortAndGroup = sortAndGroup;
            SetSelectedTags(tags);
            return Dialog.ShowDialog(Owner) == DialogResult.OK;
        }

        private IEnumerable<Tag> GetSelectedTags() => LvSelect.Items.Cast<ListViewItem>().Select(p => (Tag)p.Tag);
        private IEnumerable<Tag> GetGroups() => LvGroupBy.Items.Cast<ListViewItem>().Select(p => (Tag)p.Tag);
        private IEnumerable<SortDescription> GetSorts() => LvOrderBy.Items.Cast<TagListItem>().Select(p => new SortDescription(p.Name, p.Direction));

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
        private void SetSelectedTags(IEnumerable<Tag> tags) => LvSelect.Items.AddRange(tags.Select(p => new TagListItem(p)).ToArray());

        private void UpdateMenu()
        {
            var indices = FocusedListView?.SelectedIndices.Cast<int>() ?? Array.Empty<int>();
            var total = FocusedListView?.Items?.Count ?? 0;

            bool
                hasFocus = Focus != null,
                canEdit = new[] { LvSelect, LvOrderBy, LvGroupBy }.Contains(Focus),
                hasAny = total > 0,
                hasSelection = canEdit && indices.Any(),

                canMoveUp = canEdit,
                canMoveDown = canEdit,
                canSelect = Focus != LvSelect,
                canSort = SortAndGroup && Focus != LvOrderBy,
                canGroup = SortAndGroup && Focus != LvGroupBy,
                canCut = canEdit,
                canCopy = hasFocus,
                canPaste = canEdit,
                canDelete = canEdit,
                canClear = canEdit,
                canSelectAll = canEdit,
                canInvertSelection = canEdit;

            ApplyAll((value, item) => item.Visible = value);

            Dialog.PopupSelectSeparator.Visible = canSelectAll;

            var count = canEdit ? indices.Count() : 0;

            canMoveUp &= count > 0 && indices.Max() >= count;
            canMoveDown &= count > 0 && indices.Min() < total - count;
            canSelect &= hasSelection;
            canSort &= hasSelection;
            canGroup &= hasSelection;
            canCut &= hasSelection;
            canCopy &= hasSelection;
            canPaste &= Clipboard.GetDataObject().HasTagSortData();
            canDelete &= hasSelection;
            canClear &= hasSelection;
            canSelectAll &= hasAny;
            canInvertSelection &= hasAny;

            ApplyAll((value, item) => item.Enabled = value);

            void ApplyAll(Action<bool, ToolStripItem> action)
            {
                Apply(canMoveUp, PopupMoveUp, TbMoveUp);
                Apply(canMoveDown, PopupMoveDown, TbMoveDown);
                Apply(canSelect, PopupSelect);
                Apply(canSort, PopupSort);
                Apply(canSort, PopupSortAscending);
                Apply(canSort, PopupSortDescending);
                Apply(canGroup, PopupGroup);
                Apply(canCut, PopupCut, TbCut);
                Apply(canCopy, PopupCopy, TbCopy);
                Apply(canPaste, PopupPaste, TbPaste);
                Apply(canDelete, PopupDelete, TbDelete);
                Apply(canClear, PopupClear, TbClear);
                Apply(canSelectAll, PopupSelectAll);
                Apply(canInvertSelection, PopupInvertSelection);

                void Apply(bool value, params ToolStripItem[] items)
                {
                    foreach (var item in items)
                        action(value, item);
                }
            }
        }

        private void UpdateUI()
        {
            bool tree = _queryTreeViewController.Active;
            TreeAlphabetically.Checked = tree && TagGrouping == TagGrouping.None; ;
            TreeByCategory.Checked = tree && TagGrouping == TagGrouping.Category;
            TreeByDataType.Checked = tree && TagGrouping == TagGrouping.DataType;
            ListAlphabetically.Checked = !tree && TagGrouping == TagGrouping.None && !MultiColumn;
            ListByCategory.Checked = !tree && TagGrouping == TagGrouping.Category;
            ListByDataType.Checked = !tree && TagGrouping == TagGrouping.DataType;
            ListNamesOnly.Checked = !tree && TagGrouping == TagGrouping.None && MultiColumn;
            UpdateMenu();
        }

        private void UseListView(TagGrouping tagGrouping, bool multiColumn = false) => UseView(useTree: false, tagGrouping, multiColumn);
        private void UseTreeView(TagGrouping tagGrouping) => UseView(useTree: true, tagGrouping);

        private void UseView(bool useTree, TagGrouping tagGrouping, bool multiColumn = false)
        {
            TagGrouping = tagGrouping;
            MultiColumn = multiColumn;
            _queryListViewController.ViewMode = multiColumn ? View.List : View.Details;
            _queryListViewController.Active = !useTree;
            _queryTreeViewController.Active = useTree;
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
            Clear,
            SelectAll,
            InvertSelection,
        }

        #endregion
    }
}
