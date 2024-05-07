namespace TagScanner.Controllers
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text.RegularExpressions;
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
            TextStyleBlack = new TextStyle(Brushes.Black, null, fontStyle),
            TextStyleBrown = new TextStyle(Brushes.Brown, null, fontStyle),
            TextStyleRed = new TextStyle(Brushes.Red, null, fontStyle),
            TextStyleOrange = new TextStyle(Brushes.DarkOrange, null, fontStyle),
            TextStyleYellow = new TextStyle(Brushes.Red, Brushes.Yellow, fontStyle),
            TextStyleGreen = new TextStyle(Brushes.Green, null, fontStyle),
            TextStyleCyan = new TextStyle(Brushes.DarkCyan, null, fontStyle),
            TextStyleBlue = new TextStyle(Brushes.Blue, null, fontStyle),
            TextStyleViolet = new TextStyle(Brushes.Violet, null, fontStyle),
            TextStyleGrey = new TextStyle(Brushes.DarkGray, null, fontStyle),
            TextStyleWhite = new TextStyle(Brushes.White, Brushes.OrangeRed, fontStyle);

            private static readonly TextStyle[] TextStyles = new TextStyle[]
            {
                TextStyleBlack,
                TextStyleBrown,
                TextStyleRed,
                TextStyleOrange,
                TextStyleYellow,
                TextStyleGreen,
                TextStyleCyan,
                TextStyleBlue,
                TextStyleViolet,
                TextStyleGrey,
                TextStyleWhite,
            };

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
            switch (tokenType)
            {
                case TokenType.Comment:
                    return TextStyleGreen;
                case TokenType.Function:
                    return TextStyleCyan;
                case TokenType.Field:
                    return TextStyleBlue;
                case TokenType.None:
                    return TextStyleWhite;
            }
            if ((tokenType & TokenType.Constant) != 0)
                return TextStyleOrange;
            return TextStyleBlack;
        }

        private static string MakeRegex(IEnumerable<string> strings) => strings
            .OrderByDescending(p => p)
            .Select(p => Regex.Escape(p))
            .Aggregate((p, q) => $"{p}|{q}");

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
