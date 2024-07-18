namespace TagScanner.Controls
{
    using System.Windows.Forms;

    public class ToolStripControl<T> : ToolStripControlHost where T : Control, new()
    {
        #region Constructor

        public ToolStripControl() : base(new T()) { }

        #endregion

        #region Public Properties

        public T Guest => base.Control as T;

        #endregion

        #region Protected Methods

        protected override void OnSubscribeControlEvents(Control control)
        {
            base.OnSubscribeControlEvents(control);
            OnSubscribeEvents((T)control);
        }

        protected override void OnUnsubscribeControlEvents(Control control)
        {
            base.OnUnsubscribeControlEvents(control);
            OnUnsubscribeEvents((T)control);
        }

        protected virtual void OnSubscribeEvents(T control) { }
        protected virtual void OnUnsubscribeEvents(T control ) { }

        #endregion
    }
}
