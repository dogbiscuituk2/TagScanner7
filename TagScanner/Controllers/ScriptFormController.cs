﻿namespace TagScanner.Controllers
{
    using System.Collections.Generic;
    using System.Drawing;
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

        private MruScriptController MruScriptController;
        private ScriptForm _view;

        private static readonly FontStyle fontStyle = FontStyle.Regular;

        private static readonly TextStyle
            Black = new TextStyle(Brushes.Black, null, fontStyle),
            Brown = new TextStyle(Brushes.Brown, null, fontStyle),
            Red = new TextStyle(Brushes.Red, null, fontStyle),
            Orange = new TextStyle(Brushes.DarkOrange, null, fontStyle),
            Yellow = new TextStyle(Brushes.Red, Brushes.Yellow, fontStyle),
            Green = new TextStyle(Brushes.Green, null, fontStyle),
            Cyan = new TextStyle(Brushes.DarkCyan, null, fontStyle),
            Blue = new TextStyle(Brushes.Blue, null, fontStyle),
            Magenta = new TextStyle(Brushes.Magenta, null, fontStyle),
            Grey = new TextStyle(Brushes.DarkGray, null, fontStyle),
            White = new TextStyle(Brushes.White, Brushes.OrangeRed, fontStyle);

        private static readonly TextStyle[] TextStyles = new[]
        { Black, Brown, Red, Orange, Yellow, Green, Cyan, Blue, Magenta, Grey, White };

        #endregion

        #region Private Properties

        private Language Language
        {
            get => TextBox.Language;
            set
            {
                TextBox.TextChanged -= ColourTextBox_TextChanged;
                TextBox.Language = value;
                TextBox.OnTextChanged();
                if (Language == Language.Custom)
                    TextBox.TextChanged += ColourTextBox_TextChanged;
                foreach (var item in Languages)
                    item.Checked = (int)item.Tag == (int)Language;
            }
        }

        private ToolStripItemCollection LanguageItems => PopupLanguage.DropDownItems;
        private ToolStripMenuItem PopupLanguage => View.LanguageMenu;
        private IEnumerable<ToolStripMenuItem> Languages => LanguageItems.OfType<ToolStripMenuItem>();
        private FastColoredTextBox TextBox => View.TextBox;
        private string Text => TextBox.Text;

        #endregion

        #region Event Handlers

        private void ColourTextBox_TextChanged(object sender, TextChangedEventArgs e) => UpdateStyles(e.ChangedRange);

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
            MruScriptController = new MruScriptController(this, View.FileReopen);
            View.FileNew.Click += (sender, e) => MruScriptController.Clear();
            View.FileOpen.Click += (sender, e) => MruScriptController.Open();
            View.FileSave.Click += (sender, e) => MruScriptController.Save();
            View.FileSaveAs.Click += (sender, e) => MruScriptController.SaveAs();
            Language = Language.Custom;
            return _view;
        }

        private void Language_Click(object sender, System.EventArgs e) =>
            Language = (Language)((ToolStripItem)sender).Tag;

        private TextStyle GetTextStyle(TokenType tokenType)
        {
            if ((tokenType & TokenType.Constant) != 0)
                return Orange;
            switch (tokenType)
            {
                case TokenType.Comment: return Green;
                case TokenType.Function: return Cyan;
                case TokenType.Field: return Blue;
                case TokenType.None: return White;
                case TokenType.Parameter: return Brown;
                case TokenType.Symbol: return Black;
                case TokenType.TypeName: return Red;
                case TokenType.Variable: return Magenta;
                default: return Black;
            }
        }

        private void UpdateStyles(Range range)
        {
            var tokens = new List<Token>(Tokenizer.GetTokens(Text));
            range.ClearStyle(TextStyles);
            foreach (var token in tokens)
            {
                var index = token.Index;
                Place
                    start = TextBox.PositionToPlace(index),
                    end = TextBox.PositionToPlace(index + token.Value.Length);
                range = new Range(TextBox, start, end);
                range.SetStyle(GetTextStyle(token.TokenType));
            }
        }

        #endregion
    }
}
