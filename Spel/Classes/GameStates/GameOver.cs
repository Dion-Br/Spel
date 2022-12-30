using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Spel.Classes.LevelDesign;
using Spel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spel.Classes.GameStates
{
    internal class GameOver : GameState
    {
        new Game1 _game;

        private Texture2D _backgroundTexture, _btnMenuTexture, _btnRetartTexture, _btnCloseTexture;
        private cButton btnMenu, btnRestart, btnClose;
        private Background background;

        public GameOver(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            // Game inladen
            _game = game;

            // Textures inladen
            _backgroundTexture = _content.Load<Texture2D>("gameover");
            _btnMenuTexture = _content.Load<Texture2D>("menu");
            _btnRetartTexture = _content.Load<Texture2D>("restart");
            _btnCloseTexture = _content.Load<Texture2D>("quit");


            // Initialiseren
            background = new Background(_backgroundTexture);
            btnMenu = new cButton(_btnMenuTexture, 610, 400);
            btnRestart = new cButton(_btnRetartTexture, 610, 480);
            btnClose = new cButton(_btnCloseTexture, 610, 560);

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);

            btnMenu.Draw(spriteBatch, _graphicsDevice);
            btnRestart.Draw(spriteBatch, _graphicsDevice);
            btnClose.Draw(spriteBatch, _graphicsDevice);
        }

        public override void Update(GameTime gameTime)
        {
            // Knoppen updaten
            btnMenu.Update();
            btnRestart.Update();
            btnClose.Update();

            // Actie voor als er op een menu knop is gedrukt
            if (btnMenu.Clicked)
                _game.ChangeState(new MainMenu(_game, _graphicsDevice, _content));

            if(btnRestart.Clicked)
                _game.ChangeState(new Playing(_game, _graphicsDevice, _content));

            if (btnClose.Clicked)
                Application.Exit();
        }
    }
}
