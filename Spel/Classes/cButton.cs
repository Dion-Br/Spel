using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel.Classes
{
    internal class cButton
    {
        public Texture2D texture { get; set; }

        // Constructor 
        public cButton(Texture2D texture, int x, int y)
        {
            this.texture = texture;
            setPos(x, y);
        }

        // Grootte van de knop
        private int width { get; set; } = 175;
        private int height { get; set; } = 60;

        public void setSize(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        // Positie van de knop
        private int X { get; set; }
        private int Y { get; set; }

        public void setPos(int x, int y)
        {
            this.X = x; 
            this.Y = y;
        }
        
        // Teken functie
        public void Draw (SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            spriteBatch.Draw(texture, new Rectangle(X, Y, width, height), Color.White);
        }
    }
}
