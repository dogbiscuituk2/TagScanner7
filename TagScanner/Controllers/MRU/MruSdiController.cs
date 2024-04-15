﻿namespace TagScanner.Controllers.Mru
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Windows.Forms;
    using Models;
    using Properties;
    using Streaming;

    public abstract class MruSdiController : MruMenuController
    {
        #region Constructor

        protected MruSdiController(IModel model, string filter, string subKeyName, ToolStripItemCollection recentItems, IWin32Window owner = null)
            : base(subKeyName, recentItems)
        {
            Model = model;
            Owner = owner;
            _openFileDialog = new OpenFileDialog { Filter = filter, Title = Resources.Select_the_file_to_open };
            _saveFileDialog = new SaveFileDialog { Filter = filter, Title = Resources.Save_file };
            RefreshRecentMenu();
        }

        #endregion

        #region Properties & Fields

        public string FilePath
        {
            get => _filePath;
            set
            {
                if (FilePath == value) return;
                _filePath = value;
                OnFilePathChanged();
            }
        }

        protected IModel Model;
        protected IWin32Window Owner;

        private string _filePath = string.Empty;
        private readonly OpenFileDialog _openFileDialog;
        private readonly SaveFileDialog _saveFileDialog;

        #endregion

        #region Methods

        public bool Clear()
        {
            if (!SaveIfModified())
                return false;
            ClearDocument();
            Model.Modified = false;
            FilePath = string.Empty;
            return true;
        }

        protected abstract void ClearDocument();

        protected object LoadDocument(Stream stream, Type documentType, StreamFormat format)
        {
            var result = Streamer.LoadFromStream(stream, documentType, format);
            if (result != null)
                Model.Modified = false;
            return result;
        }

        private bool LoadFromFile(string filePath, StreamFormat format)
        {
            if (!OnFileLoading()) return false;
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                if (!LoadFromStream(stream, format))
                    return false;
            FilePath = filePath;
            AddItem(filePath);
            return true;
        }

        protected abstract bool LoadFromStream(Stream stream, StreamFormat format);

        public bool Open()
        {
            if (!SaveIfModified() || _openFileDialog.ShowDialog(Owner) != DialogResult.OK)
                return false;
            var fileName = _openFileDialog.FileName;
            var format = fileName.GetStreamFormat();
            return LoadFromFile(fileName, format);
        }

        protected override void Reopen(ToolStripItem menuItem)
        {
            var filePath = menuItem.ToolTipText;
            if (File.Exists(filePath))
            {
                if (SaveIfModified())
                    LoadFromFile(filePath, filePath.GetStreamFormat());
            }
            else if (MessageBox.Show(Owner,
                $"File \"{filePath}\" no longer exists. Remove from menu?",
                "Reopen file",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
                RemoveItem(filePath);
        }

        public bool Save() => string.IsNullOrEmpty(FilePath) ? SaveAs() : SaveToFile(FilePath, FilePath.GetStreamFormat());

        public bool SaveAs()
        {
            if (_saveFileDialog.ShowDialog(Owner) != DialogResult.OK)
                return false;
            var fileName = _saveFileDialog.FileName;
            var format = fileName.GetStreamFormat();
            return SaveToFile(fileName, format);
        }

        protected bool SaveDocument(Stream stream, object document, StreamFormat format)
        {
            var result = Streamer.SaveToStream(stream, document, format);
            if (result)
                Model.Modified = false;
            return result;
        }

        public bool SaveIfModified()
        {
            if (!Model.Modified) return true;
            switch (MessageBox.Show(Owner,
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

        private bool SaveToFile(string filePath, StreamFormat format)
        {
            if (!OnFileSaving()) return false;
            using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                if (SaveToStream(stream, format))
                {
                    stream.Flush();
                    FilePath = filePath;
                    AddItem(filePath);
                    return true;
                }
            }
            return false;
        }

        protected abstract bool SaveToStream(Stream stream, StreamFormat format);

        #endregion

        #region Event Handlers

        public event EventHandler<CancelEventArgs> FileLoading;
        public event EventHandler<CancelEventArgs> FileSaving;
        public event EventHandler FilePathChanged;

        protected virtual bool OnFileLoading()
        {
            var fileLoading = FileLoading;
            if (fileLoading == null) return true;
            var e = new CancelEventArgs();
            fileLoading(this, e);
            return !e.Cancel;
        }

        protected virtual void OnFilePathChanged()
        {
            var filePathChanged = FilePathChanged;
            filePathChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual bool OnFileSaving()
        {
            var fileSaving = FileSaving;
            if (fileSaving == null) return true;
            var e = new CancelEventArgs();
            fileSaving(this, e);
            return !e.Cancel;
        }

        #endregion
    }
}
