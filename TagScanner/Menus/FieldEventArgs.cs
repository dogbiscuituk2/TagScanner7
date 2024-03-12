namespace TagScanner.Menus
{
    using System;
    using Models;

    public class FieldEventArgs : EventArgs
    {
        public FieldEventArgs(TagProps tagProps)
        {
            TagProps = tagProps;
        }

        public TagProps TagProps { get; set; }
    }
}
