using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Core
{
    public sealed class Transform
    {
        public int RendererX { get { return (int)X - SceneManager.CurrentScene.SceneCamera.CameraX; } }
        public int RendererY { get { return (int)Y + SceneManager.CurrentScene.SceneCamera.CameraY; } }

        public float X { get; set; }
        public float Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public int RotationOriginX { get; set; }
        public int RotationOriginY { get; set; }
        public float RotationAngle { get; set; }

        public void Rotate(float angle)
        {
            RotationAngle += angle;
            if (RotationAngle >= 360.0f)
                RotationAngle = RotationAngle - 360.0f;
        }

        public void ResetRotationOrigin()
        {
            RotationOriginX = Width / 2 + RendererX;
            RotationOriginY = Height / 2 + RendererY;
        }
    }
}
