namespace TagScanner.Models
{
    using System;

    public class WorkEditEventArgs : EventArgs
    {
        public WorkEditEventArgs(Tag tag, object oldValue = null) : base()
        {
            Tag = tag;
            OldValue = oldValue;
        }

        public Tag Tag { get; private set; }
        public object OldValue { get; private set; }
    }
}
