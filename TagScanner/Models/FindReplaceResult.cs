namespace TagScanner.Models
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public class FindReplaceResult
    {
        public FindReplaceResult(Track track, Tag tag, IEnumerable<CharacterRange> characterRanges)
        {
            CharacterRanges = characterRanges.ToArray();
            Tag = tag;
            Track = track;
        }

        public CharacterRange[] CharacterRanges;
        public Tag Tag;
        public Track Track;
    }
}
