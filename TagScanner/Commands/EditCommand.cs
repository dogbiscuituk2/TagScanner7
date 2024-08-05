namespace TagScanner.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Terms;

    public class EditCommand : Command
    {
        #region Constructors

        public EditCommand(Track track, Tag tag, List<object> values) : base(track) { Tag = tag; Values = values; }
        public EditCommand(IEnumerable<Track> tracks, Tag tag, List<object> values) : base(tracks) { Tag = tag; Values = values; }
        public EditCommand(Selection selection, Tag tag, List<object> values) : base(selection) { Tag = tag; Values = values; }

        #endregion

        #region Public Properties

        public Tag Tag { get; set; }
        public List<object> Values { get; set; }

        #endregion

        #region Public Methods

        public override int Run(IModel model)
        {
            var result = 0;
            for (var index = 0; index < Tracks.Count; index++)
            {
                var value = Values[index];
                if (Tracks[index].ChangeValue(Tag, ref value))
                {
                    result++;
                    Values[index] = value;
                }
            }
            return result;
        }

        public override string ToString() =>
            $"Change {Tag.DisplayName()} {(Values.Distinct().Count() == 1 ? $"to '{Values[0]}' " : string.Empty)}on {Summary}";

        #endregion
    }
}
