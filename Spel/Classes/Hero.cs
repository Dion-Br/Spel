using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Spel.Interfaces;
using SharpDX.Direct3D9;

namespace Spel.Classes
{
    class Hero:IGameObject
    {
        private IInputReader inputReader;
        private Texture2D heroTexture;
        private Vector2 position;
        private Vector2 speed;
        private int scale, width, height;

        Animation animatie;
        public Hero(Texture2D texture, IInputReader inputReader)
        {
            this.heroTexture = texture;
            this.inputReader = inputReader;

            speed = new Vector2(5, 10);
            position = new Vector2(0, 0);
            scale = 1;
            this.width = 64;
            this.height = 64;

            animatie = new Animation();
            animatie.AddSpriteRow(this.width, this.height, 2, 6);

        }

        public void Update(GameTime gameTime)
        {
            var direction = inputReader.ReadInput();
            direction *= speed;
            position += direction;
            animatie.Update(gameTime);
            Move();
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            int rotation = 0;
            spriteBatch.Draw(heroTexture, position, animatie.CurrFrame.srcRectangle,
                Color.White, rotation, new Vector2(0, 0), scale, 0f, 0f);
        }

        private void Move()
        {
            int windowWidth = GraphicsDeviceManager.DefaultBackBufferWidth;
            int windowHeight = GraphicsDeviceManager.DefaultBackBufferHeight;

            // X Positioning
            if (position.X > windowWidth - (this.width * scale))
            {
                position.X = windowWidth - (this.width * scale);
            }
            if (position.X < 0)
            {
                position.X = 0;
            }

            // Y positioning
            if (position.Y > windowHeight - (this.height * scale))
            {
                position.Y = windowHeight - (this.height * scale);
            }
            if (position.Y < 0)
            {
                position.Y = 0;
            }

        }
    }
}
