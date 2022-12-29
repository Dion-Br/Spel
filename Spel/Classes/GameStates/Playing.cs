using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Spel.Classes.Character;
using Spel.Classes.Level;
using Spel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace Spel.Classes.GameStates
{
    internal class Playing : GameState
    {
        // Variabelen initialiseren
        private Texture2D _backgroundTexture, _heroTexture, _dragonTexture, _zombieTexture;

        private Hero hero;
        private Enemy dragon, zombie;
        private Background background;
        private KeyboardReader KBReader;
        private Map level1, level2, currentLevel; 

        public Playing(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            KBReader = new KeyboardReader();

            _dragonTexture = _content.Load<Texture2D>("enemy");
            _zombieTexture = _content.Load<Texture2D>("zombie");
            _heroTexture = _content.Load<Texture2D>("sprite");
            _backgroundTexture = _content.Load<Texture2D>("background");

            Tiles.Content = content;
            hero = new Hero(_heroTexture, KBReader);
            dragon = new dragonEnemy(_dragonTexture, 650, 800, 80);
            zombie = new zombieEnemy(_zombieTexture, 1000, 1300, 150);
            background = new Background(_backgroundTexture);

            GenerateLevels();
            currentLevel = level2;
        }

        private void GenerateLevels()
        {
            level1 = new Map();
            level2 = new Map();

            level1.Generate(new int[,]
            {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0},
                {0,0,0,0,1,1,0,0,0,0,1,0,0,0,1,1,1,0,0,0,0,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            }, 64);

            level2.Generate(new int[,]
            {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0},
                {0,1,0,1,1,1,1,1,1,0,1,0,0,0,1,1,1,0,0,0,0,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            }, 64);
        }

        public override void Update(GameTime gameTime)
        {
            hero.Update(gameTime);
            dragon.Update(gameTime);
            zombie.Update(gameTime);
            foreach(CollisionTiles tile in currentLevel.CollisionTiles)
            {
                hero.Collision(tile.Rectangle, currentLevel.Width, currentLevel.Height);
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            currentLevel.Draw(spriteBatch);
            dragon.Draw(spriteBatch);
            zombie.Draw(spriteBatch);
            hero.Draw(spriteBatch);
        }

        public void NextLevel()
        {
            currentLevel = level2;
        }
    }
}
