namespace TagScanner.Controllers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows.Data;
    using System.Windows.Forms;
    using Commands;
    using Forms;
    using Models;
    using Properties;
    using Terms;
    using Utils;

    public class FindReplaceController : Controller
    {
        #region Constructor

        public FindReplaceController(Controller parent) : base(parent)
        {
            ParentControl = View.Parent;
            Toolbar = View.Toolbar;
            TbDropDown = View.tbDropDown;
            CbFind = View.cbFind;
            TbFind = View.tbFind;
            TbFindNext = View.tbFindNext;
            TbFindPrevious = View.tbFindPrevious;
            TbFindAll = View.tbFindAll;
            TbFindClose = View.tbFindClose;
            TbPreserveCase = View.tbPreserveCase;
            CbReplace = View.cbReplace;
            TbReplaceNext = View.tbReplaceNext;
            TbReplaceAll = View.tbReplaceAll;
            TbCaseSensitive = View.tbCaseSensitive;
            TbWholeWord = View.tbWholeWord;
            TbUseRegex = View.tbUseRegex;
            TbSearchFields = View.tbSearchFields;

            PopupFindNext = MainForm.PopupFindNext;
            PopupFindPrevious = MainForm.PopupFindPrevious;
            PopupFindAll = MainForm.PopupFindAll;
            PopupReplaceNext = MainForm.PopupReplaceNext;
            PopupReplaceAll = MainForm.PopupReplaceAll;

            Hide();

            MainForm.EditFind.Click += EditFind_Click;
            MainForm.tbFindReplace.ButtonClick += EditFind_Click;
            MainForm.tbFind.Click += EditFind_Click;
            MainForm.EditReplace.Click += EditReplace_Click;
            MainForm.tbReplace.Click += EditReplace_Click;

            MainForm.PopupSearchFields.Click += TbSearchFields_Click;
            MainForm.PopupMatchCase.Click += TbCaseSensitive_Click;
            MainForm.PopupWholeWord.Click += TbWholeWord_Click;
            MainForm.PopupUseRegex.Click += TbUseRegex_Click;
            MainForm.PopupPreserveCase.Click += TbPreserveCase_Click;
            MainForm.PopupCloseFindReplace.Click += TbFindClose_Click;

            TbDropDown.Click += TbDropDown_Click;
            CbFind.DropDown += CbFind_DropDown;
            CbFind.TextChanged += CbFind_TextChanged;
            TbFind.ButtonClick += TbFind_ButtonClick;
            TbFindNext.Click += TbFindNext_Click;
            TbFindPrevious.Click += TbFindPrevious_Click;
            TbFindAll.Click += TbFindAll_Click;
            TbFindClose.Click += TbFindClose_Click;
            TbPreserveCase.Click += TbPreserveCase_Click;
            CbReplace.DropDown += CbReplace_DropDown;
            CbReplace.TextChanged += CbReplace_TextChanged;
            TbReplaceNext.Click += TbReplaceNext_Click;
            TbReplaceAll.Click += TbReplaceAll_Click;
            TbCaseSensitive.Click += TbCaseSensitive_Click;
            TbWholeWord.Click += TbWholeWord_Click;
            TbUseRegex.Click += TbUseRegex_Click;
            TbSearchFields.Click += TbSearchFields_Click;

            PopupFindNext.Click += TbFindNext_Click;
            PopupFindPrevious.Click += TbFindPrevious_Click;
            PopupFindAll.Click += TbFindAll_Click;
            PopupReplaceNext.Click += TbReplaceNext_Click;
            PopupReplaceAll.Click += TbReplaceAll_Click;

            View.Resize += View_Resize;

            SearchTags = new List<Tag> { Tag.Album, Tag.Artists, Tag.Title };
        }

        #endregion

        #region Public Methods

        public void UpdateAutoComplete()
        {
            UpdateAutoComplete(CbFind);
            UpdateAutoComplete(CbReplace);
            UpdateUI();
        }

        #endregion

        #region Fields

        private List<Tag> SearchTags
        {
            get => _searchTags;
            set
            {
                _searchTags = value;
                var any = value.Any();
                TbSearchFields.ToolTipText = !any ? "(none)" :
                    value.Select(p => p.DisplayName()).Aggregate((p, q) => $"{p}, {q}");
                UpdateUI();
            }
        }

        private int
            SearchIndex = 0,
            SearchCount = 0;

        private bool SearchForward = true;
        private List<Tag>
            _searchTags = new List<Tag>(),
            _replaceTags = new List<Tag>();
        private bool SearchValid;
        private readonly Selection Selection = new Selection();

        #endregion

        #region Controls

        private ListCollectionView ListCollectionView => MainTableController.ListCollectionView;
        private FindReplaceControl View => MainForm.FindReplaceControl;
        private System.Windows.Controls.DataGrid DataGrid => MainTableController.DataGrid;

        private readonly Control ParentControl;

        private readonly ToolStrip
            Toolbar;

        private readonly ToolStripButton
            TbCaseSensitive,
            TbDropDown,
            TbFindClose,
            TbPreserveCase,
            TbReplaceAll,
            TbReplaceNext,
            TbSearchFields,
            TbUseRegex,
            TbWholeWord;

        private readonly ToolStripComboBox
            CbFind,
            CbReplace;

        private readonly ToolStripMenuItem
            TbFindAll,
            TbFindNext,
            TbFindPrevious,
            PopupFindAll,
            PopupFindNext,
            PopupFindPrevious,
            PopupReplaceAll,
            PopupReplaceNext;

        private readonly ToolStripSplitButton
            TbFind;

        #endregion

        #region Properties

        private RegexOptions RegexOptions => CaseSensitive.AsRegexOptions();

        private bool CaseSensitive
        {
            get => TbCaseSensitive.Checked;
            set
            {
                if (CaseSensitive != value)
                {
                    TbCaseSensitive.Checked = value;
                    SearchValid = false;
                }
            }
        }

        private string SearchText => CbFind.Text;

        private string SearchPattern
        {
            get
            {
                var pattern = SearchText;
                if (!UseRegex)
                    pattern = Regex.Escape(pattern);
                if (WholeWord)
                    pattern = $@"\b{pattern}\b";
                return pattern;
            }
        }

        private bool PreserveCase
        {
            get => TbPreserveCase.Checked;
            set => TbPreserveCase.Checked = value;
        }

        private bool Replacing
        {
            get => CbReplace.Visible;
            set
            {
                TbPreserveCase.Visible =
                    CbReplace.Visible =
                    TbReplaceNext.Visible =
                    TbReplaceAll.Visible =
                    MainForm.PopupReplaceNext.Visible =
                    MainForm.PopupReplaceAll.Visible =
                    MainForm.PopupReplaceSeparator.Visible =
                    value;
                TbDropDown.Image = value ? Resources.frCloseUp : Resources.frDropDown;
            }
        }

        private bool UseRegex
        {
            get => TbUseRegex.Checked;
            set
            {
                if (UseRegex != value)
                {
                    TbUseRegex.Checked = value;
                    SearchValid = false;
                }
            }
        }

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

        private bool WholeWord
        {
            get => TbWholeWord.Checked;
            set
            {
                if (WholeWord != value)
                {
                    TbWholeWord.Checked = value;
                    SearchValid = false;
                }
            }
        }

        #endregion

        #region Event Handlers

        private void CbFind_DropDown(object sender, EventArgs e) => AppController.GetFindItems(CbFind.Items);
        private void CbFind_TextChanged(object sender, EventArgs e) { UpdateUI(); SearchValid = false; }
        private void CbReplace_DropDown(object sender, EventArgs e) => AppController.GetReplaceItems(CbReplace.Items);
        private void CbReplace_TextChanged(object sender, EventArgs e) => UpdateUI();
        private void EditFind_Click(object sender, EventArgs e) => Show(replace: false);
        private void EditReplace_Click(object sender, EventArgs e) => Show(replace: true);
        private void TbCaseSensitive_Click(object sender, EventArgs e) => ToggleCaseSensitive();
        private void TbDropDown_Click(object sender, EventArgs e) => Show(replace: !Replacing);
        private void TbFind_ButtonClick(object sender, EventArgs e) { if (SearchForward) FindNext(); else FindPrevious(); }
        private void TbFindAll_Click(object sender, EventArgs e) => FindAll();
        private void TbFindClose_Click(object sender, EventArgs e) => ShowFindReplace(visible: false);
        private void TbFindNext_Click(object sender, EventArgs e) => FindNext();
        private void TbFindPrevious_Click(object sender, EventArgs e) => FindPrevious();
        private void TbPreserveCase_Click(object sender, EventArgs e) => TogglePreserveCase();
        private void TbReplaceAll_Click(object sender, EventArgs e) => ReplaceAll();
        private void TbReplaceNext_Click(object sender, EventArgs e) => ReplaceNext();
        private void TbSearchFields_Click(object sender, EventArgs e) => ChooseSearchFields();
        private void TbUseRegex_Click(object sender, EventArgs e) => ToggleUseRegex();
        private void TbWholeWord_Click(object sender, EventArgs e) => ToggleWholeWord();
        private void View_Resize(object sender, EventArgs e) => Resize();

        #endregion

        #region Private Methods

        private void FindNext() => FindStep(delta: +1);
        private void FindPrevious() => FindStep(delta: -1);
        private void Hide() => ShowFindReplace(visible: false);
        private void Resize() => CbFind.Size = CbReplace.Size = new Size(View.Width - 81, CbFind.Height);
        private void Show(bool replace) => ShowFindReplace(visible: true, replacing: replace);
        private void ToggleCaseSensitive() => CaseSensitive ^= true;
        private void TogglePreserveCase() => PreserveCase ^= true;
        private void ToggleUseRegex() => UseRegex ^= true;
        private void ToggleWholeWord() => WholeWord ^= true;
        private void UpdateFindItems() => AppController.UpdateFindItems(items: CbFind.Items, item: CbFind.Text);
        private void UpdateReplaceItems() => AppController.UpdateReplaceItems(items: CbReplace.Items, item: CbReplace.Text);

        private void ChooseSearchFields()
        {
            var tags = SearchTags.ToList();
            var ok = new TagsSelectorController(this, p => p.CanWrite() && (p.Type() == typeof(string) || p.Type() == typeof(string[])))
                .Execute("Select the Fields to be used in the Search or Replace operation", tags);
            if (ok)
                SearchTags = tags;
        }

        private bool Find()
        {
            if (!SearchValid)
            {
                UpdateFindItems();
                UpdateReplaceItems();
                var term = MakeCondition();
                AppController.AddFilter(term.ToString());
                var visibleTracks = VisibleTracks;
                var tracks = term.Filter(visibleTracks);
                var tracksArray = tracks.ToArray();
                Selection.Clear();
                Selection.Add(tracksArray);
                SearchValid = Selection.Tracks.Any();
                if (!SearchValid)
                    MessageBox.Show(
                        MainForm,
                        $"The following specified text was not found:{Environment.NewLine}{CbFind.Text}",
                        "Find and Replace",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
            SearchCount = Selection.Tracks.Count;
            SearchIndex = 0;
            return SearchValid;
        }

        private void FindAll()
        {
            if (Find())
                AppController.NewWindow(
                    nameFormat: "<find results {0}>",
                    selection: Selection,
                    modified: false);
        }

        private bool FindStep(int delta)
        {
            UpdateFindButton(forward: delta > 0);
            if (SearchValid)
            {
                SearchIndex += delta;
                if (SearchIndex >= SearchCount)
                    SearchIndex = 0;
                else if (SearchIndex < 0)
                    SearchIndex = SearchCount - 1;
            }
            else
                Find();
            if (SearchIndex < 0 || SearchIndex >= SearchCount)
                return false;
            var track = Selection.Tracks[SearchIndex];
            MainTableController.Selection = new Selection(new[] { track });
            DataGrid.ScrollIntoView(track);
            DataGrid.Focus();
            return true;
        }

        private Term MakeCondition()
        {
            var selectedTags = SearchTags;
            if (!selectedTags.Any())
                return true;
            if (string.IsNullOrWhiteSpace(CbFind.Text))
                return true;
            var terms = new List<Term> { Environment.NewLine };
            terms.AddRange(selectedTags.Select(p => new Field(p)));
            return new Function(
                Fn.ContainsX,
                new Function(Fn.Join, terms.ToArray()),
                SearchPattern,
                CaseSensitive);
        }

        private bool Replace(bool all)
        {
            if (!FindStep(+1))
                return false;
            var tags = SearchTags.ToList();
            var tagsCount = tags.Count();
            var tracks = Selection.Tracks;
            if (!all)
                tracks = new List<Track> { tracks[SearchIndex] };
            var tracksCount = tracks.Count;
            var values = new object[tracksCount, tagsCount];
            var pattern = SearchPattern;
            var options = RegexOptions;
            for (var trackIndex = 0; trackIndex < tracksCount; trackIndex++)
            {
                var track = tracks[trackIndex];
                for (var tagIndex = 0; tagIndex < tagsCount; tagIndex++)
                {
                    var value = track.GetPropertyValue(tags[tagIndex]);
                    if (value is string s)
                        value = Regex.Replace(s, pattern, CbReplace.Text, options);
                    else if (value is string[] ss)
                        value = ss.Select(p => Regex.Replace(p, pattern, CbReplace.Text, options)).ToArray();
                    values[trackIndex, tagIndex] = value;
                }
            }
            var command = new ReplaceCommand(new Selection(tracks), tags.ToArray(), values);
            MainCommandProcessor.Run(command);
            return true;
        }

        private void ReplaceAll() => Replace(all: true);
        private void ReplaceNext() => Replace(all: false);

        private void ShowFindReplace(bool visible, bool replacing = false)
        {
            ParentControl.Visible = visible;
            Replacing = replacing;
            if (visible)
            {
                ParentControl.Size = new Size(ParentControl.Width, replacing ? 92 : 69);
                CbFind.Focus();
            }
        }

        private void UpdateAutoComplete(ToolStripComboBox comboBox) =>
            comboBox.AutoCompleteCustomSource = MainAutoCompleter.GetFieldList(Tag.JoinedPerformers, Tag.Album, Tag.Title);

        private void UpdateFindButton(bool forward)
        {
            if (SearchForward != forward)
            {
                SearchForward = forward;
                TbFind.Image = forward ? TbFindNext.Image : TbFindPrevious.Image;
                UpdateUI();
            }
        }

        private void UpdateUI()
        {
            bool
                anyTracks = VisibleTracks.Any(),
                anyFindTags = SearchTags.Any(),
                anyFindText = !string.IsNullOrEmpty(CbFind.Text),
                anyReplaceTags = SearchTags.Any(p => p.CanWrite()),
                anyReplaceText = !string.IsNullOrEmpty(CbReplace.Text),
                canFind = anyTracks && anyFindTags && anyFindText,
                canReplace = canFind && anyReplaceTags; // !anyReplaceText => warning only.
            string
                findReason = !anyTracks ? _noTracks : !anyFindTags ? _noFindTags : _noFindTerm,
                replaceReason = !canFind ? findReason : !anyReplaceTags ? _noReplaceTags : _noReplaceTerm;
            Color
                window = Color.FromKnownColor(KnownColor.Window);

            CbFind.BackColor = anyFindText ? window : Color.MistyRose;
            CbFind.ToolTipText = anyFindText ? _findTerm : _noFindTerm;
            CbReplace.BackColor = anyReplaceText ? window : Color.MistyRose;
            CbReplace.ToolTipText = anyReplaceText ? _replaceTerm : _noReplaceTerm;

            TbFind.Enabled =
                TbFindNext.Enabled = PopupFindNext.Enabled =
                TbFindPrevious.Enabled = PopupFindPrevious.Enabled =
                TbFindAll.Enabled = PopupFindAll.Enabled = canFind;

            TbReplaceNext.Enabled = PopupReplaceNext.Enabled =
                TbReplaceAll.Enabled = PopupReplaceAll.Enabled = canReplace;

            TbFind.ToolTipText = canFind ? SearchForward ? _findNext : _findPrevious : findReason;
            TbReplaceNext.ToolTipText = canReplace ? _replaceNext : replaceReason;
            TbReplaceAll.ToolTipText = canReplace ? _replaceAll : replaceReason;
        }

        #endregion

        #region TODO: Localize

        private const string
            _findNext = "Find next (F3)",
            _findPrevious = "Find previous (Shift+F3)",
            _replaceNext = "Replace next (Alt+R)",
            _replaceAll = "Replace all (Alt+A)",
            _noTracks = "There are no tracks to search.",
            _noFindTags = "There are no data fields to search.",
            _findTerm = "Search term",
            _noFindTerm = "Search term is blank.",
            _noReplaceTags = "There are no writable fields to update.",
            _replaceTerm = "Replacement term",
            _noReplaceTerm = "Replacement term is blank.";

        #endregion
    }
}
