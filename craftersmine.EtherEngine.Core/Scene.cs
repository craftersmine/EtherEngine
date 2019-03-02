﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Represents game scene. This class cannot be inherited
    /// </summary>
    public class Scene
    {
        private Color _bgColor;

        internal List<GameObject> GameObjects = new List<GameObject>();

        /// <summary>
        /// Gets or sets <see cref="Scene"/> background color
        /// </summary>
        public Color BackgroundColor { get { return _bgColor; } set { _bgColor = value;
                if (Game.GameWnd != null)
                    Game.GameWnd.GLGDI.ClearColor = _bgColor; } }
        /// <summary>
        /// Gets or sets <see cref="Scene"/> camera
        /// </summary>
        public Camera SceneCamera { get; private set; }

        /// <summary>
        /// Creates new <see cref="Scene"/> instance
        /// </summary>
        public Scene()
        {

        }

        /// <summary>
        /// Calls when scene is being updated
        /// </summary>
        public virtual void OnUpdate()
        {

        }

        /// <summary>
        /// Calls when scene is being created
        /// </summary>
        public virtual void OnStart()
        {

        }

        /// <summary>
        /// Calls when scene is being unloaded
        /// </summary>
        public virtual void OnUnload()
        { }

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

        internal void InternalCreate()
        {
            SceneCamera = new Camera(Game.GameWnd.WindowSize.Width, Game.GameWnd.WindowSize.Height);
            SceneCamera.PlaceCamera(0, 0);
            OnStart();
        }

        internal void InternalUpdate()
        {
            OnUpdate();
        }
    }
}
