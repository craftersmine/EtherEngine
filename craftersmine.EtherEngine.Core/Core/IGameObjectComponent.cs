using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Represents basic game object component
    /// </summary>
    public interface IGameObjectComponent
    {
        bool IsCreated { get; }

        /// <summary>
        /// Gets parent game object that contains this component
        /// </summary>
        GameObject ParentGameObject { get; }

        /// <summary>
        /// Calls on component creation
        /// </summary>
        /// <param name="gameObject">Game object that initializes this component</param>
        void OnCreate(GameObject gameObject);

        /// <summary>
        /// Calls on component update
        /// </summary>
        void OnUpdate();

        /// <summary>
        /// Calls on component fixed update
        /// </summary>
        void OnFixedUpdate();
    }
}
