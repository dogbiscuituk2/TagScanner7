namespace TagScanner.Models
{
    using System;
    using System.Collections.Generic;

    public class WorksEditEventArgs : WorksEventArgs
    {
        public WorksEditEventArgs(Tag tag, List<Work> works, List<object> values) : base(works)
        {
            Tag = tag;
            Values = values;
        }

        public Tag Tag { get; private set; }
        public List<object> Values { get; private set; }
    }
}
