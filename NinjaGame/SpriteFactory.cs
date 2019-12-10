using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NinjaGame;

namespace NinjaGame
{
    public class SpriteFactory
    {
        private static SpriteFactory instance = new SpriteFactory();

        public static SpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private SpriteFactory()
        {

        }

        private static ContentManager content;

        public static void Init(ContentManager gameContent)
        {
            content = gameContent;
        }
        public BaseSprite GetSprite(SpriteTypes.Type type)
        {
            switch (type)
            {

                case SpriteTypes.Type.Fireball:
                    {
                        Texture2D fireball = content.Load<Texture2D>("fireball");
                        return new GenericSprite(fireball, 50,5);
                    }
                case SpriteTypes.Type.waterShot:
                    {
                        Texture2D texture = content.Load<Texture2D>("waterShot");
                        return new GenericSprite(texture, 5, 3);
                    }
                case SpriteTypes.Type.waterShot2:
                    {
                        Texture2D texture = content.Load<Texture2D>("waterShot2");
                        return new GenericSprite(texture, 5, 10);
                    }
                case SpriteTypes.Type.waterShot3:
                    {
                        Texture2D texture = content.Load<Texture2D>("waterShot3");
                        return new GenericSprite(texture, 8, 2);
                    }
                case SpriteTypes.Type.waterShot4:
                    {
                        Texture2D texture = content.Load<Texture2D>("waterShot4");
                        return new GenericSprite(texture, 5, 10);
                    }
                case SpriteTypes.Type.waterShot5:
                    {
                        Texture2D texture = content.Load<Texture2D>("waterShot5");
                        return new GenericSprite(texture, 8, 7);
                    }
                case SpriteTypes.Type.magicMissile:
                    {
                        Texture2D texture = content.Load<Texture2D>("1_magicspell_spritesheet");
                        return new GenericSprite2(texture,74,3,9,9);
                    }
                case SpriteTypes.Type.magic8Spell:
                    {
                        Texture2D texture = content.Load<Texture2D>("2_magic8_spritesheet");
                        return new GenericSprite2(texture, 61, 3, 8, 8);
                    }
                case SpriteTypes.Type.bluefire:
                    {
                        Texture2D texture = content.Load<Texture2D>("3_bluefire_spritesheet");
                        return new GenericSprite2(texture, 61, 3, 8, 8);
                    }
                case SpriteTypes.Type.castingSpell:
                    {
                        Texture2D texture = content.Load<Texture2D>("4_casting_spritesheet");
                        return new GenericSprite2(texture, 72, 3, 9, 9);
                    }
                case SpriteTypes.Type.magicHitSpell:
                    {
                        Texture2D texture = content.Load<Texture2D>("5_magickahit_spritesheet");
                        return new GenericSprite2(texture, 42, 3, 6, 7);
                    }
                case SpriteTypes.Type.flamelash:
                    {
                        Texture2D texture = content.Load<Texture2D>("6_flamelash_spritesheet");
                        return new GenericSprite2(texture, 49, 3, 7, 7);
                    }
                case SpriteTypes.Type.firespin:
                    {
                        Texture2D texture = content.Load<Texture2D>("7_firespin_spritesheet");
                        return new GenericSprite2(texture, 61, 3, 8, 8);
                    }
                case SpriteTypes.Type.protectionCircle:
                    {
                        Texture2D texture = content.Load<Texture2D>("8_protectioncircle_spritesheet");
                        return new GenericSprite2(texture, 61, 3, 8, 8);
                    }
                case SpriteTypes.Type.brightFire:
                    {
                        Texture2D texture = content.Load<Texture2D>("9_brightfire_spritesheet");
                        return new GenericSprite2(texture, 61, 3, 8, 8);
                    }
                case SpriteTypes.Type.weaponHit:
                    {
                        Texture2D texture = content.Load<Texture2D>("10_weaponhit_spritesheet");
                        return new GenericSprite2(texture, 31, 3, 6, 6);
                    }
                case SpriteTypes.Type.fire:
                    {
                        Texture2D texture = content.Load<Texture2D>("11_fire_spritesheet");
                        return new GenericSprite2(texture, 61, 3, 8, 8);
                    }
                case SpriteTypes.Type.nebula:
                    {
                        Texture2D texture = content.Load<Texture2D>("12_nebula_spritesheet");
                        return new GenericSprite2(texture, 61, 3, 8, 8);
                    }
                case SpriteTypes.Type.vortex:
                    {
                        Texture2D texture = content.Load<Texture2D>("13_vortex_spritesheet");
                        return new GenericSprite2(texture, 61, 3, 8, 8);
                    }
                case SpriteTypes.Type.phantom:
                    {
                        Texture2D texture = content.Load<Texture2D>("14_phantom_spritesheet");
                        return new GenericSprite2(texture, 61, 3, 8, 8);
                    }
                case SpriteTypes.Type.loading:
                    {
                        Texture2D texture = content.Load<Texture2D>("15_loading_spritesheet");
                        return new GenericSprite2(texture, 61, 3, 11, 11);
                    }
                case SpriteTypes.Type.sunburn:
                    {
                        Texture2D texture = content.Load<Texture2D>("16_sunburn_spritesheet");
                        return new GenericSprite2(texture, 61, 3, 8, 8);
                    }
                case SpriteTypes.Type.felspell:
                    {
                        Texture2D texture = content.Load<Texture2D>("17_felspell_spritesheet");
                        return new GenericSprite2(texture, 90, 3, 10, 10);
                    }
                case SpriteTypes.Type.midnight:
                    {
                        Texture2D texture = content.Load<Texture2D>("18_midnight_spritesheet");
                        return new GenericSprite2(texture, 61, 3, 8, 8);
                    }
                case SpriteTypes.Type.freezingSpirit:
                    {
                        Texture2D texture = content.Load<Texture2D>("19_freezing_spritesheet");
                        return new GenericSprite2(texture, 85, 3, 10, 10);
                    }
                case SpriteTypes.Type.magicBubbles:
                    {
                        Texture2D texture = content.Load<Texture2D>("20_magicbubbles_spritesheet");
                        return new GenericSprite2(texture, 61, 3, 8, 8);
                    }
                case SpriteTypes.Type.lightning:
                    {
                        Texture2D texture = content.Load<Texture2D>("lightning");
                        return new GenericSprite(texture, 5, 3);
                    }
                case SpriteTypes.Type.growingMagic8:
                    {
                        Texture2D texture = content.Load<Texture2D>("2_magic8_spritesheet");
                        return new GrowingSprite2(texture, 61,.001f, 3, 8, 8);
                    }
                case SpriteTypes.Type.growingWaterShot:
                    {
                        Texture2D texture = content.Load<Texture2D>("waterShot");
                        return new GrowingSprite(texture, 5,-.001f, 5);
                    }

                default:
                    {
                        throw new System.ArgumentException("enum machine broke");
                    }
            }
        }
    }
}
