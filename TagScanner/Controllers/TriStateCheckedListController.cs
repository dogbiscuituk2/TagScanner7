namespace TagScanner.Controllers
{
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

        #region Public Methods

        public CheckState GetState(int index) => _control.GetItemCheckState(index);
        public void SetAllStates(CheckState value) { for (var index = 0; index < _control.Items.Count; index++) SetState(index, value); }
        public void SetState(int index, CheckState value) => _control.SetItemCheckState(index, value);

        #endregion

        #region Private Fields

        private CheckedListBox _control;

        #endregion

        #region Event Handlers

        private void Control_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            e.NewValue = NextState();

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
