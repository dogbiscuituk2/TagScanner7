﻿namespace TagScanner.Menus
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using Models;
    using Terms;

    public static class MenuMaker
    {
        #region Public Methods

        public static void AddAllTerms(ToolStripItemCollection items, EventHandler click)
        {
            items.AddTags(click);
            items.AddOperations(click);
            items.AddFunctions(click);
            items.Add("&Constant...", null, click);
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

        private static void AddFunctions(this ToolStripItemCollection items, EventHandler click)
        {
            items = items.Append("&Function");
            foreach (var method in Core.Methods.Where(p=> p.Key.IndexOf('_') < 0))
                items.Append(method.Key, method, click);
        }

        private static void AddOperations(this ToolStripItemCollection items, EventHandler click)
        {
            items = items.Append("&Operation");
            foreach (var op in Core.Operators)
                items.Append(op.Key.ToString(), op, click);
        }

        private static void AddTags(this ToolStripItemCollection items, EventHandler click)
        {
            items = items.Append("&Tag");
            var tags = Tags.Values.OrderBy(p => p.Category).ThenBy(p => p.DisplayName);
            var categories = tags.Select(p => p.Category).Distinct();
            foreach (var category in categories)
            {
                var subItems = ((ToolStripMenuItem)items.Add(category.Escape())).DropDownItems;
                foreach (var tag in tags.Where(p => p.Category == category))
                    subItems.Add(new ToolStripMenuItem(tag.DisplayName.Escape(), null, click)
                        { Tag = tag, ToolTipText = tag.Details });
            }
        }

        private static ToolStripItemCollection Append(this ToolStripItemCollection items, string text)
        {
            var item = new ToolStripMenuItem(text);
            items.Add(item);
            return item.DropDownItems;
        }

        private static void Append(this ToolStripItemCollection items, string text, object info, EventHandler click) => items.Add(new ToolStripMenuItem(text, null, click) { Tag = info });

        private static bool IncludeTerm(this ToolStripItem item, Filter target, IEnumerable<Type> types)
        {
            var tag = item.Tag;
            if (tag == null)
                return true; ;
            switch (tag)
            {
                case TagInfo tagInfo:
                    return types.Contains(tagInfo.Type);
                case KeyValuePair<Op, OpInfo> _:
                case KeyValuePair<string, MethodInfo> _:
                    return true;
                default:
                    return false;
            }
        }

        #endregion

        #region Private Utils

        private static string Escape(this string s) => s.Replace("&", "&&");

        #endregion
    }
}
