namespace TagScanner.Views
{
    partial class SplashForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SharpClipboard = new WK.Libraries.SharpClipboardNS.SharpClipboard(this.components);
            this.SuspendLayout();
            // 
            // SharpClipboard
            // 
            this.SharpClipboard.MonitorClipboard = true;
            this.SharpClipboard.ObservableFormats.All = true;
            this.SharpClipboard.ObservableFormats.Files = true;
            this.SharpClipboard.ObservableFormats.Images = true;
            this.SharpClipboard.ObservableFormats.Others = true;
            this.SharpClipboard.ObservableFormats.Texts = true;
            this.SharpClipboard.ObserveLastEntry = true;
            this.SharpClipboard.Tag = null;
            // 
            // SplashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(120, 32);
            this.ControlBox = false;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SplashForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.ResumeLayout(false);

        }

        #endregion

        public WK.Libraries.SharpClipboardNS.SharpClipboard SharpClipboard;
    }
}