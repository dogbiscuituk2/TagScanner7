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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.firstClickToolStrip1 = new TagScanner.Controls.FirstClickToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSpinEdit1 = new TagScanner.Controls.ToolStripSpinEdit();
            this.toolStripCheckBox1 = new TagScanner.Controls.ToolStripCheckBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripCheckBox2 = new TagScanner.Controls.ToolStripCheckBox();
            this.toolStripSpinEdit2 = new TagScanner.Controls.ToolStripSpinEdit();
            this.firstClickToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(119, 211);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(300, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // firstClickToolStrip1
            // 
            this.firstClickToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripSpinEdit1,
            this.toolStripCheckBox1,
            this.toolStripButton1,
            this.toolStripTextBox1,
            this.toolStripCheckBox2,
            this.toolStripSpinEdit2});
            this.firstClickToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.firstClickToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.firstClickToolStrip1.Name = "firstClickToolStrip1";
            this.firstClickToolStrip1.Size = new System.Drawing.Size(1006, 187);
            this.firstClickToolStrip1.TabIndex = 0;
            this.firstClickToolStrip1.Text = "firstClickToolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripSpinEdit1
            // 
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
            this.toolStripSpinEdit1.Size = new System.Drawing.Size(41, 23);
            this.toolStripSpinEdit1.Text = "0";
            this.toolStripSpinEdit1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // toolStripCheckBox1
            // 
            this.toolStripCheckBox1.AutoSize = false;
            this.toolStripCheckBox1.Checked = false;
            this.toolStripCheckBox1.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.toolStripCheckBox1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.toolStripCheckBox1.Name = "toolStripCheckBox1";
            this.toolStripCheckBox1.Size = new System.Drawing.Size(189, 22);
            this.toolStripCheckBox1.Text = "toolStripCheckBox1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStripCheckBox2
            // 
            this.toolStripCheckBox2.Checked = false;
            this.toolStripCheckBox2.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.toolStripCheckBox2.Name = "toolStripCheckBox2";
            this.toolStripCheckBox2.Size = new System.Drawing.Size(130, 19);
            this.toolStripCheckBox2.Text = "toolStripCheckBox2";
            // 
            // toolStripSpinEdit2
            // 
            this.toolStripSpinEdit2.AutoSize = false;
            this.toolStripSpinEdit2.DecimalPlaces = 0;
            this.toolStripSpinEdit2.Maximim = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.toolStripSpinEdit2.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.toolStripSpinEdit2.Name = "toolStripSpinEdit2";
            this.toolStripSpinEdit2.Size = new System.Drawing.Size(200, 23);
            this.toolStripSpinEdit2.Text = "987654";
            this.toolStripSpinEdit2.Value = new decimal(new int[] {
            987654,
            0,
            0,
            0});
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 450);
            this.Controls.Add(this.dateTimePicker1);
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Controls.ToolStripSpinEdit toolStripSpinEdit1;
        private Controls.ToolStripCheckBox toolStripCheckBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private Controls.ToolStripCheckBox toolStripCheckBox2;
        private Controls.ToolStripSpinEdit toolStripSpinEdit2;
    }
}