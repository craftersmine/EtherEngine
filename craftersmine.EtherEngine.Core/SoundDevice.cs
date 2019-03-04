using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Utilities;
using NVorbis.OpenTKSupport;
using OpenTK.Audio;

namespace craftersmine.EtherEngine.Core
{
    public sealed class SoundDevice
    {
        public AudioContext Context { get; private set; }
        internal OggStreamer OggStreamer { get; set; }

        public SoundDevice(string audioDevice)
        {
            Debugging.Log(LogEntryType.Info, "Using \"" + audioDevice + "\" audio device");
            Context = new AudioContext(audioDevice);
            Debugging.Log(LogEntryType.Info, "Current audio context is " + Context.ToString());
            Debugging.Log(LogEntryType.Info, "Constructing audio streaming instance...");
            OggStreamer = new OggStreamer();
            Initialize();
        }

        public SoundDevice()
        {
            Debugging.Log(LogEntryType.Info, "Using \"" + AudioContext.DefaultDevice + "\" audio device");
            Context = new AudioContext(AudioContext.DefaultDevice);
            Debugging.Log(LogEntryType.Info, "Current audio context is " + Context.ToString());
            Debugging.Log(LogEntryType.Info, "Constructing audio streaming instance...");
            OggStreamer = new OggStreamer();
            Initialize();
        }

        public void Initialize()
        {
            Context.MakeCurrent();
        }
    }
}
