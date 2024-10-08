﻿namespace TagScanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.Drawing.Text;
    using System.Linq;
    using System.Text;
    using Core;

    public class Query : ICommand
    {
        #region Constructors

        public Query(IEnumerable<Tag> tags, IEnumerable<Stag> sorts, IEnumerable<Tag> groups) =>
            Init(tags, sorts, groups);

        public Query(Tag[] tags, Tag[] sorts, Tag[] groups) : this(
            tags,
            sorts.Select(p => new Stag(p, false)),
            groups) { }

        #endregion

        #region Public Fields

        public List<Tag>
            Tags = new List<Tag>(),
            Groups = new List<Tag>();

        public List<Stag> Sorts = new List<Stag>();

        #endregion

        #region Public Properties

        public string Caption => string.Format(
            CaptionFormat,
            Undo ? "Undo" : "Redo",
            SayTags(),
            Clause
            );

        public string Clause { get; set; }

        public List<Stag> Stags { get; set; }

        public string Text
        {
            get
            {
                var result = new StringBuilder($" {Caption}\n");
                if (Tags.Any()) result.Append($"  Select  {JoinTags(Tags)}\n");
                if (Sorts.Any()) result.Append($"  OrderBy {JoinStags(Sorts)}\n");
                if (Groups.Any()) result.Append($"  GroupBy {JoinTags(Groups)}\n");
                return result.ToString();

                string JoinStags(IEnumerable<Stag> stags) => stags.Select(p => p.Caption).Join(",");
                string JoinTags(IEnumerable<Tag> tags) => tags.Select(p => p.DisplayName()).Join(",");
            }
        }

        public bool Undo { get; set; }
        public Verb Verb { get; set; }

        #endregion

        #region Operators

        public static bool operator ==(Query x, Query y) => x == null ? y == null : x.Equals(y);
        public static bool operator !=(Query x, Query y) => !(x == y);

        #endregion

        #region Public Methods

        public void Apply(IModel model) => ((ISetQuery)model).SetQuery(this);

        public override bool Equals(object obj) => obj is Query query &&
            Tags.SequenceEqual(query.Tags) &&
            Sorts.SequenceEqual(query.Sorts) &&
            Groups.SequenceEqual(query.Groups);

        public override int GetHashCode() =>
            Tags.GetHashCode() ^
            Sorts.GetHashCode() ^
            Groups.GetHashCode();

        public void Init(IEnumerable<Tag> tags, IEnumerable<Stag> sorts, IEnumerable<Tag> groups)
        {
            Tags = tags.ToList();
            Sorts = sorts.ToList();
            Groups = groups.ToList();
        }

        public override string ToString() => Caption;

        #endregion

        #region Private Fields

        private const Tag
            album = Tag.Album,
            artist = Tag.JoinedPerformers,
            decade = Tag.Decade,
            genre = Tag.JoinedGenres,
            number = Tag.DiscTrack,
            size = Tag.FileSize,
            time = Tag.Duration,
            title = Tag.Title,
            year = Tag.Year,
            yearAlbum = Tag.YearAlbum;

        private static readonly Tag[]
            Data1 = { number, title, time, size },
            Data2 = { number, title, time, size, artist, album },
            Data3 = { yearAlbum, number, title, time, size },
            Data4 = { title, yearAlbum, time, size, artist },
            GroupByAlbum = { album },
            GroupByArtist = { artist },
            GroupByArtistAlbum = { artist, yearAlbum },
            GroupByGenre = { genre, artist, yearAlbum },
            GroupByTitle = Array.Empty<Tag>(),
            GroupByYear = { decade, year, artist, album },
            SortByAlbum = { yearAlbum, number },
            SortByNumber = { number },
            SortByTitle = { title, artist, yearAlbum };

        #endregion

        #region Public Fields (depending on previously defined Private Fields)

        public static readonly Query
            ByArtistAlbum = new Query(Data1, SortByNumber, GroupByArtistAlbum),
            ByArtist = new Query(Data3, SortByAlbum, GroupByArtist),
            ByAlbum = new Query(Data1, SortByNumber, GroupByAlbum),
            ByYear = new Query(Data2, SortByNumber, GroupByYear),
            ByGenre = new Query(Data1, SortByNumber, GroupByGenre),
            ByTitle = new Query(Data4, SortByTitle, GroupByTitle);

        #endregion

        #region Private Methods

        private string CaptionFormat
        {
            get
            {
                // {0} will be replaced by "Undo" or "Redo"
                // {1} will be replaced by {Stags}
                // {2} will be replaced by {Clause}
                switch (Verb)
                {
                    case Verb.Merge:
                        return "{0} merge ({1}) into '{2}'";
                    case Verb.MoveUp:
                        return "{0} move↑ ({1}) in '{2}'";
                    case Verb.MoveDown:
                        return "{0} move↓ ({1}) in '{2}'";
                    case Verb.SelectTags:
                        return "{0} select ({1})";
                    case Verb.SortAscending:
                        return "{0} sort↑ by ({1})";
                    case Verb.SortDescending:
                        return "{0} sort↓ by ({1})";
                    case Verb.GroupBy:
                        return "{0} group by ({1})";
                    default:
                        return "{0} {1} {2} into {3}";
                }
            }
        }

        private string SayTags()
        {
            var count = Stags?.Count() ?? 0;
            if (count < 1)
                return string.Empty;
            var max = 3;
            var s = Stags.Take(max).Select(p => p.Tag.DisplayName()).Aggregate((p, q) => $"{p}, {q}");
            return count <= max ? s : $"{s}, ...";
        }

        #endregion
    }
}
