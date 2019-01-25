using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using craftersmine.EtherEngine.Utilities;

namespace craftersmine.EtherEngine.Core
{
    public sealed class GameUpdater
    {
        private AccurateTimer _gameUpdaterThread;
        private int _delayBetweenTicks = 0;

        public int Tickrate { get; private set; }

        public GameUpdater(int tickrate)
        {
            Tickrate = tickrate;
            _delayBetweenTicks = 1000 / tickrate;
            _gameUpdaterThread = new AccurateTimer(_onUpdate, _delayBetweenTicks);
        }

        public void Run()
        {
            Debugging.Log(LogEntryType.Info, "Starting GameUpdater...");
            _gameUpdaterThread.Start();
        }

        public void Stop()
        {
            Debugging.Log(LogEntryType.Info, "Stopping GameUpdater...");
            _gameUpdaterThread.Stop();
        }

        public event EventHandler GameUpdate;

        private void _onUpdate()
        {
            if (Debugging.ShowDrawCallsPerFrameInTitle)
                Game.GameWnd.Title = Game.DefaultWindowTitle + " | " + GameRendererHelper.DrawCallsPerFrame + " DrawCalls/frame";
            if (SceneManager.CurrentScene != null)
            {
                SceneManager.CurrentScene.InternalUpdate();
                for (int obj = 0; obj < SceneManager.CurrentScene.GameObjects.Count; obj++)
                    SceneManager.CurrentScene.GameObjects[obj].InternalUpdate();
            }
        }
    }
}
