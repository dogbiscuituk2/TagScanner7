namespace TagScanner.Controllers
{
    using TagScanner.Views;

    public class MainFormController : Controller
    {
        public MainFormController() : base(null)
        {
            View = new MainForm();
            LibraryFormController.NewWindow();
        }

        public MainForm View;
    }
}
