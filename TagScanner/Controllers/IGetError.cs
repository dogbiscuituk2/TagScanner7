namespace TagScanner.Controllers
{
    using System.Windows.Forms;

    public interface IGetError
    {
        ErrorProvider ErrorProvider { get; }
        string GetError(Control control);
    }
}
