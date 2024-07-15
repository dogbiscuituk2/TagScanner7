namespace TagScanner.Controllers
{
    using System;

    /// <summary>
    /// In normal operation, a call to Run() simply executes the assigned Action.
    /// After one or more calls to Pause(), all subsequent Run() calls are deferred until the matching number of Resume() calls is met or exceeded.
    /// At this point, if one or more Run() calls have occurred during the pause, then a single Run() call is emitted; otherwise none ocurs.
    /// Any superfluous (and probably erroneous?) calls to Resume() are ignored.
    /// A call to Abort() resets the controller to normal (unpaused) operation without emitting a call to Run().
    /// Note that the assigned Action may be changed at any time.
    /// </summary>
    public class UpdateController
    {
        #region Constructor

        public UpdateController(Action action) => _action = action;

        #endregion

        #region Public Properties

        public Action Action
        {
            get => _action;
            set => _action = value;
        }

        public bool Paused => _pauseCount > 0;

        #endregion

        #region Public Methods

        public void Abort()
        {
            _pauseCount = 0;
            _pending = false;
        }

        public void Pause() => _pauseCount++;

        public void Resume()
        {
            if (--_pauseCount <= 0)
            {
                _pauseCount = 0;
                if (_pending)
                    Run();
            }
        }

        public void Run()
        {
            _pending = _pauseCount > 0;
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
