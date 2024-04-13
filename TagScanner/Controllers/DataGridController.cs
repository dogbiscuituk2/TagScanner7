namespace TagScanner.Controllers
{
    using Models;
    using System.Windows.Forms;

    public class DataGridController : Controller
    {
        public DataGridController(Controller parent, Model model, DataGridView view) : base(parent)
        {
            Model = model;
            View = view;

            View.DataSource = Model;
        }

        public Model Model { get; private set; }
        public DataGridView View { get; private set;}
    }
}
