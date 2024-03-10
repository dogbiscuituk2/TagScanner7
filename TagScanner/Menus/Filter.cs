namespace TagScanner.Menus
{
    using System;

    [Flags]
    public enum Filter
    {
        None,
        FirstArg = 1,
        Returns = 2,
        Target = FirstArg | Returns,
        Disable = 4,
        Hide = 8,
        Action = Disable | Hide,
    }
}
