namespace TagScanner.Controllers
{
    using Views;

    public class FindReplaceController : Controller
    {
        public FindReplaceController(Controller parent) : base(parent) { }

        private MainForm MainForm => MainFormController.View;
        private MainFormController MainFormController => (MainFormController)Parent;


    }
}
