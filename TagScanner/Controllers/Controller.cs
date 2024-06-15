namespace TagScanner.Controllers
{
    using System.Windows.Forms;
    using Commands;
    using Forms;
    using Models;
    using Wpf;

    public abstract class Controller
    {
        #region Constructor 

        protected Controller(Controller parent) => Parent = parent;

        #endregion

        #region Protected Properties

        protected AutoCompleter MainAutoCompleter => MainFormController.AutoCompleter;
        protected CommandProcessor MainCommandProcessor => MainFormController.CommandProcessor;
        protected MainForm MainForm => MainFormController.View;
        protected MainFormController MainFormController => (MainFormController)Root;
        protected Model MainModel => MainFormController.Model;
        protected WpfTableController MainTableController => MainFormController.TableController;
        protected virtual IWin32Window Owner => Parent?.Owner;
        protected Controller Parent { get; }
        protected Controller Root => Parent == null ? this : Parent.Root;

        #endregion

        #region Protected Methods

        protected void Run(Command command, bool spoof = false) => MainCommandProcessor.Run(command, spoof);

        #endregion
    }
}
