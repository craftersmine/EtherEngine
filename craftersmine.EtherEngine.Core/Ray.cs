using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Content;
using craftersmine.EtherEngine.Rendering;
using craftersmine.EtherEngine.Utilities;

namespace craftersmine.EtherEngine.Core
{
    public class Ray : IRenderable
    {
        private bool castedOnce;

        public Transform Transform { get; set; } = new Transform();
        public float MaxLength { get; set; }
        public float StartX { get { return Transform.X; } set { Transform.X = value; } }
        public float StartY { get { return Transform.Y; } set { Transform.Y = value; } }
        public float EndX { get; private set; }
        public float EndY { get; private set; }
        public Texture Texture { get; set; }

        public Ray(int x, int y, float maxLength)
        {
            Window.CurrentWindow.Render += CurrentWindow_Render;
            Transform.X = x;
            Transform.Y = y;
            MaxLength = maxLength;
        }

        private void CurrentWindow_Render(object sender, RenderEventArgs e)
        {
            OnRender(e.GLGDIInstance);
        }

        public Ray(Point startPoint, float maxLength) : this(startPoint.X, startPoint.Y, maxLength) { }

        public GameObject[] Cast(float angle)
        {
            // fix angle amount
            while (angle >= 360.0f)
            {
                angle -= 360.0f;
            }
            while (angle < 0.0f)
            {
                angle += 360.0f;
            }
            // convert degree angle to radians
            double radAngle = angle * (Math.PI / 180.0d);
            // calculate x and y end point coordinate
            EndX = StartX + ((float)Math.Cos(radAngle) * MaxLength);
            EndY = StartY + ((float)Math.Sin(radAngle) * MaxLength);

            castedOnce = true;

            // get casted objects from scene
            List<GameObject> castedObjects = new List<GameObject>();
            for (int i = 0; i < SceneManager.CurrentScene.GameObjects.Count; i++)
            {
                Rectangle objectBounds = SceneManager.CurrentScene.GameObjects[i].Transform.GetBoundsRectangle();
                if (objectBounds.IsLineIntersects((int)StartX, (int)StartY, (int)EndX, (int)EndY))
                {
                    castedObjects.Add(SceneManager.CurrentScene.GameObjects[i]);
                }
            }
            return castedObjects.ToArray();
        }

        public void OnRender(GLGDI renderer)
        {
            if (Debugging.DrawRays)
                if (castedOnce)
                {
                    renderer.DrawLine(Color.Blue, (int)StartX, (int)StartY, (int)EndX, (int)EndY);
                    renderer.DrawPoint(Color.Lime, (int)StartX, (int)StartY, 2.5f);
                }
        }
    }
}
