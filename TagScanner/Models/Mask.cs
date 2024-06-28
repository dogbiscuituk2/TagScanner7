namespace TagScanner.Models
{
    using System;

    public class Mask
    {
        public Mask()
        {
            DateCreatedMin = DateModifiedMin = DateAccessedMin =
                DateCreatedMax = DateModifiedMax = DateAccessedMax =
                DateTime.Now;
        }

        public string FileMasks { get; set; }

        public MaskFlags Flags { get; set; }

        public DateTime DateCreatedMax { get; set; }
        public DateTime DateCreatedMin { get; set; }

        public DateTime DateModifiedMax { get; set; }
        public DateTime DateModifiedMin { get; set; }

        public DateTime DateAccessedMax { get; set; }
        public DateTime DateAccessedMin { get; set; }

        public ulong FileSizeMax { get; set; }
        public ulong FileSizeMin { get; set; }

        public bool HasAttributeFilter => (Flags & MaskFlags.Attributes) != 0;
        public bool HasDateFilter => (Flags & MaskFlags.Date) != 0;
        public bool HasFileSizeFilter => (Flags & MaskFlags.FileSize) != 0;
    }
}
