namespace TagScanner.Forms
{
    using System.Runtime.CompilerServices;

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
            this.toolStripCheckBox1 = new TagScanner.Controls.ToolStripCheckBox();
            this.toolStripSpinEdit1 = new TagScanner.Controls.ToolStripSpinEdit();
            this.firstClickToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // firstClickToolStrip1
            // 
            this.firstClickToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCheckBox1,
            this.toolStripSpinEdit1});
            this.firstClickToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.firstClickToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.firstClickToolStrip1.Name = "firstClickToolStrip1";
            this.firstClickToolStrip1.Size = new System.Drawing.Size(1006, 25);
            this.firstClickToolStrip1.TabIndex = 0;
            this.firstClickToolStrip1.Text = "firstClickToolStrip1";
            // 
            // toolStripCheckBox1
            // 
            this.toolStripCheckBox1.Checked = false;
            this.toolStripCheckBox1.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.toolStripCheckBox1.Name = "toolStripCheckBox1";
            this.toolStripCheckBox1.Size = new System.Drawing.Size(130, 22);
            this.toolStripCheckBox1.Text = "toolStripCheckBox1";
            // 
            // toolStripSpinEdit1
            // 
            this.toolStripSpinEdit1.AutoSize = false;
            this.toolStripSpinEdit1.DecimalPlaces = 0;
            this.toolStripSpinEdit1.Maximim = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.toolStripSpinEdit1.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.toolStripSpinEdit1.Name = "toolStripSpinEdit1";
            this.toolStripSpinEdit1.Size = new System.Drawing.Size(120, 20);
            this.toolStripSpinEdit1.Text = "0";
            this.toolStripSpinEdit1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 450);
            this.Controls.Add(this.firstClickToolStrip1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.firstClickToolStrip1.ResumeLayout(false);
            this.firstClickToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.FirstClickToolStrip firstClickToolStrip1;
        private Controls.ToolStripCheckBox toolStripCheckBox1;
        private Controls.ToolStripSpinEdit toolStripSpinEdit1;
        private Controls.ToolStripDateTimePicker toolStripDateTimePicker1;
    }
}