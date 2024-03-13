﻿namespace TagScanner.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Models;
    using Views;
    
    internal class TagsController : Controller
    {
        #region Public Interface

        internal TagsController(Controller parent) : base(parent)
        {
            _tagsListViewController = new TagsListViewController(this);
            _tagsTreeViewController = new TagsTreeViewController(this);
        }

        internal GroupTagsBy GroupTagsBy;

        internal override Form Form => Dialog;

        internal bool Execute(string caption, List<string> visibleTagNames)
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

        private readonly TagsListViewController _tagsListViewController;
        private readonly TagsTreeViewController _tagsTreeViewController;
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
            _tagsListViewController.InitListView();
            Dialog.ListAlphabetically.Click += (sender, e) => UseListView(View.Details, GroupTagsBy.None);
            Dialog.ListByCategory.Click += (sender, e) => UseListView(View.Details, GroupTagsBy.Category);
            Dialog.ListByDataType.Click += (sender, e) => UseListView(View.Details, GroupTagsBy.DataType);
            Dialog.ListNamesOnly.Click += (sender, e) => UseListView(View.List, GroupTagsBy.None);
            _tagsTreeViewController.InitTreeView();
            Dialog.TreeByCategory.Click += (sender, e) => UseTreeView(GroupTagsBy.Category);
            Dialog.TreeByDataType.Click += (sender, e) => UseTreeView(GroupTagsBy.DataType);
            Dialog.TreeNamesOnly.Click += (sender, e) => UseTreeView(GroupTagsBy.None);
            Dialog.ListByCategory.PerformClick();
            return Dialog;
        }

        private void UseListView(View view, GroupTagsBy groupTagsBy)
        {
            GroupTagsBy = groupTagsBy;
            _tagsTreeViewController.HideView();
            _tagsListViewController.ShowView();
            _tagsListViewController.ListView.View = view;
        }

        private void UseTreeView(GroupTagsBy groupTagsBy)
        {
            GroupTagsBy = groupTagsBy;
            _tagsListViewController.HideView();
            _tagsTreeViewController.ShowView();
        }

        #endregion

        #endregion
    }
}
