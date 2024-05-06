namespace TagScanner.Controllers
{
    using System.Drawing;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using FastColoredTextBoxNS;
    using TagScanner.Terms;
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

        private static FontStyle style => FontStyle.Regular;

        private static TextStyle
            blue = new TextStyle(Brushes.Blue, null, style),
            red = new TextStyle(Brushes.Red, null, style),
            green = new TextStyle(Brushes.Green, null, style);

        private string
            functors = Functors.Keys.Select(p => $"{p}").Aggregate((p, q) => $"{p}|{q}"),
            operators = Operators.Keys.Select(p => $"{p}").Aggregate((p, q) => $"{p}|{q}"),
            tags = Tags.Keys.Select(p => p.DisplayName()).Aggregate((p, q) => $"{p}|{q}");

        private void ColourTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            e.ChangedRange.ClearStyle(blue, red, green);
            e.ChangedRange.SetStyle(blue, functors, RegexOptions.IgnoreCase);
            e.ChangedRange.SetStyle(red, operators, RegexOptions.IgnoreCase);
            e.ChangedRange.SetStyle(green, tags, RegexOptions.IgnoreCase);
        }
    }
}
