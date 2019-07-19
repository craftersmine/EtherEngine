using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Represents game timings. This class cannot be inherited
    /// </summary>
    public sealed class Time
    {
        /// <summary>
        /// Gets delta time between updates
        /// </summary>
        public static float DeltaTime { get { if (Game.GameUpdater != null) return (float)Game.GameUpdater.UpdateTime.TotalSeconds; else return 0.0f; } }
        /// <summary>
        /// Gets delta time between fixed updates
        /// </summary>
        public static float FixedDeltaTime { get { if (Game.GameUpdater != null) return (float)Game.GameUpdater.FixedUpdateTime.TotalSeconds; else return 0.0f; } }
        /// <summary>
        /// Gets delta time between frames
        /// </summary>
        [Obsolete("WIP | Currently returns 0")]
        public static float RenderDeltaTime { get { return 0f; } }
    }
}
