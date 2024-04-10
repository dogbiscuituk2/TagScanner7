namespace TagScanner.Controllers
{
    using System.Windows.Forms;

    public class SplashController
    {
        public void Run(Form form)
        {
            _form = form;
            _timer = new Timer { Interval = 25 };
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private Form _form;
        private Timer _timer;

        private void Timer_Tick(object sender, System.EventArgs e)
        {
            _form.Opacity -= 0.025D;
            if (_form.Opacity <= 0)
            {
                _timer.Stop();
                _timer.Tick -= Timer_Tick;
                _timer.Dispose();
                _form.Hide();
            }
        }
    }
}
