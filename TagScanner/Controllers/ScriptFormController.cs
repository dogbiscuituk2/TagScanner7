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
        public ScriptFormController(Controller parent) : base(parent) { }

        public ScriptForm ScriptForm => _scriptForm ?? CreateScriptForm();

        public bool Execute()
        {
            var result = ScriptForm.ShowDialog(Owner) == DialogResult.OK;
            return result;
        }

        private ScriptForm _scriptForm;

        private FastColoredTextBox ColourTextBox => ScriptForm.ColourTextBox;

        private ScriptForm CreateScriptForm()
        {
            _scriptForm = new ScriptForm();
            ColourTextBox.Language = Language.Custom;
            ColourTextBox.TextChanged += ColourTextBox_TextChanged;
            return _scriptForm;
        }

        private static string MakeRegex(IEnumerable<string> strings) => strings
            .OrderByDescending(p => p)
            .Select(p => Regex.Escape(p))
            .Aggregate((p, q) => $"{p}|{q}");

        private static FontStyle style => FontStyle.Regular;

        private static TextStyle
            blue = new TextStyle(Brushes.LightBlue, null, style),
            red = new TextStyle(Brushes.Red, null, style),
            green = new TextStyle(Brushes.LightGreen, null, style);

        private string
            functors = MakeRegex(Functors.Keys.Select(p => $"{p}")),
            operators = MakeRegex(Operators.Symbols),
            tags = MakeRegex(Tags.Keys.Select(p => p.DisplayName()));

        private void ColourTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            e.ChangedRange.ClearStyle(blue, red, green);
            e.ChangedRange.SetStyle(blue, functors, RegexOptions.IgnoreCase);
            e.ChangedRange.SetStyle(red, operators, RegexOptions.IgnoreCase);
            e.ChangedRange.SetStyle(green, tags, RegexOptions.IgnoreCase);
        }
    }
}
