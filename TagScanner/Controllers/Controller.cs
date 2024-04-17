namespace TagScanner.Controllers
{
    using System.Windows.Forms;

    public abstract class Controller
    {
        protected Controller(Controller parent) => Parent = parent;

        protected Controller Parent { get; }

        protected virtual IWin32Window Owner => Parent.Owner;
    }
}
