namespace TagScanner.Forms
{
    partial class MaskDialog
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Advanced Audio Coding (*.aac)");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Audio Interchange (*.aiff)");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Free Lossless Audio Codec (*.flac)");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Monkey\'s Audio (*.ape)");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("MPEG Audio Layer-3 (*.mp3)");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("MPEG-4 Audio (*.m4a)");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Ogg Vorbis (*.ogg)");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Real Audio (*.ra)");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Waveform Audio (*.wav)");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Windows Media Audio (*.wma)");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Audio Files", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Advanced Video Coding (*.avchd)");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Audio Video Interleave (*.avi)");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Flash (*.flv)");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Matroska Video (*.mkv)");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("MPEG-4 Part 14 (*.mp4)");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("QuickTime (*.mov)");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Web Media (*.webm)");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Windows Media Video (*.wmv)");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Video Files", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19});
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Adobe Illustrator Document (*.ai)");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Adobe Indesign Document (*.indd)");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Bitmap (*.bmp)");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Encapsulated Postscript (*.eps)");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Graphics Interchange Format (*.gif)");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Joint Photographic Experts Group (*.jpeg|*.jpg)");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Photoshop Document (*.psd)");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Portable Document Format (*.pdf)");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Portable Network Graphics (*.png)");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Raw Image Format (*.raw)");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Tagged Image File (*.tiff)");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Image Files", new System.Windows.Forms.TreeNode[] {
            treeNode21,
            treeNode22,
            treeNode23,
            treeNode24,
            treeNode25,
            treeNode26,
            treeNode27,
            treeNode28,
            treeNode29,
            treeNode30,
            treeNode31});
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Other Files");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("All Formats", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode20,
            treeNode32,
            treeNode33});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaskDialog));
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
            this.cbFileSizeMin = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbFileSizeMax = new System.Windows.Forms.CheckBox();
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
            this.TreeView = new System.Windows.Forms.TreeView();
            this.TreeViewStateImageList = new System.Windows.Forms.ImageList(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.seFileSizeMin = new System.Windows.Forms.NumericUpDown();
            this.seFileSizeMax = new System.Windows.Forms.NumericUpDown();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.seFileSizeMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFileSizeMax)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(331, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Created";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpCreatedMin
            // 
            this.dtpCreatedMin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreatedMin.Location = new System.Drawing.Point(424, 55);
            this.dtpCreatedMin.Margin = new System.Windows.Forms.Padding(4);
            this.dtpCreatedMin.Name = "dtpCreatedMin";
            this.dtpCreatedMin.Size = new System.Drawing.Size(105, 25);
            this.dtpCreatedMin.TabIndex = 1;
            this.ToolTip.SetToolTip(this.dtpCreatedMin, "Earliest Created Date");
            this.dtpCreatedMin.Value = new System.DateTime(2024, 9, 27, 21, 20, 0, 0);
            // 
            // dtpCreatedMax
            // 
            this.dtpCreatedMax.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreatedMax.Location = new System.Drawing.Point(560, 56);
            this.dtpCreatedMax.Margin = new System.Windows.Forms.Padding(4);
            this.dtpCreatedMax.Name = "dtpCreatedMax";
            this.dtpCreatedMax.Size = new System.Drawing.Size(104, 25);
            this.dtpCreatedMax.TabIndex = 3;
            this.ToolTip.SetToolTip(this.dtpCreatedMax, "Latest Created Date");
            // 
            // dtpModifiedMax
            // 
            this.dtpModifiedMax.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpModifiedMax.Location = new System.Drawing.Point(560, 90);
            this.dtpModifiedMax.Margin = new System.Windows.Forms.Padding(4);
            this.dtpModifiedMax.Name = "dtpModifiedMax";
            this.dtpModifiedMax.Size = new System.Drawing.Size(104, 25);
            this.dtpModifiedMax.TabIndex = 6;
            this.ToolTip.SetToolTip(this.dtpModifiedMax, "Latest Modified Date");
            // 
            // dtpModifiedMin
            // 
            this.dtpModifiedMin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpModifiedMin.Location = new System.Drawing.Point(425, 89);
            this.dtpModifiedMin.Margin = new System.Windows.Forms.Padding(4);
            this.dtpModifiedMin.Name = "dtpModifiedMin";
            this.dtpModifiedMin.Size = new System.Drawing.Size(104, 25);
            this.dtpModifiedMin.TabIndex = 5;
            this.ToolTip.SetToolTip(this.dtpModifiedMin, "Earliest Modified Date");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(331, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Modified";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpAccessedMax
            // 
            this.dtpAccessedMax.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAccessedMax.Location = new System.Drawing.Point(560, 121);
            this.dtpAccessedMax.Margin = new System.Windows.Forms.Padding(4);
            this.dtpAccessedMax.Name = "dtpAccessedMax";
            this.dtpAccessedMax.Size = new System.Drawing.Size(104, 25);
            this.dtpAccessedMax.TabIndex = 9;
            this.ToolTip.SetToolTip(this.dtpAccessedMax, "Latest Accessed Date");
            // 
            // dtpAccessedMin
            // 
            this.dtpAccessedMin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAccessedMin.Location = new System.Drawing.Point(425, 123);
            this.dtpAccessedMin.Margin = new System.Windows.Forms.Padding(4);
            this.dtpAccessedMin.Name = "dtpAccessedMin";
            this.dtpAccessedMin.Size = new System.Drawing.Size(104, 25);
            this.dtpAccessedMin.TabIndex = 8;
            this.ToolTip.SetToolTip(this.dtpAccessedMin, "Earliest Accessed Date");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(331, 126);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Accessed";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(388, 17);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 30);
            this.label4.TabIndex = 10;
            this.label4.Text = "From";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(520, 15);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 30);
            this.label5.TabIndex = 11;
            this.label5.Text = "Up to";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbFileSizeMin
            // 
            this.cbFileSizeMin.AutoSize = true;
            this.cbFileSizeMin.Location = new System.Drawing.Point(401, 163);
            this.cbFileSizeMin.Margin = new System.Windows.Forms.Padding(4);
            this.cbFileSizeMin.Name = "cbFileSizeMin";
            this.cbFileSizeMin.Size = new System.Drawing.Size(15, 14);
            this.cbFileSizeMin.TabIndex = 13;
            this.ToolTip.SetToolTip(this.cbFileSizeMin, "Use Minimum File Size");
            this.cbFileSizeMin.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(331, 160);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "File Size";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbFileSizeMax
            // 
            this.cbFileSizeMax.AutoSize = true;
            this.cbFileSizeMax.Location = new System.Drawing.Point(538, 161);
            this.cbFileSizeMax.Margin = new System.Windows.Forms.Padding(4);
            this.cbFileSizeMax.Name = "cbFileSizeMax";
            this.cbFileSizeMax.Size = new System.Drawing.Size(15, 14);
            this.cbFileSizeMax.TabIndex = 16;
            this.ToolTip.SetToolTip(this.cbFileSizeMax, "Use Maximum File Size");
            this.cbFileSizeMax.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(331, 197);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "Read-only";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(331, 233);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 17);
            this.label8.TabIndex = 24;
            this.label8.Text = "Hidden";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(490, 198);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 17);
            this.label9.TabIndex = 28;
            this.label9.Text = "System";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(490, 233);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 17);
            this.label10.TabIndex = 32;
            this.label10.Text = "Archive";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbAttrReadOnly
            // 
            this.cbAttrReadOnly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttrReadOnly.FormattingEnabled = true;
            this.cbAttrReadOnly.Items.AddRange(new object[] {
            "",
            "Set",
            "Clear"});
            this.cbAttrReadOnly.Location = new System.Drawing.Point(401, 193);
            this.cbAttrReadOnly.Margin = new System.Windows.Forms.Padding(4);
            this.cbAttrReadOnly.Name = "cbAttrReadOnly";
            this.cbAttrReadOnly.Size = new System.Drawing.Size(67, 25);
            this.cbAttrReadOnly.TabIndex = 33;
            this.ToolTip.SetToolTip(this.cbAttrReadOnly, "Check \'Read-only\' attribute");
            // 
            // cbAttrHidden
            // 
            this.cbAttrHidden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttrHidden.FormattingEnabled = true;
            this.cbAttrHidden.Items.AddRange(new object[] {
            "",
            "Set",
            "Clear"});
            this.cbAttrHidden.Location = new System.Drawing.Point(401, 229);
            this.cbAttrHidden.Margin = new System.Windows.Forms.Padding(4);
            this.cbAttrHidden.Name = "cbAttrHidden";
            this.cbAttrHidden.Size = new System.Drawing.Size(67, 25);
            this.cbAttrHidden.TabIndex = 34;
            this.ToolTip.SetToolTip(this.cbAttrHidden, "Check \'Hidden\' attribute");
            // 
            // cbAttrSystem
            // 
            this.cbAttrSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttrSystem.FormattingEnabled = true;
            this.cbAttrSystem.Items.AddRange(new object[] {
            "",
            "Set",
            "Clear"});
            this.cbAttrSystem.Location = new System.Drawing.Point(560, 194);
            this.cbAttrSystem.Margin = new System.Windows.Forms.Padding(4);
            this.cbAttrSystem.Name = "cbAttrSystem";
            this.cbAttrSystem.Size = new System.Drawing.Size(67, 25);
            this.cbAttrSystem.TabIndex = 35;
            this.ToolTip.SetToolTip(this.cbAttrSystem, "Check \'System\' attribute");
            // 
            // cbAttrArchive
            // 
            this.cbAttrArchive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttrArchive.FormattingEnabled = true;
            this.cbAttrArchive.Items.AddRange(new object[] {
            "",
            "Set",
            "Clear"});
            this.cbAttrArchive.Location = new System.Drawing.Point(560, 229);
            this.cbAttrArchive.Margin = new System.Windows.Forms.Padding(4);
            this.cbAttrArchive.Name = "cbAttrArchive";
            this.cbAttrArchive.Size = new System.Drawing.Size(67, 25);
            this.cbAttrArchive.TabIndex = 36;
            this.ToolTip.SetToolTip(this.cbAttrArchive, "Check \'Archive\' attribute");
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(503, 270);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 30);
            this.btnOK.TabIndex = 37;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(599, 270);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 30);
            this.btnCancel.TabIndex = 38;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(331, 17);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 30);
            this.label11.TabIndex = 39;
            this.label11.Text = "Date";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Visible = false;
            // 
            // cbCreatedUtc
            // 
            this.cbCreatedUtc.AutoSize = true;
            this.cbCreatedUtc.Location = new System.Drawing.Point(672, 61);
            this.cbCreatedUtc.Margin = new System.Windows.Forms.Padding(4);
            this.cbCreatedUtc.Name = "cbCreatedUtc";
            this.cbCreatedUtc.Size = new System.Drawing.Size(15, 14);
            this.cbCreatedUtc.TabIndex = 40;
            this.ToolTip.SetToolTip(this.cbCreatedUtc, "Use UTC Created Date");
            this.cbCreatedUtc.UseVisualStyleBackColor = true;
            // 
            // cbModifiedUtc
            // 
            this.cbModifiedUtc.AutoSize = true;
            this.cbModifiedUtc.Location = new System.Drawing.Point(672, 94);
            this.cbModifiedUtc.Margin = new System.Windows.Forms.Padding(4);
            this.cbModifiedUtc.Name = "cbModifiedUtc";
            this.cbModifiedUtc.Size = new System.Drawing.Size(15, 14);
            this.cbModifiedUtc.TabIndex = 41;
            this.ToolTip.SetToolTip(this.cbModifiedUtc, "Use UTC Modified Date");
            this.cbModifiedUtc.UseVisualStyleBackColor = true;
            // 
            // cbAccessedUtc
            // 
            this.cbAccessedUtc.AutoSize = true;
            this.cbAccessedUtc.Location = new System.Drawing.Point(672, 128);
            this.cbAccessedUtc.Margin = new System.Windows.Forms.Padding(4);
            this.cbAccessedUtc.Name = "cbAccessedUtc";
            this.cbAccessedUtc.Size = new System.Drawing.Size(15, 14);
            this.cbAccessedUtc.TabIndex = 42;
            this.ToolTip.SetToolTip(this.cbAccessedUtc, "Use UTC Accessed Date");
            this.cbAccessedUtc.UseVisualStyleBackColor = true;
            // 
            // cbCreatedMin
            // 
            this.cbCreatedMin.AutoSize = true;
            this.cbCreatedMin.Location = new System.Drawing.Point(401, 61);
            this.cbCreatedMin.Margin = new System.Windows.Forms.Padding(4);
            this.cbCreatedMin.Name = "cbCreatedMin";
            this.cbCreatedMin.Size = new System.Drawing.Size(15, 14);
            this.cbCreatedMin.TabIndex = 43;
            this.ToolTip.SetToolTip(this.cbCreatedMin, "Use Earliest Created Date");
            this.cbCreatedMin.UseVisualStyleBackColor = true;
            // 
            // cbModifiedMin
            // 
            this.cbModifiedMin.AutoSize = true;
            this.cbModifiedMin.Location = new System.Drawing.Point(401, 95);
            this.cbModifiedMin.Margin = new System.Windows.Forms.Padding(4);
            this.cbModifiedMin.Name = "cbModifiedMin";
            this.cbModifiedMin.Size = new System.Drawing.Size(15, 14);
            this.cbModifiedMin.TabIndex = 44;
            this.ToolTip.SetToolTip(this.cbModifiedMin, "Use Earliest Modified Date");
            this.cbModifiedMin.UseVisualStyleBackColor = true;
            // 
            // cbAccessedMin
            // 
            this.cbAccessedMin.AutoSize = true;
            this.cbAccessedMin.Location = new System.Drawing.Point(401, 129);
            this.cbAccessedMin.Margin = new System.Windows.Forms.Padding(4);
            this.cbAccessedMin.Name = "cbAccessedMin";
            this.cbAccessedMin.Size = new System.Drawing.Size(15, 14);
            this.cbAccessedMin.TabIndex = 45;
            this.ToolTip.SetToolTip(this.cbAccessedMin, "Use Earliest Accessed Date");
            this.cbAccessedMin.UseVisualStyleBackColor = true;
            // 
            // cbAccessedMax
            // 
            this.cbAccessedMax.AutoSize = true;
            this.cbAccessedMax.Location = new System.Drawing.Point(537, 128);
            this.cbAccessedMax.Margin = new System.Windows.Forms.Padding(4);
            this.cbAccessedMax.Name = "cbAccessedMax";
            this.cbAccessedMax.Size = new System.Drawing.Size(15, 14);
            this.cbAccessedMax.TabIndex = 48;
            this.ToolTip.SetToolTip(this.cbAccessedMax, "Use Latest Accessed Date");
            this.cbAccessedMax.UseVisualStyleBackColor = true;
            // 
            // cbModifiedMax
            // 
            this.cbModifiedMax.AutoSize = true;
            this.cbModifiedMax.Location = new System.Drawing.Point(537, 95);
            this.cbModifiedMax.Margin = new System.Windows.Forms.Padding(4);
            this.cbModifiedMax.Name = "cbModifiedMax";
            this.cbModifiedMax.Size = new System.Drawing.Size(15, 14);
            this.cbModifiedMax.TabIndex = 47;
            this.ToolTip.SetToolTip(this.cbModifiedMax, "Use Latest Modified Date");
            this.cbModifiedMax.UseVisualStyleBackColor = true;
            // 
            // cbCreatedMax
            // 
            this.cbCreatedMax.AutoSize = true;
            this.cbCreatedMax.Location = new System.Drawing.Point(537, 61);
            this.cbCreatedMax.Margin = new System.Windows.Forms.Padding(4);
            this.cbCreatedMax.Name = "cbCreatedMax";
            this.cbCreatedMax.Size = new System.Drawing.Size(15, 14);
            this.cbCreatedMax.TabIndex = 46;
            this.ToolTip.SetToolTip(this.cbCreatedMax, "Use Latest Created Date");
            this.cbCreatedMax.UseVisualStyleBackColor = true;
            // 
            // TreeView
            // 
            this.TreeView.Location = new System.Drawing.Point(13, 13);
            this.TreeView.Margin = new System.Windows.Forms.Padding(4);
            this.TreeView.Name = "TreeView";
            treeNode1.Name = "Node4";
            treeNode1.StateImageIndex = 0;
            treeNode1.Tag = "*.aac";
            treeNode1.Text = "Advanced Audio Coding (*.aac)";
            treeNode2.Name = "Node1";
            treeNode2.StateImageIndex = 0;
            treeNode2.Tag = "*.aiff";
            treeNode2.Text = "Audio Interchange (*.aiff)";
            treeNode3.Name = "Node2";
            treeNode3.StateImageIndex = 0;
            treeNode3.Tag = "*.flac";
            treeNode3.Text = "Free Lossless Audio Codec (*.flac)";
            treeNode4.Name = "Node5";
            treeNode4.StateImageIndex = 0;
            treeNode4.Tag = "*.ape";
            treeNode4.Text = "Monkey\'s Audio (*.ape)";
            treeNode5.Name = "Node4";
            treeNode5.StateImageIndex = 0;
            treeNode5.Tag = "*.mp3";
            treeNode5.Text = "MPEG Audio Layer-3 (*.mp3)";
            treeNode6.Name = "Node6";
            treeNode6.StateImageIndex = 0;
            treeNode6.Tag = "*.m4a";
            treeNode6.Text = "MPEG-4 Audio (*.m4a)";
            treeNode7.Name = "Node3";
            treeNode7.StateImageIndex = 0;
            treeNode7.Tag = "*.ogg";
            treeNode7.Text = "Ogg Vorbis (*.ogg)";
            treeNode8.Name = "Node6";
            treeNode8.StateImageIndex = 0;
            treeNode8.Tag = "*.ra";
            treeNode8.Text = "Real Audio (*.ra)";
            treeNode9.Name = "Node0";
            treeNode9.StateImageIndex = 0;
            treeNode9.Tag = "*.wav";
            treeNode9.Text = "Waveform Audio (*.wav)";
            treeNode10.Name = "Node5";
            treeNode10.StateImageIndex = 0;
            treeNode10.Tag = "*.wma";
            treeNode10.Text = "Windows Media Audio (*.wma)";
            treeNode11.Name = "Node0";
            treeNode11.StateImageIndex = 0;
            treeNode11.Text = "Audio Files";
            treeNode12.Name = "Node9";
            treeNode12.StateImageIndex = 0;
            treeNode12.Tag = "*.avchd";
            treeNode12.Text = "Advanced Video Coding (*.avchd)";
            treeNode13.Name = "Node7";
            treeNode13.StateImageIndex = 0;
            treeNode13.Tag = "*.avi";
            treeNode13.Text = "Audio Video Interleave (*.avi)";
            treeNode14.Name = "Node8";
            treeNode14.StateImageIndex = 0;
            treeNode14.Tag = "*.flv";
            treeNode14.Text = "Flash (*.flv)";
            treeNode15.Name = "Node11";
            treeNode15.StateImageIndex = 0;
            treeNode15.Tag = "*.mkv";
            treeNode15.Text = "Matroska Video (*.mkv)";
            treeNode16.Name = "Node8";
            treeNode16.StateImageIndex = 0;
            treeNode16.Tag = "*.mp4";
            treeNode16.Text = "MPEG-4 Part 14 (*.mp4)";
            treeNode17.Name = "Node7";
            treeNode17.StateImageIndex = 0;
            treeNode17.Tag = "*.mov";
            treeNode17.Text = "QuickTime (*.mov)";
            treeNode18.Name = "Node10";
            treeNode18.StateImageIndex = 0;
            treeNode18.Tag = "*.webm";
            treeNode18.Text = "Web Media (*.webm)";
            treeNode19.Name = "Node9";
            treeNode19.StateImageIndex = 0;
            treeNode19.Tag = "*.wmv";
            treeNode19.Text = "Windows Media Video (*.wmv)";
            treeNode20.Name = "Node1";
            treeNode20.StateImageIndex = 0;
            treeNode20.Text = "Video Files";
            treeNode21.Name = "Node15";
            treeNode21.StateImageIndex = 0;
            treeNode21.Tag = "*.ai";
            treeNode21.Text = "Adobe Illustrator Document (*.ai)";
            treeNode22.Name = "Node16";
            treeNode22.StateImageIndex = 0;
            treeNode22.Tag = "*.indd";
            treeNode22.Text = "Adobe Indesign Document (*.indd)";
            treeNode23.Name = "Node10";
            treeNode23.StateImageIndex = 0;
            treeNode23.Tag = "*.bmp";
            treeNode23.Text = "Bitmap (*.bmp)";
            treeNode24.Name = "Node14";
            treeNode24.StateImageIndex = 0;
            treeNode24.Tag = "*.eps";
            treeNode24.Text = "Encapsulated Postscript (*.eps)";
            treeNode25.Name = "Node11";
            treeNode25.StateImageIndex = 0;
            treeNode25.Tag = "*.gif";
            treeNode25.Text = "Graphics Interchange Format (*.gif)";
            treeNode26.Name = "Node12";
            treeNode26.StateImageIndex = 0;
            treeNode26.Tag = "*.jpeg|*.jpg";
            treeNode26.Text = "Joint Photographic Experts Group (*.jpeg|*.jpg)";
            treeNode27.Name = "Node12";
            treeNode27.StateImageIndex = 0;
            treeNode27.Tag = "*.psd";
            treeNode27.Text = "Photoshop Document (*.psd)";
            treeNode28.Name = "Node13";
            treeNode28.StateImageIndex = 0;
            treeNode28.Tag = "*.pdf";
            treeNode28.Text = "Portable Document Format (*.pdf)";
            treeNode29.Name = "Node14";
            treeNode29.StateImageIndex = 0;
            treeNode29.Tag = "*.png";
            treeNode29.Text = "Portable Network Graphics (*.png)";
            treeNode30.Name = "Node17";
            treeNode30.StateImageIndex = 0;
            treeNode30.Tag = "*.raw";
            treeNode30.Text = "Raw Image Format (*.raw)";
            treeNode31.Name = "Node13";
            treeNode31.StateImageIndex = 0;
            treeNode31.Tag = "*.tiff";
            treeNode31.Text = "Tagged Image File (*.tiff)";
            treeNode32.Name = "Node2";
            treeNode32.StateImageIndex = 0;
            treeNode32.Text = "Image Files";
            treeNode33.Name = "Node3";
            treeNode33.StateImageIndex = 0;
            treeNode33.Text = "Other Files";
            treeNode34.Name = "Node0";
            treeNode34.StateImageIndex = 0;
            treeNode34.Text = "All Formats";
            this.TreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode34});
            this.TreeView.Size = new System.Drawing.Size(310, 284);
            this.TreeView.StateImageList = this.TreeViewStateImageList;
            this.TreeView.TabIndex = 49;
            // 
            // TreeViewStateImageList
            // 
            this.TreeViewStateImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeViewStateImageList.ImageStream")));
            this.TreeViewStateImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.TreeViewStateImageList.Images.SetKeyName(0, "frClear.png");
            this.TreeViewStateImageList.Images.SetKeyName(1, "frApply.png");
            this.TreeViewStateImageList.Images.SetKeyName(2, "frPartial.png");
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(660, 15);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 30);
            this.label12.TabIndex = 50;
            this.label12.Text = "UTC?";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // seFileSizeMin
            // 
            this.seFileSizeMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.seFileSizeMin.Location = new System.Drawing.Point(425, 157);
            this.seFileSizeMin.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFileSizeMin.Name = "seFileSizeMin";
            this.seFileSizeMin.Size = new System.Drawing.Size(104, 25);
            this.seFileSizeMin.TabIndex = 51;
            this.seFileSizeMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ToolTip.SetToolTip(this.seFileSizeMin, "Minimum File Size");
            // 
            // seFileSizeMax
            // 
            this.seFileSizeMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.seFileSizeMax.Location = new System.Drawing.Point(560, 157);
            this.seFileSizeMax.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFileSizeMax.Name = "seFileSizeMax";
            this.seFileSizeMax.Size = new System.Drawing.Size(104, 25);
            this.seFileSizeMax.TabIndex = 52;
            this.seFileSizeMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ToolTip.SetToolTip(this.seFileSizeMax, "Maximum File Size");
            // 
            // MaskDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(704, 315);
            this.Controls.Add(this.seFileSizeMax);
            this.Controls.Add(this.seFileSizeMin);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.TreeView);
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
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbFileSizeMin);
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
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaskDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "File Mask Options";
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
        public System.Windows.Forms.CheckBox cbFileSizeMin;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.CheckBox cbFileSizeMax;
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
        public System.Windows.Forms.TreeView TreeView;
        public System.Windows.Forms.ImageList TreeViewStateImageList;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.NumericUpDown seFileSizeMin;
        public System.Windows.Forms.NumericUpDown seFileSizeMax;
        private System.Windows.Forms.ToolTip ToolTip;
    }
}