namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public partial class Test
    {
        [ClassInitialize] public static void ClassInitialize(TestContext _) { }
        [TestInitialize] public void TestInitialize() { }
        [TestCleanup] public void TestCleanup() { }
        [ClassCleanup] public static void ClassCleanup() { }

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
            LZiv = "Led Zeppelin IV";

        private static readonly Mock[] Works = new[]
        {
            new Mock(TB, 1967, SP, 1, "2:00", SP),
            new Mock(TB, 1967, SP, 2, "2:42", "With a Little Help from My Friends") { AlbumArtists = new[] { "John", "Paul", "George", "Ringo" } },
            new Mock(TB, 1967, SP, 3, "3:28", "Lucy in the Sky with Diamonds") { AlbumArtistsSort = new[] { "George", "John", "Paul", "Ringo" } },
            new Mock(TB, 1967, SP, 4, "2:48", "Getting Better") { AlbumGain = "-4.07 dB" },
            new Mock(TB, 1967, SP, 5, "2:36", "Fixing a Hole") { AlbumPeak = "1.049575" },
            new Mock(TB, 1967, SP, 6, "3:25", "She's Leaving Home") { AlbumSort = "Pepper, Sgt." },
            new Mock(TB, 1967, SP, 7, "2:37", "Being for the Benefit of Mr. Kite!") { AmazonId = "Amazon ID" },
            new Mock(TB, 1967, SP, 8, "5:05", "Within You Without You") { Artists = new[] { "John", "Paul", "George", "Ringo" } },
            new Mock(TB, 1967, SP, 9, "2:37", "When I'm Sixty-Four") { AudioBitrate = 320 },
            new Mock(TB, 1967, SP, 10, "2:42", "Lovely Rita") { AudioChannels = 2 },
            new Mock(TB, 1967, SP, 11, "2:42", "Good Morning Good Morning") { AudioSampleRate = 44100 },
            new Mock(TB, 1967, SP, 12, "1:18", $"{SP} (Reprise)") { BeatsPerMinute = 120 },
            new Mock(TB, 1967, SP, 13, "5:38", "A Day in the Life") { BitsPerSample = 24 },

            new Mock(TB, 1970, LIB, 1, "3:36", "Two of Us") { Codecs = "Audio (MPEG Version 1 Audio, Layer 3 - 0:02:34.768)" },
            new Mock(TB, 1970, LIB, 2, "3:54", "Dig a Pony") { Comment = "Wow!" },
            new Mock(TB, 1970, LIB, 3, "3:48", "Across the Universe") { Composers = new[] { "McCartney", "Lennon" } },
            new Mock(TB, 1970, LIB, 4, "2:26", "I Me Mine") { ComposersSort = new[] { "Lennon", "McCartney" } },
            new Mock(TB, 1970, LIB, 5, "0:50", "Dig It") { Conductor = "George Martin" },
            new Mock(TB, 1970, LIB, 6, "4:03", "Let It Be") { Copyright = "Hands Off It's Mine" },
            new Mock(TB, 1970, LIB, 7, "0:40", "Maggie Mae") { Description = "MPEG Version 1 Audio, Layer 3" },
            new Mock(TB, 1970, LIB, 8, "3:37", "I've Got a Feeling") { DiscNumber = 1, DiscCount = 2 },
            new Mock(TB, 1970, LIB, 9, "2:54", "One After 909") { DurationString="PT2M54S" },
            new Mock(TB, 1970, LIB, 10, "3:38", "The Long and Winding Road") { FileAttributes = "Archive" },
            new Mock(TB, 1970, LIB, 11, "2:32", "For You Blue") { FileCreationTime = DateTime.Parse("24/01/2024 19:34") },
            new Mock(TB, 1970, LIB, 12, "3:09", "Get Back") { FileCreationTimeUtc = DateTime.Parse("24/01/2024 19:34") },

            new Mock(RS, 1971, SF, 1, "3:48", "Brown Sugar") { FileLastAccessTime  = DateTime.Parse("24/01/2024 19:34") },
            new Mock(RS, 1971, SF, 2, "3:50", "Sway") { FileLastAccessTimeUtc = DateTime.Parse("24/01/2024 19:34") },
            new Mock(RS, 1971, SF, 3, "5:42", "Wild Horses") { FileLastWriteTime  = DateTime.Parse("24/01/2024 19:34") },
            new Mock(RS, 1971, SF, 4, "7:14", "Can't You Hear Me Knocking") { FileLastWriteTimeUtc  = DateTime.Parse("24/01/2024 19:34") },
            new Mock(RS, 1971, SF, 5, "2:32", "You Gotta Move") { FilePath = @"C:\Music\Stones\You Gotta Move.mp3" },
            new Mock(RS, 1971, SF, 6, "3:38", "Bitch") { FileSize = 2968691 },
            new Mock(RS, 1971, SF, 7, "3:54", "I Got the Blues") { FirstAlbumArtist = "Mick" },
            new Mock(RS, 1971, SF, 8, "5:31", "Sister Morphine") { FirstAlbumArtistSort = "Ronnie" },
            new Mock(RS, 1971, SF, 9, "4:03", "Dead Flowers") { FirstArtist = "Bill" },
            new Mock(RS, 1971, SF, 10, "5:56", "Moonlight Mile") { FirstComposer = "Beethoven" },

            new Mock(RS, 2023, HD, 1, "3:46", "Angry") { FirstComposerSort = "Bach" },
            new Mock(RS, 2023, HD, 1, "4:10", "Get Close") { FirstGenre = "Rock" },
            new Mock(RS, 2023, HD, 1, "4:03", "Depending On You") { FirstPerformer = "Jagger" },
            new Mock(RS, 2023, HD, 1, "3:31", "Bite My Head Off") { FirstPerformerSort = "Wyman" },
            new Mock(RS, 2023, HD, 1, "3:58", "Whole Wide World") { Genres = new[] { "Rock", "Roll" } },
            new Mock(RS, 2023, HD, 1, "4:38", "Dreamy Skies") { Grouping = "Best" },
            new Mock(RS, 2023, HD, 1, "4:03", "Mess It Up") { ImageAltitude = 123.456 },
            new Mock(RS, 2023, HD, 1, "3:59", "Live by the Sword") { ImageCreator = "Nikon" },
            new Mock(RS, 2023, HD, 1, "3:16", "Driving Me Too Hard") { ImageDateTime = DateTime.Parse("24/01/2024 19:34") },
            new Mock(RS, 2023, HD, 1, "2:56", "Tell Me Straight") { ImageExposureTime = 1.2345 },
            new Mock(RS, 2023, HD, 1, "7:22", "Sweet Sounds of Heaven") { ImageFNumber = 1.23 },
            new Mock(RS, 2023, HD, 1, "2:41", "Rolling Stone Blues (Muddy Waters)") { ImageFocalLength = 75.2 },

            new Mock(LZ, 1969, LZ, 1, "2:43", "Good Times Bad Times"),
            new Mock(LZ, 1969, LZ, 2, "6:40", "Babe I'm Gonna Leave You"),
            new Mock(LZ, 1969, LZ, 3, "6:30", "You Shook Me"),
            new Mock(LZ, 1969, LZ, 4, "6:27", "Dazed and Confused"),
            new Mock(LZ, 1969, LZ, 5, "4:41", "Your Time is Gonna Come"),
            new Mock(LZ, 1969, LZ, 6, "2:06", "Black Mountain Side"),
            new Mock(LZ, 1969, LZ, 7, "2:26", "Communication Breakdown"),
            new Mock(LZ, 1969, LZ, 8, "4:42", "I Can't Quit You Baby"),
            new Mock(LZ, 1969, LZ, 9, "8:28", "How Many More Times"),

            new Mock(LZ, 1969, LZii, 1, "5:33", "Whole Lotta Love"),
            new Mock(LZ, 1969, LZii, 2, "4:47", "What Is and What Should Never Be"),
            new Mock(LZ, 1969, LZii, 3, "6:20", "The Lemon Song"),
            new Mock(LZ, 1969, LZii, 4, "3:50", "Thank You"),
            new Mock(LZ, 1969, LZii, 5, "4:15", "Heartbreaker"),
            new Mock(LZ, 1969, LZii, 6, "2:40", "Living Loving Maid (She's Just a Woman)"),
            new Mock(LZ, 1969, LZii, 7, "4:35", "Ramble On"),
            new Mock(LZ, 1969, LZii, 8, "4:25", "Moby Dick"),
            new Mock(LZ, 1969, LZii, 9, "4:19", "Bring it On Home"),

            new Mock(LZ, 1970, LZiii, 1, "2:26", "Immigrant Song"),
            new Mock(LZ, 1970, LZiii, 2, "3:55", "Friends"),
            new Mock(LZ, 1970, LZiii, 3, "3:29", "Celebration Day"),
            new Mock(LZ, 1970, LZiii, 4, "7:25", "Since I've Been Loving You"),
            new Mock(LZ, 1970, LZiii, 5, "4:04", "Out on the Tiles"),
            new Mock(LZ, 1970, LZiii, 6, "4:58", "Gallows Pole"),
            new Mock(LZ, 1970, LZiii, 7, "3:12", "Tangerine"),
            new Mock(LZ, 1970, LZiii, 8, "5:38", "That's the Way"),
            new Mock(LZ, 1970, LZiii, 9, "4:20", "Bron-Y-Aur Stomp"),
            new Mock(LZ, 1970, LZiii, 10, "3:41", "Hats Off to (Roy) Harper"),

            new Mock(LZ, 1971, LZiv, 1, ":", "Black Dog"),
            new Mock(LZ, 1971, LZiv, 1, ":", "Rock and Roll"),
            new Mock(LZ, 1971, LZiv, 1, ":", "The Battle of Evermore"),
            new Mock(LZ, 1971, LZiv, 1, ":", "Stairway to Heaven"),
            new Mock(LZ, 1971, LZiv, 1, ":", "Misty Mountain Hop"),
            new Mock(LZ, 1971, LZiv, 1, ":", "Four Sticks"),
            new Mock(LZ, 1971, LZiv, 1, ":", ""),
            new Mock(LZ, 1971, LZiv, 1, ":", ""),
        };
    }
}
