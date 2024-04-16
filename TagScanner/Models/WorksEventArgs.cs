namespace TagScanner.Models
{
    using System.Collections.Generic;

    public class WorksEventArgs
    {
        public WorksEventArgs(List<Work> works) : base()
        {
            Works = works;
        }

        public List<Work> Works { get; private set; }
    }
}
