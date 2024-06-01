namespace TagScanner.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public class TriStateTreeview : TreeView
    {
        #region Lifetime Management

        public TriStateTreeview()
        {
            InitializeComponent();
            DrawMode = TreeViewDrawMode.OwnerDrawAll;
            CheckBoxes = true;
            _3rdStateImage = _imageList.Images[2];
            base.StateImageList = _imageList;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _graphics != null)
            {
                _graphics.Dispose();
                _graphics = null;
                if (_components != null)
                    _components.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Public Properties

        // Since ThreeStateTreeview comes with its own StateImageList, prevent reassignment.
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ImageList StateImageList
        {
            get => base.StateImageList;
            set { }
        }

        #endregion

        #region Public Methods

        public CheckState GetNodeCheckState(TreeNode node) => (CheckState)Math.Max(0, node.StateImageIndex);

        #endregion

        #region Protected Methods

        protected override void OnAfterCheck(TreeViewEventArgs e)
        {
            if (_ignoreCheckEvents)
                return;
            _ignoreCheckEvents = true;
            try
            {
                TreeNode node = e.Node;
                var state = Math.Max(0, node.StateImageIndex) == 1 ? 0 : 1;
                if (node.Checked != (state == 1))
                    return;
                InheritCheckstate(node, state);
                for (node = node.Parent; node != null; node = node.Parent)
                {
                    if (state != 2 && node.Nodes.Cast<TreeNode>().Any(p => p.StateImageIndex != state))
                        state = 2;
                    AssignState(node, state);
                }
                base.OnAfterCheck(e);
            }
            finally
            {
                _ignoreCheckEvents = false;
            }
        }

        protected override void OnBeforeCheck(TreeViewCancelEventArgs e)
        {
            if (!_ignoreCheckEvents)
                base.OnBeforeCheck(e);
        }

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            if (e.Node.StateImageIndex == 2)
                _3rdStateNodes.Add(e.Node);
            e.DrawDefault = true;
            base.OnDrawNode(e);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            _graphics = CreateGraphics();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (_graphics != null)
            {
                _graphics.Dispose();
                _graphics = CreateGraphics();
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_LBUTTONDBLCLK = 0x0203;
            if (m.Msg == WM_LBUTTONDBLCLK)
            {
                var p = PointToClient(MousePosition);
                if (HitTest(p).Location == TreeViewHitTestLocations.StateImage)
                    return;
            }
            const int WM_Paint = 15;
            base.WndProc(ref m);
            if (m.Msg == WM_Paint)
            {
                foreach (TreeNode nd in _3rdStateNodes)
                    _graphics.DrawImage(_3rdStateImage, GetCheckRect(nd).Location);
                _3rdStateNodes.Clear();
            }
        }

        #endregion

        #region Private Fields

        private Image _3rdStateImage;
        private List<TreeNode> _3rdStateNodes = new List<TreeNode>();
        private IContainer _components;
        private Graphics _graphics;
        private bool _ignoreCheckEvents = false;
        private ImageList _imageList;

        #endregion

        #region Private Methods

        private void AssignState(TreeNode node, int state)
        {
            bool check = state == 1;
            bool invalid = node.StateImageIndex != state;
            if (invalid)
                node.StateImageIndex = state;
            if (node.Checked != check)
                node.Checked = check;
            else if (invalid)
                Invalidate(GetCheckRect(node));
        }

        private Rectangle GetCheckRect(TreeNode node)
        {
            var p = node.Bounds.Location;
            p.X -= ImageList == null ? 16 : 35;
            return new Rectangle(p.X, p.Y, 16, 16);
        }

        private void InheritCheckstate(TreeNode node, int state)
        {
            AssignState(node, state);
            foreach (TreeNode child in node.Nodes)
                InheritCheckstate(child, state);
        }

        private void InitializeComponent()
        {
            _components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(TriStateTreeview));
            _imageList = new ImageList(_components);
            SuspendLayout();
            // 
            // imageList1
            // 
            _imageList.ImageStream = ((ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            _imageList.TransparentColor = Color.Transparent;
            _imageList.Images.SetKeyName(0, "UnChecked.ico");
            _imageList.Images.SetKeyName(1, "Checked.ico");
            _imageList.Images.SetKeyName(2, "Indeterminated.ico");
            // 
            // ThreeStateTreeview
            // 
            LineColor = Color.Black;
            ResumeLayout(false);
        }

        #endregion
    }
}
