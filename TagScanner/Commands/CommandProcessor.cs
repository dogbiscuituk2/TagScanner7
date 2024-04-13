namespace TagScanner.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Controllers;
    using Views;

    public class CommandProcessor : Controller
    {
        public CommandProcessor(LibraryFormController parent) : base(parent)
        {
            View.EditUndo.Click += EditUndo_Click;
            View.tbUndo.ButtonClick += EditUndo_Click;
            View.EditRedo.Click += EditRedo_Click;
            View.tbRedo.ButtonClick += EditRedo_Click;
        }

        private readonly Stack<Command> RedoStack = new Stack<Command>();
        private readonly Stack<Command> UndoStack = new Stack<Command>();

        private int LastSave, UpdateCount;

        private LibraryForm View => LibraryFormController.View;
        private LibraryFormController LibraryFormController => (LibraryFormController)Parent;

        private void EditRedo_Click(object sender, EventArgs e) => Redo();
        private void EditUndo_Click(object sender, EventArgs e) => Undo();

        private bool CanRedo => RedoStack.Count > 0;
        private bool CanUndo => UndoStack.Count > 0;

        private string RedoAction => RedoStack.Peek().RedoAction;
        private string UndoAction => UndoStack.Peek().UndoAction;

        private void BeginUpdate() { ++UpdateCount; }

        private void EndUpdate()
        {
            if (--UpdateCount == 0)
                UpdateUI();
        }

        private bool Redo() => CanRedo && Redo(RedoStack.Pop());

        private bool Redo(Command command, bool spoof = false)
        {
            var result = spoof || command.Do();
            if (result)
            {
                UndoStack.Push(command);
                UpdateUI();
            }
            return result;
        }

        private void RedoMultiple(object sender, EventArgs e)
        {
            BeginUpdate();
            var peek = ((ToolStripItem)sender).Tag;
            do Redo(); while (UndoStack.Peek() != peek);
            EndUpdate();
        }

        private bool Undo() => CanUndo && Undo(UndoStack.Pop());

        private bool Undo(Command command)
        {
            if (!command.Do())
                return false;
            RedoStack.Push(command);
            UpdateUI();
            return true;
        }

        private void UndoMultiple(object sender, EventArgs e)
        {
            BeginUpdate();
            var peek = ((ToolStripItem)sender).Tag;
            do Undo(); while (RedoStack.Peek() != peek);
            EndUpdate();
        }

        private void UpdateUI()
        {
            if (UpdateCount > 0)
                return;
            string
                undo = CanUndo ? $"Undo {UndoAction}" : "Undo",
                redo = CanRedo ? $"Redo {RedoAction}" : "Redo";
            View.EditUndo.Enabled = View.tbUndo.Enabled = CanUndo;
            View.EditRedo.Enabled = View.tbRedo.Enabled = CanRedo;
            View.EditUndo.Text = $"&{undo}";
            View.EditRedo.Text = $"&{redo}";
            View.tbUndo.ToolTipText = $"{undo} (^Z)";
            View.tbRedo.ToolTipText = $"{redo} (^Y)";
            //LibraryFormController.ModifiedChanged();
        }

    }
}
