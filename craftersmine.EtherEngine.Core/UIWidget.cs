using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Rendering;

namespace craftersmine.EtherEngine.Core
{
    public class UIWidget : GameObject
    {
        private int _frameCounter;
        private int _currentAnimationFrame;

        public UIWidget()
        { }

        public override void OnRender(GLGDI renderer)
        {
            byte objTransparencyCalculated = (byte)(255 * ObjectTransparency);

            if (IsAnimated)
            {
                if (Animation != null)
                {
                    if (_frameCounter == Animation.TicksPerFrame)
                    {
                        _frameCounter = 0;
                        _currentAnimationFrame++;
                        if (_currentAnimationFrame == Animation.FramesCount)
                            ResetAnimation();
                    }
                    renderer.DrawImage(Animation.AnimationFrames[_currentAnimationFrame].RenderableImage,
                                    (int)Transform.X,
                                    (int)Transform.Y,
                                    Width,
                                    Height,
                                    new GLGDIPlus.BlendingValues(BlendingColor.R, BlendingColor.G, BlendingColor.B, objTransparencyCalculated));
                    _frameCounter++;
                }
                else IsAnimated = false;
            }
            else
            {
                renderer.DrawImage(Texture.RenderableImage,
                                    (int)Transform.X,
                                    (int)Transform.Y,
                                    Width,
                                    Height,
                                    new GLGDIPlus.BlendingValues(BlendingColor.R, BlendingColor.G, BlendingColor.B, objTransparencyCalculated));
            }
        }
    }
}
