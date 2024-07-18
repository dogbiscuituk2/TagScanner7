namespace TagScanner.Controls
{
    using System;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;

    [ToolStripItemDesignerAvailability(
        ToolStripItemDesignerAvailability.ToolStrip |
        ToolStripItemDesignerAvailability.MenuStrip |
        ToolStripItemDesignerAvailability.ContextMenuStrip)]
    public class ToolStripCheckBox : ToolStripControl<CheckBox>
    {
        #region Constructor

        public ToolStripCheckBox() : base() { }

        #endregion

        #region Public Properties

        public bool Checked
        {
            get => Guest.Checked;
            set => Guest.Checked = value;
        }

        public CheckState CheckState
        {
            get => Guest.CheckState;
            set => Guest.CheckState = value;
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
