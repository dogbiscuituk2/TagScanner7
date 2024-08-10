namespace TagScanner.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    using Models;

    public class ReplaceCommand : Command
    {
        #region Constructors

        public ReplaceCommand(Track track, IEnumerable<Tag> tags, object[,] values) : base(track) { Tags = tags; Values = values; }
        public ReplaceCommand(IEnumerable<Track> tracks, IEnumerable<Tag> tags, object[,] values) : base(tracks) { Tags = tags; Values = values; }
        public ReplaceCommand(Selection selection, IEnumerable<Tag> tags, object[,] values) : base(selection) { Tags = tags; Values = values; }

        #endregion

        #region Public Properties

        public IEnumerable<Tag> Tags { get; set; }
        public object[,] Values { get; set; }

        #endregion

        #region Public Methods

        public override void Run(IModel model)
        {
            var tags = Tags.ToList();
            ChangesCount = 0;
            for (var trackIndex = 0; trackIndex < Tracks.Count; trackIndex++)
                for (var tagIndex = 0; tagIndex < Tags.Count(); tagIndex++)
                {
                    var tag = tags[tagIndex];
                    var value = Values[trackIndex, tagIndex];
                    if (Tracks[trackIndex].ChangeValue(tag, ref value))
                    {
                        ChangesCount++;
                        Values[trackIndex, tagIndex] = value;
                    }
                }
        }

        public override string ToString() => $"Replace {ChangesCount} values in {Caption}";

        #endregion

        #region Private Fields

        private int ChangesCount;

        #endregion
    }
}
