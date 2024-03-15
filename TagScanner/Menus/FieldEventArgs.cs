namespace TagScanner.Menus
{
    using System;
    using Models;

    public class FieldEventArgs : EventArgs
    {
        public FieldEventArgs(Tag tag) { Tag = tag; }

        public Tag Tag { get; set; }
    }
}
