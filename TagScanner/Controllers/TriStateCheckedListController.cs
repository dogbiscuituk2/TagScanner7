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
        public void SetAllStates(CheckState value) { for (var index = 0; index < _control.Items.Count; index++) SetState(index, value); }
        public void SetState(int index, CheckState value) => _control.SetItemCheckState(index, value);
        public void SetState(object item, CheckState value) => SetState(_control.Items.IndexOf(item), value);

        #endregion

        #region Protected Methods

        protected virtual void OnItemCheck(ItemCheckEventArgs e) => ItemCheck?.Invoke(this, e);

        #endregion

        #region Private Fields

        private CheckedListBox _control;
        private Dictionary<int, CheckState> _actualStates = new Dictionary<int, CheckState>();

        #endregion

        #region Event Handlers

        private void Control_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var newValue = NextState();
            e.NewValue = newValue;
            if (_actualStates.ContainsKey(e.Index))
                _actualStates[e.Index] = newValue;
            else
                _actualStates.Add(e.Index, newValue);
            OnItemCheck(e);

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
