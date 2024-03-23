﻿namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using Models;
    using Terms;

    public partial class Test
    {
        [TestMethod]
        public void TestFields()
        {
            foreach (var tag in Tags.Keys)
            {
                var field = new Field(tag);
                Assert.IsNotNull(field);
                Assert.AreEqual(expected: tag.DisplayName(), actual: field.ToString());
                Assert.AreEqual(expected: tag.Name(), actual: field.Tag.ToString());
                Assert.AreEqual(expected: Rank.Unary, actual: field.Rank);
                Assert.AreEqual(expected: tag.Type(), actual: field.ResultType);
                Assert.AreEqual(expected: $"{Term.Work.Name}.{tag.Name()}", actual: field.Expression.ToString());
            }
        }

        [TestMethod]
        [DataRow(Tag.FileCreationTime, "24/01/2024 19:34:00")]
        [DataRow(Tag.FileCreationTimeUtc, "24/01/2024 19:34:00")]
        [DataRow(Tag.FileLastAccessTime, "24/01/2024 19:34:00")]
        [DataRow(Tag.FileLastAccessTimeUtc, "24/01/2024 19:34:00")]
        [DataRow(Tag.FileLastWriteTime, "24/01/2024 19:34:00")]
        [DataRow(Tag.FileLastWriteTimeUtc, "24/01/2024 19:34:00")]
        [DataRow(Tag.ImageDateTime, "24/01/2024 19:34:00")]
        public void TestFields_DateTime(Tag tag, object expectedValue)
        {
            var term = new Operation(tag, "!=", DateTime.MinValue);
            var works = Works.Where(p => term.Predicate(p));
            Assert.AreEqual(expected: 1, actual: works.Count());
            Assert.AreEqual(expected: expectedValue, actual: works.First().GetPropertyValue(tag).ToString());
        }

        [TestMethod]
        public void TestFields_DiscTrack()
        {
            var term = new Operation(Tag.DiscNumber, '>', 1);
            var works = Works.Where(p => term.Predicate(p));
            Assert.AreEqual(expected: 1, actual: works.Count());
            Assert.AreEqual(expected: "2/3 - 08/12", actual: works.First().DiscTrack);
        }

        [TestMethod]
        [DataRow(Tag.ImageAltitude, 123.456)]
        [DataRow(Tag.ImageFNumber, 1.23)]
        [DataRow(Tag.ImageFocalLength, 75.2)]
        [DataRow(Tag.ImageLatitude, 45.6)]
        [DataRow(Tag.ImageLongitude, 277.8)]
        public void TestFields_Double(Tag tag, object expectedValue)
        {
            var term = new Operation(tag, "!=", 0.0);
            var works = Works.Where(p => term.Predicate(p));
            Assert.AreEqual(expected: 1, actual: works.Count());
            Assert.AreEqual(expected: expectedValue, actual: works.First().GetPropertyValue(tag));
        }

        [TestMethod]
        [DataRow(Tag.AudioBitrate, 320)]
        [DataRow(Tag.AudioChannels, 2)]
        [DataRow(Tag.AudioSampleRate, 44100)]
        [DataRow(Tag.BeatsPerMinute, 120)]
        [DataRow(Tag.BitsPerSample, 24)]
        [DataRow(Tag.ImageFocalLengthIn35mmFilm, 60)]
        [DataRow(Tag.ImageISOSpeedRatings, 200)]
        [DataRow(Tag.ImageRating, 5)]
        //[DataRow(Tag.MediaTypes, TagLib.MediaTypes.Audio | TagLib.MediaTypes.Photo)]
        [DataRow(Tag.PhotoHeight, 480)]
        [DataRow(Tag.PhotoQuality, 5)]
        [DataRow(Tag.PhotoWidth, 640)]
        [DataRow(Tag.VideoHeight, 480)]
        [DataRow(Tag.VideoWidth, 640)]
        public void TestFields_Int(Tag tag, object expectedValue)
        {
            var term = new Operation(tag, "!=", 0);
            var works = Works.Where(p => term.Predicate(p));
            Assert.AreEqual(expected: 1, actual: works.Count());
            Assert.AreEqual(expected: expectedValue, actual: works.First().GetPropertyValue(tag));
        }

        [TestMethod]
        [DataRow(Tag.FileSize, 2968691L)]
        [DataRow(Tag.InvariantEndPosition, 67890L)]
        [DataRow(Tag.InvariantStartPosition, 12345L)]
        public void TestFields_Long(Tag tag, object expectedValue)
        {
            var term = new Operation(tag, "!=", 0L);
            var works = Works.Where(p => term.Predicate(p));
            Assert.AreEqual(expected: 1, actual: works.Count());
            Assert.AreEqual(expected: expectedValue, actual: works.First().GetPropertyValue(tag));
        }

        [TestMethod]
        public void TestFields_Pictures()
        {
            var works = Works.Where(p => p.Pictures != null);
            Assert.AreEqual(expected: 1, actual: works.Count());
            var pictures = works.First().Pictures;
            Assert.AreEqual(expected: 1, actual: pictures.Length);
            var picture = pictures[0];
            Assert.AreEqual(expected: @"C:\Pictures\Picture.png", actual: picture.FilePath);
            Assert.AreEqual(expected: 0, actual: picture.Index);
            Assert.AreEqual(expected: "Other", actual: picture.Type);
        }

        [TestMethod]
        [DataRow(Tag.AlbumGain, "-4.07 dB")]
        [DataRow(Tag.AlbumPeak, "1.049575")]
        [DataRow(Tag.AlbumSort, "Pepper, Sgt.")]
        [DataRow(Tag.AmazonId, "Amazon ID")]
        [DataRow(Tag.Codecs, "Audio (MPEG Version 1 Audio, Layer 3 - 0:02:34.768)")]
        [DataRow(Tag.Comment, "Wow!")]
        [DataRow(Tag.Conductor, "George Martin")]
        [DataRow(Tag.Copyright, "Hands Off It's Mine")]
        [DataRow(Tag.Description, "MPEG Version 1 Audio, Layer 3")]
        [DataRow(Tag.FileAttributes, "Archive")]
        [DataRow(Tag.FilePath, @"C:\Music\Stones\You Gotta Move.mp3")]
        [DataRow(Tag.FirstAlbumArtist, "Mick")]
        [DataRow(Tag.FirstAlbumArtistSort, "Ronnie")]
        [DataRow(Tag.FirstArtist, "Bill")]
        [DataRow(Tag.FirstComposer, "Beethoven")]
        [DataRow(Tag.FirstComposerSort, "Bach")]
        [DataRow(Tag.FirstGenre, "Rock")]
        [DataRow(Tag.FirstPerformer, "Jagger")]
        [DataRow(Tag.FirstPerformerSort, "Wyman")]
        [DataRow(Tag.Grouping, "Best")]
        [DataRow(Tag.ImageCreator, "Sam Shere (1905–1982)")]
        [DataRow(Tag.ImageMake, "Nikon")]
        [DataRow(Tag.ImageModel, "Pro")]
        [DataRow(Tag.ImageSoftware, "Photoshop")]
        [DataRow(Tag.JoinedAlbumArtists, "Led Zeppelin")]
        [DataRow(Tag.JoinedArtists, "Led Zeppelin")]
        [DataRow(Tag.JoinedComposers, "Led Zeppelin")]
        [DataRow(Tag.JoinedGenres, "Rock & Roll")]
        [DataRow(Tag.JoinedPerformers, "Led Zeppelin")]
        [DataRow(Tag.JoinedPerformersSort, "Led Zeppelin")]
        [DataRow(Tag.Lyrics, "We come from the land of the ice and snow")]
        [DataRow(Tag.MimeType, "taglib/mp3")]
        [DataRow(Tag.MusicBrainzArtistId, "Artist0123")]
        [DataRow(Tag.MusicBrainzDiscId, "Disc0123")]
        [DataRow(Tag.MusicBrainzReleaseArtistId, "ReleaseArtist0123")]
        [DataRow(Tag.MusicBrainzReleaseCountry, "Country0123")]
        [DataRow(Tag.MusicBrainzReleaseId, "Release0123")]
        [DataRow(Tag.MusicBrainzReleaseStatus, "ReleaseStatus0123")]
        [DataRow(Tag.MusicBrainzReleaseType, "ReleaseType0123")]
        [DataRow(Tag.MusicBrainzTrackId, "Track0123")]
        [DataRow(Tag.MusicIpId, "MusicIp0123")]
        [DataRow(Tag.TitleSort, "and Away Far Hills Over the")]
        [DataRow(Tag.TrackGain, "-4.07 dB")]
        [DataRow(Tag.TrackPeak, "1.049575")]
        public void TestFields_String(Tag tag, object expectedValue)
        {
            var term = (!new Function("IsEmpty", tag));
            var works = Works.Where(p => term.Predicate(p));
            Assert.AreEqual(expected: 1, actual: works.Count());
            Assert.AreEqual(expected: expectedValue, actual: works.First().GetPropertyValue(tag));
        }

        [TestMethod]
        [DataRow(Tag.AlbumArtists, new[] { "John", "Paul", "George", "Ringo" })]
        [DataRow(Tag.AlbumArtistsSort, new[] { "George", "John", "Paul", "Ringo" })]
        [DataRow(Tag.Artists, new[] { "John", "Paul", "George", "Ringo" })]
        [DataRow(Tag.Composers, new[] { "McCartney", "Lennon" })]
        [DataRow(Tag.ComposersSort, new[] { "Lennon", "McCartney" })]
        [DataRow(Tag.Genres, new[] { "Rock", "Roll" })]
        [DataRow(Tag.ImageKeywords, new[] { "Hindenburg", "Manchester", "New Jersey" })]
        [DataRow(Tag.PerformersSort, new[] { "Bonham", "Jones", "Page", "Plant" })]
        public void TestFields_Strings(Tag tag, object expectedValue)
        {
            var term = new Function("IsEmpty", tag);
            var works = Works.Where(p => term.Predicate(p));
            //var works = Works.Where(p => !string.IsNullOrWhiteSpace(p.GetPropertyValue(tag)?.ToString()));
            Assert.AreEqual(expected: 1, actual: works.Count());
            var actualValue = works.First().GetPropertyValue(tag);
            Assert.IsTrue(((string[])actualValue).SequenceEqual((string[])expectedValue));
        }

        [TestMethod]
        [DataRow(Tag.ImageOrientation, TagLib.Image.ImageOrientation.TopLeft)]
        [DataRow(Tag.TagTypes, TagLib.TagTypes.Id3v1 | TagLib.TagTypes.Id3v2)]
        public void TestFields_Enum(Tag tag, object expectedValue)
        {
            var term = new Operation(new Cast(typeof(int), tag), "!=", 0);
            var works = Works.Where(p => term.Predicate(p));
            Assert.AreEqual(expected: 1, actual: works.Count());
            Assert.AreEqual(expected: expectedValue, actual: works.First().GetPropertyValue(tag));
        }
    }
}
