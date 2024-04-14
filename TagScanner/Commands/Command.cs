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

        public virtual bool Do()
        {
            var result = Run();
            Invert();
            return result;
        }

        public void Invert() { }

        protected abstract void PropertyChanged();

        public abstract bool Run();

        #endregion
    }
}
