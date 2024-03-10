namespace TagScanner.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using TagScanner.Models;
    using TagScanner.Views;

    public abstract class TagsViewController : Controller
    {
        #region Public Interface

        public TagsViewController(Controller parent) : base(parent) { }

        public abstract Control Control { get; }
        public TagVisibilityDialog Dialog => (TagVisibilityDialog)Form;
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

        protected string GetGroupHeader(TagProps tag)
        {
            switch (GroupTagsBy)
            {
                case GroupTagsBy.Category: return tag.Category;
                case GroupTagsBy.DataType: return tag.TypeName;
                default: return string.Empty;
            }
        }

        protected abstract IEnumerable<string> GetVisibleTags();
        protected abstract void InitGroups();
        protected abstract void SetVisibleTags(IEnumerable<string> visibleTagNames);

        protected IEnumerable<TagProps> SortTags()
        {
            IEnumerable<TagProps> tags = Tags.AllTags;
            switch (GroupTagsBy)
            {
                case GroupTagsBy.Category: return tags.OrderBy(t => t.Category).ThenBy(t => t.DisplayName);
                case GroupTagsBy.DataType: return tags.OrderBy(t => t.TypeName).ThenBy(t => t.DisplayName);
                default: return tags.OrderBy(t => t.DisplayName);
            }
        }

        #endregion
    }
}
