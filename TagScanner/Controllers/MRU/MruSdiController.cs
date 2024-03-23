namespace TagScanner.Controllers.Mru
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Serialization;
    using Models;
    using Properties;
    using Utils;

    public abstract class MruSdiController : MruController
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

        protected abstract XmlSerializer GetXmlSerializer();

        protected abstract bool LoadFromStream(Stream stream, string format);
        protected abstract bool SaveToStream(Stream stream, string format);

        protected object LoadDocument(Stream stream, string format)
        {
            /*
				The asymmetrical use of XmlTextReader below is necessitated by a bug in .NET's XML Serialization routines.
				These can serialize an object to XML, which will subsequently throw an exception when trying to deserialize.
				For example, when a string contains an unprintable character like char(1), this will get serialized to &#x1;
				but fail on subsequent attempted deserialization. Note that it is actually the serialization step which is at
				fault, because the definition of an XML character (see "http://www.w3.org/TR/2000/REC-xml-20001006#charsets")
				specifically excludes all such control characters except tab, line feed, and carriage return:

					Char ::= #x9 | #xA | #xD | [#x20-#xD7FF] | [#xE000-#xFFFD] | [#x10000-#x10FFFF]

				The use of XmlTextReader gets round this problem by defaulting its Normalization property to false, hence
				disabling character range checking for numeric entities. As a result, character entities such as &#1; are
				allowed during deserialization too. The default TextReader variant on the other hand creates an XmlTextReader
				with its Normalization property set to true, which was causing the observed failure at deserialization time.
			*/
            object result = null;
            if (format.IsXmlFile())
                UseStream(() => result = GetXmlSerializer().Deserialize(new XmlTextReader(stream)));
            else
                UseStream(() => result = new BinaryFormatter().Deserialize(stream));
            return result;
        }

        protected bool SaveDocument(Stream stream, string format, object document) =>
            format.IsXmlFile()
            ? UseStream(() => GetXmlSerializer().Serialize(stream, document))
            : UseStream(() => new BinaryFormatter().Serialize(stream, document));
    }
}
