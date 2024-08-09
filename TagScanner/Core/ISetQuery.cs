namespace TagScanner.Core
{
    using Models;

    public interface ISetQuery : IModel
    {
        void SetQuery(Query query);
    }
}
