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
            this.cbUseTimes = new System.Windows.Forms.CheckBox();
            this.cbUnit = new System.Windows.Forms.ComboBox();
            this.cbUseAutocorrect = new System.Windows.Forms.CheckBox();
            this.cbAttrEncrypted = new System.Windows.Forms.ComboBox();
            this.lblEncrypted = new System.Windows.Forms.Label();
            this.cbAttrCompressed = new System.Windows.Forms.ComboBox();
            this.lblCompressed = new System.Windows.Forms.Label();
            this.seFileSizeMax = new System.Windows.Forms.NumericUpDown();
            this.seFileSizeMin = new System.Windows.Forms.NumericUpDown();
            this.lblUtc = new System.Windows.Forms.Label();
            this.cbAccessedUtc = new System.Windows.Forms.CheckBox();
            this.cbModifiedUtc = new System.Windows.Forms.CheckBox();
            this.cbCreatedUtc = new System.Windows.Forms.CheckBox();
            this.cbAttrArchive = new System.Windows.Forms.ComboBox();
            this.cbAttrSystem = new System.Windows.Forms.ComboBox();
            this.cbAttrHidden = new System.Windows.Forms.ComboBox();
            this.cbAttrReadOnly = new System.Windows.Forms.ComboBox();
            this.lblArchive = new System.Windows.Forms.Label();
            this.lblSystem = new System.Windows.Forms.Label();
            this.lblHidden = new System.Windows.Forms.Label();
            this.lblReadOnly = new System.Windows.Forms.Label();
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
            this.edConditions = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seFileSizeMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFileSizeMin)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.groupBox1);
            this.MainPanel.Controls.Add(this.cbUseTimes);
            this.MainPanel.Controls.Add(this.cbUnit);
            this.MainPanel.Controls.Add(this.cbUseAutocorrect);
            this.MainPanel.Controls.Add(this.cbAttrEncrypted);
            this.MainPanel.Controls.Add(this.lblEncrypted);
            this.MainPanel.Controls.Add(this.cbAttrCompressed);
            this.MainPanel.Controls.Add(this.lblCompressed);
            this.MainPanel.Controls.Add(this.seFileSizeMax);
            this.MainPanel.Controls.Add(this.seFileSizeMin);
            this.MainPanel.Controls.Add(this.lblUtc);
            this.MainPanel.Controls.Add(this.cbAccessedUtc);
            this.MainPanel.Controls.Add(this.cbModifiedUtc);
            this.MainPanel.Controls.Add(this.cbCreatedUtc);
            this.MainPanel.Controls.Add(this.cbAttrArchive);
            this.MainPanel.Controls.Add(this.cbAttrSystem);
            this.MainPanel.Controls.Add(this.cbAttrHidden);
            this.MainPanel.Controls.Add(this.cbAttrReadOnly);
            this.MainPanel.Controls.Add(this.lblArchive);
            this.MainPanel.Controls.Add(this.lblSystem);
            this.MainPanel.Controls.Add(this.lblHidden);
            this.MainPanel.Controls.Add(this.lblReadOnly);
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
            this.MainPanel.Size = new System.Drawing.Size(396, 422);
            this.MainPanel.TabIndex = 0;
            // 
            // cbUseTimes
            // 
            this.cbUseTimes.AutoSize = true;
            this.cbUseTimes.Location = new System.Drawing.Point(9, 5);
            this.cbUseTimes.Name = "cbUseTimes";
            this.cbUseTimes.Size = new System.Drawing.Size(87, 21);
            this.cbUseTimes.TabIndex = 36;
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
            "TiB"});
            this.cbUnit.Location = new System.Drawing.Point(333, 133);
            this.cbUnit.Name = "cbUnit";
            this.cbUnit.Size = new System.Drawing.Size(54, 25);
            this.cbUnit.TabIndex = 34;
            this.ToolTip.SetToolTip(this.cbUnit, "File Size units of measurement");
            // 
            // cbUseAutocorrect
            // 
            this.cbUseAutocorrect.AutoSize = true;
            this.cbUseAutocorrect.Location = new System.Drawing.Point(9, 236);
            this.cbUseAutocorrect.Name = "cbUseAutocorrect";
            this.cbUseAutocorrect.Size = new System.Drawing.Size(121, 21);
            this.cbUseAutocorrect.TabIndex = 33;
            this.cbUseAutocorrect.Text = "Use A&utocorrect";
            this.ToolTip.SetToolTip(this.cbUseAutocorrect, "Automatic adjustment for data validation errors");
            this.cbUseAutocorrect.UseVisualStyleBackColor = true;
            // 
            // cbAttrEncrypted
            // 
            this.cbAttrEncrypted.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttrEncrypted.FormattingEnabled = true;
            this.cbAttrEncrypted.Items.AddRange(new object[] {
            "",
            "Set",
            "Clear"});
            this.cbAttrEncrypted.Location = new System.Drawing.Point(333, 203);
            this.cbAttrEncrypted.Margin = new System.Windows.Forms.Padding(5);
            this.cbAttrEncrypted.Name = "cbAttrEncrypted";
            this.cbAttrEncrypted.Size = new System.Drawing.Size(54, 25);
            this.cbAttrEncrypted.TabIndex = 32;
            this.ToolTip.SetToolTip(this.cbAttrEncrypted, "Check \'Encrypted\' attribute");
            // 
            // lblEncrypted
            // 
            this.lblEncrypted.AutoSize = true;
            this.lblEncrypted.Location = new System.Drawing.Point(267, 207);
            this.lblEncrypted.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblEncrypted.Name = "lblEncrypted";
            this.lblEncrypted.Size = new System.Drawing.Size(66, 17);
            this.lblEncrypted.TabIndex = 31;
            this.lblEncrypted.Text = "&Encrypted";
            this.lblEncrypted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbAttrCompressed
            // 
            this.cbAttrCompressed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttrCompressed.FormattingEnabled = true;
            this.cbAttrCompressed.Items.AddRange(new object[] {
            "",
            "Set",
            "Clear"});
            this.cbAttrCompressed.Location = new System.Drawing.Point(333, 169);
            this.cbAttrCompressed.Margin = new System.Windows.Forms.Padding(5);
            this.cbAttrCompressed.Name = "cbAttrCompressed";
            this.cbAttrCompressed.Size = new System.Drawing.Size(54, 25);
            this.cbAttrCompressed.TabIndex = 30;
            this.ToolTip.SetToolTip(this.cbAttrCompressed, "Check \'Compressed\' attribute");
            // 
            // lblCompressed
            // 
            this.lblCompressed.AutoSize = true;
            this.lblCompressed.Location = new System.Drawing.Point(251, 172);
            this.lblCompressed.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCompressed.Name = "lblCompressed";
            this.lblCompressed.Size = new System.Drawing.Size(82, 17);
            this.lblCompressed.TabIndex = 29;
            this.lblCompressed.Text = "C&ompressed";
            this.lblCompressed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // seFileSizeMax
            // 
            this.seFileSizeMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.seFileSizeMax.Location = new System.Drawing.Point(201, 133);
            this.seFileSizeMax.Margin = new System.Windows.Forms.Padding(4);
            this.seFileSizeMax.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFileSizeMax.Name = "seFileSizeMax";
            this.seFileSizeMax.Size = new System.Drawing.Size(108, 25);
            this.seFileSizeMax.TabIndex = 20;
            this.seFileSizeMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ToolTip.SetToolTip(this.seFileSizeMax, "Maximum File Size");
            // 
            // seFileSizeMin
            // 
            this.seFileSizeMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.seFileSizeMin.Location = new System.Drawing.Point(69, 133);
            this.seFileSizeMin.Margin = new System.Windows.Forms.Padding(4);
            this.seFileSizeMin.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFileSizeMin.Name = "seFileSizeMin";
            this.seFileSizeMin.Size = new System.Drawing.Size(108, 25);
            this.seFileSizeMin.TabIndex = 18;
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
            this.lblUtc.TabIndex = 3;
            this.lblUtc.Text = "UTC";
            this.lblUtc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToolTip.SetToolTip(this.lblUtc, "Use UTC Dates/Times");
            // 
            // cbAccessedUtc
            // 
            this.cbAccessedUtc.AutoSize = true;
            this.cbAccessedUtc.Location = new System.Drawing.Point(373, 104);
            this.cbAccessedUtc.Margin = new System.Windows.Forms.Padding(5);
            this.cbAccessedUtc.Name = "cbAccessedUtc";
            this.cbAccessedUtc.Size = new System.Drawing.Size(15, 14);
            this.cbAccessedUtc.TabIndex = 15;
            this.ToolTip.SetToolTip(this.cbAccessedUtc, "Use UTC Accessed Date/Time");
            this.cbAccessedUtc.UseVisualStyleBackColor = true;
            // 
            // cbModifiedUtc
            // 
            this.cbModifiedUtc.AutoSize = true;
            this.cbModifiedUtc.Location = new System.Drawing.Point(373, 69);
            this.cbModifiedUtc.Margin = new System.Windows.Forms.Padding(5);
            this.cbModifiedUtc.Name = "cbModifiedUtc";
            this.cbModifiedUtc.Size = new System.Drawing.Size(15, 14);
            this.cbModifiedUtc.TabIndex = 11;
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
            this.cbCreatedUtc.TabIndex = 7;
            this.ToolTip.SetToolTip(this.cbCreatedUtc, "Use UTC Created Date/Time");
            this.cbCreatedUtc.UseVisualStyleBackColor = true;
            // 
            // cbAttrArchive
            // 
            this.cbAttrArchive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttrArchive.FormattingEnabled = true;
            this.cbAttrArchive.Items.AddRange(new object[] {
            "",
            "Set",
            "Clear"});
            this.cbAttrArchive.Location = new System.Drawing.Point(184, 203);
            this.cbAttrArchive.Margin = new System.Windows.Forms.Padding(5);
            this.cbAttrArchive.Name = "cbAttrArchive";
            this.cbAttrArchive.Size = new System.Drawing.Size(54, 25);
            this.cbAttrArchive.TabIndex = 28;
            this.ToolTip.SetToolTip(this.cbAttrArchive, "Check \'Archive\' attribute");
            // 
            // cbAttrSystem
            // 
            this.cbAttrSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttrSystem.FormattingEnabled = true;
            this.cbAttrSystem.Items.AddRange(new object[] {
            "",
            "Set",
            "Clear"});
            this.cbAttrSystem.Location = new System.Drawing.Point(184, 169);
            this.cbAttrSystem.Margin = new System.Windows.Forms.Padding(5);
            this.cbAttrSystem.Name = "cbAttrSystem";
            this.cbAttrSystem.Size = new System.Drawing.Size(54, 25);
            this.cbAttrSystem.TabIndex = 26;
            this.ToolTip.SetToolTip(this.cbAttrSystem, "Check \'System\' attribute");
            // 
            // cbAttrHidden
            // 
            this.cbAttrHidden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttrHidden.FormattingEnabled = true;
            this.cbAttrHidden.Items.AddRange(new object[] {
            "",
            "Set",
            "Clear"});
            this.cbAttrHidden.Location = new System.Drawing.Point(69, 203);
            this.cbAttrHidden.Margin = new System.Windows.Forms.Padding(5);
            this.cbAttrHidden.Name = "cbAttrHidden";
            this.cbAttrHidden.Size = new System.Drawing.Size(54, 25);
            this.cbAttrHidden.TabIndex = 24;
            this.ToolTip.SetToolTip(this.cbAttrHidden, "Check \'Hidden\' attribute");
            // 
            // cbAttrReadOnly
            // 
            this.cbAttrReadOnly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttrReadOnly.FormattingEnabled = true;
            this.cbAttrReadOnly.Items.AddRange(new object[] {
            "",
            "Set",
            "Clear"});
            this.cbAttrReadOnly.Location = new System.Drawing.Point(69, 168);
            this.cbAttrReadOnly.Margin = new System.Windows.Forms.Padding(5);
            this.cbAttrReadOnly.Name = "cbAttrReadOnly";
            this.cbAttrReadOnly.Size = new System.Drawing.Size(54, 25);
            this.cbAttrReadOnly.TabIndex = 22;
            this.ToolTip.SetToolTip(this.cbAttrReadOnly, "Check \'Read-only\' attribute");
            // 
            // lblArchive
            // 
            this.lblArchive.AutoSize = true;
            this.lblArchive.Location = new System.Drawing.Point(135, 207);
            this.lblArchive.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblArchive.Name = "lblArchive";
            this.lblArchive.Size = new System.Drawing.Size(50, 17);
            this.lblArchive.TabIndex = 27;
            this.lblArchive.Text = "Archi&ve";
            this.lblArchive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSystem
            // 
            this.lblSystem.AutoSize = true;
            this.lblSystem.Location = new System.Drawing.Point(135, 172);
            this.lblSystem.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSystem.Name = "lblSystem";
            this.lblSystem.Size = new System.Drawing.Size(49, 17);
            this.lblSystem.TabIndex = 25;
            this.lblSystem.Text = "&System";
            this.lblSystem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHidden
            // 
            this.lblHidden.AutoSize = true;
            this.lblHidden.Location = new System.Drawing.Point(7, 207);
            this.lblHidden.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHidden.Name = "lblHidden";
            this.lblHidden.Size = new System.Drawing.Size(50, 17);
            this.lblHidden.TabIndex = 23;
            this.lblHidden.Text = "&Hidden";
            this.lblHidden.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblReadOnly
            // 
            this.lblReadOnly.AutoSize = true;
            this.lblReadOnly.Location = new System.Drawing.Point(6, 172);
            this.lblReadOnly.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblReadOnly.Name = "lblReadOnly";
            this.lblReadOnly.Size = new System.Drawing.Size(64, 17);
            this.lblReadOnly.TabIndex = 21;
            this.lblReadOnly.Text = "&ReadOnly";
            this.lblReadOnly.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 137);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "&File Size";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUpTo
            // 
            this.lblUpTo.AutoSize = true;
            this.lblUpTo.Location = new System.Drawing.Point(308, 6);
            this.lblUpTo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblUpTo.Name = "lblUpTo";
            this.lblUpTo.Size = new System.Drawing.Size(41, 17);
            this.lblUpTo.TabIndex = 2;
            this.lblUpTo.Text = "Up to";
            this.lblUpTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToolTip.SetToolTip(this.lblUpTo, "Latest Date/Time");
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(159, 6);
            this.lblFrom.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(38, 17);
            this.lblFrom.TabIndex = 1;
            this.lblFrom.Text = "From";
            this.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToolTip.SetToolTip(this.lblFrom, "Earliest Date/Time");
            // 
            // dtpAccessedMax
            // 
            this.dtpAccessedMax.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpAccessedMax.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAccessedMax.Location = new System.Drawing.Point(221, 98);
            this.dtpAccessedMax.Margin = new System.Windows.Forms.Padding(5);
            this.dtpAccessedMax.Name = "dtpAccessedMax";
            this.dtpAccessedMax.ShowCheckBox = true;
            this.dtpAccessedMax.Size = new System.Drawing.Size(128, 25);
            this.dtpAccessedMax.TabIndex = 14;
            this.ToolTip.SetToolTip(this.dtpAccessedMax, "Latest Accessed Date/Time");
            // 
            // dtpAccessedMin
            // 
            this.dtpAccessedMin.CustomFormat = "yyyy-MM-dd";
            this.dtpAccessedMin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAccessedMin.Location = new System.Drawing.Point(69, 98);
            this.dtpAccessedMin.Margin = new System.Windows.Forms.Padding(5);
            this.dtpAccessedMin.Name = "dtpAccessedMin";
            this.dtpAccessedMin.ShowCheckBox = true;
            this.dtpAccessedMin.Size = new System.Drawing.Size(128, 25);
            this.dtpAccessedMin.TabIndex = 13;
            this.ToolTip.SetToolTip(this.dtpAccessedMin, "Earliest Accessed Date/Time");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 102);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "&Accessed";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.label3, "Accessed Date/Time");
            // 
            // dtpModifiedMax
            // 
            this.dtpModifiedMax.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpModifiedMax.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpModifiedMax.Location = new System.Drawing.Point(221, 63);
            this.dtpModifiedMax.Margin = new System.Windows.Forms.Padding(5);
            this.dtpModifiedMax.Name = "dtpModifiedMax";
            this.dtpModifiedMax.ShowCheckBox = true;
            this.dtpModifiedMax.Size = new System.Drawing.Size(128, 25);
            this.dtpModifiedMax.TabIndex = 10;
            this.ToolTip.SetToolTip(this.dtpModifiedMax, "Latest Modified Date/Time");
            // 
            // dtpModifiedMin
            // 
            this.dtpModifiedMin.CustomFormat = "yyyy-MM-dd";
            this.dtpModifiedMin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpModifiedMin.Location = new System.Drawing.Point(69, 63);
            this.dtpModifiedMin.Margin = new System.Windows.Forms.Padding(5);
            this.dtpModifiedMin.Name = "dtpModifiedMin";
            this.dtpModifiedMin.ShowCheckBox = true;
            this.dtpModifiedMin.Size = new System.Drawing.Size(128, 25);
            this.dtpModifiedMin.TabIndex = 9;
            this.ToolTip.SetToolTip(this.dtpModifiedMin, "Earliest Modified Date/Time");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "&Modified";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.label2, "Modified Date/Time");
            // 
            // dtpCreatedMax
            // 
            this.dtpCreatedMax.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpCreatedMax.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCreatedMax.Location = new System.Drawing.Point(221, 28);
            this.dtpCreatedMax.Margin = new System.Windows.Forms.Padding(5);
            this.dtpCreatedMax.Name = "dtpCreatedMax";
            this.dtpCreatedMax.ShowCheckBox = true;
            this.dtpCreatedMax.Size = new System.Drawing.Size(128, 25);
            this.dtpCreatedMax.TabIndex = 6;
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
            this.dtpCreatedMin.TabIndex = 5;
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
            this.label1.TabIndex = 4;
            this.label1.Text = "&Created";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.label1, "Created Date/Time");
            // 
            // edConditions
            // 
            this.edConditions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.edConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edConditions.Location = new System.Drawing.Point(3, 21);
            this.edConditions.Multiline = true;
            this.edConditions.Name = "edConditions";
            this.edConditions.ReadOnly = true;
            this.edConditions.Size = new System.Drawing.Size(390, 136);
            this.edConditions.TabIndex = 0;
            this.edConditions.Text = "!ReadOnly, !Hidden, !System, !Archive, !Compressed, !Encrypted";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.edConditions);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 262);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 160);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conditions";
            // 
            // FileFilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FileFilterControl";
            this.Size = new System.Drawing.Size(396, 423);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seFileSizeMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFileSizeMin)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.ComboBox cbAttrEncrypted;
        public System.Windows.Forms.Label lblEncrypted;
        public System.Windows.Forms.ComboBox cbAttrCompressed;
        public System.Windows.Forms.Label lblCompressed;
        public System.Windows.Forms.NumericUpDown seFileSizeMax;
        public System.Windows.Forms.NumericUpDown seFileSizeMin;
        public System.Windows.Forms.Label lblUtc;
        public System.Windows.Forms.CheckBox cbAccessedUtc;
        public System.Windows.Forms.CheckBox cbModifiedUtc;
        public System.Windows.Forms.CheckBox cbCreatedUtc;
        public System.Windows.Forms.ComboBox cbAttrArchive;
        public System.Windows.Forms.ComboBox cbAttrSystem;
        public System.Windows.Forms.ComboBox cbAttrHidden;
        public System.Windows.Forms.ComboBox cbAttrReadOnly;
        public System.Windows.Forms.Label lblArchive;
        public System.Windows.Forms.Label lblSystem;
        public System.Windows.Forms.Label lblHidden;
        public System.Windows.Forms.Label lblReadOnly;
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
    }
}
