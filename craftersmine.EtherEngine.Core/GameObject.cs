using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Content;
using craftersmine.EtherEngine.Rendering;

namespace craftersmine.EtherEngine.Core
{
    public class GameObject : IRenderable
    {
        public Texture Texture { get; set; }
        public CollisionBox CollisionBox { get; private set; }
        public Transform Transform { get; set; } = new Transform();
        public float X { get { return Transform.X; } set { Transform.X = value; } }
        public float Y { get { return Transform.Y; } set { Transform.Y = value; } }
        public int Width { get { return Transform.Width; } set { Transform.Width = value; } }
        public int Height { get { return Transform.Height; } set { Transform.Height = value; } }
        public bool IsVisibleByCamera { get; internal set; }
        public bool Visible { get; set; }
        public bool Collidable { get; set; }

        public virtual void OnStart()
        {

        }

        internal void InternalCreate()
        {
            Transform.ResetRotationOrigin();
            Visible = true;
            OnStart();
        }

        public virtual void OnUpdate()
        { }

        internal void InternalUpdate()
        {
            OnUpdate();
        }

        public virtual void OnCollide(GameObject gameObject)
        {

        }

        internal void InternalCollide(GameObject gameObject)
        {
            OnCollide(gameObject);
        }

        public virtual void OnRender(GLGDI renderer)
        {
            renderer.DrawImage(Texture.RenderableImage,
                                    Transform.RendererX,
                                    Transform.RendererY,
                                    Width,
                                    Height);
        }

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
