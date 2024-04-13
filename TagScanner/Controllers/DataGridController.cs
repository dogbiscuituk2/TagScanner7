namespace TagScanner.Controllers
{
    using Models;
    using System.Windows.Forms;

    public class DataGridController : Controller
    {
        public DataGridController(Controller parent, Model model, DataGridView view) : base(parent)
        {
            //Model = model;
            //View = view;

            //var foo = new BindingSource(Model, "Works");

            //View.DataSource = foo;
            //View.DataMember = "Works";
        }

        public Model Model { get; private set; }
        public DataGridView View { get; private set;}
    }
}
