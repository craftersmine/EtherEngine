using System;
using System.Diagnostics;
using System.Threading;

namespace craftersmine.EtherEngine.Utilities
{
    /// <summary>
    /// Represents a specific frequency timer. This class cannot be inherited
    /// </summary>
    public sealed class UpdateTimer
    {
        private TimeSpan _last;
        private TimeSpan _lag;
        private TimeSpan _current;
        private TimeSpan _elapsed;
        private Thread _updaterThread;
        private TimeSpan _updaterFrequency;
        private Stopwatch _stopwatch;
        private TimeSpan _tpsAccumulator;
        private int fixedTicks;
        private int ticks;
        private float _updateFreq;
        
        /// <summary>
        /// Gets timer current state
        /// </summary>
        public TimerState CurrentState { get; private set; }
        /// <summary>
        /// Gets current timer frequency
        /// </summary>
        public float UpdaterFrequency { get { return _updateFreq; } set { _updateFreq = value; _updaterFrequency = TimeSpan.FromMilliseconds(1000.0f / _updateFreq); } }
        /// <summary>
        /// Gets last fixed update elapsed time
        /// </summary>
        public TimeSpan FixedUpdateTime { get { return _elapsed; } }
        /// <summary>
        /// Gets last update elapsed time
        /// </summary>
        public TimeSpan UpdateTime { get { return FixedUpdateTime + Lag; } }
        /// <summary>
        /// Gets lag time
        /// </summary>
        public TimeSpan Lag { get { return _lag; } }

        /// <summary>
        /// Occurs when FixedUpdate being called
        /// </summary>
        public event EventHandler<UpdateEventArgs> FixedUpdate;
        /// <summary>
        /// Occurs when Update beind called
        /// </summary>
        public event EventHandler<UpdateEventArgs> Update;
        //public TimeSpan LastUpdateTime { get { return _last; } }
        //public TimeSpan LagTime { get { return _lag; } }

        /// <summary>
        /// Creates new <see cref="UpdateTimer"/> instance with specific frequency
        /// </summary>
        /// <param name="frequency">Timer update frequency</param>
        public UpdateTimer(float frequency)
        {
            CurrentState = TimerState.Stopped;
            UpdaterFrequency = frequency;
            _updaterThread = new Thread(new ThreadStart(Updater));
            _stopwatch = new Stopwatch();
        }

        /// <summary>
        /// Stops timer
        /// </summary>
        public void Stop()
        {
            if (CurrentState == TimerState.Paused)
                CurrentState = TimerState.Active;
            CurrentState = TimerState.Stopped;
            _stopwatch.Reset();
        }

        /// <summary>
        /// Starts timer
        /// </summary>
        public void Start()
        {
            if (CurrentState == TimerState.Active)
                return;
            if (CurrentState == TimerState.Paused)
            {
                CurrentState = TimerState.Active;
                return;
            }
            CurrentState = TimerState.Active;
            _updaterThread.Start();
        }

        public void Pause()
        {
            CurrentState = TimerState.Paused;
        }

        private void Updater()
        {
            _stopwatch.Start();
            while (CurrentState == TimerState.Active || CurrentState == TimerState.Paused)
            {
                while (CurrentState == TimerState.Paused)
                { }

                _current = _stopwatch.Elapsed;
                _elapsed = _current - _last;
                _lag += _elapsed;

                Update?.Invoke(this, new UpdateEventArgs() { DeltaTime = _elapsed });
                Debugging.UpdateTime = (float)_elapsed.TotalSeconds;
                ticks++;

                Debugging.LagTime = (float)_lag.TotalSeconds * 1000.0f;

                while (_lag >= _updaterFrequency) {
                    FixedUpdate?.Invoke(this, new UpdateEventArgs() { DeltaTime = _elapsed + _lag });
                    Debugging.FixedUpdateTime = ((float)_elapsed.TotalSeconds + (float)_lag.TotalSeconds);
                    fixedTicks++;
                    _lag -= _updaterFrequency;
                }

                _last = _current;
                _tpsAccumulator += _elapsed;
                if (_tpsAccumulator >= TimeSpan.FromSeconds(1.0f))
                {
                    Debugging.TPS = ticks;
                    Debugging.FixedTPS = fixedTicks;
                    ticks = 0;
                    fixedTicks = 0;
                    _tpsAccumulator = TimeSpan.Zero;
                }
            }
            if (CurrentState == TimerState.Paused || CurrentState == TimerState.Active)
                Debugging.Log(LogEntryType.Warning, "Update timer was stopped unexpectedly!");
        }
    }

    /// <summary>
    /// Represents class which contains Update event data
    /// </summary>
    public sealed class UpdateEventArgs : EventArgs
    {
        /// <summary>
        /// Update delta time
        /// </summary>
        public TimeSpan DeltaTime { get; set; }
    }

    public enum TimerState
    {
        Active,
        Stopped,
        Paused
    }
}
