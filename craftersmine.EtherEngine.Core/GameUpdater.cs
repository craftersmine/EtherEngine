using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using craftersmine.EtherEngine.Utilities;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Represents game updater timer. This class cannot be inherited
    /// </summary>
    public sealed class GameUpdater
    {
        private AccurateTimer _gameUpdaterThread;
        private AccurateTimer _tpsUpdater;
        private int _delayBetweenTicks = 0;
        private int _ticks = 0;
        private int _lastTicks = 0;

        /// <summary>
        /// Gets current <see cref="GameUpdater"/> tickrate (TPS)
        /// </summary>
        public int Tickrate { get; private set; }

        /// <summary>
        /// Creates new <see cref="GameUpdater"/> instance with specified maximum tickrate
        /// </summary>
        /// <param name="tickrate">Maximum tickrate of updater</param>
        public GameUpdater(int tickrate)
        {
            Tickrate = tickrate;
            _delayBetweenTicks = 1000 / tickrate;
            _gameUpdaterThread = new AccurateTimer(_onUpdate, _delayBetweenTicks);
            _tpsUpdater = new AccurateTimer(new Action(() => { _lastTicks = _ticks; _ticks = 0; Debugging.TPS = _lastTicks; }), 1000);
        }

        /// <summary>
        /// Starts <see cref="GameUpdater"/> update loop
        /// </summary>
        public void Run()
        {
            Debugging.Log(LogEntryType.Info, "Starting GameUpdater...");
            _gameUpdaterThread.Start();
            _tpsUpdater.Start();
        }

        /// <summary>
        /// Stops <see cref="GameUpdater"/> update loop
        /// </summary>
        public void Stop()
        {
            Debugging.Log(LogEntryType.Info, "Stopping GameUpdater...");
            _gameUpdaterThread.Stop();
            _tpsUpdater.Stop();
        }

        private void _onUpdate()
        {
            if (SceneManager.CurrentScene != null)
            {
                SceneManager.CurrentScene.InternalUpdate();
                for (int obj = 0; obj < SceneManager.CurrentScene.GameObjects.Count; obj++)
                    SceneManager.CurrentScene.GameObjects[obj].InternalUpdate();
            }
            _ticks++;
        }
    }
}
