using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spel.Classes.LevelDesign;
using Spel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spel.Classes.GameStates
{
    internal class MainMenu : GameState
    {
        new Game1 _game;

        private Texture2D _backgroundTexture, _btnStartTexture, _btnCloseTexture;
        private Background background;
        private cButton btnStart, btnClose;

        public MainMenu(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            // Game inladen
            _game = game;

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
            // Knoppen updaten
            btnStart.Update();
            btnClose.Update();

            // Actie voor als er op een menu knop is gedrukt
            if (btnStart.Clicked)
                _game.ChangeState(new Playing(_game, _graphicsDevice, _content));


            if (btnClose.Clicked)
                Application.Exit();
        }
    }
}
