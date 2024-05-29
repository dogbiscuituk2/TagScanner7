namespace TagScanner.Utils
{
    using System;

    [Flags]
    public enum CharCase
    {
        Sentence = 1, // Words separated by spaces. First word capitalized.
        Proper = 2, // Words separated by spaces. All words capitalized.
        lower = 4, // All letters lowercase.
        UPPER = 8, // All letters uppercase.
        caMel = 16, // All words except the first capitalized.
        PasCal = 32, // All words including the first capitalized.
        snake_ = 64, // Words separated by underscores. All letters lowercase.
        kebab = 128, // Words separated by hyphens. All letters lowercase.
    }
}
