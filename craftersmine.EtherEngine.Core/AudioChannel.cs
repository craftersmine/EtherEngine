using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Content;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Represents scene audio channel. This class cannot be inherited
    /// </summary>
    public sealed class AudioChannel
    {
        /// <summary>
        /// Gets current audio clip used by this audio channel
        /// </summary>
        public AudioClip AudioClip { get; private set; }

        /// <summary>
        /// Creates new instance of <see cref="AudioChannel"/> with specified audio clip
        /// </summary>
        /// <param name="audioClip"></param>
        public AudioChannel(AudioClip audioClip)
        {
            AudioClip = audioClip;
        }

        /// <summary>
        /// Plays audio clip
        /// </summary>
        public void Play()
        {
            if (AudioClip.OggStream.Ready)
                AudioClip.OggStream.Play();
        }

        /// <summary>
        /// Pauses playing audio clip
        /// </summary>
        public void Pause()
        {
            AudioClip.OggStream.Pause();
        }

        /// <summary>
        /// Stops playing audio clip
        /// </summary>
        public void Stop()
        {
            AudioClip.OggStream.Stop();
        }

        /// <summary>
        /// Resumes paused audio clip
        /// </summary>
        public void Resume()
        {
            AudioClip.OggStream.Resume();
        }
    }
}
