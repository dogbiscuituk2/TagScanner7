namespace TagScanner.Tests
{
    using System;
    using Models;

    public static class Test
    {
        public static readonly Track[] Tracks = new[]
        {
            NewTrack(TB, 1967, SP, 1, "2:00", SP),
            NewTrack(TB, 1967, SP, 2, "2:42", "With a Little Help from My Friends"),
            NewTrack(TB, 1967, SP, 3, "3:28", "Lucy in the Sky with Diamonds"),
            NewTrack(TB, 1967, SP, 4, "2:48", "Getting Better"),
            NewTrack(TB, 1967, SP, 5, "2:36", "Fixing a Hole"),
            NewTrack(TB, 1967, SP, 6, "3:25", "She's Leaving Home"),
            NewTrack(TB, 1967, SP, 7, "2:37", "Being for the Benefit of Mr. Kite!"),
            NewTrack(TB, 1967, SP, 8, "5:05", "Within You Without You"),
            NewTrack(TB, 1967, SP, 9, "2:37", "When I'm Sixty-Four"),
            NewTrack(TB, 1967, SP, 10, "2:42", "Lovely Rita"),
            NewTrack(TB, 1967, SP, 11, "2:42", "Good Morning Good Morning"),
            NewTrack(TB, 1967, SP, 12, "1:18", $"{SP} (Reprise)"),
            NewTrack(TB, 1967, SP, 13, "5:38", "A Day in the Life"),

            NewTrack(TB, 1970, LIB, 1, "3:36", "Two of Us"),
            NewTrack(TB, 1970, LIB, 2, "3:54", "Dig a Pony"),
            NewTrack(TB, 1970, LIB, 3, "3:48", "Across the Universe"),
            NewTrack(TB, 1970, LIB, 4, "2:26", "I Me Mine"),
            NewTrack(TB, 1970, LIB, 5, "0:50", "Dig It"),
            NewTrack(TB, 1970, LIB, 6, "4:03", "Let It Be"),
            NewTrack(TB, 1970, LIB, 7, "0:40", "Maggie Mae"),
            NewTrack(TB, 1970, LIB, 8, "3:37", "I've Got a Feeling"),
            NewTrack(TB, 1970, LIB, 9, "2:54", "One After 909"),
            NewTrack(TB, 1970, LIB, 10, "3:38", "The Long and Winding Road"),
            NewTrack(TB, 1970, LIB, 11, "2:32", "For You Blue") ,
            NewTrack(TB, 1970, LIB, 12, "3:09", "Get Back"),

            NewTrack(RS, 1971, SF, 1, "3:48", "Brown Sugar"),
            NewTrack(RS, 1971, SF, 2, "3:50", "Sway"),
            NewTrack(RS, 1971, SF, 3, "5:42", "Wild Horses"),
            NewTrack(RS, 1971, SF, 4, "7:14", "Can't You Hear Me Knocking"),
            NewTrack(RS, 1971, SF, 5, "2:32", "You Gotta Move"),
            NewTrack(RS, 1971, SF, 6, "3:38", "Bitch"),
            NewTrack(RS, 1971, SF, 7, "3:54", "I Got the Blues"),
            NewTrack(RS, 1971, SF, 8, "5:31", "Sister Morphine"),
            NewTrack(RS, 1971, SF, 9, "4:03", "Dead Flowers"),
            NewTrack(RS, 1971, SF, 10, "5:56", "Moonlight Mile"),

            NewTrack(RS, 2023, HD, 1, "3:46", "Angry"),
            NewTrack(RS, 2023, HD, 2, "4:10", "Get Close"),
            NewTrack(RS, 2023, HD, 3, "4:03", "Depending On You"),
            NewTrack(RS, 2023, HD, 4, "3:31", "Bite My Head Off"),
            NewTrack(RS, 2023, HD, 5, "3:58", "Whole Wide World"),
            NewTrack(RS, 2023, HD, 6, "4:38", "Dreamy Skies"),
            NewTrack(RS, 2023, HD, 7, "4:03", "Mess It Up"),
            NewTrack(RS, 2023, HD, 8, "3:59", "Live by the Sword"),
            NewTrack(RS, 2023, HD, 9, "3:16", "Driving Me Too Hard"),
            NewTrack(RS, 2023, HD, 10, "2:56", "Tell Me Straight"),
            NewTrack(RS, 2023, HD, 11, "7:22", "Sweet Sounds of Heaven"),
            NewTrack(RS, 2023, HD, 12, "2:41", "Rolling Stone Blues (Muddy Waters)"),

            NewTrack(LZ, 1969, LZ, 1, "2:43", "Good Times Bad Times"),
            NewTrack(LZ, 1969, LZ, 2, "6:40", "Babe I'm Gonna Leave You"),
            NewTrack(LZ, 1969, LZ, 3, "6:30", "You Shook Me"),
            NewTrack(LZ, 1969, LZ, 4, "6:27", "Dazed and Confused"),
            NewTrack(LZ, 1969, LZ, 5, "4:41", "Your Time is Gonna Come"),
            NewTrack(LZ, 1969, LZ, 6, "2:06", "Black Mountain Side"),
            NewTrack(LZ, 1969, LZ, 7, "2:26", "Communication Breakdown"),
            NewTrack(LZ, 1969, LZ, 8, "4:42", "I Can't Quit You Baby"),
            NewTrack(LZ, 1969, LZ, 9, "8:28", "How Many More Times"),

            NewTrack(LZ, 1969, LZii, 1, "5:33", "Whole Lotta Love"),
            NewTrack(LZ, 1969, LZii, 2, "4:47", "What Is and What Should Never Be"),
            NewTrack(LZ, 1969, LZii, 3, "6:20", "The Lemon Song"),
            NewTrack(LZ, 1969, LZii, 4, "3:50", "Thank You"),
            NewTrack(LZ, 1969, LZii, 5, "4:15", "Heartbreaker"),
            NewTrack(LZ, 1969, LZii, 6, "2:40", "Living Loving Maid (She's Just a Woman)"),
            NewTrack(LZ, 1969, LZii, 7, "4:35", "Ramble On"),
            NewTrack(LZ, 1969, LZii, 8, "4:25", "Moby Dick"),
            NewTrack(LZ, 1969, LZii, 9, "4:19", "Bring it On Home"),

            NewTrack(LZ, 1970, LZiii, 1, "2:26", "Immigrant Song"),
            NewTrack(LZ, 1970, LZiii, 2, "3:55", "Friends"),
            NewTrack(LZ, 1970, LZiii, 3, "3:29", "Celebration Day"),
            NewTrack(LZ, 1970, LZiii, 4, "7:25", "Since I've Been Loving You"),
            NewTrack(LZ, 1970, LZiii, 5, "4:04", "Out on the Tiles"),
            NewTrack(LZ, 1970, LZiii, 6, "4:58", "Gallows Pole"),
            NewTrack(LZ, 1970, LZiii, 7, "3:12", "Tangerine"),
            NewTrack(LZ, 1970, LZiii, 8, "5:38", "That's the Way"),
            NewTrack(LZ, 1970, LZiii, 9, "4:20", "Bron-Y-Aur Stomp"),
            NewTrack(LZ, 1970, LZiii, 10, "3:41", "Hats Off to (Roy) Harper"),

            NewTrack(LZ, 1971, LZiv, 1, "4:55", "Black Dog"),
            NewTrack(LZ, 1971, LZiv, 2, "3:41", "Rock and Roll"),
            NewTrack(LZ, 1971, LZiv, 3, "5:52", "The Battle of Evermore"),
            NewTrack(LZ, 1971, LZiv, 4, "8:03", "Stairway to Heaven"),
            NewTrack(LZ, 1971, LZiv, 5, "4:39", "Misty Mountain Hop"),
            NewTrack(LZ, 1971, LZiv, 6, "4:46", "Four Sticks"),
            NewTrack(LZ, 1971, LZiv, 7, "3:33", "Going to California"),
            NewTrack(LZ, 1971, LZiv, 8, "7:08", "When the Levee Breaks"),

            NewTrack(LZ, 1973, HH, 1, "5:32", "The Song Remains the Same"),
            NewTrack(LZ, 1973, HH, 2, "7:39", "The Rain Song"),
            NewTrack(LZ, 1973, HH, 3, "4:50", "Over the Hills and Far Away"),
            NewTrack(LZ, 1973, HH, 4, "3:17", "The Crunge"),
            NewTrack(LZ, 1973, HH, 5, "3:43", "Dancing Days"),
            NewTrack(LZ, 1973, HH, 6, "4:23", "D'yer Mak'er"),
            NewTrack(LZ, 1973, HH, 7, "7:00", "No Quarter"),
            NewTrack(LZ, 1973, HH, 8, "4:31", "The Ocean")
        };

        private static Track NewTrack(string artist, int year, string album, int trackNumber, string duration, string title) => new Track()
        {
            Album = album,
            Duration = TimeSpan.Parse($"{"00:00:00".Substring(0, 8 - duration.Length)}{duration}"),
            JoinedAlbumArtists = artist,
            JoinedArtists = artist,
            JoinedComposers = artist,
            JoinedPerformers = artist,
            Performers = new[] { artist },
            TrackNumber = trackNumber,
            Title = title,
            Year = year
        };

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
    }
}
