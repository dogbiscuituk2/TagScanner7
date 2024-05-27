namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using FastColoredTextBoxNS;
    using Forms;
    using Mru;
    using Terms;

    public class ScriptFormController : Controller
    {
        #region Constructor

        public ScriptFormController(Controller parent) : base(parent)
        {
            CbFilter = MainForm.FilterControl.cbFilter;
        }

        #endregion

        #region Public Properties

        public bool DocumentIsModified
        {
            get => _documentIsModified;
            set
            {
                if (_documentIsModified != value)
                {
                    _documentIsModified = value;
                    UpdateUI();
                }
            }
        }

        public string Text
        {
            get =>TextBox.Text;
            set
            {
                TextBox.Text = value;
            }
        }

        public ScriptForm View => _view ?? CreateScriptForm();

        #endregion

        #region Public Methods

        public bool Execute()
        {
            var result = View.ShowDialog(Owner) == DialogResult.OK;
            return result;
        }

        public void ShowModal(IWin32Window owner, string text)
        {
            Text = text;
            Execute();
        }

        #endregion

        #region Private Fields

        private bool _documentIsModified;
        private MruScriptController _scriptController;
        private ScriptForm _view;

        private ToolStripComboBox
            CbFilter;

        private ToolStripSplitButton
            TbFilter;

        private ToolStripMenuItem
            EditUpdateFilter,
            TbFilterUpdate,
            EditApplyFilter,
            TbFilterApply;

        #endregion

        #region Private Properties

        private Language Language
        {
            get => TextBox.Language;
            set
            {
                TextBox.Language = value;
                TextBox.OnTextChanged();
                foreach (var item in Languages)
                    item.Checked = (int)item.Tag == (int)Language;
            }
        }

        private ToolStripItemCollection LanguageItems => LanguageMenu.DropDownItems;
        private ToolStripMenuItem LanguageMenu => View.LanguageMenu;
        private IEnumerable<ToolStripMenuItem> Languages => LanguageItems.OfType<ToolStripMenuItem>();
        private FastColoredTextBox TextBox => View.TextBox;

        #endregion

        #region Event Handlers

        private void FileNew_Click(object sender, EventArgs e) => _scriptController.Clear();
        private void FileOpen_Click(object sender, EventArgs e) => _scriptController.Open();
        private void FileSave_Click(object sender, EventArgs e) => _scriptController.Save();
        private void FileSaveAs_Click(object sender, EventArgs e) => _scriptController.SaveAs();

        private void EditUndo_Click(object sender, EventArgs e) { TextBox.Undo(); UpdateUI(); }
        private void EditRedo_Click(object sender, EventArgs e) { TextBox.Redo(); UpdateUI(); }
        private void EditCut_Click(object sender, EventArgs e) { TextBox.Cut(); UpdateUI(); }
        private void EditCopy_Click(object sender, EventArgs e) { TextBox.Copy(); UpdateUI(); }
        private void EditPaste_Click(object sender, EventArgs e) { TextBox.Paste(); UpdateUI(); }
        private void EditDelete_Click(object sender, EventArgs e) { /* TextBox.Delete(); */ UpdateUI(); }
        private void EditUpdateFilter_Click(object sender, EventArgs e) => UpdateFilter();
        private void EditApplyFilter_Click(object sender, EventArgs e) => ApplyFilter();
        private void EditSelectAll_Click(object sender, EventArgs e) { TextBox.SelectAll(); UpdateUI(); }

        private void ViewMenu_DropDownOpening(object sender, EventArgs e) => UpdateMenu();
        private void ViewLineNumbers_Click(object sender, EventArgs e) => TextBox.ShowLineNumbers ^= true;
        private void ViewRuler_Click(object sender, EventArgs e) => View.Ruler.Visible ^= true;
        private void ViewWordWrap_Click(object sender, EventArgs e) => TextBox.WordWrap ^= true;

        private void ScriptRun_Click(object sender, EventArgs e) => UpdateResult();

        private void ColourTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DocumentIsModified = true;
            if (Language == Language.Custom)
                UpdateStyles(e.ChangedRange);
        }

        private void Language_Click(object sender, System.EventArgs e) =>
            Language = (Language)((ToolStripItem)sender).Tag;

        private void View_Shown(object sender, EventArgs e) => View.ActiveControl = View.TextBox;

        #endregion

        #region Private Methods

        private void ApplyFilter()
        {
            UpdateFilter();
            MainFormController.FilterController.ApplyFilter();
        }

        private void CreateAutocompleteMenu()
        {
            var items = new AutocompleteMenu(TextBox) { MinFragmentLength = 3 }.Items;
            items.SetAutocompleteItems(MainAutoCompleter.GetFilterAutoCompleteItems().Cast<string>().Distinct().ToList());
            items.MaximumSize = new System.Drawing.Size(200, 300);
            items.Width = 200;
        }

        private ScriptForm CreateScriptForm()
        {
            _view = new ScriptForm();
            _scriptController = new MruScriptController(this, View.FileReopen);

            EditUpdateFilter = View.EditUpdateFilter;
            EditApplyFilter = View.EditApplyFilter;
            TbFilter = View.tbFilter;
            TbFilterUpdate = View.tbFilterUpdate;
            TbFilterApply = View.tbFilterApply;

            EditUpdateFilter.Click += EditUpdateFilter_Click;
            EditApplyFilter.Click += EditApplyFilter_Click;
            TbFilter.ButtonClick += EditApplyFilter_Click;
            TbFilterUpdate.Click += EditUpdateFilter_Click;
            TbFilterApply.Click += EditApplyFilter_Click;

            var index = 0;
            foreach (var language in Languages)
            {
                language.Click += Language_Click;
                language.Tag = index++;
            }
            Language = Language.Custom;

            CreateAutocompleteMenu();

            View.FileNew.Click += FileNew_Click;
            View.tbNew.Click += FileNew_Click;
            View.FileOpen.Click += FileOpen_Click;
            View.tbOpenScript.Click += FileOpen_Click;
            View.FileSave.Click += FileSave_Click;
            View.tbSaveScript.Click += FileSave_Click;
            View.FileSaveAs.Click += FileSaveAs_Click;
            View.tbSaveAs.Click += FileSaveAs_Click;

            View.EditUndo.Click += EditUndo_Click;
            View.tbUndo.Click += EditUndo_Click;
            View.EditRedo.Click += EditRedo_Click;
            View.tbRedo.Click += EditRedo_Click;
            View.EditCut.Click += EditCut_Click;
            View.tbCut.Click += EditCut_Click;
            View.EditCopy.Click += EditCopy_Click;
            View.tbCopy.Click += EditCopy_Click;
            View.EditPaste.Click += EditPaste_Click;
            View.tbPaste.Click += EditPaste_Click;
            View.EditDelete.Click += EditDelete_Click;
            View.tbDelete.Click += EditDelete_Click;
            View.EditSelectAll.Click += EditSelectAll_Click;

            View.ViewMenu.DropDownOpening += ViewMenu_DropDownOpening;
            View.ViewRuler.Click += ViewRuler_Click;
            View.ViewLineNumbers.Click += ViewLineNumbers_Click;
            View.ViewWordWrap.Click += ViewWordWrap_Click;

            View.ScriptRun.Click += ScriptRun_Click;
            View.tbRun.Click += ScriptRun_Click;

            TextBox.TextChanged += ColourTextBox_TextChanged;
            View.Shown += View_Shown;
            UpdateUI();

            return _view;
        }

        private void UpdateFilter() => CbFilter.Text = Text;

        private void UpdateMenu()
        {
            View.ViewRuler.Checked = View.Ruler.Visible;
            View.ViewWordWrap.Checked = TextBox.WordWrap;
        }

        private void UpdateResult()
        {
            var text = Text;
            var caseSensitive = false;
            Term term = null;
            string result = null;
            var ok = true;
            try
            {
                term = Parser.Parse(text, caseSensitive);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                ok = false;
            }
            if (ok)
                try
                {
                    var output = term.Result;
                    result = output?.ToString() ?? string.Empty;
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }
            View.ResultTextBox.Text = result;
        }

        private void UpdateStyles(Range range)
        {
            var tokens = new List<Token>(Lexer.GetTokens(Text));
            range.ClearStyle(Lexer.AllTextStyles);
            foreach (var token in tokens)
                new Range(TextBox,
                    TextBox.PositionToPlace(token.Start),
                    TextBox.PositionToPlace(token.End))
                    .SetStyle(Lexer.TextStyle(token.Kind));
            UpdateUI();
        }

        private void UpdateUI()
        {
            View.Text = _scriptController.WindowCaption;
            View.EditUndo.Enabled = View.tbUndo.Enabled = TextBox.UndoEnabled;
            View.EditRedo.Enabled = View.tbRedo.Enabled = TextBox.RedoEnabled;
            View.EditCut.Enabled = View.tbCut.Enabled =
                View.EditCopy.Enabled = View.tbCopy.Enabled =
                View.EditDelete.Enabled = View.tbDelete.Enabled = TextBox.SelectionLength > 0;
        }

        #endregion
    }
}