using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using Spel.Classes;
using Spel.Classes.GameStates;
using Spel.Classes.Level;
using System;
using System.IO.Pipes;

namespace Spel
{
    public class Game1 : Game
    {
        // Game State instellingen
        private GameState CurrentGameState;
        private GameState NextGameState;
        public Map map;

        public void ChangeState(GameState newState)
        {
            NextGameState = newState;
        }

        // Variabelen declareren
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            // Grootte van scherm instellen
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1400;
            _graphics.PreferredBackBufferHeight = 787;
            _graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            map = new Map();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            CurrentGameState = new MainMenu(this, _graphics.GraphicsDevice, Content);
            Tiles.Content = Content;

            map.Generate(new int[,]
            {
                {0,0,0,0,1 },
                {0,0,0,1,1 },
                {0,0,1,1,1 },
                {0,1,0,1,0 },
                {1,0,0,1,0 }
            }, 128);
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Update huidige game state
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

            // Teken huidige game state
            CurrentGameState.Draw(gameTime, _spriteBatch);
            map.Draw(_spriteBatch);
            // End
            _spriteBatch.End();            

            base.Draw(gameTime);
        }
    }
}