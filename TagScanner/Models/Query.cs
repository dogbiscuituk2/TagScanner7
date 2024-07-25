﻿namespace TagScanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    public class Query
    {
        #region Constructors

        public Query(IEnumerable<Tag> tags, IEnumerable<SortDescription> sorts, IEnumerable<Tag> groups) =>
            Init(tags, sorts, groups);

        public Query(Tag[] tags, Tag[] sorts, Tag[] groups) : this(tags,
            sorts.Select(p => new SortDescription($"{p}", ListSortDirection.Ascending)),
            groups) { }

        #endregion

        #region Public Properties

        public List<Tag> Tags = new List<Tag>();
        public List<Tag> Groups = new List<Tag>();
        public List<SortDescription> Sorts = new List<SortDescription>();

        #endregion

        #region Operators

        public static bool operator ==(Query x, Query y) => x == null ? y == null : x.Equals(y);
        public static bool operator !=(Query x, Query y) => !(x == y);

        #endregion

        #region Public Methods

        public override bool Equals(object obj) => obj is Query query &&
            Tags.SequenceEqual(query.Tags) &&
            Sorts.SequenceEqual(query.Sorts) &&
            Groups.SequenceEqual(query.Groups);

        public override int GetHashCode() =>
            Tags.GetHashCode() ^
            Sorts.GetHashCode() ^
            Groups.GetHashCode();

        public void Init(IEnumerable<Tag> tags, IEnumerable<SortDescription> sorts, IEnumerable<Tag> groups)
        {
            Tags = tags.ToList();
            Sorts = sorts.ToList();
            Groups = groups.ToList();
        }

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
    }
}
