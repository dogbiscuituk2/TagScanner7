namespace TagScanner.Controllers
{
    using System.Diagnostics;
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

        #region Private Fields

        private CheckedListBox _control;

        #endregion

        #region Event Handlers

        private void Control_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var newValue = NextState();
            Debug.WriteLine(newValue);
            e.NewValue = newValue;

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
