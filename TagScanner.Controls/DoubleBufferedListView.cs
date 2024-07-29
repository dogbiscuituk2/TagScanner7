namespace TagScanner.Controls
{
    using System.Windows.Forms;

    public partial class DoubleBufferedListView : ListView
    {
        public DoubleBufferedListView()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
