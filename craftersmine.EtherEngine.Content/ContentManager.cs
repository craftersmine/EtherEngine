using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace craftersmine.EtherEngine.Content
{
    /// <summary>
    /// Represents a game content manager. This class cannot be inherited
    /// </summary>
    public sealed class ContentManager
    {
        private Dictionary<string, ContentObject> objects = new Dictionary<string, ContentObject>();

        /// <summary>
        /// Gest current content package path
        /// </summary>
        public string ContentPath { get; private set; }

        /// <summary>
        /// Creates a new instance of <see cref="ContentManager"/> and loads content package metadata
        /// </summary>
        /// <param name="contentPath">Content package metadata</param>
        public ContentManager(string contentPath)
        {
            ContentPath = contentPath.Replace('/', Path.DirectorySeparatorChar).Replace('.', Path.DirectorySeparatorChar);
            ContentPath = Path.Combine("content", ContentPath);
            try
            {
                string metadataPath = Path.Combine(ContentPath, "metadata.epm");
                string[] metadata = File.ReadAllLines(metadataPath);
                foreach (var metadataEntry in metadata)
                {
                    if (!string.IsNullOrEmpty(metadataEntry) || !string.IsNullOrWhiteSpace(metadataEntry))
                    {
                        string[] splittedEntry = metadataEntry.Split(new string[] { "::" }, StringSplitOptions.RemoveEmptyEntries);
                        ContentType type = (ContentType)int.Parse(splittedEntry[0]);
                        string id = splittedEntry[1];
                        string refObjId = "none";
                        if (splittedEntry.Length > 2)
                            if (!string.IsNullOrEmpty(splittedEntry[2]) || !string.IsNullOrWhiteSpace(splittedEntry[2]))
                                refObjId = splittedEntry[2];
                        ContentObject obj = new ContentObject(type, id, refObjId);
                        objects.Add(id, obj);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ContentManagerException("Error while loading \"" + ContentPath + "\" package! " + ex.Message);
            }
        }

        /// <summary>
        /// Returns true if <paramref name="objectId"/> is exists in package, else false
        /// </summary>
        /// <param name="objectId">Object ID to check</param>
        /// <returns></returns>
        public bool Contains(string objectId)
        {
            return objects.ContainsKey(objectId);
        }

        /// <summary>
        /// Loads texture from content package with specified ID
        /// </summary>
        /// <param name="id">Texture ID</param>
        /// <returns></returns>
        public Texture LoadTexture(string id)
        {
            if (Contains(id))
            {
                ContentObject cObj = objects[id];
                if (cObj.Type == ContentType.Texture)
                {
                    string path = Path.Combine(ContentPath, id + ".etx");
                    try
                    {
                        return Texture.FromFile(path);
                    }
                    catch (Exception ex)
                    {
                        throw new ContentManagerException("Unable to load object with this id \"" + id + "\" as texture! " + ex.Message);
                    }
                }
                else throw new ContentManagerException("Object with this id \"" + id + "\" is not a texture!");
            }
            else throw new ContentManagerException("Package does not contains object with this id \"" + id + "\"!");
        }

        /// <summary>
        /// Loads texture as texture atlas from content package with specified ID
        /// </summary>
        /// <param name="id">Texture ID</param>
        /// <returns></returns>
        public TextureAtlas LoadTextureAtlas(string id)
        {
            if (Contains(id))
            {
                ContentObject cObj = objects[id];
                if (cObj.Type == ContentType.TextureAtlas || cObj.Type == ContentType.TextureAtlas)
                {
                    string path = Path.Combine(ContentPath, id + ".etx");
                    try
                    {
                        return new TextureAtlas(Texture.FromFile(path));
                    }
                    catch (Exception ex)
                    {
                        throw new ContentManagerException("Unable to load object with this id \"" + id + "\" as texture atlas! " + ex.Message);
                    }
                }
                else throw new ContentManagerException("Object with this id \"" + id + "\" is not a texture or texture atlas!");
            }
            else throw new ContentManagerException("Package does not contains object with this id \"" + id + "\"!");
        }

        /// <summary>
        /// Loads animation data and animation texture from content package with specified ID
        /// </summary>
        /// <param name="id">Animation ID</param>
        /// <returns></returns>
        public Animation LoadAnimation(string id)
        {
            if (Contains(id))
            {
                ContentObject cObj = objects[id];
                if (cObj.Type == ContentType.Animation)
                {
                    string path = Path.Combine(ContentPath, id + ".eam");
                    if (cObj.HasReferencedObject)
                    {
                        try
                        {
                            Texture animationTex = LoadTexture(cObj.ReferencedObjectId);

                            int framesCount = 0;
                            int frameWidth = 0;
                            int ticksPerFrame = 0;

                            string[] animMetadata = File.ReadAllLines(path);

                            foreach (var metaLn in animMetadata)
                            {
                                string[] split = metaLn.Split('=');
                                switch (split[0])
                                {
                                    case "fcount":
                                        framesCount = int.Parse(split[1]);
                                        break;
                                    case "fwidth":
                                        frameWidth = int.Parse(split[1]);
                                        break;
                                    case "tpf":
                                        ticksPerFrame = int.Parse(split[1]);
                                        break;
                                }
                            }

                            return new Animation(animationTex, framesCount, frameWidth, ticksPerFrame);
                        }
                        catch (Exception ex)
                        {
                            throw new ContentManagerException("Unable to load object with this id \"" + id + "\" as animation! " + ex.Message);
                        }
                    }
                    else throw new ContentManagerException("Animation hasn't reference to texture!");
                }
                else throw new ContentManagerException("Object with this id \"" + id + "\" is not an animation!");
            }
            else throw new ContentManagerException("Package does not contains object with this id \"" + id + "\"!");
        }

        /// <summary>
        /// Loads audio clip from content package with specified ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AudioClip LoadAudioClip(string id)
        {
            if (Contains(id))
            {
                ContentObject cObj = objects[id];
                if (cObj.Type == ContentType.AudioClip)
                {
                    string path = Path.Combine(ContentPath, id + ".eac");
                    try
                    {
                        return AudioClip.FromFile(path);
                    }
                    catch (Exception ex)
                    {
                        throw new ContentManagerException("Unable to load object with this id \"" + id + "\" as audio clip! " + ex.Message);
                    }
                }
                else throw new ContentManagerException("Object with this id \"" + id + "\" is not an audio clip!");
            }
            else throw new ContentManagerException("Package does not contains object with this id \"" + id + "\"!");
        }
    }

    /// <summary>
    /// Represents content object metadata. This class cannot be inherited
    /// </summary>
    public sealed class ContentObject
    {
        /// <summary>
        /// Type of object
        /// </summary>
        public ContentType Type { get; private set; }
        /// <summary>
        /// Object ID
        /// </summary>
        public string Id { get; private set; }
        /// <summary>
        /// Referenced Object ID (e.g. texture for animation)
        /// </summary>
        public string ReferencedObjectId { get; private set; }
        /// <summary>
        /// Gets true if object has referenced object, otherwise false
        /// </summary>
        public bool HasReferencedObject { get; private set; }

        /// <summary>
        /// Creates a new instance of content object metadata
        /// </summary>
        /// <param name="type">Object type</param>
        /// <param name="id">Object ID</param>
        /// <param name="referencedObjectId">Referenced Object ID (none if object has not referenced object)</param>
        public ContentObject(ContentType type, string id, string referencedObjectId)
        {
            Type = type;
            Id = id;
            ReferencedObjectId = referencedObjectId;
            if (ReferencedObjectId == "none")
                HasReferencedObject = false;
            else HasReferencedObject = true;
        }
    }

    /// <summary>
    /// Enumerates possible types of objects
    /// </summary>
    public enum ContentType
    {
        /// <summary>
        /// Texture
        /// </summary>
        Texture = 100,
        /// <summary>
        /// Texture atlas
        /// </summary>
        TextureAtlas = 110,
        /// <summary>
        /// Animation
        /// </summary>
        Animation = 200,
        /// <summary>
        /// Audio clip
        /// </summary>
        AudioClip = 300
    }
}
