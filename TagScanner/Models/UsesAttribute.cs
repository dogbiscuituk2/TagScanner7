namespace TagScanner.Models
{
    using System;

    [AttributeUsage(AttributeTargets.Property)]
    public class UsesAttribute : Attribute
    {
        public UsesAttribute(params string[] propertyNames) => _propertyNames = propertyNames;

        public static UsesAttribute Default = new UsesAttribute();

        private readonly string[] _propertyNames;
    }
}
