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

            LvSelected = Dialog.lvSelected;
            LvOrderBy = Dialog.lvOrderBy;
            LvOrderBy = Dialog.lvOrderBy;

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
            Update(LvSelected, GetTags());
            Update(LvOrderBy, GetSorts());
            Update(LvGroupBy, GetGroups());

            void Update(ListView view, IEnumerable<Tag> tags)
            {
                if (view == null)
                    return;
                view.Clear();
                view.Items.AddRange(tags.Select(p => new ListViewItem($"{p}")).ToArray());
            }
        }

        #endregion

        #region Private Fields

        private bool MultiColumn;

        private readonly ToolStripMenuItem
            ListAlphabetically,
            ListByCategory,
            ListByDataType,
            ListNamesOnly,
            TreeAlphabetically,
            TreeByCategory,
            TreeByDataType;

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
            LvOrderBy.Items.Cast<ListViewItem>().Select(p => new SortDescription(p.Name, p.StateImageIndex));

        private IEnumerable<Tag> GetTags() => ActiveController.GetSelectedTags();

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
