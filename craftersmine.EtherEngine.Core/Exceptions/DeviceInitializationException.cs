using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Exceptions
{

    [Serializable]
    public class DeviceInitializationException : Exception
    {
        public DeviceInitializationException() { }
        public DeviceInitializationException(string message) : base(message) { }
        public DeviceInitializationException(string message, Exception inner) : base(message, inner) { }
        protected DeviceInitializationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
