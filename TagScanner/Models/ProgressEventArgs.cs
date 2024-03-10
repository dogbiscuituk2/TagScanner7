namespace TagScanner.Models
{
    using System;

    public class ProgressEventArgs : EventArgs
    {
        public bool Continue { get; set; }
        public int Count { get; set; }
        public int Index { get; set; }
        public string Path { get; set; }
        public bool Skip { get; set; }
        public Work Work { get; set; }

        public ProgressEventArgs(int index, int count, string path, Work work)
        {
            Continue = true;
            Count = count;
            Index = index;
            Path = path;
            Skip = false;
            Work = work;
        }
    }
}
