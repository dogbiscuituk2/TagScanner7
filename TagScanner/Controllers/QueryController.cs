﻿namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Core;
    using Forms;
    using Models;

    public partial class QueryController : UndoRedoController<Query>, ISetQuery
    {
        #region Constructors

        public QueryController(Controller parent) : this(parent, p => true) { }

        public QueryController(Controller parent, Func<Tag, bool> tagFilter) : base(parent)
        {
            Init(this, UpdateUI, PopupUndo, PopupRedo, TbUndo, TbRedo);

            AvailableTags = Tags.Keys.Where(tagFilter);

            _TreeViewController = new QueryTreeViewController(this, Dialog.TreeView);
            _ListViewController = new QueryListViewController(this, Dialog.ListView);

            _TreeViewController.InitView();

            TreeAlphabetically.Click += TreeAlphabetically_Click;
            TreeByCategory.Click += TreeByCategory_Click;
            TreeByDataType.Click += TreeByDataType_Click;
            TbTree.ButtonClick += TreeByCategory_Click;

            _ListViewController.InitView();

            ListAlphabetically.Click += ListAlphabetically_Click;
            ListByCategory.Click += ListByCategory_Click;
            ListByDataType.Click += ListByDataType_Click;
            ListNamesOnly.Click += ListNamesOnly_Click;
            ListSmallIcons.Click += ListSmallIcons_Click;
            ListLargeIcons.Click += ListLargeIcons_Click;
            ListTiles.Click += ListTiles_Click;
            TbList.ButtonClick += ListNamesOnly_Click;

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

            void InitControls(params Control[] controls) => Array.ForEach(controls, p =>
            {
                p.GotFocus += Control_StateChanged;
                if (p is TreeView treeView)
                    treeView.AfterSelect += Control_StateChanged;
                else if (p is ListView listView)
                    listView.SelectedIndexChanged += Control_StateChanged;
            });

            Clear();
        }

        #endregion

        #region Public Properties

        public IEnumerable<Tag> AvailableTags { get; private set; }
        public TagGrouping TagGrouping { get; private set; }

        #endregion

        #region Public Methods

        public bool Execute(string caption, string detail, Query query)
        {
            SetSorts(query.Sorts);
            SetGroups(query.Groups);
            var ok = Execute(caption, detail, query.Tags, true);
            if (ok)
                query.Init(GetSelectedTags(), GetSorts(), GetGroupByTags());
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

        public void SetQuery(Query query)
        {
            SetSorts(query.Sorts);
            SetGroups(query.Groups);
            SetSelectedTags(query.Tags);
            UpdateMenu();
        }

        public void UpdateSelection()
        {
            UpdateTags(LvSelect, GetSelectedTags());
            UpdateSorts(LvOrderBy, GetSorts());
            UpdateTags(LvGroupBy, GetGroupByTags());

            void UpdateSorts(ListView view, IEnumerable<Stag> sorts)
            {
                if (view == null)
                    return;
                view.Clear();
                view.Items.AddRange(sorts.Select(p => new StagItem(p)).ToArray());
            }

            void UpdateTags(ListView view, IEnumerable<Tag> tags)
            {
                if (view == null)
                    return;
                view.Clear();
                view.Items.AddRange(tags.Select(p => new StagItem(p)).ToArray());
            }
        }

        #endregion

        #region Private Fields

        private string _clause;
        private string _detail;
        private QueryDialog _dialog;
        private Control _focus;
        private bool
            _initializing,
            _multiColumn,
            _sortAndGroup;

        private readonly QueryTreeViewController _TreeViewController;
        private readonly QueryListViewController _ListViewController;

        #endregion

        #region Private Properties

        private QueryDialog Dialog => _dialog ?? CreateDialog();
        private TreeView TreeView => Dialog.TreeView;
        private ListView ListView => Dialog.ListView;
        private ListView LvSelect => Dialog.lvSelect;
        private ListView LvOrderBy => Dialog.lvOrderBy;
        private ListView LvGroupBy => Dialog.lvGroupBy;

        private Control Focus
        {
            get => _focus;
            set
            {
                FocusView(false);
                _focus = value;
                FocusView(true);

                void FocusView(bool focus)
                {
                    var label = FocusLabel;
                    if (label != null)
                        label.BackColor = Color.FromKnownColor(focus ? KnownColor.ActiveCaption : KnownColor.Control);
                }
            }
        }

        private ContextMenuStrip PopupMenu => Dialog.PopupMenu;

        private ToolStripMenuItem TreeAlphabetically => Dialog.TreeAlphabetically;
        private ToolStripMenuItem TreeByCategory => Dialog.TreeByCategory;
        private ToolStripMenuItem TreeByDataType => Dialog.TreeByDataType;
        private ToolStripMenuItem ListAlphabetically => Dialog.ListAlphabetically;
        private ToolStripMenuItem ListByCategory => Dialog.ListByCategory;
        private ToolStripMenuItem ListByDataType => Dialog.ListByDataType;
        private ToolStripMenuItem ListNamesOnly => Dialog.ListNamesOnly;
        private ToolStripMenuItem ListSmallIcons => Dialog.ListSmallIcons;
        private ToolStripMenuItem ListLargeIcons => Dialog.ListLargeIcons;
        private ToolStripMenuItem ListTiles => Dialog.ListTiles;
        private ToolStripMenuItem PopupMoveUp => Dialog.PopupMoveUp;
        private ToolStripMenuItem PopupMoveDown => Dialog.PopupMoveDown;
        private ToolStripMenuItem PopupSelect => Dialog.PopupSelect;
        private ToolStripMenuItem PopupSortAscending => Dialog.PopupSortAscending;
        private ToolStripMenuItem PopupSortDescending => Dialog.PopupSortDescending;
        private ToolStripMenuItem PopupGroup => Dialog.PopupGroupBy;
        private ToolStripMenuItem PopupUndo => Dialog.PopupUndo;
        private ToolStripMenuItem PopupRedo => Dialog.PopupRedo;
        private ToolStripMenuItem PopupCut => Dialog.PopupCut;
        private ToolStripMenuItem PopupCopy => Dialog.PopupCopy;
        private ToolStripMenuItem PopupPaste => Dialog.PopupPaste;
        private ToolStripMenuItem PopupDelete => Dialog.PopupDelete;
        private ToolStripMenuItem PopupClear => Dialog.PopupClear;
        private ToolStripMenuItem PopupSelectAll => Dialog.PopupSelectAll;
        private ToolStripMenuItem PopupInvertSelection => Dialog.PopupInvertSelection;

        private ToolStripButton TbOK => Dialog.tbOK;
        private ToolStripButton TbCancel => Dialog.tbCancel;
        private ToolStripButton TbMoveUp => Dialog.tbMoveUp;
        private ToolStripButton TbMoveDown => Dialog.tbMoveDown;
        private ToolStripButton TbCut => Dialog.tbCut;
        private ToolStripButton TbCopy => Dialog.tbCopy;
        private ToolStripButton TbPaste => Dialog.tbPaste;
        private ToolStripButton TbDelete => Dialog.tbDelete;

        private ToolStripSplitButton TbUndo => Dialog.tbUndo;
        private ToolStripSplitButton TbRedo => Dialog.tbRedo;
        private ToolStripSplitButton TbTree => Dialog.tbTree;
        private ToolStripSplitButton TbList => Dialog.tbList;

        private string FocusClause => FocusLabel?.Text ?? string.Empty;
        private int FocusIndex => Focus == LvSelect ? 1 : Focus == LvOrderBy ? 2 : Focus == LvGroupBy ? 3 : 0;
        private ListView.ListViewItemCollection FocusItems => FocusListView?.Items;
        private Label FocusLabel => new[] { null, Dialog.lblSelect, Dialog.lblOrderBy, Dialog.lblGroupBy }[FocusIndex];
        private ListView FocusListView => Focus as ListView;
        private ListView.SelectedListViewItemCollection FocusSelection => FocusListView?.SelectedItems;
        private List<int> FocusSelectedIndices => FocusListView?.SelectedIndices.Cast<int>().ToList();
        private TreeNode SelectedNode => TreeView.SelectedNode;

        private bool SortAndGroup
        {
            get => _sortAndGroup;
            set
            {
                _sortAndGroup = value;
                LvOrderBy.Visible = value;
                LvGroupBy.Visible = value;
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
        private void ListNamesOnly_Click(object sender, EventArgs e) => UseListView(TagGrouping.None, View.List);
        private void ListSmallIcons_Click(object sender, EventArgs e) => UseListView(TagGrouping.None, View.SmallIcon);
        private void ListLargeIcons_Click(object sender, EventArgs e) => UseListView(TagGrouping.None, View.LargeIcon);
        private void ListTiles_Click(object sender, EventArgs e) => UseListView(TagGrouping.None, View.Tile);

        private void TreeAlphabetically_Click(object sender, EventArgs e) => UseTreeView(TagGrouping.None);
        private void TreeByCategory_Click(object sender, EventArgs e) => UseTreeView(TagGrouping.Category);
        private void TreeByDataType_Click(object sender, EventArgs e) => UseTreeView(TagGrouping.DataType);

        private void PopupClear_Click(object sender, EventArgs e) => DoActiveVerb(Verb.Clear);
        private void PopupCopy_Click(object sender, EventArgs e) => DoActiveVerb(Verb.Copy);
        private void PopupCut_Click(object sender, EventArgs e) => DoActiveVerb(Verb.Cut);
        private void PopupDelete_Click(object sender, EventArgs e) => DoActiveVerb(Verb.Delete);
        private void PopupInvertSelection_Click(object sender, EventArgs e) => DoActiveVerb(Verb.InvertSelection);
        private void PopupMoveDown_Click(object sender, EventArgs e) => DoActiveVerb(Verb.MoveDown);
        private void PopupMoveUp_Click(object sender, EventArgs e) => DoActiveVerb(Verb.MoveUp);
        private void PopupPaste_Click(object sender, EventArgs e) => DoActiveVerb(Verb.Paste);
        private void PopupSelectAll_Click(object sender, EventArgs e) => DoActiveVerb(Verb.SelectAll);
        private void PopupTargetMenu_Opening(object sender, CancelEventArgs e) => UpdateMenu();

        private void PopupGroup_Click(object sender, EventArgs e) => DoPassiveVerb(Verb.GroupBy);
        private void PopupSelect_Click(object sender, EventArgs e) => DoPassiveVerb(Verb.SelectTags);
        private void PopupSortAscending_Click(object sender, EventArgs e) => DoPassiveVerb(Verb.SortAscending);
        private void PopupSortDescending_Click(object sender, EventArgs e) => DoPassiveVerb(Verb.SortDescending);

        #endregion

        #region Private Methods

        private QueryDialog CreateDialog()
        {
            _dialog = new QueryDialog();
            AddDragControls(
                ListView,
                TreeView,
                LvSelect,
                LvOrderBy,
                LvGroupBy);
            _initializing = true;
            return Dialog;
        }

        private void DoActiveVerb(Verb verb)
        {
            FocusListView?.BeginUpdate();
            var items = FocusItems;
            var count = items?.Count ?? 0;
            var selectedIndices = FocusSelectedIndices;
            DoVerb();
            FocusListView?.EndUpdate();
            UpdateMenu();

            void DoClear()
            {
                if (items.Count == 0)
                    return;
                DoRun();
                items.Clear();
            }

            void DoCopy() => Focus.CopyToClipboard();

            void DoCut() { DoCopy(); DoDelete(); }

            void DoDelete()
            {
                DoRun();
                for (int index = count - 1; index >= 0; index--)
                    if (selectedIndices.Contains(index))
                        items.RemoveAt(index);
            }

            void DoInvertSelection() { foreach (ListViewItem item in items) item.Selected ^= true; }

            void DoMove(bool up)
            {
                DoRun();
                int index, focus = -1;
                if (up) for (index = 1; index < count; index++) Swap();
                else for (index = count - 1; index > 0; index--) Swap();
                if (focus >= 0)
                    FocusListView.EnsureVisible(focus);

                void Swap()
                {
                    if (selectedIndices.Contains(up ? index : index - 1))
                    {
                        var item = items[index - 1];
                        items.RemoveAt(index - 1);
                        items.Insert(index, item);
                        if (focus < 0)
                            focus = up ? index - 1 : index;
                    }
                }
            }

            void DoPaste()
            {
                if (StagData.IsOnClipboard())
                    Merge(Verb.Paste, StagData.FromClipboard());
            }

            void DoRun() => Run(verb, Focus.GetSelectedStags());

            void DoSelectAll() { foreach (ListViewItem item in items) item.Selected = true; }

            void DoVerb()
            {
                switch (verb)
                {
                    case Verb.MoveUp: DoMove(up: true); return;
                    case Verb.MoveDown: DoMove(up: false); return;
                    case Verb.Cut: DoCut(); return;
                    case Verb.Copy: DoCopy(); return;
                    case Verb.Paste: DoPaste(); return;
                    case Verb.Delete: DoDelete(); return;
                    case Verb.Clear: DoClear(); return;
                    case Verb.SelectAll: DoSelectAll(); return;
                    case Verb.InvertSelection: DoInvertSelection(); return;
                }
            }
        }

        private void DoPassiveVerb(Verb verb)
        {
            var tags = Focus.GetSelectedStags();
            var oldFocus = Focus;
            Focus = GetNewFocus();
            Merge(verb, tags);
            Focus = oldFocus;
            UpdateMenu();

            Control GetNewFocus()
            {
                switch (verb)
                {
                    case Verb.SelectTags: return LvSelect;
                    case Verb.SortAscending: SetDescending(false); return LvOrderBy;
                    case Verb.SortDescending: SetDescending(true); return LvOrderBy;
                    case Verb.GroupBy: return LvGroupBy;
                    default: return null;
                }

                void SetDescending(bool value) => tags.ForEach(p => p.Descending = value);
            }
        }

        private bool Execute(string caption, string detail, List<Tag> tags, bool sortAndGroup)
        {
            Dialog.Text = caption;
            _detail = detail;
            Dialog.lblSelect.Text = $"Selected {detail}";
            string
                browse = $"Browse {detail} in",
                tree = $"{browse} Tree View",
                list = $"{browse} List View",
                changes = $"changes to Selected {detail}",
                change = "most recent change";
            InitControls(tree, Dialog.TreeMenu, TbTree);
            InitControls($"{tree} - Alphabetically", TreeAlphabetically);
            InitControls($"{tree} - by Category", TreeByCategory);
            InitControls($"{tree} - by Data Type", TreeByDataType);
            InitControls($"{list}", Dialog.ListMenu, TbList);
            InitControls($"{list} - Alphabetically", ListAlphabetically);
            InitControls($"{list} - by Category", ListByCategory);
            InitControls($"{list} - by Data Type", ListByDataType);
            InitControls($"{list} - Names only", ListNamesOnly);
            InitControls($"{list} - small icons", ListSmallIcons);
            InitControls($"{list} - large icons", ListLargeIcons);
            InitControls($"{list} - tiles", ListTiles);
            InitControls($"Confirm {changes}", Dialog.FileSaveAndClose, TbOK);
            InitControls($"Discard {changes}", Dialog.FileCloseWithoutSaving, TbCancel);
            InitControls($"Undo {change}", PopupUndo, TbUndo);
            InitControls($"Redo {change}", PopupRedo, TbRedo);
            InitActiveControls();
            SetSelectedTags(tags);
            SortAndGroup = sortAndGroup;
            return Dialog.ShowDialog(Owner) == DialogResult.OK;
        }

        private void InitActiveControls()
        {
            var box =
                Focus == TreeView ? "Tree View" :
                Focus == ListView ? "List View" :
                $"'{FocusClause}' box";
            InitControls($"Cut highlighted {_detail} from {box} to Clipboard", PopupCut, TbCut);
            InitControls($"Copy highlighted {_detail} from {box} to Clipboard", PopupCopy, TbCopy);
            InitControls($"Paste {_detail} from Clipboard into {box}", PopupPaste, TbPaste);
            InitControls($"Delete highlighted {_detail} from {box}", PopupDelete, TbDelete);
            InitControls($"Delete all {_detail} from {box}", PopupClear);
            InitControls($"Move highlighted {_detail} up (in {box})", PopupMoveUp, TbMoveUp);
            InitControls($"Move highlighted {_detail} down (in {box})", PopupMoveDown, TbMoveDown);
            InitControls($"Highlight all {_detail} in {box}", PopupSelectAll);
            InitControls($"Invert highlighting of all {_detail} in {box}", PopupInvertSelection);
        }

        private void InitControls(string toolTip, params ToolStripItem[] controls) => Array.ForEach(controls, p => p.ToolTipText = toolTip);

        private void Merge(Verb verb, IEnumerable<Stag> added)
        {
            var before = FocusListView.GetAllStags();
            var count = FocusItems.Count;
            var selected = FocusSelectedIndices;
            var pivot = selected.Any() ? selected.First() : count;
            var after = Cull(before.Take(pivot)).Concat(added).Concat(Cull(before.Skip(pivot)));
            if (!after.SequenceEqual(before))
            {
                Run(verb, added);
                FocusListView.BeginUpdate();
                FocusItems.Clear();
                FocusItems.AddRange(after.ToItems());
                FocusListView.EndUpdate();
                UpdateMenu();
            }
            return;

            IEnumerable<Stag> Cull(IEnumerable<Stag> stags) => stags.Where(p => !added.Any(q => q.Tag == p.Tag));
        }

        private IEnumerable<Tag> GetGroupByTags() => LvGroupBy.Items.Cast<ListViewItem>().Select(p => (Tag)p.Tag);
        private IEnumerable<Stag> GetSorts() => LvOrderBy.Items.Cast<StagItem>().Select(p => new Stag((Tag)p.Tag, p.Direction));
        private IEnumerable<Tag> GetSelectedTags() => LvSelect.Items.Cast<ListViewItem>().Select(p => (Tag)p.Tag);

        private void SetGroups(IEnumerable<Tag> tags) => SetItems(LvGroupBy, tags);
        private void SetSelectedTags(IEnumerable<Tag> tags) => SetItems(LvSelect, tags);

        private void SetItems(ListView view, IEnumerable<Tag> tags)
        {
            var items = view.Items;
            view.BeginUpdate();
            items.Clear();
            items.AddRange(tags.Select(p => new StagItem(p)).ToArray());
            view.EndUpdate();
        }

        private void SetSorts(IEnumerable<Stag> stags)
        {
            var items = LvOrderBy.Items;
            LvOrderBy.BeginUpdate();
            items.Clear();
            items.AddRange(stags.Select(p => new StagItem(p)).ToArray());
            LvOrderBy.EndUpdate();
        }

        private void UpdateMenu()
        {
            UpdateLocalUI();
            InitActiveControls();

            var indices = FocusSelectedIndices ?? new List<int>();
            var total = FocusItems?.Count ?? 0;
            var targets = new[] { LvSelect, LvOrderBy, LvGroupBy };

            bool
                hasFocus = Focus != null,
                canEdit = targets.Contains(Focus),
                hasAny = total > 0,
                hasSelection = indices.Any() || Focus == TreeView && SelectedNode != null,

                canMoveUp = canEdit,
                canMoveDown = canEdit,
                canSelect = Focus != LvSelect,
                canSort = SortAndGroup,
                canGroup = SortAndGroup && Focus != LvGroupBy,
                canCut = canEdit,
                canCopy = hasFocus,
                canPaste = canEdit,
                canDelete = canEdit,
                canClear = canEdit,
                canSelectAll = canEdit,
                canInvertSelection = canEdit;

            ApplyAll((value, item) => item.Visible = value);

            Dialog.PopupSeparator1.Visible = !canEdit;
            Dialog.PopupSeparator2.Visible = Dialog.PopupSeparator5.Visible = canEdit;

            var count = canEdit ? indices.Count() : 0;

            canMoveUp &= count > 0 && indices.Max() >= count;
            canMoveDown &= count > 0 && indices.Min() < total - count;
            canSelect &= hasSelection;
            canSort &= hasSelection;
            canGroup &= hasSelection;
            canCut &= hasSelection;
            canCopy &= hasSelection;
            canPaste &= StagData.IsOnClipboard();
            canDelete &= hasSelection;
            canClear &= hasAny;
            canSelectAll &= hasAny;
            canInvertSelection &= hasAny;

            ApplyAll((value, item) => item.Enabled = value);

            void ApplyAll(Action<bool, ToolStripItem> action)
            {
                Apply(!canEdit, Dialog.PopupTree, Dialog.PopupList);
                Apply(canMoveUp, PopupMoveUp, TbMoveUp);
                Apply(canMoveDown, PopupMoveDown, TbMoveDown);
                Apply(canSelect, PopupSelect);
                Apply(canSort, PopupSortAscending, PopupSortDescending);
                Apply(canGroup, PopupGroup);
                Apply(canCut, PopupCut, TbCut);
                Apply(canCopy, PopupCopy, TbCopy);
                Apply(canPaste, PopupPaste, TbPaste);
                Apply(canDelete, PopupDelete, TbDelete);
                Apply(canClear, PopupClear);
                Apply(canSelectAll, PopupSelectAll);
                Apply(canInvertSelection, PopupInvertSelection);
                _initializing = false;

                void Apply(bool value, params ToolStripItem[] items)
                {
                    Array.ForEach(items, p => action(value, p));
                    if (_initializing
                        && items.Length == 2
                        && items[0] is ToolStripMenuItem menuItem
                        && items[1] is ToolStripButton button)
                    {
                        button.Image = menuItem.Image;
                        button.ImageTransparentColor = menuItem.ImageTransparentColor;
                        button.Text = menuItem.Text;
                        button.Click += (sender, e) => menuItem.PerformClick();
                    }
                }
            }
        }

        private void UpdateUI()
        {
            bool tree = _TreeViewController.Active;
            TreeAlphabetically.Checked = tree && TagGrouping == TagGrouping.None; ;
            TreeByCategory.Checked = tree && TagGrouping == TagGrouping.Category;
            TreeByDataType.Checked = tree && TagGrouping == TagGrouping.DataType;
            ListAlphabetically.Checked = !tree && TagGrouping == TagGrouping.None && !_multiColumn;
            ListByCategory.Checked = !tree && TagGrouping == TagGrouping.Category;
            ListByDataType.Checked = !tree && TagGrouping == TagGrouping.DataType;
            ListNamesOnly.Checked = !tree && TagGrouping == TagGrouping.None && _multiColumn;
            UpdateMenu();
        }

        private void UseListView(TagGrouping tagGrouping, View view = View.Details) => UseView(useTree: false, tagGrouping, view);
        private void UseTreeView(TagGrouping tagGrouping) => UseView(useTree: true, tagGrouping);

        private void UseView(bool useTree, TagGrouping tagGrouping, View view = View.Details)
        {
            TagGrouping = tagGrouping;
            _multiColumn = view == View.List;
            _ListViewController.ViewMode = view;
            _ListViewController.Active = !useTree;
            _TreeViewController.Active = useTree;
            UpdateUI();
        }

        #endregion
    }
}
