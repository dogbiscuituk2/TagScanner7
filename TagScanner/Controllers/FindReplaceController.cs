namespace TagScanner.Controllers
{
    using System.Windows.Forms;
    using Views;

    public class FindReplaceController : Controller
    {
        public FindReplaceController(Controller parent) : base(parent)
        {
            MainForm.EditFind.Click += EditFind_Click;
            MainForm.EditReplace.Click += EditReplace_Click;

            BtnClose.Click += BtnClose_Click;
            rbFind.CheckedChanged += Option_CheckedChanged;
        }

        private void BtnClose_Click(object sender, System.EventArgs e) => FindReplace.Hide();
        private void EditFind_Click(object sender, System.EventArgs e) => ShowFindReplace(replace: false);
        private void EditReplace_Click(object sender, System.EventArgs e) => ShowFindReplace(replace: true);
        private void Option_CheckedChanged(object sender, System.EventArgs e) => UpdateUI();

        private Button BtnClose => MainForm.btnClose;
        private Button BtnFindAll => MainForm.btnFindAll;
        private Button BtnReplaceAll => MainForm.btnReplaceAll;
        private Button BtnReplaceNext => MainForm.btnReplaceNext;
        private ComboBox cbFind => MainForm.FindComboBox;
        private CheckBox cbPreserveCase => MainForm.cbPreserveCase;
        private ComboBox cbReplace => MainForm.ReplaceComboBox;
        private GroupBox FindReplace => MainForm.gbFindReplace;
        private MainForm MainForm => MainFormController.View;
        private MainFormController MainFormController => (MainFormController)Parent;
        private RadioButton rbFind => MainForm.rbFind;
        private RadioButton rbReplace => MainForm.rbReplace;

        private void ShowFindReplace(bool replace)
        {
            FindReplace.Visible = true;
            rbFind.Checked = !replace;
            rbReplace.Checked = replace;
            cbFind.Focus();
            UpdateUI();
        }

        private void UpdateUI()
        {
            var replacing = rbReplace.Checked;
            cbReplace.Enabled =
                cbPreserveCase.Visible =
                BtnReplaceNext.Visible =
                BtnReplaceAll.Visible =
                replacing;
            BtnFindAll.Visible = !replacing;
        }
    }
}
