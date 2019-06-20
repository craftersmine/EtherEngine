using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Core.Exceptions
{
    [Serializable]
    public class GameWindowException : Exception
    {
        public GameWindowException() { }
        public GameWindowException(string message) : base(message) { }
        public GameWindowException(string message, Exception inner) : base(message, inner) { }
        protected GameWindowException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
