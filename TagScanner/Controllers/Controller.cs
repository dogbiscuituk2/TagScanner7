namespace TagScanner.Controllers
{
    using System.Windows.Forms;

    internal abstract class Controller
    {
        protected Controller(Controller parent) => Parent = parent;

        internal Controller Parent { get;  }

        internal virtual Form Form => Parent?.Form;
    }
}
