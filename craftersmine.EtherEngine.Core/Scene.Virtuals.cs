using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Core
{
    public partial class Scene
    {
        /// <summary>
        /// Calls when scene is being updated
        /// </summary>
        public virtual void OnUpdate(float deltaTime)
        {

        }

        /// <summary>
        /// Calls when scene is being created
        /// </summary>
        public virtual void OnStart()
        {

        }

        /// <summary>
        /// Calls when scene is being unloaded
        /// </summary>
        public virtual void OnUnload()
        { }
    }
}
