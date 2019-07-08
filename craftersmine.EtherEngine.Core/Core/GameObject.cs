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
    public class GameObject : IRenderable
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
        /// Gets or sets object texture
        /// </summary>
        public Texture Texture { get; set; }

        /// <summary>
        /// Gets or sets object opacity
        /// </summary>
        public float ObjectOpacity { get; set; } = 1.0f;

        /// <summary>
        /// Gets or sets object tint color
        /// </summary>
        public Color ObjectTint { get; set; }

        /// <summary>
        /// Creates new instance of <see cref="GameObject"/>
        /// </summary>
        public GameObject()
        {
            Transform = new Transform();
            CollisionBox = CollisionBox.Empty;
        }

        /// <summary>
        /// Calls every game update
        /// </summary>
        /// <param name="deltaTime">Delta time</param>
        public virtual void OnUpdate(float deltaTime)
        { }

        /// <summary>
        /// Calls every fixed game update
        /// </summary>
        /// <param name="deltaTime">Delta time</param>
        public virtual void OnFixedUpdate(float deltaTime)
        { }

        /// <summary>
        /// Calls when game object being created
        /// </summary>
        public virtual void OnCreate()
        {

        }

        internal void InternalOnFixedUpdate(float deltaTime)
        {
            CollisionBox.ObjectX = Transform.X;
            CollisionBox.ObjectY = Transform.Y;
            CollisionBox.ObjectCameraX = Transform.CameraX;
            CollisionBox.ObjectCameraY = Transform.CameraY;
            OnFixedUpdate(deltaTime);
        }

        internal void InternalOnUpdate(float deltaTime)
        {
            OnUpdate(deltaTime);
        }

        /// <summary>
        /// Calls when engine performs a draw
        /// </summary>
        public void OnRender(RenderTarget renderTarget)
        {
            if (Texture != null)
            {
                renderTarget.DrawBitmap(Texture.Bitmap, Transform.DrawingBoundings, ObjectOpacity, (BitmapInterpolationMode)Game.Renderer.InterpolationMode);
            }
        }
    }
}
