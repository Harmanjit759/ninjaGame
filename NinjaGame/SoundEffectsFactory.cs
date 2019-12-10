using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaGame
{
    public class SoundEffectsFactory
    {
        private static SoundEffectsFactory instance = new SoundEffectsFactory();

        public static SoundEffectsFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private SoundEffectsFactory()
        {

        }

        private static ContentManager content;

        public static void Init(ContentManager gameContent)
        {
            content = gameContent;
        }

        public Song getSFX(SoundTypes.Type type)
        {
            switch (type)
            {
                case SoundTypes.Type.fireball:
                    {
                        Song effect = content.Load<Song>("Sounds/explode3");
                        return effect;
                    }
                case SoundTypes.Type.freezing:
                    {
                        Song effect = content.Load<Song>("Sounds/wind");
                        return effect;
                    }
                case SoundTypes.Type.lightning:
                    {
                        Song effect = content.Load<Song>("Sounds/zap14");
                        return effect;
                    }
                case SoundTypes.Type.dark:
                    {
                        Song effect = content.Load<Song>("Sounds/curse");
                        return effect;
                    }
                case SoundTypes.Type.felspell:
                    {
                        Song effect = content.Load<Song>("Sounds/pestilence");
                        return effect;
                    }

                default:
                    {
                        throw new System.ArgumentException("soundtype enum machine broke");
                    }

            }

        }
    }
}
