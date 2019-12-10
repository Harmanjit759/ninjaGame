using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaGame
{
    public class FireJutsu: Jutsu
    {
        public FireJutsu(Level level)
        {
            this.level = level;
            sprites = new List<BaseSprite>();

            Random random = new Random();
            int fireballs = random.Next(1, 4);

            int i = 0;
            while (i < fireballs)
            {
                int x = random.Next(0, 600);
                int y = random.Next(0, 500);
                GenericSprite sprite = (GenericSprite)SpriteFactory.Instance.GetSprite(SpriteTypes.Type.Fireball);
                sprite.Position = new Vector2(x, y);
                sprites.Add(sprite);

                i++;
            }

            SoundManager.Instance.PlaySFX(SoundTypes.Type.fireball);


            void Destroy(){
                Remove(level);
            }
            DelayTimer.Create(6000, Destroy);
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 origin = new Vector2(level.origin.x, level.origin.y);
            foreach(BaseSprite sprite in sprites)
            {
                float scaledX = origin.X * 5;
                float Y = origin.Y/2;

                float posX = sprite.Position.X;
                float posY = sprite.Position.Y;

                posX += (scaledX - posX) / 100;
                posY += (Y - posY) / 100;

                sprite.Position = new Vector2(posX, posY);
            }
            base.Update(gameTime);
        }

    }
}
