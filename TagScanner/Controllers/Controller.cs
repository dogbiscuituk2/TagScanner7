namespace TagScanner.Controllers
{
    using System.Windows.Forms;

    public abstract class Controller
    {
        protected Controller(Controller parent) => Parent = parent;

        protected MainFormController MainFormController => (MainFormController)Root;
        protected Controller Parent { get; }
        protected Controller Root => Parent == null ? this : Parent.Root;

        protected virtual IWin32Window Owner => Parent.Owner;
    }
}
