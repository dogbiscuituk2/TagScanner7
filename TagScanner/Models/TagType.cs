namespace TagScanner.Models
{
    using System;

    public static class TagType
    {
        public const string
            Boolean = "Boolean",
            DateTime = "DateTime",
            Double = "Double",
            FileStatus = "FileStatus",
            ImageOrientation = "ImageOrientation",
            Int32 = "Int32",
            Int64 = "Int64",
            Logical = "Logical",
            MediaTypes = "MediaTypes",
            Pictures ="Picture[]",
            String = "String",
            Strings = "String[]",
            TagTypes = "TagTypes",
            TimeSpan = "TimeSpan";

        public static string Say(this Type type)
        {
            if (type.IsArray)
                return $"{type.GetElementType().Say()}[]";
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Boolean: return "condition";
                case TypeCode.Char: return "character";
                case TypeCode.Double: return "number";
                case TypeCode.Int32: return "integer";
                case TypeCode.Int64: return "long";
                case TypeCode.Object: return "this";
                case TypeCode.String: return "string";
                default: return type.Name;
            }
        }
    }
}
