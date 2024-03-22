using System.Runtime.Remoting.Channels;

namespace TagScanner.Menus
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Models;
    using Terms;
    using Utils;

    public static class MenuMaker
    {
        #region Public Methods

        public static void AddAllTerms(ToolStripItemCollection items, EventHandler click)
        {
#if DEBUG
            items.Add("(add test terms)", null, click).Tag = null;
#endif
            items.AddTags(click);
            items.AddOperations(click);
            items.AddFunctions(click);
            items.AddCasts(click);
            items.Add("&Value...", null, click).Tag = 0;
        }

        public static bool FilterItems(this ToolStripItemCollection items, Filter action, params Type[] types)
        {
            var result = false;
            foreach (var item in items.OfType<ToolStripMenuItem>())
            {
                Filter
                    target = action & Filter.Target,
                    act = action & Filter.Action;
                var subItems = item.DropDownItems;
                var ok = act == Filter.None || (subItems.Count > 0
                    ? subItems.FilterItems(action, types)
                    : item.IncludeTerm(target, types));
                item.Enabled = ok || act != Filter.Disable;
                item.Visible = ok || act != Filter.Hide;
                result |= ok;
            }
            return result;
        }

        #endregion

        #region Private Methods

        private static void AddCasts(this ToolStripItemCollection items, EventHandler click)
        {
            items = items.Append("&Cast");
            foreach (var type in Cast.NewTypes)
                items.Append(type.Say(), type, click);
        }

        private static void AddFunctions(this ToolStripItemCollection items, EventHandler click)
        {
            items = items.Append("&Function");
            foreach (var key in Methods.Keys.Where(p => p.IndexOf('_') < 0))
                items.Append(key, key, click);
        }

        private static void AddOperations(this ToolStripItemCollection items, EventHandler click)
        {
            var images = new[]
            {
                Properties.Resources.Op_Conditional,
                Properties.Resources.Op_And,
                Properties.Resources.Op_Or,
                Properties.Resources.Op_Xor,
                Properties.Resources.Op_EqualTo,
                Properties.Resources.Op_NotEqualTo,
                Properties.Resources.Op_LessThan,
                Properties.Resources.Op_NotLessThan,
                Properties.Resources.Op_GreaterThan,
                Properties.Resources.Op_NotGreaterThan,
                Properties.Resources.Op_Concatenate,
                Properties.Resources.Op_Add,
                Properties.Resources.Op_Subtract,
                Properties.Resources.Op_Multiply,
                Properties.Resources.Op_Divide,
                Properties.Resources.Op_Add,
                Properties.Resources.Op_Subtract,
                Properties.Resources.Op_Not,
            };
            items = items.Append("&Operation");
            foreach (var op in Operators.Keys)
                items.Append(op.ToString(), op, click, images[(int)op]);
        }

        private static void AddTags(this ToolStripItemCollection items, EventHandler click)
        {
            items = items.Append("&Tag");
            var tags = Tags.Keys.OrderBy(p => p.Category()).ThenBy(p => p.DisplayName());
            var categories = tags.Select(p => p.Category()).Distinct();
            foreach (var category in categories)
            {
                var subItems = ((ToolStripMenuItem)items.Add(category.Escape())).DropDownItems;
                foreach (var tag in tags.Where(p => p.Category() == category))
                    subItems.Add(new ToolStripMenuItem(tag.DisplayName().Escape(), null, click)
                        { Tag = tag, ToolTipText = tag.Details() });
            }
        }

        private static ToolStripItemCollection Append(this ToolStripItemCollection items, string text, Image image = null)
        {
            var item = new ToolStripMenuItem(text, image) { ImageTransparentColor = Color.White };
            items.Add(item);
            return item.DropDownItems;
        }

        private static void Append(this ToolStripItemCollection items, string text, object info, EventHandler click, Image image = null) =>
            items.Add(new ToolStripMenuItem(text, image, click) { ImageTransparentColor = Color.White, Tag = info });

        private static bool IncludeTerm(this ToolStripItem item, Filter target, IEnumerable<Type> types)
        {
            var key = item.Tag;
            if (key == null)
                return true; ;
            switch (key)
            {
                case Tag tag:
                    return types.Contains(tag.Type());
                case Op _:
                case string _:
                    return true;
                default:
                    return false;
            }
        }

        #endregion
    }
}
