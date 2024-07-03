namespace TagScanner.Models
{
    using System;

    public class SchemaLine
    {
        #region Constructors

        public SchemaLine(int level, string description, string filespecs, bool check)
        {
            Level = level;
            Description = description;
            Filespecs = filespecs;
            Check = check;
        }

        public SchemaLine(string value)
        {
            var p = value.IndexOf('>');
            Level = Math.Sign(p) + 1;
            Description = value.Remove(0, p + 1);
            Filespecs = p > 0 ? value.Substring(0, p) : string.Empty;
            Check = Description.StartsWith(">");
            if (Check)
                Description = Description.Remove(0, 1);
        }

        #endregion

        #region Public Fields

        public readonly int Level;
        public readonly string Description, Filespecs;
        public readonly bool Check;

        #endregion

        #region Public Properties

        public string Filter => $"{Description}|{Filespecs.Replace('|', ';')}";

        #endregion

        #region Public Methods

        public override string ToString()
        {
            switch (Level)
            {
                case 0:
                    return Description;
                case 1:
                    return $">{Description}";
                default:
                    var separator = Check ? ">>" : ">";
                    return $"{Filespecs}{separator}{Description}";
            }
        }

        #endregion
    }
}
