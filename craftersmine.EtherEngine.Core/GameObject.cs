using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Content;
using craftersmine.EtherEngine.Rendering;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Represents basic game object
    /// </summary>
    public class GameObject : IRenderable
    {
        /// <summary>
        /// Gets or sets <see cref="Content.Texture"/> which being rendered
        /// </summary>
        public Texture Texture { get; set; }
        /// <summary>
        /// Gets <see cref="Core.CollisionBox"/> which being used by <see cref="CollisionUpdater"/> to check collisions
        /// </summary>
        public CollisionBox CollisionBox { get; private set; }
        /// <summary>
        /// Gets or sets <see cref="GameObject"/> transformation properties
        /// </summary>
        public Transform Transform { get; set; } = new Transform();
        /// <summary>
        /// Gets or sets <see cref="GameObject"/> X axis position
        /// </summary>
        public float X { get { return Transform.X; } set { Transform.X = value; } }
        /// <summary>
        /// Gets or sets <see cref="GameObject"/> Y axis position
        /// </summary>
        public float Y { get { return Transform.Y; } set { Transform.Y = value; } }
        /// <summary>
        /// Gets or sets <see cref="GameObject"/> width
        /// </summary>
        public int Width { get { return Transform.Width; } set { Transform.Width = value; } }
        /// <summary>
        /// Gets or sets <see cref="GameObject"/> height
        /// </summary>
        public int Height { get { return Transform.Height; } set { Transform.Height = value; } }
        /// <summary>
        /// Gets true if <see cref="GameObject"/> is visible by camera
        /// </summary>
        public bool IsVisibleByCamera { get; internal set; }
        /// <summary>
        /// Gets or sets true if <see cref="GameObject"/> is being rendered else false
        /// </summary>
        public bool Visible { get; set; }
        /// <summary>
        /// Gets or sets true if <see cref="CollisionUpdater"/> will check collisions for this object
        /// </summary>
        public bool Collidable { get; set; }

        /// <summary>
        /// Calls when <see cref="GameObject"/> being created
        /// </summary>
        public virtual void OnStart()
        {

        }

        internal void InternalCreate()
        {
            Transform.ResetRotationOrigin();
            Visible = true;
            OnStart();
        }

        /// <summary>
        /// Calls when <see cref="GameObject"/> is being updated
        /// </summary>
        public virtual void OnUpdate()
        { }

        internal void InternalUpdate()
        {
            OnUpdate();
        }

        /// <summary>
        /// Calls when <see cref="GameObject"/> collided with other object
        /// </summary>
        /// <param name="gameObject">Collided object</param>
        public virtual void OnCollide(GameObject gameObject)
        {

        }

        internal void InternalCollide(GameObject gameObject)
        {
            OnCollide(gameObject);
        }

        /// <summary>
        /// Calls when <see cref="GameObject"/> is being rendered
        /// </summary>
        /// <param name="renderer"></param>
        public virtual void OnRender(GLGDI renderer)
        {
            renderer.DrawImage(Texture.RenderableImage,
                                    Transform.RendererX,
                                    Transform.RendererY,
                                    Width,
                                    Height);
        }

        /// <summary>
        /// Sets <see cref="GameObject"/> collision box
        /// </summary>
        /// <param name="collisionBox">Collision box</param>
        public void SetCollsionBox(CollisionBox collisionBox)
        {
            CollisionBox = collisionBox;
        }

        internal void UpdateCollsionLocation()
        {
            int colliderX = CollisionBox.CollisionBoxBounds.X + (int)this.X;
            int colliderY = CollisionBox.CollisionBoxBounds.Y + (int)this.Y;
            CollisionBox.CollisionBoxBoundsOffsetted = new System.Drawing.Rectangle(colliderX, colliderY, CollisionBox.CollisionBoxBounds.Width, CollisionBox.CollisionBoxBounds.Height);
        }
    }
}
