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
    /// <summary>
    /// Represents an ray for ray-casting. This class cannot be inherited
    /// </summary>
    public sealed class Ray : IRenderable
    {
        private bool castedOnce;
        private Segment rayLine;

        /// <summary>
        /// Gets or sets current <see cref="Ray"/> transformation properties
        /// </summary>
        public Transform Transform { get; set; } = new Transform();
        /// <summary>
        /// Maximum casting range of ray
        /// </summary>
        public float MaxLength { get; set; }
        /// <summary>
        /// Gets or sets ray start point X position
        /// </summary>
        public float StartX { get { return Transform.X; } set { Transform.X = value; } }
        /// <summary>
        /// Gets or sets ray start point Y position
        /// </summary>
        public float StartY { get { return Transform.Y; } set { Transform.Y = value; } }
        /// <summary>
        /// Gets or sets ray end point X position
        /// </summary>
        public float EndX { get; private set; }
        /// <summary>
        /// Gets or sets ray end point Y position
        /// </summary>
        public float EndY { get; private set; }
        /// <summary>
        /// Not used by <see cref="Ray"/>
        /// </summary>
        public Texture Texture { get; set; }

        /// <summary>
        /// Creates new instance of <see cref="Ray"/> with specified start point position coordinates and maximum casting length
        /// </summary>
        /// <param name="x">Start point X position</param>
        /// <param name="y">Start point Y position</param>
        /// <param name="maxLength">Maximum ray cast length</param>
        public Ray(int x, int y, float maxLength)
        {
            Window.CurrentWindow.Render += CurrentWindow_Render;
            Transform.X = x;
            Transform.Y = y;
            if (maxLength <= 0)
                MaxLength = 1;
            else MaxLength = maxLength;
        }

        private void CurrentWindow_Render(object sender, RenderEventArgs e)
        {
            OnRender(e.GLGDIInstance);
        }

        /// <summary>
        /// Creates new instance of <see cref="Ray"/> with specified start point and maximum casting length
        /// </summary>
        /// <param name="startPoint">Ray start point</param>
        /// <param name="maxLength">Maximum ray cast length</param>
        public Ray(Point startPoint, float maxLength) : this(startPoint.X, startPoint.Y, maxLength) { }

        /// <summary>
        /// Makes ray cast on specified angle from start point and returns array of casted <see cref="GameObject"/>
        /// </summary>
        /// <param name="angle">Casting ray angle</param>
        /// <returns>Array of casted <see cref="GameObject"/></returns>
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

            rayLine = new Segment(new PointF(StartX, StartY), new PointF(EndX, EndY));

            castedOnce = true;

            // get casted objects from scene
            List<GameObject> castedObjects = new List<GameObject>();
            for (int i = 0; i < SceneManager.CurrentScene.GameObjects.Count; i++)
            {
                Rectangle objectBounds = SceneManager.CurrentScene.GameObjects[i].Transform.GetBoundsRectangle();
                if (rayLine.IsIntersectsRectangle(objectBounds))
                    castedObjects.Add(SceneManager.CurrentScene.GameObjects[i]);
            }
            return castedObjects.ToArray();
        }

        /// <summary>
        /// Calls when <see cref="Ray"/> being rendered
        /// </summary>
        /// <param name="renderer"></param>
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
