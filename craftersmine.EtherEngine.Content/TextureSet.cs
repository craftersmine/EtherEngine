using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Content
{
    /// <summary>
    /// Represents texture set. This class cannot be inherited
    /// </summary>
    public sealed class TextureSet
    {
        private Dictionary<string, Texture> _textures = new Dictionary<string, Texture>();

        /// <summary>
        /// Creates new <see cref="TextureSet"/> instance
        /// </summary>
        public TextureSet()
        {

        }

        /// <summary>
        /// Tries to add texture in set and returns true if success, otherwise false
        /// </summary>
        /// <param name="id">Texture id</param>
        /// <param name="texture">Texture</param>
        /// <returns></returns>
        public bool AddTexture(string id, Texture texture)
        {
            if (!_textures.ContainsKey(id))
            {
                _textures.Add(id, texture);
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Tries to remove texture from set and returns true if success, otherwise false
        /// </summary>
        /// <param name="id">Id of removing texture</param>
        /// <returns></returns>
        public bool RemoveTexture(string id)
        {
            if (_textures.ContainsKey(id))
            {
                _textures.Remove(id);
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Tries to existing texture in set with another one and returns true if success, otherwise false
        /// </summary>
        /// <param name="id">Replacing texture id</param>
        /// <param name="newTexture">New texture</param>
        /// <returns></returns>
        public bool ChangeTexture(string id, Texture newTexture)
        {
            if (_textures.ContainsKey(id))
            {
                _textures[id] = newTexture;
                return true;
            }
            else return false;
        }
    }
}
