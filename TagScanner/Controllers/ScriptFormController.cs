namespace TagScanner.Controllers
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using FastColoredTextBoxNS;
    using Terms;
    using Views;

    public class ScriptFormController : Controller
    {
        #region Constructor

        public ScriptFormController(Controller parent) : base(parent) { }

        #endregion

        #region Public Methods

        public bool Execute()
        {
            var result = ScriptForm.ShowDialog(Owner) == DialogResult.OK;
            return result;
        }

        #endregion

        #region Private Fields

        private ScriptForm _scriptForm;

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

        private ScriptForm ScriptForm => _scriptForm ?? CreateScriptForm();
        private FastColoredTextBox ColourTextBox => ScriptForm.ColourTextBox;
        private string Text => ColourTextBox.Text;

        #endregion

        #region Event Handlers

        private void ColourTextBox_TextChanged(object sender, TextChangedEventArgs e) => UpdateStyles(e.ChangedRange);

        #endregion

        #region Private Methods

        private ScriptForm CreateScriptForm()
        {
            _scriptForm = new ScriptForm();
            ColourTextBox.Language = Language.Custom;
            ColourTextBox.TextChanged += ColourTextBox_TextChanged;
            return _scriptForm;
        }

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
                    start = ColourTextBox.PositionToPlace(index),
                    end = ColourTextBox.PositionToPlace(index + token.Value.Length);
                range = new Range(ColourTextBox, start, end);
                range.SetStyle(GetTextStyle(token.TokenType));
            }
        }

        #endregion
    }
}
