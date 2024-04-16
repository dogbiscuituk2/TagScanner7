namespace TagScanner.Commands
{
    using Models;

    public abstract class Command
    {
        #region Constructor

        public Command() { }

        #endregion

        #region Properties

        public object Value { get; set; }

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

        public virtual void Invert() { }

        public abstract bool Run(Model model);

        #endregion
    }
}
