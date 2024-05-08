namespace TagScanner.Controllers.Mru
{
    using System.IO;
    using System.Windows.Forms;
    using FastColoredTextBoxNS;
    using Streaming;
    using Views;

    public class MruScriptController : MruSdiController
    {
        public MruScriptController(Controller parent, ContextMenuStrip parentMenu)
            : base(parent, Properties.Settings.Default.ScriptFilter, "ScriptMRU", parentMenu.Items) { }

        public MruScriptController(Controller parent, ToolStripMenuItem parentMenu)
            : base(parent, Properties.Settings.Default.ScriptFilter, "ScriptMRU", parentMenu.DropDownItems) { }

        private ScriptForm ScriptForm => ScriptFormController.View;
        private ScriptFormController ScriptFormController => (ScriptFormController)Parent;
        private FastColoredTextBox TextBox => ScriptForm.TextBox;

        protected override void ClearDocument() => TextBox.Clear();

        protected override bool LoadFromStream(Stream stream, StreamFormat format)
        {
            //using (var reader = new StreamReader(stream))
            //    TextBox.Text = reader.ReadToEnd();
            TextBox.Text = new StreamReader(stream).ReadToEnd();
            return true;
        }

        protected override bool SaveToStream(Stream stream, StreamFormat format)
        {
            //using (var writer = new StreamWriter(stream))
            //    writer.Write(TextBox.Text);
            new StreamWriter(stream).Write(TextBox.Text);
            return true;
        }
    }
}
