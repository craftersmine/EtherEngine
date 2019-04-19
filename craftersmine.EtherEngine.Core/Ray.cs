using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Utilities;

namespace craftersmine.EtherEngine.Core
{
    public class Ray
    {
        public Transform Transform { get; set; } = new Transform();
        public float MaxLength { get; set; }
        public float StartX { get { return Transform.X; } set { Transform.X = value; } }
        public float StartY { get { return Transform.Y; } set { Transform.Y = value; } }
        public float EndX { get; private set; }
        public float EndY { get; private set; }

        public Ray(int x, int y, float maxLength)
        {
            Transform.X = x;
            Transform.Y = y;
            MaxLength = maxLength;
        }

        public Ray(Point startPoint, float maxLength) : this(startPoint.X, startPoint.Y, maxLength) { }

        public GameObject[] Cast(float angle)
        {
            // fix angle amount
            while (angle >= 360.0f)
            {
                angle -= 360.0f;
            }
            // convert degree angle to radians
            double radAngle = angle * (Math.PI / 180.0d);
            // calculate x and y end point coordinate
            float EndX = StartX + ((float)Math.Cos(radAngle) * MaxLength);
            float EndY = StartY + ((float)Math.Sin(radAngle) * MaxLength);

            if (Debugging.DrawRays)
                Rendering.Window.CurrentWindow.GLGDI.DrawLine(Color.Blue, (int)StartX, (int)StartY, (int)EndX, (int)EndY);
            
            // get casted objects from scene
            List<GameObject> castedObjects = new List<GameObject>();
            for (int i = 0; i < SceneManager.CurrentScene.GameObjects.Count; i++)
            {
                if (new Rectangle(
                                        (int)SceneManager.CurrentScene.GameObjects[i].Transform.X,
                                        (int)SceneManager.CurrentScene.GameObjects[i].Transform.Y,
                                        SceneManager.CurrentScene.GameObjects[i].Transform.Width,
                                        SceneManager.CurrentScene.GameObjects[i].Transform.Height)
                                        .IsLineIntersects((int)StartX, (int)StartY, (int)EndX, (int)EndY))
                {
                    castedObjects.Add(SceneManager.CurrentScene.GameObjects[i]);
                }
            }
            return castedObjects.ToArray();
        }
    }
}
