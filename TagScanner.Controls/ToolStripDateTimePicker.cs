namespace TagScanner.Controls
{
    using System;
    using System.Windows.Forms;

    public class ToolStripDateTimePicker : ToolStripControl<DateTimePicker>
    {
        #region Constructor

        public ToolStripDateTimePicker() : base() { }

        #endregion

        #region Public Properties

        public bool Checked
        {
            get => Control.Checked;
            set => Control.Checked = value;
        }

        public string CustomFormat
        {
            get => Control.CustomFormat;
            set => Control.CustomFormat = value;
        }

        public DateTimePickerFormat Format
        {
            get => Control.Format;
            set => Control.Format = value;
        }

        public bool ShowCheckBox
        {
            get => Control.ShowCheckBox;
            set => Control.ShowCheckBox = value;
        }

        public bool ShowUpDown
        {
            get => Control.ShowUpDown;
            set => Control.ShowUpDown = value;
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
