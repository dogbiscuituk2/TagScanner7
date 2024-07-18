namespace TagScanner.Controls
{
    using System;
    using System.Windows.Forms;

    public class ToolStripCheckBox : ToolStripControl<CheckBox>
    {
        #region Constructor

        public ToolStripCheckBox() : base() { }

        #endregion

        #region Public Properties

        public bool Checked
        {
            get => Control.Checked;
            set => Control.Checked = value;
        }

        public CheckState CheckState
        {
            get => Control.CheckState;
            set => Control.CheckState = value;
        }

        #endregion

        #region Public Events

        public event EventHandler CheckedChanged;
        public event EventHandler CheckStateChanged;

        #endregion

        #region Protected Methods

        protected override void OnSubscribeEvents(CheckBox checkBox)
        {
            checkBox.CheckedChanged += OnCheckedChanged;
            checkBox.CheckStateChanged += OnCheckStateChanged;
        }

        protected override void OnUnsubscribeEvents(CheckBox checkBox)
        {
            checkBox.CheckedChanged -= OnCheckedChanged;
            checkBox.CheckStateChanged -= OnCheckStateChanged;
        }

        #endregion

        #region Event Handlers

        private void OnCheckedChanged(object sender, EventArgs e) => CheckedChanged?.Invoke(this, EventArgs.Empty);
        private void OnCheckStateChanged(object sender, EventArgs e) => CheckStateChanged?.Invoke(this, EventArgs.Empty);

        #endregion
    }
}
