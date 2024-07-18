namespace TagScanner.Controls
{
    using System.Windows.Forms;

    public static class FirstClickHelper
    {
        public static void WndProc(this ToolStrip self, Message message)
        {
            const int wmMouseActive = 0x21;
            if (message.Msg == wmMouseActive && self.CanFocus && !self.Focused)
                self.Focus();
        }
    }
}
