using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Content;

namespace craftersmine.EtherEngine.Core
{
    public partial class Scene
    {
        internal Dictionary<string, AudioChannel> AudioChannels = new Dictionary<string, AudioChannel>();

        public bool CreateAudioChannel(string id, AudioClip audioClip)
        {
            if (!AudioChannels.ContainsKey(id))
            {
                AudioChannels.Add(id, new AudioChannel(audioClip));
                return true;
            }
            else return false;
        }

        public void RemoveAudioChannel(string id)
        {
            if (AudioChannels.ContainsKey(id))
            {
                AudioChannels[id].Stop();
                AudioChannels.Remove(id);
            }
        }

        public AudioChannel GetAudioChannel(string id)
        {
            if (AudioChannels.ContainsKey(id))
                return AudioChannels[id];
            else return null;
        }
    }
}
