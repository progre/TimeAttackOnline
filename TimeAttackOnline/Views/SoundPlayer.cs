using System.IO;
using WMPLib;
using System.Windows.Forms;

namespace Progressive.TimeAttackOnline.Views
{
    class SoundPlayer
    {
        private readonly string path = Application.StartupPath;
        private WindowsMediaPlayer wmp;

        public int Volume
        {
            set { wmp.settings.volume = value; }
        }

        public SoundPlayer()
        {

            wmp = new WindowsMediaPlayer();
        }

        public void Play(int count)
        {
            string fileName = path + '\\' + count + ".wav";
            if (!File.Exists(fileName))
            {
                fileName = path + '\\' + count + ".mp3";
                if (!File.Exists(fileName))
                {
                    return;
                }
            }
            wmp.URL = fileName;
            wmp.controls.play();
        }
    }
}
