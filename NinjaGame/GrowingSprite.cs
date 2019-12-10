using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NinjaGame
{
    public class GrowingSprite : GenericSprite
    {
        protected Vector2 currentScale;
        protected float growthFactor;
        public GrowingSprite(Texture2D texture, int totalNumberOfFrames, float growthFactor, int updatesPerFrame = 15) : base(texture, totalNumberOfFrames, updatesPerFrame)
        {
            Texture = texture;
            TotalNumberOfFrames = totalNumberOfFrames;
            Position = new Vector2(200f, 200f);
            CurrentFrame = 0;
            UpdatesPerFrame = updatesPerFrame;
            this.currentScale = Vector2.One;
            this.growthFactor = growthFactor;

        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Draw(spriteBatch, position, this.currentScale, SpriteEffects.None);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects effects)
        {
            Draw(spriteBatch, position, this.currentScale, effects);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            this.currentScale.X += growthFactor;
            this.currentScale.Y += growthFactor;
        }
    }
}
