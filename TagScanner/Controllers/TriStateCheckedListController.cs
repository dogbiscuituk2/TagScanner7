namespace TagScanner.Controllers
{
    using System.Collections.Generic;
    using System.Windows.Forms;

    public class TriStateCheckedListController : Controller
    {
        #region Constructor

        public TriStateCheckedListController(Controller parent, CheckedListBox control) : base(parent)
        {
            _control = control;
            _control.ItemCheck += Control_ItemCheck;
        }

        #endregion

        #region Public Events

        public event ItemCheckEventHandler ItemCheck;

        #endregion

        #region Public Methods

        public CheckState GetState(int index)
        {
            if (!_actualStates.TryGetValue(index, out CheckState state))
                state = _control.GetItemCheckState(index);
            return state;
        }

        public CheckState GetState(object item) => GetState(_control.Items.IndexOf(item));
        public void SetAllStates(CheckState newValue) { for (var index = 0; index < _control.Items.Count; index++) SetState(index, newValue); }
        public void SetState(object item, CheckState newValue) => SetState(_control.Items.IndexOf(item), newValue);

        public void SetState(int index, CheckState newValue)
        {
            var oldValue = GetState(index);
            _control.SetItemCheckState(index, newValue);
            if (_actualStates.ContainsKey(index))
                _actualStates[index] = newValue;
            else
                _actualStates.Add(index, newValue);
            OnItemCheck(new ItemCheckEventArgs(index, newValue, oldValue));
        }

        #endregion

        #region Protected Methods

        protected virtual void OnItemCheck(ItemCheckEventArgs e) => ItemCheck?.Invoke(this, e);

        #endregion

        #region Private Fields

        private Dictionary<int, CheckState> _actualStates = new Dictionary<int, CheckState>();
        private CheckedListBox _control;
        private bool _updating;

        #endregion

        #region Event Handlers

        private void Control_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_updating)
                return;
            _updating = true;
            SetState(e.Index, NextState());
            _updating = false;

            CheckState NextState()
            {
                switch (e.CurrentValue)
                {
                    case CheckState.Indeterminate: return CheckState.Checked;
                    case CheckState.Checked: return CheckState.Unchecked;
                    default: return CheckState.Indeterminate;
                }
            }
        }

        #endregion
    }
}
