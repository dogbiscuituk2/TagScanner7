namespace TagScanner.Forms
{
    partial class FileFilterDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtpCreatedMin = new System.Windows.Forms.DateTimePicker();
            this.dtpCreatedMax = new System.Windows.Forms.DateTimePicker();
            this.dtpModifiedMax = new System.Windows.Forms.DateTimePicker();
            this.dtpModifiedMin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpAccessedMax = new System.Windows.Forms.DateTimePicker();
            this.dtpAccessedMin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.seFileSizeMin = new System.Windows.Forms.NumericUpDown();
            this.cbFileSizeMin = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbFileSizeMax = new System.Windows.Forms.CheckBox();
            this.seFileSizeMax = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbAttrReadOnly = new System.Windows.Forms.ComboBox();
            this.cbAttrHidden = new System.Windows.Forms.ComboBox();
            this.cbAttrSystem = new System.Windows.Forms.ComboBox();
            this.cbAttrArchive = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.cbCreatedUtc = new System.Windows.Forms.CheckBox();
            this.cbModifiedUtc = new System.Windows.Forms.CheckBox();
            this.cbAccessedUtc = new System.Windows.Forms.CheckBox();
            this.cbCreatedMin = new System.Windows.Forms.CheckBox();
            this.cbModifiedMin = new System.Windows.Forms.CheckBox();
            this.cbAccessedMin = new System.Windows.Forms.CheckBox();
            this.cbAccessedMax = new System.Windows.Forms.CheckBox();
            this.cbModifiedMax = new System.Windows.Forms.CheckBox();
            this.cbCreatedMax = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.seFileSizeMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFileSizeMax)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Created";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpCreatedMin
            // 
            this.dtpCreatedMin.Location = new System.Drawing.Point(96, 38);
            this.dtpCreatedMin.Name = "dtpCreatedMin";
            this.dtpCreatedMin.Size = new System.Drawing.Size(163, 20);
            this.dtpCreatedMin.TabIndex = 1;
            // 
            // dtpCreatedMax
            // 
            this.dtpCreatedMax.Location = new System.Drawing.Point(286, 38);
            this.dtpCreatedMax.Name = "dtpCreatedMax";
            this.dtpCreatedMax.Size = new System.Drawing.Size(163, 20);
            this.dtpCreatedMax.TabIndex = 3;
            // 
            // dtpModifiedMax
            // 
            this.dtpModifiedMax.Location = new System.Drawing.Point(286, 64);
            this.dtpModifiedMax.Name = "dtpModifiedMax";
            this.dtpModifiedMax.Size = new System.Drawing.Size(163, 20);
            this.dtpModifiedMax.TabIndex = 6;
            // 
            // dtpModifiedMin
            // 
            this.dtpModifiedMin.Location = new System.Drawing.Point(96, 64);
            this.dtpModifiedMin.Name = "dtpModifiedMin";
            this.dtpModifiedMin.Size = new System.Drawing.Size(163, 20);
            this.dtpModifiedMin.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Modified";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpAccessedMax
            // 
            this.dtpAccessedMax.Location = new System.Drawing.Point(286, 90);
            this.dtpAccessedMax.Name = "dtpAccessedMax";
            this.dtpAccessedMax.Size = new System.Drawing.Size(163, 20);
            this.dtpAccessedMax.TabIndex = 9;
            // 
            // dtpAccessedMin
            // 
            this.dtpAccessedMin.Location = new System.Drawing.Point(96, 90);
            this.dtpAccessedMin.Name = "dtpAccessedMin";
            this.dtpAccessedMin.Size = new System.Drawing.Size(163, 20);
            this.dtpAccessedMin.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Accessed";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(72, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Minimum";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(262, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "Maximum";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // seFileSizeMin
            // 
            this.seFileSizeMin.Location = new System.Drawing.Point(96, 116);
            this.seFileSizeMin.Name = "seFileSizeMin";
            this.seFileSizeMin.Size = new System.Drawing.Size(163, 20);
            this.seFileSizeMin.TabIndex = 12;
            // 
            // cbFileSizeMin
            // 
            this.cbFileSizeMin.AutoSize = true;
            this.cbFileSizeMin.Location = new System.Drawing.Point(75, 120);
            this.cbFileSizeMin.Name = "cbFileSizeMin";
            this.cbFileSizeMin.Size = new System.Drawing.Size(15, 14);
            this.cbFileSizeMin.TabIndex = 13;
            this.cbFileSizeMin.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "File Size";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbFileSizeMax
            // 
            this.cbFileSizeMax.AutoSize = true;
            this.cbFileSizeMax.Location = new System.Drawing.Point(265, 120);
            this.cbFileSizeMax.Name = "cbFileSizeMax";
            this.cbFileSizeMax.Size = new System.Drawing.Size(15, 14);
            this.cbFileSizeMax.TabIndex = 16;
            this.cbFileSizeMax.UseVisualStyleBackColor = true;
            // 
            // seFileSizeMax
            // 
            this.seFileSizeMax.Location = new System.Drawing.Point(286, 116);
            this.seFileSizeMax.Name = "seFileSizeMax";
            this.seFileSizeMax.Size = new System.Drawing.Size(163, 20);
            this.seFileSizeMax.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Read Only";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Hidden";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 199);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "System";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 226);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Archive";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbAttrReadOnly
            // 
            this.cbAttrReadOnly.FormattingEnabled = true;
            this.cbAttrReadOnly.Items.AddRange(new object[] {
            "Any",
            "True",
            "False"});
            this.cbAttrReadOnly.Location = new System.Drawing.Point(75, 142);
            this.cbAttrReadOnly.Name = "cbAttrReadOnly";
            this.cbAttrReadOnly.Size = new System.Drawing.Size(58, 21);
            this.cbAttrReadOnly.TabIndex = 33;
            this.cbAttrReadOnly.Text = "Any";
            // 
            // cbAttrHidden
            // 
            this.cbAttrHidden.FormattingEnabled = true;
            this.cbAttrHidden.Items.AddRange(new object[] {
            "Any",
            "True",
            "False"});
            this.cbAttrHidden.Location = new System.Drawing.Point(75, 169);
            this.cbAttrHidden.Name = "cbAttrHidden";
            this.cbAttrHidden.Size = new System.Drawing.Size(58, 21);
            this.cbAttrHidden.TabIndex = 34;
            this.cbAttrHidden.Text = "Any";
            // 
            // cbAttrSystem
            // 
            this.cbAttrSystem.FormattingEnabled = true;
            this.cbAttrSystem.Items.AddRange(new object[] {
            "Any",
            "True",
            "False"});
            this.cbAttrSystem.Location = new System.Drawing.Point(75, 196);
            this.cbAttrSystem.Name = "cbAttrSystem";
            this.cbAttrSystem.Size = new System.Drawing.Size(58, 21);
            this.cbAttrSystem.TabIndex = 35;
            this.cbAttrSystem.Text = "Any";
            // 
            // cbAttrArchive
            // 
            this.cbAttrArchive.FormattingEnabled = true;
            this.cbAttrArchive.Items.AddRange(new object[] {
            "Any",
            "True",
            "False"});
            this.cbAttrArchive.Location = new System.Drawing.Point(75, 223);
            this.cbAttrArchive.Name = "cbAttrArchive";
            this.cbAttrArchive.Size = new System.Drawing.Size(58, 21);
            this.cbAttrArchive.TabIndex = 36;
            this.cbAttrArchive.Text = "Any";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(344, 221);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 37;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(425, 221);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 38;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(15, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 23);
            this.label11.TabIndex = 39;
            this.label11.Text = "Date";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbCreatedUtc
            // 
            this.cbCreatedUtc.AutoSize = true;
            this.cbCreatedUtc.Location = new System.Drawing.Point(455, 42);
            this.cbCreatedUtc.Name = "cbCreatedUtc";
            this.cbCreatedUtc.Size = new System.Drawing.Size(48, 17);
            this.cbCreatedUtc.TabIndex = 40;
            this.cbCreatedUtc.Text = "UTC";
            this.cbCreatedUtc.UseVisualStyleBackColor = true;
            // 
            // cbModifiedUtc
            // 
            this.cbModifiedUtc.AutoSize = true;
            this.cbModifiedUtc.Location = new System.Drawing.Point(455, 68);
            this.cbModifiedUtc.Name = "cbModifiedUtc";
            this.cbModifiedUtc.Size = new System.Drawing.Size(48, 17);
            this.cbModifiedUtc.TabIndex = 41;
            this.cbModifiedUtc.Text = "UTC";
            this.cbModifiedUtc.UseVisualStyleBackColor = true;
            // 
            // cbAccessedUtc
            // 
            this.cbAccessedUtc.AutoSize = true;
            this.cbAccessedUtc.Location = new System.Drawing.Point(455, 94);
            this.cbAccessedUtc.Name = "cbAccessedUtc";
            this.cbAccessedUtc.Size = new System.Drawing.Size(48, 17);
            this.cbAccessedUtc.TabIndex = 42;
            this.cbAccessedUtc.Text = "UTC";
            this.cbAccessedUtc.UseVisualStyleBackColor = true;
            // 
            // cbCreatedMin
            // 
            this.cbCreatedMin.AutoSize = true;
            this.cbCreatedMin.Location = new System.Drawing.Point(75, 42);
            this.cbCreatedMin.Name = "cbCreatedMin";
            this.cbCreatedMin.Size = new System.Drawing.Size(15, 14);
            this.cbCreatedMin.TabIndex = 43;
            this.cbCreatedMin.UseVisualStyleBackColor = true;
            // 
            // cbModifiedMin
            // 
            this.cbModifiedMin.AutoSize = true;
            this.cbModifiedMin.Location = new System.Drawing.Point(75, 68);
            this.cbModifiedMin.Name = "cbModifiedMin";
            this.cbModifiedMin.Size = new System.Drawing.Size(15, 14);
            this.cbModifiedMin.TabIndex = 44;
            this.cbModifiedMin.UseVisualStyleBackColor = true;
            // 
            // cbAccessedMin
            // 
            this.cbAccessedMin.AutoSize = true;
            this.cbAccessedMin.Location = new System.Drawing.Point(75, 94);
            this.cbAccessedMin.Name = "cbAccessedMin";
            this.cbAccessedMin.Size = new System.Drawing.Size(15, 14);
            this.cbAccessedMin.TabIndex = 45;
            this.cbAccessedMin.UseVisualStyleBackColor = true;
            // 
            // cbAccessedMax
            // 
            this.cbAccessedMax.AutoSize = true;
            this.cbAccessedMax.Location = new System.Drawing.Point(265, 94);
            this.cbAccessedMax.Name = "cbAccessedMax";
            this.cbAccessedMax.Size = new System.Drawing.Size(15, 14);
            this.cbAccessedMax.TabIndex = 48;
            this.cbAccessedMax.UseVisualStyleBackColor = true;
            // 
            // cbModifiedMax
            // 
            this.cbModifiedMax.AutoSize = true;
            this.cbModifiedMax.Location = new System.Drawing.Point(265, 68);
            this.cbModifiedMax.Name = "cbModifiedMax";
            this.cbModifiedMax.Size = new System.Drawing.Size(15, 14);
            this.cbModifiedMax.TabIndex = 47;
            this.cbModifiedMax.UseVisualStyleBackColor = true;
            // 
            // cbCreatedMax
            // 
            this.cbCreatedMax.AutoSize = true;
            this.cbCreatedMax.Location = new System.Drawing.Point(265, 42);
            this.cbCreatedMax.Name = "cbCreatedMax";
            this.cbCreatedMax.Size = new System.Drawing.Size(15, 14);
            this.cbCreatedMax.TabIndex = 46;
            this.cbCreatedMax.UseVisualStyleBackColor = true;
            // 
            // FileFilterDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(519, 254);
            this.Controls.Add(this.cbAccessedMax);
            this.Controls.Add(this.cbModifiedMax);
            this.Controls.Add(this.cbCreatedMax);
            this.Controls.Add(this.cbAccessedMin);
            this.Controls.Add(this.cbModifiedMin);
            this.Controls.Add(this.cbCreatedMin);
            this.Controls.Add(this.cbAccessedUtc);
            this.Controls.Add(this.cbModifiedUtc);
            this.Controls.Add(this.cbCreatedUtc);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbAttrArchive);
            this.Controls.Add(this.cbAttrSystem);
            this.Controls.Add(this.cbAttrHidden);
            this.Controls.Add(this.cbAttrReadOnly);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbFileSizeMax);
            this.Controls.Add(this.seFileSizeMax);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbFileSizeMin);
            this.Controls.Add(this.seFileSizeMin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpAccessedMax);
            this.Controls.Add(this.dtpAccessedMin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpModifiedMax);
            this.Controls.Add(this.dtpModifiedMin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpCreatedMax);
            this.Controls.Add(this.dtpCreatedMin);
            this.Controls.Add(this.label1);
            this.Name = "FileFilterDialog";
            this.Text = "Filesystem Filter";
            ((System.ComponentModel.ISupportInitialize)(this.seFileSizeMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFileSizeMax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.DateTimePicker dtpCreatedMin;
        public System.Windows.Forms.DateTimePicker dtpCreatedMax;
        public System.Windows.Forms.DateTimePicker dtpModifiedMax;
        public System.Windows.Forms.DateTimePicker dtpModifiedMin;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.DateTimePicker dtpAccessedMax;
        public System.Windows.Forms.DateTimePicker dtpAccessedMin;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.NumericUpDown seFileSizeMin;
        public System.Windows.Forms.CheckBox cbFileSizeMin;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.CheckBox cbFileSizeMax;
        public System.Windows.Forms.NumericUpDown seFileSizeMax;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.ComboBox cbAttrReadOnly;
        public System.Windows.Forms.ComboBox cbAttrHidden;
        public System.Windows.Forms.ComboBox cbAttrSystem;
        public System.Windows.Forms.ComboBox cbAttrArchive;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.CheckBox cbCreatedUtc;
        public System.Windows.Forms.CheckBox cbModifiedUtc;
        public System.Windows.Forms.CheckBox cbAccessedUtc;
        public System.Windows.Forms.CheckBox cbCreatedMin;
        public System.Windows.Forms.CheckBox cbModifiedMin;
        public System.Windows.Forms.CheckBox cbAccessedMin;
        public System.Windows.Forms.CheckBox cbAccessedMax;
        public System.Windows.Forms.CheckBox cbModifiedMax;
        public System.Windows.Forms.CheckBox cbCreatedMax;
    }
}