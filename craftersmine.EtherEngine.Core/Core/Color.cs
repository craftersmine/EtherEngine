using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Represents and RGB/RGBA color
    /// </summary>
    public struct Color
    {
        internal Color4 RawColor { get; set; }

        /// <summary>
        /// Gets a Red component of color
        /// </summary>
        public float R { get { return RawColor.Red; } }
        /// <summary>
        /// Gets a Green component of color
        /// </summary>
        public float G { get { return RawColor.Green; } }
        /// <summary>
        /// Gets a Blue component of color
        /// </summary>
        public float B { get { return RawColor.Blue; } }
        /// <summary>
        /// Gets a Alpha value of color
        /// </summary>
        public float A { get { return RawColor.Alpha; } }
        
        /// <summary>
        /// Creates a color from specified Red, Green, Blue and Alpha values
        /// </summary>
        /// <param name="r">Red component of color</param>
        /// <param name="g">Green component of color</param>
        /// <param name="b">Blue component of color</param>
        /// <param name="a">Alpha value of color</param>
        public Color(float r, float g, float b, float a)
        {
            RawColor = new Color4(r, g, b, a);
        }

        /// <summary>
        /// Creates a color from specified Red, Green and Blue values with Alpha value 1.0f (Opaque)
        /// </summary>
        /// <param name="r">Red component of color</param>
        /// <param name="g">Green component of color</param>
        /// <param name="b">Blue component of color</param>
        public Color(float r, float g, float b) : this(r, g, b, 1.0f) { }

        /// <summary>
        /// Creates a color from specified Grayscale value (Black to White) with Alpha value 1.0f (Opaque)
        /// </summary>
        /// <param name="grayscaleValue">Grayscale value</param>
        public Color(float grayscaleValue) : this(grayscaleValue, grayscaleValue, grayscaleValue) { }

        /// <summary>
        /// Creates a color from specified Grayscale value (Black to White) and Alpha value
        /// </summary>
        /// <param name="grayscaleValue">Grayscale value</param>
        /// <param name="a">Alpha value of color</param>
        public Color(float grayscaleValue, float a) : this(grayscaleValue, grayscaleValue, grayscaleValue, a) { }

        /// <summary>
        /// Creates a color from specified <see cref="Int32"/> value of RGBA color
        /// </summary>
        /// <param name="rgba"></param>
        public Color(int rgba)
        {
            RawColor = new Color4(rgba);
        }

        /// <summary>
        /// [INTERNAL] Creates color from specified DirectX color
        /// </summary>
        /// <param name="color4">Internal DirectX raw color instance</param>
        internal Color(Color4 color4) { RawColor = color4; }

        /// <summary>
        /// Adds two colors
        /// </summary>
        /// <param name="color1">Color 1</param>
        /// <param name="color2">Color 2</param>
        /// <returns></returns>
        public static Color Add(Color color1, Color color2)
        {
            return new Color(Color4.Add(color1.RawColor, color2.RawColor));
        }

        /// <summary>
        /// Subtracts two colors
        /// </summary>
        /// <param name="color1">Color 1</param>
        /// <param name="color2">Color 2</param>
        /// <returns></returns>
        public static Color Subtract(Color color1, Color color2)
        {
            return new Color(Color4.Subtract(color1.RawColor, color1.RawColor));
        }

        /// <summary>
        /// Restricts value to be within a specified range
        /// </summary>
        /// <param name="color">Color value</param>
        /// <param name="min">Minimal point of range</param>
        /// <param name="max">Maximal point of range</param>
        /// <returns></returns>
        public static Color Clamp(Color color, Color min, Color max)
        {
            return new Color(Color4.Clamp(color.RawColor, min.RawColor, max.RawColor));
        }

        /// <summary>
        /// Computes the premultiplied value of specified color
        /// </summary>
        /// <param name="color">Color value</param>
        /// <returns></returns>
        public static Color Premultiply(Color color)
        {
            return new Color(Color4.Premultiply(color.RawColor));
        }

        /// <summary>
        /// Modulates two colors
        /// </summary>
        /// <param name="color1">Color 1</param>
        /// <param name="color2">Color 2</param>
        /// <returns></returns>
        public static Color Modulate(Color color1, Color color2)
        {
            return new Color(Color4.Modulate(color1.RawColor, color2.RawColor));
        }

        /// <summary>
        /// Negates a color
        /// </summary>
        /// <param name="color">Color to negate</param>
        /// <returns></returns>
        public static Color Negate(Color color)
        {
            return new Color(Color4.Negate(color.RawColor));
        }

        /// <summary>
        /// Returns a color containing the smallest components of the specified colors
        /// </summary>
        /// <param name="color1">Color 1</param>
        /// <param name="color2">COlor 2</param>
        /// <returns></returns>
        public static Color Min(Color color1, Color color2)
        {
            return new Color(Color4.Min(color1.RawColor, color2.RawColor));
        }

        /// <summary>
        /// Returns a color containing the largest components of the specified colors
        /// </summary>
        /// <param name="color1">Color 1</param>
        /// <param name="color2">COlor 2</param>
        /// <returns></returns>
        public static Color Max(Color color1, Color color2)
        {
            return new Color(Color4.Max(color1.RawColor, color2.RawColor));
        }

        /// <summary>
        /// Performs a linear interpolation between two colors
        /// </summary>
        /// <param name="color1">Color 1</param>
        /// <param name="color2">Color 2</param>
        /// <param name="value">Value between interpolated colors</param>
        /// <returns></returns>
        public static Color Lerp(Color color1, Color color2, float value)
        {
            return new Color(Color4.Lerp(color1.RawColor, color2.RawColor, value));
        }

        /// <summary>
        /// Scales a color
        /// </summary>
        /// <param name="color">Color value</param>
        /// <param name="value">Scale factor</param>
        /// <returns></returns>
        public static Color Scale(Color color, float value)
        {
            return new Color(Color4.Scale(color.RawColor, value));
        }

        /// <summary>
        /// Performs a cubic interpolation between two colors
        /// </summary>
        /// <param name="color1">Color 1</param>
        /// <param name="color2">Color 2</param>
        /// <param name="value">Value between interpolated colors</param>
        /// <returns></returns>
        public static Color SmoothStep(Color color1, Color color2, float value)
        {
            return new Color(Color4.SmoothStep(color1.RawColor, color2.RawColor, value));
        }

        /// <summary>
        /// Adjusts the contrast of a color
        /// </summary>
        /// <param name="color">Color value</param>
        /// <param name="contrast">Contrast value</param>
        /// <returns></returns>
        public static Color AdjustContrast(Color color, float contrast)
        {
            return new Color(Color4.AdjustContrast(color.RawColor, contrast));
        }

        /// <summary>
        /// Adjusts the saturation of a color
        /// </summary>
        /// <param name="color">Color value</param>
        /// <param name="saturation">Saturation value</param>
        /// <returns></returns>
        public static Color AdjustSaturation(Color color, float saturation)
        {
            return new Color(Color4.AdjustSaturation(color.RawColor, saturation));
        }
    }
}
