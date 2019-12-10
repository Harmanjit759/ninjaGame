using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NinjaGame
{
    public class GenericSprite2 : BaseSprite
    {
        protected int rows;
        protected int columns;
        public GenericSprite2(Texture2D texture, int totalNumberOfFrames = 1, int updatesPerFrame = 15,int rows = 9, int columns = 9) : base(texture, totalNumberOfFrames, updatesPerFrame)
        {
            Texture = texture;
            TotalNumberOfFrames = totalNumberOfFrames;
            CurrentFrame = 0;
            UpdatesPerFrame = updatesPerFrame;
            Position = new Vector2(200f, 200f);
            this.rows = rows;
            this.columns = columns;
 
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Vector2 scale, SpriteEffects effects)
        {
            int width = Texture.Width / columns;
            int height = Texture.Height / rows;

            int row = (int)((float)CurrentFrame / (float)columns);
            int column = CurrentFrame % columns;

            Rectangle source = new Rectangle(width * column, height * row, width, height);
            Rectangle dest = new Rectangle((int)position.X, (int)position.Y, (int) (width * scale.X), (int) (height * scale.Y));

            spriteBatch.Draw(Texture, dest, source, Color.White, 0f, Vector2.Zero, effects, 0);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Vector2 scale)
        {
            Draw(spriteBatch, position, scale, SpriteEffects.None);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Draw(spriteBatch, position, DefaultScale,SpriteEffects.None);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects effects)
        {
            Draw(spriteBatch, position,DefaultScale,effects);
        }

        public override void Update(GameTime gameTime)
        {
            CurrentUpdate++;
            if (CurrentUpdate == UpdatesPerFrame)
            {
                CurrentUpdate = 0;

                CurrentFrame++;
                if (CurrentFrame == TotalNumberOfFrames)
                    CurrentFrame = 0;
            }
         
        }
    }
}
