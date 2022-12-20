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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace Spel.Classes.GameStates
{
    internal class Playing : GameState
    {
        // Variabelen initialiseren
        private Texture2D _backgroundTexture, _heroTexture;

        private Hero hero;
        private Background background;
        private KeyboardReader KBReader; 

        public Playing(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            KBReader = new KeyboardReader();

            _heroTexture = _content.Load<Texture2D>("sprite");
            _backgroundTexture = _content.Load<Texture2D>("background");

            hero = new Hero(_heroTexture, KBReader);
            background = new Background(_backgroundTexture);
        }
        
        public override void Update(GameTime gameTime)
        {
            hero.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            hero.Draw(spriteBatch);
        }
    }
}
