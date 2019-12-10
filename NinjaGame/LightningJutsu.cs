using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaGame
{
    public class LightningJutsu: Jutsu
    {
        Random random;
        public LightningJutsu(Level level)
        {
            this.level = level;
            sprites = new List<BaseSprite>();

            random = new Random();
            int lightningBalls = random.Next(12, 24);

            int i = 0;
            while (i < lightningBalls)
            {
                int x = random.Next(0, 600);
                int y = random.Next(0, 500);
                GenericSprite sprite = (GenericSprite)SpriteFactory.Instance.GetSprite(SpriteTypes.Type.lightning);
                sprite.Position = new Vector2(x, y);
                sprites.Add(sprite);

                i++;
            }

            SoundManager.Instance.PlaySFX(SoundTypes.Type.lightning);


            void Destroy()
            {
                Remove(level);
            }
            DelayTimer.Create(3000, Destroy);
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 origin = new Vector2(level.origin.x, level.origin.y);
            foreach (BaseSprite sprite in sprites)
            {
                float scaledX = origin.X * 5;
                float Y = origin.Y / 2;

                float posX = sprite.Position.X;
                float posY = sprite.Position.Y;

                posX += (scaledX - posX) / 100 * random.Next(-2,2);
                posY += (Y - posY) / 100 * random.Next(-1, 1);

                sprite.Position = new Vector2(posX, posY);
            }
            base.Update(gameTime);
        }
    }
}
