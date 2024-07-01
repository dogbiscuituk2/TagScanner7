namespace TagScanner.Controllers
{
    using System.Windows.Forms;

    public interface IGetErrors
    {
        ErrorProvider ErrorProvider { get; }
        string GetErrors(Control control);
    }
}
