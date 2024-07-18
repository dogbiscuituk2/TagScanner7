namespace TagScanner.Forms
{
    partial class TestForm
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
            this.firstClickToolStrip1 = new TagScanner.Controls.FirstClickToolStrip();
            this.SuspendLayout();
            // 
            // firstClickToolStrip1
            // 
            this.firstClickToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.firstClickToolStrip1.Name = "firstClickToolStrip1";
            this.firstClickToolStrip1.Size = new System.Drawing.Size(800, 25);
            this.firstClickToolStrip1.TabIndex = 0;
            this.firstClickToolStrip1.Text = "firstClickToolStrip1";
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.firstClickToolStrip1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.FirstClickToolStrip firstClickToolStrip1;
    }
}