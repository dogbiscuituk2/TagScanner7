namespace TagScanner.Models
{
    using System;
    using Controllers;

    [Serializable]
    public class FileOptions
    {
        public FileOptions()
        {
            Schema = AppController.Schema;
            DateCreatedMin = DateModifiedMin = DateAccessedMin =
                DateCreatedMax = DateModifiedMax = DateAccessedMax =
                DateTime.Now;
        }

        public Schema Schema { get; set; }

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
    }
}
