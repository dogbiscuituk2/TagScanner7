namespace TagScanner.Controls
{
    using System.Windows.Forms;

    public class TermTreeView : TreeView
    {
        public TermTreeView() : base()
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
