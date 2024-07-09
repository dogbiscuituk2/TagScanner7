namespace TagScanner.Models
{
    using System;
    using System.IO;
    using Terms;

    [Serializable]
    public class FileOptions
    {
        public FileOptions()
        {
            CreatedMin = ModifiedMin = AccessedMin =
                CreatedMax = ModifiedMax = AccessedMax =
                DateTime.Today;
        }

        public FileFlags Flags { get; set; }

        public DateTime CreatedMax { get; set; }
        public DateTime CreatedMin { get; set; }

        public DateTime ModifiedMax { get; set; }
        public DateTime ModifiedMin { get; set; }

        public DateTime AccessedMax { get; set; }
        public DateTime AccessedMin { get; set; }

        public ulong FileSizeMax { get; set; }
        public ulong FileSizeMin { get; set; }

        public Conjunction GetFilter()
        {
            var filter = new Conjunction();
            AddDate(FileFlags.CreatedMin, FileFlags.CreatedUtc, Tag.FileCreated, Tag.FileCreatedUtc, Op.NotLessThan, CreatedMin);
            AddDate(FileFlags.CreatedMax, FileFlags.CreatedUtc, Tag.FileCreated, Tag.FileCreatedUtc, Op.NotGreaterThan, CreatedMax);
            AddDate(FileFlags.ModifiedMin, FileFlags.ModifiedUtc, Tag.FileModified, Tag.FileModifiedUtc, Op.NotLessThan, ModifiedMin);
            AddDate(FileFlags.ModifiedMax, FileFlags.ModifiedUtc, Tag.FileModified, Tag.FileModifiedUtc, Op.NotGreaterThan, ModifiedMax);
            AddDate(FileFlags.AccessedMin, FileFlags.AccessedUtc, Tag.FileAccessed, Tag.FileAccessedUtc, Op.NotLessThan, AccessedMin);
            AddDate(FileFlags.AccessedMax, FileFlags.AccessedUtc, Tag.FileAccessed, Tag.FileAccessedUtc, Op.NotGreaterThan, AccessedMax);
            AddSize(FileFlags.FileSizeMin, Tag.FileSize, Op.NotLessThan, FileSizeMin);
            AddSize(FileFlags.FileSizeMax, Tag.FileSize, Op.NotGreaterThan, FileSizeMax);
            AddAttribute(FileFlags.ReadOnlyTrue, FileFlags.ReadOnlyFalse, FileAttributes.ReadOnly);
            AddAttribute(FileFlags.HiddenTrue, FileFlags.HiddenFalse, FileAttributes.Hidden);
            AddAttribute(FileFlags.SystemTrue, FileFlags.SystemFalse, FileAttributes.System);
            AddAttribute(FileFlags.ArchiveTrue, FileFlags.ArchiveFalse, FileAttributes.Archive);
            AddAttribute(FileFlags.CompressedTrue, FileFlags.CompressedFalse, FileAttributes.Compressed);
            AddAttribute(FileFlags.EncryptedTrue, FileFlags.EncryptedFalse, FileAttributes.Encrypted);
            return filter;

            void AddAttribute(FileFlags ifTrue, FileFlags ifFalse, FileAttributes attribute)
            {
                if ((Flags & (ifTrue | ifFalse)) != 0)
                {
                    Term function = new Function(Tag.FileAttributes, Fn.Contains, $"{attribute}", false);
                    AddTerm((Flags & ifTrue) != 0 ? function : !function);
                }
            }

            void AddDate(FileFlags flag, FileFlags utc, Tag tag, Tag tagUtc, Op op, DateTime value)
            {
                if ((Flags & flag) != 0)
                    AddTerm(new Operation((Flags & utc) == 0 ? tag : tagUtc, op, value));
            }

            void AddSize(FileFlags flag, Tag tag, Op op, ulong value)
            {
                if ((Flags & flag) != 0)
                    AddTerm(new Operation(tag, op, value));
            }

            void AddTerm(Term term) => filter.Operands.Add(term);
        }
    }
}
