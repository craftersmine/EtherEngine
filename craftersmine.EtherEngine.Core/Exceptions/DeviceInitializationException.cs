using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Exceptions
{
    /// <summary>
    /// The exception that is thrown when an attempt to intialize Direct3D device fails
    /// </summary>
    [Serializable]
    public class DeviceInitializationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceInitializationException"/> class with its message string set to a system-supplied message.
        /// </summary>
        public DeviceInitializationException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceInitializationException"/> class with a specified error message.
        /// </summary>
        /// <param name="message"></param>
        public DeviceInitializationException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceInitializationException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public DeviceInitializationException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceInitializationException"/> class with the specified serialization and context information.
        /// </summary>
        /// <param name="info">An object that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">An object that contains contextual information about the source or destination.</param>
        protected DeviceInitializationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
