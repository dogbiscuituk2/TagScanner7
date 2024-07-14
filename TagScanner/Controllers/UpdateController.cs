namespace TagScanner.Controllers
{
    using System;

    public class UpdateController
    {
        #region Constructor

        public UpdateController(Action action) => _action = action;

        #endregion

        #region Public Methods

        public void Pause() => _pauseCount++;

        public void Resume()
        {
            if (--_pauseCount == 0 && _pending)
                Run();
        }

        public void Run()
        {
            _pending = _pauseCount != 0;
            if (!_pending)
                _action();
        }

        #endregion

        #region Private Fields

        private Action _action;
        private int _pauseCount;
        bool _pending;

        #endregion
    }
}
