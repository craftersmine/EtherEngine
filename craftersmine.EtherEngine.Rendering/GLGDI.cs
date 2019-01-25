using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GLGDIPlus;
using craftersmine.EtherEngine.Utilities;

namespace craftersmine.EtherEngine.Rendering
{
    /// <summary>
    /// Represents GLGDI+ library wrapper. This class cannot be inherited
    /// </summary>
    public sealed class GLGDI
    {
        private GLGraphics GLGraphics { get; set; }
        private Color clearColor;
        private bool linearFilteringEnabled;

        /// <summary>
        /// Gets or sets current clearing color
        /// </summary>
        public Color ClearColor { get { return clearColor; } set { clearColor = value; GLGraphics.SetClearColor(clearColor); } }

        /// <summary>
        /// Gets or sets true if LINEAR filtering enabled or false if NEAREST filtering enabled
        /// </summary>
        public bool IsLinearFilteringEnabled { get { return linearFilteringEnabled; } set { linearFilteringEnabled = value; GLGraphics.SetLinearFiltering(linearFilteringEnabled); } }

        /// <summary>
        /// Creates a new instance of GLGDI+ wrapper
        /// </summary>
        public GLGDI()
        {
            GLGraphics = new GLGraphics();
            GLGraphics.Init();
            GLGraphics.Reset();
            GLGraphics.Clear();
            GLGraphics.SetClearColor(Color.LightBlue);
            GLGraphics.Clear();
        }

        /// <summary>
        /// Draws rectangle with specified color
        /// </summary>
        /// <param name="color">Drawing color</param>
        /// <param name="rectangle">Drawing rectangle data</param>
        public void DrawRectangle(Color color, Rectangle rectangle)
        {
            GLGraphics.DrawRectangle(color, rectangle);
        }

        /// <summary>
        /// Draws rectangle with specified color, width, height and at specified location coordinates
        /// </summary>
        /// <param name="color">Drawing color</param>
        /// <param name="x">X location coordinate</param>
        /// <param name="y">Y location coordinate</param>
        /// <param name="width">Width of rectangle</param>
        /// <param name="height">Height of rectangle</param>
        public void DrawRectangle(Color color, int x, int y, int width, int height)
        {
            GLGraphics.DrawRectangle(color, x, y, width, height);
        }

        /// <summary>
        /// Draws line with specified color
        /// </summary>
        /// <param name="color">Drawing color</param>
        /// <param name="xStart">Line start point X location</param>
        /// <param name="yStart">Line start point Y location</param>
        /// <param name="xEnd">Line end point X location</param>
        /// <param name="yEnd">Line end point Y location</param>
        public void DrawLine(Color color, int xStart, int yStart, int xEnd, int yEnd)
        {
            GLGraphics.DrawLine(color, xStart, yStart, xEnd, yEnd);

        }

        /// <summary>
        /// Draws image at specified location
        /// </summary>
        /// <param name="image">Drawing image</param>
        /// <param name="x">Image X location</param>
        /// <param name="y">Image Y location</param>
        public void DrawImage(GLImage image, int x, int y)
        {
            GLGraphics.DrawImage(image, x, y);
        }

        /// <summary>
        /// Draws image at specified location and blending values
        /// </summary>
        /// <param name="image">Drawing image</param>
        /// <param name="x">Image X location</param>
        /// <param name="y">Image Y location</param>
        /// <param name="blendingValues">Color blending values</param>
        public void DrawImage(GLImage image, int x, int y, BlendingValues blendingValues)
        {
            GLGraphics.DrawImage(image, x, y, blendingValues);
        }

        /// <summary>
        /// Draws image at specified rectangle from source rectangle
        /// </summary>
        /// <param name="image">Drawing image</param>
        /// <param name="destinationRectangle">Destination rectangle</param>
        /// <param name="sourceRectangle">Source rectangle</param>
        public void DrawImage(GLImage image, Rectangle destinationRectangle, Rectangle sourceRectangle)
        {
            GLGraphics.DrawImage(image, destinationRectangle, sourceRectangle);
        }

