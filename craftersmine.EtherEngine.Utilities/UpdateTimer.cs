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
        private TimeSpan _tpsCounterTime;
        
        /// <summary>
        /// Gets true if timer is active, otherwise false
        /// </summary>
        public bool IsActive { get; private set; }
        /// <summary>
        /// Gets current timer frequency
        /// </summary>
        public float UpdaterFrequency { get; private set; }
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
            IsActive = false;
            UpdaterFrequency = frequency;
            _updaterThread = new Thread(new ThreadStart(Updater));
            _updaterFrequency = TimeSpan.FromMilliseconds(1000.0f / UpdaterFrequency);
            _stopwatch = new Stopwatch();
        }

        /// <summary>
        /// Stops timer
        /// </summary>
        public void Stop()
        {
            IsActive = false;
            _stopwatch.Reset();
        }

        /// <summary>
        /// Starts timer
        /// </summary>
        public void Start()
        {
            IsActive = true;
            _updaterThread.Start();
        }

        private void Updater()
        {
            _lag = TimeSpan.Zero;
            _tpsCounterTime = TimeSpan.Zero;
            _stopwatch.Start();
            while (IsActive)
            {
                _current = _stopwatch.Elapsed;
                _elapsed = _current - _last;
                _lag += _elapsed;

                FixedUpdate?.Invoke(this, new UpdateEventArgs() { DeltaTime = _elapsed });

                while (_lag >= _updaterFrequency) {
                    Update?.Invoke(this, new UpdateEventArgs() { DeltaTime = _elapsed + _lag });
                    _lag -= _updaterFrequency;
                }

                _last = _current;
            }
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
}
