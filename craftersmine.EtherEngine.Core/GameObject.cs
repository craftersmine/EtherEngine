using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Content;

namespace craftersmine.EtherEngine.Core
{
    public class GameObject
    {
        internal int RendererX { get { return (int)X - SceneManager.CurrentScene.SceneCamera.CameraX; } }
        internal int RendererY { get { return (int)Y + SceneManager.CurrentScene.SceneCamera.CameraY; } }

        public Texture Texture { get; set; }
        public CollisionBox CollisionBox { get; private set; }
        public float X { get; set; }
        public float Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool IsVisibleByCamera { get; internal set; }
        public bool Visible { get; set; }
        public bool Collidable { get; set; }

        public virtual void OnStart()
        {

        }

        internal void InternalCreate()
        {
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
