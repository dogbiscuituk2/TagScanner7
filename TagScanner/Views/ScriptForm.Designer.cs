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
            ((System.ComponentModel.ISupportInitialize)(this.ColourTextBox)).BeginInit();
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
            this.ColourTextBox.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.ColourTextBox.IsReplaceMode = false;
            this.ColourTextBox.Location = new System.Drawing.Point(12, 12);
            this.ColourTextBox.Name = "ColourTextBox";
            this.ColourTextBox.Paddings = new System.Windows.Forms.Padding(0);
            this.ColourTextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.ColourTextBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("ColourTextBox.ServiceColors")));
            this.ColourTextBox.Size = new System.Drawing.Size(600, 231);
            this.ColourTextBox.TabIndex = 0;
            this.ColourTextBox.Zoom = 100;
            // 
            // ScriptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ColourTextBox);
            this.Name = "ScriptForm";
            this.Text = "Script";
            ((System.ComponentModel.ISupportInitialize)(this.ColourTextBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public FastColoredTextBoxNS.FastColoredTextBox ColourTextBox;
    }
}