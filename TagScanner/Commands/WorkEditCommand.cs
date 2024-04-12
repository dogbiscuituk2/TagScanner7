namespace TagScanner.Commands
{
    using TagScanner.Models;

    public class WorkEditCommand
    {
        public WorkEditCommand(Work work, object value)
        {
            Work = work;
            Value = value;
        }

        private Work Work { get; set; }
        private object Value { get; set; }
    }
}
