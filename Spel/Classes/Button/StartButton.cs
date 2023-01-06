using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Spel.Classes.GameStates;

namespace Spel.Classes.Button
{
    internal class StartButton : cButton
    {

        public StartButton(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, int X, int Y) : base(game, graphicsDevice, content, X, Y)
        {
            _texture = content.Load<Texture2D>("play");
        }

        internal override void DoBtnFunction()
        {
            _game.ChangeState(new Playing(_game, _graphicsDevice, _content));
        }
    }
}
