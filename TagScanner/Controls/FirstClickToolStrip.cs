namespace TagScanner.Controls
{
    using System.Windows.Forms;

    public class FirstClickToolStrip : ToolStrip
    {
        protected override void WndProc(ref Message message)
        {
            this.WndProc(message);
            base.WndProc(ref message);
        }
    }
}
