using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace MusicGame
{
    public class MusicPlayer
    {
        private WindowsMediaPlayer wmp;

        public MusicPlayer()
        {
            wmp = new WindowsMediaPlayer();
        }

        public void SetMusic(string uri)
        {
            if (wmp != null)
            {
                wmp.URL = uri;
            }
        }

        public void PlayMusic()
        {
            if (wmp.URL != null)
            {
                wmp.controls.play();
            }
        }

        public void StopMusic()
        {
            if (wmp.URL != null)
            {
                wmp.controls.stop();
            }
        }
    }
}
