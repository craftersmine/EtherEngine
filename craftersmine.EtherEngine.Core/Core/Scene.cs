using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Represents game scene
    /// </summary>
    public class Scene
    {
        internal List<GameObject> GameObjects = new List<GameObject>();

        /// <summary>
        /// Gets or sets scene background color
        /// </summary>
        public Color BackgroundColor { get; set; } = new Color(.0f, .0f, .0f);
        /// <summary>
        /// Gets or sets scene camera
        /// </summary>
        public Camera Camera { get; set; }

        /// <summary>
        /// Creates new instance of <see cref="Scene"/>
        /// </summary>
        public Scene()
        {
            Camera = new Camera();
        }

        /// <summary>
        /// Adds game object to scene
        /// </summary>
        /// <param name="gameObject">Game object</param>
        public void AddGameObject(GameObject gameObject)
        {
            GameObjects.Add(gameObject);
        }

        /// <summary>
        /// Calls when scene being created
        /// </summary>
        public virtual void OnCreate()
        { }

        /// <summary>
        /// Calls every time when scene being updated
        /// </summary>
        /// <param name="deltaTime">Delta time</param>
        public virtual void OnUpdate(float deltaTime)
        { }

        /// <summary>
        /// Calls every time when scene being updated at fixed periods
        /// </summary>
        /// <param name="deltaTime">Delta time</param>
        public virtual void OnFixedUpdate(float deltaTime)
        { }
    }
}
