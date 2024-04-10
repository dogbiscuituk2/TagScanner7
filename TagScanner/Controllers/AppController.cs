namespace TagScanner.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Views;

    public static class AppController
    {
        static AppController()
        {
            MainForm = new MainForm();
            MainForm.FormClosing += MainForm_FormClosing;
            NewWindow();
            new SplashController().Run(MainForm);
        }

        public static MainForm MainForm;
        private static readonly List<LibraryFormController> Controllers = new List<LibraryFormController>();

        public static void CloseWindow(LibraryFormController controller)
        {
            Controllers.Remove(controller);
            if (!Controllers.Any())
                MainForm.Close();
        }

        public static void NewWindow()
        {
            var controller = new LibraryFormController();
            Controllers.Add(controller);
            controller.View.Show();
        }

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

        private static void MainForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e) =>
            e.Cancel = !Shutdown();
    }
}
