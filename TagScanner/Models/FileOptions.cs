﻿namespace TagScanner.Models
{
    using System;

    [Serializable]
    public class FileOptions
    {
        public string Schema { get; set; }

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
    }
}
