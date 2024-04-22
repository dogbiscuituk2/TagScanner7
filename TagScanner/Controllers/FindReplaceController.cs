namespace TagScanner.Controllers
{
    using System.Windows.Forms;
    using Views;

    public class FindReplaceController : Controller
    {
        public FindReplaceController(Controller parent) : base(parent)
        {
            Hide();
            TagsListController = new TagsListController(this, TagsListView);
            TagsListController.InitListView();
            MainForm.EditFind.Click += EditFind_Click;
            MainForm.EditReplace.Click += EditReplace_Click;
            BtnClose.Click += BtnClose_Click;
            FindRadioButton.CheckedChanged += Option_CheckedChanged;
        }

        private readonly TagsListController TagsListController;

        private void BtnClose_Click(object sender, System.EventArgs e) => Hide();
        private void EditFind_Click(object sender, System.EventArgs e) => Show(replace: false);
        private void EditReplace_Click(object sender, System.EventArgs e) => Show(replace: true);
        private void Option_CheckedChanged(object sender, System.EventArgs e) => UpdateUI();

        private Button BtnClose => MainForm.btnClose;
        private Button BtnFindAll => MainForm.btnFindAll;
        private Button BtnReplaceAll => MainForm.btnReplaceAll;
        private Button BtnReplaceNext => MainForm.btnReplaceNext;
        private ComboBox FindComboBox => MainForm.FindComboBox;
        private CheckBox PreserveCaseCheckBox => MainForm.cbPreserveCase;
        private ComboBox ReplaceComboBox => MainForm.ReplaceComboBox;
        private SplitContainer ClientSplitContainer => MainForm.ClientSplitContainer;
        private GroupBox FindReplace => MainForm.gbFindReplace;
        private MainForm MainForm => MainFormController.View;
        private MainFormController MainFormController => (MainFormController)Parent;
        private RadioButton FindRadioButton => MainForm.rbFind;
        private RadioButton ReplaceRadioButton => MainForm.rbReplace;
        private ListView TagsListView => MainForm.TagsListView;

        private void Hide() => ShowFindReplace(visible: false);
        private void Show(bool replace) => ShowFindReplace(visible: true, replacing: replace);

        private void ShowFindReplace(bool visible, bool replacing = false)
        {
            ClientSplitContainer.Panel1Collapsed = !visible;
            if (visible)
            {
                FindReplace.Visible = true;
                FindRadioButton.Checked = !replacing;
                ReplaceRadioButton.Checked = replacing;
                FindComboBox.Focus();
                UpdateUI();
            }
        }

        private void UpdateUI()
        {
            var replacing = ReplaceRadioButton.Checked;
            TagsListController.InitItems(!replacing);
            ReplaceComboBox.Enabled =
                PreserveCaseCheckBox.Visible =
                BtnReplaceNext.Visible =
                BtnReplaceAll.Visible = replacing;
            BtnFindAll.Visible = !replacing;
        }
    }
}
