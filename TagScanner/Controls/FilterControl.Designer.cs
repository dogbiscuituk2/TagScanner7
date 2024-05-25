namespace TagScanner.Controls
{
    partial class FilterControl
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
            this.Toolbar = new TagScanner.Controls.FirstClickToolStrip();
            this.tbCaseSensitive = new System.Windows.Forms.ToolStripButton();
            this.cbFilter = new System.Windows.Forms.ToolStripComboBox();
            this.tbApply = new System.Windows.Forms.ToolStripButton();
            this.tbClear = new System.Windows.Forms.ToolStripButton();
            this.tbEdit = new System.Windows.Forms.ToolStripButton();
            this.tbClose = new System.Windows.Forms.ToolStripButton();
            this.Toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // Toolbar
            // 
            this.Toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbFilter,
            this.tbCaseSensitive,
            this.tbApply,
            this.tbClear,
            this.tbEdit,
            this.tbClose});
            this.Toolbar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.Toolbar.Location = new System.Drawing.Point(0, 0);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Size = new System.Drawing.Size(349, 23);
            this.Toolbar.TabIndex = 0;
            this.Toolbar.Text = "toolStrip1";
            // 
            // tbCaseSensitive
            // 
            this.tbCaseSensitive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCaseSensitive.Image = global::TagScanner.Properties.Resources.frCase;
            this.tbCaseSensitive.ImageTransparentColor = System.Drawing.Color.White;
            this.tbCaseSensitive.Name = "tbCaseSensitive";
            this.tbCaseSensitive.Size = new System.Drawing.Size(23, 20);
            this.tbCaseSensitive.Text = "Case sensitive";
            this.tbCaseSensitive.ToolTipText = "Case sensitive filter";
            // 
            // cbFilter
            // 
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(140, 23);
            this.cbFilter.ToolTipText = "Enter filter script";
            // 
            // tbApply
            // 
            this.tbApply.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbApply.Image = global::TagScanner.Properties.Resources.frApply;
            this.tbApply.ImageTransparentColor = System.Drawing.Color.White;
            this.tbApply.Name = "tbApply";
            this.tbApply.Size = new System.Drawing.Size(23, 20);
            this.tbApply.Text = "toolStripButton1";
            this.tbApply.ToolTipText = "Apply filter";
            // 
            // tbClear
            // 
            this.tbClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbClear.Image = global::TagScanner.Properties.Resources.frClear;
            this.tbClear.ImageTransparentColor = System.Drawing.Color.White;
            this.tbClear.Name = "tbClear";
            this.tbClear.Size = new System.Drawing.Size(23, 20);
            this.tbClear.Text = "toolStripButton2";
            this.tbClear.ToolTipText = "Clear filter";
            // 
            // tbEdit
            // 
            this.tbEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbEdit.Image = global::TagScanner.Properties.Resources.frEdit;
            this.tbEdit.ImageTransparentColor = System.Drawing.Color.White;
            this.tbEdit.Name = "tbEdit";
            this.tbEdit.Size = new System.Drawing.Size(23, 20);
            this.tbEdit.Text = "toolStripButton3";
            this.tbEdit.ToolTipText = "Edit filter";
            // 
            // tbClose
            // 
            this.tbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbClose.Image = global::TagScanner.Properties.Resources.frClose;
            this.tbClose.ImageTransparentColor = System.Drawing.Color.White;
            this.tbClose.Name = "tbClose";
            this.tbClose.Size = new System.Drawing.Size(23, 20);
            this.tbClose.Text = "toolStripButton1";
            this.tbClose.ToolTipText = "Close filter";
            // 
            // FilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Toolbar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FilterControl";
            this.Size = new System.Drawing.Size(349, 32);
            this.Toolbar.ResumeLayout(false);
            this.Toolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public TagScanner.Controls.FirstClickToolStrip Toolbar;
        public System.Windows.Forms.ToolStripButton tbCaseSensitive;
        public System.Windows.Forms.ToolStripComboBox cbFilter;
        public System.Windows.Forms.ToolStripButton tbApply;
        public System.Windows.Forms.ToolStripButton tbClear;
        public System.Windows.Forms.ToolStripButton tbEdit;
        public System.Windows.Forms.ToolStripButton tbClose;
    }
}
