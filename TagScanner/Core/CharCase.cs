namespace TagScanner.Core
{
    using System;

    [Flags]
    public enum CharCase
    {
        Sentence = 1, // Words separated by spaces. First word capitalized.
        Proper = 2, // Words separated by spaces. All words capitalized.
        Lower = 4, // All letters lowercase.
        Upper = 8, // All letters uppercase.
        Camel = 16, // All words except the first capitalized.
        Pascal = 32, // All words including the first capitalized.
        Snake = 64, // Words separated by underscores. All letters lowercase.
        Kebab = 128, // Words separated by hyphens. All letters lowercase.
    }
}
