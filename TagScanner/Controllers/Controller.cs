namespace TagScanner.Controllers
{
    using System.Windows.Forms;
    using Commands;
    using Models;
    using Forms;
    using Wpf;

    public abstract class Controller
    {
        protected Controller(Controller parent) => Parent = parent;

        protected AutoCompleter MainAutoCompleter => MainFormController.AutoCompleter;
        protected CommandProcessor MainCommandProcessor => MainFormController.CommandProcessor;
        protected MainForm MainForm => MainFormController.View;
        protected MainFormController MainFormController => (MainFormController)Root;
        protected Model MainModel => MainFormController.Model;
        protected WpfTableController MainTableController => MainFormController.TableController;
        protected virtual IWin32Window Owner => Parent?.Owner;
        protected Controller Parent { get; }
        protected Controller Root => Parent == null ? this : Parent.Root;
    }
}
