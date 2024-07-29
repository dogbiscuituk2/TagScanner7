namespace TagScanner.Controllers
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Models;

    public abstract class QueryViewController : Controller
    {
        #region Constructor

        public QueryViewController(Controller parent, Control control) : base(parent) { Control = control; }

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

        #region Protected Properties

        protected IEnumerable<Tag> AvailableTags => QueryController.AvailableTags;
        protected Control Control { get; private set; }
        protected Color ReadOnlyColour => Color.FromKnownColor(KnownColor.GrayText);
        protected TagGrouping TagGrouping => QueryController.TagGrouping;

        #endregion

        #region Protected Methods

        protected void GetColours(bool selected, bool canWrite, out Color fore, out Color back)
        {
            fore = Color.FromKnownColor(
                selected && Control.Focused ? KnownColor.HighlightText :
                selected || canWrite ? KnownColor.WindowText :
                KnownColor.GrayText);

            back = Color.FromKnownColor(
                selected ? Control.Focused ? KnownColor.Highlight : KnownColor.InactiveCaption : KnownColor.Window);
        }

        protected string GetGroupHeader(Tag tag)
        {
            switch (TagGrouping)
            {
                case TagGrouping.Category: return tag.Category();
                case TagGrouping.DataType: return tag.TypeName();
                default: return string.Empty;
            }
        }

        protected abstract void InitGroups();

        protected IEnumerable<Tag> SortTags()
        {
            IEnumerable<Tag> tags = AvailableTags;
            switch (TagGrouping)
            {
                case TagGrouping.Category: return tags.OrderBy(t => t.Category()).ThenBy(t => t.DisplayName());
                case TagGrouping.DataType: return tags.OrderBy(t => t.TypeName()).ThenBy(t => t.DisplayName());
                default: return tags.OrderBy(t => t.DisplayName());
            }
        }

        #endregion

        #region Private Fields

        private bool _active;

        #endregion

        #region Private Properties

        private QueryController QueryController => Parent as QueryController;

        #endregion
    }
}
