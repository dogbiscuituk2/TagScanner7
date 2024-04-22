namespace TagScanner.Controllers
{
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Models;
    using Views;

    public class TagsController : Controller
    {
        #region Public Interface

        public TagsController(Controller parent) : base(parent)
        {
            _tagsListController = new TagsListController(this);
            _tagsTreeController = new TagsTreeController(this);
        }

        public GroupTagsBy GroupTagsBy;

        public bool Execute(string caption, List<Tag> visibleTags)
        {
            Dialog.Text = caption;
            _tagsListController.SetVisibleTags(visibleTags);
            var ok = Dialog.ShowDialog(Owner) == DialogResult.OK;
            if (ok)
            {
                visibleTags.Clear();
                visibleTags.AddRange(_tagsListController.GetSelectedTags());
            }
            return ok;
        }

        #endregion

        #region Private Implementation

        #region Private Fields

        private readonly TagsListController _tagsListController;
        private readonly TagsTreeController _tagsTreeController;
        private static TagVisibilityDialog _dialog;

        #endregion

        #region Private Properties

        public TagVisibilityDialog Dialog => _dialog ?? CreateDialog();
        private List<Tag> VisibleTags { get; set; }

        #endregion

        #region Private Methods

        private TagVisibilityDialog CreateDialog()
        {
            _dialog = new TagVisibilityDialog();

            _tagsListController.InitListView();
            Dialog.ListAlphabetically.Click += (sender, e) => UseListView(View.Details, GroupTagsBy.None);
            Dialog.ListByCategory.Click += (sender, e) => UseListView(View.Details, GroupTagsBy.Category);
            Dialog.ListByDataType.Click += (sender, e) => UseListView(View.Details, GroupTagsBy.DataType);
            Dialog.ListNamesOnly.Click += (sender, e) => UseListView(View.List, GroupTagsBy.None);

            _tagsTreeController.InitTreeView();
            Dialog.TreeByCategory.Click += (sender, e) => UseTreeView(GroupTagsBy.Category);
            Dialog.TreeByDataType.Click += (sender, e) => UseTreeView(GroupTagsBy.DataType);
            Dialog.TreeNamesOnly.Click += (sender, e) => UseTreeView(GroupTagsBy.None);
            Dialog.ListByCategory.PerformClick();

            return Dialog;
        }

        private void UseListView(View view, GroupTagsBy groupTagsBy)
        {
            GroupTagsBy = groupTagsBy;
            _tagsTreeController.HideView();
            _tagsListController.ShowView();
            _tagsListController.ListView.View = view;
        }

        private void UseTreeView(GroupTagsBy groupTagsBy)
        {
            GroupTagsBy = groupTagsBy;
            _tagsListController.HideView();
            _tagsTreeController.ShowView();
        }

        #endregion

        #endregion
    }
}
