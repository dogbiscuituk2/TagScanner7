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

        public CheckState CheckState
        {
            get => Control.CheckState;
            set => Control.CheckState = value;
        }

        public override string Text
        {
            get => Control.Text;
            set => Control.Text = value;
        }

        #endregion

        #region Public Events

        public event EventHandler CheckStateChanged;

        #endregion

        #region Protected Methods

        protected override void OnSubscribeEvents(CheckBox checkBox)
        {
            checkBox.CheckStateChanged += OnCheckStateChanged;
        }

        protected override void OnUnsubscribeEvents(CheckBox checkBox)
        {
            checkBox.CheckStateChanged -= OnCheckStateChanged;
        }

        #endregion

        #region Event Handlers

        private void OnCheckStateChanged(object sender, EventArgs e) =>
            CheckStateChanged?.Invoke(this, EventArgs.Empty);

        #endregion
    }
}
