namespace TagScanner.Controllers
{
    using System.Windows.Forms;

    public abstract class ErrorProviderController : Controller
    {
        public ErrorProviderController(Controller parent) : base(parent) { }

        protected abstract ErrorProvider ErrorProvider { get; }

        protected abstract string GetError(Control control);

        protected void InitErrorProvider(Control control)
        {
            ErrorProvider.SetIconAlignment(control, ErrorIconAlignment.MiddleRight);
            ErrorProvider.SetIconPadding(control, 4);
            control.Validated += (sender, e) => ErrorProvider.SetError((Control)sender, GetError(control));
        }
    }
}
