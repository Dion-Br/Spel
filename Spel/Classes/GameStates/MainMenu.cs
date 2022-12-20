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
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace Spel.Classes.GameStates
{
    internal class MainMenu : GameState
    {
        private Texture2D _backgroundTexture, _btnStartTexture, _btnCloseTexture;
        private Background background;
        private cButton btnStart, btnClose;

        public MainMenu(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            // Textures inladen
            _backgroundTexture = _content.Load<Texture2D>("mainscreen");
            _btnStartTexture = _content.Load<Texture2D>("play");
            _btnCloseTexture = _content.Load<Texture2D>("quit");

            // Initialiseren
            background = new Background(_backgroundTexture);
            btnStart = new cButton(_btnStartTexture, 610, 400);
            btnClose = new cButton(_btnCloseTexture, 610, 480);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            btnStart.Draw(spriteBatch, _graphicsDevice);
            btnClose.Draw(spriteBatch, _graphicsDevice);
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
