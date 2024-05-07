namespace TagScanner.Terms
{
    using System;
    using System.Linq.Expressions;

    public class CollectionField : Term
    {
        public CollectionField(string propertyName) { PropertyName = propertyName; }

        public override Expression Expression => Expression.Property(Collection, PropertyName);
        public string PropertyName { get; set; }

        public override Type ResultType
        {
            get
            {
                switch (PropertyName)
                {
                    case "Count":
                        return typeof(int);
                    default:
                        return null;
                }
            }
        }
    }
}
