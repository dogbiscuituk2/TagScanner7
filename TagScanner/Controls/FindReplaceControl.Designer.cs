namespace TagScanner.Forms
{
    partial class FindReplaceControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindReplaceControl));
            this.Toolbar = new System.Windows.Forms.ToolStrip();
            this.tbDropDown = new System.Windows.Forms.ToolStripButton();
            this.cbFind = new System.Windows.Forms.ToolStripComboBox();
            this.tbFind = new System.Windows.Forms.ToolStripSplitButton();
            this.tbFindNext = new System.Windows.Forms.ToolStripMenuItem();
            this.tbFindPrevious = new System.Windows.Forms.ToolStripMenuItem();
            this.tbFindAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tbFindClose = new System.Windows.Forms.ToolStripButton();
            this.tbCloseUp = new System.Windows.Forms.ToolStripButton();
            this.cbReplace = new System.Windows.Forms.ToolStripComboBox();
            this.tbReplaceNext = new System.Windows.Forms.ToolStripButton();
            this.tbReplaceAll = new System.Windows.Forms.ToolStripButton();
            this.tbCaseSensitive = new System.Windows.Forms.ToolStripButton();
            this.tbWholeWord = new System.Windows.Forms.ToolStripButton();
            this.tbUseRegex = new System.Windows.Forms.ToolStripButton();
            this.tbPickTags = new System.Windows.Forms.ToolStripButton();
            this.Toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // Toolbar
            // 
            this.Toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbDropDown,
            this.cbFind,
            this.tbFind,
            this.tbFindClose,
            this.tbCloseUp,
            this.cbReplace,
            this.tbReplaceNext,
            this.tbReplaceAll,
            this.tbCaseSensitive,
            this.tbWholeWord,
            this.tbUseRegex,
            this.tbPickTags});
            this.Toolbar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.Toolbar.Location = new System.Drawing.Point(0, 0);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Size = new System.Drawing.Size(186, 69);
            this.Toolbar.TabIndex = 1;
            this.Toolbar.Text = "toolStrip1";
            // 
            // tbDropDown
            // 
            this.tbDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbDropDown.Image = global::TagScanner.Properties.Resources.frDropDown;
            this.tbDropDown.ImageTransparentColor = System.Drawing.Color.White;
            this.tbDropDown.Name = "tbDropDown";
            this.tbDropDown.Size = new System.Drawing.Size(23, 20);
            this.tbDropDown.Text = "toolStripButton1";
            this.tbDropDown.ToolTipText = "Toggle to switch between find and replace modes";
            // 
            // cbFind
            // 
            this.cbFind.Items.AddRange(new object[] {
            "one",
            "two",
            "three"});
            this.cbFind.Name = "cbFind";
            this.cbFind.Size = new System.Drawing.Size(94, 23);
            this.cbFind.ToolTipText = "Search term";
            // 
            // tbFind
            // 
            this.tbFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbFind.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbFindNext,
            this.tbFindPrevious,
            this.tbFindAll});
            this.tbFind.Image = global::TagScanner.Properties.Resources.frFindNext;
            this.tbFind.ImageTransparentColor = System.Drawing.Color.White;
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(32, 20);
            this.tbFind.Text = "toolStripSplitButton1";
            this.tbFind.ToolTipText = "Find Next (F3)";
            // 
            // tbFindNext
            // 
            this.tbFindNext.Image = global::TagScanner.Properties.Resources.frFindNext;
            this.tbFindNext.Name = "tbFindNext";
            this.tbFindNext.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.tbFindNext.Size = new System.Drawing.Size(196, 22);
            this.tbFindNext.Text = "Find Next";
            // 
            // tbFindPrevious
            // 
            this.tbFindPrevious.Image = global::TagScanner.Properties.Resources.frFindPrevious;
            this.tbFindPrevious.ImageTransparentColor = System.Drawing.Color.White;
            this.tbFindPrevious.Name = "tbFindPrevious";
            this.tbFindPrevious.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F3)));
            this.tbFindPrevious.Size = new System.Drawing.Size(196, 22);
            this.tbFindPrevious.Text = "Find Previous";
            // 
            // tbFindAll
            // 
            this.tbFindAll.Image = global::TagScanner.Properties.Resources.frSearch;
            this.tbFindAll.ImageTransparentColor = System.Drawing.Color.White;
            this.tbFindAll.Name = "tbFindAll";
            this.tbFindAll.Size = new System.Drawing.Size(196, 22);
            this.tbFindAll.Text = "Find All";
            // 
            // tbFindClose
            // 
            this.tbFindClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbFindClose.Image = global::TagScanner.Properties.Resources.frClose;
            this.tbFindClose.ImageTransparentColor = System.Drawing.Color.White;
            this.tbFindClose.Name = "tbFindClose";
            this.tbFindClose.Size = new System.Drawing.Size(23, 20);
            this.tbFindClose.Text = "toolStripButton2";
            this.tbFindClose.ToolTipText = "Close find/replace";
            // 
            // tbCloseUp
            // 
            this.tbCloseUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCloseUp.Enabled = false;
            this.tbCloseUp.Image = global::TagScanner.Properties.Resources.frBlank;
            this.tbCloseUp.ImageTransparentColor = System.Drawing.Color.White;
            this.tbCloseUp.Name = "tbCloseUp";
            this.tbCloseUp.Size = new System.Drawing.Size(23, 20);
            this.tbCloseUp.Text = "toolStripButton3";
            this.tbCloseUp.ToolTipText = " Toggle to switch between find and replace modes";
            // 
            // cbReplace
            // 
            this.cbReplace.Name = "cbReplace";
            this.cbReplace.Size = new System.Drawing.Size(94, 23);
            this.cbReplace.ToolTipText = "Replace term";
            // 
            // tbReplaceNext
            // 
            this.tbReplaceNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbReplaceNext.Image = global::TagScanner.Properties.Resources.frReplaceNext;
            this.tbReplaceNext.ImageTransparentColor = System.Drawing.Color.White;
            this.tbReplaceNext.Name = "tbReplaceNext";
            this.tbReplaceNext.Size = new System.Drawing.Size(23, 20);
            this.tbReplaceNext.Text = "toolStripButton4";
            this.tbReplaceNext.ToolTipText = "Replace next";
            // 
            // tbReplaceAll
            // 
            this.tbReplaceAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbReplaceAll.Image = global::TagScanner.Properties.Resources.frReplaceAll;
            this.tbReplaceAll.ImageTransparentColor = System.Drawing.Color.White;
            this.tbReplaceAll.Name = "tbReplaceAll";
            this.tbReplaceAll.Size = new System.Drawing.Size(23, 20);
            this.tbReplaceAll.Text = "toolStripButton5";
            this.tbReplaceAll.ToolTipText = "Replace all";
            // 
            // tbCaseSensitive
            // 
            this.tbCaseSensitive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCaseSensitive.Image = global::TagScanner.Properties.Resources.frCase;
            this.tbCaseSensitive.ImageTransparentColor = System.Drawing.Color.White;
            this.tbCaseSensitive.Name = "tbCaseSensitive";
            this.tbCaseSensitive.Size = new System.Drawing.Size(23, 20);
            this.tbCaseSensitive.Text = "toolStripButton6";
            this.tbCaseSensitive.ToolTipText = "Match case (Alt+C)";
            // 
            // tbWholeWord
            // 
            this.tbWholeWord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbWholeWord.Image = global::TagScanner.Properties.Resources.frWholeWord;
            this.tbWholeWord.ImageTransparentColor = System.Drawing.Color.White;
            this.tbWholeWord.Name = "tbWholeWord";
            this.tbWholeWord.Size = new System.Drawing.Size(23, 20);
            this.tbWholeWord.Text = "toolStripButton7";
            this.tbWholeWord.ToolTipText = "Match whole word (Alt+W)";
            // 
            // tbUseRegex
            // 
            this.tbUseRegex.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbUseRegex.Image = global::TagScanner.Properties.Resources.frRegex;
            this.tbUseRegex.ImageTransparentColor = System.Drawing.Color.White;
            this.tbUseRegex.Name = "tbUseRegex";
            this.tbUseRegex.Size = new System.Drawing.Size(23, 20);
            this.tbUseRegex.Text = "toolStripButton8";
            this.tbUseRegex.ToolTipText = "Use Regular Expressions (Alt+E)";
            // 
            // tbPickTags
            // 
            this.tbPickTags.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbPickTags.Image = ((System.Drawing.Image)(resources.GetObject("tbPickTags.Image")));
            this.tbPickTags.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbPickTags.Name = "tbPickTags";
            this.tbPickTags.Size = new System.Drawing.Size(86, 19);
            this.tbPickTags.Text = "Search fields...";
            // 
            // FindReplaceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Toolbar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FindReplaceControl";
            this.Size = new System.Drawing.Size(186, 71);
            this.Toolbar.ResumeLayout(false);
            this.Toolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip Toolbar;
        public System.Windows.Forms.ToolStripButton tbDropDown;
        public System.Windows.Forms.ToolStripComboBox cbFind;
        public System.Windows.Forms.ToolStripSplitButton tbFind;
        public System.Windows.Forms.ToolStripButton tbFindClose;
        public System.Windows.Forms.ToolStripButton tbCloseUp;
        public System.Windows.Forms.ToolStripComboBox cbReplace;
        public System.Windows.Forms.ToolStripButton tbReplaceNext;
        public System.Windows.Forms.ToolStripButton tbReplaceAll;
        public System.Windows.Forms.ToolStripButton tbCaseSensitive;
        public System.Windows.Forms.ToolStripButton tbWholeWord;
        public System.Windows.Forms.ToolStripButton tbUseRegex;
        public System.Windows.Forms.ToolStripButton tbPickTags;
        public System.Windows.Forms.ToolStripMenuItem tbFindNext;
        public System.Windows.Forms.ToolStripMenuItem tbFindPrevious;
        public System.Windows.Forms.ToolStripMenuItem tbFindAll;
    }
}
