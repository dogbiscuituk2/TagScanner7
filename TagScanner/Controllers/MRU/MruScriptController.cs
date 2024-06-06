namespace TagScanner.Controllers.Mru
{
    using System.IO;
    using System.Windows.Forms;
    using FastColoredTextBoxNS;
    using Forms;
    using Streaming;

    public class MruScriptController : MruSdiController
    {
        #region Constructors

        public MruScriptController(Controller parent, ContextMenuStrip parentMenu)
            : base(parent, Properties.Settings.Default.ScriptFilter, "ScriptMRU", parentMenu.Items) { }

        public MruScriptController(Controller parent, ToolStripMenuItem parentMenu)
            : base(parent, Properties.Settings.Default.ScriptFilter, "ScriptMRU", parentMenu.DropDownItems) { }

        #endregion

        #region Public Methods

        public void Undo() => TextBox.Undo();
        public void Redo() => TextBox.Redo();
        public void Cut() => TextBox.Cut();
        public void Copy() => TextBox.Copy();
        public void Paste() => TextBox.Paste();
        public void Delete() { }

        #endregion

        #region Protected Properties

        protected override bool DocumentIsModified => ScriptFormController.DocumentIsModified;

        #endregion

        #region Protected Methods

        protected override void ClearDocument() => TextBox.Clear();

        protected override bool LoadFromStream(Stream stream, StreamFormat format)
        {
            TextBox.Text = new StreamReader(stream).ReadToEnd();
            return true;
        }

        protected override bool SaveToStream(Stream stream, StreamFormat format)
        {
            new StreamWriter(stream).Write(TextBox.Text);
            return true;
        }

        #endregion

        #region Private Properties

        private ScriptForm ScriptForm => ScriptFormController.View;
        private ScriptFormController ScriptFormController => (ScriptFormController)Parent;
        private FastColoredTextBox TextBox => ScriptForm.TextBox;

        #endregion
    }
}
