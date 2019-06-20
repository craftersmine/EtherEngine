using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Core
{
    public sealed class Color
    {
        internal Color4 Color4 { get; set; }

        public float R { get { return Color4.Red; } }
        public float G { get { return Color4.Green; } }
        public float B { get { return Color4.Blue; } }
        public float A { get { return Color4.Alpha; } }
        
        public Color(float r, float g, float b, float a)
        {
            Color4 = new Color4(r, g, b, a);
        }

        public Color(float r, float g, float b) : this(r, g, b, 1.0f) { }

        public Color(float grayscaleValue) : this(grayscaleValue, grayscaleValue, grayscaleValue) { }

        public Color(float grayscaleValue, float a) : this(grayscaleValue, grayscaleValue, grayscaleValue, a) { }

        public Color(int rgba)
        {
            Color4 = new Color4(rgba);
        }

        internal Color(Color4 color4) { Color4 = color4; }

        public static Color Add(Color color1, Color color2)
        {
            return new Color(Color4.Add(color1.Color4, color2.Color4));
        }

        public static Color Subtract(Color color1, Color color2)
        {
            return new Color(Color4.Subtract(color1.Color4, color1.Color4));
        }

        public static Color Clamp(Color color, Color min, Color max)
        {
            return new Color(Color4.Clamp(color.Color4, min.Color4, max.Color4));
        }

        public static Color Premultiply(Color color)
        {
            return new Color(Color4.Premultiply(color.Color4));
        }

        public static Color Modulate(Color color1, Color color2)
        {
            return new Color(Color4.Modulate(color1.Color4, color2.Color4));
        }

        public static Color Negate(Color color)
        {
            return new Color(Color4.Negate(color.Color4));
        }

        public static Color Min(Color color1, Color color2)
        {
            return new Color(Color4.Min(color1.Color4, color2.Color4));
        }

        public static Color Max(Color color1, Color color2)
        {
            return new Color(Color4.Max(color1.Color4, color2.Color4));
        }

        public static Color Lerp(Color color1, Color color2, float value)
        {
            return new Color(Color4.Lerp(color1.Color4, color2.Color4, value));
        }

        public static Color Scale(Color color, float value)
        {
            return new Color(Color4.Scale(color.Color4, value));
        }

        public static Color SmoothStep(Color color1, Color color2, float value)
        {
            return new Color(Color4.SmoothStep(color1.Color4, color2.Color4, value));
        }

        public static Color AdjustContrast(Color color, float contrast)
        {
            return new Color(Color4.AdjustContrast(color.Color4, contrast));
        }

        public static Color AdjustSaturation(Color color, float saturation)
        {
            return new Color(Color4.AdjustSaturation(color.Color4, saturation));
        }
    }
}
