namespace TagScanner.Controls
{
    using System;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;

    [ToolStripItemDesignerAvailability(
        ToolStripItemDesignerAvailability.ToolStrip |
        ToolStripItemDesignerAvailability.MenuStrip |
        ToolStripItemDesignerAvailability.ContextMenuStrip)]
    public class ToolStripDateTimePicker : ToolStripControl<DateTimePicker>
    {
        #region Constructor

        public ToolStripDateTimePicker() : base() { }

        #endregion

        #region Public Properties

        public bool Checked
        {
            get => Guest.Checked;
            set => Guest.Checked = value;
        }

        public string CustomFormat
        {
            get => Guest.CustomFormat;
            set => Guest.CustomFormat = value;
        }

        public DateTimePickerFormat Format
        {
            get => Guest.Format;
            set => Guest.Format = value;
        }

        public bool ShowCheckBox
        {
            get => Guest.ShowCheckBox;
            set => Guest.ShowCheckBox = value;
        }

        public bool ShowUpDown
        {
            get => Guest.ShowUpDown;
            set => Guest.ShowUpDown = value;
        }

        public DateTime Value
        {
            get => Guest.Value;
            set => Guest.Value = value;
        }

        #endregion

        #region Public Events

        public event EventHandler ValueChanged;

        #endregion

        #region Protected Methods

        protected override void OnSubscribeEvents(DateTimePicker dateTimePicker)
        {
            dateTimePicker.ValueChanged += OnValueChanged;
        }

        protected override void OnUnsubscribeEvents(DateTimePicker dateTimePicker)
        {
            dateTimePicker.ValueChanged -= OnValueChanged;
        }

        #endregion

        #region Event Handlers

        private void OnValueChanged(object sender, EventArgs e) => ValueChanged?.Invoke(this, EventArgs.Empty);

        #endregion
    }
}
