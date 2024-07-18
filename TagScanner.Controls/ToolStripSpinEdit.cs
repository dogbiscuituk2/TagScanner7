namespace TagScanner.Controls
{
    using System;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;

    [ToolStripItemDesignerAvailability(
        ToolStripItemDesignerAvailability.ToolStrip |
        ToolStripItemDesignerAvailability.MenuStrip |
        ToolStripItemDesignerAvailability.ContextMenuStrip)]
    public class ToolStripSpinEdit : ToolStripControl<NumericUpDown>
    {
        #region Constructor

        public ToolStripSpinEdit() : base() { AutoSize = false; }

        #endregion

        #region Public Properties

        public int DecimalPlaces
        {
            get => Guest.DecimalPlaces;
            set => Guest.DecimalPlaces = value;
        }

        public decimal Maximim
        {
            get => Guest.Maximum;
            set => Guest.Maximum = value;
        }

        public decimal Minimum
        {
            get => Guest.Minimum;
            set => Guest.Minimum = value;
        }

        public decimal Value
        {
            get => Guest.Value;
            set => Guest.Value = value;
        }

        #endregion

        #region Public Events

        public event EventHandler ValueChanged;

        #endregion

        #region Protected Methods

        protected override void OnSubscribeEvents(NumericUpDown spinEdit)
        {
            spinEdit.ValueChanged += OnValueChanged;
        }

        protected override void OnUnsubscribeEvents(NumericUpDown spinEdit)
        {
            spinEdit.ValueChanged -= OnValueChanged;
        }

        #endregion

        #region Event Handlers

        private void OnValueChanged(object sender, EventArgs e) => ValueChanged?.Invoke(this, EventArgs.Empty);

        #endregion
    }
}
