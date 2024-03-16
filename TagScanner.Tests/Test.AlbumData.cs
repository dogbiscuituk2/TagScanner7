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

        private const string
            TheBeatles = "The Beatles",
            SgtPepper = "Sgt. Pepper's Lonely Hearts Club Band",
            LetItBe = "Let It Be",
            TheStones = "The Rolling Stones",
            StickyFingers = "Sticky Fingers",
            HackneyDiamonds = "Hackney Diamonds";

        private static readonly Mock[] Works = new[]
        {
            new Mock(TheBeatles, 1967, SgtPepper, 1, "2:00", SgtPepper),
            new Mock(TheBeatles, 1967, SgtPepper, 2, "2:42", "With a Little Help from My Friends") { AlbumArtists = new[] { "John", "Paul", "George", "Ringo" } },
            new Mock(TheBeatles, 1967, SgtPepper, 3, "3:28", "Lucy in the Sky with Diamonds") { AlbumArtistsSort = new[] { "George", "John", "Paul", "Ringo" } },
            new Mock(TheBeatles, 1967, SgtPepper, 4, "2:48", "Getting Better") { AlbumGain = "-4.07 dB" },
            new Mock(TheBeatles, 1967, SgtPepper, 5, "2:36", "Fixing a Hole") { AlbumPeak = "1.049575" },
            new Mock(TheBeatles, 1967, SgtPepper, 6, "3:25", "She's Leaving Home") { AlbumSort = "Pepper, Sgt." },
            new Mock(TheBeatles, 1967, SgtPepper, 7, "2:37", "Being for the Benefit of Mr. Kite!") { AmazonId = "Amazon ID" },
            new Mock(TheBeatles, 1967, SgtPepper, 8, "5:05", "Within You Without You") { Artists = new[] { "John", "Paul", "George", "Ringo" } },

            new Mock(TheBeatles, 1967, SgtPepper, 9, "2:37", "When I'm Sixty-Four") { AudioBitrate = 320 },
            new Mock(TheBeatles, 1967, SgtPepper, 10, "2:42", "Lovely Rita") { AudioChannels = 2 },
            new Mock(TheBeatles, 1967, SgtPepper, 11, "2:42", "Good Morning Good Morning") { AudioSampleRate = 44100 },
            new Mock(TheBeatles, 1967, SgtPepper, 12, "1:18", $"{SgtPepper} (Reprise)") { BeatsPerMinute = 120 },
            new Mock(TheBeatles, 1967, SgtPepper, 13, "5:38", "A Day in the Life") { BitsPerSample = 24 },

            new Mock(TheBeatles, 1970, LetItBe, 1, "3:36", "Two of Us") { Codecs = "Audio (MPEG Version 1 Audio, Layer 3 - 0:02:34.768)" },
            new Mock(TheBeatles, 1970, LetItBe, 2, "3:54", "Dig a Pony") { Comment = "Wow!" },
            new Mock(TheBeatles, 1970, LetItBe, 3, "3:48", "Across the Universe") { Composers = new[] { "McCartney", "Lennon" } },
            new Mock(TheBeatles, 1970, LetItBe, 4, "2:26", "I Me Mine") { ComposersSort = new[] { "Lennon", "McCartney" } },
            new Mock(TheBeatles, 1970, LetItBe, 5, "0:50", "Dig It") { Conductor = "George Martin" },
            new Mock(TheBeatles, 1970, LetItBe, 6, "4:03", "Let It Be") { Copyright = "Hands Off It's Mine" },
            new Mock(TheBeatles, 1970, LetItBe, 7, "0:40", "Maggie Mae") { Description = "MPEG Version 1 Audio, Layer 3" },
            new Mock(TheBeatles, 1970, LetItBe, 8, "3:37", "I've Got a Feeling") { DiscNumber = 1, DiscCount = 2 },
            new Mock(TheBeatles, 1970, LetItBe, 9, "2:54", "One After 909") { DurationString="PT2M54S" },
            new Mock(TheBeatles, 1970, LetItBe, 10, "3:38", "The Long and Winding Road") { FileAttributes = "Archive" },
            new Mock(TheBeatles, 1970, LetItBe, 11, "2:32", "For You Blue") { FileCreationTime = DateTime.Parse("24/01/2024 19:34") },
            new Mock(TheBeatles, 1970, LetItBe, 12, "3:09", "Get Back") { FileCreationTimeUtc = DateTime.Parse("24/01/2024 19:34") },

            new Mock(TheStones, 1971, StickyFingers, 1, "3:48", "Brown Sugar") { FileLastAccessTime  = DateTime.Parse("24/01/2024 19:34") },
            new Mock(TheStones, 1971, StickyFingers, 2, "3:50", "Sway") { FileLastAccessTimeUtc = DateTime.Parse("24/01/2024 19:34") },
            new Mock(TheStones, 1971, StickyFingers, 3, "5:42", "Wild Horses") { FileLastWriteTime  = DateTime.Parse("24/01/2024 19:34") },
            new Mock(TheStones, 1971, StickyFingers, 4, "7:14", "Can't You Hear Me Knocking") { FileLastWriteTimeUtc  = DateTime.Parse("24/01/2024 19:34") },
            new Mock(TheStones, 1971, StickyFingers, 5, "2:32", "You Gotta Move") { FilePath = @"C:\Music\Stones\You Gotta Move.mp3" },
            new Mock(TheStones, 1971, StickyFingers, 6, "3:38", "Bitch") { FileSize = 2968691 },
            new Mock(TheStones, 1971, StickyFingers, 7, "3:54", "I Got the Blues") { FirstAlbumArtist = "Mick" },
            new Mock(TheStones, 1971, StickyFingers, 8, "5:31", "Sister Morphine") { FirstAlbumArtistSort = "Ronnie" },
            new Mock(TheStones, 1971, StickyFingers, 9, "4:03", "Dead Flowers") { FirstArtist = "Bill" },
            new Mock(TheStones, 1971, StickyFingers, 10, "5:56", "Moonlight Mile") { FirstComposer = "Beethoven" },

            new Mock(TheStones, 2023, HackneyDiamonds, 1, "3:46", "Angry") { FirstComposerSort = "Bach" },
            new Mock(TheStones, 2023, HackneyDiamonds, 1, "4:10", "Get Close") { FirstGenre = "Rock" },
            new Mock(TheStones, 2023, HackneyDiamonds, 1, "4:03", "Depending On You") { FirstPerformer = "Jagger" },
            new Mock(TheStones, 2023, HackneyDiamonds, 1, "3:31", "Bite My Head Off") { FirstPerformerSort = "Wyman" },
            new Mock(TheStones, 2023, HackneyDiamonds, 1, "3:58", "Whole Wide World") { Genres = new[] { "Rock", "Roll" } },
            new Mock(TheStones, 2023, HackneyDiamonds, 1, "4:38", "Dreamy Skies") { Grouping = "Best" },
            new Mock(TheStones, 2023, HackneyDiamonds, 1, "4:03", "Mess It Up") { ImageAltitude = 123.456 },
            new Mock(TheStones, 2023, HackneyDiamonds, 1, "3:59", "Live by the Sword") { ImageCreator = "Nikon" },
            new Mock(TheStones, 2023, HackneyDiamonds, 1, "3:16", "Driving Me Too Hard") { ImageDateTime = DateTime.Parse("24/01/2024 19:34") },
            new Mock(TheStones, 2023, HackneyDiamonds, 1, "2:56", "Tell Me Straight") { ImageExposureTime = 1.2345 },
            new Mock(TheStones, 2023, HackneyDiamonds, 1, "7:22", "Sweet Sounds of Heaven") { ImageFNumber = 1.23 },
            new Mock(TheStones, 2023, HackneyDiamonds, 1, "2:41", "Rolling Stone Blues (Muddy Waters)") { ImageFocalLength = 75.2 },
        };
    }
}
