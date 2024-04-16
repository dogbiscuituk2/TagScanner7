namespace TagScanner.Models
{
    using System;
    using System.Collections.Generic;

    public class WorksEditedEventArgs : EventArgs
    {
        public WorksEditedEventArgs(Tag tag, List<Work> works, List<object> values) : base()
        {
            Tag = tag;
            Works = works;
            Values = values;
        }

        public Tag Tag { get; private set; }
        public List<Work> Works { get; private set; }
        public List<object> Values { get; private set; }
    }
}
