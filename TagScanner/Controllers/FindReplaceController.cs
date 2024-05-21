namespace TagScanner.Controllers
{
    using System;
    using System.Drawing;
    using Views;

    public class FindReplaceController : Controller
    {
        public FindReplaceController(Controller parent) : base(parent)
        {
            View.Resize += View_Resize;
        }

        private void View_Resize(object sender, EventArgs e)
        {
            var width = View.Width;
            View.cbFindTerm.Size = View.cbReplaceTerm.Size = new Size(width - 93, View.cbFindTerm.Height);
            View.tbPickTags.Size = new Size(width - 93, View.tbPickTags.Height);
        }

        private FindReplaceControl View => MainForm.FindReplaceControl;
    }
}
