using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;
using Spel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel.Classes.LevelDesign
{
    class Background : IGameObject
    {
        private Texture2D bgTexture;

        public Vector2 WindowSize { get; private set; } = new Vector2(1400, 787);

        public Background(Texture2D texture)
        {
            // Set the background texture that was given 
            bgTexture = texture;
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the background on the given spriteBatch
            spriteBatch.Draw(bgTexture, new Vector2(0, 0),
                 Color.White);
        }
    }
}
