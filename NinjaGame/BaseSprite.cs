using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaGame
{
    public abstract class BaseSprite
    {
        protected static Vector2 DefaultScale = new Vector2(1);

        protected Texture2D Texture;
        protected int TotalNumberOfFrames;
        protected int CurrentFrame;
        protected int UpdatesPerFrame;
        protected int CurrentUpdate;
        private Vector2 position;
        public Vector2 Position { get => position; set => position = value; }

        protected BaseSprite(Texture2D texture, int totalNumberOfFrames = 1, int updatesPerFrame = 15)
        {
            Texture = texture;
            TotalNumberOfFrames = totalNumberOfFrames;
            CurrentFrame = 0;
            UpdatesPerFrame = updatesPerFrame;
            Position = new Vector2(200f, 200f);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, Position, DefaultScale, SpriteEffects.None);
        }

        public virtual void DrawScaled(SpriteBatch spriteBatch, Vector2 scale)
        {
            Draw(spriteBatch, Position, scale, SpriteEffects.None);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Draw(spriteBatch, position, DefaultScale, SpriteEffects.None);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects effects)
        {
            Draw(spriteBatch, position, DefaultScale, effects);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position, Vector2 scale)
        {
            int width = Texture.Width / TotalNumberOfFrames;
            int height = Texture.Height;

            Rectangle source = new Rectangle(width * CurrentFrame, 0, width, height);

            position.Y = Game1.Height - position.Y - (height * scale.Y);

            spriteBatch.Draw(Texture, position, source, Color.White, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position, Vector2 scale, SpriteEffects effects)
        {
            int width = Texture.Width / TotalNumberOfFrames;
            int height = Texture.Height;

            Rectangle dest = new Rectangle((int)position.X * 2, (int)position.Y * 2, width * 2, height * 2);
            Rectangle source = new Rectangle(width * CurrentFrame, 0, width, height);

            dest.Y = (int)(Game1.Height - (position.Y * 2) - (height * 2));

            spriteBatch.Draw(Texture, dest, source, Color.White, 0f, Vector2.Zero, effects, 0);
        }

        public virtual void Update(GameTime gameTime)
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
