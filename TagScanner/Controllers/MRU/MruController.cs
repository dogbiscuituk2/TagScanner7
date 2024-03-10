namespace TagScanner.Controllers.MRU
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using TagScanner.Models;
    using Win32 = Microsoft.Win32;

    public class MruController
    {
        protected MruController(Model model, string subKeyName, ToolStripDropDownItem parentItem) :
            this(model, subKeyName, parentItem.DropDownItems)
        {
            ParentItem = parentItem;
            RefreshRecentMenu();
        }

        protected MruController(Model model, string subKeyName, ContextMenuStrip parentMenu) :
            this(model, subKeyName, parentMenu.Items)
        {
            ParentMenu = parentMenu;
            RefreshRecentMenu();
        }

        protected MruController(Model model, string subKeyName, ToolStripItemCollection recentItems)
        {
            if (string.IsNullOrWhiteSpace(subKeyName))
                throw new ArgumentNullException("subKeyName");
            Model = model;
            SubKeyName = $@"Software\{Application.CompanyName}\{Application.ProductName}\{subKeyName}";
            RecentItems = recentItems;
            RefreshRecentMenu();
        }

        protected readonly Model Model;

        protected void AddItem(string item)
        {
            try
            {
                var key = CreateSubKey();
                if (key == null)
                    return;
                try
                {
                    DeleteItem(key, item);
                    key.SetValue($"{DateTime.Now:yyyyMMddHHmmssFF}", item);
                }
                finally { key.Close(); }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            RefreshRecentMenu();
        }

        protected void RemoveItem(string item)
        {
            try
            {
                var key = OpenSubKey(true);
                if (key == null)
                    return;
                try { DeleteItem(key, item); }
                finally { key.Close(); }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            RefreshRecentMenu();
        }

        protected virtual void Reopen(ToolStripItem menuItem) { }

        private readonly ToolStripDropDownItem ParentItem;
        private readonly ContextMenuStrip ParentMenu;
        private readonly ToolStripItemCollection RecentItems;
        private readonly string SubKeyName;

        private Win32.RegistryKey User => Win32.Registry.CurrentUser;

        private void DeleteItem(Win32.RegistryKey key, string item)
        {
            var name = key.GetValueNames().Where(n => key.GetValue(n, null) as string == item).FirstOrDefault();
            if (name != null)
                key.DeleteValue(name);
        }

        private void OnItemClick(object sender, EventArgs e) => Reopen((ToolStripItem)sender);

        private void OnRecentClear_Click(object sender, EventArgs e)
        {
            try
            {
                Win32.RegistryKey key = OpenSubKey(true);
                if (key == null)
                    return;
                foreach (string name in key.GetValueNames())
                    key.DeleteValue(name, true);
                key.Close();
                if (RecentItems != null)
                {
                    RecentItems.Clear();
                    SetEnabled(false);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }

        private void RefreshRecentMenu()
        {
            if (RecentItems == null)
                return;
            RecentItems.Clear();
            Win32.RegistryKey key = null;
            try { key = OpenSubKey(false); }
            catch (Exception ex) { Console.WriteLine(ex); }
            bool ok = key != null;
            if (ok)
            {
                foreach (var name in key.GetValueNames().OrderByDescending(n => n))
                {
                    if ((key.GetValue(name, null) is string value))
                        try
                        {
                            var text = CompactMenuText(value.Split('|')[0]);
                            var item = RecentItems.Add(text, null, OnItemClick);
                            item.Tag = value;
                            item.ToolTipText = value.Replace('|', '\n');
                        }
                        catch (Exception ex) { Console.WriteLine(ex); }
                }
                ok = RecentItems.Count > 0;
                if (ok)
                {
                    RecentItems.Add("-");
                    RecentItems.Add("Clear this list", null, OnRecentClear_Click);
                }
            }
            SetEnabled(ok);
        }

        private void SetEnabled(bool value)
        {
            if (ParentMenu != null)
                ParentMenu.Enabled = value;
            else if (ParentItem != null)
                ParentItem.Enabled = value;
        }

        private Win32.RegistryKey CreateSubKey() => User.CreateSubKey(SubKeyName, Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);
        private Win32.RegistryKey OpenSubKey(bool writable) => User.OpenSubKey(SubKeyName, writable);

        private static string CompactMenuText(string text)
        {
            var result = Path.ChangeExtension(text, string.Empty).TrimEnd('.');
            TextRenderer.MeasureText(
                result,
                SystemFonts.MenuFont,
                new Size(320, 0),
                TextFormatFlags.PathEllipsis | TextFormatFlags.ModifyString);
            var length = result.IndexOf((char)0);
            if (length >= 0)
                result = result.Substring(0, length);
            return result.Replace("&", "&&");
        }
    }
}
