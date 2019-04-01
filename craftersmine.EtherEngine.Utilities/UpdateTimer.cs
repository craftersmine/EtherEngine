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
        private DateTime _last;
        private TimeSpan _lag;
        private DateTime _current;
        private TimeSpan _elapsed;
        private Thread _updaterThread;
        private TimeSpan _updaterFrequency;
        
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
        }

        /// <summary>
        /// Stops timer
        /// </summary>
        public void Stop()
        {
            IsActive = false;
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
            _last = DateTime.Now;
            _lag = TimeSpan.Zero;
            while (IsActive)
            {
                _current = DateTime.Now;
                _elapsed = _current - _last;
                _last = _current;
                _lag += _elapsed;

                FixedUpdate?.Invoke(this, new UpdateEventArgs() { DeltaTime = _elapsed });

                while (_lag >= _updaterFrequency) {
                    Update?.Invoke(this, new UpdateEventArgs() { DeltaTime = _elapsed + _lag });
                    _lag -= _updaterFrequency;
                }
            }
        }
    }

    public sealed class UpdateEventArgs : EventArgs
    {
        public TimeSpan DeltaTime { get; set; }
    }
}
