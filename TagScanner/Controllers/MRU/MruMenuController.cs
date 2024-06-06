namespace TagScanner.Controllers.Mru
{
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Utils;
    using Win32 = Microsoft.Win32;

    public abstract class MruMenuController : MruController
    {
        #region Constructor

        protected MruMenuController(Controller parent, string subKeyName, ToolStripItemCollection recentItems)
            : base(parent, subKeyName)
        {
            _recentItems = recentItems;
            RefreshRecentMenu();
        }

        #endregion

        #region Protected Fields

        protected ToolStripDropDownItem _parentItem;
        protected ContextMenuStrip _parentMenu;
        protected ToolStripItemCollection _recentItems;

        #endregion

        #region Public Properties

        public bool Merging { get; set; }

        #endregion

        #region Event Handlers

        private void OnItemClick(object sender, EventArgs e) => Reuse((ToolStripItem)sender);

        private void OnRecentClear_Click(object sender, EventArgs e)
        {
            ClearItems();
            if (_recentItems == null) return;
            _recentItems.Clear();
            SetEnabled(false);
        }

        #endregion

        #region Protected Methods

        protected override void AddItem(string item)
        {
            base.AddItem(item);
            RefreshRecentMenu();
        }

        protected void RefreshRecentMenu()
        {
            if (_recentItems == null)
                return;
            _recentItems.Clear();
            var ok = TryReadKey(out Win32.RegistryKey key);
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
                    var item = new ToolStripMenuItem("Clear this list", Properties.Resources.Delete, OnRecentClear_Click)
                    {
                        ImageTransparentColor = Color.White
                    };
                    _recentItems.Add(item);
                }
            }
            SetEnabled(ok);
        }

        protected override void RemoveItem(string item)
        {
            base.RemoveItem(item);
            RefreshRecentMenu();
        }

        protected abstract void Reuse(ToolStripItem menuItem);

        #endregion

        #region Private Methods

        private static string CompactMenuText(string text)
        {
            var result = text;
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

        private void SetEnabled(bool value)
        {
            if (_parentMenu != null)
                _parentMenu.Enabled = value;
            else if (_parentItem != null)
                _parentItem.Enabled = value;
        }

        #endregion
    }
}
