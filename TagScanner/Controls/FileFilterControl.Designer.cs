namespace TagScanner.Controls
{
    partial class FileFilterControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbAttrEncrypted = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbAttrCompressed = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.seFileSizeMax = new System.Windows.Forms.NumericUpDown();
            this.seFileSizeMin = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.cbAccessedUtc = new System.Windows.Forms.CheckBox();
            this.cbModifiedUtc = new System.Windows.Forms.CheckBox();
            this.cbCreatedUtc = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbAttrArchive = new System.Windows.Forms.ComboBox();
            this.cbAttrSystem = new System.Windows.Forms.ComboBox();
            this.cbAttrHidden = new System.Windows.Forms.ComboBox();
            this.cbAttrReadOnly = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbFileSizeMax = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbFileSizeMin = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpAccessedMax = new System.Windows.Forms.DateTimePicker();
            this.dtpAccessedMin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpModifiedMax = new System.Windows.Forms.DateTimePicker();
            this.dtpModifiedMin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpCreatedMax = new System.Windows.Forms.DateTimePicker();
            this.dtpCreatedMin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seFileSizeMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFileSizeMin)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbAttrEncrypted);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.cbAttrCompressed);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.seFileSizeMax);
            this.panel2.Controls.Add(this.seFileSizeMin);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.cbAccessedUtc);
            this.panel2.Controls.Add(this.cbModifiedUtc);
            this.panel2.Controls.Add(this.cbCreatedUtc);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.cbAttrArchive);
            this.panel2.Controls.Add(this.cbAttrSystem);
            this.panel2.Controls.Add(this.cbAttrHidden);
            this.panel2.Controls.Add(this.cbAttrReadOnly);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cbFileSizeMax);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cbFileSizeMin);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.dtpAccessedMax);
            this.panel2.Controls.Add(this.dtpAccessedMin);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dtpModifiedMax);
            this.panel2.Controls.Add(this.dtpModifiedMin);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dtpCreatedMax);
            this.panel2.Controls.Add(this.dtpCreatedMin);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(416, 282);
            this.panel2.TabIndex = 2;
            // 
            // cbAttrEncrypted
            // 
            this.cbAttrEncrypted.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttrEncrypted.FormattingEnabled = true;
            this.cbAttrEncrypted.Items.AddRange(new object[] {
            "",
            "Set",
            "Clear"});
            this.cbAttrEncrypted.Location = new System.Drawing.Point(284, 245);
            this.cbAttrEncrypted.Margin = new System.Windows.Forms.Padding(5);
            this.cbAttrEncrypted.Name = "cbAttrEncrypted";
            this.cbAttrEncrypted.Size = new System.Drawing.Size(75, 25);
            this.cbAttrEncrypted.TabIndex = 32;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(197, 249);
            this.label14.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 17);
            this.label14.TabIndex = 31;
            this.label14.Text = "&Encrypted";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbAttrCompressed
            // 
            this.cbAttrCompressed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttrCompressed.FormattingEnabled = true;
            this.cbAttrCompressed.Items.AddRange(new object[] {
            "",
            "Set",
            "Clear"});
            this.cbAttrCompressed.Location = new System.Drawing.Point(284, 210);
            this.cbAttrCompressed.Margin = new System.Windows.Forms.Padding(5);
            this.cbAttrCompressed.Name = "cbAttrCompressed";
            this.cbAttrCompressed.Size = new System.Drawing.Size(75, 25);
            this.cbAttrCompressed.TabIndex = 28;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(197, 214);
            this.label13.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 17);
            this.label13.TabIndex = 27;
            this.label13.Text = "C&ompressed";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // seFileSizeMax
            // 
            this.seFileSizeMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.seFileSizeMax.Location = new System.Drawing.Point(255, 141);
            this.seFileSizeMax.Margin = new System.Windows.Forms.Padding(4);
            this.seFileSizeMax.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFileSizeMax.Name = "seFileSizeMax";
            this.seFileSizeMax.Size = new System.Drawing.Size(104, 25);
            this.seFileSizeMax.TabIndex = 20;
            this.seFileSizeMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // seFileSizeMin
            // 
            this.seFileSizeMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.seFileSizeMin.Location = new System.Drawing.Point(97, 141);
            this.seFileSizeMin.Margin = new System.Windows.Forms.Padding(4);
            this.seFileSizeMin.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFileSizeMin.Name = "seFileSizeMin";
            this.seFileSizeMin.Size = new System.Drawing.Size(102, 25);
            this.seFileSizeMin.TabIndex = 18;
            this.seFileSizeMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(368, 10);
            this.label12.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 17);
            this.label12.TabIndex = 3;
            this.label12.Text = "UTC?";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbAccessedUtc
            // 
            this.cbAccessedUtc.AutoSize = true;
            this.cbAccessedUtc.Location = new System.Drawing.Point(390, 108);
            this.cbAccessedUtc.Margin = new System.Windows.Forms.Padding(5);
            this.cbAccessedUtc.Name = "cbAccessedUtc";
            this.cbAccessedUtc.Size = new System.Drawing.Size(15, 14);
            this.cbAccessedUtc.TabIndex = 15;
            this.cbAccessedUtc.UseVisualStyleBackColor = true;
            // 
            // cbModifiedUtc
            // 
            this.cbModifiedUtc.AutoSize = true;
            this.cbModifiedUtc.Location = new System.Drawing.Point(390, 73);
            this.cbModifiedUtc.Margin = new System.Windows.Forms.Padding(5);
            this.cbModifiedUtc.Name = "cbModifiedUtc";
            this.cbModifiedUtc.Size = new System.Drawing.Size(15, 14);
            this.cbModifiedUtc.TabIndex = 11;
            this.cbModifiedUtc.UseVisualStyleBackColor = true;
            // 
            // cbCreatedUtc
            // 
            this.cbCreatedUtc.AutoSize = true;
            this.cbCreatedUtc.Location = new System.Drawing.Point(390, 38);
            this.cbCreatedUtc.Margin = new System.Windows.Forms.Padding(5);
            this.cbCreatedUtc.Name = "cbCreatedUtc";
            this.cbCreatedUtc.Size = new System.Drawing.Size(15, 14);
            this.cbCreatedUtc.TabIndex = 7;
            this.cbCreatedUtc.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 10);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Date";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Visible = false;
            // 
            // cbAttrArchive
            // 
            this.cbAttrArchive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttrArchive.FormattingEnabled = true;
            this.cbAttrArchive.Items.AddRange(new object[] {
            "",
            "Set",
            "Clear"});
            this.cbAttrArchive.Location = new System.Drawing.Point(284, 175);
            this.cbAttrArchive.Margin = new System.Windows.Forms.Padding(5);
            this.cbAttrArchive.Name = "cbAttrArchive";
            this.cbAttrArchive.Size = new System.Drawing.Size(75, 25);
            this.cbAttrArchive.TabIndex = 24;
            // 
            // cbAttrSystem
            // 
            this.cbAttrSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttrSystem.FormattingEnabled = true;
            this.cbAttrSystem.Items.AddRange(new object[] {
            "",
            "Set",
            "Clear"});
            this.cbAttrSystem.Location = new System.Drawing.Point(97, 245);
            this.cbAttrSystem.Margin = new System.Windows.Forms.Padding(5);
            this.cbAttrSystem.Name = "cbAttrSystem";
            this.cbAttrSystem.Size = new System.Drawing.Size(75, 25);
            this.cbAttrSystem.TabIndex = 30;
            // 
            // cbAttrHidden
            // 
            this.cbAttrHidden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttrHidden.FormattingEnabled = true;
            this.cbAttrHidden.Items.AddRange(new object[] {
            "",
            "Set",
            "Clear"});
            this.cbAttrHidden.Location = new System.Drawing.Point(97, 210);
            this.cbAttrHidden.Margin = new System.Windows.Forms.Padding(5);
            this.cbAttrHidden.Name = "cbAttrHidden";
            this.cbAttrHidden.Size = new System.Drawing.Size(75, 25);
            this.cbAttrHidden.TabIndex = 26;
            // 
            // cbAttrReadOnly
            // 
            this.cbAttrReadOnly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttrReadOnly.FormattingEnabled = true;
            this.cbAttrReadOnly.Items.AddRange(new object[] {
            "",
            "Set",
            "Clear"});
            this.cbAttrReadOnly.Location = new System.Drawing.Point(97, 175);
            this.cbAttrReadOnly.Margin = new System.Windows.Forms.Padding(5);
            this.cbAttrReadOnly.Name = "cbAttrReadOnly";
            this.cbAttrReadOnly.Size = new System.Drawing.Size(75, 25);
            this.cbAttrReadOnly.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(197, 179);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 17);
            this.label10.TabIndex = 23;
            this.label10.Text = "Archi&ve";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 249);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 17);
            this.label9.TabIndex = 29;
            this.label9.Text = "&System";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 214);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 17);
            this.label8.TabIndex = 25;
            this.label8.Text = "&Hidden";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 179);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "&Read-only";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbFileSizeMax
            // 
            this.cbFileSizeMax.AutoSize = true;
            this.cbFileSizeMax.Location = new System.Drawing.Point(234, 145);
            this.cbFileSizeMax.Margin = new System.Windows.Forms.Padding(5);
            this.cbFileSizeMax.Name = "cbFileSizeMax";
            this.cbFileSizeMax.Size = new System.Drawing.Size(15, 14);
            this.cbFileSizeMax.TabIndex = 19;
            this.cbFileSizeMax.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 143);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "&File Size";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbFileSizeMin
            // 
            this.cbFileSizeMin.AutoSize = true;
            this.cbFileSizeMin.Location = new System.Drawing.Point(74, 145);
            this.cbFileSizeMin.Margin = new System.Windows.Forms.Padding(5);
            this.cbFileSizeMin.Name = "cbFileSizeMin";
            this.cbFileSizeMin.Size = new System.Drawing.Size(15, 14);
            this.cbFileSizeMin.TabIndex = 17;
            this.cbFileSizeMin.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(231, 10);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Up to";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 10);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "From";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpAccessedMax
            // 
            this.dtpAccessedMax.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAccessedMax.Location = new System.Drawing.Point(231, 102);
            this.dtpAccessedMax.Margin = new System.Windows.Forms.Padding(5);
            this.dtpAccessedMax.Name = "dtpAccessedMax";
            this.dtpAccessedMax.ShowCheckBox = true;
            this.dtpAccessedMax.Size = new System.Drawing.Size(128, 25);
            this.dtpAccessedMax.TabIndex = 14;
            // 
            // dtpAccessedMin
            // 
            this.dtpAccessedMin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAccessedMin.Location = new System.Drawing.Point(71, 102);
            this.dtpAccessedMin.Margin = new System.Windows.Forms.Padding(5);
            this.dtpAccessedMin.Name = "dtpAccessedMin";
            this.dtpAccessedMin.ShowCheckBox = true;
            this.dtpAccessedMin.Size = new System.Drawing.Size(128, 25);
            this.dtpAccessedMin.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "&Accessed";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpModifiedMax
            // 
            this.dtpModifiedMax.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpModifiedMax.Location = new System.Drawing.Point(231, 67);
            this.dtpModifiedMax.Margin = new System.Windows.Forms.Padding(5);
            this.dtpModifiedMax.Name = "dtpModifiedMax";
            this.dtpModifiedMax.ShowCheckBox = true;
            this.dtpModifiedMax.Size = new System.Drawing.Size(128, 25);
            this.dtpModifiedMax.TabIndex = 10;
            // 
            // dtpModifiedMin
            // 
            this.dtpModifiedMin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpModifiedMin.Location = new System.Drawing.Point(71, 67);
            this.dtpModifiedMin.Margin = new System.Windows.Forms.Padding(5);
            this.dtpModifiedMin.Name = "dtpModifiedMin";
            this.dtpModifiedMin.ShowCheckBox = true;
            this.dtpModifiedMin.Size = new System.Drawing.Size(128, 25);
            this.dtpModifiedMin.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "&Modified";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpCreatedMax
            // 
            this.dtpCreatedMax.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreatedMax.Location = new System.Drawing.Point(231, 32);
            this.dtpCreatedMax.Margin = new System.Windows.Forms.Padding(5);
            this.dtpCreatedMax.Name = "dtpCreatedMax";
            this.dtpCreatedMax.ShowCheckBox = true;
            this.dtpCreatedMax.Size = new System.Drawing.Size(128, 25);
            this.dtpCreatedMax.TabIndex = 6;
            // 
            // dtpCreatedMin
            // 
            this.dtpCreatedMin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreatedMin.Location = new System.Drawing.Point(71, 32);
            this.dtpCreatedMin.Margin = new System.Windows.Forms.Padding(5);
            this.dtpCreatedMin.Name = "dtpCreatedMin";
            this.dtpCreatedMin.ShowCheckBox = true;
            this.dtpCreatedMin.Size = new System.Drawing.Size(128, 25);
            this.dtpCreatedMin.TabIndex = 5;
            this.dtpCreatedMin.Value = new System.DateTime(2024, 9, 27, 21, 20, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "&Created";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FileFilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FileFilterControl";
            this.Size = new System.Drawing.Size(416, 282);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seFileSizeMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFileSizeMin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.ComboBox cbAttrEncrypted;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.ComboBox cbAttrCompressed;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.NumericUpDown seFileSizeMax;
        public System.Windows.Forms.NumericUpDown seFileSizeMin;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.CheckBox cbAccessedUtc;
        public System.Windows.Forms.CheckBox cbModifiedUtc;
        public System.Windows.Forms.CheckBox cbCreatedUtc;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.ComboBox cbAttrArchive;
        public System.Windows.Forms.ComboBox cbAttrSystem;
        public System.Windows.Forms.ComboBox cbAttrHidden;
        public System.Windows.Forms.ComboBox cbAttrReadOnly;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.CheckBox cbFileSizeMax;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.CheckBox cbFileSizeMin;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.DateTimePicker dtpAccessedMax;
        public System.Windows.Forms.DateTimePicker dtpAccessedMin;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.DateTimePicker dtpModifiedMax;
        public System.Windows.Forms.DateTimePicker dtpModifiedMin;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.DateTimePicker dtpCreatedMax;
        public System.Windows.Forms.DateTimePicker dtpCreatedMin;
        public System.Windows.Forms.Label label1;
    }
}
