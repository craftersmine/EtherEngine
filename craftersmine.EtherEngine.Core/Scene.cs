using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Content;
using craftersmine.EtherEngine.Input;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Represents game scene. This class cannot be inherited
    /// </summary>
    public partial class Scene
    {
        private Color _bgColor;

        /// <summary>
        /// Gets or sets <see cref="Scene"/> background color
        /// </summary>
        public Color BackgroundColor { get { return _bgColor; } set { _bgColor = value;
                if (Game.GameWnd != null)
                    Game.GameWnd.GLGDI.ClearColor = _bgColor; } }
        /// <summary>
        /// Gets or sets <see cref="Scene"/> camera
        /// </summary>
        public Camera SceneCamera { get; private set; }

        /// <summary>
        /// Creates new <see cref="Scene"/> instance
        /// </summary>
        public Scene()
        {

        }

        internal void InternalCreate()
        {
            SceneCamera = new Camera(Game.GameWnd.WindowSize.Width, Game.GameWnd.WindowSize.Height);
            SceneCamera.PlaceCamera(0, 0);
            OnStart();
        }

        internal void InternalUpdate(TimeSpan deltaTime)
        {
            if (Mouse.LeftButton || Mouse.MiddleButton || Mouse.RightButton)
            {
                for (int i = 0; i < UIWidgets.Count; i++)
                {
                    if (UIWidgets[i].Transform.CheckPointInBounds(Mouse.X, Mouse.Y))
                        UIWidgets[i].OnMouseDown(Mouse.X, Mouse.Y, Mouse.LeftButton, Mouse.MiddleButton, Mouse.RightButton);
                }

                for (int i = 0; i < GameObjects.Count; i++)
                {
                    if (GameObjects[i].Transform.CheckPointInBounds(Mouse.X, Mouse.Y))
                        GameObjects[i].OnMouseDown(Mouse.X, Mouse.Y, Mouse.LeftButton, Mouse.MiddleButton, Mouse.RightButton);
                }
            }
            OnUpdate((float)deltaTime.TotalSeconds * 1000.0f);
        }
    }
}
