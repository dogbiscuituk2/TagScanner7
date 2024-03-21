namespace TagScanner.Utils
{
    using System.Drawing;

    internal class Ink
    {
        internal Ink(Inks inks = Inks._16inks) => Inks = inks;

        /// <summary>
        /// Essentially 0 to 4.
        /// </summary>
        internal Inks Inks { get; set; }

        internal Brush Brush(int ink) => _brushes[Pick(ink)];
        internal Color Colour(int ink) => _colours[Pick(ink)];
        internal Pen Pen(int ink) => _pens[Pick(ink)];

        private readonly Brush[] _brushes =
        {
            Brushes.Black,
            Brushes.DarkRed,
            Brushes.Brown,
            Brushes.MediumVioletRed,
            Brushes.Red,
            Brushes.DarkOrange,
            Brushes.DarkGoldenrod,
            Brushes.DarkOliveGreen,
            Brushes.DarkGreen,
            Brushes.Green,
            Brushes.DarkCyan,
            Brushes.Blue,
            Brushes.DarkBlue,
            Brushes.DarkOrchid,
            Brushes.DarkViolet,
            Brushes.DarkMagenta,
        };

        private readonly Color[] _colours =
        {
            Color.Black,
            Color.DarkRed,
            Color.Brown,
            Color.MediumVioletRed,
            Color.Red,
            Color.DarkOrange,
            Color.DarkGoldenrod,
            Color.DarkOliveGreen,
            Color.DarkGreen,
            Color.Green,
            Color.DarkCyan,
            Color.Blue,
            Color.DarkBlue,
            Color.DarkOrchid,
            Color.DarkViolet,
            Color.DarkMagenta,
        };

        private readonly Pen[] _pens =
        {
            Pens.Black,
            Pens.DarkRed,
            Pens.Brown,
            Pens.MediumVioletRed,
            Pens.Red,
            Pens.DarkOrange,
            Pens.DarkGoldenrod,
            Pens.DarkOliveGreen,
            Pens.DarkGreen,
            Pens.Green,
            Pens.DarkCyan,
            Pens.Blue,
            Pens.DarkBlue,
            Pens.DarkOrchid,
            Pens.DarkViolet,
            Pens.DarkMagenta,
        };

        /// <summary>
        /// int mask = (1 << ((int)Inks)) - 1;
        /// int scale = 4 - (int)Inks;
        /// return (ink & mask) << scale;
        /// </summary>
        /// <param name="ink">Index, from 0 to max colours - 1.</param>
        /// <returns>Calculated index into arrays.</returns>
        private int Pick(int ink) => (ink & ((1 << ((int)Inks)) - 1)) << (4 - (int)Inks);
    }
}
