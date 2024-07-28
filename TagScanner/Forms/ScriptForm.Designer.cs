namespace TagScanner.Forms
{
    partial class ScriptForm
    {

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptForm));
            this.TextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.Ruler = new FastColoredTextBoxNS.Ruler();
            this.ToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.PopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EditUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.EditRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.EditCut = new System.Windows.Forms.ToolStripMenuItem();
            this.EditCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.EditPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.EditDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.EditFind = new System.Windows.Forms.ToolStripMenuItem();
            this.EditReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.EditUpdateFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.EditApplyFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.EditSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.EditMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.Toolbar = new TagScanner.Controls.FirstClickToolStrip();
            this.tbNew = new System.Windows.Forms.ToolStripButton();
            this.tbOpen = new System.Windows.Forms.ToolStripSplitButton();
            this.tbOpenScript = new System.Windows.Forms.ToolStripMenuItem();
            this.tbReopen = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSave = new System.Windows.Forms.ToolStripSplitButton();
            this.tbSaveScript = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbUndo = new System.Windows.Forms.ToolStripButton();
            this.tbRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tbCut = new System.Windows.Forms.ToolStripButton();
            this.tbCopy = new System.Windows.Forms.ToolStripButton();
            this.tbPaste = new System.Windows.Forms.ToolStripButton();
            this.tbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tbFindReplace = new System.Windows.Forms.ToolStripSplitButton();
            this.tbFind = new System.Windows.Forms.ToolStripMenuItem();
            this.tbReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.tbFilter = new System.Windows.Forms.ToolStripSplitButton();
            this.tbFilterUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tbFilterApply = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tbRun = new System.Windows.Forms.ToolStripButton();
            this.MainMenu = new TagScanner.Controls.FirstClickMenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.FileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.FileReopen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.FileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.FileClose = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewRuler = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewLineNumbers = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewWordWrap = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.Language_ʞɯɾ = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Language_CS = new System.Windows.Forms.ToolStripMenuItem();
            this.Language_VB = new System.Windows.Forms.ToolStripMenuItem();
            this.Language_HTML = new System.Windows.Forms.ToolStripMenuItem();
            this.Language_SQL = new System.Windows.Forms.ToolStripMenuItem();
            this.Language_XML = new System.Windows.Forms.ToolStripMenuItem();
            this.Language_PHP = new System.Windows.Forms.ToolStripMenuItem();
            this.Language_JS = new System.Windows.Forms.ToolStripMenuItem();
            this.Language_Lua = new System.Windows.Forms.ToolStripMenuItem();
            this.ScriptMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ScriptRun = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            this.ToolStripContainer.ContentPanel.SuspendLayout();
            this.ToolStripContainer.LeftToolStripPanel.SuspendLayout();
            this.ToolStripContainer.TopToolStripPanel.SuspendLayout();
            this.ToolStripContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.PopupMenu.SuspendLayout();
            this.Toolbar.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBox
            // 
            this.TextBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.TextBox.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.TextBox.BackBrush = null;
            this.TextBox.CharHeight = 14;
            this.TextBox.CharWidth = 8;
            this.TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox.IsReplaceMode = false;
            this.TextBox.Location = new System.Drawing.Point(0, 0);
            this.TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.TextBox.Name = "TextBox";
            this.TextBox.Paddings = new System.Windows.Forms.Padding(0);
            this.TextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.TextBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("TextBox.ServiceColors")));
            this.TextBox.Size = new System.Drawing.Size(751, 348);
            this.TextBox.TabIndex = 0;
            this.TextBox.Zoom = 100;
            // 
            // Ruler
            // 
            this.Ruler.Dock = System.Windows.Forms.DockStyle.Top;
            this.Ruler.Location = new System.Drawing.Point(0, 0);
            this.Ruler.MaximumSize = new System.Drawing.Size(1073741824, 24);
            this.Ruler.MinimumSize = new System.Drawing.Size(0, 24);
            this.Ruler.Name = "Ruler";
            this.Ruler.Size = new System.Drawing.Size(751, 24);
            this.Ruler.TabIndex = 1;
            this.Ruler.Target = this.TextBox;
            // 
            // ToolStripContainer
            // 
            // 
            // ToolStripContainer.ContentPanel
            // 
            this.ToolStripContainer.ContentPanel.Controls.Add(this.splitContainer1);
            this.ToolStripContainer.ContentPanel.Controls.Add(this.Ruler);
            this.ToolStripContainer.ContentPanel.Size = new System.Drawing.Size(751, 537);
            this.ToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // ToolStripContainer.LeftToolStripPanel
            // 
            this.ToolStripContainer.LeftToolStripPanel.Controls.Add(this.Toolbar);
            this.ToolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.ToolStripContainer.Name = "ToolStripContainer";
            this.ToolStripContainer.Size = new System.Drawing.Size(784, 561);
            this.ToolStripContainer.TabIndex = 2;
            this.ToolStripContainer.Text = "toolStripContainer1";
            // 
            // ToolStripContainer.TopToolStripPanel
            // 
            this.ToolStripContainer.TopToolStripPanel.Controls.Add(this.MainMenu);
            // 
            // splitContainer1
            // 
            this.splitContainer1.ContextMenuStrip = this.PopupMenu;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TextBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ResultTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(751, 513);
            this.splitContainer1.SplitterDistance = 348;
            this.splitContainer1.TabIndex = 2;
            // 
            // PopupMenu
            // 
            this.PopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditUndo,
            this.EditRedo,
            this.toolStripSeparator7,
            this.EditCut,
            this.EditCopy,
            this.EditPaste,
            this.EditDelete,
            this.toolStripSeparator8,
            this.EditFind,
            this.EditReplace,
            this.toolStripMenuItem3,
            this.EditUpdateFilter,
            this.EditApplyFilter,
            this.toolStripSeparator9,
            this.EditSelectAll});
            this.PopupMenu.Name = "contextMenuStrip1";
            this.PopupMenu.OwnerItem = this.EditMenu;
            this.PopupMenu.Size = new System.Drawing.Size(181, 270);
            // 
            // EditUndo
            // 
            this.EditUndo.Image = global::TagScanner.Properties.Resources.Edit_UndoHS;
            this.EditUndo.Name = "EditUndo";
            this.EditUndo.ShortcutKeyDisplayString = "^Z";
            this.EditUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.EditUndo.Size = new System.Drawing.Size(180, 22);
            this.EditUndo.Text = "&Undo";
            // 
            // EditRedo
            // 
            this.EditRedo.Image = global::TagScanner.Properties.Resources.Edit_RedoHS;
            this.EditRedo.Name = "EditRedo";
            this.EditRedo.ShortcutKeyDisplayString = "^Y";
            this.EditRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.EditRedo.Size = new System.Drawing.Size(180, 22);
            this.EditRedo.Text = "&Redo";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(177, 6);
            // 
            // EditCut
            // 
            this.EditCut.Image = global::TagScanner.Properties.Resources.CutHS;
            this.EditCut.Name = "EditCut";
            this.EditCut.ShortcutKeyDisplayString = "^X";
            this.EditCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.EditCut.Size = new System.Drawing.Size(180, 22);
            this.EditCut.Text = "Cu&t";
            // 
            // EditCopy
            // 
            this.EditCopy.Image = global::TagScanner.Properties.Resources.CopyHS;
            this.EditCopy.Name = "EditCopy";
            this.EditCopy.ShortcutKeyDisplayString = "^C";
            this.EditCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.EditCopy.Size = new System.Drawing.Size(180, 22);
            this.EditCopy.Text = "&Copy";
            // 
            // EditPaste
            // 
            this.EditPaste.Image = global::TagScanner.Properties.Resources.PasteHS;
            this.EditPaste.Name = "EditPaste";
            this.EditPaste.ShortcutKeyDisplayString = "^V";
            this.EditPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.EditPaste.Size = new System.Drawing.Size(180, 22);
            this.EditPaste.Text = "&Paste";
            // 
            // EditDelete
            // 
            this.EditDelete.Image = global::TagScanner.Properties.Resources.Delete;
            this.EditDelete.ImageTransparentColor = System.Drawing.Color.White;
            this.EditDelete.Name = "EditDelete";
            this.EditDelete.ShortcutKeyDisplayString = "";
            this.EditDelete.Size = new System.Drawing.Size(180, 22);
            this.EditDelete.Text = "&Delete";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(177, 6);
            // 
            // EditFind
            // 
            this.EditFind.Image = global::TagScanner.Properties.Resources.ZoomHS;
            this.EditFind.Name = "EditFind";
            this.EditFind.ShortcutKeyDisplayString = "^F";
            this.EditFind.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.EditFind.Size = new System.Drawing.Size(180, 22);
            this.EditFind.Text = "&Find...";
            // 
            // EditReplace
            // 
            this.EditReplace.Name = "EditReplace";
            this.EditReplace.ShortcutKeyDisplayString = "^H";
            this.EditReplace.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.EditReplace.Size = new System.Drawing.Size(180, 22);
            this.EditReplace.Text = "&Replace...";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(177, 6);
            // 
            // EditUpdateFilter
            // 
            this.EditUpdateFilter.ImageTransparentColor = System.Drawing.Color.White;
            this.EditUpdateFilter.Name = "EditUpdateFilter";
            this.EditUpdateFilter.ShortcutKeyDisplayString = "";
            this.EditUpdateFilter.Size = new System.Drawing.Size(180, 22);
            this.EditUpdateFilter.Text = "Updat&e Filter";
            // 
            // EditApplyFilter
            // 
            this.EditApplyFilter.Image = global::TagScanner.Properties.Resources.fff_app_Filter_16;
            this.EditApplyFilter.ImageTransparentColor = System.Drawing.Color.White;
            this.EditApplyFilter.Name = "EditApplyFilter";
            this.EditApplyFilter.ShortcutKeyDisplayString = "^L";
            this.EditApplyFilter.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.EditApplyFilter.Size = new System.Drawing.Size(180, 22);
            this.EditApplyFilter.Text = "Update && App&ly";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(177, 6);
            // 
            // EditSelectAll
            // 
            this.EditSelectAll.Name = "EditSelectAll";
            this.EditSelectAll.ShortcutKeyDisplayString = "^A";
            this.EditSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.EditSelectAll.Size = new System.Drawing.Size(180, 22);
            this.EditSelectAll.Text = "Select &All";
            // 
            // EditMenu
            // 
            this.EditMenu.DropDown = this.PopupMenu;
            this.EditMenu.Name = "EditMenu";
            this.EditMenu.Size = new System.Drawing.Size(39, 20);
            this.EditMenu.Text = "&Edit";
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultTextBox.Location = new System.Drawing.Point(0, 0);
            this.ResultTextBox.Multiline = true;
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.ReadOnly = true;
            this.ResultTextBox.Size = new System.Drawing.Size(751, 161);
            this.ResultTextBox.TabIndex = 0;
            // 
            // Toolbar
            // 
            this.Toolbar.Dock = System.Windows.Forms.DockStyle.None;
            this.Toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbNew,
            this.tbOpen,
            this.tbSave,
            this.toolStripSeparator2,
            this.tbUndo,
            this.tbRedo,
            this.toolStripSeparator3,
            this.tbCut,
            this.tbCopy,
            this.tbPaste,
            this.tbDelete,
            this.toolStripSeparator4,
            this.tbFindReplace,
            this.tbFilter,
            this.toolStripSeparator6,
            this.tbRun});
            this.Toolbar.Location = new System.Drawing.Point(0, 3);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Size = new System.Drawing.Size(33, 302);
            this.Toolbar.TabIndex = 0;
            // 
            // tbNew
            // 
            this.tbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbNew.Image = global::TagScanner.Properties.Resources.NewDocumentHS;
            this.tbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbNew.Name = "tbNew";
            this.tbNew.Size = new System.Drawing.Size(31, 20);
            this.tbNew.Text = "toolStripButton1";
            this.tbNew.ToolTipText = "New";
            // 
            // tbOpen
            // 
            this.tbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbOpen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbOpenScript,
            this.tbReopen});
            this.tbOpen.Image = global::TagScanner.Properties.Resources.openfolderHS;
            this.tbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbOpen.Name = "tbOpen";
            this.tbOpen.Size = new System.Drawing.Size(31, 20);
            this.tbOpen.Text = "toolStripSplitButton1";
            this.tbOpen.ToolTipText = "Open";
            // 
            // tbOpenScript
            // 
            this.tbOpenScript.Name = "tbOpenScript";
            this.tbOpenScript.ShortcutKeyDisplayString = "^O";
            this.tbOpenScript.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tbOpenScript.Size = new System.Drawing.Size(136, 22);
            this.tbOpenScript.Text = "&Open...";
            // 
            // tbReopen
            // 
            this.tbReopen.Name = "tbReopen";
            this.tbReopen.Size = new System.Drawing.Size(136, 22);
            this.tbReopen.Text = "&Reopen";
            // 
            // tbSave
            // 
            this.tbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSave.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbSaveScript,
            this.tbSaveAs});
            this.tbSave.Image = global::TagScanner.Properties.Resources.saveHS;
            this.tbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSave.Name = "tbSave";
            this.tbSave.Size = new System.Drawing.Size(31, 20);
            this.tbSave.Text = "toolStripSplitButton2";
            this.tbSave.ToolTipText = "Save";
            // 
            // tbSaveScript
            // 
            this.tbSaveScript.Name = "tbSaveScript";
            this.tbSaveScript.ShortcutKeyDisplayString = "^S";
            this.tbSaveScript.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tbSaveScript.Size = new System.Drawing.Size(123, 22);
            this.tbSaveScript.Text = "&Save";
            // 
            // tbSaveAs
            // 
            this.tbSaveAs.Name = "tbSaveAs";
            this.tbSaveAs.Size = new System.Drawing.Size(123, 22);
            this.tbSaveAs.Text = "Save &As...";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(31, 6);
            // 
            // tbUndo
            // 
            this.tbUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbUndo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbUndo.Image = global::TagScanner.Properties.Resources.Edit_UndoHS;
            this.tbUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbUndo.Name = "tbUndo";
            this.tbUndo.Size = new System.Drawing.Size(31, 20);
            this.tbUndo.Text = "toolStripButton2";
            this.tbUndo.ToolTipText = "Undo";
            // 
            // tbRedo
            // 
            this.tbRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbRedo.Image = global::TagScanner.Properties.Resources.Edit_RedoHS;
            this.tbRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbRedo.Name = "tbRedo";
            this.tbRedo.Size = new System.Drawing.Size(31, 20);
            this.tbRedo.Text = "toolStripButton3";
            this.tbRedo.ToolTipText = "Redo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(31, 6);
            // 
            // tbCut
            // 
            this.tbCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCut.Image = global::TagScanner.Properties.Resources.CutHS;
            this.tbCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbCut.Name = "tbCut";
            this.tbCut.Size = new System.Drawing.Size(31, 20);
            this.tbCut.Text = "toolStripButton4";
            this.tbCut.ToolTipText = "Cut (^X)";
            // 
            // tbCopy
            // 
            this.tbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCopy.Image = global::TagScanner.Properties.Resources.CopyHS;
            this.tbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbCopy.Name = "tbCopy";
            this.tbCopy.Size = new System.Drawing.Size(31, 20);
            this.tbCopy.Text = "toolStripButton5";
            this.tbCopy.ToolTipText = "Copy (^C)";
            // 
            // tbPaste
            // 
            this.tbPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbPaste.Image = global::TagScanner.Properties.Resources.PasteHS;
            this.tbPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbPaste.Name = "tbPaste";
            this.tbPaste.Size = new System.Drawing.Size(31, 20);
            this.tbPaste.Text = "toolStripButton6";
            this.tbPaste.ToolTipText = "Paste (^V)";
            // 
            // tbDelete
            // 
            this.tbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbDelete.Image = global::TagScanner.Properties.Resources.Delete;
            this.tbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbDelete.Name = "tbDelete";
            this.tbDelete.Size = new System.Drawing.Size(31, 20);
            this.tbDelete.Text = "toolStripButton7";
            this.tbDelete.ToolTipText = "Delete";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(31, 6);
            // 
            // tbFindReplace
            // 
            this.tbFindReplace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbFindReplace.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbFind,
            this.tbReplace});
            this.tbFindReplace.Image = global::TagScanner.Properties.Resources.ZoomHS;
            this.tbFindReplace.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbFindReplace.Name = "tbFindReplace";
            this.tbFindReplace.Size = new System.Drawing.Size(31, 20);
            this.tbFindReplace.Text = "toolStripSplitButton3";
            this.tbFindReplace.ToolTipText = "Find/Replace";
            // 
            // tbFind
            // 
            this.tbFind.Image = global::TagScanner.Properties.Resources.ZoomHS;
            this.tbFind.Name = "tbFind";
            this.tbFind.ShortcutKeyDisplayString = "^F";
            this.tbFind.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.tbFind.Size = new System.Drawing.Size(148, 22);
            this.tbFind.Text = "&Find...";
            // 
            // tbReplace
            // 
            this.tbReplace.Name = "tbReplace";
            this.tbReplace.ShortcutKeyDisplayString = "^H";
            this.tbReplace.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.tbReplace.Size = new System.Drawing.Size(148, 22);
            this.tbReplace.Text = "&Replace...";
            // 
            // tbFilter
            // 
            this.tbFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbFilterUpdate,
            this.tbFilterApply});
            this.tbFilter.Image = global::TagScanner.Properties.Resources.fff_app_Filter_16;
            this.tbFilter.ImageTransparentColor = System.Drawing.Color.White;
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(31, 20);
            this.tbFilter.Text = "toolStripButton1";
            this.tbFilter.ToolTipText = "Update & Apply Filter (^L)";
            // 
            // tbFilterUpdate
            // 
            this.tbFilterUpdate.Name = "tbFilterUpdate";
            this.tbFilterUpdate.Size = new System.Drawing.Size(180, 22);
            this.tbFilterUpdate.Text = "Updat&e Filter";
            // 
            // tbFilterApply
            // 
            this.tbFilterApply.Name = "tbFilterApply";
            this.tbFilterApply.ShortcutKeyDisplayString = "^L";
            this.tbFilterApply.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.tbFilterApply.Size = new System.Drawing.Size(180, 22);
            this.tbFilterApply.Text = "Update && App&ly";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(31, 6);
            // 
            // tbRun
            // 
            this.tbRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbRun.Image = global::TagScanner.Properties.Resources.PlayHS;
            this.tbRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbRun.Name = "tbRun";
            this.tbRun.Size = new System.Drawing.Size(31, 20);
            this.tbRun.Text = "toolStripButton8";
            this.tbRun.ToolTipText = "Run (F9)";
            // 
            // MainMenu
            // 
            this.MainMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.EditMenu,
            this.ViewMenu,
            this.LanguageMenu,
            this.ScriptMenu});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(784, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileNew,
            this.FileOpen,
            this.FileReopen,
            this.toolStripMenuItem1,
            this.FileSave,
            this.FileSaveAs,
            this.toolStripMenuItem2,
            this.FileClose});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 20);
            this.FileMenu.Text = "&File";
            // 
            // FileNew
            // 
            this.FileNew.Image = global::TagScanner.Properties.Resources.NewDocumentHS;
            this.FileNew.Name = "FileNew";
            this.FileNew.ShortcutKeyDisplayString = "^N";
            this.FileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.FileNew.Size = new System.Drawing.Size(136, 22);
            this.FileNew.Text = "New";
            // 
            // FileOpen
            // 
            this.FileOpen.Image = global::TagScanner.Properties.Resources.openfolderHS;
            this.FileOpen.Name = "FileOpen";
            this.FileOpen.ShortcutKeyDisplayString = "^O";
            this.FileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.FileOpen.Size = new System.Drawing.Size(136, 22);
            this.FileOpen.Text = "Open...";
            // 
            // FileReopen
            // 
            this.FileReopen.Name = "FileReopen";
            this.FileReopen.Size = new System.Drawing.Size(136, 22);
            this.FileReopen.Text = "Reopen";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(133, 6);
            // 
            // FileSave
            // 
            this.FileSave.Image = global::TagScanner.Properties.Resources.saveHS;
            this.FileSave.Name = "FileSave";
            this.FileSave.ShortcutKeyDisplayString = "^S";
            this.FileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.FileSave.Size = new System.Drawing.Size(136, 22);
            this.FileSave.Text = "Save";
            // 
            // FileSaveAs
            // 
            this.FileSaveAs.Name = "FileSaveAs";
            this.FileSaveAs.Size = new System.Drawing.Size(136, 22);
            this.FileSaveAs.Text = "Save As...";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(133, 6);
            // 
            // FileClose
            // 
            this.FileClose.Name = "FileClose";
            this.FileClose.Size = new System.Drawing.Size(136, 22);
            this.FileClose.Text = "Close";
            // 
            // ViewMenu
            // 
            this.ViewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewRuler,
            this.ViewLineNumbers,
            this.ViewWordWrap});
            this.ViewMenu.Name = "ViewMenu";
            this.ViewMenu.Size = new System.Drawing.Size(44, 20);
            this.ViewMenu.Text = "&View";
            // 
            // ViewRuler
            // 
            this.ViewRuler.Name = "ViewRuler";
            this.ViewRuler.Size = new System.Drawing.Size(148, 22);
            this.ViewRuler.Text = "&Ruler";
            // 
            // ViewLineNumbers
            // 
            this.ViewLineNumbers.Name = "ViewLineNumbers";
            this.ViewLineNumbers.Size = new System.Drawing.Size(148, 22);
            this.ViewLineNumbers.Text = "&Line Numbers";
            // 
            // ViewWordWrap
            // 
            this.ViewWordWrap.Name = "ViewWordWrap";
            this.ViewWordWrap.Size = new System.Drawing.Size(148, 22);
            this.ViewWordWrap.Text = "&WordWrap";
            // 
            // LanguageMenu
            // 
            this.LanguageMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Language_ʞɯɾ,
            this.toolStripSeparator1,
            this.Language_CS,
            this.Language_VB,
            this.Language_HTML,
            this.Language_SQL,
            this.Language_XML,
            this.Language_PHP,
            this.Language_JS,
            this.Language_Lua});
            this.LanguageMenu.Name = "LanguageMenu";
            this.LanguageMenu.Size = new System.Drawing.Size(71, 20);
            this.LanguageMenu.Text = "&Language";
            // 
            // Language_ʞɯɾ
            // 
            this.Language_ʞɯɾ.Name = "Language_ʞɯɾ";
            this.Language_ʞɯɾ.Size = new System.Drawing.Size(135, 22);
            this.Language_ʞɯɾ.Text = "ʞɯɾ";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(132, 6);
            // 
            // Language_CS
            // 
            this.Language_CS.Name = "Language_CS";
            this.Language_CS.Size = new System.Drawing.Size(135, 22);
            this.Language_CS.Text = "C#";
            // 
            // Language_VB
            // 
            this.Language_VB.Name = "Language_VB";
            this.Language_VB.Size = new System.Drawing.Size(135, 22);
            this.Language_VB.Text = "Visual Basic";
            // 
            // Language_HTML
            // 
            this.Language_HTML.Name = "Language_HTML";
            this.Language_HTML.Size = new System.Drawing.Size(135, 22);
            this.Language_HTML.Text = "HTML";
            // 
            // Language_SQL
            // 
            this.Language_SQL.Name = "Language_SQL";
            this.Language_SQL.Size = new System.Drawing.Size(135, 22);
            this.Language_SQL.Text = "SQL";
            // 
            // Language_XML
            // 
            this.Language_XML.Name = "Language_XML";
            this.Language_XML.Size = new System.Drawing.Size(135, 22);
            this.Language_XML.Text = "XML";
            // 
            // Language_PHP
            // 
            this.Language_PHP.Name = "Language_PHP";
            this.Language_PHP.Size = new System.Drawing.Size(135, 22);
            this.Language_PHP.Text = "PHP";
            // 
            // Language_JS
            // 
            this.Language_JS.Name = "Language_JS";
            this.Language_JS.Size = new System.Drawing.Size(135, 22);
            this.Language_JS.Text = "JavaScript";
            // 
            // Language_Lua
            // 
            this.Language_Lua.Name = "Language_Lua";
            this.Language_Lua.Size = new System.Drawing.Size(135, 22);
            this.Language_Lua.Text = "Lua";
            // 
            // ScriptMenu
            // 
            this.ScriptMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ScriptRun});
            this.ScriptMenu.Name = "ScriptMenu";
            this.ScriptMenu.Size = new System.Drawing.Size(49, 20);
            this.ScriptMenu.Text = "&Script";
            // 
            // ScriptRun
            // 
            this.ScriptRun.Image = global::TagScanner.Properties.Resources.PlayHS;
            this.ScriptRun.Name = "ScriptRun";
            this.ScriptRun.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.ScriptRun.Size = new System.Drawing.Size(114, 22);
            this.ScriptRun.Text = "&Run";
            // 
            // ScriptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.ToolStripContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ScriptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Script";
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            this.ToolStripContainer.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer.LeftToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer.LeftToolStripPanel.PerformLayout();
            this.ToolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer.TopToolStripPanel.PerformLayout();
            this.ToolStripContainer.ResumeLayout(false);
            this.ToolStripContainer.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.PopupMenu.ResumeLayout(false);
            this.Toolbar.ResumeLayout(false);
            this.Toolbar.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public FastColoredTextBoxNS.FastColoredTextBox TextBox;
        public FastColoredTextBoxNS.Ruler Ruler;
        public System.Windows.Forms.ToolStripContainer ToolStripContainer;
        public TagScanner.Controls.FirstClickMenuStrip MainMenu;
        public System.Windows.Forms.ToolStripMenuItem FileMenu;
        public System.Windows.Forms.ToolStripMenuItem LanguageMenu;
        public System.Windows.Forms.ToolStripMenuItem FileNew;
        public System.Windows.Forms.ToolStripMenuItem FileOpen;
        public System.Windows.Forms.ToolStripMenuItem FileReopen;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem FileSave;
        public System.Windows.Forms.ToolStripMenuItem FileSaveAs;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        public System.Windows.Forms.ToolStripMenuItem FileClose;
        public System.Windows.Forms.ToolStripMenuItem Language_ʞɯɾ;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripMenuItem Language_CS;
        public System.Windows.Forms.ToolStripMenuItem Language_VB;
        public System.Windows.Forms.ToolStripMenuItem Language_HTML;
        public System.Windows.Forms.ToolStripMenuItem Language_XML;
        public System.Windows.Forms.ToolStripMenuItem Language_SQL;
        public System.Windows.Forms.ToolStripMenuItem Language_PHP;
        public System.Windows.Forms.ToolStripMenuItem Language_JS;
        public System.Windows.Forms.ToolStripMenuItem Language_Lua;
        public System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.TextBox ResultTextBox;
        public System.Windows.Forms.ToolStripMenuItem ScriptMenu;
        public System.Windows.Forms.ToolStripMenuItem ScriptRun;
        public TagScanner.Controls.FirstClickToolStrip Toolbar;
        public System.Windows.Forms.ContextMenuStrip PopupMenu;
        public System.Windows.Forms.ToolStripButton tbNew;
        public System.Windows.Forms.ToolStripSplitButton tbOpen;
        public System.Windows.Forms.ToolStripSplitButton tbSave;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripButton tbUndo;
        public System.Windows.Forms.ToolStripButton tbRedo;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripButton tbCut;
        public System.Windows.Forms.ToolStripButton tbCopy;
        public System.Windows.Forms.ToolStripButton tbPaste;
        public System.Windows.Forms.ToolStripButton tbDelete;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        public System.Windows.Forms.ToolStripSplitButton tbFindReplace;
        public System.Windows.Forms.ToolStripMenuItem EditMenu;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        public System.Windows.Forms.ToolStripButton tbRun;
        public System.Windows.Forms.ToolStripMenuItem tbOpenScript;
        public System.Windows.Forms.ToolStripMenuItem tbReopen;
        public System.Windows.Forms.ToolStripMenuItem tbSaveScript;
        public System.Windows.Forms.ToolStripMenuItem tbSaveAs;
        public System.Windows.Forms.ToolStripMenuItem tbFind;
        public System.Windows.Forms.ToolStripMenuItem tbReplace;
        public System.Windows.Forms.ToolStripMenuItem ViewMenu;
        public System.Windows.Forms.ToolStripMenuItem ViewWordWrap;
        public System.Windows.Forms.ToolStripMenuItem EditUndo;
        public System.Windows.Forms.ToolStripMenuItem EditRedo;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        public System.Windows.Forms.ToolStripMenuItem EditCut;
        public System.Windows.Forms.ToolStripMenuItem EditCopy;
        public System.Windows.Forms.ToolStripMenuItem EditPaste;
        public System.Windows.Forms.ToolStripMenuItem EditDelete;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        public System.Windows.Forms.ToolStripMenuItem EditFind;
        public System.Windows.Forms.ToolStripMenuItem EditReplace;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        public System.Windows.Forms.ToolStripMenuItem EditSelectAll;
        public System.Windows.Forms.ToolStripMenuItem EditUpdateFilter;
        public System.Windows.Forms.ToolStripSplitButton tbFilter;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        public System.Windows.Forms.ToolStripMenuItem EditApplyFilter;
        public System.Windows.Forms.ToolStripMenuItem tbFilterUpdate;
        public System.Windows.Forms.ToolStripMenuItem tbFilterApply;
        public System.Windows.Forms.ToolStripMenuItem ViewRuler;
        public System.Windows.Forms.ToolStripMenuItem ViewLineNumbers;
        private System.ComponentModel.IContainer components;
    }
}