using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spel.Classes.Button;
using Spel.Classes.LevelDesign;
using Spel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spel.Classes.GameStates
{
    internal class MainMenu : GameState
    {
        new Game1 _game;

        private Texture2D _backgroundTexture;
        private Background background;        

        public MainMenu(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            // Sleep zodat er niet tweemaal op een knop word gedrukt na game over
            Thread.Sleep(200);

            // Game inladen
            _game = game;

            // Textures inladen
            _backgroundTexture = _content.Load<Texture2D>("mainscreen");

            // Initialiseren
            background = new Background(_backgroundTexture);

            // Knoppen toevoegen
            buttons.Add(new StartButton(game, graphicsDevice, content, 610, 400));
            buttons.Add(new CloseButton(game, graphicsDevice, content, 610, 480));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Alle elementen tekenen
            background.Draw(spriteBatch);

            foreach(var button in buttons)
            {
                button.Draw(spriteBatch);
            }
        }

        public override void Update(GameTime gameTime)
        {
            // Knoppen updaten
            foreach (var button in buttons)
            {
                button.Update();
            }
        }
    }
}
