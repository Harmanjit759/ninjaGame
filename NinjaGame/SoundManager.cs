using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaGame
{
    public class SoundManager
    {
        private static SoundManager instance = new SoundManager();

        public static SoundManager Instance
        {
            get
            {
                return instance;
            }
        }

        private SoundManager()
        {

        }

        private static Boolean mute = false;
        private static Boolean pause = false;

        public static bool IsPaused { get => pause; set => pause = value; }

        public void PlayBGM(SoundTypes.Type type)
        {
            if (!mute)
            {
                //Song m = Sound.BGMFactory.Instance.getBGM(type);
                //MediaPlayer.Play(m);
                //MediaPlayer.IsRepeating = true;
            }
        }

        public void PlaySFX(SoundTypes.Type type, float volume = 1f)
        {
            if (!mute && !IsPaused)
            {
                Song s = SoundEffectsFactory.Instance.getSFX(type);
                MediaPlayer.Play(s);
                MediaPlayer.IsRepeating = false;
            }

        }

        public void MuteToggle()
        {
            mute = !mute;
            MediaPlayer.IsMuted = !MediaPlayer.IsMuted;

        }

        public void PauseToggle()
        {
            IsPaused = !IsPaused;
            if (IsPaused)
            {
                MediaPlayer.Pause();
            }
            else
            {
                MediaPlayer.Resume();
            }

        }
        public void Stop()
        {
            MediaPlayer.Stop();
        }

    }
}
