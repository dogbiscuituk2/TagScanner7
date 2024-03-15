namespace TagScanner.Models
{
    using System;

    [AttributeUsage(AttributeTargets.Property)]
    public class UsesAttribute : Attribute
    {
        public UsesAttribute(params Tag[] tags) => _tags = tags;

        public static UsesAttribute Default = new UsesAttribute();

        private readonly Tag[] _tags;
    }
}
