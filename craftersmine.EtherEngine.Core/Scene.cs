using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Core
{
    public class Scene
    {
        private Color _bgColor;

        internal List<GameObject> GameObjects = new List<GameObject>();

        public Color BackgroundColor { get { return _bgColor; } set { _bgColor = value;
                if (Game.GameWnd != null)
                    Game.GameWnd.GLGDI.ClearColor = _bgColor; } }
        public Camera SceneCamera { get; private set; }

        public Scene()
        {

        }

        public virtual void OnUpdate()
        {

        }

        public virtual void OnStart()
        {

        }

        public virtual void OnUnload()
        { }

        public void AddGameObject(GameObject gameObject)
        {
            gameObject.InternalCreate();
            GameObjects.Add(gameObject);
        }

        public void AddGameObjects(IEnumerable<GameObject> gameObjects)
        {
            foreach (var obj in gameObjects)
            {
                AddGameObject(obj);
            }
        }

        public void RemoveGameObject(GameObject gameObject)
        {
            if (GameObjects.Contains(gameObject))
            {
                GameObjects.Remove(gameObject);
            }
        }

        internal void InternalCreate()
        {
            SceneCamera = new Camera(Game.GameWnd.WindowSize.Width, Game.GameWnd.WindowSize.Height);
            SceneCamera.PlaceCamera(0, 0);
            OnStart();
        }

        internal void InternalUpdate()
        {
            OnUpdate();
        }
    }
}
