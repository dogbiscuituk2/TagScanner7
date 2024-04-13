namespace TagScanner.Commands
{
    using Models;

    public interface ICommand
    {
        string UndoAction { get; }
        string RedoAction { get; }

        bool Do(Model model);
        bool Run(Model model);

        void Invert();
    }
}