        /// <summary>
        /// Draws image at specified rectangle from source rectangle with specified blending values
        /// </summary>
        /// <param name="image">Drawing image</param>
        /// <param name="destinationRectangle">Destination rectangle</param>
        /// <param name="sourceRectangle">Source rectangle</param>
        /// <param name="blendingValues">Color blending values</param>
        public void DrawImage(GLImage image, Rectangle destinationRectangle, Rectangle sourceRectangle, BlendingValues blendingValues)
        {
            GLGraphics.DrawImage(image, destinationRectangle, sourceRectangle, blendingValues);
        }

        /// <summary>
        /// Draws image at specified location with specified width and height
        /// </summary>
        /// <param name="image">Drawing image</param>
        /// <param name="x">Image X location</param>
        /// <param name="y">Image Y location</param>
        /// <param name="width">Drawing bounds width</param>
        /// <param name="height">Drawing bounds height</param>
        public void DrawImage(GLImage image, int x, int y, int width, int height)
        {
            GLGraphics.DrawImage(image, x, y, width, height);
        }

        /// <summary>
        /// Draws image at specified location with specified width and height and blending values
        /// </summary>
        /// <param name="image">Drawing image</param>
        /// <param name="x">Image X location</param>
        /// <param name="y">Image Y location</param>
        /// <param name="width">Drawing bounds width</param>
        /// <param name="height">Drawing bounds height</param>
        /// <param name="blendingValues">Color blending values</param>
        public void DrawImage(GLImage image, int x, int y, int width, int height, BlendingValues blendingValues)
        {
            GLGraphics.DrawImage(image, x, y, width, height, blendingValues);
        }

        /// <summary>
        /// Draws tiled image
        /// </summary>
        /// <param name="multiImage">Drawing multi image</param>
        public void DrawTiledImage(GLMultiImage multiImage)
        {
            GLGraphics.DrawMultiImage(multiImage);
        }

        /// <summary>
        /// Draws tiled image with specified blending values
        /// </summary>
        /// <param name="multiImage">Drawing multi image</param>
        /// <param name="blendingValues">Color blending values</param>
        public void DrawTiledImage(GLMultiImage multiImage, BlendingValues blendingValues)
        {
            GLGraphics.DrawMultiImage(multiImage, blendingValues);
        }

        /// <summary>
        /// Draws point with specified color and size
        /// </summary>
        /// <param name="color">Drawing color</param>
        /// <param name="point">Drawing point</param>
        /// <param name="pointSize">Point size</param>
        public void DrawPoint(Color color, Point point, float pointSize)
        {
            GLGraphics.DrawPoint(color, point, pointSize);
        }

        /// <summary>
        /// Draws point with specified color and size at specified location
        /// </summary>
        /// <param name="color">Drawing color</param>
        /// <param name="x">Point X location</param>
        /// <param name="y">Point Y location</param>
        /// <param name="pointSize">Point size</param>
        public void DrawPoint(Color color, int x, int y, float pointSize)
        {
            DrawPoint(color, new Point(x, y), pointSize);
        }

        /// <summary>
        /// Draws point with floating point coordinates values with specified color and size
        /// </summary>
        /// <param name="color">Drawing color</param>
        /// <param name="point">Drawing point</param>
        /// <param name="pointSize">Point size</param>
        public void DrawPoint(Color color, PointF point, float pointSize)
        {
            GLGraphics.DrawPointF(color, point, pointSize);
        }

        /// <summary>
        /// Draws points with specified color and size
        /// </summary>
        /// <param name="color">Drawing color</param>
        /// <param name="points">Array of drawing points</param>
        /// <param name="pointSize">Points size</param>
        public void DrawPoints(Color color, Point[] points, float pointSize)
        {
            foreach (var point in points)
            {
                DrawPoint(color, point, pointSize);
            }
        }

