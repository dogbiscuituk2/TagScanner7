namespace TagScanner.Controllers
{
    using System.Windows.Forms;

    public class SplashController
    {
        public void Run(Form form) => form.Shown += (sender, e) => form.Hide();
    }
}
