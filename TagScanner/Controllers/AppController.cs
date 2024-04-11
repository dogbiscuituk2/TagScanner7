namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Utils;
    using Views;

    public static class AppController
    {
        #region Static Constructor

        static AppController()
        {
            MainForm = new SplashForm();
            Controllers = new List<LibraryFormController>();
            MainForm.FormClosing += MainForm_FormClosing;
            NewWindow();
            new SplashController().Run(MainForm);
        }

        #endregion

        #region Public Methods

        public static void CloseWindow(LibraryFormController controller)
        {
            Controllers.Remove(controller);
            if (!Controllers.Any())
                MainForm.Close();
        }
        public static string GetTempFileName() => $"<untitled #{++TempFileIndex}>";
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
                    Text = $@"{shortcut}{controller.View.Text.Escape()}",
                };
                item.Click += WindowClick;
                menu.DropDownItems.Add(item);
            }
        }

        public static void Run() => Application.Run(MainForm);

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

        #region Private Fields

        private static SplashForm MainForm { get; }
        private static List<LibraryFormController> Controllers { get; }
        private static int TempFileIndex;
        #endregion

        #region Private Methods

        private static void ClearWindowMenu(ToolStripDropDownItem menu)
        {
            if (!menu.HasDropDownItems) return;
            foreach (ToolStripItem item in menu.DropDownItems)
                item.Click -= WindowClick;
            menu.DropDownItems.Clear();
        }

        private static void MainForm_FormClosing(object sender, FormClosingEventArgs e) => e.Cancel = !Shutdown();

        private static void WindowClick(object sender, EventArgs e)
        {
            var form = (LibraryForm)((ToolStripMenuItem)sender).Tag;
            form.BringToFront();
            form.Focus();
        }

        #endregion
    }
}
