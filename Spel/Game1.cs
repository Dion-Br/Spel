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
    // Game states

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        enum GameState
        {
            MainMenu,
            Playing,
            GameOver
        }
        GameState CurrentGameState = GameState.Playing;
        MainMenu mainMenu;
        Playing playing;

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
            playing = new Playing(this, _graphics.GraphicsDevice, Content);
            mainMenu = new MainMenu(this, _graphics.GraphicsDevice, Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    mainMenu.Update(gameTime);
                    break;
                case GameState.Playing:
                    playing.Update(gameTime);
                    break;
                case GameState.GameOver:
                    break;
            };
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Clear
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            // TODO: Add your drawing code here

            // Background
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    mainMenu.Draw(gameTime, _spriteBatch);
                    break;
                case GameState.Playing:
                    playing.Draw(gameTime, _spriteBatch);
                    break;
                case GameState.GameOver:
                    break;
            };

            // End
            _spriteBatch.End();            

            base.Draw(gameTime);
        }
    }
}