namespace TagScanner.Core
{
    public interface ICommand
    {
        void Apply(IModel model);
        string Summary { get; set; }
    }
}
