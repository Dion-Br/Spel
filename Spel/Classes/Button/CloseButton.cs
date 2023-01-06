using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Forms;

namespace Spel.Classes.Button
{
    internal class CloseButton : cButton
    {
        public CloseButton(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, int X, int Y) : base(game, graphicsDevice, content, X, Y)
        {
            _texture = content.Load<Texture2D>("quit");
        }

        internal override void DoBtnFunction()
        {
            Application.Exit();
        }
    }
}
