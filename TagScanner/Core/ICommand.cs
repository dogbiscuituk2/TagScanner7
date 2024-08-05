namespace TagScanner.Core
{
    public interface ICommand
    {
        int Do(IModel model);
    }
}
