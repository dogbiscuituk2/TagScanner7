namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Forms;
    using Models;

    public class TagsController : Controller
    {
        #region Constructors

        public TagsController(Controller parent) : this(parent, p => true) { }

        public TagsController(Controller parent, Func<Tag, bool> tagFilter) : base(parent)
        {
            AvailableTags = Tags.Keys.Where(tagFilter);
            _tagsListController = new TagsListController(this);
            _tagsTreeController = new TagsTreeController(this);
        }

        #endregion

        #region Public Properties

        public IEnumerable<Tag> AvailableTags { get; private set; }

        public GroupTagsBy GroupTagsBy;

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
                selectedTags.AddRange(_tagsListController.GetSelectedTags());
            }
            return ok;
        }

        #endregion

        #region Private Fields

        private static TagVisibilityDialog _dialog;
        private readonly TagsListController _tagsListController;
        private readonly TagsTreeController _tagsTreeController;

        #endregion

        #region Private Properties

        private TagsViewController ActiveController => _tagsListController.Active ? _tagsListController : (TagsViewController)_tagsTreeController;
        public TagVisibilityDialog Dialog => _dialog ?? CreateDialog();

        #endregion

        #region Private Methods

        private TagVisibilityDialog CreateDialog()
        {
            _dialog = new TagVisibilityDialog();

            _tagsListController.InitView();
            Dialog.ListAlphabetically.Click += (sender, e) => UseListView(View.Details, GroupTagsBy.None);
            Dialog.ListByCategory.Click += (sender, e) => UseListView(View.Details, GroupTagsBy.Category);
            Dialog.ListByDataType.Click += (sender, e) => UseListView(View.Details, GroupTagsBy.DataType);
            Dialog.ListNamesOnly.Click += (sender, e) => UseListView(View.List, GroupTagsBy.None);

            _tagsTreeController.InitView();
            Dialog.TreeByCategory.Click += (sender, e) => UseTreeView(GroupTagsBy.Category);
            Dialog.TreeByDataType.Click += (sender, e) => UseTreeView(GroupTagsBy.DataType);
            Dialog.TreeNamesOnly.Click += (sender, e) => UseTreeView(GroupTagsBy.None);

            Dialog.ListByCategory.PerformClick();
            return Dialog;
        }

        private IEnumerable<Tag> GetSelectedTags() => ActiveController.GetSelectedTags();
        private void SetSelectedTags(IEnumerable<Tag> selectedTags) => ActiveController.SetSelectedTags(selectedTags);

        private void UseListView(View view, GroupTagsBy groupTagsBy)
        {
            var selectedTags = GetSelectedTags();
            GroupTagsBy = groupTagsBy;
            _tagsTreeController.HideView();
            _tagsListController.ShowView(view);
            SetSelectedTags(selectedTags);
        }

        private void UseTreeView(GroupTagsBy groupTagsBy)
        {
            var selectedTags = GetSelectedTags();
            GroupTagsBy = groupTagsBy;
            _tagsListController.HideView();
            _tagsTreeController.ShowView();
            SetSelectedTags(selectedTags);
        }

        #endregion
    }
}
