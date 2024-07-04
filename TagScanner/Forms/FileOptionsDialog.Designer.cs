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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileOptionsDialog));
            this.TreeView = new System.Windows.Forms.TreeView();
            this.PopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PopupAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeViewStateImageList = new System.Windows.Forms.ImageList(this.components);
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
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
            this.PopupMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seFileSizeMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFileSizeMin)).BeginInit();
            this.SuspendLayout();
            // 
            // TreeView
            // 
            this.TreeView.ContextMenuStrip = this.PopupMenu;
            this.TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeView.HideSelection = false;
            this.TreeView.Location = new System.Drawing.Point(0, 0);
            this.TreeView.Margin = new System.Windows.Forms.Padding(4);
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size(269, 255);
            this.TreeView.StateImageList = this.TreeViewStateImageList;
            this.TreeView.TabIndex = 0;
            // 
            // PopupMenu
            // 
            this.PopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PopupAdd,
            this.PopupEdit,
            this.PopupDelete});
            this.PopupMenu.Name = "PopupMenu";
            this.PopupMenu.Size = new System.Drawing.Size(132, 70);
            // 
            // PopupAdd
            // 
            this.PopupAdd.Name = "PopupAdd";
            this.PopupAdd.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.PopupAdd.Size = new System.Drawing.Size(131, 22);
            this.PopupAdd.Text = "&Add...";
            this.PopupAdd.ToolTipText = "Add a new File Format";
            // 
            // PopupEdit
            // 
            this.PopupEdit.Name = "PopupEdit";
            this.PopupEdit.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.PopupEdit.Size = new System.Drawing.Size(131, 22);
            this.PopupEdit.Text = "&Edit...";
            this.PopupEdit.ToolTipText = "Edit this File Format";
            // 
            // PopupDelete
            // 
            this.PopupDelete.Name = "PopupDelete";
            this.PopupDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.PopupDelete.Size = new System.Drawing.Size(131, 22);
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
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 255);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 36);
            this.panel1.TabIndex = 35;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(4, 4);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 27);
            this.btnAdd.TabIndex = 33;
            this.btnAdd.Text = "Add (Ins)";
            this.ToolTip.SetToolTip(this.btnAdd, "Add a new File Format");
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(96, 4);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(84, 27);
            this.btnEdit.TabIndex = 34;
            this.btnEdit.Text = "Edit (F2)";
            this.ToolTip.SetToolTip(this.btnEdit, "Edit the selected File Format");
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(188, 4);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 27);
            this.btnDelete.TabIndex = 35;
            this.btnDelete.Text = "Delete (Del)";
            this.ToolTip.SetToolTip(this.btnDelete, "Remove the selected File Format");
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(596, 4);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 27);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(504, 4);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 27);
            this.btnOK.TabIndex = 36;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
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
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(269, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(415, 255);
            this.panel2.TabIndex = 36;
            // 
            // seFileSizeMax
            // 
            this.seFileSizeMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.seFileSizeMax.Location = new System.Drawing.Point(254, 135);
            this.seFileSizeMax.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFileSizeMax.Name = "seFileSizeMax";
            this.seFileSizeMax.Size = new System.Drawing.Size(106, 25);
            this.seFileSizeMax.TabIndex = 50;
            this.seFileSizeMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ToolTip.SetToolTip(this.seFileSizeMax, "Maximum File Size");
            // 
            // seFileSizeMin
            // 
            this.seFileSizeMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.seFileSizeMin.Location = new System.Drawing.Point(100, 135);
            this.seFileSizeMin.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFileSizeMin.Name = "seFileSizeMin";
            this.seFileSizeMin.Size = new System.Drawing.Size(106, 25);
            this.seFileSizeMin.TabIndex = 48;
            this.seFileSizeMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ToolTip.SetToolTip(this.seFileSizeMin, "Minimum File Size");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(376, 8);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 17);
            this.label12.TabIndex = 33;
            this.label12.Text = "UTC?";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbAccessedUtc
            // 
            this.cbAccessedUtc.AutoSize = true;
            this.cbAccessedUtc.Location = new System.Drawing.Point(386, 105);
            this.cbAccessedUtc.Margin = new System.Windows.Forms.Padding(4);
            this.cbAccessedUtc.Name = "cbAccessedUtc";
            this.cbAccessedUtc.Size = new System.Drawing.Size(15, 14);
            this.cbAccessedUtc.TabIndex = 45;
            this.ToolTip.SetToolTip(this.cbAccessedUtc, "Use UTC Accessed Date");
            this.cbAccessedUtc.UseVisualStyleBackColor = true;
            // 
            // cbModifiedUtc
            // 
            this.cbModifiedUtc.AutoSize = true;
            this.cbModifiedUtc.Location = new System.Drawing.Point(386, 72);
            this.cbModifiedUtc.Margin = new System.Windows.Forms.Padding(4);
            this.cbModifiedUtc.Name = "cbModifiedUtc";
            this.cbModifiedUtc.Size = new System.Drawing.Size(15, 14);
            this.cbModifiedUtc.TabIndex = 41;
            this.ToolTip.SetToolTip(this.cbModifiedUtc, "Use UTC Modified Date");
            this.cbModifiedUtc.UseVisualStyleBackColor = true;
            // 
            // cbCreatedUtc
            // 
            this.cbCreatedUtc.AutoSize = true;
            this.cbCreatedUtc.Location = new System.Drawing.Point(386, 39);
            this.cbCreatedUtc.Margin = new System.Windows.Forms.Padding(4);
            this.cbCreatedUtc.Name = "cbCreatedUtc";
            this.cbCreatedUtc.Size = new System.Drawing.Size(15, 14);
            this.cbCreatedUtc.TabIndex = 37;
            this.ToolTip.SetToolTip(this.cbCreatedUtc, "Use UTC Created Date");
            this.cbCreatedUtc.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 8);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 17);
            this.label11.TabIndex = 30;
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
            this.cbAttrArchive.Location = new System.Drawing.Point(232, 207);
            this.cbAttrArchive.Margin = new System.Windows.Forms.Padding(4);
            this.cbAttrArchive.Name = "cbAttrArchive";
            this.cbAttrArchive.Size = new System.Drawing.Size(67, 25);
            this.cbAttrArchive.TabIndex = 58;
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
            this.cbAttrSystem.Location = new System.Drawing.Point(232, 172);
            this.cbAttrSystem.Margin = new System.Windows.Forms.Padding(4);
            this.cbAttrSystem.Name = "cbAttrSystem";
            this.cbAttrSystem.Size = new System.Drawing.Size(67, 25);
            this.cbAttrSystem.TabIndex = 54;
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
            this.cbAttrHidden.Location = new System.Drawing.Point(78, 207);
            this.cbAttrHidden.Margin = new System.Windows.Forms.Padding(4);
            this.cbAttrHidden.Name = "cbAttrHidden";
            this.cbAttrHidden.Size = new System.Drawing.Size(67, 25);
            this.cbAttrHidden.TabIndex = 56;
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
            this.cbAttrReadOnly.Location = new System.Drawing.Point(78, 171);
            this.cbAttrReadOnly.Margin = new System.Windows.Forms.Padding(4);
            this.cbAttrReadOnly.Name = "cbAttrReadOnly";
            this.cbAttrReadOnly.Size = new System.Drawing.Size(67, 25);
            this.cbAttrReadOnly.TabIndex = 52;
            this.ToolTip.SetToolTip(this.cbAttrReadOnly, "Check \'Read-only\' attribute");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(167, 211);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 17);
            this.label10.TabIndex = 57;
            this.label10.Text = "Archi&ve";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(167, 176);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 17);
            this.label9.TabIndex = 53;
            this.label9.Text = "&System";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 211);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 17);
            this.label8.TabIndex = 55;
            this.label8.Text = "&Hidden";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 175);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 17);
            this.label7.TabIndex = 51;
            this.label7.Text = "&Read-only";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbFileSizeMax
            // 
            this.cbFileSizeMax.AutoSize = true;
            this.cbFileSizeMax.Location = new System.Drawing.Point(232, 141);
            this.cbFileSizeMax.Margin = new System.Windows.Forms.Padding(4);
            this.cbFileSizeMax.Name = "cbFileSizeMax";
            this.cbFileSizeMax.Size = new System.Drawing.Size(15, 14);
            this.cbFileSizeMax.TabIndex = 49;
            this.ToolTip.SetToolTip(this.cbFileSizeMax, "Use Maximum File Size");
            this.cbFileSizeMax.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 138);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 17);
            this.label6.TabIndex = 46;
            this.label6.Text = "&File Size";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbFileSizeMin
            // 
            this.cbFileSizeMin.AutoSize = true;
            this.cbFileSizeMin.Location = new System.Drawing.Point(78, 141);
            this.cbFileSizeMin.Margin = new System.Windows.Forms.Padding(4);
            this.cbFileSizeMin.Name = "cbFileSizeMin";
            this.cbFileSizeMin.Size = new System.Drawing.Size(15, 14);
            this.cbFileSizeMin.TabIndex = 47;
            this.ToolTip.SetToolTip(this.cbFileSizeMin, "Use Minimum File Size");
            this.cbFileSizeMin.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(232, 8);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 17);
            this.label5.TabIndex = 32;
            this.label5.Text = "Up to";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(78, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 31;
            this.label4.Text = "From";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpAccessedMax
            // 
            this.dtpAccessedMax.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAccessedMax.Location = new System.Drawing.Point(232, 99);
            this.dtpAccessedMax.Margin = new System.Windows.Forms.Padding(4);
            this.dtpAccessedMax.Name = "dtpAccessedMax";
            this.dtpAccessedMax.ShowCheckBox = true;
            this.dtpAccessedMax.Size = new System.Drawing.Size(128, 25);
            this.dtpAccessedMax.TabIndex = 44;
            this.ToolTip.SetToolTip(this.dtpAccessedMax, "Latest Accessed Date");
            // 
            // dtpAccessedMin
            // 
            this.dtpAccessedMin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAccessedMin.Location = new System.Drawing.Point(78, 99);
            this.dtpAccessedMin.Margin = new System.Windows.Forms.Padding(4);
            this.dtpAccessedMin.Name = "dtpAccessedMin";
            this.dtpAccessedMin.ShowCheckBox = true;
            this.dtpAccessedMin.Size = new System.Drawing.Size(128, 25);
            this.dtpAccessedMin.TabIndex = 43;
            this.ToolTip.SetToolTip(this.dtpAccessedMin, "Earliest Accessed Date");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 103);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 42;
            this.label3.Text = "&Accessed";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpModifiedMax
            // 
            this.dtpModifiedMax.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpModifiedMax.Location = new System.Drawing.Point(232, 66);
            this.dtpModifiedMax.Margin = new System.Windows.Forms.Padding(4);
            this.dtpModifiedMax.Name = "dtpModifiedMax";
            this.dtpModifiedMax.ShowCheckBox = true;
            this.dtpModifiedMax.Size = new System.Drawing.Size(128, 25);
            this.dtpModifiedMax.TabIndex = 40;
            this.ToolTip.SetToolTip(this.dtpModifiedMax, "Latest Modified Date");
            // 
            // dtpModifiedMin
            // 
            this.dtpModifiedMin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpModifiedMin.Location = new System.Drawing.Point(78, 66);
            this.dtpModifiedMin.Margin = new System.Windows.Forms.Padding(4);
            this.dtpModifiedMin.Name = "dtpModifiedMin";
            this.dtpModifiedMin.ShowCheckBox = true;
            this.dtpModifiedMin.Size = new System.Drawing.Size(128, 25);
            this.dtpModifiedMin.TabIndex = 39;
            this.ToolTip.SetToolTip(this.dtpModifiedMin, "Earliest Modified Date");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 38;
            this.label2.Text = "&Modified";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpCreatedMax
            // 
            this.dtpCreatedMax.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreatedMax.Location = new System.Drawing.Point(232, 33);
            this.dtpCreatedMax.Margin = new System.Windows.Forms.Padding(4);
            this.dtpCreatedMax.Name = "dtpCreatedMax";
            this.dtpCreatedMax.ShowCheckBox = true;
            this.dtpCreatedMax.Size = new System.Drawing.Size(128, 25);
            this.dtpCreatedMax.TabIndex = 36;
            this.ToolTip.SetToolTip(this.dtpCreatedMax, "Latest Created Date");
            // 
            // dtpCreatedMin
            // 
            this.dtpCreatedMin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreatedMin.Location = new System.Drawing.Point(78, 33);
            this.dtpCreatedMin.Margin = new System.Windows.Forms.Padding(4);
            this.dtpCreatedMin.Name = "dtpCreatedMin";
            this.dtpCreatedMin.ShowCheckBox = true;
            this.dtpCreatedMin.Size = new System.Drawing.Size(128, 25);
            this.dtpCreatedMin.TabIndex = 35;
            this.ToolTip.SetToolTip(this.dtpCreatedMin, "Earliest Created Date");
            this.dtpCreatedMin.Value = new System.DateTime(2024, 9, 27, 21, 20, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 34;
            this.label1.Text = "&Created";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FileOptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 291);
            this.Controls.Add(this.TreeView);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 330);
            this.Name = "FileOptionsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "File Options";
            this.PopupMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seFileSizeMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFileSizeMin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TreeView TreeView;
        public System.Windows.Forms.ImageList TreeViewStateImageList;
        private System.Windows.Forms.ToolTip ToolTip;
        public System.Windows.Forms.ContextMenuStrip PopupMenu;
        public System.Windows.Forms.ToolStripMenuItem PopupAdd;
        public System.Windows.Forms.ToolStripMenuItem PopupEdit;
        public System.Windows.Forms.ToolStripMenuItem PopupDelete;
        public System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.Button btnEdit;
        public System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel2;
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