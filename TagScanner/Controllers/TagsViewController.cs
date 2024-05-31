namespace TagScanner.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Models;
    using Terms;
    using Forms;
    using System;

    public abstract class TagsViewController : Controller
    {
        #region Public Interface

        protected TagsViewController(Controller parent) : base(parent) { }

        private TagsController TagsController => Parent as TagsController;

        public abstract Control Control { get; }
        public TagVisibilityDialog Dialog => TagsController?.Dialog;
        public GroupTagsBy GroupTagsBy => ((TagsController)Parent).GroupTagsBy;

        public void HideView() => Control?.Hide();

        public void ShowView()
        {
            Control.Visible = true;
            Control.BringToFront();
            Control.Dock = DockStyle.Fill;
            InitGroups();
        }

        #endregion

        #region Protected Implementation

        protected string GetGroupHeader(Tag tag)
        {
            switch (GroupTagsBy)
            {
                case GroupTagsBy.Category: return tag.Category();
                case GroupTagsBy.DataType: return tag.TypeName();
                default: return string.Empty;
            }
        }

        public abstract IEnumerable<Tag> GetSelectedTags();
        protected abstract void InitGroups();
        public abstract void SetSelectedTags(IEnumerable<Tag> visibleTags, Func<Tag, bool> tagFilter);

        protected IEnumerable<TagInfo> SortTags()
        {
            IEnumerable<TagInfo> tagInfo = Tags.Values;
            switch (GroupTagsBy)
            {
                case GroupTagsBy.Category: return tagInfo.OrderBy(t => t.Category).ThenBy(t => t.DisplayName);
                case GroupTagsBy.DataType: return tagInfo.OrderBy(t => t.TypeName).ThenBy(t => t.DisplayName);
                default: return tagInfo.OrderBy(t => t.DisplayName);
            }
        }

        #endregion
    }
}
