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
            AddDates(FileFlags.Created, Tag.FileCreated, Tag.FileCreatedUtc, CreatedMin, CreatedMax);
            AddDates(FileFlags.Modified, Tag.FileModified, Tag.FileModifiedUtc, ModifiedMin, ModifiedMax);
            AddDates(FileFlags.Accessed, Tag.FileAccessed, Tag.FileAccessedUtc, AccessedMin, AccessedMax);
            AddFileSize();
            AddAttribute(FileFlags.ReadOnly, FileAttributes.ReadOnly);
            AddAttribute(FileFlags.Hidden, FileAttributes.Hidden);
            AddAttribute(FileFlags.System, FileAttributes.System);
            AddAttribute(FileFlags.Archive, FileAttributes.Archive);
            AddAttribute(FileFlags.Compressed, FileAttributes.Compressed);
            AddAttribute(FileFlags.Encrypted, FileAttributes.Encrypted);
            return filter;

            void AddAttribute(FileFlags flags, FileAttributes attribute)
            {
                flags &= Flags;
                if (flags == 0)
                    return;
                Term function = new Function(Tag.FileAttributes, Fn.Contains, $"{attribute}", false);
                if ((flags & FileFlags.False) != 0)
                    function = !function;
                AddTerm(function);
            }

            void AddDates(FileFlags flags, Tag tag, Tag tagUtc, DateTime min, DateTime max)
            {
                flags &= Flags;
                bool
                    useMin = (flags & FileFlags.Min) != 0,
                    useMax = (flags & FileFlags.Max) != 0;
                tag = (flags & FileFlags.Utc) == 0 ? tag : tagUtc;
                if (useMin)
                    if (useMax)
                        AddTerm(new Operation(Op.NotGreaterThan, min, tag, max));
                    else
                        AddTerm(new Operation(Op.NotGreaterThan, min, tag));
                else if (useMax)
                    AddTerm(new Operation(Op.NotGreaterThan, tag, max));
            }

            void AddFileSize()
            {
                var flags = Flags & FileFlags.FileSize;
                bool
                    useMin = (flags & FileFlags.FileSizeMin) != 0,
                    useMax = (flags & FileFlags.FileSizeMax) != 0;
                if (useMin)
                    if (useMax)
                        AddTerm(new Operation(Op.NotGreaterThan, FileSizeMin, Tag.FileSize, FileSizeMax));
                    else
                        AddTerm(new Operation(Op.NotGreaterThan, FileSizeMin, Tag.FileSize));
                else if (useMax)
                    AddTerm(new Operation(Op.NotGreaterThan, Tag.FileSize, FileSizeMax));
            }

            void AddTerm(Term term) => filter.Operands.Add(term);
        }
    }
}
