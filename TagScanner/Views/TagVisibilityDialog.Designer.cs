namespace TagScanner.Views
{
	partial class TagVisibilityDialog
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
            this.ListView = new System.Windows.Forms.ListView();
            this.chTagName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDataType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chWritable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.ListMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ListAlphabetically = new System.Windows.Forms.ToolStripMenuItem();
            this.ListByCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.ListByDataType = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ListNamesOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeByCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeByDataType = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeNamesOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListView
            // 
            this.ListView.AllowColumnReorder = true;
            this.ListView.AllowDrop = true;
            this.ListView.CheckBoxes = true;
            this.ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTagName,
            this.chCategory,
            this.chDataType,
            this.chWritable});
            this.ListView.FullRowSelect = true;
            this.ListView.HideSelection = false;
            this.ListView.Location = new System.Drawing.Point(13, 28);
            this.ListView.Margin = new System.Windows.Forms.Padding(4);
            this.ListView.Name = "ListView";
            this.ListView.ShowItemToolTips = true;
            this.ListView.Size = new System.Drawing.Size(152, 120);
            this.ListView.TabIndex = 2;
            this.ListView.UseCompatibleStateImageBehavior = false;
            this.ListView.View = System.Windows.Forms.View.List;
            // 
            // chTagName
            // 
            this.chTagName.Text = "Tag Name";
            this.chTagName.Width = 200;
            // 
            // chCategory
            // 
            this.chCategory.Text = "Category";
            this.chCategory.Width = 100;
            // 
            // chDataType
            // 
            this.chDataType.Text = "Data Type";
            this.chDataType.Width = 100;
            // 
            // chWritable
            // 
            this.chWritable.Text = "Writable?";
            this.chWritable.Width = 80;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 390);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 51);
            this.panel1.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(522, 9);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 30);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(428, 9);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 30);
            this.btnOK.TabIndex = 19;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ListMenu,
            this.TreeMenu});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(624, 24);
            this.MainMenu.TabIndex = 4;
            this.MainMenu.Text = "menuStrip1";
            // 
            // ListMenu
            // 
            this.ListMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ListAlphabetically,
            this.ListByCategory,
            this.ListByDataType,
            this.toolStripMenuItem2,
            this.ListNamesOnly});
            this.ListMenu.Name = "ListMenu";
            this.ListMenu.Size = new System.Drawing.Size(37, 20);
            this.ListMenu.Text = "&List";
            // 
            // ListAlphabetically
            // 
            this.ListAlphabetically.Name = "ListAlphabetically";
            this.ListAlphabetically.Size = new System.Drawing.Size(180, 22);
            this.ListAlphabetically.Text = "&Alphabetically";
            // 
            // ListByCategory
            // 
            this.ListByCategory.Name = "ListByCategory";
            this.ListByCategory.Size = new System.Drawing.Size(180, 22);
            this.ListByCategory.Text = "by &Category";
            // 
            // ListByDataType
            // 
            this.ListByDataType.Name = "ListByDataType";
            this.ListByDataType.Size = new System.Drawing.Size(180, 22);
            this.ListByDataType.Text = "by &Data Type";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // ListNamesOnly
            // 
            this.ListNamesOnly.Name = "ListNamesOnly";
            this.ListNamesOnly.Size = new System.Drawing.Size(180, 22);
            this.ListNamesOnly.Text = "&Names only";
            // 
            // TreeMenu
            // 
            this.TreeMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TreeByCategory,
            this.TreeByDataType,
            this.toolStripMenuItem1,
            this.TreeNamesOnly});
            this.TreeMenu.Name = "TreeMenu";
            this.TreeMenu.Size = new System.Drawing.Size(40, 20);
            this.TreeMenu.Text = "&Tree";
            // 
            // TreeByCategory
            // 
            this.TreeByCategory.Name = "TreeByCategory";
            this.TreeByCategory.Size = new System.Drawing.Size(180, 22);
            this.TreeByCategory.Text = "by &Category";
            // 
            // TreeByDataType
            // 
            this.TreeByDataType.Name = "TreeByDataType";
            this.TreeByDataType.Size = new System.Drawing.Size(180, 22);
            this.TreeByDataType.Text = "by &Data Type";
            // 
            // TreeNamesOnly
            // 
            this.TreeNamesOnly.Name = "TreeNamesOnly";
            this.TreeNamesOnly.Size = new System.Drawing.Size(180, 22);
            this.TreeNamesOnly.Text = "&Names only";
            // 
            // TreeView
            // 
            this.TreeView.CheckBoxes = true;
            this.TreeView.Location = new System.Drawing.Point(172, 28);
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size(152, 121);
            this.TreeView.TabIndex = 5;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // TagVisibilityDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.ListView);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TreeView);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "TagVisibilityDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Visible Tags";
            this.panel1.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.ListView ListView;
        public System.Windows.Forms.ColumnHeader chTagName;
        public System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.Button btnCancel;
		public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.ColumnHeader chDataType;
        public System.Windows.Forms.ColumnHeader chCategory;
        public System.Windows.Forms.ColumnHeader chWritable;
        public System.Windows.Forms.MenuStrip MainMenu;
        public System.Windows.Forms.TreeView TreeView;
        public System.Windows.Forms.ToolStripMenuItem ListMenu;
        public System.Windows.Forms.ToolStripMenuItem ListAlphabetically;
        public System.Windows.Forms.ToolStripMenuItem ListByCategory;
        public System.Windows.Forms.ToolStripMenuItem ListByDataType;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        public System.Windows.Forms.ToolStripMenuItem ListNamesOnly;
        public System.Windows.Forms.ToolStripMenuItem TreeMenu;
        public System.Windows.Forms.ToolStripMenuItem TreeByCategory;
        public System.Windows.Forms.ToolStripMenuItem TreeByDataType;
        public System.Windows.Forms.ToolStripMenuItem TreeNamesOnly;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    }
}