namespace TagScanner.Controllers
{
    using System.Windows.Forms;

    public abstract class Controller
    {
        protected Controller(Controller parent) => Parent = parent;

        public Controller Parent { get;  }

        public virtual Form Form => Parent?.Form;
    }
}
