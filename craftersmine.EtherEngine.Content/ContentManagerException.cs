using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Content
{
    /// <summary>
    /// Throws when <see cref="ContentManager"/> catches an error while operating content package
    /// </summary>
    [Serializable]
    public class ContentManagerException : Exception
    {
        /// <summary>
        /// Throws when <see cref="ContentManager"/> catches an error while operating content package
        /// </summary>
        public ContentManagerException() { }
        /// <summary>
        /// Throws when <see cref="ContentManager"/> catches an error while operating content package
        /// </summary>
        public ContentManagerException(string message) : base(message) { }
        /// <summary>
        /// Throws when <see cref="ContentManager"/> catches an error while operating content package
        /// </summary>
        public ContentManagerException(string message, Exception inner) : base(message, inner) { }
        /// <summary>
        /// Throws when <see cref="ContentManager"/> catches an error while operating content package
        /// </summary>
        protected ContentManagerException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
