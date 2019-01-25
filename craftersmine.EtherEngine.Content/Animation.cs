using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Content
{
    /// <summary>
    /// Represents animation. This class cannot be inherited
    /// </summary>
    public sealed class Animation
    {
        /// <summary>
        /// Gets an array of prepared animation frames
        /// </summary>
        public Texture[] AnimationFrames { get; private set; }
        /// <summary>
        /// Gets animation total frames count
        /// </summary>
        public int FramesCount { get; private set; }
        /// <summary>
        /// Gets animation per frame width
        /// </summary>
        public int FrameWidth { get; private set; }
        /// <summary>
        /// Gets count of ticks between frame change
        /// </summary>
        public int TicksPerFrame { get; private set; }

        /// <summary>
        /// Creates a new instance of <see cref="Animation"/>
        /// </summary>
        /// <param name="animationBaseTexture">Animation base texture</param>
        /// <param name="framesCount">Animation total frames count</param>
        /// <param name="frameWidth">Animation per frame width</param>
        /// <param name="ticksPerFrame">Count of ticks between frame change</param>
        public Animation(Texture animationBaseTexture, int framesCount, int frameWidth, int ticksPerFrame)
        {
            FramesCount = framesCount;
            FrameWidth = frameWidth;
            TicksPerFrame = ticksPerFrame;

            AnimationFrames = new Texture[FramesCount];

            for (int i = 0; i < FramesCount; i++)
            {
                Bitmap bmp = new Bitmap(FrameWidth, animationBaseTexture.Height);
                //frames.Add(new Bitmap(FrameWidth, animationBaseTexture.Height));
                var image = Graphics.FromImage(bmp);
                image.DrawImage(animationBaseTexture.BaseBitmap, new Rectangle(0, 0, FrameWidth, animationBaseTexture.Height), new Rectangle(i * FrameWidth, 0, FrameWidth, animationBaseTexture.Height), GraphicsUnit.Pixel);
                image.Dispose();

                AnimationFrames[i] = new Texture(bmp);
            }
        }
    }
}
