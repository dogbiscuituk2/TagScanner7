namespace TagScanner.Commands
{
    using System.Collections.Generic;
    using Models;
    using Terms;

    public class TracksEditCommand : Command
    {
        public TracksEditCommand(Tag tag, List<Track> tracks, List<object> values) : base()
        {
            Tag = tag;
            Tracks = tracks;
            Values = values;
        }

        public Tag Tag { get; set; }
        public List<Track> Tracks { get; set; }
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
            // model.???
        }

        public override string RedoAction => Action;
        public override string UndoAction => Action;

        private string Action => $"{Tag.DisplayName()} change";

        public override string ToString() => Action;
    }
}
