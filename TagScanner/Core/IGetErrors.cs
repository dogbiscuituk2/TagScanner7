namespace TagScanner.Core
{
    using System.Windows.Forms;

    public interface IGetErrors
    {
        ErrorProvider ErrorProvider { get; }
        string GetErrors(Control control);
    }
}
