using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaGame
{
    public class PoisonJutsu:Jutsu
    {
        Random random;
        public PoisonJutsu(Level level)
        {
            this.level = level;
            sprites = new List<BaseSprite>();

            this.random = new Random();
            int p = random.Next(10, 15);

            int i = 0;
            while (i < p)
            {
                int x = random.Next(0, 750);
                int y = random.Next(0, 550);
                BaseSprite sprite = SpriteFactory.Instance.GetSprite(SpriteTypes.Type.felspell);
                sprite.Position = new Vector2(x, y);
                sprites.Add(sprite);

                i++;
            }

            SoundManager.Instance.PlaySFX(SoundTypes.Type.felspell);


            void Destroy()
            {
                Remove(level);
            }
            DelayTimer.Create(12000, Destroy);
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 origin = new Vector2(level.origin.x, level.origin.y);
            foreach (BaseSprite sprite in sprites)
            {
                float posX = sprite.Position.X+random.Next(-2,3);
                float posY = sprite.Position.Y;

                sprite.Position = new Vector2(posX, posY);
            }
            base.Update(gameTime);
        }
    }
}
