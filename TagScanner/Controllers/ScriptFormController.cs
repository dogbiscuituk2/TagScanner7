namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using FastColoredTextBoxNS;
    using Mru;
    using Terms;
    using Views;

    public class ScriptFormController : Controller
    {
        #region Constructor

        public ScriptFormController(Controller parent) : base(parent) { }

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

        public ScriptForm View => _view ?? CreateScriptForm();

        #endregion

        #region Public Methods

        public bool Execute()
        {
            var result = View.ShowDialog(Owner) == DialogResult.OK;
            return result;
        }

        #endregion

        #region Private Fields

        private bool _documentIsModified;
        private MruScriptController _scriptController;
        private ScriptForm _view;

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
        private string Text => TextBox.Text;
        private FastColoredTextBox TextBox => View.TextBox;

        #endregion

        #region Event Handlers

        private void ColourTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DocumentIsModified = true;
            if (Language == Language.Custom)
                UpdateStyles(e.ChangedRange);
        }

        private void Language_Click(object sender, System.EventArgs e) =>
            Language = (Language)((ToolStripItem)sender).Tag;

        #endregion

        #region Private Methods

        private ScriptForm CreateScriptForm()
        {
            _view = new ScriptForm();
            var index = 0;
            foreach (var language in Languages)
            {
                language.Click += Language_Click;
                language.Tag = index++;
            }
            _scriptController = new MruScriptController(this, View.FileReopen);
            View.FileNew.Click += (sender, e) => _scriptController.Clear();
            View.FileOpen.Click += (sender, e) => _scriptController.Open();
            View.FileSave.Click += (sender, e) => _scriptController.Save();
            View.FileSaveAs.Click += (sender, e) => _scriptController.SaveAs();
            Language = Language.Custom;
            TextBox.TextChanged += ColourTextBox_TextChanged;
            return _view;
        }

        private void UpdateResult()
        {
            var text = Text;
            var caseSensitive = false;
            var parser = new Parser();
            Term term = null;
            string result = null;
            var ok = true;
            try
            {
                term = parser.Parse(text, caseSensitive);
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
            var tokens = new List<Token>(Tokenizer.GetTokens(Text));
            range.ClearStyle(Tokenizer.AllTextStyles);
            foreach (var token in tokens)
                new Range(TextBox,
                    TextBox.PositionToPlace(token.Start),
                    TextBox.PositionToPlace(token.End))
                    .SetStyle(token.Kind.TextStyle());
            UpdateResult();
        }

        private void UpdateUI() => View.Text = _scriptController.WindowCaption;

        #endregion
    }
}
