namespace TagScanner.Controllers
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Models;
    using Terms;
    using Views;

    public class FindReplaceController : Controller
    {
        public FindReplaceController(Controller parent) : base(parent)
        {
            Hide();
            TagsListController = new TagsListController(this, TagsListView);
            TagsListController.InitListView();
            MainForm.EditFind.Click += EditFind_Click;
            MainForm.tbFind.Click += EditFind_Click;
            MainForm.EditReplace.Click += EditReplace_Click;
            FindComboBox.DropDown += FindComboBox_DropDown;
            FindRadioButton.CheckedChanged += Option_CheckedChanged;
            ReplaceComboBox.DropDown += ReplaceComboBox_DropDown;
            ReplaceRadioButton.CheckedChanged += Option_CheckedChanged;
            BtnClose.Click += BtnClose_Click;
            BtnFindAll.Click += BtnFindAll_Click;
            BtnFindNext.Click += BtnFindNext_Click;
            BtnFindPrevious.Click += BtnFindPrevious_Click;
            BtnReplaceAll.Click += BtnReplaceAll_Click;
            BtnReplaceNext.Click += BtnReplaceNext_Click;
        }

        private readonly Selection Selection = new Selection();
        private readonly TagsListController TagsListController;

        private void FindComboBox_DropDown(object sender, EventArgs e) => AppController.GetFindItems(FindComboBox);
        private void ReplaceComboBox_DropDown(object sender, EventArgs e) => AppController.GetReplaceItems(ReplaceComboBox);

        private void BtnClose_Click(object sender, EventArgs e) => Hide();
        private void BtnFindAll_Click(object sender, EventArgs e) => FindAll();
        private void BtnFindNext_Click(object sender, EventArgs e) => FindNext();
        private void BtnFindPrevious_Click(object sender, EventArgs e) => FindPrevious();
        private void BtnReplaceAll_Click(object sender, EventArgs e) => ReplaceAll();
        private void BtnReplaceNext_Click(object sender, EventArgs e) => ReplaceNext();

        private void EditFind_Click(object sender, EventArgs e) => Show(replace: false);
        private void EditReplace_Click(object sender, EventArgs e) => Show(replace: true);
        private void Option_CheckedChanged(object sender, EventArgs e) => UpdateUI();

        private Button BtnClose => MainForm.btnClose;
        private Button BtnFindAll => MainForm.btnFindAll;
        private Button BtnFindNext => MainForm.btnFindNext;
        private Button BtnFindPrevious => MainForm.btnFindPrevious;
        private Button BtnReplaceAll => MainForm.btnReplaceAll;
        private Button BtnReplaceNext => MainForm.btnReplaceNext;
        private Button BtnSkipTrack => MainForm.btnSkipTrack;

        private CheckBox CaseSensitiveCheckBox => MainForm.cbMatchCase;
        private CheckBox WholeWordCheckBox => MainForm.cbMatchWholeWord;
        private CheckBox UseRegexCheckBox => MainForm.cbUseRegex;

        private ComboBox FindComboBox => MainForm.FindComboBox;
        private ComboBox ReplaceComboBox => MainForm.ReplaceComboBox;

        private SplitContainer ClientSplitContainer => MainForm.ClientSplitContainer;

        private MainForm MainForm => MainFormController.View;
        private MainFormController MainFormController => (MainFormController)Parent;

        private RadioButton FindRadioButton => MainForm.rbFind;
        private RadioButton ReplaceRadioButton => MainForm.rbReplace;

        private ListView TagsListView => MainForm.TagsListView;

        private bool CaseSensitive => CaseSensitiveCheckBox.Checked;
        private bool WholeWord => WholeWordCheckBox.Checked;
        private bool UseRegex => UseRegexCheckBox.Checked;

        private Term MakeCondition()
        {
            var selectedTags = TagsListController.GetSelectedTags();
            if (!selectedTags.Any())
                return Term.True;
            var value = FindComboBox.Text;
            if (string.IsNullOrWhiteSpace(value))
                return Term.True;
            if (!UseRegex)
                value = Regex.Escape(value);
            if (WholeWord)
                value = $@"\W{value}\W";
            if (selectedTags.Count() == 1)
                return MakeSimpleCondition(selectedTags.First(), value);
            var term = new Disjunction();
            term.Operands.Clear();
            foreach (var tag in selectedTags)
                term.Operands.Add(MakeSimpleCondition(tag, value));
            return term;
        }

        private Func<Track, bool> MakePredicate() => MakeCondition().Predicate;

        private Term MakeSimpleCondition(Tag tag, string value)
        {
            var options = CaseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase;
            return new Function(Fn.Match_, tag, value, new Constant<RegexOptions>(options));
        }

        private bool Find()
        {
            UpdateFindItems();
            var predicate = MakePredicate();
            Selection.Clear();
            Selection.Add(MainFormController.Model.Tracks.Where(p => predicate(p)));
            var result = Selection.Tracks.Any();
            if (!result)
                MessageBox.Show(
                    MainForm,
                    $"The following specified text was not found:{Environment.NewLine}{FindComboBox.Text}",
                    "Find and Replace",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            return result;
        }

        private void FindAll()
        {
            if (Find())
                AppController.NewWindow(
                    nameFormat: "<find results {0}>",
                    selection: Selection,
                    modified: false);
        }

        private void FindNext()
        {
            UpdateFindItems();
        }

        private void FindPrevious()
        {
            UpdateFindItems();
        }

        private void Replace()
        {

        }

        private void ReplaceAll()
        {
            if (Find())
            {

            }

        }

        private void ReplaceNext()
        {
            UpdateReplaceItems();
        }

        private void Hide() => ShowFindReplace(visible: false);

        private void Show(bool replace) => ShowFindReplace(visible: true, replacing: replace);

        private void ShowFindReplace(bool visible, bool replacing = false)
        {
            ClientSplitContainer.Panel1Collapsed = !visible;
            if (visible)
            {
                FindRadioButton.Checked = !replacing;
                ReplaceRadioButton.Checked = replacing;
                FindComboBox.Focus();
                UpdateUI();
            }
        }

        private void UpdateFindItems() => AppController.UpdateFindItems(FindComboBox);
        private void UpdateReplaceItems() => AppController.UpdateReplaceItems(ReplaceComboBox);

        private void UpdateUI()
        {
            var replacing = ReplaceRadioButton.Checked;
            TagsListController.InitItems(!replacing);
            TagsListController.SetSelectedTags(new[] { Tag.Title, Tag.Album, Tag.JoinedPerformers });
            ReplaceComboBox.Enabled =
                BtnReplaceNext.Visible =
                BtnReplaceAll.Visible = replacing;
            BtnFindAll.Visible = !replacing;
        }
    }
}
