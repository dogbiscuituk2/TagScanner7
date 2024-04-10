namespace TagScanner.Controllers.Mru
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Utils;
    using Win32 = Microsoft.Win32;

    public class MruController
    {
        public MruController(string subKeyName, ToolStripDropDownItem parentItem) :
            this(subKeyName, parentItem?.DropDownItems)
        {
            _parentItem = parentItem;
            RefreshRecentMenu();
        }

        public MruController(string subKeyName, ContextMenuStrip parentMenu) :
            this(subKeyName, parentMenu?.Items)
        {
            _parentMenu = parentMenu;
            RefreshRecentMenu();
        }

        public MruController(string subKeyName, ToolStripItemCollection recentItems)
        {
            if (string.IsNullOrWhiteSpace(subKeyName))
                throw new ArgumentNullException(nameof(subKeyName));
            _subKeyName = $@"Software\{Application.CompanyName}\{Application.ProductName}\{subKeyName}";
            _recentItems = recentItems;
            RefreshRecentMenu();
        }

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

        private readonly ToolStripDropDownItem _parentItem;
        private readonly ContextMenuStrip _parentMenu;
        private readonly ToolStripItemCollection _recentItems;
        private readonly string _subKeyName;

        private Win32.RegistryKey User => Win32.Registry.CurrentUser;

        private static void DeleteItem(Win32.RegistryKey key, string item)
        {
            var name = key.GetValueNames().FirstOrDefault(n => key.GetValue(n, null) as string == item);
            if (name != null)
                key.DeleteValue(name);
        }

        private void OnItemClick(object sender, EventArgs e) => Reopen((ToolStripItem)sender);

        private void OnRecentClear_Click(object sender, EventArgs e)
        {
            try
            {
                var key = OpenSubKey(true);
                if (key == null)
                    return;
                foreach (var name in key.GetValueNames())
                    key.DeleteValue(name, true);
                key.Close();
                if (_recentItems == null) return;
                _recentItems.Clear();
                SetEnabled(false);
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }

        private void RefreshRecentMenu()
        {
            if (_recentItems == null)
                return;
            _recentItems.Clear();
            Win32.RegistryKey key = null;
            try { key = OpenSubKey(false); }
            catch (Exception ex) { Console.WriteLine(ex); }
            var ok = key != null;
            if (ok)
            {
                foreach (var name in key.GetValueNames().OrderByDescending(n => n))
                {
                    if (!(key.GetValue(name, null) is string value)) continue;
                    try
                    {
                        var text = CompactMenuText(value.Split('|')[0]);
                        var item = _recentItems.Add(text, null, OnItemClick);
                        item.Tag = value;
                        item.ToolTipText = value.Replace("|", Environment.NewLine);
                    }
                    catch (Exception ex) { Console.WriteLine(ex); }
                }
                ok = _recentItems.Count > 0;
                if (ok)
                {
                    _recentItems.Add("-");
                    _recentItems.Add("Clear this list", null, OnRecentClear_Click);
                }
            }
            SetEnabled(ok);
        }

        private void SetEnabled(bool value)
        {
            if (_parentMenu != null)
                _parentMenu.Enabled = value;
            else if (_parentItem != null)
                _parentItem.Enabled = value;
        }

        private Win32.RegistryKey CreateSubKey() => User.CreateSubKey(_subKeyName, Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);
        private Win32.RegistryKey OpenSubKey(bool writable) => User.OpenSubKey(_subKeyName, writable);

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
            return result.Escape();
        }
    }
}
