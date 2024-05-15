namespace TagScanner.Commands
{
    using System.Linq;
    using Models;

    public class ReplaceCommand : Command
    {
        public ReplaceCommand(Selection selection, Tag[] tags, object[,] values) : base(selection)
        {
            Tags = tags;
            Values = values;
        }

        public Tag[] Tags { get; set; }
        public object[,] Values { get; set; }

        private int ChangesCount;

        public override int Run(Model model)
        {
            ChangesCount = 0;
            for (var trackIndex = 0; trackIndex < Tracks.Count; trackIndex++)
                for (var tagIndex = 0; tagIndex < Tags.Count(); tagIndex++)
                {
                    var tag = Tags[tagIndex];
                    var value = Values[trackIndex, tagIndex];
                    if (Tracks[trackIndex].ChangeValue(tag, ref value))
                    {
                        ChangesCount++;
                        Values[trackIndex, tagIndex] = value;
                    }
                }
            return ChangesCount;
        }

        public override string ToString() => $"Replace {ChangesCount} values in {Summary}";
    }
}
