using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Content;
using craftersmine.EtherEngine.Renderer;
using SharpDX.Direct2D1;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Represents a basic game object
    /// </summary>
    public class GameObject
    {
        /// <summary>
        /// Object transformation
        /// </summary>
        public Transform Transform;

        /// <summary>
        /// Object collision box
        /// </summary>
        public CollisionBox CollisionBox;

        /// <summary>
        /// Gets or sets object opacity
        /// </summary>
        [Obsolete("Will be removed in future versions, use RendererComponen.Material.Opacity instead")]
        public float ObjectOpacity { get; set; } = 1.0f;

        /// <summary>
        /// Gets or sets object tint color
        /// </summary>
        public Color ObjectTint { get; set; }

        /// <summary>
        /// Gets or sets game object component collection
        /// </summary>
        public GameObjectComponentCollection Components { get; set; }

        /// <summary>
        /// Creates new instance of <see cref="GameObject"/>
        /// </summary>
        public GameObject()
        {
            Transform = new Transform();
            CollisionBox = CollisionBox.Empty;
            Components = new GameObjectComponentCollection();
            Components.Add(new SpriteRenderer());
        }

        /// <summary>
        /// Searches component of specified type and returns first entry
        /// </summary>
        /// <typeparam name="T">Component type to get</typeparam>
        /// <returns></returns>
        public T GetComponent<T>()
        {
            foreach (var component in Components)
            {
                if (component.GetType() == typeof(T))
                    return (T)component;
                if (component.GetType().IsAssignableFrom(typeof(T)))
                    return (T)component;
                if (component.GetType().IsSubclassOf(typeof(T)))
                    return (T)component;
                if (component.GetType().GetInterfaces().Contains(typeof(T)))
                    return (T)component;
            }
            return default;
        }

        /// <summary>
        /// Calls every game update
        /// </summary>
        public virtual void OnUpdate()
        { }

        /// <summary>
        /// Calls every fixed game update
        /// </summary>
        public virtual void OnFixedUpdate()
        { }

        /// <summary>
        /// Calls when game object being created
        /// </summary>
        public virtual void OnCreate()
        {

        }

        internal void InternalOnCreate()
        {
            foreach (var component in Components)
                component.OnCreate(this);
            OnCreate();
        }

        internal void InternalOnFixedUpdate()
        {
            CollisionBox.ObjectX = Transform.X;
            CollisionBox.ObjectY = Transform.Y;
            CollisionBox.ObjectCameraX = Transform.CameraX;
            CollisionBox.ObjectCameraY = Transform.CameraY;
            foreach (var component in Components)
                component.OnFixedUpdate();
            OnFixedUpdate();
        }

        internal void InternalOnUpdate()
        {
            foreach (var component in Components)
                component.OnUpdate();
            OnUpdate();
        }

        /// <summary>
        /// Calls when engine performs a draw
        /// </summary>
        [Obsolete("Use component RendererComponent.OnRender() instead")]
        public void OnRender(RenderTarget renderTarget)
        {
            
        }
    }
}
