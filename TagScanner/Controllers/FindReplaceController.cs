namespace TagScanner.Controllers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows.Data;
    using System.Windows.Forms;
    using Models;
    using Commands;
    using Terms;
    using Utils;
    using Views;

    public class FindReplaceController : Controller
    {
        #region Constructor

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

        #endregion

        #region Fields

        private readonly Selection Selection = new Selection();
        private readonly TagsListController TagsListController;

        #endregion

        #region Properties

        private ListCollectionView ListCollectionView => MainTableController.ListCollectionView;

        private bool CaseSensitive => CaseSensitiveCheckBox.Checked;
        private RegexOptions RegexOptions => CaseSensitive.AsRegexOptions();
        private IEnumerable<Tag> SelectedTags => TagsListController.GetSelectedTags();
        private bool UseRegex => UseRegexCheckBox.Checked;
        private bool WholeWord => WholeWordCheckBox.Checked;

        private string Pattern
        {
            get
            {
                var pattern = FindComboBox.Text;
                if (!UseRegex)
                    pattern = Regex.Escape(pattern);
                if (WholeWord)
                    pattern = $@"\W{pattern}\W";
                return pattern;
            }
        }

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

        private RadioButton FindRadioButton => MainForm.rbFind;
        private RadioButton ReplaceRadioButton => MainForm.rbReplace;

        private SplitContainer ClientSplitContainer => MainForm.ClientSplitContainer;
        private ListView TagsListView => MainForm.TagsListView;

        #endregion

        #region Event Handlers

        private void FindComboBox_DropDown(object sender, EventArgs e) => AppController.GetFindItems(FindComboBox);
        private void ReplaceComboBox_DropDown(object sender, EventArgs e) => AppController.GetReplaceItems(ReplaceComboBox);

        private void Option_CheckedChanged(object sender, EventArgs e) => UpdateUI();

        private void BtnClose_Click(object sender, EventArgs e) => Hide();
        private void BtnFindAll_Click(object sender, EventArgs e) => FindAll();
        private void BtnFindNext_Click(object sender, EventArgs e) => FindNext();
        private void BtnFindPrevious_Click(object sender, EventArgs e) => FindPrevious();
        private void BtnReplaceAll_Click(object sender, EventArgs e) => ReplaceAll();
        private void BtnReplaceNext_Click(object sender, EventArgs e) => ReplaceNext();

        private void EditFind_Click(object sender, EventArgs e) => Show(replace: false);
        private void EditReplace_Click(object sender, EventArgs e) => Show(replace: true);

        #endregion

        #region Methods

        private IEnumerable<Track> VisibleTracks
        {
            get
            {
                var enumerator = ((IEnumerable)ListCollectionView).GetEnumerator();
                while (true)
                {
                    if (enumerator.MoveNext() && enumerator.Current is Track track)
                        yield return track;
                    else
                        yield break;
                }
            }
        }

        private bool Find()
        {
            UpdateFindItems();
            var term = MakeCondition();
            AppController.AddFilter(term.ToString());
            var predicate = term.Predicate;
            var visibleTracks = VisibleTracks;
            var selection = new Selection(visibleTracks);
            var tracks = visibleTracks.Where(p => predicate(selection, p));
            var tracksArray = tracks.ToArray();
            Selection.Clear();
            Selection.Add(tracksArray);
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
            {
                AppController.NewWindow(
                    nameFormat: "<find results {0}>",
                    selection: Selection,
                    modified: false);
                //TableController.Selection = Selection;
                //TableController.DataGrid.ScrollIntoView(Selection.Tracks[0]);
                MainTableController.DataGrid.Focus();
                MainTableController.FindResults = Selection;
            }
        }

        private void FindNext()
        {
            UpdateFindItems();
        }

        private void FindPrevious()
        {
            UpdateFindItems();
        }

        private void Hide() => ShowFindReplace(visible: false);

        private Term MakeCondition()
        {
            var selectedTags = SelectedTags;
            if (!selectedTags.Any())
                return Term.True;
            if (string.IsNullOrWhiteSpace(FindComboBox.Text))
                return Term.True;
            var terms = new List<Term> { Environment.NewLine };
            terms.AddRange(selectedTags.Select(p => new TrackField(p)));
            return new Function(
                Fn.ContainsX,
                new Function(Fn.Join, terms.ToArray()),
                Pattern,
                CaseSensitive);
        }

        private void Replace()
        {

        }

        private void ReplaceAll()
        {
            if (Find())
            {
                var tracks = Selection.Tracks;
                var tracksCount = tracks.Count;
                var tags = SelectedTags.ToList();
                var tagsCount = tags.Count();
                var values = new object[tracksCount, tagsCount];
                var pattern = Pattern;
                var options = RegexOptions;
                for (var trackIndex = 0; trackIndex < tracksCount; trackIndex++)
                {
                    var track = tracks[trackIndex];
                    for (var tagIndex = 0; tagIndex < tagsCount; tagIndex++)
                    {
                        var tag = tags[tagIndex];
                        var value = track.GetPropertyValue(tag).ToString();
                        if (Regex.IsMatch(value, pattern, options))
                            value = Regex.Replace(value, pattern, ReplaceComboBox.Text, options);
                        values[trackIndex, tagIndex] = value;
                    }
                }
                var command = new ReplaceCommand(Selection, tags.ToArray(), values);
                MainCommandProcessor.Run(command);
            }
        }

        private void ReplaceNext()
        {
            UpdateReplaceItems();
        }

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

        #endregion
    }
}
