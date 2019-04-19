using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Core
{
    public partial class Scene
    {
        internal List<GameObject> GameObjects = new List<GameObject>();

        /// <summary>
        /// Adds <see cref="GameObject"/> to scene
        /// </summary>
        /// <param name="gameObject">Addable object</param>
        public void AddGameObject(GameObject gameObject)
        {
            gameObject.InternalCreate();
            GameObjects.Add(gameObject);
        }

        /// <summary>
        /// Adds range of <see cref="GameObject"/> to scene
        /// </summary>
        /// <param name="gameObjects">Addable objects collection</param>
        public void AddGameObjects(IEnumerable<GameObject> gameObjects)
        {
            foreach (var obj in gameObjects)
            {
                AddGameObject(obj);
            }
        }

        /// <summary>
        /// Removes <see cref="GameObject"/> from scene
        /// </summary>
        /// <param name="gameObject">Removable object</param>
        public void RemoveGameObject(GameObject gameObject)
        {
            if (GameObjects.Contains(gameObject))
            {
                GameObjects.Remove(gameObject);
            }
        }
    }
}
