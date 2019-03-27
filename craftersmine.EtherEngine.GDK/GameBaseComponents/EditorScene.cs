using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using craftersmine.EtherEngine.Content;
using craftersmine.EtherEngine.Core;
using craftersmine.EtherEngine.Input;

namespace craftersmine.EtherEngine.GDK.GameBaseComponents
{
    /// <summary>
    /// Represents game scene. This class cannot be inherited
    /// </summary>
    [Serializable]
    public class EditorScene
    {
        private Color _bgColor;

        public List<EditorGameObject> GameObjects = new List<EditorGameObject>();
        public List<EditorUIWidget> UIWidgets = new List<EditorUIWidget>();

        [XmlIgnore]
        public Dictionary<string, AudioChannel> AudioChannels = new Dictionary<string, AudioChannel>();

        /// <summary>
        /// Gets or sets <see cref="Scene"/> background color
        /// </summary>
        public Color BackgroundColor { get { return _bgColor; } set { _bgColor = value; } }
        /// <summary>
        /// Gets or sets <see cref="Scene"/> camera
        /// </summary>
        [XmlIgnore]
        public Camera SceneCamera { get; private set; }

        /// <summary>
        /// Creates new <see cref="Scene"/> instance
        /// </summary>
        public EditorScene()
        {

        }

        /// <summary>
        /// Calls when scene is being updated
        /// </summary>
        public virtual void OnUpdate()
        {

        }

        /// <summary>
        /// Calls when scene is being created
        /// </summary>
        public virtual void OnStart()
        {

        }

        /// <summary>
        /// Calls when scene is being unloaded
        /// </summary>
        public virtual void OnUnload()
        { }

        /// <summary>
        /// Adds <see cref="GameObject"/> to scene
        /// </summary>
        /// <param name="gameObject">Addable object</param>
        public void AddGameObject(EditorGameObject gameObject)
        {
            gameObject.InternalCreate();
            GameObjects.Add(gameObject);
        }

        /// <summary>
        /// Adds range of <see cref="GameObject"/> to scene
        /// </summary>
        /// <param name="gameObjects">Addable objects collection</param>
        public void AddGameObjects(IEnumerable<EditorGameObject> gameObjects)
        {
            foreach (var obj in gameObjects)
            {
                AddGameObject(obj);
            }
        }

        /// <summary>
        /// Removes <see cref="GameObject"/> from scene
        /// </summary>
        /// <param name="gameObject">Removable object</param>
        public void RemoveGameObject(EditorGameObject gameObject)
        {
            if (GameObjects.Contains(gameObject))
            {
                GameObjects.Remove(gameObject);
            }
        }

        public bool CreateAudioChannel(string id, AudioClip audioClip)
        {
            if (!AudioChannels.ContainsKey(id))
            {
                AudioChannels.Add(id, new AudioChannel(audioClip));
                return true;
            }
            else return false;
        }

        public void RemoveAudioChannel(string id)
        {
            if (AudioChannels.ContainsKey(id))
            {
                AudioChannels[id].Stop();
                AudioChannels.Remove(id);
            }
        }

        public AudioChannel GetAudioChannel(string id)
        {
            if (AudioChannels.ContainsKey(id))
                return AudioChannels[id];
            else return null;
        }

        public void AddUIWidget(EditorUIWidget widget)
        {
            UIWidgets.Add(widget);
        }

        public void RemoveUIWidget(EditorUIWidget widget)
        {
            UIWidgets.Remove(widget);
        }

        public void InternalCreate()
        {
            SceneCamera = new Camera(StaticData.RenderFrame.Width, StaticData.RenderFrame.Height);
            SceneCamera.PlaceCamera(0, 0);
            OnStart();
        }

        public void InternalUpdate()
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
            OnUpdate();
        }
    }
}
