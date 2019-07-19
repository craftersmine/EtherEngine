using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Renderer;
using SharpDX.Direct2D1;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Represents a basic renderer component which is base for other renderers
    /// </summary>
    public class BaseRenderer : IGameObjectComponent, IRenderable
    {
        private bool isCreated;
        private GameObject parentGameObject;

        /// <summary>
        /// Gets true if renderer was successfully created
        /// </summary>
        public bool IsCreated { get { return isCreated; } }
        /// <summary>
        /// Gets game object that contains this component
        /// </summary>
        public GameObject ParentGameObject { get { return parentGameObject; } }

        /// <summary>
        /// Called at component creation
        /// </summary>
        /// <param name="gameObject">Game object that initiated creation</param>
        public virtual void OnCreate(GameObject gameObject)
        {
            parentGameObject = gameObject;
            isCreated = true;
        }

        /// <summary>
        /// Called at component fixed update
        /// </summary>
        public virtual void OnFixedUpdate()
        {
            
        }

        /// <summary>
        /// Called when renderer performs frame render
        /// </summary>
        /// <param name="renderFrame">Render frame where you can draw</param>
        public virtual void OnRender(RenderFrame renderFrame)
        {
            
        }

        /// <summary>
        /// Called at component update
        /// </summary>
        public virtual void OnUpdate()
        {
            
        }
    }
}
