namespace TagScanner.Views
{
    using System;
    using System.Windows.Forms;

    public partial class FindReplaceControl : UserControl
    {
        public FindReplaceControl()
        {
            InitializeComponent();
        }

        private void FindReplaceControl_Resize(object sender, EventArgs e)
        {
            var width = Size.Width;
            cbFindTerm.Size = cbReplaceterm.Size = new System.Drawing.Size(width - 93, cbFindTerm.Height);
            tbPickTags.Size = new System.Drawing.Size(width - 93, tbPickTags.Height);
        }

        private void tbToggleFindReplace_Click(object sender, EventArgs e)
        {

        }
    }
}
