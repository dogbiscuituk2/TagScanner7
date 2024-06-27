namespace TagScanner.Models
{
    using System;

    public class FileFilter
    {
        public FileFilterFlags Flags { get; set; }

        public DateTime DateCreatedMax { get; set; }
        public DateTime DateCreatedMin { get; set; }

        public DateTime DateModifiedMax { get; set; }
        public DateTime DateModifiedMin { get; set; }

        public DateTime DateAccessedMax { get; set; }
        public DateTime DateAccessedMin { get; set; }

        public long FileSizeMax { get; set; }
        public long FileSizeMin { get; set; }
    }
}
