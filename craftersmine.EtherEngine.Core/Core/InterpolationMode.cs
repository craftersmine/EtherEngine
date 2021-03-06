﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Direct2D1;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Interpolation modes
    /// </summary>
    public enum InterpolationMode
    {
        /// <summary>
        /// Linear interpolation
        /// </summary>
        Linear = BitmapInterpolationMode.Linear,
        /// <summary>
        /// Nearest interpolation
        /// </summary>
        NearestNeighbor = BitmapInterpolationMode.NearestNeighbor,
    }
}
