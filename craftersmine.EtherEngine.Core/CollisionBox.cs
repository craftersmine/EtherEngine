using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Core
{
    public sealed class CollisionBox
    {
        public Rectangle CollisionBoxBounds { get; private set; }
        internal Rectangle CollisionBoxBoundsOffsetted { get; set; }

        public CollisionBox(Rectangle collisionBox)
        {
            CollisionBoxBounds = collisionBox;
            CollisionBoxBoundsOffsetted = new Rectangle(collisionBox.Location, collisionBox.Size);
        }

        public CollisionBox(int xOffset, int yOffset, int width, int height) : this(new Rectangle(xOffset, yOffset, width, height)) { }

        public void UpdateCollisionBox(Rectangle newCollisionBox)
        {
            CollisionBoxBounds = newCollisionBox;
        }

        public void UpdateCollisionBox(int xOffset, int yOffset, int width, int height)
        {
            UpdateCollisionBox(new Rectangle(xOffset, yOffset, width, height));
        }
    }
}
