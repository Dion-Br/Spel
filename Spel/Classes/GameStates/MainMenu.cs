using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Spel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace Spel.Classes.GameStates
{
    internal class MainMenu : GameState
    {
        private Texture2D _backgroundTexture;
        Background background;

        public MainMenu(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            _backgroundTexture = _content.Load<Texture2D>("background");
            background = new Background(_backgroundTexture);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
