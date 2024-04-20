namespace TagScanner.Models
{
    using System.Collections.Generic;

    public class SelectionEditEventArgs : SelectionEventArgs
    {
        public SelectionEditEventArgs(Selection selection, Tag tag, List<object> values) : base(selection)
        {
            Tag = tag;
            Values = values;
        }

        public Tag Tag { get; private set; }
        public List<object> Values { get; private set; }
    }
}
