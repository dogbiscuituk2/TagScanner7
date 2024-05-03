namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using Models;

    [TestClass]
    public partial class Test
    {
        [ClassInitialize] public static void ClassInitialize(TestContext _) { }
        [TestInitialize] public void TestInitialize() { }
        [TestCleanup] public void TestCleanup() { }
        [ClassCleanup] public static void ClassCleanup() { }

        private class TestTrack : Track
        {
            internal TestTrack(string artist, int year, string album, int trackNumber, string duration, string title) : base()
            {
                Album = album;
                Duration = TimeSpan.Parse($"00:0{duration}");
                JoinedAlbumArtists = artist;
                JoinedArtists = artist;
                JoinedComposers = artist;
                JoinedPerformers = artist;
                Performers = new[] { artist };
                TrackNumber = trackNumber;
                Title = title;
                Year = year;
            }
        }

        private const string
            TB = "The Beatles",
            SP = "Sgt. Pepper's Lonely Hearts Club Band",
            LIB = "Let It Be",
            RS = "The Rolling Stones",
            SF = "Sticky Fingers",
            HD = "Hackney Diamonds",
            LZ = "Led Zeppelin",
            LZii = "Led Zeppelin II",
            LZiii = "Led Zeppelin III",
            LZiv = "Led Zeppelin IV",
            HH = "Houses of the Holy";

        private static readonly TestTrack[] Tracks = new[]
        {
            new TestTrack(TB, 1967, SP, 1, "2:00", SP),
            new TestTrack(TB, 1967, SP, 2, "2:42", "With a Little Help from My Friends") { AlbumArtists = new[] { "John", "Paul", "George", "Ringo" } },
            new TestTrack(TB, 1967, SP, 3, "3:28", "Lucy in the Sky with Diamonds") { AlbumArtistsSort = new[] { "George", "John", "Paul", "Ringo" } },
            new TestTrack(TB, 1967, SP, 4, "2:48", "Getting Better") { AlbumGain = "-4.07 dB" },
            new TestTrack(TB, 1967, SP, 5, "2:36", "Fixing a Hole") { AlbumPeak = "1.049575" },
            new TestTrack(TB, 1967, SP, 6, "3:25", "She's Leaving Home") { AlbumSort = "Pepper, Sgt." },
            new TestTrack(TB, 1967, SP, 7, "2:37", "Being for the Benefit of Mr. Kite!") { AmazonId = "Amazon ID" },
            new TestTrack(TB, 1967, SP, 8, "5:05", "Within You Without You") { Artists = new[] { "John", "Paul", "George", "Ringo" } },
            new TestTrack(TB, 1967, SP, 9, "2:37", "When I'm Sixty-Four") { AudioBitrate = 320 },
            new TestTrack(TB, 1967, SP, 10, "2:42", "Lovely Rita") { AudioChannels = 2 },
            new TestTrack(TB, 1967, SP, 11, "2:42", "Good Morning Good Morning") { AudioSampleRate = 44100 },
            new TestTrack(TB, 1967, SP, 12, "1:18", $"{SP} (Reprise)") { BeatsPerMinute = 120 },
            new TestTrack(TB, 1967, SP, 13, "5:38", "A Day in the Life") { BitsPerSample = 24 },

            new TestTrack(TB, 1970, LIB, 1, "3:36", "Two of Us") { Codecs = "Audio (MPEG Version 1 Audio, Layer 3 - 0:02:34.768)" },
            new TestTrack(TB, 1970, LIB, 2, "3:54", "Dig a Pony") { Comment = "Wow!" },
            new TestTrack(TB, 1970, LIB, 3, "3:48", "Across the Universe") { Composers = new[] { "McCartney", "Lennon" } },
            new TestTrack(TB, 1970, LIB, 4, "2:26", "I Me Mine") { ComposersSort = new[] { "Lennon", "McCartney" } },
            new TestTrack(TB, 1970, LIB, 5, "0:50", "Dig It") { Conductor = "George Martin" },
            new TestTrack(TB, 1970, LIB, 6, "4:03", "Let It Be") { Copyright = "Hands Off It's Mine" },
            new TestTrack(TB, 1970, LIB, 7, "0:40", "Maggie Mae") { Description = "MPEG Version 1 Audio, Layer 3" },
            new TestTrack(TB, 1970, LIB, 8, "3:37", "I've Got a Feeling") { DiscNumber = 2, DiscCount = 3, TrackCount = 12 },
            new TestTrack(TB, 1970, LIB, 9, "2:54", "One After 909"),
            new TestTrack(TB, 1970, LIB, 10, "3:38", "The Long and Winding Road") { FileAttributes = "Archive" },
            new TestTrack(TB, 1970, LIB, 11, "2:32", "For You Blue") { FileCreationTime = DateTime.Parse("24/01/2024 19:34:00") },
            new TestTrack(TB, 1970, LIB, 12, "3:09", "Get Back") { FileCreationTimeUtc = DateTime.Parse("24/01/2024 19:34:00") },

            new TestTrack(RS, 1971, SF, 1, "3:48", "Brown Sugar") { FileLastAccessTime  = DateTime.Parse("24/01/2024 19:34:00") },
            new TestTrack(RS, 1971, SF, 2, "3:50", "Sway") { FileLastAccessTimeUtc = DateTime.Parse("24/01/2024 19:34:00") },
            new TestTrack(RS, 1971, SF, 3, "5:42", "Wild Horses") { FileLastWriteTime  = DateTime.Parse("24/01/2024 19:34:00") },
            new TestTrack(RS, 1971, SF, 4, "7:14", "Can't You Hear Me Knocking") { FileLastWriteTimeUtc  = DateTime.Parse("24/01/2024 19:34:00") },
            new TestTrack(RS, 1971, SF, 5, "2:32", "You Gotta Move") { FilePath = @"C:\Music\Stones\You Gotta Move.mp3" },
            new TestTrack(RS, 1971, SF, 6, "3:38", "Bitch") { FileSize = 2968691L },
            new TestTrack(RS, 1971, SF, 7, "3:54", "I Got the Blues") { FirstAlbumArtist = "Mick" },
            new TestTrack(RS, 1971, SF, 8, "5:31", "Sister Morphine") { FirstAlbumArtistSort = "Ronnie" },
            new TestTrack(RS, 1971, SF, 9, "4:03", "Dead Flowers") { FirstArtist = "Bill" },
            new TestTrack(RS, 1971, SF, 10, "5:56", "Moonlight Mile") { FirstComposer = "Beethoven" },

            new TestTrack(RS, 2023, HD, 1, "3:46", "Angry") { FirstComposerSort = "Bach" },
            new TestTrack(RS, 2023, HD, 2, "4:10", "Get Close") { FirstGenre = "Rock" },
            new TestTrack(RS, 2023, HD, 3, "4:03", "Depending On You") { FirstPerformer = "Jagger" },
            new TestTrack(RS, 2023, HD, 4, "3:31", "Bite My Head Off") { FirstPerformerSort = "Wyman" },
            new TestTrack(RS, 2023, HD, 5, "3:58", "Whole Wide World") { Genres = new[] { "Rock", "Roll" } },
            new TestTrack(RS, 2023, HD, 6, "4:38", "Dreamy Skies") { Grouping = "Best" },
            new TestTrack(RS, 2023, HD, 7, "4:03", "Mess It Up") { ImageAltitude = 123.456 },
            new TestTrack(RS, 2023, HD, 8, "3:59", "Live by the Sword") { ImageCreator = "Sam Shere (1905–1982)" },
            new TestTrack(RS, 2023, HD, 9, "3:16", "Driving Me Too Hard") { ImageDateTime = DateTime.Parse("24/01/2024 19:34:00") },
            new TestTrack(RS, 2023, HD, 10, "2:56", "Tell Me Straight") { ImageExposureTime = 1.2345 },
            new TestTrack(RS, 2023, HD, 11, "7:22", "Sweet Sounds of Heaven") { ImageFNumber = 1.23 },
            new TestTrack(RS, 2023, HD, 12, "2:41", "Rolling Stone Blues (Muddy Waters)") { ImageFocalLength = 75.2 },

            new TestTrack(LZ, 1969, LZ, 1, "2:43", "Good Times Bad Times") { ImageFocalLengthIn35mmFilm = 60 },
            new TestTrack(LZ, 1969, LZ, 2, "6:40", "Babe I'm Gonna Leave You") { ImageISOSpeedRatings = 200},
            new TestTrack(LZ, 1969, LZ, 3, "6:30", "You Shook Me") { ImageKeywords = new [] { "Hindenburg", "Manchester", "New Jersey" } },
            new TestTrack(LZ, 1969, LZ, 4, "6:27", "Dazed and Confused") { ImageLatitude = 45.6 },
            new TestTrack(LZ, 1969, LZ, 5, "4:41", "Your Time is Gonna Come") { ImageLongitude = 277.8 },
            new TestTrack(LZ, 1969, LZ, 6, "2:06", "Black Mountain Side") { ImageMake = "Nikon" },
            new TestTrack(LZ, 1969, LZ, 7, "2:26", "Communication Breakdown") { ImageModel = "Pro" },
            new TestTrack(LZ, 1969, LZ, 8, "4:42", "I Can't Quit You Baby") { ImageOrientation = TagLib.Image.ImageOrientation.TopLeft},
            new TestTrack(LZ, 1969, LZ, 9, "8:28", "How Many More Times") { ImageRating = 5},

            new TestTrack(LZ, 1969, LZii, 1, "5:33", "Whole Lotta Love") { ImageSoftware = "Photoshop" },
            new TestTrack(LZ, 1969, LZii, 2, "4:47", "What Is and What Should Never Be") { InvariantEndPosition = 67890L },
            new TestTrack(LZ, 1969, LZii, 3, "6:20", "The Lemon Song") { InvariantStartPosition = 12345L },
            new TestTrack(LZ, 1969, LZii, 4, "3:50", "Thank You") { JoinedAlbumArtists = "Led Zeppelin" },
            new TestTrack(LZ, 1969, LZii, 5, "4:15", "Heartbreaker") { JoinedArtists = "Led Zeppelin" },
            new TestTrack(LZ, 1969, LZii, 6, "2:40", "Living Loving Maid (She's Just a Woman)") { JoinedComposers = "Led Zeppelin" },
            new TestTrack(LZ, 1969, LZii, 7, "4:35", "Ramble On") { JoinedGenres = "Rock & Roll" },
            new TestTrack(LZ, 1969, LZii, 8, "4:25", "Moby Dick") { JoinedPerformers = "Led Zeppelin" },
            new TestTrack(LZ, 1969, LZii, 9, "4:19", "Bring it On Home") { JoinedPerformersSort = "Led Zeppelin" },

            new TestTrack(LZ, 1970, LZiii, 1, "2:26", "Immigrant Song") { Lyrics = "We come from the land of the ice and snow" },
            new TestTrack(LZ, 1970, LZiii, 2, "3:55", "Friends") { MediaTypes = TagLib.MediaTypes.Audio | TagLib.MediaTypes.Photo },
            new TestTrack(LZ, 1970, LZiii, 3, "3:29", "Celebration Day") { MimeType = "taglib/mp3" },
            new TestTrack(LZ, 1970, LZiii, 4, "7:25", "Since I've Been Loving You") { MusicBrainzArtistId = "Artist0123" },
            new TestTrack(LZ, 1970, LZiii, 5, "4:04", "Out on the Tiles") { MusicBrainzDiscId = "Disc0123" },
            new TestTrack(LZ, 1970, LZiii, 6, "4:58", "Gallows Pole") { MusicBrainzReleaseArtistId = "ReleaseArtist0123" },
            new TestTrack(LZ, 1970, LZiii, 7, "3:12", "Tangerine") { MusicBrainzReleaseCountry = "Country0123" },
            new TestTrack(LZ, 1970, LZiii, 8, "5:38", "That's the Way") { MusicBrainzReleaseId = "Release0123" },
            new TestTrack(LZ, 1970, LZiii, 9, "4:20", "Bron-Y-Aur Stomp") { MusicBrainzReleaseStatus = "ReleaseStatus0123" },
            new TestTrack(LZ, 1970, LZiii, 10, "3:41", "Hats Off to (Roy) Harper") { MusicBrainzReleaseType = "ReleaseType0123" },

            new TestTrack(LZ, 1971, LZiv, 1, "4:55", "Black Dog") { MusicBrainzTrackId = "Track0123" },
            new TestTrack(LZ, 1971, LZiv, 2, "3:41", "Rock and Roll") { MusicIpId = "MusicIp0123" },
            new TestTrack(LZ, 1971, LZiv, 3, "5:52", "The Battle of Evermore") { Name = "Hastings" },
            new TestTrack(LZ, 1971, LZiv, 4, "8:03", "Stairway to Heaven") { Performers = new [] { "Page", "Plant", "Bonham", "Jones" } },
            new TestTrack(LZ, 1971, LZiv, 5, "4:39", "Misty Mountain Hop") { PerformersSort = new [] { "Bonham", "Jones", "Page", "Plant" } },
            new TestTrack(LZ, 1971, LZiv, 6, "4:46", "Four Sticks") { PhotoHeight = 480 },
            new TestTrack(LZ, 1971, LZiv, 7, "3:33", "Going to California") { PhotoQuality = 5 },
            new TestTrack(LZ, 1971, LZiv, 8, "7:08", "When the Levee Breaks") { PhotoWidth = 640 },

            new TestTrack(LZ, 1973, HH, 1, "5:32", "The Song Remains the Same") { Pictures = new[] { new Picture(@"C:\Pictures\Picture.png", 0, new TagLib.Picture()) } },
            new TestTrack(LZ, 1973, HH, 2, "7:39", "The Rain Song") { TagTypes = TagLib.TagTypes.Id3v1 | TagLib.TagTypes.Id3v2 },
            new TestTrack(LZ, 1973, HH, 3, "4:50", "Over the Hills and Far Away") { TitleSort = "and Away Far Hills Over the" },
            new TestTrack(LZ, 1973, HH, 4, "3:17", "The Crunge") { TrackNumber = 1, TrackCount = 2 },
            new TestTrack(LZ, 1973, HH, 5, "3:43", "Dancing Days") { TrackGain= "-4.07 dB" },
            new TestTrack(LZ, 1973, HH, 6, "4:23", "D'yer Mak'er") { TrackPeak = "1.049575" },
            new TestTrack(LZ, 1973, HH, 7, "7:00", "No Quarter") { VideoHeight = 480 },
            new TestTrack(LZ, 1973, HH, 8, "4:31", "The Ocean") { VideoWidth = 640 },
        };
    }
}
