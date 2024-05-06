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

        private static FontStyle fontStyle = FontStyle.Regular;

        private static TextStyle
            red = new TextStyle(Brushes.Red, null, fontStyle),
            green = new TextStyle(Brushes.Green, null, fontStyle),
            cyan = new TextStyle(Brushes.DarkCyan, null, fontStyle),
            blue = new TextStyle(Brushes.Blue, null, fontStyle),
            black = new TextStyle(Brushes.Black, null, fontStyle);

        private string
            functors = MakeRegex(Functors.Keys.Select(p => $"{p}")),
            operators = MakeRegex(Operators.Symbols),
            tags = MakeRegex(Tags.Keys.Select(p => p.DisplayName()));

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
                    return green;
                case TokenType.Function:
                    return cyan;
                case TokenType.Field:
                    return blue;
            }
            if ((tokenType & TokenType.Constant) != 0)
                return red;
            return black;
        }

        private static string MakeRegex(IEnumerable<string> strings) => strings
            .OrderByDescending(p => p)
            .Select(p => Regex.Escape(p))
            .Aggregate((p, q) => $"{p}|{q}");

        private void UpdateStyles(Range range)
        {
            var tokens = new List<Token>();
            Tokenizer.TryGetTokens(Text, ref tokens);
            range.ClearStyle(black, red, green, cyan, blue, black);
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
