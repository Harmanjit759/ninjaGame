using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaGame
{
    public class FreezingJutsu: Jutsu
    {
        public FreezingJutsu(Level level)
        {
            this.level = level;
            sprites = new List<BaseSprite>();

            BaseSprite freezing1 = SpriteFactory.Instance.GetSprite(SpriteTypes.Type.freezingSpirit);
            BaseSprite freezing2 = SpriteFactory.Instance.GetSprite(SpriteTypes.Type.freezingSpirit);
            BaseSprite freezing3 = SpriteFactory.Instance.GetSprite(SpriteTypes.Type.freezingSpirit);
            BaseSprite freezing4 = SpriteFactory.Instance.GetSprite(SpriteTypes.Type.freezingSpirit);
            BaseSprite freezing5 = SpriteFactory.Instance.GetSprite(SpriteTypes.Type.freezingSpirit);
            BaseSprite freezing6 = SpriteFactory.Instance.GetSprite(SpriteTypes.Type.freezingSpirit);
            BaseSprite freezing7 = SpriteFactory.Instance.GetSprite(SpriteTypes.Type.freezingSpirit);
            BaseSprite freezing8 = SpriteFactory.Instance.GetSprite(SpriteTypes.Type.freezingSpirit);

            freezing1.Position = new Vector2(0f, 0f);
            freezing2.Position = new Vector2(700f, 0f);
            freezing3.Position = new Vector2(0f, 500f);
            freezing4.Position = new Vector2(700f, 500f);
            freezing5.Position = new Vector2(400f, 0f);
            freezing6.Position = new Vector2(400f, 500f);
            freezing7.Position = new Vector2(0f, 300f);
            freezing8.Position = new Vector2(700f, 300f);

            sprites.Add(freezing1);
            sprites.Add(freezing2);
            sprites.Add(freezing3);
            sprites.Add(freezing4);
            sprites.Add(freezing5);
            sprites.Add(freezing6);
            sprites.Add(freezing7);
            sprites.Add(freezing8);

            SoundManager.Instance.PlaySFX(SoundTypes.Type.freezing);


            void Destroy()
            {
                Remove(level);
            }
            DelayTimer.Create(10000, Destroy);
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 center = new Vector2(400f,300f);
            Vector2 origin = new Vector2(level.origin.x, level.origin.y);
            foreach (BaseSprite sprite in sprites)
            {

                float posX = sprite.Position.X;
                float posY = sprite.Position.Y;

                posX += (center.X - posX) / 300 + (origin.X*5-posX)/600;
                posY += (center.Y - posY) / 300 + (origin.Y-posY)/600;

                sprite.Position = new Vector2(posX, posY);
            }
            base.Update(gameTime);
        }
    }
}
