using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NVorbis.OpenTKSupport;

namespace craftersmine.EtherEngine.Content
{
    /// <summary>
    /// Represents game audio clip. This class cannot be inherited
    /// </summary>
    public sealed class AudioClip
    {
        private OggStream oggStream;

        /// <summary>
        /// Gets or sets true if audio clip is looped, else false
        /// </summary>
        public bool IsLooped { get { return oggStream.IsLooped; } set { oggStream.IsLooped = value; } }

        /// <summary>
        /// Gets or sets volume level of audio clip
        /// </summary>
        public float Volume { get { return oggStream.Volume; } set { oggStream.Volume = value; } }

        /// <summary>
        /// Creates new <see cref="AudioClip"/> instance from specified <see cref="OggStream"/>
        /// </summary>
        /// <param name="oggStream">Ogg stream</param>
        public AudioClip(OggStream oggStream)
        {
            this.oggStream = oggStream;
            this.oggStream.Prepare();
        }

        /// <summary>
        /// Plays audio clip
        /// </summary>
        public void Play()
        {
            if (oggStream.Ready)
                oggStream.Play();
        }

        /// <summary>
        /// Pauses playing audio clip
        /// </summary>
        public void Pause()
        {
            oggStream.Pause();
        }

        /// <summary>
        /// Stops playing audio clip
        /// </summary>
        public void Stop()
        {
            oggStream.Stop();
        }

        /// <summary>
        /// Resumes paused audio clip
        /// </summary>
        public void Resume()
        {
            oggStream.Resume();
        }

        /// <summary>
        /// Loads <see cref="AudioClip"/> from file
        /// </summary>
        /// <param name="filename">Full path to file</param>
        /// <returns></returns>
        public static AudioClip FromFile(string filename)
        {
            return new AudioClip(new OggStream(filename));
        }

        /// <summary>
        /// Loads <see cref="AudioClip"/> from stream
        /// </summary>
        /// <param name="stream">Stream of audio clip</param>
        /// <returns></returns>
        public static AudioClip FromStream(Stream stream)
        {
            return new AudioClip(new OggStream(stream));
        }
    }
}
