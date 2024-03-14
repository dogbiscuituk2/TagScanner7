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

        private static Work NewWork(string artist, int year, string album, int trackNumber, string duration, string title) => new Work
        {
            Performers = new[] { artist },
            Year = year,
            Album = album,
            TrackNumber = trackNumber,
            Duration = TimeSpan.Parse($"00:0{duration}"),
            Title = title,
        };

        private static readonly Work[] Works = new[]
        {
            NewWork(TheBeatles, 1967, SgtPepper, 1, "2:00", SgtPepper),
            NewWork(TheBeatles, 1967, SgtPepper, 2, "2:42", "With a Little Help from My Friends"),
            NewWork(TheBeatles, 1967, SgtPepper, 3, "3:28", "Lucy in the Sky with Diamonds"),
            NewWork(TheBeatles, 1967, SgtPepper, 4, "2:48", "Getting Better"),
            NewWork(TheBeatles, 1967, SgtPepper, 5, "2:36", "Fixing a Hole"),
            NewWork(TheBeatles, 1967, SgtPepper, 6, "3:25", "She's Leaving Home"),
            NewWork(TheBeatles, 1967, SgtPepper, 7, "2:37", "Being for the Benefit of Mr. Kite!"),
            NewWork(TheBeatles, 1967, SgtPepper, 8, "5:05", "Within You Without You"),
            NewWork(TheBeatles, 1967, SgtPepper, 9, "2:37", "When I'm Sixty-Four"),
            NewWork(TheBeatles, 1967, SgtPepper, 10, "2:42", "Lovely Rita"),
            NewWork(TheBeatles, 1967, SgtPepper, 11, "2:42", "Good Morning Good Morning"),
            NewWork(TheBeatles, 1967, SgtPepper, 12, "1:18", $"{SgtPepper} (Reprise)"),
            NewWork(TheBeatles, 1967, SgtPepper, 13, "5:38", "A Day in the Life"),

            NewWork(TheBeatles, 1970, LetItBe, 1, "3:36", "Two of Us"),
            NewWork(TheBeatles, 1970, LetItBe, 2, "3:54", "Dig a Pony"),
            NewWork(TheBeatles, 1970, LetItBe, 3, "3:48", "Across the Universe"),
            NewWork(TheBeatles, 1970, LetItBe, 4, "2:26", "I Me Mine"),
            NewWork(TheBeatles, 1970, LetItBe, 5, "0:50", "Dig It"),
            NewWork(TheBeatles, 1970, LetItBe, 6, "4:03", "Let It Be"),
            NewWork(TheBeatles, 1970, LetItBe, 7, "0:40", "Maggie Mae"),
            NewWork(TheBeatles, 1970, LetItBe, 8, "3:37", "I've Got a Feeling"),
            NewWork(TheBeatles, 1970, LetItBe, 9, "2:54", "One After 909"),
            NewWork(TheBeatles, 1970, LetItBe, 10, "3:38", "The Long and Winding Road"),
            NewWork(TheBeatles, 1970, LetItBe, 11, "2:32", "For You Blue"),
            NewWork(TheBeatles, 1970, LetItBe, 12, "3:09", "Get Back"),

            NewWork(TheStones, 1971, StickyFingers, 1, "3:48", "Brown Sugar"),
            NewWork(TheStones, 1971, StickyFingers, 2, "3:50", "Sway"),
            NewWork(TheStones, 1971, StickyFingers, 3, "5:42", "Wild Horses"),
            NewWork(TheStones, 1971, StickyFingers, 4, "7:14", "Can't You Hear Me Knocking"),
            NewWork(TheStones, 1971, StickyFingers, 5, "2:32", "You Gotta Move"),
            NewWork(TheStones, 1971, StickyFingers, 6, "3:38", "Bitch"),
            NewWork(TheStones, 1971, StickyFingers, 7, "3:54", "I Got the Blues"),
            NewWork(TheStones, 1971, StickyFingers, 8, "5:31", "Sister Morphine"),
            NewWork(TheStones, 1971, StickyFingers, 9, "4:03", "Dead Flowers"),
            NewWork(TheStones, 1971, StickyFingers, 10, "5:56", "Moonlight Mile"),

            NewWork(TheStones, 2023, HackneyDiamonds, 1, "3:46", "Angry"),
            NewWork(TheStones, 2023, HackneyDiamonds, 1, "4:10", "Get Close"),
            NewWork(TheStones, 2023, HackneyDiamonds, 1, "4:03", "Depending On You"),
            NewWork(TheStones, 2023, HackneyDiamonds, 1, "3:31", "Bite My Head Off"),
            NewWork(TheStones, 2023, HackneyDiamonds, 1, "3:58", "Whole Wide World"),
            NewWork(TheStones, 2023, HackneyDiamonds, 1, "4:38", "Dreamy Skies"),
            NewWork(TheStones, 2023, HackneyDiamonds, 1, "4:03", "Mess It Up"),
            NewWork(TheStones, 2023, HackneyDiamonds, 1, "3:59", "Live by the Sword"),
            NewWork(TheStones, 2023, HackneyDiamonds, 1, "3:16", "Driving Me Too Hard"),
            NewWork(TheStones, 2023, HackneyDiamonds, 1, "2:56", "Tell Me Straight"),
            NewWork(TheStones, 2023, HackneyDiamonds, 1, "7:22", "Sweet Sounds of Heaven"),
            NewWork(TheStones, 2023, HackneyDiamonds, 1, "2:41", "Rolling Stone Blues (Muddy Waters)"),
        };
    }
}
