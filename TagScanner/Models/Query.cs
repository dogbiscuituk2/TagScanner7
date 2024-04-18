namespace TagScanner.Models
{
    using System;
    using System.Linq;

    public class Query
    {
        #region Constructor

        public Query(Tag[] tags, Tag[] groups, Tag[] sorts)
        {
            Tags = tags;
            Groups = groups;
            Sorts = sorts;
        }

        #endregion

        public Tag[] Tags, Groups, Sorts;

        #region Private Fields

        private const Tag
            album = Tag.Album,
            artist = Tag.JoinedPerformers,
            decade = Tag.Decade,
            genre = Tag.JoinedGenres,
            number = Tag.DiscTrack,
            path = Tag.FilePath,
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
            GroupByNone = Array.Empty<Tag>(),
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
            ByNone = new Query(Data4, GroupByNone, SortByTitle);

        #endregion
    }
}
