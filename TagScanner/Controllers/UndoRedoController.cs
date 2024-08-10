namespace TagScanner.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Core;

    public abstract class UndoRedoController<TCommand> : Controller where TCommand : class, ICommand
    {
        #region Constructor

        protected UndoRedoController(Controller parent) : base(parent) { }

        #endregion

        #region Public Properties

        public bool IsModified => LastSave != UndoStack.Count;

        #endregion

        #region Public Methods

        public void Clear()
        {
            LastSave = 0;
            UndoStack.Clear();
            RedoStack.Clear();
            Updater.Run();
        }

        public void UpdateLocalUI()
        {
            if (Paused)
                return;
            UndoMenuItem.Enabled = UndoButton.Enabled = CanUndo;
            RedoMenuItem.Enabled = RedoButton.Enabled = CanRedo;
            string
                undo = CanUndo ? UndoAction : "Undo",
                redo = CanRedo ? RedoAction : "Redo";
            UndoMenuItem.Text = $"&{undo}";
            RedoMenuItem.Text = $"&{redo}";
            UndoButton.ToolTipText = $"{undo}";
            RedoButton.ToolTipText = $"{redo}";
        }

        #endregion

        #region Protected Fields

        protected int LastSave;

        protected IModel Model;

        protected readonly Stack<TCommand>
            UndoStack = new Stack<TCommand>(),
            RedoStack = new Stack<TCommand>();

        #endregion

        #region Protected Properties

        protected bool Busy;
        protected bool Paused => Updater.Paused;

        protected ToolStripMenuItem UndoMenuItem
        {
            get => _undoMenuItem;
            set => InitMenuItem(_undoMenuItem = value, undo: true);
        }

        protected ToolStripMenuItem RedoMenuItem
        {
            get => _redoMenuItem;
            set => InitMenuItem(_redoMenuItem = value, undo: false);
        }

        protected ToolStripSplitButton UndoButton
        {
            get => _undoButton;
            set => InitSplitButton(_undoButton = value, undo: true);
        }

        protected ToolStripSplitButton RedoButton
        {
            get => _redoButton;
            set => InitSplitButton(_redoButton = value, undo: false);
        }

        protected bool CanUndo => UndoStack.Count > 0;
        protected bool CanRedo => RedoStack.Count > 0;

        protected virtual string UndoAction => UndoStack.Peek().ToString();
        protected virtual string RedoAction => RedoStack.Peek().ToString();

        protected Action UpdateAction
        {
            get => Updater.Action;
            set => Updater.Action = value;
        }

        #endregion

        #region Protected Methods

        protected virtual void Do(TCommand command, bool undo, bool spoof)
        {
            if (!spoof)
            {
                Busy = true;
                command.Apply(Model);
                Busy = false;
            }
            var stack = undo ? RedoStack : UndoStack;
            stack.Push(command);
            UpdateAction();
            DumpStacks();
        }

        protected void Init(IModel model, Action updateAction,
            ToolStripMenuItem undoMenuItem, ToolStripMenuItem redoMenuItem,
            ToolStripSplitButton undoButton, ToolStripSplitButton redoButton)
        {
            Model = model;
            UpdateAction = updateAction;
            UndoMenuItem = undoMenuItem;
            RedoMenuItem = redoMenuItem;
            UndoButton = undoButton;
            RedoButton = redoButton;
        }

        protected virtual void Redo(TCommand command, bool spoof = false) => Do(command, undo: false, spoof);
        protected virtual void Undo(TCommand command) => Do(command, undo: true, spoof: false);

        /// <summary>
        /// Run a command, pushing its memento on to the Undo stack.
        /// </summary>
        /// <param name="command">The command to run.</param>
        /// <param name="spoof">A flag indicating whether the command should actually be run. 
        /// If true, the command should be run as normal. 
        /// If false, the relevant properties have already been changed on the target, 
        /// so just log the memento to the Undo stack.</param>
        /// <returns>True if the command was run, and actually caused a property change.</returns>
        public void Run(TCommand command, bool spoof = false)
        {
            if (Busy || command == null)
                return;
            if (LastSave > UndoStack.Count)
                LastSave = -1;
            RedoStack.Clear();
            Redo(command, spoof);
        }

        #endregion

        #region Private Fields

        private ToolStripMenuItem _undoMenuItem, _redoMenuItem;
        private ToolStripSplitButton _undoButton, _redoButton;

        private readonly UpdateController Updater = new UpdateController(null);

        #endregion

        #region Private Methods

        private void DoMultiple(object item, bool undo)
        {
            var peek = (TCommand)((ToolStripItem)item).Tag;
            if (undo)
                do Undo(); while (RedoStack.Peek() != peek);
            else
                do Redo(); while (UndoStack.Peek() != peek);
        }

        private void DoSingle(bool undo)
        {
            if (undo)
                Undo();
            else
                Redo();
        }

        private void DumpStacks()
        {
//#if UNDO_REDO
            DumpStack(undo: true);
            DumpStack(undo: false);
            Say("\n");
            return;

            void DumpStack(bool undo)
            {
                Say(undo ? "UNDO\n" : "REDO\n");
                var stack = undo ? UndoStack : RedoStack;
                if (stack.Any())
                    stack.ToList().ForEach(p => Say($"{p.Text}"));
                else
                    Say(" <empty>\n");
            }

            void Say(string s) => System.Diagnostics.Debug.Write(s);
//#endif
        }

        private static void HighlightMenu(ToolStripItem activeItem)
        {
            if (!activeItem.Selected)
                return;
            var items = activeItem.GetCurrentParent().Items;
            var index = items.IndexOf(activeItem);
            foreach (ToolStripItem item in items)
                item.BackColor = Color.FromKnownColor(items.IndexOf(item) <= index
                    ? KnownColor.GradientActiveCaption
                    : KnownColor.Control);
        }

        private void InitDropDownItem(ToolStripDropDownItem item, bool undo) =>
            item.DropDownOpening += (sender, e) => PopulateMenu(undo);

        private void InitMenuItem(ToolStripMenuItem item, bool undo)
        {
            item.Click += (sender, e) => DoSingle(undo);
            InitDropDownItem(item, undo);
        }

        private void InitSplitButton(ToolStripSplitButton button, bool undo)
        {
            button.ButtonClick += (sender, e) => DoSingle(undo);
            InitDropDownItem(button, undo);
        }

        private void PopulateMenu(bool undo)
        {
            var commands = (undo ? UndoStack : RedoStack).ToArray();
            var menuItems = (undo ? MainForm.UndoPopupMenu : MainForm.RedoPopupMenu).Items;
            var handler = (EventHandler)((sender, e) => DoMultiple(sender, undo));
            const int MaxItems = 20;
            menuItems.Clear();
            for (int n = 0; n < Math.Min(commands.Length, MaxItems); n++)
            {
                var command = commands[n];
                var item = new ToolStripMenuItem(command.ToString().Escape(), null, handler) { Tag = command };
                item.MouseEnter += (sender, e) => HighlightMenu((ToolStripItem)sender);
                item.Paint += (sender, e) => HighlightMenu((ToolStripItem)sender);
                menuItems.Add(item);
            }
        }

        private void Undo() { if (CanUndo) Undo(UndoStack.Pop()); }
        private void Redo() { if (CanRedo) Redo(RedoStack.Pop()); }

        #endregion
    }
}
