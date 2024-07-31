namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.Xml;
    using WK.Libraries.SharpClipboardNS;
    using Forms;
    using Models;
    using Mru;
    using Utils;

    public static class AppController
    {
        #region Static Constructor

        static AppController()
        {
            SplashForm = new SplashForm();
            Controllers = new List<MainFormController>();
            SplashForm.FormClosing += MainForm_FormClosing;
            NewWindow();
            new SplashController().Run(SplashForm);
            SplashForm.SharpClipboard.ClipboardChanged += SharpClipboard_ClipboardChanged;
        }

        #endregion

        #region Public Fields

        public static MruFilterController MruFilterController = new MruFilterController(null);
        public static MruStringsController MruFindController = new MruStringsController(null, "FindMRU");
        public static MruStringsController MruReplaceController = new MruStringsController(null, "ReplaceMRU");
        public static MruSchemaController MruSchemaController = new MruSchemaController(null, "DefaultSchema");

        #endregion

        #region Public Properties

        public static Schema Schema
        {
            get => ReadSchema();
            set => WriteSchema(value);
        }

        #endregion

        #region Public Methods

        public static void AddFilter(string value) => MruFilterController.AddValue(value);

        public static void CloseWindow(MainFormController controller)
        {
            Controllers.Remove(controller);
            if (!Controllers.Any())
                SplashForm.Close();
        }

        public static string GetTempFileName(string nameFormat = LibraryNameFormat)
        {
            var filePaths = Controllers.Select(p => p.FilePath);
            for (var index = 1; true; index++)
            {
                var filePath = string.Format(nameFormat, index);
                if (!filePaths.Contains(filePath))
                    return filePath;
            }
        }

        public static void NewWindow(string nameFormat = LibraryNameFormat, Selection selection = null, bool modified = true)
        {
            var controller = new MainFormController();
            Controllers.Add(controller);
            controller.FilePath = GetTempFileName(nameFormat);
            if (selection != null)
                controller.TracksAdd(selection);
            controller.View.Show();
            if (!modified)
                controller.CommandProcessor.Clear();
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

        public static void GetFilterItems(ComboBox.ObjectCollection items) => MruFilterController.RegistryRead(items);
        public static void GetFindItems(ComboBox.ObjectCollection items) => MruFindController.RegistryRead(items);
        public static void GetReplaceItems(ComboBox.ObjectCollection items) => MruReplaceController.RegistryRead(items);
        public static void UpdateFilterItems(ComboBox.ObjectCollection items, string item) => MruFilterController.UpdateItems(items, item);
        public static void UpdateFindItems(ComboBox.ObjectCollection items, string item) => MruFindController.UpdateItems(items, item);
        public static void UpdateReplaceItems(ComboBox.ObjectCollection items, string item) => MruReplaceController.UpdateItems(items, item);

        public static void UpdateUI(MainFormController mainFormController)
        {
            mainFormController.UpdateLocalUI();
            mainFormController.CommandProcessor.UpdateLocalUI();
        }

        #endregion

        #region Private Fields

        private const string LibraryNameFormat = "<untitled #{0}>";
        private static Schema _schema;

        #endregion

        #region Private Properties

        private static List<MainFormController> Controllers { get; }
        private static SplashForm SplashForm { get; }

        #endregion

        #region Event Handlers

        private static void MainForm_FormClosing(object sender, FormClosingEventArgs e) => e.Cancel = !Shutdown();

        private static void SharpClipboard_ClipboardChanged(object sender, SharpClipboard.ClipboardChangedEventArgs e)
        {
            var canPasteFiles = CanPasteFiles();
            Controllers.ForEach(p => p.EnablePasteFiles(canPasteFiles));
            return;

            bool CanPasteFiles()
            {
                // An array of file paths can be pasted.
                if (Clipboard.ContainsFileDropList())
                    return true;
                // An XML file containing a Track collection can be pasted.
                var text = Clipboard.GetText();
                var doc = new XmlDocument();
                try
                {
                    doc.LoadXml(text);
                    if (doc.DocumentElement.Name == "ArrayOfTrack")
                        return true;
                }
                catch { } // Wrong format, details are of no interest.
                return false;
            }
        }

        private static void WindowClick(object sender, EventArgs e)
        {
            var form = (MainForm)((ToolStripMenuItem)sender).Tag;
            form.BringToFront();
            form.Focus();
        }

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

        private static Schema ReadSchema() => _schema ?? (_schema = MruSchemaController.ReadSchema());

        private static void WriteSchema(Schema schema) => MruSchemaController.WriteSchema(_schema = schema);

        #endregion
    }
}
