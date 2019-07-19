using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Represents a game object component collection
    /// </summary>
    public sealed class GameObjectComponentCollection : ICollection<IGameObjectComponent>
    {
        private List<IGameObjectComponent> gameObjectComponents = new List<IGameObjectComponent>();

        /// <summary>
        /// Gets count of game object components
        /// </summary>
        public int Count { get { return gameObjectComponents.Count; } }

        /// <summary>
        /// Gets true if collection is readonly, otherwise false
        /// </summary>
        public bool IsReadOnly { get { return false; } }

        /// <summary>
        /// Adds specified game object component into a collection
        /// </summary>
        /// <param name="item">Game object component</param>
        public void Add(IGameObjectComponent item)
        {
            gameObjectComponents.Add(item);
        }

        /// <summary>
        /// Clears whole game object component collection
        /// </summary>
        public void Clear()
        {
            gameObjectComponents.Clear();
        }

        /// <summary>
        /// Returns true if game object component contains in this collection, otherwise false
        /// </summary>
        /// <param name="item">Object to check</param>
        public bool Contains(IGameObjectComponent item)
        {
            if (gameObjectComponents.Contains(item))
                return true;
            return false;
        }

        /// <summary>
        /// Copies whole collection into specified array from specified start index
        /// </summary>
        /// <param name="array">Array to copy</param>
        /// <param name="arrayIndex">Start index</param>
        public void CopyTo(IGameObjectComponent[] array, int arrayIndex)
        {
            gameObjectComponents.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Returns an enumerator that performs enumeration of collection elements
        /// </summary>
        /// <returns></returns>
        public IEnumerator<IGameObjectComponent> GetEnumerator()
        {
            return gameObjectComponents.GetEnumerator();
        }

        /// <summary>
        /// Performs search of specified object and returns index that counts from zero of first entry, found in bounds of whole collection
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(IGameObjectComponent item)
        {
            return gameObjectComponents.IndexOf(item);
        }

        /// <summary>
        /// Inserts a game object component into a collection at specified index
        /// </summary>
        /// <param name="index">Index to insert</param>
        /// <param name="item">Inserting object</param>
        public void Insert(int index, IGameObjectComponent item)
        {
            gameObjectComponents.Insert(index, item);
        }

        /// <summary>
        /// Removes specified game object component from collection
        /// </summary>
        /// <param name="item">Removing object</param>
        /// <returns></returns>
        public bool Remove(IGameObjectComponent item)
        {
            return gameObjectComponents.Remove(item);
        }

        /// <summary>
        /// Removes specified game object component from collection with specified index
        /// </summary>
        /// <param name="index">Removing object index</param>
        public void RemoveAt(int index)
        {
            gameObjectComponents.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return gameObjectComponents.GetEnumerator();
        }
    }
}
