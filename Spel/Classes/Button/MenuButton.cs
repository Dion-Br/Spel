using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel.Classes.Button
{
    internal class MenuButton : cButton
    {
        public MenuButton(ContentManager content, int X, int Y) : base(content, X, Y)
        {
            _texture = content.Load<Texture2D>("menu");
        }
    }
}
