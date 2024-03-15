namespace TagScanner.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Models;
    using Terms;
    using Views;

    internal abstract class TagsViewController : Controller
    {
        #region Public Interface

        protected TagsViewController(Controller parent) : base(parent) { }

        internal abstract Control Control { get; }
        internal TagVisibilityDialog Dialog => (TagVisibilityDialog)Form;
        internal GroupTagsBy GroupTagsBy => ((TagsController)Parent).GroupTagsBy;

        internal void HideView() => Control?.Hide();

        internal void ShowView()
        {
            Control.Visible = true;
            Control.BringToFront();
            Control.Dock = DockStyle.Fill;
            InitGroups();
        }

        #endregion

        #region Protected Implementation

        protected string GetGroupHeader(TagInfo tag)
        {
            switch (GroupTagsBy)
            {
                case GroupTagsBy.Category: return tag.Category;
                case GroupTagsBy.DataType: return tag.TypeName;
                default: return string.Empty;
            }
        }

        public abstract List<Tag> GetVisibleTags();
        protected abstract void InitGroups();
        public abstract void SetVisibleTags(List<Tag> visibleTags);

        protected IEnumerable<TagInfo> SortTags()
        {
            IEnumerable<TagInfo> tagInfo = Core.Tags.Values;
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
