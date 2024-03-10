namespace TagScanner.Views
{
    partial class FilterForm
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
            this.TreeView = new System.Windows.Forms.TreeView();
            this.PopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PopupAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddRoot = new System.Windows.Forms.Button();
            this.FieldComboBox = new System.Windows.Forms.ComboBox();
            this.OperatorComboBox = new System.Windows.Forms.ComboBox();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.AddMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FieldMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenu.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TreeView
            // 
            this.TreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeView.ContextMenuStrip = this.PopupMenu;
            this.TreeView.HideSelection = false;
            this.TreeView.Location = new System.Drawing.Point(13, 97);
            this.TreeView.Margin = new System.Windows.Forms.Padding(4);
            this.TreeView.Name = "TreeView";
            this.TreeView.ShowNodeToolTips = true;
            this.TreeView.Size = new System.Drawing.Size(758, 413);
            this.TreeView.TabIndex = 0;
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
            this.PopupAdd.Text = "&Add";
            // 
            // PopupEdit
            // 
            this.PopupEdit.Name = "PopupEdit";
            this.PopupEdit.Size = new System.Drawing.Size(107, 22);
            this.PopupEdit.Text = "&Edit";
            // 
            // PopupDelete
            // 
            this.PopupDelete.Name = "PopupDelete";
            this.PopupDelete.Size = new System.Drawing.Size(107, 22);
            this.PopupDelete.Text = "&Delete";
            // 
            // btnAddRoot
            // 
            this.btnAddRoot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRoot.Location = new System.Drawing.Point(683, 518);
            this.btnAddRoot.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddRoot.Name = "btnAddRoot";
            this.btnAddRoot.Size = new System.Drawing.Size(88, 30);
            this.btnAddRoot.TabIndex = 1;
            this.btnAddRoot.Text = "Add Root";
            this.btnAddRoot.UseVisualStyleBackColor = true;
            // 
            // FieldComboBox
            // 
            this.FieldComboBox.FormattingEnabled = true;
            this.FieldComboBox.Location = new System.Drawing.Point(13, 522);
            this.FieldComboBox.Name = "FieldComboBox";
            this.FieldComboBox.Size = new System.Drawing.Size(159, 25);
            this.FieldComboBox.TabIndex = 2;
            // 
            // OperatorComboBox
            // 
            this.OperatorComboBox.FormattingEnabled = true;
            this.OperatorComboBox.Location = new System.Drawing.Point(178, 522);
            this.OperatorComboBox.Name = "OperatorComboBox";
            this.OperatorComboBox.Size = new System.Drawing.Size(498, 25);
            this.OperatorComboBox.TabIndex = 3;
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddMenu});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(784, 24);
            this.MainMenu.TabIndex = 4;
            this.MainMenu.Text = "menuStrip1";
            // 
            // AddMenu
            // 
            this.AddMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FieldMenu});
            this.AddMenu.Name = "AddMenu";
            this.AddMenu.Size = new System.Drawing.Size(41, 20);
            this.AddMenu.Text = "&Add";
            // 
            // FieldMenu
            // 
            this.FieldMenu.Name = "FieldMenu";
            this.FieldMenu.Size = new System.Drawing.Size(180, 22);
            this.FieldMenu.Text = "&Field";
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.OperatorComboBox);
            this.Controls.Add(this.FieldComboBox);
            this.Controls.Add(this.btnAddRoot);
            this.Controls.Add(this.TreeView);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.MainMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Filter";
            this.PopupMenu.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button btnAddRoot;
        public System.Windows.Forms.TreeView TreeView;
        public System.Windows.Forms.ContextMenuStrip PopupMenu;
        public System.Windows.Forms.ComboBox FieldComboBox;
        public System.Windows.Forms.ComboBox OperatorComboBox;
        public System.Windows.Forms.ToolStripMenuItem PopupAdd;
        public System.Windows.Forms.ToolStripMenuItem PopupEdit;
        public System.Windows.Forms.ToolStripMenuItem PopupDelete;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem AddMenu;
        private System.Windows.Forms.ToolStripMenuItem FieldMenu;
    }
}