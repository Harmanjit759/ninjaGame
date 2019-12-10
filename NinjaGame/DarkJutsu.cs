using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaGame
{
    public class DarkJutsu: Jutsu
    {
        private Random random;
        public DarkJutsu(Level level)
        {
            this.level = level;
            sprites = new List<BaseSprite>();

            BaseSprite dark1 = SpriteFactory.Instance.GetSprite(SpriteTypes.Type.nebula);
            BaseSprite dark2 = SpriteFactory.Instance.GetSprite(SpriteTypes.Type.nebula);
            BaseSprite dark3 = SpriteFactory.Instance.GetSprite(SpriteTypes.Type.nebula);
            BaseSprite dark4 = SpriteFactory.Instance.GetSprite(SpriteTypes.Type.nebula);
            BaseSprite dark5 = SpriteFactory.Instance.GetSprite(SpriteTypes.Type.nebula);

            dark1.Position = new Vector2(300f, 300f);
            dark2.Position = new Vector2(500f, 300f);
            dark3.Position = new Vector2(400f, 400f);
            dark4.Position = new Vector2(400f, 500f);
            dark5.Position = new Vector2(400f, 300f);

            sprites.Add(dark1);
            sprites.Add(dark2);
            sprites.Add(dark3);
            sprites.Add(dark4);
            sprites.Add(dark5);

            this.random = new Random();

            SoundManager.Instance.PlaySFX(SoundTypes.Type.dark);


            void Destroy()
            {
                Remove(level);
            }
            DelayTimer.Create(12000, Destroy);
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 origin = new Vector2(level.indexOrigin.x, level.indexOrigin.y);
            foreach (BaseSprite sprite in sprites)
            {

                float scaledX = origin.X * 5;
                float Y = origin.Y / 2;

                float posX = sprite.Position.X;
                float posY = sprite.Position.Y;

                posX += (scaledX - posX) / 250 * (float) (1+random.NextDouble());
                posY += (Y - posY) / 250 * (float)(1 + random.NextDouble());

                sprite.Position = new Vector2(posX, posY);
            }
        }
    }
}
