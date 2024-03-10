﻿namespace TagScanner.Menus
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using TagScanner.Models;
    using TagScanner.Terms;

    public static class MenuMakerBasic
    {
        #region Public Methods

        public static void AddAllTerms(this ToolStripItemCollection items, EventHandler click)
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
                var subitems = item.DropDownItems;
                var ok = act == Filter.None || (subitems.Count > 0
                    ? subitems.FilterItems(action, types)
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
            items.AddMethodsStringInstance(click);
            items.AddMethodsStringStatic(click);
            items.AddMethodsRegexStatic(click);
            items.AddMethodsMathStatic(click);
        }

        private static void AddMethods(this ToolStripItemCollection items, string head, IEnumerable<KeyValuePair<string, MethodInfo>> methods, EventHandler click)
        {
            items = items.Append(head);
            foreach (var method in methods)
            {
                var key = method.Key.Escape();
                items.Buffer(key.Contains('.') ? key.Tail() : key, method, click);
            }
            items.Flush();
        }

        private static void AddMethodsMathStatic(this ToolStripItemCollection items, EventHandler click) => items.AddMethods("&Math", Core.MathStatics, click);
        private static void AddMethodsRegexStatic(this ToolStripItemCollection items, EventHandler click) => items.AddMethods("&Regex", Core.RegexStatics, click);
        private static void AddMethodsStringInstance(this ToolStripItemCollection items, EventHandler click) => items.AddMethods("&General", Core.StringMethods, click);
        private static void AddMethodsStringStatic(this ToolStripItemCollection items, EventHandler click) => items.AddMethods("&String", Core.StringStatics, click);

        private static void AddOperations(this ToolStripItemCollection items, EventHandler click)
        {
            items = items.Append("&Operation");
            foreach (var op in Core.Operators)
                items.Append(op.Key.ToString(), op, click);
        }

        private static void AddTags(this ToolStripItemCollection items, EventHandler click)
        {
            items = items.Append("&Tag");
            var fields = Tags.AllTags.OrderBy(p => p.DisplayName);
            foreach (var field in fields)
                items.Buffer(field.DisplayName.Escape(), field, click);
            items.Flush();
        }

        private static ToolStripItemCollection Append(this ToolStripItemCollection items, string text)
        {
            var item = new ToolStripMenuItem(text);
            items.Add(item);
            return item.DropDownItems;
        }

        private static void Append(this ToolStripItemCollection items, string text, object info, EventHandler click) => items.Add(new ToolStripMenuItem(text, null, click) { Tag = info });

        private static void Buffer(this ToolStripItemCollection items, string text, object info, EventHandler click)
        {
            var count = items.Count;
            if (count > 0 && items[count - 1].Text.Head() != text.Head())
                items.Flush();
            items.Append(text, info, click);
        }

        public static void Flush(this ToolStripItemCollection items)
        {
            var count = items.Count;
            if (count < 2) return;
            var head = items[count - 1].Text.Head();
            var subitems = items.OfType<ToolStripMenuItem>().Where(p => p.Text.Head() == head).ToArray();
            if (subitems.Count() >= 2)
            {
                foreach (var item in subitems)
                    items.Remove(item);
                items.Append(head).AddRange(subitems);
            }
        }

        private static bool GetTargetType(Filter target, Umptad umptad, Type[] types)
        {
            var type = target == Filter.FirstArg
                ? umptad.ParameterTypes.FirstOrDefault()
                : umptad.ResultType;
            return types.Contains(type);
        }

        private static bool IncludeTerm(this ToolStripMenuItem item, Filter target, Type[] types)
        {
            var tag = item.Tag;
            if (tag == null)
                return true; ;
            if (tag is TagProps tagProps)
                return types.Contains(tagProps.Type);
            if (tag is KeyValuePair<Op, OpInfo> op) return true;
            if (tag is KeyValuePair<string, MethodInfo> method) return true;
            return false;
        }

        #endregion

        #region Private Utils

        private static string Escape(this string s) => s.Replace("&", "&&");
        private static string Head(this string s) => s.Split(' ', '.', '/', '(')[0];
        private static string Tail(this string s) => s.Substring(s.Head().Length + 1);

        #endregion
    }
}
