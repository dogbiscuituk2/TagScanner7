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
            this.tbToggleFindReplace = new System.Windows.Forms.ToolStripButton();
            this.cbFindTerm = new System.Windows.Forms.ToolStripComboBox();
            this.tbFind = new System.Windows.Forms.ToolStripSplitButton();
            this.tbClose = new System.Windows.Forms.ToolStripButton();
            this.tbSpacer = new System.Windows.Forms.ToolStripButton();
            this.cbReplaceterm = new System.Windows.Forms.ToolStripComboBox();
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
            this.tbToggleFindReplace,
            this.cbFindTerm,
            this.tbFind,
            this.tbClose,
            this.tbSpacer,
            this.cbReplaceterm,
            this.tbReplaceNext,
            this.tbReplaceAll,
            this.tbCaseSensitive,
            this.tbWholeWord,
            this.tbUseRegex,
            this.tbPickTags});
            this.Toolbar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.Toolbar.Location = new System.Drawing.Point(0, 0);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Size = new System.Drawing.Size(206, 69);
            this.Toolbar.TabIndex = 1;
            this.Toolbar.Text = "toolStrip1";
            // 
            // tbToggleFindReplace
            // 
            this.tbToggleFindReplace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbToggleFindReplace.Image = global::TagScanner.Properties.Resources.frToggle;
            this.tbToggleFindReplace.ImageTransparentColor = System.Drawing.Color.White;
            this.tbToggleFindReplace.Name = "tbToggleFindReplace";
            this.tbToggleFindReplace.Size = new System.Drawing.Size(23, 20);
            this.tbToggleFindReplace.Text = "toolStripButton1";
            this.tbToggleFindReplace.ToolTipText = "Toggle to switch between find and replace modes";
            this.tbToggleFindReplace.Click += new System.EventHandler(this.tbToggleFindReplace_Click);
            // 
            // cbFindTerm
            // 
            this.cbFindTerm.Name = "cbFindTerm";
            this.cbFindTerm.Size = new System.Drawing.Size(121, 23);
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
            // tbSpacer
            // 
            this.tbSpacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSpacer.Image = ((System.Drawing.Image)(resources.GetObject("tbSpacer.Image")));
            this.tbSpacer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSpacer.Name = "tbSpacer";
            this.tbSpacer.Size = new System.Drawing.Size(23, 20);
            this.tbSpacer.Text = "toolStripButton3";
            this.tbSpacer.ToolTipText = " ";
            // 
            // cbReplaceterm
            // 
            this.cbReplaceterm.Name = "cbReplaceterm";
            this.cbReplaceterm.Size = new System.Drawing.Size(121, 23);
            this.cbReplaceterm.ToolTipText = "Replace term";
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
            this.tbPickTags.Size = new System.Drawing.Size(103, 19);
            this.tbPickTags.Text = "Album|Artist|Title";
            // 
            // FindReplaceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Toolbar);
            this.Name = "FindReplaceControl";
            this.Size = new System.Drawing.Size(206, 79);
            this.Resize += new System.EventHandler(this.FindReplaceControl_Resize);
            this.Toolbar.ResumeLayout(false);
            this.Toolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Toolbar;
        private System.Windows.Forms.ToolStripButton tbToggleFindReplace;
        private System.Windows.Forms.ToolStripComboBox cbFindTerm;
        private System.Windows.Forms.ToolStripSplitButton tbFind;
        private System.Windows.Forms.ToolStripButton tbClose;
        private System.Windows.Forms.ToolStripButton tbSpacer;
        private System.Windows.Forms.ToolStripComboBox cbReplaceterm;
        private System.Windows.Forms.ToolStripButton tbReplaceNext;
        private System.Windows.Forms.ToolStripButton tbReplaceAll;
        private System.Windows.Forms.ToolStripButton tbCaseSensitive;
        private System.Windows.Forms.ToolStripButton tbWholeWord;
        private System.Windows.Forms.ToolStripButton tbUseRegex;
        private System.Windows.Forms.ToolStripButton tbPickTags;
    }
}
