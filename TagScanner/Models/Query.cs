﻿namespace TagScanner.Models
{
    using System;
    using System.Linq;

    public class Query
    {
        public Query(Tag[] tags, Tag[] groups, Tag[] sorts)
        {
            Tags = tags;
            Groups = groups;
            Sorts = sorts;
        }

        public Tag[]
            Tags,
            Groups,
            Sorts;

        public override bool Equals(object obj) => obj is Query query &&
            Tags.SequenceEqual(query.Tags) &&
            Groups.SequenceEqual(query.Groups) &&
            Sorts.SequenceEqual(query.Sorts);

        public override int GetHashCode() =>
            Tags.GetHashCode() ^
            Groups.GetHashCode() ^
            Sorts.GetHashCode();

        public static bool operator ==(Query x, Query y) => x == null ? y == null :  x.Equals(y);
        public static bool operator !=(Query x, Query y) => !(x == y);

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
            ByArtistAlbum = new Query(Data1, GroupByArtistAlbum, SortByNumber),
            ByArtist = new Query(Data3, GroupByArtist, SortByAlbum),
            ByAlbum = new Query(Data1, GroupByAlbum, SortByNumber),
            ByYear = new Query(Data2, GroupByYear, SortByNumber),
            ByGenre = new Query(Data1, GroupByGenre, SortByNumber),
            ByTitle = new Query(Data4, GroupByTitle, SortByTitle);

        #endregion
    }
}
