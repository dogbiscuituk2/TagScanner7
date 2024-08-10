namespace TagScanner.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Core;
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

        public override void Run(IModel model)
        {
            for (var index = 0; index < Tracks.Count; index++)
            {
                var value = Values[index];
                if (Tracks[index].ChangeValue(Tag, ref value))
                    Values[index] = value;
            }
        }

        public override string ToString() =>
            $"Change {Tag.DisplayName()} {(Values.Distinct().Count() == 1 ? $"to '{Values[0]}' " : string.Empty)}on {Caption}";

        #endregion
    }
}
