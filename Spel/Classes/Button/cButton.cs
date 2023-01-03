using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.X3DAudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel.Classes.Button
{
    abstract class cButton
    {
        protected Game1 _game;
        protected GraphicsDevice _graphicsDevice;
        protected ContentManager _content;

        internal Texture2D _texture;

        // Constructor 
        public cButton(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, int X, int Y)
        {
            _game = game;
            _graphicsDevice = graphicsDevice;
            _content = content;


            setPos(X, Y);
            rectangle = new Rectangle(x, y, width, height);
        }

        // Grootte van de knop
        internal int width { get; set; } = 175;
        internal int height { get; set; } = 60;

        public void setSize(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        // Positie van de knop
        internal int x { get; set; }
        internal int y { get; set; }

        public void setPos(int X, int Y)
        {
            x = X;
            y = Y;
        }

        // Kleur property
        public Color color { get; set; } = Color.White;

        // Rechthoek over knop
        public Rectangle rectangle { get; private set; }

        // Bool of er geklikt is op knop
        public bool Clicked { get; private set; }

        // Update functie
        public void Update()
        {
            // Kleur veranderen als muis over knop gaat
            var mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);

            if (rectangle.Contains(mousePosition))
            {
                color = Color.Gray;

                // Als er geklikt word op knop
                if (mouseState.LeftButton == ButtonState.Pressed)
                    Clicked = true;
                else
                    Clicked = false;
            }
            else
            {
                color = Color.White;
            }

            if (Clicked)
            {
                DoBtnFunction();
            }
        }

        internal abstract void DoBtnFunction();

        // Teken functie
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, rectangle, color);
        }
    }
}
