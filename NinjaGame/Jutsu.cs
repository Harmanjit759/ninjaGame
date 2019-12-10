using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaGame
{
    public abstract class Jutsu
    {
        protected List<BaseSprite> sprites;

        protected Level level;
        protected Jutsu()
        {
            sprites = new List<BaseSprite>();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (BaseSprite sprite in sprites)
            {
                sprite.Draw(spriteBatch);
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach(BaseSprite sprite in sprites)
            {
                sprite.Update(gameTime);
            }
        }

        public void Remove(Level level)
        {
            level.Remove(this);
        }

    }
}
