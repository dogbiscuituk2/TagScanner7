namespace TagScanner.Controllers
{
    using System.Windows.Forms;

    public abstract class Controller
    {
        protected Controller(Controller parent) => Parent = parent;

        internal Controller Parent { get;  }

        internal virtual Form Form => Parent?.Form;
    }
}
