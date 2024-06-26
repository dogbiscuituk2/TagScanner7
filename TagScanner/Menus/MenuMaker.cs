﻿namespace TagScanner.Menus
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

        public static bool FilterItems(this ToolStripItemCollection items, MenuFilter action, params Type[] types)
        {
            var result = false;
            foreach (var item in items.OfType<ToolStripMenuItem>())
            {
                MenuFilter
                    target = action & MenuFilter.Target,
                    act = action & MenuFilter.Action;
                var subItems = item.DropDownItems;
                var ok = act == MenuFilter.None || (subItems.Count > 0
                    ? subItems.FilterItems(action, types)
                    : item.IncludeTerm(target, types));
                item.Enabled = ok || act != MenuFilter.Disable;
                item.Visible = ok || act != MenuFilter.Hide;
                result |= ok;
            }
            return result;
        }

        #endregion

        #region Private Methods

        private static void AddCasts(this ToolStripItemCollection items, EventHandler click)
        {
            items = items.Append("&Cast");
            foreach (var type in Types.Values)
                items.Append(type.Say(), type, click);
        }

        private static void AddFunctions(this ToolStripItemCollection items, EventHandler click)
        {
            items = items.Append("&Function");
            foreach (var fn in Functors.Keys)
                items.Append($"{fn}", fn, click).ToolTipText = fn.GetPrototype();
        }

        private static void AddOperations(this ToolStripItemCollection items, EventHandler click)
        {
            items = items.Append("&Operation");
            foreach (var op in Operators.Keys)
            {
                var text = op.ToString();
                var opInfo = op.OpInfo();
            }
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

        private static ToolStripMenuItem Append(this ToolStripItemCollection items, string text, object info, EventHandler click, Image image = null)
        {
            var item = new ToolStripMenuItem(text, image, click) { ImageTransparentColor = Color.White, Tag = info };
            items.Add(item);
            return item;
        }

        private static ToolStripMenuItem Append(this ToolStripItemCollection items, string text, object info, EventHandler click, int imageIndex)
        {
            var item = new ToolStripMenuItem(text, null, click) { ImageIndex = imageIndex, Tag = info };
            items.Add(item);
            return item;
        }

        private static bool IncludeTerm(this ToolStripItem item, MenuFilter target, IEnumerable<Type> types)
        {
            var key = item.Tag;
            if (key == null)
                return true; ;
            switch (key)
            {
                case Tag tag:
                    return types.Contains(tag.Type());
                case Op _:
                case Fn _:
                    return true;
                default:
                    return false;
            }
        }

        #endregion
    }
}
