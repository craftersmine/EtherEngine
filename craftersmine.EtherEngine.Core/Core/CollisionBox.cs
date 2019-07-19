using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Represents a collision box for object
    /// </summary>
    public struct CollisionBox
    {
        internal Plane Bounds;
        internal RectangleF ColliderBounds;

        private float width;
        private float height;
        private float offsetX;
        private float offsetY;
        private float objectX;
        private float objectY;
        private float objectCameraX;
        private float objectCameraY;

        /// <summary>
        /// Gets or sets width of collision box
        /// </summary>
        public float Width { get { return width; } set { width = value; UpdateColliderPlane(); } }
        /// <summary>
        /// Gets of sets height of collision box
        /// </summary>
        public float Height { get { return height; } set { height = value; UpdateColliderPlane(); } }
        /// <summary>
        /// Gets or sets collision box offset relative game object position along X axis
        /// </summary>
        public float OffsetX { get { return offsetX; } set { offsetX = value; UpdateColliderPlane(); } }
        /// <summary>
        /// Gets or sets collision box offset relative game object position along Y axis
        /// </summary>
        public float OffsetY { get { return offsetY; } set { offsetY = value; UpdateColliderPlane(); } }

        internal float ObjectX { get { return objectX; } set { objectX = value; UpdateColliderPlane(); } }
        internal float ObjectY { get { return objectY; } set { objectY = value; UpdateColliderPlane(); } }
        internal float ObjectCameraX { get { return objectCameraX; } set { objectCameraX = value; UpdateColliderPlane(); } }
        internal float ObjectCameraY { get { return objectCameraY; } set { objectCameraY = value; UpdateColliderPlane(); } }

        /// <summary>
        /// Contains collision box with parameters equals zeroes
        /// </summary>
        public readonly static CollisionBox Empty = new CollisionBox(0f, 0f, 0f, 0f);

        /// <summary>
        /// Creates a new instance of <see cref="CollisionBox"/> with specified parameters
        /// </summary>
        /// <param name="width">Width of collision box</param>
        /// <param name="height">Height of collision box</param>
        /// <param name="offsetX">Collision box offset relative game object position along X axis</param>
        /// <param name="offsetY">Collision box offset relative game object position along Y axis</param>
        public CollisionBox(float width, float height, float offsetX, float offsetY)
        {
            this.width = width;
            this.height = height;
            this.offsetX = offsetX;
            this.offsetY = offsetY;
            objectX = 0f;
            objectY = 0f;
            objectCameraX = 0f;
            objectCameraY = 0f;
            Bounds = new Plane(new Vector3(offsetX, offsetY, 0f), new Vector3(offsetX, offsetY + height, 0f), new Vector3(offsetX + width, offsetY + height, 0f));
            ColliderBounds = new RectangleF(offsetX, offsetY, width, height);

        }

        internal void UpdateColliderPlane()
        {
            Bounds = new Plane(new Vector3(offsetX + objectX, offsetY + objectY, 0f), new Vector3(offsetX + objectX, offsetY + objectY + Height, 0f), new Vector3(offsetX + objectX + Width, offsetY + objectY + Height, 0f));
            ColliderBounds = new RectangleF(offsetX + objectCameraX, offsetY + objectCameraY, width, height);
        }
    }
}
