using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Spel.Classes.Button;
using Spel.Classes.LevelDesign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel.Classes.GameStates
{
    internal class WinnerState : GameState
    {
        private Texture2D _backgroundTexture;
        private Background background;

        public WinnerState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            // Textures inladen
            _backgroundTexture = _content.Load<Texture2D>("gameoverwin");

            // Initialiseren
            background = new Background(_backgroundTexture);

            buttons.Add(new MenuButton(game, graphicsDevice, content, 610, 400));
            buttons.Add(new RestartButton(game, graphicsDevice, content, 610, 480));
            buttons.Add(new CloseButton(game, graphicsDevice, content, 610, 560));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Alle elementen tekenen
            background.Draw(spriteBatch);

            foreach (var button in buttons)
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
