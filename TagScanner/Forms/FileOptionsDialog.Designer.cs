namespace TagScanner.Forms
{
    partial class FileOptionsDialog
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
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Audio Interchange (*.aif|*.aifc|*.aiff)");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("CD Audio Track (*.cda)");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Free Lossless Audio Codec (*.flac)");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Monkey\'s Audio (*.ape)");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("MPEG Audio Layer-3 (*.mp3)");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("MPEG-4 Audio (*.m4a)");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Musical Instrument Digital Interface (*.mid|*.midi|*.rmi)");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Ogg Vorbis (*.ogg)");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Real Audio (*.ra)");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Sun Microsystems & NeXT (*.au|*.snd)");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Waveform Audio (*.wav)");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Windows audio file (*.aac|*.adt|*.adts)");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Windows Media Audio (*.wma)");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Audio Files", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Advanced Video Coding (*.avchd)");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Audio Video Interleave (*.avi)");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Flash (*.flv)");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Indeo Video Technology (*.ivf)");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Matroska Video (*.mkv)");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("MPEG-4 Part 14 (*.mp4)");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("QuickTime (*.mov)");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Web Media (*.webm)");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Windows Media Video (*.wmv)");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Video Files", new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23,
            treeNode24});
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Adobe Illustrator Document (*.ai)");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Adobe Indesign Document (*.indd)");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Bitmap (*.bmp)");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Encapsulated Postscript (*.eps)");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Graphics Interchange Format (*.gif)");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Joint Photographic Experts Group (*.jpeg|*.jpg)");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Photoshop Document (*.psd)");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Portable Document Format (*.pdf)");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Portable Network Graphics (*.png)");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("Raw Image Format (*.raw)");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("Tagged Image File (*.tiff)");
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("Image Files", new System.Windows.Forms.TreeNode[] {
            treeNode26,
            treeNode27,
            treeNode28,
            treeNode29,
            treeNode30,
            treeNode31,
            treeNode32,
            treeNode33,
            treeNode34,
            treeNode35,
            treeNode36});
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("Other Files");
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("All Media", new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode25,
            treeNode37,
            treeNode38});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileOptionsDialog));
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
            this.TreeView = new System.Windows.Forms.TreeView();
            this.PopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PopupAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeViewStateImageList = new System.Windows.Forms.ImageList(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.seFileSizeMin = new System.Windows.Forms.NumericUpDown();
            this.seFileSizeMax = new System.Windows.Forms.NumericUpDown();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.PopupMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seFileSizeMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFileSizeMax)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(331, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Created";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpCreatedMin
            // 
            this.dtpCreatedMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpCreatedMin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreatedMin.Location = new System.Drawing.Point(402, 40);
            this.dtpCreatedMin.Margin = new System.Windows.Forms.Padding(4);
            this.dtpCreatedMin.Name = "dtpCreatedMin";
            this.dtpCreatedMin.ShowCheckBox = true;
            this.dtpCreatedMin.Size = new System.Drawing.Size(128, 25);
            this.dtpCreatedMin.TabIndex = 1;
            this.ToolTip.SetToolTip(this.dtpCreatedMin, "Earliest Created Date");
            this.dtpCreatedMin.Value = new System.DateTime(2024, 9, 27, 21, 20, 0, 0);
            // 
            // dtpCreatedMax
            // 
            this.dtpCreatedMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpCreatedMax.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreatedMax.Location = new System.Drawing.Point(538, 40);
            this.dtpCreatedMax.Margin = new System.Windows.Forms.Padding(4);
            this.dtpCreatedMax.Name = "dtpCreatedMax";
            this.dtpCreatedMax.ShowCheckBox = true;
            this.dtpCreatedMax.Size = new System.Drawing.Size(126, 25);
            this.dtpCreatedMax.TabIndex = 3;
            this.ToolTip.SetToolTip(this.dtpCreatedMax, "Latest Created Date");
            // 
            // dtpModifiedMax
            // 
            this.dtpModifiedMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpModifiedMax.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpModifiedMax.Location = new System.Drawing.Point(538, 73);
            this.dtpModifiedMax.Margin = new System.Windows.Forms.Padding(4);
            this.dtpModifiedMax.Name = "dtpModifiedMax";
            this.dtpModifiedMax.ShowCheckBox = true;
            this.dtpModifiedMax.Size = new System.Drawing.Size(126, 25);
            this.dtpModifiedMax.TabIndex = 6;
            this.ToolTip.SetToolTip(this.dtpModifiedMax, "Latest Modified Date");
            // 
            // dtpModifiedMin
            // 
            this.dtpModifiedMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpModifiedMin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpModifiedMin.Location = new System.Drawing.Point(402, 73);
            this.dtpModifiedMin.Margin = new System.Windows.Forms.Padding(4);
            this.dtpModifiedMin.Name = "dtpModifiedMin";
            this.dtpModifiedMin.ShowCheckBox = true;
            this.dtpModifiedMin.Size = new System.Drawing.Size(128, 25);
            this.dtpModifiedMin.TabIndex = 5;
            this.ToolTip.SetToolTip(this.dtpModifiedMin, "Earliest Modified Date");
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(331, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Modified";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpAccessedMax
            // 
            this.dtpAccessedMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpAccessedMax.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAccessedMax.Location = new System.Drawing.Point(538, 106);
            this.dtpAccessedMax.Margin = new System.Windows.Forms.Padding(4);
            this.dtpAccessedMax.Name = "dtpAccessedMax";
            this.dtpAccessedMax.ShowCheckBox = true;
            this.dtpAccessedMax.Size = new System.Drawing.Size(126, 25);
            this.dtpAccessedMax.TabIndex = 9;
            this.ToolTip.SetToolTip(this.dtpAccessedMax, "Latest Accessed Date");
            // 
            // dtpAccessedMin
            // 
            this.dtpAccessedMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpAccessedMin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAccessedMin.Location = new System.Drawing.Point(402, 106);
            this.dtpAccessedMin.Margin = new System.Windows.Forms.Padding(4);
            this.dtpAccessedMin.Name = "dtpAccessedMin";
            this.dtpAccessedMin.ShowCheckBox = true;
            this.dtpAccessedMin.Size = new System.Drawing.Size(128, 25);
            this.dtpAccessedMin.TabIndex = 8;
            this.ToolTip.SetToolTip(this.dtpAccessedMin, "Earliest Accessed Date");
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(331, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Accessed";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(399, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "From";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(536, 15);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Up to";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbFileSizeMin
            // 
            this.cbFileSizeMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFileSizeMin.AutoSize = true;
            this.cbFileSizeMin.Location = new System.Drawing.Point(402, 148);
            this.cbFileSizeMin.Margin = new System.Windows.Forms.Padding(4);
            this.cbFileSizeMin.Name = "cbFileSizeMin";
            this.cbFileSizeMin.Size = new System.Drawing.Size(15, 14);
            this.cbFileSizeMin.TabIndex = 13;
            this.ToolTip.SetToolTip(this.cbFileSizeMin, "Use Minimum File Size");
            this.cbFileSizeMin.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(332, 145);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "File Size";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbFileSizeMax
            // 
            this.cbFileSizeMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFileSizeMax.AutoSize = true;
            this.cbFileSizeMax.Location = new System.Drawing.Point(539, 146);
            this.cbFileSizeMax.Margin = new System.Windows.Forms.Padding(4);
            this.cbFileSizeMax.Name = "cbFileSizeMax";
            this.cbFileSizeMax.Size = new System.Drawing.Size(15, 14);
            this.cbFileSizeMax.TabIndex = 16;
            this.ToolTip.SetToolTip(this.cbFileSizeMax, "Use Maximum File Size");
            this.cbFileSizeMax.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(332, 182);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "Read-only";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(332, 218);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 17);
            this.label8.TabIndex = 24;
            this.label8.Text = "Hidden";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(491, 183);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 17);
            this.label9.TabIndex = 28;
            this.label9.Text = "System";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(491, 218);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 17);
            this.label10.TabIndex = 32;
            this.label10.Text = "Archive";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbAttrReadOnly
            // 
            this.cbAttrReadOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAttrReadOnly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttrReadOnly.FormattingEnabled = true;
            this.cbAttrReadOnly.Items.AddRange(new object[] {
            "",
            "Set",
            "Clear"});
            this.cbAttrReadOnly.Location = new System.Drawing.Point(402, 178);
            this.cbAttrReadOnly.Margin = new System.Windows.Forms.Padding(4);
            this.cbAttrReadOnly.Name = "cbAttrReadOnly";
            this.cbAttrReadOnly.Size = new System.Drawing.Size(67, 25);
            this.cbAttrReadOnly.TabIndex = 33;
            this.ToolTip.SetToolTip(this.cbAttrReadOnly, "Check \'Read-only\' attribute");
            // 
            // cbAttrHidden
            // 
            this.cbAttrHidden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAttrHidden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttrHidden.FormattingEnabled = true;
            this.cbAttrHidden.Items.AddRange(new object[] {
            "",
            "Set",
            "Clear"});
            this.cbAttrHidden.Location = new System.Drawing.Point(402, 214);
            this.cbAttrHidden.Margin = new System.Windows.Forms.Padding(4);
            this.cbAttrHidden.Name = "cbAttrHidden";
            this.cbAttrHidden.Size = new System.Drawing.Size(67, 25);
            this.cbAttrHidden.TabIndex = 34;
            this.ToolTip.SetToolTip(this.cbAttrHidden, "Check \'Hidden\' attribute");
            // 
            // cbAttrSystem
            // 
            this.cbAttrSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAttrSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttrSystem.FormattingEnabled = true;
            this.cbAttrSystem.Items.AddRange(new object[] {
            "",
            "Set",
            "Clear"});
            this.cbAttrSystem.Location = new System.Drawing.Point(561, 179);
            this.cbAttrSystem.Margin = new System.Windows.Forms.Padding(4);
            this.cbAttrSystem.Name = "cbAttrSystem";
            this.cbAttrSystem.Size = new System.Drawing.Size(67, 25);
            this.cbAttrSystem.TabIndex = 35;
            this.ToolTip.SetToolTip(this.cbAttrSystem, "Check \'System\' attribute");
            // 
            // cbAttrArchive
            // 
            this.cbAttrArchive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAttrArchive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttrArchive.FormattingEnabled = true;
            this.cbAttrArchive.Items.AddRange(new object[] {
            "",
            "Set",
            "Clear"});
            this.cbAttrArchive.Location = new System.Drawing.Point(561, 214);
            this.cbAttrArchive.Margin = new System.Windows.Forms.Padding(4);
            this.cbAttrArchive.Name = "cbAttrArchive";
            this.cbAttrArchive.Size = new System.Drawing.Size(67, 25);
            this.cbAttrArchive.TabIndex = 36;
            this.ToolTip.SetToolTip(this.cbAttrArchive, "Check \'Archive\' attribute");
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(555, 251);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(64, 27);
            this.btnOK.TabIndex = 37;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(627, 251);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 27);
            this.btnCancel.TabIndex = 38;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(332, 15);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 17);
            this.label11.TabIndex = 39;
            this.label11.Text = "Date";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Visible = false;
            // 
            // cbCreatedUtc
            // 
            this.cbCreatedUtc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCreatedUtc.AutoSize = true;
            this.cbCreatedUtc.Location = new System.Drawing.Point(672, 46);
            this.cbCreatedUtc.Margin = new System.Windows.Forms.Padding(4);
            this.cbCreatedUtc.Name = "cbCreatedUtc";
            this.cbCreatedUtc.Size = new System.Drawing.Size(15, 14);
            this.cbCreatedUtc.TabIndex = 40;
            this.ToolTip.SetToolTip(this.cbCreatedUtc, "Use UTC Created Date");
            this.cbCreatedUtc.UseVisualStyleBackColor = true;
            // 
            // cbModifiedUtc
            // 
            this.cbModifiedUtc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbModifiedUtc.AutoSize = true;
            this.cbModifiedUtc.Location = new System.Drawing.Point(672, 79);
            this.cbModifiedUtc.Margin = new System.Windows.Forms.Padding(4);
            this.cbModifiedUtc.Name = "cbModifiedUtc";
            this.cbModifiedUtc.Size = new System.Drawing.Size(15, 14);
            this.cbModifiedUtc.TabIndex = 41;
            this.ToolTip.SetToolTip(this.cbModifiedUtc, "Use UTC Modified Date");
            this.cbModifiedUtc.UseVisualStyleBackColor = true;
            // 
            // cbAccessedUtc
            // 
            this.cbAccessedUtc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAccessedUtc.AutoSize = true;
            this.cbAccessedUtc.Location = new System.Drawing.Point(672, 112);
            this.cbAccessedUtc.Margin = new System.Windows.Forms.Padding(4);
            this.cbAccessedUtc.Name = "cbAccessedUtc";
            this.cbAccessedUtc.Size = new System.Drawing.Size(15, 14);
            this.cbAccessedUtc.TabIndex = 42;
            this.ToolTip.SetToolTip(this.cbAccessedUtc, "Use UTC Accessed Date");
            this.cbAccessedUtc.UseVisualStyleBackColor = true;
            // 
            // TreeView
            // 
            this.TreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeView.ContextMenuStrip = this.PopupMenu;
            this.TreeView.HideSelection = false;
            this.TreeView.Location = new System.Drawing.Point(13, 13);
            this.TreeView.Margin = new System.Windows.Forms.Padding(4);
            this.TreeView.Name = "TreeView";
            treeNode1.Name = "Node1";
            treeNode1.StateImageIndex = 0;
            treeNode1.Tag = "*.aac";
            treeNode1.Text = "Advanced Audio Coding (*.aac)";
            treeNode2.Name = "Node2";
            treeNode2.StateImageIndex = 0;
            treeNode2.Tag = "*.aif|*.aifc|*.aiff";
            treeNode2.Text = "Audio Interchange (*.aif|*.aifc|*.aiff)";
            treeNode3.Name = "Node2";
            treeNode3.StateImageIndex = 0;
            treeNode3.Tag = "*.cda";
            treeNode3.Text = "CD Audio Track (*.cda)";
            treeNode4.Name = "Node3";
            treeNode4.StateImageIndex = 0;
            treeNode4.Tag = "*.flac";
            treeNode4.Text = "Free Lossless Audio Codec (*.flac)";
            treeNode5.Name = "Node4";
            treeNode5.StateImageIndex = 0;
            treeNode5.Tag = "*.ape";
            treeNode5.Text = "Monkey\'s Audio (*.ape)";
            treeNode6.Name = "Node5";
            treeNode6.StateImageIndex = 0;
            treeNode6.Tag = "*.mp3";
            treeNode6.Text = "MPEG Audio Layer-3 (*.mp3)";
            treeNode7.Name = "Node6";
            treeNode7.StateImageIndex = 0;
            treeNode7.Tag = "*.m4a";
            treeNode7.Text = "MPEG-4 Audio (*.m4a)";
            treeNode8.Name = "Node0";
            treeNode8.StateImageIndex = 0;
            treeNode8.Tag = "*.mid|*.midi|*.rmi";
            treeNode8.Text = "Musical Instrument Digital Interface (*.mid|*.midi|*.rmi)";
            treeNode9.Name = "Node7";
            treeNode9.StateImageIndex = 0;
            treeNode9.Tag = "*.ogg";
            treeNode9.Text = "Ogg Vorbis (*.ogg)";
            treeNode10.Name = "Node8";
            treeNode10.StateImageIndex = 0;
            treeNode10.Tag = "*.ra";
            treeNode10.Text = "Real Audio (*.ra)";
            treeNode11.Name = "Node1";
            treeNode11.StateImageIndex = 0;
            treeNode11.Tag = "*.au|*.snd";
            treeNode11.Text = "Sun Microsystems & NeXT (*.au|*.snd)";
            treeNode12.Name = "Node9";
            treeNode12.StateImageIndex = 0;
            treeNode12.Tag = "*.wav";
            treeNode12.Text = "Waveform Audio (*.wav)";
            treeNode13.Name = "Node3";
            treeNode13.StateImageIndex = 0;
            treeNode13.Tag = "*.aac|*.adt|*.adts";
            treeNode13.Text = "Windows audio file (*.aac|*.adt|*.adts)";
            treeNode14.Name = "Node10";
            treeNode14.StateImageIndex = 0;
            treeNode14.Tag = "*.wma";
            treeNode14.Text = "Windows Media Audio (*.wma)";
            treeNode15.Name = "Node11";
            treeNode15.StateImageIndex = 0;
            treeNode15.Text = "Audio Files";
            treeNode16.Name = "Node12";
            treeNode16.StateImageIndex = 0;
            treeNode16.Tag = "*.avchd";
            treeNode16.Text = "Advanced Video Coding (*.avchd)";
            treeNode17.Name = "Node13";
            treeNode17.StateImageIndex = 0;
            treeNode17.Tag = "*.avi";
            treeNode17.Text = "Audio Video Interleave (*.avi)";
            treeNode18.Name = "Node14";
            treeNode18.StateImageIndex = 0;
            treeNode18.Tag = "*.flv";
            treeNode18.Text = "Flash (*.flv)";
            treeNode19.Name = "Node4";
            treeNode19.StateImageIndex = 0;
            treeNode19.Tag = "*.ivf";
            treeNode19.Text = "Indeo Video Technology (*.ivf)";
            treeNode20.Name = "Node15";
            treeNode20.StateImageIndex = 0;
            treeNode20.Tag = "*.mkv";
            treeNode20.Text = "Matroska Video (*.mkv)";
            treeNode21.Name = "Node16";
            treeNode21.StateImageIndex = 0;
            treeNode21.Tag = "*.mp4";
            treeNode21.Text = "MPEG-4 Part 14 (*.mp4)";
            treeNode22.Name = "Node17";
            treeNode22.StateImageIndex = 0;
            treeNode22.Tag = "*.mov";
            treeNode22.Text = "QuickTime (*.mov)";
            treeNode23.Name = "Node18";
            treeNode23.StateImageIndex = 0;
            treeNode23.Tag = "*.webm";
            treeNode23.Text = "Web Media (*.webm)";
            treeNode24.Name = "Node19";
            treeNode24.StateImageIndex = 0;
            treeNode24.Tag = "*.wmv";
            treeNode24.Text = "Windows Media Video (*.wmv)";
            treeNode25.Name = "Node20";
            treeNode25.StateImageIndex = 0;
            treeNode25.Text = "Video Files";
            treeNode26.Name = "Node21";
            treeNode26.StateImageIndex = 0;
            treeNode26.Tag = "*.ai";
            treeNode26.Text = "Adobe Illustrator Document (*.ai)";
            treeNode27.Name = "Node22";
            treeNode27.StateImageIndex = 0;
            treeNode27.Tag = "*.indd";
            treeNode27.Text = "Adobe Indesign Document (*.indd)";
            treeNode28.Name = "Node23";
            treeNode28.StateImageIndex = 0;
            treeNode28.Tag = "*.bmp";
            treeNode28.Text = "Bitmap (*.bmp)";
            treeNode29.Name = "Node24";
            treeNode29.StateImageIndex = 0;
            treeNode29.Tag = "*.eps";
            treeNode29.Text = "Encapsulated Postscript (*.eps)";
            treeNode30.Name = "Node25";
            treeNode30.StateImageIndex = 0;
            treeNode30.Tag = "*.gif";
            treeNode30.Text = "Graphics Interchange Format (*.gif)";
            treeNode31.Name = "Node26";
            treeNode31.StateImageIndex = 0;
            treeNode31.Tag = "*.jpeg|*.jpg";
            treeNode31.Text = "Joint Photographic Experts Group (*.jpeg|*.jpg)";
            treeNode32.Name = "Node27";
            treeNode32.StateImageIndex = 0;
            treeNode32.Tag = "*.psd";
            treeNode32.Text = "Photoshop Document (*.psd)";
            treeNode33.Name = "Node28";
            treeNode33.StateImageIndex = 0;
            treeNode33.Tag = "*.pdf";
            treeNode33.Text = "Portable Document Format (*.pdf)";
            treeNode34.Name = "Node29";
            treeNode34.StateImageIndex = 0;
            treeNode34.Tag = "*.png";
            treeNode34.Text = "Portable Network Graphics (*.png)";
            treeNode35.Name = "Node30";
            treeNode35.StateImageIndex = 0;
            treeNode35.Tag = "*.raw";
            treeNode35.Text = "Raw Image Format (*.raw)";
            treeNode36.Name = "Node31";
            treeNode36.StateImageIndex = 0;
            treeNode36.Tag = "*.tiff";
            treeNode36.Text = "Tagged Image File (*.tiff)";
            treeNode37.Name = "Node32";
            treeNode37.StateImageIndex = 0;
            treeNode37.Text = "Image Files";
            treeNode38.Name = "Node33";
            treeNode38.StateImageIndex = 0;
            treeNode38.Text = "Other Files";
            treeNode39.Name = "Node34";
            treeNode39.StateImageIndex = 0;
            treeNode39.Text = "All Media";
            this.TreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode39});
            this.TreeView.Size = new System.Drawing.Size(310, 265);
            this.TreeView.StateImageList = this.TreeViewStateImageList;
            this.TreeView.TabIndex = 49;
            // 
            // PopupMenu
            // 
            this.PopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PopupAdd,
            this.PopupEdit,
            this.PopupDelete});
            this.PopupMenu.Name = "PopupMenu";
            this.PopupMenu.Size = new System.Drawing.Size(108, 70);
            // 
            // PopupAdd
            // 
            this.PopupAdd.Name = "PopupAdd";
            this.PopupAdd.Size = new System.Drawing.Size(107, 22);
            this.PopupAdd.Text = "&Add...";
            this.PopupAdd.ToolTipText = "Add a new File Format";
            // 
            // PopupEdit
            // 
            this.PopupEdit.Name = "PopupEdit";
            this.PopupEdit.Size = new System.Drawing.Size(107, 22);
            this.PopupEdit.Text = "&Edit...";
            this.PopupEdit.ToolTipText = "Edit this File Format";
            // 
            // PopupDelete
            // 
            this.PopupDelete.Name = "PopupDelete";
            this.PopupDelete.Size = new System.Drawing.Size(107, 22);
            this.PopupDelete.Text = "&Delete";
            this.PopupDelete.ToolTipText = "Remove this File Format";
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
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(662, 15);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 17);
            this.label12.TabIndex = 50;
            this.label12.Text = "UTC?";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // seFileSizeMin
            // 
            this.seFileSizeMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.seFileSizeMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.seFileSizeMin.Location = new System.Drawing.Point(426, 142);
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
            this.seFileSizeMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.seFileSizeMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.seFileSizeMax.Location = new System.Drawing.Point(561, 142);
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
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(483, 251);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(64, 27);
            this.btnDelete.TabIndex = 53;
            this.btnDelete.Text = "Delete";
            this.ToolTip.SetToolTip(this.btnDelete, "Remove the selected File Format");
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(415, 251);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(60, 27);
            this.btnEdit.TabIndex = 54;
            this.btnEdit.Text = "Edit...";
            this.ToolTip.SetToolTip(this.btnEdit, "Edit the selected File Format");
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(347, 251);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 27);
            this.btnAdd.TabIndex = 55;
            this.btnAdd.Text = "Add...";
            this.ToolTip.SetToolTip(this.btnAdd, "Add a new File Format");
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // FileOptionsDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(704, 291);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.seFileSizeMax);
            this.Controls.Add(this.seFileSizeMin);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.TreeView);
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(720, 330);
            this.Name = "FileOptionsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "File Options";
            this.PopupMenu.ResumeLayout(false);
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
        public System.Windows.Forms.TreeView TreeView;
        public System.Windows.Forms.ImageList TreeViewStateImageList;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.NumericUpDown seFileSizeMin;
        public System.Windows.Forms.NumericUpDown seFileSizeMax;
        private System.Windows.Forms.ToolTip ToolTip;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.Button btnEdit;
        public System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.ContextMenuStrip PopupMenu;
        public System.Windows.Forms.ToolStripMenuItem PopupAdd;
        public System.Windows.Forms.ToolStripMenuItem PopupEdit;
        public System.Windows.Forms.ToolStripMenuItem PopupDelete;
    }
}