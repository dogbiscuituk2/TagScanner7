namespace TagScanner.Models
{
    using System;
    using TagScanner.Terms;

    [Serializable]
    public class FileOptions
    {
        public FileOptions()
        {
            DateCreatedMin = DateModifiedMin = DateAccessedMin =
                DateCreatedMax = DateModifiedMax = DateAccessedMax =
                DateTime.Now;
        }

        public FileFlags Flags { get; set; }

        public DateTime DateCreatedMax { get; set; }
        public DateTime DateCreatedMin { get; set; }

        public DateTime DateModifiedMax { get; set; }
        public DateTime DateModifiedMin { get; set; }

        public DateTime DateAccessedMax { get; set; }
        public DateTime DateAccessedMin { get; set; }

        public ulong FileSizeMax { get; set; }
        public ulong FileSizeMin { get; set; }

        public bool HasAttributeFilter => (Flags & FileFlags.Attributes) != 0;
        public bool HasDateFilter => (Flags & FileFlags.Date) != 0;
        public bool HasFileSizeFilter => (Flags & FileFlags.FileSize) != 0;

        public Conjunction GetPredicate()
        {
            var filter = new Conjunction();
            AddDateFilter(FileFlags.CreatedMin, FileFlags.CreatedUtc, Tag.FileCreationTimeUtc, Tag.FileCreationTime, Op.NotLessThan, DateCreatedMin);
            return filter;

            void AddDateFilter(FileFlags flag, FileFlags utc, Tag tagUtc, Tag tag, Op op, DateTime value)
            {
                if ((Flags & flag) != 0)
                    filter.Operands.Add(new Operation((Flags & utc) != 0 ? tagUtc : tag, op, value));
            }
        }
    }
}
