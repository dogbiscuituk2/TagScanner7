namespace TagScanner.Commands
{
    using Models;

    public abstract class Command
    {
        #region Constructor

        public Command() { }

        #endregion

        #region Properties

        public abstract string UndoAction { get; }
        public abstract string RedoAction { get; }

        #endregion

        #region Methods

        public virtual bool Do(Model model)
        {
            var result = Run(model);
            Invert();
            return result;
        }

        public void Invert() { }

        protected abstract void PropertyChanged(Model model, Tag tag);

        public abstract bool Run(Model model);

        #endregion
    }
}
