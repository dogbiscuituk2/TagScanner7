namespace TagScanner.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Forms;
    using Models;

    public abstract class TagsViewController : Controller
    {
        #region Constructor

        public TagsViewController(Controller parent) : base(parent) { }

        #endregion

        #region Public Properties

        public bool Active => Control.Visible;

        #endregion

        #region Public Methods

        public void HideView() => Control.Hide();

        public void ShowView()
        {
            Control.Visible = true;
            Control.BringToFront();
            Control.Dock = DockStyle.Fill;
            InitGroups();
        }

        public abstract IEnumerable<Tag> GetSelectedTags();
        public abstract void SetSelectedTags(IEnumerable<Tag> visibleTags);

        #endregion

        #region Protected Properties

        protected IEnumerable<Tag> AvailableTags => TagsController.AvailableTags;
        protected abstract Control Control { get; }
        protected TagSelectorDialog Dialog => TagsController.Dialog;
        protected GroupTagsBy GroupTagsBy => TagsController.GroupTagsBy;

        #endregion

        #region Protected Methods

        protected string GetGroupHeader(Tag tag)
        {
            switch (GroupTagsBy)
            {
                case GroupTagsBy.Category: return tag.Category();
                case GroupTagsBy.DataType: return tag.TypeName();
                default: return string.Empty;
            }
        }

        protected abstract void InitGroups();

        protected IEnumerable<TagInfo> SortTags()
        {
            IEnumerable<TagInfo> tagInfo = AvailableTags.Select(p => p.TagToTagInfo());
            switch (GroupTagsBy)
            {
                case GroupTagsBy.Category: return tagInfo.OrderBy(t => t.Category).ThenBy(t => t.DisplayName);
                case GroupTagsBy.DataType: return tagInfo.OrderBy(t => t.TypeName).ThenBy(t => t.DisplayName);
                default: return tagInfo.OrderBy(t => t.DisplayName);
            }
        }

        #endregion

        #region Private Properties

        private TagsController TagsController => Parent as TagsController;

        #endregion
    }
}
