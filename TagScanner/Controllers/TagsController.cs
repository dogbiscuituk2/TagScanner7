namespace TagScanner.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using TagScanner.Models;
    using TagScanner.Views;
    
    public class TagsController : Controller
    {
        #region Public Interface

        public TagsController(Controller parent) : base(parent)
        {
            TagsListViewController = new TagsListViewController(this);
            TagsTreeViewController = new TagsTreeViewController(this);
        }

        public GroupTagsBy GroupTagsBy;

        public override Form Form => Dialog;

        public bool Execute(string caption, List<string> visibleTagNames)
        {
            Dialog.Text = caption;
            _visibleTagNames = visibleTagNames.ToList();
            //TagsListViewController.SetVisibleTags(visibleTagNames);
            var ok = Dialog.ShowDialog(Parent.Form) == DialogResult.OK;
            if (ok)
            {
                visibleTagNames.Clear();
                visibleTagNames.AddRange(_visibleTagNames);
            }
            return ok;
        }

        #endregion

        #region Private Implementation

        #region Private Fields

        private readonly TagsListViewController TagsListViewController;
        private readonly TagsTreeViewController TagsTreeViewController;
        private static TagVisibilityDialog _dialog;
        private List<string> _visibleTagNames;

        #endregion

        #region Private Properties

        private TagVisibilityDialog Dialog => _dialog ?? CreateDialog();

        #endregion

        #region Private Methods

        private TagVisibilityDialog CreateDialog()
        {
            _dialog = new TagVisibilityDialog();
            TagsListViewController.InitListView();
            Dialog.ListAlphabetically.Click += (sender, e) => UseListView(View.Details, GroupTagsBy.None);
            Dialog.ListByCategory.Click += (sender, e) => UseListView(View.Details, GroupTagsBy.Category);
            Dialog.ListByDataType.Click += (sender, e) => UseListView(View.Details, GroupTagsBy.DataType);
            Dialog.ListNamesOnly.Click += (sender, e) => UseListView(View.List, GroupTagsBy.None);
            TagsTreeViewController.InitTreeView();
            Dialog.TreeByCategory.Click += (sender, e) => UseTreeView(GroupTagsBy.Category);
            Dialog.TreeByDataType.Click += (sender, e) => UseTreeView(GroupTagsBy.DataType);
            Dialog.TreeNamesOnly.Click += (sender, e) => UseTreeView(GroupTagsBy.None);
            Dialog.ListByCategory.PerformClick();
            return Dialog;
        }

        private void UseListView(View view, GroupTagsBy groupTagsBy)
        {
            GroupTagsBy = groupTagsBy;
            TagsTreeViewController.HideView();
            TagsListViewController.ShowView();
            TagsListViewController.ListView.View = view;
        }

        private void UseTreeView(GroupTagsBy groupTagsBy)
        {
            GroupTagsBy = groupTagsBy;
            TagsListViewController.HideView();
            TagsTreeViewController.ShowView();
        }

        #endregion

        #endregion
    }
}
