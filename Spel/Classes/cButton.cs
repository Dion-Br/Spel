using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.X3DAudio;
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
        public cButton(Texture2D texture, int X, int Y)
        {
            this.texture = texture;
            setPos(X, Y);

            rectangle = new Rectangle(x, y, width, height);
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
        private int x { get; set; }
        private int y { get; set; }

        public void setPos(int X, int Y)
        {
            this.x = X; 
            this.y = Y;
        }

        // Kleur property
        public Color color { get; set; } = Color.White;

        // Rechthoek over knop
        public Rectangle rectangle { get; private set; }
        
        // Teken functie
        public void Draw (SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            spriteBatch.Draw(texture, rectangle, color);
        }

        // Bool of er geklikt is op knop
        public bool Clicked { get; private set; }

        // Update functie
        public void Update()
        {
            // Kleur veranderen als muis over knop gaat
            var mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);

            if (this.rectangle.Contains(mousePosition))
            {
                this.color = Color.Gray;

                // Als er geklikt word op knop
                if (mouseState.LeftButton == ButtonState.Pressed)
                    Clicked = true;
                else
                    Clicked = false;
            }
            else
            {
                this.color = Color.White;
            }
        }
    }
}
