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
            this.components = new System.ComponentModel.Container();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.edConditions = new System.Windows.Forms.TextBox();
            this.cbUseTimes = new System.Windows.Forms.CheckBox();
            this.cbUnit = new System.Windows.Forms.ComboBox();
            this.cbUseAutocorrect = new System.Windows.Forms.CheckBox();
            this.seFileSizeMax = new System.Windows.Forms.NumericUpDown();
            this.seFileSizeMin = new System.Windows.Forms.NumericUpDown();
            this.lblUtc = new System.Windows.Forms.Label();
            this.cbAccessedUtc = new System.Windows.Forms.CheckBox();
            this.cbModifiedUtc = new System.Windows.Forms.CheckBox();
            this.cbCreatedUtc = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblUpTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpAccessedMax = new System.Windows.Forms.DateTimePicker();
            this.dtpAccessedMin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpModifiedMax = new System.Windows.Forms.DateTimePicker();
            this.dtpModifiedMin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpCreatedMax = new System.Windows.Forms.DateTimePicker();
            this.dtpCreatedMin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cbReadOnly = new System.Windows.Forms.CheckBox();
            this.cbHidden = new System.Windows.Forms.CheckBox();
            this.cbSystem = new System.Windows.Forms.CheckBox();
            this.cbArchive = new System.Windows.Forms.CheckBox();
            this.cbEncrypted = new System.Windows.Forms.CheckBox();
            this.cbCompressed = new System.Windows.Forms.CheckBox();
            this.MainPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seFileSizeMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFileSizeMin)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.cbCompressed);
            this.MainPanel.Controls.Add(this.cbEncrypted);
            this.MainPanel.Controls.Add(this.cbArchive);
            this.MainPanel.Controls.Add(this.cbSystem);
            this.MainPanel.Controls.Add(this.cbHidden);
            this.MainPanel.Controls.Add(this.cbReadOnly);
            this.MainPanel.Controls.Add(this.groupBox1);
            this.MainPanel.Controls.Add(this.cbUseTimes);
            this.MainPanel.Controls.Add(this.cbUnit);
            this.MainPanel.Controls.Add(this.cbUseAutocorrect);
            this.MainPanel.Controls.Add(this.seFileSizeMax);
            this.MainPanel.Controls.Add(this.seFileSizeMin);
            this.MainPanel.Controls.Add(this.lblUtc);
            this.MainPanel.Controls.Add(this.cbAccessedUtc);
            this.MainPanel.Controls.Add(this.cbModifiedUtc);
            this.MainPanel.Controls.Add(this.cbCreatedUtc);
            this.MainPanel.Controls.Add(this.label6);
            this.MainPanel.Controls.Add(this.lblUpTo);
            this.MainPanel.Controls.Add(this.lblFrom);
            this.MainPanel.Controls.Add(this.dtpAccessedMax);
            this.MainPanel.Controls.Add(this.dtpAccessedMin);
            this.MainPanel.Controls.Add(this.label3);
            this.MainPanel.Controls.Add(this.dtpModifiedMax);
            this.MainPanel.Controls.Add(this.dtpModifiedMin);
            this.MainPanel.Controls.Add(this.label2);
            this.MainPanel.Controls.Add(this.dtpCreatedMax);
            this.MainPanel.Controls.Add(this.dtpCreatedMin);
            this.MainPanel.Controls.Add(this.label1);
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(400, 320);
            this.MainPanel.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.edConditions);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 210);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(400, 110);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected File Property Conditions";
            // 
            // edConditions
            // 
            this.edConditions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.edConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edConditions.Location = new System.Drawing.Point(2, 20);
            this.edConditions.Multiline = true;
            this.edConditions.Name = "edConditions";
            this.edConditions.ReadOnly = true;
            this.edConditions.Size = new System.Drawing.Size(396, 88);
            this.edConditions.TabIndex = 0;
            // 
            // cbUseTimes
            // 
            this.cbUseTimes.AutoSize = true;
            this.cbUseTimes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbUseTimes.Location = new System.Drawing.Point(301, 162);
            this.cbUseTimes.Name = "cbUseTimes";
            this.cbUseTimes.Size = new System.Drawing.Size(87, 21);
            this.cbUseTimes.TabIndex = 25;
            this.cbUseTimes.Text = "Use &Times";
            this.ToolTip.SetToolTip(this.cbUseTimes, "Use both Dates and Times?\r\n(deselect to use Dates only)");
            this.cbUseTimes.UseVisualStyleBackColor = true;
            // 
            // cbUnit
            // 
            this.cbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnit.FormattingEnabled = true;
            this.cbUnit.Items.AddRange(new object[] {
            "Bytes",
            "KiB",
            "MiB",
            "GiB",
            "TiB",
            "PiB",
            "EiB"});
            this.cbUnit.Location = new System.Drawing.Point(333, 110);
            this.cbUnit.Name = "cbUnit";
            this.cbUnit.Size = new System.Drawing.Size(54, 25);
            this.cbUnit.TabIndex = 18;
            this.ToolTip.SetToolTip(this.cbUnit, "File Size units of measurement");
            // 
            // cbUseAutocorrect
            // 
            this.cbUseAutocorrect.AutoSize = true;
            this.cbUseAutocorrect.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbUseAutocorrect.Location = new System.Drawing.Point(267, 182);
            this.cbUseAutocorrect.Name = "cbUseAutocorrect";
            this.cbUseAutocorrect.Size = new System.Drawing.Size(121, 21);
            this.cbUseAutocorrect.TabIndex = 26;
            this.cbUseAutocorrect.Text = "Use A&utocorrect";
            this.ToolTip.SetToolTip(this.cbUseAutocorrect, "Automatic adjustment for data validation errors");
            this.cbUseAutocorrect.UseVisualStyleBackColor = true;
            // 
            // seFileSizeMax
            // 
            this.seFileSizeMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.seFileSizeMax.Location = new System.Drawing.Point(201, 110);
            this.seFileSizeMax.Margin = new System.Windows.Forms.Padding(4);
            this.seFileSizeMax.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFileSizeMax.Name = "seFileSizeMax";
            this.seFileSizeMax.Size = new System.Drawing.Size(108, 25);
            this.seFileSizeMax.TabIndex = 17;
            this.seFileSizeMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ToolTip.SetToolTip(this.seFileSizeMax, "Maximum File Size");
            // 
            // seFileSizeMin
            // 
            this.seFileSizeMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.seFileSizeMin.Location = new System.Drawing.Point(69, 110);
            this.seFileSizeMin.Margin = new System.Windows.Forms.Padding(4);
            this.seFileSizeMin.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFileSizeMin.Name = "seFileSizeMin";
            this.seFileSizeMin.Size = new System.Drawing.Size(108, 25);
            this.seFileSizeMin.TabIndex = 16;
            this.seFileSizeMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ToolTip.SetToolTip(this.seFileSizeMin, "Minimum File Size");
            // 
            // lblUtc
            // 
            this.lblUtc.AutoSize = true;
            this.lblUtc.Location = new System.Drawing.Point(365, 6);
            this.lblUtc.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblUtc.Name = "lblUtc";
            this.lblUtc.Size = new System.Drawing.Size(31, 17);
            this.lblUtc.TabIndex = 2;
            this.lblUtc.Text = "UTC";
            this.lblUtc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToolTip.SetToolTip(this.lblUtc, "Use UTC Dates/Times");
            // 
            // cbAccessedUtc
            // 
            this.cbAccessedUtc.AutoSize = true;
            this.cbAccessedUtc.Location = new System.Drawing.Point(373, 82);
            this.cbAccessedUtc.Margin = new System.Windows.Forms.Padding(5);
            this.cbAccessedUtc.Name = "cbAccessedUtc";
            this.cbAccessedUtc.Size = new System.Drawing.Size(15, 14);
            this.cbAccessedUtc.TabIndex = 14;
            this.ToolTip.SetToolTip(this.cbAccessedUtc, "Use UTC Accessed Date/Time");
            this.cbAccessedUtc.UseVisualStyleBackColor = true;
            // 
            // cbModifiedUtc
            // 
            this.cbModifiedUtc.AutoSize = true;
            this.cbModifiedUtc.Location = new System.Drawing.Point(373, 58);
            this.cbModifiedUtc.Margin = new System.Windows.Forms.Padding(5);
            this.cbModifiedUtc.Name = "cbModifiedUtc";
            this.cbModifiedUtc.Size = new System.Drawing.Size(15, 14);
            this.cbModifiedUtc.TabIndex = 10;
            this.ToolTip.SetToolTip(this.cbModifiedUtc, "Use UTC Modified Date/Time");
            this.cbModifiedUtc.UseVisualStyleBackColor = true;
            // 
            // cbCreatedUtc
            // 
            this.cbCreatedUtc.AutoSize = true;
            this.cbCreatedUtc.Location = new System.Drawing.Point(373, 34);
            this.cbCreatedUtc.Margin = new System.Windows.Forms.Padding(5);
            this.cbCreatedUtc.Name = "cbCreatedUtc";
            this.cbCreatedUtc.Size = new System.Drawing.Size(15, 14);
            this.cbCreatedUtc.TabIndex = 6;
            this.ToolTip.SetToolTip(this.cbCreatedUtc, "Use UTC Created Date/Time");
            this.cbCreatedUtc.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 114);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "&File Size";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUpTo
            // 
            this.lblUpTo.AutoSize = true;
            this.lblUpTo.Location = new System.Drawing.Point(221, 6);
            this.lblUpTo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblUpTo.Name = "lblUpTo";
            this.lblUpTo.Size = new System.Drawing.Size(41, 17);
            this.lblUpTo.TabIndex = 1;
            this.lblUpTo.Text = "Up to";
            this.lblUpTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToolTip.SetToolTip(this.lblUpTo, "Latest Date/Time");
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(69, 6);
            this.lblFrom.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(38, 17);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From";
            this.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToolTip.SetToolTip(this.lblFrom, "Earliest Date/Time");
            // 
            // dtpAccessedMax
            // 
            this.dtpAccessedMax.CustomFormat = "yyyy-MM-dd";
            this.dtpAccessedMax.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAccessedMax.Location = new System.Drawing.Point(221, 76);
            this.dtpAccessedMax.Margin = new System.Windows.Forms.Padding(5);
            this.dtpAccessedMax.Name = "dtpAccessedMax";
            this.dtpAccessedMax.ShowCheckBox = true;
            this.dtpAccessedMax.Size = new System.Drawing.Size(128, 25);
            this.dtpAccessedMax.TabIndex = 13;
            this.ToolTip.SetToolTip(this.dtpAccessedMax, "Latest Accessed Date/Time");
            // 
            // dtpAccessedMin
            // 
            this.dtpAccessedMin.CustomFormat = "yyyy-MM-dd";
            this.dtpAccessedMin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAccessedMin.Location = new System.Drawing.Point(69, 76);
            this.dtpAccessedMin.Margin = new System.Windows.Forms.Padding(5);
            this.dtpAccessedMin.Name = "dtpAccessedMin";
            this.dtpAccessedMin.ShowCheckBox = true;
            this.dtpAccessedMin.Size = new System.Drawing.Size(128, 25);
            this.dtpAccessedMin.TabIndex = 12;
            this.ToolTip.SetToolTip(this.dtpAccessedMin, "Earliest Accessed Date/Time");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "&Accessed";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.label3, "Accessed Date/Time");
            // 
            // dtpModifiedMax
            // 
            this.dtpModifiedMax.CustomFormat = "yyyy-MM-dd";
            this.dtpModifiedMax.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpModifiedMax.Location = new System.Drawing.Point(221, 52);
            this.dtpModifiedMax.Margin = new System.Windows.Forms.Padding(5);
            this.dtpModifiedMax.Name = "dtpModifiedMax";
            this.dtpModifiedMax.ShowCheckBox = true;
            this.dtpModifiedMax.Size = new System.Drawing.Size(128, 25);
            this.dtpModifiedMax.TabIndex = 9;
            this.ToolTip.SetToolTip(this.dtpModifiedMax, "Latest Modified Date/Time");
            // 
            // dtpModifiedMin
            // 
            this.dtpModifiedMin.CustomFormat = "yyyy-MM-dd";
            this.dtpModifiedMin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpModifiedMin.Location = new System.Drawing.Point(69, 52);
            this.dtpModifiedMin.Margin = new System.Windows.Forms.Padding(5);
            this.dtpModifiedMin.Name = "dtpModifiedMin";
            this.dtpModifiedMin.ShowCheckBox = true;
            this.dtpModifiedMin.Size = new System.Drawing.Size(128, 25);
            this.dtpModifiedMin.TabIndex = 8;
            this.ToolTip.SetToolTip(this.dtpModifiedMin, "Earliest Modified Date/Time");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "&Modified";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.label2, "Modified Date/Time");
            // 
            // dtpCreatedMax
            // 
            this.dtpCreatedMax.CustomFormat = "yyyy-MM-dd";
            this.dtpCreatedMax.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCreatedMax.Location = new System.Drawing.Point(221, 28);
            this.dtpCreatedMax.Margin = new System.Windows.Forms.Padding(5);
            this.dtpCreatedMax.Name = "dtpCreatedMax";
            this.dtpCreatedMax.ShowCheckBox = true;
            this.dtpCreatedMax.Size = new System.Drawing.Size(128, 25);
            this.dtpCreatedMax.TabIndex = 5;
            this.ToolTip.SetToolTip(this.dtpCreatedMax, "Latest Created Date/Time");
            // 
            // dtpCreatedMin
            // 
            this.dtpCreatedMin.CustomFormat = "yyyy-MM-dd";
            this.dtpCreatedMin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCreatedMin.Location = new System.Drawing.Point(69, 28);
            this.dtpCreatedMin.Margin = new System.Windows.Forms.Padding(5);
            this.dtpCreatedMin.Name = "dtpCreatedMin";
            this.dtpCreatedMin.ShowCheckBox = true;
            this.dtpCreatedMin.Size = new System.Drawing.Size(128, 25);
            this.dtpCreatedMin.TabIndex = 4;
            this.ToolTip.SetToolTip(this.dtpCreatedMin, "Earliest Created Date/Time");
            this.dtpCreatedMin.Value = new System.DateTime(2024, 9, 27, 21, 20, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "&Created";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.label1, "Created Date/Time");
            // 
            // cbReadOnly
            // 
            this.cbReadOnly.Checked = true;
            this.cbReadOnly.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbReadOnly.Location = new System.Drawing.Point(9, 142);
            this.cbReadOnly.Name = "cbReadOnly";
            this.cbReadOnly.Size = new System.Drawing.Size(103, 21);
            this.cbReadOnly.TabIndex = 19;
            this.cbReadOnly.Text = "&ReadOnly";
            this.cbReadOnly.ThreeState = true;
            this.cbReadOnly.UseVisualStyleBackColor = true;
            // 
            // cbHidden
            // 
            this.cbHidden.Checked = true;
            this.cbHidden.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbHidden.Location = new System.Drawing.Point(9, 162);
            this.cbHidden.Name = "cbHidden";
            this.cbHidden.Size = new System.Drawing.Size(103, 21);
            this.cbHidden.TabIndex = 20;
            this.cbHidden.Text = "&Hidden";
            this.cbHidden.ThreeState = true;
            this.cbHidden.UseVisualStyleBackColor = true;
            // 
            // cbSystem
            // 
            this.cbSystem.Checked = true;
            this.cbSystem.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbSystem.Location = new System.Drawing.Point(9, 182);
            this.cbSystem.Name = "cbSystem";
            this.cbSystem.Size = new System.Drawing.Size(103, 21);
            this.cbSystem.TabIndex = 21;
            this.cbSystem.Text = "&System";
            this.cbSystem.ThreeState = true;
            this.cbSystem.UseVisualStyleBackColor = true;
            // 
            // cbArchive
            // 
            this.cbArchive.Checked = true;
            this.cbArchive.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbArchive.Location = new System.Drawing.Point(118, 142);
            this.cbArchive.Name = "cbArchive";
            this.cbArchive.Size = new System.Drawing.Size(103, 21);
            this.cbArchive.TabIndex = 22;
            this.cbArchive.Text = "Archi&ve";
            this.cbArchive.ThreeState = true;
            this.cbArchive.UseVisualStyleBackColor = true;
            // 
            // cbEncrypted
            // 
            this.cbEncrypted.Checked = true;
            this.cbEncrypted.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbEncrypted.Location = new System.Drawing.Point(118, 182);
            this.cbEncrypted.Name = "cbEncrypted";
            this.cbEncrypted.Size = new System.Drawing.Size(103, 21);
            this.cbEncrypted.TabIndex = 24;
            this.cbEncrypted.Text = "&Encrypted";
            this.cbEncrypted.ThreeState = true;
            this.cbEncrypted.UseVisualStyleBackColor = true;
            // 
            // cbCompressed
            // 
            this.cbCompressed.Checked = true;
            this.cbCompressed.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbCompressed.Location = new System.Drawing.Point(118, 162);
            this.cbCompressed.Name = "cbCompressed";
            this.cbCompressed.Size = new System.Drawing.Size(103, 21);
            this.cbCompressed.TabIndex = 23;
            this.cbCompressed.Text = "C&ompressed";
            this.cbCompressed.ThreeState = true;
            this.cbCompressed.UseVisualStyleBackColor = true;
            // 
            // FileFilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FileFilterControl";
            this.Size = new System.Drawing.Size(400, 320);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seFileSizeMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFileSizeMin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.NumericUpDown seFileSizeMax;
        public System.Windows.Forms.NumericUpDown seFileSizeMin;
        public System.Windows.Forms.Label lblUtc;
        public System.Windows.Forms.CheckBox cbAccessedUtc;
        public System.Windows.Forms.CheckBox cbModifiedUtc;
        public System.Windows.Forms.CheckBox cbCreatedUtc;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label lblUpTo;
        public System.Windows.Forms.Label lblFrom;
        public System.Windows.Forms.DateTimePicker dtpAccessedMax;
        public System.Windows.Forms.DateTimePicker dtpAccessedMin;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.DateTimePicker dtpModifiedMax;
        public System.Windows.Forms.DateTimePicker dtpModifiedMin;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.DateTimePicker dtpCreatedMax;
        public System.Windows.Forms.DateTimePicker dtpCreatedMin;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ToolTip ToolTip;
        public System.Windows.Forms.CheckBox cbUseAutocorrect;
        public System.Windows.Forms.Panel MainPanel;
        public System.Windows.Forms.ComboBox cbUnit;
        public System.Windows.Forms.CheckBox cbUseTimes;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox edConditions;
        public System.Windows.Forms.CheckBox cbReadOnly;
        public System.Windows.Forms.CheckBox cbCompressed;
        public System.Windows.Forms.CheckBox cbEncrypted;
        public System.Windows.Forms.CheckBox cbArchive;
        public System.Windows.Forms.CheckBox cbSystem;
        public System.Windows.Forms.CheckBox cbHidden;
    }
}
