using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Core.Exceptions
{

    [Serializable]
    public class SceneManagerException : Exception
    {
        public SceneManagerException() { }
        public SceneManagerException(string message) : base(message) { }
        public SceneManagerException(string message, Exception inner) : base(message, inner) { }
        protected SceneManagerException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
