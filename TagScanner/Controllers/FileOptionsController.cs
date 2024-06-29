﻿namespace TagScanner.Controllers
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Forms;
    using Models;
    using Utils;

    public class FileOptionsController : Controller
    {
        #region Constructor

        public FileOptionsController(Controller parent) : base(parent)
        {
            MainForm.AddOptions.Click += AddOptions_Click;
        }

        #endregion

        #region Public Properties

        public string Schema
        {
            get
            {
                var schema = new StringBuilder();
                AddNodes(Nodes);
                return schema.ToString();

                void AddNode(TreeNode node)
                {
                    schema.AppendLine(NodeString(node));
                    AddNodes(node.Nodes);
                }

                void AddNodes(TreeNodeCollection nodes)
                {
                    foreach (TreeNode node in nodes)
                        AddNode(node);
                }

                string NodeString(TreeNode node)
                {
                    var text = node.Text;
                    switch (node.Level)
                    {
                        case 0:
                            return text;
                        case 1:
                            return $">{text}";
                        default:
                            var filespec = node.Tag.ToString();
                            return $"{filespec}>{text.Substring(0, text.Length - filespec.Length - 3)}";
                    }
                }
            }
            set
            {
                Nodes.Clear();
                foreach (var item in value.TextToStrings().Where(p => !string.IsNullOrWhiteSpace(p)))
                {
                    int
                        count = item.Length,
                        index = item.IndexOf('>');
                    string
                        description = item.Substring(index + 1, count - index - 1),
                        filespec = index > 0 ? item.Substring(0, index) : string.Empty;
                    var nodes = Nodes;
                    for (var level = Math.Sign(index); level > -1; level--)
                        nodes = nodes.OfType<TreeNode>().Last().Nodes;
                    var node = nodes.Add(description);
                    InitNode(node, description, filespec, TreeNodeState.Unchecked);
               }
            }
        }

        #endregion

        #region Public Methods

        public bool Execute(ref FileOptions options)
        {
            if (View == null)
                CreateView();

            var foo = Schema;
            Schema = foo;
            var bar = Schema;

            Process(options, loading: true);
            UpdateUI();
            var ok = View.ShowDialog(Owner) == DialogResult.OK;
            if (ok)
                options = Process(new FileOptions(), loading: false);
            return ok;
        }

        #endregion

        #region Private Fields

        private FileOptionsDialog View;
        private TriStateTreeController TriStateTreeController;
        private bool Updating;

        private Button
            BtnAdd, BtnEdit, BtnDelete;

        private CheckBox
            CbCreatedMin, CbCreatedMax, CbCreatedUtc,
            CbModifiedMin, CbModifiedMax, CbModifiedUtc,
            CbAccessedMin, CbAccessedMax, CbAccessedUtc,
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
        private TreeNode RootNode => Nodes[0];
        private TreeView TreeView => View.TreeView;

        private TreeNode SelectedNode
        {
            get => TreeView.SelectedNode;
            set => TreeView.SelectedNode = value;
        }

        #endregion

        #region Event Handlers

        private void AddOptions_Click(object sender, EventArgs e)
        {
            var options = new FileOptions();
            Execute(ref options);
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e) => UpdateUI();
        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e) => UpdateUI();

        #endregion

        #region Private Methods

        private void Add()
        {
            var description = string.Empty;
            var filespec = string.Empty;
            if (EditValue("Add a new File Format", ref description, ref filespec))
            {
                var node = OtherFormats.Nodes.Add(description);
                InitNode(node, description, filespec, TreeNodeState.Checked);
            }
        }

        private void AdjustDate(DateTimePicker min, DateTimePicker max, bool lower)
        {
            if (!Updating)
            {
                Updating = true;
                if (lower)
                {
                    if (min.Value > max.Value)
                        min.Value = max.Value;
                }
                else
                {
                    if (max.Value < min.Value)
                        max.Value = min.Value;
                }
                Updating = false;
            }
        }

        private void AdjustFileSize(bool lower)
        {
            if (!Updating)
            {
                Updating = true;
                decimal
                    min = SeFileSizeMin.Value,
                    max = SeFileSizeMax.Value;
                if (lower)
                    SeFileSizeMin.Value = Math.Min(min, max);
                else
                    SeFileSizeMax.Value = Math.Max(min, max);
                Updating = false;
            }
            AdjustIncrement(SeFileSizeMin);
            AdjustIncrement(SeFileSizeMax);
        }

        private void AdjustIncrement(NumericUpDown control) =>
            control.Increment = Math.Max(1, Math.Truncate(control.Value / 100));

        private void CreateView()
        {
            View = new FileOptionsDialog();
            TriStateTreeController = new TriStateTreeController(TreeView);
            SetNodeState(RootNode, TreeNodeState.Unchecked);

            BtnAdd = View.btnAdd;
            BtnEdit = View.btnEdit;
            BtnDelete = View.btnDelete;

            CbCreatedMin = View.cbCreatedMin;
            CbCreatedMax = View.cbCreatedMax;
            CbCreatedUtc = View.cbCreatedUtc;
            CbModifiedMin = View.cbModifiedMin;
            CbModifiedMax = View.cbModifiedMax;
            CbModifiedUtc = View.cbModifiedUtc;
            CbAccessedMin = View.cbAccessedMin;
            CbAccessedMax = View.cbAccessedMax;
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

            CbCreatedMin.CheckedChanged += CheckBox_CheckedChanged;
            CbModifiedMin.CheckedChanged += CheckBox_CheckedChanged;
            CbAccessedMin.CheckedChanged += CheckBox_CheckedChanged;
            CbFileSizeMin.CheckedChanged += CheckBox_CheckedChanged;
            CbCreatedMax.CheckedChanged += CheckBox_CheckedChanged;
            CbModifiedMax.CheckedChanged += CheckBox_CheckedChanged;
            CbAccessedMax.CheckedChanged += CheckBox_CheckedChanged;
            CbFileSizeMax.CheckedChanged += CheckBox_CheckedChanged;

            DtpCreatedMin.ValueChanged += (sender, e) => AdjustDate(DtpCreatedMin, DtpCreatedMax, lower: false);
            DtpCreatedMax.ValueChanged += (sender, e) => AdjustDate(DtpCreatedMin, DtpCreatedMax, lower: true);
            DtpModifiedMin.ValueChanged += (sender, e) => AdjustDate(DtpModifiedMin, DtpModifiedMax, lower: false);
            DtpModifiedMax.ValueChanged += (sender, e) => AdjustDate(DtpModifiedMin, DtpModifiedMax, lower: true);
            DtpAccessedMin.ValueChanged += (sender, e) => AdjustDate(DtpAccessedMin, DtpAccessedMax, lower: false);
            DtpAccessedMax.ValueChanged += (sender, e) => AdjustDate(DtpAccessedMin, DtpAccessedMax, lower: true);

            SeFileSizeMin.ValueChanged += (sender, e) => AdjustFileSize(lower: false);
            SeFileSizeMax.ValueChanged += (sender, e) => AdjustFileSize(lower: true);

            BtnAdd.Click += (sender, e) => Add();
            PopupAdd.Click += (sender, e) => Add();
            BtnEdit.Click += (sender, e) => Edit();
            PopupEdit.Click += (sender, e) => Edit();
            BtnDelete.Click += (sender, e) => Remove();
            PopupDelete.Click += (sender, e) => Remove();
        }

        private void Edit()
        {
            var node = SelectedNode;
            var description = node.Text;
            var filespec = node.Tag.ToString();
            description = description.Substring(0, description.Length - filespec.Length - 3);
            if (EditValue("Edit this File Format", ref description, ref filespec))
                InitNode(node, description, filespec);
        }

        private bool EditValue(string prompt, ref string description, ref string filespec) =>
            new FileFormatController(this).Execute(prompt, ref description, ref filespec);

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

        private void InitNode(TreeNode node, string description, string filespec, TreeNodeState state = TreeNodeState.Indeterminate)
        {
            SelectedNode = node;
            node.Text = string.IsNullOrWhiteSpace(filespec) ? description : $"{description} ({filespec})";
            node.Tag = filespec;
            if (state != TreeNodeState.Indeterminate)
                SetNodeState(node, state);
            node.EnsureVisible();
            TreeView.Focus();
        }

        private FileOptions Process(FileOptions options, bool loading)
        {
            if (loading)
                SetFileFormats(options.FileFormats);
            else
                options.FileFormats = GetFileFormats();

            ProcessCheckBox(CbCreatedMin, FileFlags.DateCreatedMin);
            ProcessCheckBox(CbCreatedMax, FileFlags.DateCreatedMax);
            ProcessCheckBox(CbCreatedUtc, FileFlags.DateCreatedUtc);
            ProcessCheckBox(CbModifiedMin, FileFlags.DateModifiedMin);
            ProcessCheckBox(CbModifiedMax, FileFlags.DateModifiedMax);
            ProcessCheckBox(CbModifiedUtc, FileFlags.DateModifiedUtc);
            ProcessCheckBox(CbAccessedMin, FileFlags.DateAccessedMin);
            ProcessCheckBox(CbAccessedMax, FileFlags.DateAccessedMax);
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

        private void UpdateUI()
        {
            BtnEdit.Enabled = PopupEdit.Enabled = BtnDelete.Enabled = PopupDelete.Enabled =
                SelectedNode?.Level == 2;
            DtpCreatedMin.Enabled = CbCreatedMin.Checked;
            DtpModifiedMin.Enabled = CbModifiedMin.Checked;
            DtpAccessedMin.Enabled = CbAccessedMin.Checked;
            DtpCreatedMax.Enabled = CbCreatedMax.Checked;
            DtpModifiedMax.Enabled = CbModifiedMax.Checked;
            DtpAccessedMax.Enabled = CbAccessedMax.Checked;
            SeFileSizeMin.Enabled = CbFileSizeMin.Checked;
            SeFileSizeMax.Enabled = CbFileSizeMax.Checked;
        }

        #endregion
    }
}
