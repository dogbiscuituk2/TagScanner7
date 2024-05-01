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

        public IProgress<ProgressEventArgs> CreateNewProgress()
        {
            var progressStrip = new StatusStrip();
            var cancelButton = new ToolStripSplitButton { DropDownButtonWidth = 0, Text = "Cancel" };
            var progressBar = new ToolStripProgressBar { Style = ProgressBarStyle.Continuous };
            var statusLine = new ToolStripLabel();
            statusLine.Text = "Locating files...";
            progressStrip.Items.AddRange(new ToolStripItem[] { cancelButton, progressBar, statusLine });
            progressStrip.Dock = DockStyle.Bottom;
            progressStrip.Visible = true;
            MainForm.ToolStripContainer.BottomToolStripPanel.Controls.Add(progressStrip);
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
                    progressStrip.Items.Remove(statusLine);
                    progressStrip.Items.Remove(progressBar);
                    progressStrip.Items.Remove(cancelButton);
                    MainForm.ToolStripContainer.BottomToolStripPanel.Controls.Remove(progressStrip);
                }
            });
            return progress;
        }

        private static void CancelButton_ButtonClick(object sender, EventArgs e) => ((ToolStripItem)sender).Enabled = false;
    }
}
