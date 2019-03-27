using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using craftersmine.EtherEngine.Content;
using craftersmine.EtherEngine.Rendering;

namespace craftersmine.EtherEngine.GDK.GameBaseComponents
{
    /// <summary>
    /// Represents basic game object
    /// </summary>
    [Serializable]
    public class EditorGameObject : IRenderable
    {
        private int _frameCounter = 0;
        private int _currentAnimationFrame = 0;

        /// <summary>
        /// Gets or sets <see cref="Content.Texture"/> which being rendered
        /// </summary>
        [XmlIgnore]
        public Texture Texture { get; set; }
        /// <summary>
        /// Gets or sets <see cref="Content.Animation"/> for object
        /// </summary>
        [XmlIgnore]
        public Animation Animation { get; set; }
        /// <summary>
        /// Gets <see cref="Core.CollisionBox"/> which being used by <see cref="CollisionUpdater"/> to check collisions
        /// </summary>
        [XmlIgnore]
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
        /// Gets or sets object texture or animation texture transparency factor
        /// </summary>
        public float ObjectTransparency { get; set; } = 1.0f;
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
        public bool IsVisibleByCamera { get; set; }
        /// <summary>
        /// Gets or sets true if <see cref="GameObject"/> is being rendered else false
        /// </summary>
        public bool Visible { get; set; }
        /// <summary>
        /// Gets or sets true if <see cref="CollisionUpdater"/> will check collisions for this object
        /// </summary>
        public bool Collidable { get; set; }
        /// <summary>
        /// Gets or sets true if object animation enabled, else false
        /// </summary>
        public bool IsAnimated { get; set; }
        /// <summary>
        /// Gets or sets object texture or animation texture blending color
        /// </summary>
        public Color BlendingColor { get; set; }

        /// <summary>
        /// Calls when <see cref="GameObject"/> being created
        /// </summary>
        public virtual void OnStart()
        {

        }

        internal void InternalCreate()
        {
            BlendingColor = Color.White;
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
        public virtual void OnCollide(EditorGameObject gameObject)
        {

        }

        internal void InternalCollide(EditorGameObject gameObject)
        {
            OnCollide(gameObject);
        }

        public virtual void OnMouseDown(int mouseX, int mouseY, bool mouseLeftButton, bool mouseMiddleButton, bool mouseRightButton)
        {

        }

        /// <summary>
        /// Calls when <see cref="GameObject"/> is being rendered
        /// </summary>
        /// <param name="renderer"></param>
        public virtual void OnRender(GLGDI renderer)
        {
            byte objTransparencyCalculated = (byte)(255 * ObjectTransparency);
            //if (objTransparencyCalculated < 0)
            //    objTransparencyCalculated = 0;
            //else if (objTransparencyCalculated > 255)
            //    objTransparencyCalculated = 255;

            if (IsAnimated)
            {
                if (Animation != null)
                {
                    if (_frameCounter == Animation.TicksPerFrame)
                    {
                        _frameCounter = 0;
                        _currentAnimationFrame++;
                        if (_currentAnimationFrame == Animation.FramesCount)
                            ResetAnimation();
                    }
                    renderer.DrawImage(Animation.AnimationFrames[_currentAnimationFrame].RenderableImage,
                                    Transform.RendererX,
                                    Transform.RendererY,
                                    Width,
                                    Height,
                                    new GLGDIPlus.BlendingValues(BlendingColor.R, BlendingColor.G, BlendingColor.B, objTransparencyCalculated));
                    _frameCounter++;
                }
                else IsAnimated = false;
            }
            else
            {
                renderer.DrawImage(Texture.RenderableImage,
                                    Transform.RendererX,
                                    Transform.RendererY,
                                    Width,
                                    Height,
                                    new GLGDIPlus.BlendingValues(BlendingColor.R, BlendingColor.G, BlendingColor.B, objTransparencyCalculated));
            }
            
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
            CollisionBox.CollisionBoxBoundsOffsetted = new Rectangle(colliderX, colliderY, CollisionBox.CollisionBoxBounds.Width, CollisionBox.CollisionBoxBounds.Height);
        }

        /// <summary>
        /// Resets object animation frame to first
        /// </summary>
        public void ResetAnimation()
        {
            _currentAnimationFrame = 0;
        }

        /// <summary>
        /// Creates shallow of the current object of specified type
        /// </summary>
        /// <typeparam name="T">The type of returnable cloned object</typeparam>
        /// <returns></returns>
        public virtual T Clone<T>()
        {
            return (T)MemberwiseClone();
        }
    }
}
