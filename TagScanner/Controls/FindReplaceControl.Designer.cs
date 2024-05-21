namespace TagScanner.Views
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
            this.cbFindTerm = new System.Windows.Forms.ToolStripComboBox();
            this.tbFind = new System.Windows.Forms.ToolStripSplitButton();
            this.tbClose = new System.Windows.Forms.ToolStripButton();
            this.tbCloseUp = new System.Windows.Forms.ToolStripButton();
            this.cbReplaceTerm = new System.Windows.Forms.ToolStripComboBox();
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
            this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbDropDown,
            this.cbFindTerm,
            this.tbFind,
            this.tbClose,
            this.tbCloseUp,
            this.cbReplaceTerm,
            this.tbReplaceNext,
            this.tbReplaceAll,
            this.tbCaseSensitive,
            this.tbWholeWord,
            this.tbUseRegex,
            this.tbPickTags});
            this.Toolbar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.Toolbar.Location = new System.Drawing.Point(0, 0);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Size = new System.Drawing.Size(173, 69);
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
            // cbFindTerm
            // 
            this.cbFindTerm.Name = "cbFindTerm";
            this.cbFindTerm.Size = new System.Drawing.Size(81, 23);
            this.cbFindTerm.ToolTipText = "Search term";
            // 
            // tbFind
            // 
            this.tbFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbFind.Image = global::TagScanner.Properties.Resources.frFindNext;
            this.tbFind.ImageTransparentColor = System.Drawing.Color.White;
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(32, 20);
            this.tbFind.Text = "toolStripSplitButton1";
            this.tbFind.ToolTipText = "Find Next (F3)";
            // 
            // tbClose
            // 
            this.tbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbClose.Image = global::TagScanner.Properties.Resources.frClose;
            this.tbClose.ImageTransparentColor = System.Drawing.Color.White;
            this.tbClose.Name = "tbClose";
            this.tbClose.Size = new System.Drawing.Size(23, 20);
            this.tbClose.Text = "toolStripButton2";
            this.tbClose.ToolTipText = "Close";
            // 
            // tbCloseUp
            // 
            this.tbCloseUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCloseUp.Image = global::TagScanner.Properties.Resources.frCloseUp;
            this.tbCloseUp.ImageTransparentColor = System.Drawing.Color.White;
            this.tbCloseUp.Name = "tbCloseUp";
            this.tbCloseUp.Size = new System.Drawing.Size(23, 20);
            this.tbCloseUp.Text = "toolStripButton3";
            this.tbCloseUp.ToolTipText = " ";
            // 
            // cbReplaceTerm
            // 
            this.cbReplaceTerm.Name = "cbReplaceTerm";
            this.cbReplaceTerm.Size = new System.Drawing.Size(81, 23);
            this.cbReplaceTerm.ToolTipText = "Replace term";
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
            this.tbPickTags.AutoSize = false;
            this.tbPickTags.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbPickTags.Image = ((System.Drawing.Image)(resources.GetObject("tbPickTags.Image")));
            this.tbPickTags.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbPickTags.Name = "tbPickTags";
            this.tbPickTags.Size = new System.Drawing.Size(103, 19);
            this.tbPickTags.Text = "Album|Artist|Title";
            // 
            // FindReplaceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Toolbar);
            this.Name = "FindReplaceControl";
            this.Size = new System.Drawing.Size(173, 79);
            this.Toolbar.ResumeLayout(false);
            this.Toolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip Toolbar;
        public System.Windows.Forms.ToolStripButton tbDropDown;
        public System.Windows.Forms.ToolStripComboBox cbFindTerm;
        public System.Windows.Forms.ToolStripSplitButton tbFind;
        public System.Windows.Forms.ToolStripButton tbClose;
        public System.Windows.Forms.ToolStripButton tbCloseUp;
        public System.Windows.Forms.ToolStripComboBox cbReplaceTerm;
        public System.Windows.Forms.ToolStripButton tbReplaceNext;
        public System.Windows.Forms.ToolStripButton tbReplaceAll;
        public System.Windows.Forms.ToolStripButton tbCaseSensitive;
        public System.Windows.Forms.ToolStripButton tbWholeWord;
        public System.Windows.Forms.ToolStripButton tbUseRegex;
        public System.Windows.Forms.ToolStripButton tbPickTags;
    }
}
