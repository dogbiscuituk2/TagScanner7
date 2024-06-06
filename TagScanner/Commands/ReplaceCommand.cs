namespace TagScanner.Commands
{
    using System.Linq;
    using Models;

    public class ReplaceCommand : Command
    {
        #region Constructor

        public ReplaceCommand(Selection selection, Tag[] tags, object[,] values) : base(selection)
        {
            Tags = tags;
            Values = values;
        }

        #endregion

        #region Public Properties

        public Tag[] Tags { get; set; }
        public object[,] Values { get; set; }

        #endregion

        #region Public Methods

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

        #endregion

        #region Private Fields

        private int ChangesCount;

        #endregion
    }
}
