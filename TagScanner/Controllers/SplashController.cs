namespace TagScanner.Controllers
{
    using System.Windows.Forms;

    public class SplashController
    {
        #region Public Methods

        public void Run(Form form) => form.Shown += (sender, e) => form.Hide();

        #endregion
    }
}
