namespace TagScanner.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Views;

    public class AppController : Controller
    {
        public AppController() : base(null)
        {
            MainForm = new MainForm();
            MainForm.FormClosing += MainForm_FormClosing;
            NewWindow();
        }

        private void MainForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e) =>
            e.Cancel = !Shutdown();

        public MainForm MainForm;

        private readonly List<LibraryFormController> _controllers = new List<LibraryFormController>();

        public void NewWindow()
        {
            var controller = new LibraryFormController(this);
            _controllers.Add(controller);
            controller.View.Show();
        }

        public bool Shutdown()
        {
            for (var index = _controllers.Count; index > 0; index--)
            {
                var controller = _controllers[index -1];
                var view = controller.View;
                view.Close();
                if (view.Visible)
                    return false;
                CloseWindow(controller);
            }
            return true;
        }

        public void CloseWindow(LibraryFormController controller)
        {
            _controllers.Remove(controller);
            if (!_controllers.Any())
                MainForm.Close();
        }
    }
}
