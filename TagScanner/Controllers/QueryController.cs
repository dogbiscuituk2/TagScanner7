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

            PopupTargetMenu = Dialog.PopupTargetMenu;
            PopupTargetCut = Dialog.PopupTargetCut;
            PopupTargetCopy = Dialog.PopupTargetCopy;
            PopupTargetPaste = Dialog.PopupTargetPaste;
            PopupTargetDelete = Dialog.PopupTargetDelete;
            PopupTargetMoveUp = Dialog.PopupTargetMoveUp;
            PopupTargetMoveDown = Dialog.PopupTargetMoveDown;

            LvSelected = Dialog.lvSelected;
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

            LvSelected.GotFocus += ListView_GotFocus;
            LvOrderBy.GotFocus += ListView_GotFocus;
            LvGroupBy.GotFocus += ListView_GotFocus;

            PopupTargetMenu.Opening += PopupTargetMenu_Opening;

            UseTreeView(ListTagsBy.Category);
        }

        #endregion

        #region Public Properties

        public IEnumerable<Tag> AvailableTags { get; private set; }

        #endregion

        #region Public Fields

        public ListTagsBy ListTagsBy;

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
            {
                //query.Tags = ActiveController.GetSelectedTags().ToArray();
                //query.Sorts = GetOrderByTags().ToArray();
                //query.Groups = GetGroupByTags().ToArray();
            }
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
            UpdateTags(LvSelected, GetTags());
            UpdateSorts(LvOrderBy, GetSorts());
            UpdateTags(LvGroupBy, GetGroups());

            // TODO: polymorphise!

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

        private ListView ActiveTarget;
        private bool MultiColumn;

        private readonly ContextMenuStrip PopupTargetMenu;

        private readonly ToolStripMenuItem
            ListAlphabetically,
            ListByCategory,
            ListByDataType,
            ListNamesOnly,
            TreeAlphabetically,
            TreeByCategory,
            TreeByDataType,
            PopupTargetCut,
            PopupTargetCopy,
            PopupTargetPaste,
            PopupTargetDelete,
            PopupTargetMoveUp,
            PopupTargetMoveDown;

        private readonly ToolStripButton
            tbListAlpha,
            tbListCat,
            tbListType,
            tbListNames,
            tbTreeAlpha,
            tbTreeCat,
            tbTreeType;

        private readonly ListView LvSelected, LvOrderBy, LvGroupBy;

        private static QueryDialog _dialog;
        private readonly QueryListViewController _queryListViewController;
        private readonly QueryTreeViewController _queryTreeViewController;

        #endregion

        #region Private Properties

        private QueryViewController ActiveController =>
            _queryListViewController.Active
            ? _queryListViewController
            : (QueryViewController)_queryTreeViewController;

        private QueryDialog Dialog => _dialog ?? CreateDialog();

        #endregion

        #region Event Handlers

        private void ListAlphabetically_Click(object sender, EventArgs e) => UseListView(ListTagsBy.None);
        private void ListByCategory_Click(object sender, EventArgs e) => UseListView(ListTagsBy.Category);
        private void ListByDataType_Click(object sender, EventArgs e) => UseListView(ListTagsBy.DataType);
        private void ListNamesOnly_Click(object sender, EventArgs e) => UseListView(ListTagsBy.None, true);
        private void ListView_GotFocus(object sender, EventArgs e) { ActiveTarget = sender as ListView; System.Diagnostics.Debug.WriteLine((sender as Control).Name); }
        private void PopupTargetMenu_Opening(object sender, CancelEventArgs e) => PopupOpening();
        private void TreeAlphabetically_Click(object sender, EventArgs e) => UseTreeView(ListTagsBy.None);
        private void TreeByCategory_Click(object sender, EventArgs e) => UseTreeView(ListTagsBy.Category);
        private void TreeByDataType_Click(object sender, EventArgs e) => UseTreeView(ListTagsBy.DataType);

        #endregion

        #region Private Methods

        private QueryDialog CreateDialog()
        {
            _dialog = new QueryDialog();
            MainTagDragDropController.Add
                (
                _dialog.ListView,
                _dialog.TreeView,
                _dialog.lvSelected,
                _dialog.lvOrderBy,
                _dialog.lvGroupBy
                );
            return Dialog;
        }

        private IEnumerable<Tag> GetGroups() => new List<Tag>();

        private IEnumerable<SortDescription> GetSorts() =>
            LvOrderBy.Items.Cast<TagListItem>().Select(p => new SortDescription(p.Name, p.SortDirection));

        private IEnumerable<Tag> GetTags() => ActiveController.GetSelectedTags();

        private void PopupOpening()
        {
            if (ActiveTarget == null) return;
            var total = ActiveTarget.Items.Count;
            var indices = ActiveTarget.SelectedIndices.Cast<int>();
            var count = indices.Count();
            bool hasSelection = indices.Any();
            PopupTargetCut.Enabled = PopupTargetCopy.Enabled = PopupTargetDelete.Enabled = hasSelection;
            PopupTargetMoveUp.Enabled = hasSelection && indices.Max() >= count;
            PopupTargetMoveDown.Enabled = hasSelection && indices.Min() < total - count;
        }

        private void SetGroups(IEnumerable<Tag> tags)
        {
            LvGroupBy.Items.AddRange(tags.Select(p => new ListViewItem($"{p}")).ToArray());
        }

        private void SetSorts(IEnumerable<SortDescription> sorts)
        {
            LvOrderBy.Items.AddRange(sorts.Select(p => new ListViewItem($"{p}")
            {
                StateImageIndex = p.Direction == ListSortDirection.Ascending ? 0 : 1
            }
            ).ToArray());
        }

        private void SetTags(IEnumerable<Tag> selectedTags)
        {
            ActiveController.SetSelectedTags(selectedTags);
        }

        private void UpdateUI()
        {
            bool tree = _queryTreeViewController.Active;
            TreeAlphabetically.Checked = tbTreeAlpha.Checked = tree && ListTagsBy == ListTagsBy.None; ;
            TreeByCategory.Checked = tbTreeCat.Checked = tree && ListTagsBy == ListTagsBy.Category;
            TreeByDataType.Checked = tbTreeType.Checked = tree && ListTagsBy == ListTagsBy.DataType;
            ListAlphabetically.Checked = tbListAlpha.Checked = !tree && ListTagsBy == ListTagsBy.None && !MultiColumn;
            ListByCategory.Checked = tbListCat.Checked = !tree && ListTagsBy == ListTagsBy.Category;
            ListByDataType.Checked = tbListType.Checked = !tree && ListTagsBy == ListTagsBy.DataType;
            ListNamesOnly.Checked = tbListNames.Checked = !tree && ListTagsBy == ListTagsBy.None && MultiColumn;
            UpdateSelection();
        }

        private void UseListView(ListTagsBy listTagsBy, bool multiColumn = false) => UseTreeView(listTagsBy, tree: false, multiColumn);

        private void UseTreeView(ListTagsBy listTagsBy, bool tree = true, bool multiColumn = false)
        {
            var selectedTags = GetTags();
            ListTagsBy = listTagsBy;
            MultiColumn = multiColumn;
            _queryListViewController.ViewMode = multiColumn ? View.List : View.Details;
            _queryListViewController.Active = !tree;
            _queryTreeViewController.Active = tree;
            SetTags(selectedTags);
            UpdateUI();
        }

        #endregion
    }
}
