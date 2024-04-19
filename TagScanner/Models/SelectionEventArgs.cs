namespace TagScanner.Models
{
    using System;

    public class SelectionEventArgs : EventArgs
    {
        public SelectionEventArgs(Selection selection) : base() => Selection = selection;

        public Selection Selection { get; private set; }
    }
}
