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
            this.panel2 = new System.Windows.Forms.Panel();
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
            this.lblDate = new System.Windows.Forms.Label();
            this.cbAttrArchive = new System.Windows.Forms.ComboBox();
            this.cbAttrSystem = new System.Windows.Forms.ComboBox();
            this.cbAttrHidden = new System.Windows.Forms.ComboBox();
            this.cbAttrReadOnly = new System.Windows.Forms.ComboBox();
            this.lblArchive = new System.Windows.Forms.Label();
            this.lblSystem = new System.Windows.Forms.Label();
            this.lblHidden = new System.Windows.Forms.Label();
            this.lblReadOnly = new System.Windows.Forms.Label();
            this.cbFileSizeMax = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbFileSizeMin = new System.Windows.Forms.CheckBox();
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
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seFileSizeMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFileSizeMin)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbUseAutocorrect);
            this.panel2.Controls.Add(this.cbAttrEncrypted);
            this.panel2.Controls.Add(this.lblEncrypted);
            this.panel2.Controls.Add(this.cbAttrCompressed);
            this.panel2.Controls.Add(this.lblCompressed);
            this.panel2.Controls.Add(this.seFileSizeMax);
            this.panel2.Controls.Add(this.seFileSizeMin);
            this.panel2.Controls.Add(this.lblUtc);
            this.panel2.Controls.Add(this.cbAccessedUtc);
            this.panel2.Controls.Add(this.cbModifiedUtc);
            this.panel2.Controls.Add(this.cbCreatedUtc);
            this.panel2.Controls.Add(this.lblDate);
            this.panel2.Controls.Add(this.cbAttrArchive);
            this.panel2.Controls.Add(this.cbAttrSystem);
            this.panel2.Controls.Add(this.cbAttrHidden);
            this.panel2.Controls.Add(this.cbAttrReadOnly);
            this.panel2.Controls.Add(this.lblArchive);
            this.panel2.Controls.Add(this.lblSystem);
            this.panel2.Controls.Add(this.lblHidden);
            this.panel2.Controls.Add(this.lblReadOnly);
            this.panel2.Controls.Add(this.cbFileSizeMax);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cbFileSizeMin);
            this.panel2.Controls.Add(this.lblUpTo);
            this.panel2.Controls.Add(this.lblFrom);
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
            this.panel2.Size = new System.Drawing.Size(500, 260);
            this.panel2.TabIndex = 0;
            // 
            // cbUseAutocorrect
            // 
            this.cbUseAutocorrect.AutoSize = true;
            this.cbUseAutocorrect.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbUseAutocorrect.Location = new System.Drawing.Point(202, 236);
            this.cbUseAutocorrect.Name = "cbUseAutocorrect";
            this.cbUseAutocorrect.Size = new System.Drawing.Size(290, 21);
            this.cbUseAutocorrect.TabIndex = 33;
            this.cbUseAutocorrect.Text = "&Use Autocorrect to fix data validation errors?";
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
            this.cbAttrEncrypted.Location = new System.Drawing.Point(432, 199);
            this.cbAttrEncrypted.Margin = new System.Windows.Forms.Padding(5);
            this.cbAttrEncrypted.Name = "cbAttrEncrypted";
            this.cbAttrEncrypted.Size = new System.Drawing.Size(60, 25);
            this.cbAttrEncrypted.TabIndex = 32;
            this.ToolTip.SetToolTip(this.cbAttrEncrypted, "Check \'Encrypted\' attribute");
            // 
            // lblEncrypted
            // 
            this.lblEncrypted.AutoSize = true;
            this.lblEncrypted.Location = new System.Drawing.Point(366, 203);
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
            this.cbAttrCompressed.Location = new System.Drawing.Point(432, 165);
            this.cbAttrCompressed.Margin = new System.Windows.Forms.Padding(5);
            this.cbAttrCompressed.Name = "cbAttrCompressed";
            this.cbAttrCompressed.Size = new System.Drawing.Size(60, 25);
            this.cbAttrCompressed.TabIndex = 30;
            this.ToolTip.SetToolTip(this.cbAttrCompressed, "Check \'Compressed\' attribute");
            // 
            // lblCompressed
            // 
            this.lblCompressed.AutoSize = true;
            this.lblCompressed.Location = new System.Drawing.Point(350, 168);
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
            this.seFileSizeMax.Enabled = false;
            this.seFileSizeMax.Location = new System.Drawing.Point(293, 129);
            this.seFileSizeMax.Margin = new System.Windows.Forms.Padding(4);
            this.seFileSizeMax.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFileSizeMax.Name = "seFileSizeMax";
            this.seFileSizeMax.Size = new System.Drawing.Size(160, 25);
            this.seFileSizeMax.TabIndex = 20;
            this.seFileSizeMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ToolTip.SetToolTip(this.seFileSizeMax, "Maximum File Size");
            // 
            // seFileSizeMin
            // 
            this.seFileSizeMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.seFileSizeMin.Enabled = false;
            this.seFileSizeMin.Location = new System.Drawing.Point(89, 129);
            this.seFileSizeMin.Margin = new System.Windows.Forms.Padding(4);
            this.seFileSizeMin.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFileSizeMin.Name = "seFileSizeMin";
            this.seFileSizeMin.Size = new System.Drawing.Size(160, 25);
            this.seFileSizeMin.TabIndex = 18;
            this.seFileSizeMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ToolTip.SetToolTip(this.seFileSizeMin, "Minimum File Size");
            // 
            // lblUtc
            // 
            this.lblUtc.AutoSize = true;
            this.lblUtc.Location = new System.Drawing.Point(469, 2);
            this.lblUtc.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblUtc.Name = "lblUtc";
            this.lblUtc.Size = new System.Drawing.Size(31, 17);
            this.lblUtc.TabIndex = 3;
            this.lblUtc.Text = "UTC";
            this.lblUtc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbAccessedUtc
            // 
            this.cbAccessedUtc.AutoSize = true;
            this.cbAccessedUtc.Location = new System.Drawing.Point(477, 100);
            this.cbAccessedUtc.Margin = new System.Windows.Forms.Padding(5);
            this.cbAccessedUtc.Name = "cbAccessedUtc";
            this.cbAccessedUtc.Size = new System.Drawing.Size(15, 14);
            this.cbAccessedUtc.TabIndex = 15;
            this.ToolTip.SetToolTip(this.cbAccessedUtc, "Use UTC Accessed Date");
            this.cbAccessedUtc.UseVisualStyleBackColor = true;
            // 
            // cbModifiedUtc
            // 
            this.cbModifiedUtc.AutoSize = true;
            this.cbModifiedUtc.Location = new System.Drawing.Point(477, 65);
            this.cbModifiedUtc.Margin = new System.Windows.Forms.Padding(5);
            this.cbModifiedUtc.Name = "cbModifiedUtc";
            this.cbModifiedUtc.Size = new System.Drawing.Size(15, 14);
            this.cbModifiedUtc.TabIndex = 11;
            this.ToolTip.SetToolTip(this.cbModifiedUtc, "Use UTC Modified Date");
            this.cbModifiedUtc.UseVisualStyleBackColor = true;
            // 
            // cbCreatedUtc
            // 
            this.cbCreatedUtc.AutoSize = true;
            this.cbCreatedUtc.Location = new System.Drawing.Point(477, 30);
            this.cbCreatedUtc.Margin = new System.Windows.Forms.Padding(5);
            this.cbCreatedUtc.Name = "cbCreatedUtc";
            this.cbCreatedUtc.Size = new System.Drawing.Size(15, 14);
            this.cbCreatedUtc.TabIndex = 7;
            this.ToolTip.SetToolTip(this.cbCreatedUtc, "Use UTC Created Date");
            this.cbCreatedUtc.UseVisualStyleBackColor = true;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(7, 2);
            this.lblDate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(35, 17);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Date";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbAttrArchive
            // 
            this.cbAttrArchive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttrArchive.FormattingEnabled = true;
            this.cbAttrArchive.Items.AddRange(new object[] {
            "",
            "Set",
            "Clear"});
            this.cbAttrArchive.Location = new System.Drawing.Point(234, 199);
            this.cbAttrArchive.Margin = new System.Windows.Forms.Padding(5);
            this.cbAttrArchive.Name = "cbAttrArchive";
            this.cbAttrArchive.Size = new System.Drawing.Size(60, 25);
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
            this.cbAttrSystem.Location = new System.Drawing.Point(234, 165);
            this.cbAttrSystem.Margin = new System.Windows.Forms.Padding(5);
            this.cbAttrSystem.Name = "cbAttrSystem";
            this.cbAttrSystem.Size = new System.Drawing.Size(60, 25);
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
            this.cbAttrHidden.Location = new System.Drawing.Point(69, 199);
            this.cbAttrHidden.Margin = new System.Windows.Forms.Padding(5);
            this.cbAttrHidden.Name = "cbAttrHidden";
            this.cbAttrHidden.Size = new System.Drawing.Size(60, 25);
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
            this.cbAttrReadOnly.Location = new System.Drawing.Point(69, 164);
            this.cbAttrReadOnly.Margin = new System.Windows.Forms.Padding(5);
            this.cbAttrReadOnly.Name = "cbAttrReadOnly";
            this.cbAttrReadOnly.Size = new System.Drawing.Size(60, 25);
            this.cbAttrReadOnly.TabIndex = 22;
            this.ToolTip.SetToolTip(this.cbAttrReadOnly, "Check \'Read-only\' attribute");
            // 
            // lblArchive
            // 
            this.lblArchive.AutoSize = true;
            this.lblArchive.Location = new System.Drawing.Point(185, 203);
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
            this.lblSystem.Location = new System.Drawing.Point(185, 168);
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
            this.lblHidden.Location = new System.Drawing.Point(7, 203);
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
            this.lblReadOnly.Location = new System.Drawing.Point(6, 168);
            this.lblReadOnly.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblReadOnly.Name = "lblReadOnly";
            this.lblReadOnly.Size = new System.Drawing.Size(62, 17);
            this.lblReadOnly.TabIndex = 21;
            this.lblReadOnly.Text = "&Readonly";
            this.lblReadOnly.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbFileSizeMax
            // 
            this.cbFileSizeMax.AutoSize = true;
            this.cbFileSizeMax.Location = new System.Drawing.Point(273, 135);
            this.cbFileSizeMax.Margin = new System.Windows.Forms.Padding(5);
            this.cbFileSizeMax.Name = "cbFileSizeMax";
            this.cbFileSizeMax.Size = new System.Drawing.Size(15, 14);
            this.cbFileSizeMax.TabIndex = 19;
            this.ToolTip.SetToolTip(this.cbFileSizeMax, "Use Maximum File Size");
            this.cbFileSizeMax.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 133);
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
            this.cbFileSizeMin.Location = new System.Drawing.Point(69, 136);
            this.cbFileSizeMin.Margin = new System.Windows.Forms.Padding(5);
            this.cbFileSizeMin.Name = "cbFileSizeMin";
            this.cbFileSizeMin.Size = new System.Drawing.Size(15, 14);
            this.cbFileSizeMin.TabIndex = 17;
            this.ToolTip.SetToolTip(this.cbFileSizeMin, "Use Minimum File Size");
            this.cbFileSizeMin.UseVisualStyleBackColor = true;
            // 
            // lblUpTo
            // 
            this.lblUpTo.AutoSize = true;
            this.lblUpTo.Location = new System.Drawing.Point(273, 2);
            this.lblUpTo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblUpTo.Name = "lblUpTo";
            this.lblUpTo.Size = new System.Drawing.Size(41, 17);
            this.lblUpTo.TabIndex = 2;
            this.lblUpTo.Text = "Up to";
            this.lblUpTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(69, 2);
            this.lblFrom.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(38, 17);
            this.lblFrom.TabIndex = 1;
            this.lblFrom.Text = "From";
            this.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpAccessedMax
            // 
            this.dtpAccessedMax.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpAccessedMax.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAccessedMax.Location = new System.Drawing.Point(273, 94);
            this.dtpAccessedMax.Margin = new System.Windows.Forms.Padding(5);
            this.dtpAccessedMax.Name = "dtpAccessedMax";
            this.dtpAccessedMax.ShowCheckBox = true;
            this.dtpAccessedMax.Size = new System.Drawing.Size(180, 25);
            this.dtpAccessedMax.TabIndex = 14;
            this.ToolTip.SetToolTip(this.dtpAccessedMax, "Latest Accessed Date");
            // 
            // dtpAccessedMin
            // 
            this.dtpAccessedMin.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpAccessedMin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAccessedMin.Location = new System.Drawing.Point(69, 94);
            this.dtpAccessedMin.Margin = new System.Windows.Forms.Padding(5);
            this.dtpAccessedMin.Name = "dtpAccessedMin";
            this.dtpAccessedMin.ShowCheckBox = true;
            this.dtpAccessedMin.Size = new System.Drawing.Size(180, 25);
            this.dtpAccessedMin.TabIndex = 13;
            this.ToolTip.SetToolTip(this.dtpAccessedMin, "Earliest Accessed Date");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "&Accessed";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpModifiedMax
            // 
            this.dtpModifiedMax.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpModifiedMax.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpModifiedMax.Location = new System.Drawing.Point(273, 59);
            this.dtpModifiedMax.Margin = new System.Windows.Forms.Padding(5);
            this.dtpModifiedMax.Name = "dtpModifiedMax";
            this.dtpModifiedMax.ShowCheckBox = true;
            this.dtpModifiedMax.Size = new System.Drawing.Size(180, 25);
            this.dtpModifiedMax.TabIndex = 10;
            this.ToolTip.SetToolTip(this.dtpModifiedMax, "Latest Modified Date");
            // 
            // dtpModifiedMin
            // 
            this.dtpModifiedMin.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpModifiedMin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpModifiedMin.Location = new System.Drawing.Point(69, 59);
            this.dtpModifiedMin.Margin = new System.Windows.Forms.Padding(5);
            this.dtpModifiedMin.Name = "dtpModifiedMin";
            this.dtpModifiedMin.ShowCheckBox = true;
            this.dtpModifiedMin.Size = new System.Drawing.Size(180, 25);
            this.dtpModifiedMin.TabIndex = 9;
            this.ToolTip.SetToolTip(this.dtpModifiedMin, "Earliest Modified Date");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "&Modified";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpCreatedMax
            // 
            this.dtpCreatedMax.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpCreatedMax.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCreatedMax.Location = new System.Drawing.Point(273, 24);
            this.dtpCreatedMax.Margin = new System.Windows.Forms.Padding(5);
            this.dtpCreatedMax.Name = "dtpCreatedMax";
            this.dtpCreatedMax.ShowCheckBox = true;
            this.dtpCreatedMax.Size = new System.Drawing.Size(180, 25);
            this.dtpCreatedMax.TabIndex = 6;
            this.ToolTip.SetToolTip(this.dtpCreatedMax, "Latest Created Date");
            // 
            // dtpCreatedMin
            // 
            this.dtpCreatedMin.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpCreatedMin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCreatedMin.Location = new System.Drawing.Point(69, 24);
            this.dtpCreatedMin.Margin = new System.Windows.Forms.Padding(5);
            this.dtpCreatedMin.Name = "dtpCreatedMin";
            this.dtpCreatedMin.ShowCheckBox = true;
            this.dtpCreatedMin.Size = new System.Drawing.Size(180, 25);
            this.dtpCreatedMin.TabIndex = 5;
            this.ToolTip.SetToolTip(this.dtpCreatedMin, "Earliest Created Date");
            this.dtpCreatedMin.Value = new System.DateTime(2024, 9, 27, 21, 20, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 28);
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
            this.Size = new System.Drawing.Size(500, 260);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seFileSizeMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFileSizeMin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
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
        public System.Windows.Forms.Label lblDate;
        public System.Windows.Forms.ComboBox cbAttrArchive;
        public System.Windows.Forms.ComboBox cbAttrSystem;
        public System.Windows.Forms.ComboBox cbAttrHidden;
        public System.Windows.Forms.ComboBox cbAttrReadOnly;
        public System.Windows.Forms.Label lblArchive;
        public System.Windows.Forms.Label lblSystem;
        public System.Windows.Forms.Label lblHidden;
        public System.Windows.Forms.Label lblReadOnly;
        public System.Windows.Forms.CheckBox cbFileSizeMax;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.CheckBox cbFileSizeMin;
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
        private System.Windows.Forms.ToolTip ToolTip;
        public System.Windows.Forms.CheckBox cbUseAutocorrect;
    }
}
