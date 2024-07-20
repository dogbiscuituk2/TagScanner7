namespace TagScanner.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Models;

    public abstract class TagViewController : Controller
    {
        #region Constructor

        public TagViewController(Controller parent, Control control) : base(parent) { Control = control; }

        #endregion

        #region Public Properties

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

        protected IEnumerable<Tag> AvailableTags => TagSelectController.AvailableTags;
        protected Control Control { get; private set; }
        protected ListTagsBy ListTagsBy => TagSelectController.ListTagsBy;

        #endregion

        #region Protected Methods

        protected string GetGroupHeader(Tag tag)
        {
            switch (ListTagsBy)
            {
                case ListTagsBy.Category: return tag.Category();
                case ListTagsBy.DataType: return tag.TypeName();
                default: return string.Empty;
            }
        }

        protected abstract void InitGroups();

        protected IEnumerable<TagInfo> SortTags()
        {
            IEnumerable<TagInfo> tagInfo = AvailableTags.Select(p => p.TagToTagInfo());
            switch (ListTagsBy)
            {
                case ListTagsBy.Category: return tagInfo.OrderBy(t => t.Category).ThenBy(t => t.DisplayName);
                case ListTagsBy.DataType: return tagInfo.OrderBy(t => t.TypeName).ThenBy(t => t.DisplayName);
                default: return tagInfo.OrderBy(t => t.DisplayName);
            }
        }

        #endregion

        #region Private Fields

        private bool _active;

        #endregion

        #region Private Properties

        private TagSelectController TagSelectController => Parent as TagSelectController;

        #endregion
    }
}
