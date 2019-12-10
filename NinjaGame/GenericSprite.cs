using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NinjaGame
{
    public class GenericSprite : BaseSprite
    {
        public GenericSprite(Texture2D texture, int totalNumberOfFrames = 1, int updatesPerFrame = 15) : base(texture, totalNumberOfFrames, updatesPerFrame)
        {
            Texture = texture;
            TotalNumberOfFrames = totalNumberOfFrames;
            CurrentFrame = 0;
            UpdatesPerFrame = updatesPerFrame;
            Position = new Vector2(200f, 200f);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Vector2 scale, SpriteEffects effects)
        {
            int width = Texture.Width / TotalNumberOfFrames;
            int height = Texture.Height;

            Rectangle source = new Rectangle(width * CurrentFrame, 0, width, height);
            Rectangle dest = new Rectangle((int)position.X, (int)position.Y, (int)(width * scale.X), (int)(height * scale.Y));

            spriteBatch.Draw(Texture, dest, source, Color.White, 0f, Vector2.Zero, effects, 0);
        }
    }
}
