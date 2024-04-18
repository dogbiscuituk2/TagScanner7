namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using WK.Libraries.SharpClipboardNS;
    using Utils;
    using Views;
    using System.Xml;
    using System.Xml.Schema;

    public static class AppController
    {
        #region Static Constructor

        static AppController()
        {
            SplashForm = new SplashForm();
            Controllers = new List<LibraryFormController>();
            SplashForm.FormClosing += MainForm_FormClosing;
            NewWindow();
            new SplashController().Run(SplashForm);
            SplashForm.SharpClipboard.ClipboardChanged += SharpClipboard_ClipboardChanged;
        }

        #endregion

        #region Public Methods

        public static void CloseWindow(LibraryFormController controller)
        {
            Controllers.Remove(controller);
            if (!Controllers.Any())
                SplashForm.Close();
        }

        public static string GetTempFileName()
        {
            var filePaths = Controllers.Select(p => p.FilePath);
            for (var index = 1; true; index++)
            {
                var filePath = $"<untitled #{index}>";
                if (!filePaths.Contains(filePath))
                    return filePath;
            }
        }

        public static void NewWindow()
        {
            var controller = new LibraryFormController();
            Controllers.Add(controller);
            controller.FilePath = GetTempFileName();
            controller.View.Show();
        }

        public static void PopulateWindowMenu(ToolStripMenuItem menu)
        {
            ClearWindowMenu(menu);
            for (var index = 0; index < Controllers.Count; index++)
            {
                var controller = Controllers[index];
                var shortcut =
                    index < 9 ? $@"&{index + 1}: " :
                    index < 9 + 26 ? $@"&{(char)('A' + index - 9)}: " :
                    string.Empty;
                var item = new ToolStripMenuItem()
                {
                    Tag = controller.View,
                    Text = $@"{shortcut}{controller.FilePath.Escape()}",
                };
                item.Click += WindowClick;
                menu.DropDownItems.Add(item);
            }
        }

        public static void Run() => Application.Run(SplashForm);

        public static bool Shutdown()
        {
            for (var index = Controllers.Count; index > 0; index--)
            {
                var controller = Controllers[index -1];
                var view = controller.View;
                view.Close();
                if (view.Visible)
                    return false;
                CloseWindow(controller);
            }
            return true;
        }

        #endregion

        #region Events

        private static void SharpClipboard_ClipboardChanged(object sender, SharpClipboard.ClipboardChangedEventArgs e)
        {
            var text = Clipboard.GetText();
            var doc = new XmlDocument();
            try
            {
                doc.LoadXml(text);
                if (doc.DocumentElement.Name == "ArrayOfTrack")
                {
                    EnablePaste(true);
                    return;
                }
            }
            catch { }
            EnablePaste(false);
            return;

            void EnablePaste(bool enable)
            {
                foreach (var controller in Controllers)
                    controller.EnablePaste(enable);
            }
        }

        #endregion

        #region Private Fields

        private static SplashForm SplashForm { get; }
        private static List<LibraryFormController> Controllers { get; }

        #endregion

        #region Private Methods

        private static void ClearWindowMenu(ToolStripDropDownItem menu)
        {
            var items = menu.DropDownItems;
            for (var index = items.Count - 1; index >= 2;  index--)
            {
                items[index].Click -= WindowClick;
                items.RemoveAt(index);
            }
        }

        private static void MainForm_FormClosing(object sender, FormClosingEventArgs e) => e.Cancel = !Shutdown();

        private static void WindowClick(object sender, EventArgs e)
        {
            var form = (LibraryForm)((ToolStripMenuItem)sender).Tag;
            form.BringToFront();
            form.Focus();
        }

        public static void UpdateUI(LibraryFormController libraryFormController)
        {
            libraryFormController.UpdateLocalUI();
            libraryFormController.CommandProcessor.UpdateLocalUI();
        }

        #endregion
    }
}
