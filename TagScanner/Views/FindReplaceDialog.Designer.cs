namespace TagScanner.Views
{
    partial class FindReplaceDialog
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
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbTags = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(12, 130);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(138, 17);
            this.checkBox3.TabIndex = 13;
            this.checkBox3.Text = "Use regular e&xpressions";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(12, 107);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(113, 17);
            this.checkBox2.TabIndex = 12;
            this.checkBox2.Text = "Match &whole word";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 84);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(82, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Match &case";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(83, 33);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(529, 21);
            this.comboBox2.TabIndex = 10;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(83, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(529, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(12, 153);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(94, 17);
            this.checkBox4.TabIndex = 14;
            this.checkBox4.Text = "Preser&ve case";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbTags);
            this.groupBox1.Location = new System.Drawing.Point(156, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(456, 176);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "&Tags to match";
            // 
            // cbTags
            // 
            this.cbTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbTags.FormattingEnabled = true;
            this.cbTags.Items.AddRange(new object[] {
            "Album",
            "Artist",
            "Title"});
            this.cbTags.Location = new System.Drawing.Point(3, 16);
            this.cbTags.MultiColumn = true;
            this.cbTags.Name = "cbTags";
            this.cbTags.Size = new System.Drawing.Size(450, 157);
            this.cbTags.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(285, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Find &Previous";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(396, 243);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Find &Next";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(507, 243);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 23);
            this.button3.TabIndex = 19;
            this.button3.Text = "Sk&ip Track";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(396, 272);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(105, 23);
            this.button4.TabIndex = 20;
            this.button4.Text = "Replac&e Next";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(504, 272);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(105, 23);
            this.button5.TabIndex = 21;
            this.button5.Text = "Replace &All";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 7);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(45, 17);
            this.radioButton1.TabIndex = 22;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "&Find";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(12, 34);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(65, 17);
            this.radioButton2.TabIndex = 23;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "&Replace";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // FindReplaceDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 309);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindReplaceDialog";
            this.Text = "Find / Replace";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox checkBox3;
        public System.Windows.Forms.CheckBox checkBox2;
        public System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.ComboBox comboBox2;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.CheckBox checkBox4;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.CheckedListBox cbTags;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}