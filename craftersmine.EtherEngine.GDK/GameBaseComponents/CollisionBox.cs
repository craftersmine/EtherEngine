using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.GDK.GameBaseComponents
{
    /// <summary>
    /// Represents collision box. This class cannot be inherited
    /// </summary>
    public sealed class CollisionBox
    {
        /// <summary>
        /// Gets current <see cref="CollisionBox"/> bounds
        /// </summary>
        public Rectangle CollisionBoxBounds { get; private set; }

        internal Rectangle CollisionBoxBoundsOffsetted { get; set; }

        /// <summary>
        /// Creates new instance of <see cref="CollisionBox"/> with specified <see cref="Rectangle"/> bounds
        /// </summary>
        /// <param name="collisionBox"><see cref="Rectangle"/> which represents bounds of <see cref="CollisionBox"/></param>
        public CollisionBox(Rectangle collisionBox)
        {
            CollisionBoxBounds = collisionBox;
            CollisionBoxBoundsOffsetted = new Rectangle(collisionBox.Location, collisionBox.Size);
        }

        /// <summary>
        /// Creates new instance of <see cref="CollisionBox"/> with specified bounds
        /// </summary>
        /// <param name="xOffset">Collision box offset relative <see cref="GameObject"/> X position</param>
        /// <param name="yOffset">Collision box offset relative <see cref="GameObject"/> Y posision</param>
        /// <param name="width">Collision box width</param>
        /// <param name="height">Collision box height</param>
        public CollisionBox(int xOffset, int yOffset, int width, int height) : this(new Rectangle(xOffset, yOffset, width, height)) { }

        /// <summary>
        /// Updates collision box with new specified <see cref="Rectangle"/> bounds
        /// </summary>
        /// <param name="newCollisionBox"><see cref="Rectangle"/> which represents bounds of <see cref="CollisionBox"/></param>
        public void UpdateCollisionBox(Rectangle newCollisionBox)
        {
            CollisionBoxBounds = newCollisionBox;
        }

        /// <summary>
        /// Updates collision box with new specified bounds
        /// </summary>
        /// <param name="xOffset">Collision box offset relative <see cref="GameObject"/> X position</param>
        /// <param name="yOffset">Collision box offset relative <see cref="GameObject"/> Y posision</param>
        /// <param name="width">Collision box width</param>
        /// <param name="height">Collision box height</param>
        public void UpdateCollisionBox(int xOffset, int yOffset, int width, int height)
        {
            UpdateCollisionBox(new Rectangle(xOffset, yOffset, width, height));
        }
    }
}
