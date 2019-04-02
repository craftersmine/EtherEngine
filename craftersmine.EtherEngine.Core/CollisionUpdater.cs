using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Utilities;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Represents game collision updater. This class cannot be inherited
    /// </summary>
    public sealed class CollisionUpdater
    {
        private UpdateTimer _collisionUpdaterThread;

        /// <summary>
        /// Gets maximum possible collision updater tickrate (CU/s)
        /// </summary>
        public int Tickrate { get; private set; }

        /// <summary>
        /// Creates new <see cref="CollisionUpdater"/> instance with specified maximum tickrate
        /// </summary>
        /// <param name="tickrate">Maximum tickrate of updater</param>
        public CollisionUpdater(int tickrate)
        {
            Tickrate = tickrate;
            _collisionUpdaterThread = new UpdateTimer(Tickrate);
        }

        internal void OnFixedUpdate(object sender, UpdateEventArgs e)
        {
            if (SceneManager.CurrentScene != null)
            {
                for (int obj = 0; obj < SceneManager.CurrentScene.GameObjects.Count; obj++)
                {
                    if (SceneManager.CurrentScene.GameObjects[obj] != null)
                    {
                        if (SceneManager.CurrentScene.GameObjects[obj].CollisionBox != null)
                        {
                            if (SceneManager.CurrentScene.GameObjects[obj].Collidable && SceneManager.CurrentScene.GameObjects[obj].CollisionBox.CollisionBoxBounds != Rectangle.Empty)
                            {
                                SceneManager.CurrentScene.GameObjects[obj].UpdateCollsionLocation();
                                for (int obj2 = 0; obj2 < SceneManager.CurrentScene.GameObjects.Count; obj2++)
                                {
                                    if (SceneManager.CurrentScene.GameObjects[obj2] != null)
                                    {
                                        if (SceneManager.CurrentScene.GameObjects[obj2].CollisionBox != null)
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
                        }
                    }
                }
            }
        }
    }
}
