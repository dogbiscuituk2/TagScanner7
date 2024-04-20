namespace TagScanner.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Terms;

    public class TracksEditCommand : Command
    {
        public TracksEditCommand(Selection selection, Tag tag, List<object> values) : base(selection)
        {
            Tag = tag;
            Values = values;
        }

        public Tag Tag { get; set; }
        public List<object> Values { get; set; }

        public override bool Run(Model model)
        {
            var result = false;
            for (var index = 0; index < Tracks.Count; index++)
            {
                var value = Values[index];
                result |= Tracks[index].ChangeValue(Tag, ref value);
                Values[index] = value;
            }
            return result;
        }

        public override string ToString() =>
            $"Change {Tag.DisplayName()} {(Values.Distinct().Count() == 1 ? $"to '{Values[0]}' " : string.Empty)}on {Summary}";
    }
}
