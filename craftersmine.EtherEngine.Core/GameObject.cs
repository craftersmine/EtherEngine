using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Content;

namespace craftersmine.EtherEngine.Core
{
    public class GameObject
    {
        internal int RendererX { get { return (int)X - SceneManager.CurrentScene.SceneCamera.CameraX; } }
        internal int RendererY { get { return (int)Y + SceneManager.CurrentScene.SceneCamera.CameraY; } }

        public Texture Texture { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool IsVisibleByCamera { get; private set; }

        public virtual void OnStart()
        {

        }

        internal void InternalCreate()
        {
            OnStart();
        }

        public virtual void OnUpdate()
        { }

        internal void InternalUpdate()
        {
            OnUpdate();
        }
    }
}
