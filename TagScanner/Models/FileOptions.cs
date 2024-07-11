namespace TagScanner.Models
{
    using Microsoft.CodeAnalysis.Operations;
    using System;
    using System.Collections.Generic;
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
                if (flags != 0)
                {
                    Term function = new Function(Tag.FileAttributes, Fn.Contains, $"{attribute}", false);
                    filter.Operands.Add((flags & FileFlags.False) != 0 ? function : !function);
                }
            }

            void AddDates(FileFlags flags, Tag tag, Tag tagUtc, DateTime min, DateTime max) =>
                AddRelation(flags, (flags & FileFlags.Utc) == 0 ? tag : tagUtc, min, max);

            void AddFileSize() => AddRelation(FileFlags.FileSize, Tag.FileSize, FileSizeMin, FileSizeMax);

            void AddRelation(FileFlags flags, Tag tag, Term min, Term max)
            {
                flags &= Flags;
                bool
                    useMin = (flags & FileFlags.Min) != 0,
                    useMax = (flags & FileFlags.Max) != 0;
                if (useMin || useMax)
                {
                    var operands = new List<Term>();
                    if (useMin) operands.Add(min);
                    operands.Add(tag);
                    if (useMax) operands.Add(max);
                    filter.Operands.Add(new Operation(Op.NotGreaterThan, operands.ToArray()));
                }
            }
        }
    }
}
