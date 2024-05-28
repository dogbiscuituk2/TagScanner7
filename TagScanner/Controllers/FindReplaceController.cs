namespace TagScanner.Controllers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;
    using System.Windows.Data;
    using System.Windows.Forms;
    using Commands;
    using Forms;
    using Models;
    using TagScanner.Properties;
    using Terms;
    using Utils;

    public class FindReplaceController : Controller
    {
        #region Constructor

        public FindReplaceController(Controller parent) : base(parent)
        {
            ParentControl = View.Parent;
            TbDropDown = View.tbDropDown;
            CbFind = View.cbFind;
            TbFind = View.tbFind;
            TbFindNext = View.tbFindNext;
            TbFindPrevious = View.tbFindPrevious;
            TbFindAll = View.tbFindAll;
            TbFindClose = View.tbFindClose;
            TbCloseUp = View.tbCloseUp;
            CbReplace = View.cbReplace;
            TbReplaceNext = View.tbReplaceNext;
            TbReplaceAll = View.tbReplaceAll;
            TbCaseSensitive = View.tbCaseSensitive;
            TbWholeWord = View.tbWholeWord;
            TbUseRegex = View.tbUseRegex;
            TbPickTags = View.tbPickTags;

            Hide();

            MainForm.EditFind.Click += EditFind_Click;
            MainForm.tbFindReplace.ButtonClick += TbFindReplace_ButtonClick;
            MainForm.tbFind.Click += EditFind_Click;
            MainForm.EditReplace.Click += EditReplace_Click;
            MainForm.tbReplace.Click += EditReplace_Click;

            MainForm.PopupSearchFields.Click += TbPickTags_Click;
            MainForm.PopupMatchCase.Click += TbCaseSensitive_Click;
            MainForm.PopupWholeWord.Click += TbWholeWord_Click;
            MainForm.PopupUseRegex.Click += TbUseRegex_Click;
            MainForm.PopupFindNext.Click += TbFindNext_Click;
            MainForm.PopupFindPrevious.Click += TbFindPrevious_Click;
            MainForm.PopupFindAll.Click += TbFindAll_Click;
            MainForm.PopupReplaceNext.Click += TbReplaceNext_Click;
            MainForm.PopupReplaceAll.Click += TbReplaceAll_Click;
            MainForm.PopupCloseFindReplace.Click += TbFindClose_Click;

            TbDropDown.Click += TbDropDown_Click;
            CbFind.DropDown += CbFind_DropDown;
            CbFind.TextChanged += CbFind_TextChanged;
            TbFindNext.Click += TbFindNext_Click;
            TbFindPrevious.Click += TbFindPrevious_Click;
            TbFindAll.Click += TbFindAll_Click;
            TbFindClose.Click += TbFindClose_Click;
            CbReplace.DropDown += CbReplace_DropDown;
            CbReplace.TextChanged += CbReplace_TextChanged;
            TbCloseUp.Click += TbCloseUp_Click;
            TbReplaceNext.Click += TbReplaceNext_Click;
            TbReplaceAll.Click += TbReplaceAll_Click;
            TbCaseSensitive.Click += TbCaseSensitive_Click;
            TbWholeWord.Click += TbWholeWord_Click;
            TbUseRegex.Click += TbUseRegex_Click;
            TbPickTags.Click += TbPickTags_Click;

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
                TbPickTags.ToolTipText = !any ? "(none)" :
                    value.Select(p => p.DisplayName()).Aggregate((p, q) => $"{p}, {q}");
                UpdateUI();
            }
        }

        private bool SearchForward = true;
        private List<Tag> _searchTags = new List<Tag>();
        private bool SearchValid;
        private readonly Selection Selection = new Selection();

        #endregion

        #region Controls

        private ListCollectionView ListCollectionView => MainTableController.ListCollectionView;
        private FindReplaceControl View => MainForm.FindReplaceControl;

        private readonly Control ParentControl;

        private readonly ToolStripButton
            TbCaseSensitive,
            TbCloseUp,
            TbDropDown,
            TbFindClose,
            TbPickTags,
            TbReplaceAll,
            TbReplaceNext,
            TbUseRegex,
            TbWholeWord;

        private readonly ToolStripComboBox
            CbFind,
            CbReplace;

        private readonly ToolStripMenuItem
            TbFindAll,
            TbFindNext,
            TbFindPrevious;

        private readonly ToolStripSplitButton
            TbFind;

        #endregion

        #region Properties

        private bool CaseSensitive { get => TbCaseSensitive.Checked; set => TbCaseSensitive.Checked = value; }
        private RegexOptions RegexOptions => CaseSensitive.AsRegexOptions();
        private bool UseRegex { get => TbUseRegex.Checked; set => TbUseRegex.Checked = value; }
        private bool WholeWord { get => TbWholeWord.Checked; set => TbWholeWord.Checked = value; }

        private string Pattern
        {
            get
            {
                var pattern = CbFind.Text;
                if (!UseRegex)
                    pattern = Regex.Escape(pattern);
                if (WholeWord)
                    pattern = $@"\b{pattern}\b";
                return pattern;
            }
        }

        private bool Replacing
        {
            get => TbCloseUp.Visible;
            set
            {
                TbCloseUp.Visible =
                    CbReplace.Visible =
                    TbReplaceNext.Visible =
                    TbReplaceAll.Visible =
                    MainForm.PopupReplaceNext.Visible =
                    MainForm.PopupReplaceAll.Visible =
                    MainForm.PopupReplaceSeparator.Visible =
                    value;
                TbDropDown.Image = value ? Properties.Resources.frCloseUp : Properties.Resources.frDropDown;
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

        #endregion

        #region Event Handlers

        private void CbFind_DropDown(object sender, EventArgs e) => AppController.GetFindItems(CbFind.Items);
        private void CbFind_TextChanged(object sender, EventArgs e) => SearchValid = false;
        private void CbReplace_DropDown(object sender, EventArgs e) => AppController.GetReplaceItems(CbReplace.Items);
        private void CbReplace_TextChanged(object sender, EventArgs e) => SearchValid = false;
        private void EditFind_Click(object sender, EventArgs e) => Show(replace: false);
        private void EditReplace_Click(object sender, EventArgs e) => Show(replace: true);
        private void TbCaseSensitive_Click(object sender, EventArgs e) => ToggleCaseSensitive();
        private void TbCloseUp_Click(object sender, EventArgs e) => Show(replace: false);
        private void TbDropDown_Click(object sender, EventArgs e) => Show(replace: !Replacing);
        private void TbFindAll_Click(object sender, EventArgs e) => FindAll();
        private void TbFindClose_Click(object sender, EventArgs e) => ShowFindReplace(visible: false);
        private void TbFindNext_Click(object sender, EventArgs e) => FindNext();
        private void TbFindPrevious_Click(object sender, EventArgs e) => FindPrevious();
        private void TbFindReplace_ButtonClick(object sender, EventArgs e) { if (SearchForward) FindNext(); else FindPrevious(); }
        private void TbPickTags_Click(object sender, EventArgs e) => PickTags();
        private void TbReplaceAll_Click(object sender, EventArgs e) => ReplaceAll();
        private void TbReplaceNext_Click(object sender, EventArgs e) => ReplaceNext();
        private void TbUseRegex_Click(object sender, EventArgs e) => ToggleUseRegex();
        private void TbWholeWord_Click(object sender, EventArgs e) => ToggleWholeWord();
        private void View_Resize(object sender, EventArgs e) => Resize();

        #endregion

        #region Private Methods

        private void Hide() => ShowFindReplace(visible: false);
        private void Resize() => CbFind.Size = CbReplace.Size = new Size(View.Width - 81, CbFind.Height);
        private void Show(bool replace) => ShowFindReplace(visible: true, replacing: replace);
        private void ToggleCaseSensitive() => CaseSensitive ^= true;
        private void ToggleUseRegex() => UseRegex ^= true;
        private void ToggleWholeWord() => WholeWord ^= true;
        private void UpdateFindItems() => AppController.UpdateFindItems(CbFind.Items, CbFind.Text);
        private void UpdateReplaceItems() => AppController.UpdateReplaceItems(CbReplace.Items, CbReplace.Text);

        private bool Find()
        {
            UpdateFindItems();
            var term = MakeCondition();
            AppController.AddFilter(term.ToString());
            var visibleTracks = VisibleTracks;
            var tracks = term.Filter(visibleTracks);
            var tracksArray = tracks.ToArray();
            Selection.Clear();
            Selection.Add(tracksArray);
            var result = Selection.Tracks.Any();
            if (!result)
                MessageBox.Show(
                    MainForm,
                    $"The following specified text was not found:{Environment.NewLine}{CbFind.Text}",
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
            UpdateFindButton(forward: true);
            UpdateFindItems();
        }

        private void FindPrevious()
        {
            UpdateFindButton(forward: false);
            UpdateFindItems();
        }

        private void Replace()
        {
            UpdateReplaceItems();
        }

        private void ReplaceAll()
        {
            UpdateReplaceItems();
            if (Find())
            {
                var tracks = Selection.Tracks;
                var tracksCount = tracks.Count;
                var tags = SearchTags.ToList();
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
                            value = Regex.Replace(value, pattern, CbReplace.Text, options);
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
                Pattern,
                CaseSensitive);
        }

        private void PickTags()
        {
            var tags = SearchTags.ToList();
            var ok = new TagsController(this).Execute("Select the Columns to display in the Media Table", tags);
            if (ok)
                SearchTags = tags;
        }

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
                InitFindButton(forward ? TbFindNext : TbFindPrevious);
            }

            void InitFindButton(ToolStripMenuItem item)
            {
                TbFind.Image = item.Image;
                TbFind.ToolTipText = item.ToolTipText;
            }
        }

        private void UpdateUI()
        {
            bool
                anySearchText = !string.IsNullOrEmpty(CbFind.Text),
                anyTags = SearchTags.Any(),
                anyTracks = MainModel.Tracks.Any();
            TbFind.Enabled =
                TbFindAll.Enabled =
                TbFindNext.Enabled =
                TbFindPrevious.Enabled =
                TbReplaceNext.Enabled =
                TbReplaceAll.Enabled =
                anySearchText && anyTags && anyTracks;
        }

        #endregion
    }
}
