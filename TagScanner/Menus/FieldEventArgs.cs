namespace TagScanner.Menus
{
    using System;
    using TagScanner.Models;

    public class FieldEventArgs : EventArgs
    {
        public FieldEventArgs(TagProps tagProps) : base() { TagProps = tagProps; }

        public TagProps TagProps { get; set; }
    }
}
