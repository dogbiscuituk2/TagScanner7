namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Forms;
    using Models;

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
            MainForm.tbFindReplace.ButtonClick += EditFind_Click;
            MainForm.tbFind.Click += EditFind_Click;
            MainForm.EditReplace.Click += EditReplace_Click;
            MainForm.tbReplace.Click += EditReplace_Click;

            TbDropDown.Click += TbDropDown_Click;
            TbFindNext.Click += TbFindNext_Click;
            TbFindPrevious.Click += TbFindPrevious_Click;
            TbFindAll.Click += TbFindAll_Click;
            TbFindClose.Click += TbFindClose_Click;
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
        }

        #endregion

        #region Fields

        private List<Tag> _searchTags = new List<Tag>();

        private List<Tag> SearchTags
        {
            get => _searchTags;
            set
            {
                _searchTags = value;
                var any = value.Any();
                TbPickTags.ToolTipText = !any ? "(none)" :
                    value.Select(p => p.DisplayName()).Aggregate((p, q) => $"{p}, {q}");
                TbFind.Enabled =
                    TbFindAll.Enabled =
                    TbFindNext.Enabled =
                    TbFindPrevious.Enabled =
                    TbReplaceNext.Enabled =
                    TbReplaceAll.Enabled =
                    any;
            }
        }

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

        private readonly ToolStripSplitButton TbFind;

        #endregion

        #region Properties

        private FindReplaceControl View => MainForm.FindReplaceControl;

        private bool CaseSensitive { get => TbCaseSensitive.Checked; set => TbCaseSensitive.Checked = value; }
        private bool UseRegex { get => TbUseRegex.Checked; set => TbUseRegex.Checked = value; }
        private bool WhooleWord { get => TbWholeWord.Checked; set => TbWholeWord.Checked = value; }

        #endregion

        #region Event Handlers

        private void EditFind_Click(object sender, EventArgs e) => Show(replace: false);
        private void EditReplace_Click(object sender, EventArgs e) => Show(replace: true);
        private void TbCaseSensitive_Click(object sender, EventArgs e) => ToggleCaseSensitive();
        private void TbCloseUp_Click(object sender, EventArgs e) => Show(replace: false);
        private void TbDropDown_Click(object sender, EventArgs e) => Show(replace: true);
        private void TbFindAll_Click(object sender, EventArgs e) => FindAll();
        private void TbFindClose_Click(object sender, EventArgs e) => ShowFindReplace(visible: false);
        private void TbFindNext_Click(object sender, EventArgs e) => FindNext();
        private void TbFindPrevious_Click(object sender, EventArgs e) => FindPrevious();
        private void TbPickTags_Click(object sender, EventArgs e) => PickTags();
        private void TbReplaceAll_Click(object sender, EventArgs e) => ReplaceAll();
        private void TbReplaceNext_Click(object sender, EventArgs e) => ReplaceNext();
        private void TbUseRegex_Click(object sender, EventArgs e) => ToggleUseRegex();
        private void TbWholeWord_Click(object sender, EventArgs e) => ToggleWholeWord();
        private void View_Resize(object sender, EventArgs e) => Resize();

        #endregion

        #region Private Methods

        private void FindAll() { }
        private void FindNext() { }
        private void FindPrevious() { }
        private void Hide() => ShowFindReplace(visible: false);
        private void ReplaceAll() { }
        private void ReplaceNext() { }
        private void Resize() => CbFind.Size = CbReplace.Size = new Size(View.Width - 81, CbFind.Height);
        private void Show(bool replace) => ShowFindReplace(visible: true, replacing: replace);
        private void ToggleCaseSensitive() => CaseSensitive ^= true;
        private void ToggleUseRegex() => UseRegex ^= true;
        private void ToggleWholeWord() => WhooleWord ^= true;

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
            if (visible)
            {
                TbCloseUp.Visible = CbReplace.Visible = TbReplaceNext.Visible = TbReplaceAll.Visible = replacing;
                CbFind.Focus();
            }
            ParentControl.Size = new Size(ParentControl.Width, replacing ? 75 : 52);
        }

        private void UpdateAutoComplete(ToolStripComboBox comboBox) =>
            comboBox.AutoCompleteCustomSource = MainAutoCompleter.GetFieldList(Tag.JoinedPerformers, Tag.Album, Tag.Title);

        #endregion
    }
}
