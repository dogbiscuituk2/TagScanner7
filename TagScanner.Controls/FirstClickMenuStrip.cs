namespace TagScanner.Controls
{
    using System.Windows.Forms;

    public class FirstClickMenuStrip : MenuStrip
    {
        protected override void WndProc(ref Message message)
        {
            this.WndProc(message);
            base.WndProc(ref message);
        }
    }
}
