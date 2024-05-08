namespace TagScanner.Views
{
    partial class ScriptForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptForm));
            this.TextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.ruler1 = new FastColoredTextBoxNS.Ruler();
            this.ToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.FileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.FileReopen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.FileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.FileClose = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageKerr = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.LanguageCS = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageVB = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageHTML = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageXML = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageSQL = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguagePHP = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageJS = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageLua = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            this.ToolStripContainer.ContentPanel.SuspendLayout();
            this.ToolStripContainer.TopToolStripPanel.SuspendLayout();
            this.ToolStripContainer.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBox
            // 
            this.TextBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.TextBox.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.TextBox.BackBrush = null;
            this.TextBox.CharHeight = 14;
            this.TextBox.CharWidth = 8;
            this.TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox.IsReplaceMode = false;
            this.TextBox.Location = new System.Drawing.Point(0, 24);
            this.TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.TextBox.Name = "TextBox";
            this.TextBox.Paddings = new System.Windows.Forms.Padding(0);
            this.TextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.TextBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("TextBox.ServiceColors")));
            this.TextBox.Size = new System.Drawing.Size(784, 513);
            this.TextBox.TabIndex = 0;
            this.TextBox.Zoom = 100;
            // 
            // ruler1
            // 
            this.ruler1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ruler1.Location = new System.Drawing.Point(0, 0);
            this.ruler1.MaximumSize = new System.Drawing.Size(1073741824, 24);
            this.ruler1.MinimumSize = new System.Drawing.Size(0, 24);
            this.ruler1.Name = "ruler1";
            this.ruler1.Size = new System.Drawing.Size(784, 24);
            this.ruler1.TabIndex = 1;
            this.ruler1.Target = this.TextBox;
            // 
            // ToolStripContainer
            // 
            // 
            // ToolStripContainer.ContentPanel
            // 
            this.ToolStripContainer.ContentPanel.Controls.Add(this.TextBox);
            this.ToolStripContainer.ContentPanel.Controls.Add(this.ruler1);
            this.ToolStripContainer.ContentPanel.Size = new System.Drawing.Size(784, 537);
            this.ToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.ToolStripContainer.Name = "ToolStripContainer";
            this.ToolStripContainer.Size = new System.Drawing.Size(784, 561);
            this.ToolStripContainer.TabIndex = 2;
            this.ToolStripContainer.Text = "toolStripContainer1";
            // 
            // ToolStripContainer.TopToolStripPanel
            // 
            this.ToolStripContainer.TopToolStripPanel.Controls.Add(this.MainMenu);
            // 
            // MainMenu
            // 
            this.MainMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.LanguageMenu});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(784, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileNew,
            this.FileOpen,
            this.FileReopen,
            this.toolStripMenuItem1,
            this.FileSave,
            this.FileSaveAs,
            this.toolStripMenuItem2,
            this.FileClose});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 20);
            this.FileMenu.Text = "&File";
            // 
            // FileNew
            // 
            this.FileNew.Name = "FileNew";
            this.FileNew.Size = new System.Drawing.Size(180, 22);
            this.FileNew.Text = "New";
            // 
            // FileOpen
            // 
            this.FileOpen.Name = "FileOpen";
            this.FileOpen.Size = new System.Drawing.Size(180, 22);
            this.FileOpen.Text = "Open";
            // 
            // FileReopen
            // 
            this.FileReopen.Name = "FileReopen";
            this.FileReopen.Size = new System.Drawing.Size(180, 22);
            this.FileReopen.Text = "Reopen";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // FileSave
            // 
            this.FileSave.Name = "FileSave";
            this.FileSave.Size = new System.Drawing.Size(180, 22);
            this.FileSave.Text = "Save";
            // 
            // FileSaveAs
            // 
            this.FileSaveAs.Name = "FileSaveAs";
            this.FileSaveAs.Size = new System.Drawing.Size(180, 22);
            this.FileSaveAs.Text = "Save As...";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // FileClose
            // 
            this.FileClose.Name = "FileClose";
            this.FileClose.Size = new System.Drawing.Size(180, 22);
            this.FileClose.Text = "Close";
            // 
            // LanguageMenu
            // 
            this.LanguageMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LanguageKerr,
            this.toolStripSeparator1,
            this.LanguageCS,
            this.LanguageVB,
            this.LanguageHTML,
            this.LanguageXML,
            this.LanguageSQL,
            this.LanguagePHP,
            this.LanguageJS,
            this.LanguageLua});
            this.LanguageMenu.Name = "LanguageMenu";
            this.LanguageMenu.Size = new System.Drawing.Size(71, 20);
            this.LanguageMenu.Text = "&Language";
            // 
            // LanguageKerr
            // 
            this.LanguageKerr.Name = "LanguageKerr";
            this.LanguageKerr.Size = new System.Drawing.Size(180, 22);
            this.LanguageKerr.Text = "Kerr";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // LanguageCS
            // 
            this.LanguageCS.Name = "LanguageCS";
            this.LanguageCS.Size = new System.Drawing.Size(180, 22);
            this.LanguageCS.Text = "C#";
            // 
            // LanguageVB
            // 
            this.LanguageVB.Name = "LanguageVB";
            this.LanguageVB.Size = new System.Drawing.Size(180, 22);
            this.LanguageVB.Text = "Visual Basic";
            // 
            // LanguageHTML
            // 
            this.LanguageHTML.Name = "LanguageHTML";
            this.LanguageHTML.Size = new System.Drawing.Size(180, 22);
            this.LanguageHTML.Text = "HTML";
            // 
            // LanguageXML
            // 
            this.LanguageXML.Name = "LanguageXML";
            this.LanguageXML.Size = new System.Drawing.Size(180, 22);
            this.LanguageXML.Text = "XML";
            // 
            // LanguageSQL
            // 
            this.LanguageSQL.Name = "LanguageSQL";
            this.LanguageSQL.Size = new System.Drawing.Size(180, 22);
            this.LanguageSQL.Text = "SQL";
            // 
            // LanguagePHP
            // 
            this.LanguagePHP.Name = "LanguagePHP";
            this.LanguagePHP.Size = new System.Drawing.Size(180, 22);
            this.LanguagePHP.Text = "PHP";
            // 
            // LanguageJS
            // 
            this.LanguageJS.Name = "LanguageJS";
            this.LanguageJS.Size = new System.Drawing.Size(180, 22);
            this.LanguageJS.Text = "JavaScript";
            // 
            // LanguageLua
            // 
            this.LanguageLua.Name = "LanguageLua";
            this.LanguageLua.Size = new System.Drawing.Size(180, 22);
            this.LanguageLua.Text = "Lua";
            // 
            // ScriptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.ToolStripContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.MainMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ScriptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Script";
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            this.ToolStripContainer.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer.TopToolStripPanel.PerformLayout();
            this.ToolStripContainer.ResumeLayout(false);
            this.ToolStripContainer.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public FastColoredTextBoxNS.FastColoredTextBox TextBox;
        public FastColoredTextBoxNS.Ruler ruler1;
        public System.Windows.Forms.ToolStripContainer ToolStripContainer;
        public System.Windows.Forms.MenuStrip MainMenu;
        public System.Windows.Forms.ToolStripMenuItem FileMenu;
        public System.Windows.Forms.ToolStripMenuItem LanguageMenu;
        public System.Windows.Forms.ToolStripMenuItem FileNew;
        public System.Windows.Forms.ToolStripMenuItem FileOpen;
        public System.Windows.Forms.ToolStripMenuItem FileReopen;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem FileSave;
        public System.Windows.Forms.ToolStripMenuItem FileSaveAs;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        public System.Windows.Forms.ToolStripMenuItem FileClose;
        public System.Windows.Forms.ToolStripMenuItem LanguageKerr;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripMenuItem LanguageCS;
        public System.Windows.Forms.ToolStripMenuItem LanguageVB;
        public System.Windows.Forms.ToolStripMenuItem LanguageHTML;
        public System.Windows.Forms.ToolStripMenuItem LanguageXML;
        public System.Windows.Forms.ToolStripMenuItem LanguageSQL;
        public System.Windows.Forms.ToolStripMenuItem LanguagePHP;
        public System.Windows.Forms.ToolStripMenuItem LanguageJS;
        public System.Windows.Forms.ToolStripMenuItem LanguageLua;
    }
}