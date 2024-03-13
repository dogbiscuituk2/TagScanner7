namespace TagScanner.Controllers.MRU
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Windows.Forms;
    using Models;
    using Properties;

    internal abstract class MruSdiController : MruController
    {
        protected MruSdiController(IModel model, string filter, string subKeyName, ToolStripMenuItem recentMenuItem)
            : base(subKeyName, recentMenuItem)
        {
            Model = model;
            _openFileDialog = new OpenFileDialog { Filter = filter, Title = Resources.Select_the_file_to_open };
            _saveFileDialog = new SaveFileDialog { Filter = filter, Title = Resources.Save_file };
        }

        protected IModel Model;

        internal bool Clear()
        {
            if (!SaveIfModified())
                return false;
            ClearDocument();
            Model.Modified = false;
            FilePath = string.Empty;
            return true;
        }

        internal bool Open() => SaveIfModified() && _openFileDialog.ShowDialog() == DialogResult.OK && LoadFromFile(_openFileDialog.FileName);
        internal bool Save() => string.IsNullOrEmpty(FilePath) ? SaveAs() : SaveToFile(FilePath);
        internal bool SaveAs() => _saveFileDialog.ShowDialog() == DialogResult.OK && SaveToFile(_saveFileDialog.FileName);

        internal bool SaveIfModified()
        {
            if (!Model.Modified) return true;
            switch (MessageBox.Show(
                        "The contents of this file have changed. Do you want to save the changes?",
                        "File modified",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Warning))
            {
                case DialogResult.Yes: return Save();
                case DialogResult.No: return true;
                case DialogResult.Cancel: return false;
            }
            return true;
        }

        internal event EventHandler FilePathChanged;

        internal event EventHandler<CancelEventArgs> FileLoading;
        internal event EventHandler<CancelEventArgs> FileSaving;

        private string _filePath = string.Empty;
        protected string FilePath
        {
            get => _filePath;
            set
            {
                if (FilePath == value) return;
                _filePath = value;
                OnFilePathChanged();
            }
        }

        protected abstract void ClearDocument();

        protected abstract bool LoadFromStream(Stream stream, string format);

        protected virtual void OnFilePathChanged()
        {
            var filePathChanged = FilePathChanged;
            filePathChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual bool OnFileLoading()
        {
            var fileLoading = FileLoading;
            if (fileLoading == null) return true;
            var e = new CancelEventArgs();
            fileLoading(this, e);
            return !e.Cancel;
        }

        protected virtual bool OnFileSaving()
        {
            var fileSaving = FileSaving;
            if (fileSaving == null) return true;
            var e = new CancelEventArgs();
            fileSaving(this, e);
            return !e.Cancel;
        }

        protected override void Reopen(ToolStripItem menuItem)
        {
            var filePath = menuItem.ToolTipText;
            if (File.Exists(filePath))
            {
                if (SaveIfModified())
                    LoadFromFile(filePath);
            }
            else if (MessageBox.Show(
                $"File \"{filePath}\" no longer exists. Remove from menu?",
                "Reopen file",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
                RemoveItem(filePath);
        }

        protected abstract bool SaveToStream(Stream stream, string format);

        protected bool UseStream(Action action)
        {
            var result = true;
            try
            {
                action();
                Model.Modified = false;
            }
            catch (Exception x)
            {
                MessageBox.Show(
                    x.Message,
                    x.GetType().Name,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                result = false;
            }
            return result;
        }

        private readonly OpenFileDialog _openFileDialog;
        private readonly SaveFileDialog _saveFileDialog;

        private bool LoadFromFile(string filePath)
        {
            if (!OnFileLoading()) return false;
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                if (!LoadFromStream(stream, Path.GetExtension(filePath)))
                    return false;
            FilePath = filePath;
            AddItem(filePath);
            return true;
        }

        private bool SaveToFile(string filePath)
        {
            if (!OnFileSaving()) return false;
            using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                if (SaveToStream(stream, Path.GetExtension(filePath)))
                {
                    stream.Flush();
                    FilePath = filePath;
                    AddItem(filePath);
                    return true;
                }
            }
            return false;
        }
    }
}
