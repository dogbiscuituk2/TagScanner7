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

        public FileOptionsController(Controller parent) : base(parent)
        {
            MainForm.AddOptions.Click += AddOptions_Click;
        }

        #endregion

        #region Public Properties

        public ErrorProvider ErrorProvider => View.ErrorProvider;

        public Schema Schema
        {
            get => GetSchema();
            set => SetSchema(value);
        }

        #endregion

        #region Public Methods

        public bool Execute(ref FileOptions options)
        {
            if (View == null)
                CreateView();
            Process(options, loading: true);
            UpdateUI();
            var ok = View.ShowDialog(Owner) == DialogResult.OK;
            if (ok)
            {
                options = Process(new FileOptions(), loading: false);
                AppController.WriteSchema(Schema);
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

        private FileOptionsDialog View;
        private TriStateTreeController TriStateTreeController;
        private ErrorController ErrorController;
        private bool Updating;

        private Button
            BtnAdd, BtnEdit, BtnDelete;

        private CheckBox
            CbCreatedUtc, CbModifiedUtc, CbAccessedUtc,
            CbFileSizeMin, CbFileSizeMax;

        private ComboBox
            CbReadOnly, CbHidden, CbSystem, CbArchive;

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
        private TreeNode OtherFormats => RootNode.Nodes[3];
        private TreeNode RootNode => Nodes.Count > 0 ? Nodes[0] : null;
        private TreeView TreeView => View.TreeView;

        private TreeNode SelectedNode
        {
            get => TreeView.SelectedNode;
            set => TreeView.SelectedNode = value;
        }

        #endregion

        #region Event Handlers

        private void AddOptions_Click(object sender, EventArgs e) => AddOptions();
        private void CheckBox_CheckedChanged(object sender, EventArgs e) => UpdateUI();
        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e) => UpdateUI();

        #endregion

        #region Private Methods

        private void Add()
        {
            string
                description = string.Empty,
                filespecs = string.Empty;
            if (EditValue("Add a new File Format", ref description, ref filespecs))
                AddNode(OtherFormats.Nodes, description, filespecs, check: true);
        }

        private void AddNode(TreeNodeCollection nodes, string description, string filespecs, bool check)
        {
            var node = nodes.Add(description);
            InitNode(node, description, filespecs, check ? TreeNodeState.Checked : TreeNodeState.Unchecked);
        }

        private void AddOptions()
        {
            var options = new FileOptions();
            Execute(ref options);
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
            Schema = AppController.Schema;
            var root = RootNode;
            if (root != null)
                foreach (TreeNode node in RootNode.Nodes)
                    node.Collapse();

            ErrorController = new ErrorController(this,
                DtpCreatedMin, DtpCreatedMax,
                DtpModifiedMin, DtpModifiedMax,
                DtpAccessedMin, DtpAccessedMax,
                SeFileSizeMin, SeFileSizeMax);
        }

        private void Edit()
        {
            var node = SelectedNode;
            var description = node.Text;
            var filespecs = node.Tag.ToString();
            description = description.Substring(0, description.Length - filespecs.Length - 3);
            if (EditValue("Edit this File Format", ref description, ref filespecs))
                InitNode(node, description, filespecs);
        }

        private bool EditValue(string prompt, ref string description, ref string filespecs) =>
            new FileFormatController(this).Execute(prompt, ref description, ref filespecs);

        private string GetFileFormats()
        {
            var formats = new StringBuilder();
            Traverse(Nodes);
            return formats.ToString();

            void Traverse(TreeNodeCollection nodes)
            {
                foreach (TreeNode node in nodes)
                {
                    if (node.Tag != null && node.StateImageIndex == 1)
                    {
                        if (formats.Length > 0)
                            formats.Append('|');
                        formats.Append(node.Tag);
                    }
                    Traverse(node.Nodes);
                }
            }
        }

        private static TreeNodeState GetNodeState(TreeNode node) => (TreeNodeState)node.StateImageIndex;

        private Schema GetSchema()
        {
            var schema = new Schema();
            AddNodes(Nodes);
            return schema;

            void AddNode(TreeNode node)
            {
                Schema.AddLine(NodeToLine(node));
                AddNodes(node.Nodes);
            }

            void AddNodes(TreeNodeCollection nodes)
            {
                foreach (TreeNode node in nodes)
                    AddNode(node);
            }

            SchemaLine NodeToLine(TreeNode node)
            {
                var text = node.Text;
                var filespecs = node.Tag.ToString();
                var description = text.Substring(0, text.Length - filespecs.Length - 3);
                var check = GetNodeState(node) == TreeNodeState.Checked;
                return new SchemaLine(node.Level, description, filespecs, check);
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

        private FileOptions Process(FileOptions options, bool loading)
        {
            if (loading)
                SetSchema(options.Schema);
            else
                options.Schema = GetSchema();

            ProcessDtpCheckBox(DtpCreatedMin, FileFlags.DateCreatedMin);
            ProcessDtpCheckBox(DtpCreatedMax, FileFlags.DateCreatedMax);
            ProcessCheckBox(CbCreatedUtc, FileFlags.DateCreatedUtc);
            ProcessDtpCheckBox(DtpModifiedMin, FileFlags.DateModifiedMin);
            ProcessDtpCheckBox(DtpModifiedMax, FileFlags.DateModifiedMax);
            ProcessCheckBox(CbModifiedUtc, FileFlags.DateModifiedUtc);
            ProcessDtpCheckBox(DtpAccessedMin, FileFlags.DateAccessedMin);
            ProcessDtpCheckBox(DtpAccessedMax, FileFlags.DateAccessedMax);
            ProcessCheckBox(CbAccessedUtc, FileFlags.DateAccessedUtc);
            ProcessCheckBox(CbFileSizeMin, FileFlags.FileSizeMin);
            ProcessCheckBox(CbFileSizeMax, FileFlags.FileSizeMax);

            if (loading)
            {
                DtpCreatedMin.Value = options.DateCreatedMin;
                DtpCreatedMax.Value = options.DateCreatedMax;
                DtpModifiedMin.Value = options.DateModifiedMin;
                DtpModifiedMax.Value = options.DateModifiedMax;
                DtpAccessedMin.Value = options.DateAccessedMin;
                DtpAccessedMax.Value = options.DateAccessedMax;
                SeFileSizeMin.Value = options.FileSizeMin;
                SeFileSizeMax.Value = options.FileSizeMax;
            }
            else
            {
                options.DateCreatedMin = DtpCreatedMin.Value;
                options.DateCreatedMax = DtpCreatedMax.Value;
                options.DateModifiedMin = DtpModifiedMin.Value;
                options.DateModifiedMax = DtpModifiedMax.Value;
                options.DateAccessedMin = DtpAccessedMin.Value;
                options.DateAccessedMax = DtpAccessedMax.Value;
                options.FileSizeMin = (ulong)SeFileSizeMin.Value;
                options.FileSizeMax = (ulong)SeFileSizeMax.Value;
            }

            ProcessComboBox(CbReadOnly, FileFlags.ReadOnlyTrue, FileFlags.ReadOnlyFalse);
            ProcessComboBox(CbHidden, FileFlags.HiddenTrue, FileFlags.HiddenFalse);
            ProcessComboBox(CbSystem, FileFlags.SystemTrue, FileFlags.SystemFalse);
            ProcessComboBox(CbArchive, FileFlags.ArchiveTrue, FileFlags.ArchiveFalse);

            return options;

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

            bool GetFlag(FileFlags flag) => (options.Flags & flag) != 0;
            void SetFlag(FileFlags flag) => options.Flags |= flag;
        }

        private void Remove()
        {
            var node = SelectedNode;
            if (MessageBox.Show(
                $"Remove '{node.Text}' from the list of available file formats?",
                "Remove File Format",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                ) == DialogResult.Yes)
            {
                Nodes.Remove(node);
                SelectedNode = OtherFormats;
            }
        }

        private void SetFileFormats(string formats)
        {
            formats = $"|{formats}|";
            Traverse(Nodes);

            void Traverse(TreeNodeCollection nodes)
            {
                foreach (TreeNode node in nodes)
                {
                    if (node.Tag != null)
                    {
                        var check = formats.Contains($"|{node.Tag}|");
                        SetNodeState(node, check ? TreeNodeState.Checked : TreeNodeState.Unchecked);
                    }
                    Traverse(node.Nodes);
                }
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
            BtnEdit.Enabled = PopupEdit.Enabled = BtnDelete.Enabled = PopupDelete.Enabled =
                SelectedNode?.Level == 2;
            SeFileSizeMin.Enabled = CbFileSizeMin.Checked;
            SeFileSizeMax.Enabled = CbFileSizeMax.Checked;
        }

        #endregion
    }
}
