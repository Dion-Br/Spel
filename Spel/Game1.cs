using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using Spel.Classes;
using Spel.Classes.GameStates;
using System;
using System.IO.Pipes;

namespace Spel
{
    public class Game1 : Game
    {
        private GameState CurrentGameState;
        private GameState NextGameState;

        public void ChangeState(GameState newState)
        {
            NextGameState = newState;
        }

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            // Setting window size
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1400;
            _graphics.PreferredBackBufferHeight = 787;
            _graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            CurrentGameState = new MainMenu(this, _graphics.GraphicsDevice, Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (NextGameState!= null)
            {
                CurrentGameState = NextGameState;
                NextGameState = null;
            }

            CurrentGameState.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Clear
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            CurrentGameState.Draw(gameTime, _spriteBatch);

            // End
            _spriteBatch.End();            

            base.Draw(gameTime);
        }
    }
}