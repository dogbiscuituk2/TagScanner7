namespace TagScanner.Controls
{
    using System.Windows.Forms;

    public class ToolStripHost : ToolStripControlHost
    {
        public ToolStripHost() : base(new Label()) { }
        public ToolStripHost(Control control) : base(control) { }
    }
}
