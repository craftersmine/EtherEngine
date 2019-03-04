using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Core.Exceptions
{
    /// <summary>
    /// The exception that is thrown when scene manager can't operate with scene
    /// </summary>
    [Serializable]
    public class SceneManagerException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SceneManagerException"/> class with its message string set to a system-supplied message.
        /// </summary>
        public SceneManagerException() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SceneManagerException"/> class with a specified error message.
        /// </summary>
        public SceneManagerException(string message) : base(message) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SceneManagerException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        public SceneManagerException(string message, Exception inner) : base(message, inner) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SceneManagerException"/> class with the specified serialization and context information.
        /// </summary>
        protected SceneManagerException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
