namespace TagScanner.Menus
{
    using System;
    using Models;

    public class FieldEventArgs : EventArgs
    {
        public FieldEventArgs(TagInfo tagInfo)
        {
            TagInfo = tagInfo;
        }

        public TagInfo TagInfo { get; set; }
    }
}
