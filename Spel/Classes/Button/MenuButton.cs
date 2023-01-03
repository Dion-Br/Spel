using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Spel.Classes.GameStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel.Classes.Button
{
    internal class MenuButton : cButton
    {
        public MenuButton(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, int X, int Y) : base(game, graphicsDevice, content, X, Y)
        {
            _texture = content.Load<Texture2D>("menu");
        }

        internal override void DoBtnFunction()
        {
            _game.ChangeState(new MainMenu(_game, _graphicsDevice, _content));
        }
    }
}