        /// <summary>
        /// Draws points with floating point coordinates values with specified color and size
        /// </summary>
        /// <param name="color">Drawing color</param>
        /// <param name="points">Array of drawing points</param>
        /// <param name="pointSize">Points size</param>
        public void DrawPoints(Color color, PointF[] points, float pointSize)
        {
            GLGraphics.DrawPointsF(color, new List<PointF>(points), pointSize);
        }

        /// <summary>
        /// Draws string with specified text, font, color at specified location
        /// </summary>
        /// <param name="text">Drawing string</param>
        /// <param name="font">Text font</param>
        /// <param name="color">Text color</param>
        /// <param name="x">String X location</param>
        /// <param name="y">String Y location</param>
        public void DrawString(string text, Font font, Color color, int x, int y)
        {
            GLGraphics.DrawString(text, font, color, x, y);
        }

        /// <summary>
        /// Draws string with specified text, font, color at specified location and quality
        /// </summary>
        /// <param name="text">Drawing string</param>
        /// <param name="font">Text font</param>
        /// <param name="color">Text color</param>
        /// <param name="x">String X location</param>
        /// <param name="y">String Y location</param>
        /// <param name="quality">Text quality</param>
        public void DrawString(string text, Font font, Color color, int x, int y, TextQuality quality)
        {
            GLGraphics.DrawString(text, font, color, x, y, (GLGraphics.TextQuality)quality);
        }

        /// <summary>
        /// Draws string with specified text, font, color at specified bounding rectangle and quality
        /// </summary>
        /// <param name="text">Drawing string</param>
        /// <param name="font">Text font</param>
        /// <param name="color">Text color</param>
        /// <param name="rectangle">Drawing bounding rectangle</param>
        /// <param name="quality">Text quality</param>
        public void DrawString(string text, Font font, Color color, Rectangle rectangle, TextQuality quality)
        {
            GLGraphics.DrawString(text, font, color, rectangle, (GLGraphics.TextQuality)quality);
        }

        /// <summary>
        /// Clears whole window with specified color
        /// </summary>
        /// <param name="color">Clearing color</param>
        public void Clear(Color color)
        {
            GLGraphics.Clear(color);
        }

        /// <summary>
        /// Clears whole window
        /// </summary>
        public void Clear()
        {
            GLGraphics.Clear();
        }

        /// <summary>
        /// Fills specified rectangle with specified color
        /// </summary>
        /// <param name="color">Fill color</param>
        /// <param name="rectangle">Filling rectangle</param>
        public void FillRectangle(Color color, Rectangle rectangle)
        {
            GLGraphics.FillRectangle(color, rectangle);
        }

        /// <summary>
        /// Rotates whole scene on specified angle with specified origin X and Y
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="originX"></param>
        /// <param name="originY"></param>
        public void Rotate(float angle, int originX, int originY)
        {
            GLGraphics.Rotate(angle, originX, originY);
        }

        /// <summary>
        /// Translates whole scene at specified position
        /// </summary>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        public void Translate(int x, int y)
        {
            GLGraphics.Translate(x, y);
        }

        /// <summary>
        /// Scales whole scene at specified factor
        /// </summary>
        /// <param name="scaleFactor">Scale factor</param>
        public void Scale(float scaleFactor)
        {
            Scale(scaleFactor, scaleFactor);
        }

        /// <summary>
        /// Scales whole scene at specified factors
        /// </summary>
        /// <param name="xFactor">Scale X factor</param>
        /// <param name="yFactor">Scale Y factor</param>
        public void Scale(float xFactor, float yFactor)
        {
            GLGraphics.Scale(xFactor, yFactor);
        }
    }

    /// <summary>
    /// String drawing quality
    /// </summary>
    public enum TextQuality
    {
        /// <summary>
        /// High quality
        /// </summary>
        High = GLGraphics.TextQuality.High,
        /// <summary>
        /// Medium quality
        /// </summary>
        Medium = GLGraphics.TextQuality.Medium,
        /// <summary>
        /// Low quality
        /// </summary>
        Low = GLGraphics.TextQuality.Low
    }
}
