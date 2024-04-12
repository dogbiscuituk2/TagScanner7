namespace TagScanner.Models
{
    using System;

    public class WorkEditEventArgs : EventArgs
    {
        public WorkEditEventArgs(Tag tag, object oldValue = null, object newValue = null) : base()
        {
            Tag = tag;
            OldValue = oldValue;
            NewValue = newValue;
        }

        public Tag Tag { get; private set; }
        public object OldValue { get; private set; }
        public object NewValue { get; private set; }
    }
}
