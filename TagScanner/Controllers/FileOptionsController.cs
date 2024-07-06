namespace TagScanner.Controllers
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Forms;
    using Models;

    public class FileOptionsController : Controller, IGetErrors
    {
        #region Constructor

        public FileOptionsController(Controller parent) : base(parent) =>
            MainForm.AddOptions.Click += AddOptions_Click;

        #endregion

        #region Public Properties

        public ErrorProvider ErrorProvider => View.ErrorProvider;

        #endregion

        #region Public Methods

        public bool Execute()
        {
            if (View == null)
                CreateView();

            SetSchema(AppController.Schema);
            var root = RootNode;
            if (root != null)
                foreach (TreeNode node in RootNode.Nodes)
                    node.Collapse();

            Process(loading: true);
            UpdateUI();
            var ok = View.ShowDialog(Owner) == DialogResult.OK;
            if (ok)
            {
                Process(loading: false);
                AppController.Schema = GetSchema();
                var filterTerm = FileOptions.GetFilter();
                MainModel.FileOptionsFilter = filterTerm.Filter;
            }
            return ok;
        }

        public string GetErrors(Control control)
        {
            var errors = new StringBuilder();
            if (control == DtpCreatedMin || control == DtpCreatedMax)
                CheckDates(DtpCreatedMin, DtpCreatedMax, "Created Date");
            if (control == DtpModifiedMin || control == DtpModifiedMax)
                CheckDates(DtpModifiedMin, DtpModifiedMax, "Modified Date");
            if (control == DtpAccessedMin || control == DtpAccessedMax)
                CheckDates(DtpAccessedMin, DtpAccessedMax, "Accessed Date");
            if (control == SeFileSizeMin || control == SeFileSizeMax)
                if (CbFileSizeMin.Checked && CbFileSizeMax.Checked && SeFileSizeMin.Value > SeFileSizeMax.Value)
                    errors.AppendLine("The minimum File Size cannot be greater than the maximum.");
            return errors.ToString().Trim();

            void CheckDates(DateTimePicker min, DateTimePicker max, string date)
            {
                if (min.Checked && max.Checked && min.Value > max.Value)
                    errors.AppendLine($"The first {date} cannot be later than the last.");
            }
        }

        #endregion

        #region Private Fields

        private static readonly string[] LineTypes = new[] { "Root", "Media Category", "File Format" };
        private readonly FileOptions FileOptions = new FileOptions();

        private FileOptionsDialog View;
        private TriStateTreeController TriStateTreeController;

        private Button
            BtnAdd, BtnEdit, BtnDelete;

        private CheckBox
            CbCreatedUtc, CbModifiedUtc, CbAccessedUtc,
            CbFileSizeMin, CbFileSizeMax;

        private ComboBox
            CbReadOnly, CbHidden, CbSystem, CbArchive, CbCompressed, CbEncrypted;

        private DateTimePicker
            DtpCreatedMin, DtpCreatedMax,
            DtpModifiedMin, DtpModifiedMax,
            DtpAccessedMin, DtpAccessedMax;

        private NumericUpDown
            SeFileSizeMin, SeFileSizeMax;

        private ToolStripMenuItem
            PopupAdd, PopupEdit, PopupDelete;

        #endregion

        #region Private Properties

        private TreeNodeCollection Nodes => TreeView.Nodes;
        private TreeNode RootNode => Nodes.Count > 0 ? Nodes[0] : null;
        private TreeView TreeView => View.TreeView;

        private TreeNode SelectedNode
        {
            get => TreeView.SelectedNode;
            set => TreeView.SelectedNode = value;
        }

        #endregion

        #region Event Handlers

        private void AddOptions_Click(object sender, EventArgs e) => Execute();
        private void CheckBox_CheckedChanged(object sender, EventArgs e) => UpdateUI();
        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e) => UpdateUI();

        #endregion

        #region Private Methods

        private void Add()
        {
            var parent = SelectedNode;
            parent = parent.Level < 2 ? parent : parent.Parent;
            var level = parent.Level + 1;
            string
                description = string.Empty,
                filespecs = string.Empty;
            if (EditValue($"Add a new {LineTypes[level]}", level, ref description, ref filespecs))
                AddNode(parent.Nodes, description, filespecs, check: level == 2);
        }

        private void AddNode(TreeNodeCollection nodes, string description, string filespecs, bool check)
        {
            var node = nodes.Add(description);
            InitNode(node, description, filespecs, check ? TreeNodeState.Checked : TreeNodeState.Unchecked);
        }

        private void AdjustIncrement(NumericUpDown control) =>
            control.Increment = Math.Max(1, Math.Truncate(control.Value / 100));

        private void CreateView()
        {
            View = new FileOptionsDialog();

            BtnAdd = View.btnAdd;
            BtnEdit = View.btnEdit;
            BtnDelete = View.btnDelete;

            CbCreatedUtc = View.cbCreatedUtc;
            CbModifiedUtc = View.cbModifiedUtc;
            CbAccessedUtc = View.cbAccessedUtc;
            CbFileSizeMin = View.cbFileSizeMin;
            CbFileSizeMax = View.cbFileSizeMax;

            CbReadOnly = View.cbAttrReadOnly;
            CbHidden = View.cbAttrHidden;
            CbSystem = View.cbAttrSystem;
            CbArchive = View.cbAttrArchive;
            CbCompressed = View.cbAttrCompressed;
            CbEncrypted = View.cbAttrEncrypted;

            DtpCreatedMin = View.dtpCreatedMin;
            DtpCreatedMax = View.dtpCreatedMax;
            DtpModifiedMin = View.dtpModifiedMin;
            DtpModifiedMax = View.dtpModifiedMax;
            DtpAccessedMin = View.dtpAccessedMin;
            DtpAccessedMax = View.dtpAccessedMax;

            SeFileSizeMin = View.seFileSizeMin;
            SeFileSizeMax = View.seFileSizeMax;

            PopupAdd = View.PopupAdd;
            PopupEdit = View.PopupEdit;
            PopupDelete = View.PopupDelete;

            SeFileSizeMin.Maximum = SeFileSizeMax.Maximum = ulong.MaxValue;

            TreeView.AfterSelect += TreeView_AfterSelect;

            CbFileSizeMin.CheckedChanged += CheckBox_CheckedChanged;
            CbFileSizeMax.CheckedChanged += CheckBox_CheckedChanged;

            SeFileSizeMin.ValueChanged += (sender, e) => AdjustIncrement(SeFileSizeMin);
            SeFileSizeMax.ValueChanged += (sender, e) => AdjustIncrement(SeFileSizeMax);

            BtnAdd.Click += (sender, e) => Add();
            PopupAdd.Click += (sender, e) => Add();
            BtnEdit.Click += (sender, e) => Edit();
            PopupEdit.Click += (sender, e) => Edit();
            BtnDelete.Click += (sender, e) => Remove();
            PopupDelete.Click += (sender, e) => Remove();

            TriStateTreeController = new TriStateTreeController(TreeView);

            new ErrorController(this,
                DtpCreatedMin, DtpCreatedMax,
                DtpModifiedMin, DtpModifiedMax,
                DtpAccessedMin, DtpAccessedMax,
                SeFileSizeMin, SeFileSizeMax);
        }

        private void Edit()
        {
            var node = SelectedNode;
            var level = node.Level;
            var description = node.Text;
            var filespecs = node.Tag?.ToString() ?? string.Empty;
            if (level == 2)
                description = description.Substring(0, description.Length - filespecs.Length - 3);
            if (EditValue($"Edit the selected {LineTypes[level]}", level, ref description, ref filespecs))
                InitNode(node, description, filespecs);
        }

        private bool EditValue(string prompt, int level, ref string description, ref string filespecs) =>
            new FileFormatController(this).Execute(prompt, level, ref description, ref filespecs);

        private static TreeNodeState GetNodeState(TreeNode node) => (TreeNodeState)node.StateImageIndex;

        private Schema GetSchema()
        {
            var schema = new Schema();
            AddNodes(Nodes);
            return schema;

            void AddNode(TreeNode node)
            {
                schema.AddLine(NodeToLine(node));
                AddNodes(node.Nodes);
            }

            void AddNodes(TreeNodeCollection nodes)
            {
                foreach (TreeNode node in nodes)
                    AddNode(node);
            }

            SchemaLine NodeToLine(TreeNode node)
            {
                var level = node.Level;
                var filespecs = node.Tag.ToString();
                var description = node.Text;
                if (level == 2)
                    description = description.Remove(description.Length - filespecs.Length - 3);
                var check = GetNodeState(node) == TreeNodeState.Checked;
                return new SchemaLine(level, description, filespecs, check);
            }
        }

        private void InitNode(TreeNode node, string description, string filespecs)
        {
            SelectedNode = node;
            node.Text = string.IsNullOrWhiteSpace(filespecs) ? description : $"{description} ({filespecs})";
            node.Tag = filespecs;
            node.EnsureVisible();
            TreeView.Focus();
        }

        private void InitNode(TreeNode node, string description, string filespecs, TreeNodeState state)
        {
            InitNode(node, description, filespecs);
            SetNodeState(node, state);
        }

        private void Process(bool loading)
        {
            ProcessDtpCheckBox(DtpCreatedMin, FileFlags.CreatedMin);
            ProcessDtpCheckBox(DtpCreatedMax, FileFlags.CreatedMax);
            ProcessCheckBox(CbCreatedUtc, FileFlags.CreatedUtc);
            ProcessDtpCheckBox(DtpModifiedMin, FileFlags.ModifiedMin);
            ProcessDtpCheckBox(DtpModifiedMax, FileFlags.ModifiedMax);
            ProcessCheckBox(CbModifiedUtc, FileFlags.ModifiedUtc);
            ProcessDtpCheckBox(DtpAccessedMin, FileFlags.AccessedMin);
            ProcessDtpCheckBox(DtpAccessedMax, FileFlags.AccessedMax);
            ProcessCheckBox(CbAccessedUtc, FileFlags.AccessedUtc);
            ProcessCheckBox(CbFileSizeMin, FileFlags.FileSizeMin);
            ProcessCheckBox(CbFileSizeMax, FileFlags.FileSizeMax);

            if (loading)
            {
                DtpCreatedMin.Value = FileOptions.CreatedMin;
                DtpCreatedMax.Value = FileOptions.CreatedMax;
                DtpModifiedMin.Value = FileOptions.ModifiedMin;
                DtpModifiedMax.Value = FileOptions.ModifiedMax;
                DtpAccessedMin.Value = FileOptions.AccessedMin;
                DtpAccessedMax.Value = FileOptions.AccessedMax;
                SeFileSizeMin.Value = FileOptions.FileSizeMin;
                SeFileSizeMax.Value = FileOptions.FileSizeMax;
            }
            else
            {
                FileOptions.CreatedMin = DtpCreatedMin.Value;
                FileOptions.CreatedMax = DtpCreatedMax.Value;
                FileOptions.ModifiedMin = DtpModifiedMin.Value;
                FileOptions.ModifiedMax = DtpModifiedMax.Value;
                FileOptions.AccessedMin = DtpAccessedMin.Value;
                FileOptions.AccessedMax = DtpAccessedMax.Value;
                FileOptions.FileSizeMin = (ulong)SeFileSizeMin.Value;
                FileOptions.FileSizeMax = (ulong)SeFileSizeMax.Value;
            }

            ProcessComboBox(CbReadOnly, FileFlags.ReadOnlyTrue, FileFlags.ReadOnlyFalse);
            ProcessComboBox(CbHidden, FileFlags.HiddenTrue, FileFlags.HiddenFalse);
            ProcessComboBox(CbSystem, FileFlags.SystemTrue, FileFlags.SystemFalse);
            ProcessComboBox(CbArchive, FileFlags.ArchiveTrue, FileFlags.ArchiveFalse);
            ProcessComboBox(CbCompressed, FileFlags.CompressedTrue, FileFlags.CompressedFalse);
            ProcessComboBox(CbEncrypted, FileFlags.EncryptedTrue, FileFlags.EncryptedFalse);

            void ProcessCheckBox(CheckBox control, FileFlags flag)
            {
                if (loading)
                    control.Checked = GetFlag(flag);
                else
                    SetFlag(control.Checked ? flag : 0);
            }

            void ProcessDtpCheckBox(DateTimePicker control, FileFlags flag)
            {
                if (loading)
                    control.Checked = GetFlag(flag);
                else
                    SetFlag(control.Checked ? flag : 0);
            }

            void ProcessComboBox(ComboBox control, FileFlags yes, FileFlags no)
            {
                if (loading)
                    control.SelectedIndex = GetFlag(yes) ? 1 : GetFlag(no) ? 2 : 0;
                else
                    switch (control.SelectedIndex)
                    {
                        case 1: SetFlag(yes); break;
                        case 2: SetFlag(no); break;
                    }
            }

            bool GetFlag(FileFlags flag) => (FileOptions.Flags & flag) != 0;
            void SetFlag(FileFlags flag) => FileOptions.Flags |= flag;
        }

        private void Remove()
        {
            var node = SelectedNode;
            var level = node.Level;
            var lineType = LineTypes[level];
            if (MessageBox.Show(
                $"Remove '{node.Text}' from the available {lineType} list?",
                $"Delete the selected {lineType}",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                ) == DialogResult.Yes)
            {
                Nodes.Remove(node);
            }
        }

        private void SetNodeState(TreeNode node, TreeNodeState state) => TriStateTreeController.SetNodeState(node, state);

        private void SetSchema(Schema schema)
        {
            Nodes.Clear();
            foreach (var line in schema.Lines)
            {
                var nodes = Nodes;
                for (var level = line.Level; level > 0; level--)
                    nodes = nodes.OfType<TreeNode>().Last().Nodes;
                AddNode(nodes, line.Description, line.Filespecs, line.Check);
            }
        }

        private void UpdateUI()
        {
            BtnDelete.Enabled = PopupDelete.Enabled = SelectedNode?.Level > 0;
            SeFileSizeMin.Enabled = CbFileSizeMin.Checked;
            SeFileSizeMax.Enabled = CbFileSizeMax.Checked;
        }

        #endregion
    }
}
