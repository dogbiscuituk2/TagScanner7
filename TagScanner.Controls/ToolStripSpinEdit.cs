namespace TagScanner.Controls
{
    using System;
    using System.Windows.Forms;

    public class ToolStripSpinEdit : ToolStripControl<NumericUpDown>
    {
        #region Constructor

        public ToolStripSpinEdit() : base() { }

        #endregion

        #region Public Properties

        public int DecimalPlaces
        {
            get => Control.DecimalPlaces;
            set => Control.DecimalPlaces = value;
        }

        public decimal Maximim
        {
            get => Control.Maximum;
            set => Control.Maximum = value;
        }

        public decimal Minimum
        {
            get => Control.Minimum;
            set => Control.Minimum = value;
        }

        public decimal Value
        {
            get => Control.Value;
            set => Control.Value = value;
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
