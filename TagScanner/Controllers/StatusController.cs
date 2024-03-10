namespace TagScanner.Controllers
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using TagScanner.Models;

    public class StatusController
    {
        public StatusController(Model model, StatusStrip statusStrip) { Model = model; StatusBar = statusStrip; }

        private readonly Model Model;
        private readonly StatusStrip StatusBar;

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
                    if (e.Work != null)
                    {
                        Model.Modified = true;
                        e.Work.PropertyChanged += Model.Work_PropertyChanged;
                    }
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

        private void CancelButton_ButtonClick(object sender, EventArgs e) => ((ToolStripItem)sender).Enabled = false;
    }
}
