namespace TagScanner.Models
{
    using System;

    [AttributeUsage(AttributeTargets.Property)]
    public class FrequentlyUsedAttribute : Attribute
    {
        public FrequentlyUsedAttribute(bool frequentlyUsed = true) => _frequentlyUsed = frequentlyUsed;

        public static FrequentlyUsedAttribute Default = new FrequentlyUsedAttribute(false);

        private readonly bool _frequentlyUsed;
    }
}
