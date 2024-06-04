namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    using Forms;
    using Models;

    public class TagsSelectorController : Controller
    {
        #region Constructors

        public TagsSelectorController(Controller parent) : this(parent, p => true) { }

        public TagsSelectorController(Controller parent, Func<Tag, bool> tagFilter) : base(parent)
        {
            AvailableTags = Tags.Keys.Where(tagFilter);

            _tagsListController = new TagsListController(this, Dialog.ListView);
            _tagsTreeController = new TagsTreeController(this, Dialog.TreeView);

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

            TbSearchFields = Dialog.tbSearchFields;
            GbSelectedTags = Dialog.gbSelectedTags;
            PopupRemove = Dialog.PopupRemove;
            PopupMenu = Dialog.PopupMenu;

            _tagsTreeController.InitView();
            TreeAlphabetically.Click += TreeAlphabetically_Click;
            TreeByCategory.Click += TreeByCategory_Click;
            TreeByDataType.Click += TreeByDataType_Click;
            tbTreeAlpha.Click += TreeAlphabetically_Click;
            tbTreeCat.Click += TreeByCategory_Click;
            tbTreeType.Click += TreeByDataType_Click;

            _tagsListController.InitView();
            ListAlphabetically.Click += ListAlphabetically_Click;
            ListByCategory.Click += ListByCategory_Click;
            ListByDataType.Click += ListByDataType_Click;
            ListNamesOnly.Click += ListNamesOnly_Click;
            tbListAlpha.Click += ListAlphabetically_Click;
            tbListCat.Click += ListByCategory_Click;
            tbListType.Click += ListByDataType_Click;
            tbListNames.Click += ListNamesOnly_Click;

            PopupMenu.Opening += PopupMenu_Opening;
            PopupRemove.Click += PopupRemove_Click;

            UseTreeView(GroupTagsBy.Category);
        }

        #endregion

        #region Public Properties

        public IEnumerable<Tag> AvailableTags { get; private set; }

        public GroupTagsBy GroupTagsBy;
        private bool MultiColumn;

        #endregion

        #region Public Methods

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

        #endregion

        #region Private Fields

        private TagSelectorDialog _dialog;
        private readonly TagsListController _tagsListController;
        private readonly TagsTreeController _tagsTreeController;

        #endregion

        #region Private Properties

        private TagsViewController ActiveController => _tagsListController.Active ? _tagsListController : (TagsViewController)_tagsTreeController;
        private TagSelectorDialog Dialog => _dialog ?? CreateDialog();

        private ToolStripMenuItem
            ListAlphabetically,
            ListByCategory,
            ListByDataType,
            ListNamesOnly,
            TreeAlphabetically,
            TreeByCategory,
            TreeByDataType;

        private ToolStripButton
            tbListAlpha,
            tbListCat,
            tbListType,
            tbListNames,
            tbTreeAlpha,
            tbTreeCat,
            tbTreeType;

        private ContextMenuStrip PopupMenu;
        private ToolStripMenuItem PopupRemove;
        private TextBox TbSearchFields;
        private GroupBox GbSelectedTags;

        #endregion

        #region Event Handlers

        private void ListAlphabetically_Click(object sender, EventArgs e) => UseListView(GroupTagsBy.None);
        private void ListByCategory_Click(object sender, EventArgs e) => UseListView(GroupTagsBy.Category);
        private void ListByDataType_Click(object sender, EventArgs e) => UseListView(GroupTagsBy.DataType);
        private void ListNamesOnly_Click(object sender, EventArgs e) => UseListView(GroupTagsBy.None, true);
        private void PopupMenu_Opening(object sender, CancelEventArgs e) => UpdatePopupMenu();
        private void PopupRemove_Click(object sender, EventArgs e) => DeselectTags();
        private void TreeAlphabetically_Click(object sender, EventArgs e) => UseTreeView(GroupTagsBy.None);
        private void TreeByCategory_Click(object sender, EventArgs e) => UseTreeView(GroupTagsBy.Category);
        private void TreeByDataType_Click(object sender, EventArgs e) => UseTreeView(GroupTagsBy.DataType);


        #endregion

        #region Private Methods

        private TagSelectorDialog CreateDialog()
        {
            _dialog = new TagSelectorDialog();

            return Dialog;
        }

        private void DeselectTags()
        {
            var text = TbSearchFields.Text;
            int
                start = TbSearchFields.SelectionStart,
                end = start + TbSearchFields.SelectionLength,
                first = 0,
                count = 0;
            for (int index = 0, p = 0, q; p < end; index++, p = q + 2)
            {
                q = text.IndexOf(',', p);
                if (q < 0)
                    q = text.Length;
                if (start <= q && end >= p && count++ == 0)
                    first = index;
            }
            if (count > 0)
            {
                var tags = GetSelectedTags();
                var drop = tags.Skip(first).Take(count);
                SetSelectedTags(tags.Except(drop));
            }
        }

        private IEnumerable<Tag> GetSelectedTags() => ActiveController.GetSelectedTags();
        private void SetSelectedTags(IEnumerable<Tag> selectedTags) => ActiveController.SetSelectedTags(selectedTags);

        private void UpdatePopupMenu() => PopupRemove.Enabled = TbSearchFields.SelectionLength > 0;

        public void UpdateSelection()
        {
            var tags = GetSelectedTags();
            TbSearchFields.Text = tags.Say();
            GbSelectedTags.Enabled = PopupRemove.Enabled = tags.Any();
        }

        private void UpdateUI()
        {
            bool tree = _tagsTreeController.Active;
            TreeAlphabetically.Checked = tbTreeAlpha.Checked = tree && GroupTagsBy == GroupTagsBy.None; ;
            TreeByCategory.Checked = tbTreeCat.Checked = tree && GroupTagsBy == GroupTagsBy.Category;
            TreeByDataType.Checked = tbTreeType.Checked = tree && GroupTagsBy == GroupTagsBy.DataType;
            ListAlphabetically.Checked = tbListAlpha.Checked = !tree && GroupTagsBy == GroupTagsBy.None && !MultiColumn;
            ListByCategory.Checked = tbListCat.Checked = !tree && GroupTagsBy == GroupTagsBy.Category;
            ListByDataType.Checked = tbListType.Checked = !tree && GroupTagsBy == GroupTagsBy.DataType;
            ListNamesOnly.Checked = tbListNames.Checked = !tree && GroupTagsBy == GroupTagsBy.None && MultiColumn;
            UpdateSelection();
        }

        private void UseListView(GroupTagsBy groupTagsBy, bool multiColumn = false) => UseTreeView(groupTagsBy, tree: false, multiColumn);

        private void UseTreeView(GroupTagsBy groupTagsBy, bool tree = true, bool multiColumn = false)
        {
            var selectedTags = GetSelectedTags();
            GroupTagsBy = groupTagsBy;
            MultiColumn = multiColumn;
            _tagsListController.ViewMode = multiColumn ? View.List : View.Details;
            _tagsListController.Active = !tree;
            _tagsTreeController.Active = tree;
            SetSelectedTags(selectedTags);
            UpdateUI();
        }

        #endregion
    }
}
