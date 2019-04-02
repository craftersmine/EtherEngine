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
        private UpdateTimer _gameUpdaterThread;

        /// <summary>
        /// Gets maximum possible <see cref="GameUpdater"/> tickrate (TPS)
        /// </summary>
        public int Tickrate { get; private set; }

        /// <summary>
        /// Creates new <see cref="GameUpdater"/> instance with specified maximum tickrate
        /// </summary>
        /// <param name="tickrate">Maximum tickrate of updater</param>
        public GameUpdater(int tickrate)
        {
            Tickrate = tickrate;
            _gameUpdaterThread = new UpdateTimer(Tickrate);
            _gameUpdaterThread.Update += _onUpdate;
            _gameUpdaterThread.FixedUpdate += Game.CollisionUpdater.OnFixedUpdate;
        }

        /// <summary>
        /// Starts <see cref="GameUpdater"/> update loop
        /// </summary>
        public void Run()
        {
            Debugging.Log(LogEntryType.Info, "Starting GameUpdater...");
            _gameUpdaterThread.Start();
        }

        /// <summary>
        /// Stops <see cref="GameUpdater"/> update loop
        /// </summary>
        public void Stop()
        {
            Debugging.Log(LogEntryType.Info, "Stopping GameUpdater...");
            _gameUpdaterThread.Stop();
        }

        private void _onUpdate(object sender, UpdateEventArgs e)
        {
            if (SceneManager.CurrentScene != null)
            {
                SceneManager.CurrentScene.InternalUpdate(e.DeltaTime);
                for (int obj = 0; obj < SceneManager.CurrentScene.GameObjects.Count; obj++)
                    if (SceneManager.CurrentScene.GameObjects[obj] != null)
                    {
                        SceneManager.CurrentScene.GameObjects[obj].InternalUpdate(e.DeltaTime);
                    }
            }

            Debugging.FixedUpdateTime = (float)_gameUpdaterThread.FixedUpdateTime.TotalSeconds * 1000.0f;
            Debugging.UpdateTime = (float)_gameUpdaterThread.FixedUpdateTime.TotalSeconds * 1000.0f;
        }
    }
}
