namespace TagScanner.Core
{
    public interface ICommand
    {
        void Apply(IModel model);
        string Caption { get; }
        string Text { get; }
    }
}
