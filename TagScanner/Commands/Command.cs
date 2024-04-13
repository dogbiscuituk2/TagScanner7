namespace TagScanner.Commands
{
    using Models;

    public abstract class Command : ICommand
    {
        #region Constructor

        public Command() { }

        #endregion

        #region ICommand

        public abstract string UndoAction { get; }
        public abstract string RedoAction { get; }

        public virtual bool Do(Model model)
        {
            var result = Run(model);
            Invert();
            return result;
        }

        public void Invert() { }
        public abstract bool Run(Model model);

        #endregion

        #region Methods

        protected abstract void PropertyChanged(Model model, Tag tag);

        #endregion
    }
}
