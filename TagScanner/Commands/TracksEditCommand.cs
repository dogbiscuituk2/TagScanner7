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

        public override bool Do(Model model)
        {
            var result = base.Do(model);
            if (result)
                PropertyChanged();
            return result;
        }

        public override bool Run(Model model)
        {
            var result = false;
            for (var index = 0; index < Tracks.Count; index++)
            {
                var track = Tracks[index];
                var oldValue = track.GetPropertyValue(Tag);
                var newValue = Values[index];
                result |= !Equals(oldValue, newValue);
                if (result)
                {
                    track.SetPropertyValue(Tag, newValue);
                    Values[index] = oldValue;
                }
            }
            return result;
        }

        protected void PropertyChanged()
        {
            return;
        }

        public override string ToString() =>
            $"Change {Tag.DisplayName()} {(Values.Distinct().Count() == 1 ? $"to '{Values[0]}' " : string.Empty)}on {Summary}";
    }
}
