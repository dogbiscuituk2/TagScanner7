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
            this.ColourTextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.ruler1 = new FastColoredTextBoxNS.Ruler();
            this.ToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            ((System.ComponentModel.ISupportInitialize)(this.ColourTextBox)).BeginInit();
            this.ToolStripContainer.ContentPanel.SuspendLayout();
            this.ToolStripContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ColourTextBox
            // 
            this.ColourTextBox.AutoCompleteBracketsList = new char[] {
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
            this.ColourTextBox.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.ColourTextBox.BackBrush = null;
            this.ColourTextBox.CharHeight = 14;
            this.ColourTextBox.CharWidth = 8;
            this.ColourTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ColourTextBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ColourTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColourTextBox.IsReplaceMode = false;
            this.ColourTextBox.Location = new System.Drawing.Point(0, 24);
            this.ColourTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ColourTextBox.Name = "ColourTextBox";
            this.ColourTextBox.Paddings = new System.Windows.Forms.Padding(0);
            this.ColourTextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.ColourTextBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("ColourTextBox.ServiceColors")));
            this.ColourTextBox.Size = new System.Drawing.Size(784, 512);
            this.ColourTextBox.TabIndex = 0;
            this.ColourTextBox.Zoom = 100;
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
            this.ruler1.Target = this.ColourTextBox;
            // 
            // ToolStripContainer
            // 
            // 
            // ToolStripContainer.ContentPanel
            // 
            this.ToolStripContainer.ContentPanel.Controls.Add(this.ColourTextBox);
            this.ToolStripContainer.ContentPanel.Controls.Add(this.ruler1);
            this.ToolStripContainer.ContentPanel.Size = new System.Drawing.Size(784, 536);
            this.ToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.ToolStripContainer.Name = "ToolStripContainer";
            this.ToolStripContainer.Size = new System.Drawing.Size(784, 561);
            this.ToolStripContainer.TabIndex = 2;
            this.ToolStripContainer.Text = "toolStripContainer1";
            // 
            // ScriptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.ToolStripContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ScriptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Script";
            ((System.ComponentModel.ISupportInitialize)(this.ColourTextBox)).EndInit();
            this.ToolStripContainer.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer.ResumeLayout(false);
            this.ToolStripContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public FastColoredTextBoxNS.FastColoredTextBox ColourTextBox;
        public FastColoredTextBoxNS.Ruler ruler1;
        public System.Windows.Forms.ToolStripContainer ToolStripContainer;
    }
}