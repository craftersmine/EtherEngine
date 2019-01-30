﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Utilities;

namespace craftersmine.EtherEngine.Core
{
    public sealed class CollisionUpdater
    {
        private AccurateTimer _collisionUpdaterThread;
        private AccurateTimer _cpsUpdater;
        private int _delayBetweenTicks = 0;
        private int _ticks = 0;
        private int _lastTicks = 0;

        public int Tickrate { get; private set; }

        public CollisionUpdater(int tickrate)
        {
            Tickrate = tickrate;
            _delayBetweenTicks = 1000 / tickrate;
            _collisionUpdaterThread = new AccurateTimer(_onUpdate, _delayBetweenTicks);
            _cpsUpdater = new AccurateTimer(new Action(() => { _lastTicks = _ticks; _ticks = 0; Debugging.CollisionsUpdatesPerSecond = _lastTicks; }), 1000);
        }

        public void Run()
        {
            Debugging.Log(LogEntryType.Info, "Starting CollisionUpdater...");
            _collisionUpdaterThread.Start();
            _cpsUpdater.Start();
        }

        public void Stop()
        {
            Debugging.Log(LogEntryType.Info, "Stopping CollisionUpdater...");
            _collisionUpdaterThread.Stop();
            _cpsUpdater.Stop();
        }

        private void _onUpdate()
        {
            if (SceneManager.CurrentScene != null)
            {
                for (int obj = 0; obj < SceneManager.CurrentScene.GameObjects.Count; obj++)
                {
                    if (SceneManager.CurrentScene.GameObjects[obj].Collidable && SceneManager.CurrentScene.GameObjects[obj].CollisionBox.CollisionBoxBounds != Rectangle.Empty)
                    {
                        SceneManager.CurrentScene.GameObjects[obj].UpdateCollsionLocation();
                        for (int obj2 = 0; obj2 < SceneManager.CurrentScene.GameObjects.Count; obj2++)
                        {
                            if (SceneManager.CurrentScene.GameObjects[obj2].Collidable && SceneManager.CurrentScene.GameObjects[obj2].CollisionBox != null && SceneManager.CurrentScene.GameObjects[obj2].CollisionBox.CollisionBoxBounds != Rectangle.Empty)
                            {
                                SceneManager.CurrentScene.GameObjects[obj].UpdateCollsionLocation();
                                if (SceneManager.CurrentScene.GameObjects[obj].CollisionBox.CollisionBoxBoundsOffsetted.IntersectsWith(SceneManager.CurrentScene.GameObjects[obj2].CollisionBox.CollisionBoxBoundsOffsetted))
                                {
                                    SceneManager.CurrentScene.GameObjects[obj].InternalCollide(SceneManager.CurrentScene.GameObjects[obj2]);
                                }
                            }
                        }
                    }
                }
            }
            _ticks++;
        }
    }
}
