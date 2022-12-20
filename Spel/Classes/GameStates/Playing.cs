using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Spel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Spel.Classes.GameStates
{
    internal class Playing : GameState
    {
        private KeyboardReader KBReader; 
        private Texture2D _heroTexture;
        Hero hero;

        public Playing(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            KBReader = new KeyboardReader();

            _heroTexture = _content.Load<Texture2D>("sprite");
            hero = new Hero(_heroTexture, KBReader);
        }
        
        public override void Update(GameTime gameTime)
        {
            hero.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            hero.Draw(spriteBatch);
        }
    }
}
