namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Models;

    public abstract class TagsViewController : Controller
    {
        #region Constructor

        public TagsViewController(Controller parent, Control control) : base(parent) { Control = control; }

        #endregion

        #region Public Properties

        private bool _active;
        public bool Active
        {
            get => _active;
            set
            {
                _active = value;
                Control.Visible = Active;
                if (Active)
                {
                    Control.BringToFront();
                    Control.Dock = DockStyle.Fill;
                    InitGroups();
                }
            }
        }

        #endregion

        #region Public Methods

        public abstract IEnumerable<Tag> GetSelectedTags();
        public abstract void SetSelectedTags(IEnumerable<Tag> visibleTags);

        #endregion

        #region Protected Properties

        protected IEnumerable<Tag> AvailableTags => TagsSelectorController.AvailableTags;
        protected Control Control { get; private set; }
        protected GroupTagsBy GroupTagsBy => TagsSelectorController.GroupTagsBy;

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

        private TagsSelectorController TagsSelectorController => Parent as TagsSelectorController;

        #endregion
    }
}
