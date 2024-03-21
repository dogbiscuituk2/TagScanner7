namespace TagScanner.Controls
{
    using System.Windows.Forms;

    public class TermTree : TreeView
    {
        public TermTree() : base()
        {
            DoubleBuffered = true;
        }

        protected sealed override bool DoubleBuffered
        {
            get => base.DoubleBuffered;
            set => base.DoubleBuffered = value;
        }
    }
}
