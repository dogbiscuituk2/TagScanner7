namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Forms;
    using Models;

    public class TagSelectController : Controller
    {
        #region Constructors

        public TagSelectController(Controller parent) : this(parent, p => true) { }

        public TagSelectController(Controller parent, Func<Tag, bool> tagFilter) : base(parent)
        {
            AvailableTags = Tags.Keys.Where(tagFilter);

            _tagListController = new TagListController(this, Dialog.ListView);
            _tagTreeController = new TagTreeController(this, Dialog.TreeView);

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

            TpSelected = Dialog.tpSelected;
            LvSelected = Dialog.lvSelected;
            TpOrderBy = Dialog.tpOrderBy;
            LvOrderBy = Dialog.lvOrderBy;
            TpOrderBy = Dialog.tpOrderBy;
            LvOrderBy = Dialog.lvOrderBy;

            _tagTreeController.InitView();
            TreeAlphabetically.Click += TreeAlphabetically_Click;
            TreeByCategory.Click += TreeByCategory_Click;
            TreeByDataType.Click += TreeByDataType_Click;
            tbTreeAlpha.Click += TreeAlphabetically_Click;
            tbTreeCat.Click += TreeByCategory_Click;
            tbTreeType.Click += TreeByDataType_Click;

            _tagListController.InitView();
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
            SetSelectedTags(query.Tags);
            SetOrderByTags(query.Sorts);
            SetGroupByTags(query.Groups);
            var ok = Dialog.ShowDialog(Owner) == DialogResult.OK;
            if (ok)
            {
                query.Tags = ActiveController.GetSelectedTags().ToArray();
                query.Sorts = GetOrderByTags().ToArray();
                query.Groups = GetGroupByTags().ToArray();
            }
            return ok;
        }

        public bool Execute(string caption, List<Tag> selectedTags)
        {
            Dialog.Text = caption;
            SetSelectedTags(selectedTags);
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
            Update(LvSelected, GetSelectedTags());
            Update(LvOrderBy, GetOrderByTags());
            Update(LvGroupBy, GetGroupByTags());

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

        private readonly TabPage TpSelected, TpOrderBy, TpGroupBy;
        private readonly ListView LvSelected, LvOrderBy, LvGroupBy;

        private TagSelectDialog _dialog;
        private readonly TagListController _tagListController;
        private readonly TagTreeController _tagTreeController;

        #endregion

        #region Private Properties

        private TagViewController ActiveController => _tagListController.Active ? _tagListController : (TagViewController)_tagTreeController;
        private TagSelectDialog Dialog => _dialog ?? CreateDialog();

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

        private TagSelectDialog CreateDialog()
        {
            _dialog = new TagSelectDialog();

            return Dialog;
        }

        private IEnumerable<Tag> GetGroupByTags() => new List<Tag>();
        private IEnumerable<Tag> GetOrderByTags() => new List<Tag>();
        private IEnumerable<Tag> GetSelectedTags() => ActiveController.GetSelectedTags();

        private void SetGroupByTags(IEnumerable<Tag> selectedTags) { }
        private void SetOrderByTags(IEnumerable<Tag> selectedTags) { }
        private void SetSelectedTags(IEnumerable<Tag> selectedTags) => ActiveController.SetSelectedTags(selectedTags);

        private void UpdateUI()
        {
            bool tree = _tagTreeController.Active;
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
            var selectedTags = GetSelectedTags();
            ListTagsBy = listTagsBy;
            MultiColumn = multiColumn;
            _tagListController.ViewMode = multiColumn ? View.List : View.Details;
            _tagListController.Active = !tree;
            _tagTreeController.Active = tree;
            SetSelectedTags(selectedTags);
            UpdateUI();
        }

        #endregion
    }
}
