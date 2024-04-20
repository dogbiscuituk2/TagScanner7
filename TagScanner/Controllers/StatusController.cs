namespace TagScanner.Controllers
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using Models;
    using Views;

    public class StatusController : Controller
    {
        public StatusController(Controller parent) : base(parent) { }

        private MainForm MainForm => MainFormController.View;
        private MainFormController MainFormController => (MainFormController)Parent;
        private Model Model => MainFormController.Model;
        private StatusStrip StatusBar => MainForm.StatusBar;
        private ToolStripItemCollection StatusBarItems => StatusBar.Items;

        public IProgress<ProgressEventArgs> CreateNewProgress()
        {
            var progressBar = new ToolStripProgressBar { Style = ProgressBarStyle.Continuous };
            var cancelButton = new ToolStripSplitButton { DropDownButtonWidth = 0, Text = "Cancel" };
            var statusLine = new ToolStripLabel();
            StatusBarItems.AddRange(new ToolStripItem[] { cancelButton, progressBar, statusLine });
            cancelButton.ButtonClick += CancelButton_ButtonClick;
            var progress = new Progress<ProgressEventArgs>((e) =>
            {
                if (!e.Continue)
                    return;
                e.Continue = e.Index < e.Count && cancelButton.Enabled;
                if (e.Continue)
                {
                    progressBar.Maximum = e.Count;
                    progressBar.Value = e.Index;
                    statusLine.Text = Path.GetDirectoryName(e.Path);
                }
                else
                {
                    cancelButton.ButtonClick -= CancelButton_ButtonClick;
                    StatusBarItems.Remove(statusLine);
                    StatusBarItems.Remove(progressBar);
                    StatusBarItems.Remove(cancelButton);
                }
            });
            return progress;
        }

        private static void CancelButton_ButtonClick(object sender, EventArgs e) => ((ToolStripItem)sender).Enabled = false;
    }
}
