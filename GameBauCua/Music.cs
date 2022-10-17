using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace GameBauCua
{
    class Music
    {
        private WindowsMediaPlayer wmp = null;

        public void LinkFileMusic(string DuongDanFileNhac)
        {
            wmp.URL = DuongDanFileNhac;
        }

        public Music()
        {
            wmp = new WindowsMediaPlayer();
        }

        public void Play()
        {
            wmp.controls.play();
        }

        public void Stop()
        {
            wmp.controls.stop();
        }
        public void Pause()
        {
            wmp.controls.pause();
        }

        public void ChangeMusic(string DuongDanFileNhac)
        {
            wmp.URL = DuongDanFileNhac;
        }
    }
}
