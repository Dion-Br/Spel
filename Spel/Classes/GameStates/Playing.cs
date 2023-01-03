using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Spel.Classes.Character;
using Spel.Classes.Level;
using Spel.Classes.Levels;
using Spel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace Spel.Classes.GameStates
{
    internal class Playing : GameState
    {
        // Variabelen initialiseren
        new Game1 _game;
        private static int counter = 0;

        private Texture2D _heroTexture;

        private Hero hero;
        private KeyboardReader KBReader;
        internal Levels.Level level1, level2, currentLevel;

        public Playing(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            // Game inladen
            _game = game;
            _heroTexture = _content.Load<Texture2D>("sprite");


            KBReader = new KeyboardReader();
            hero = new Hero(_heroTexture, KBReader);

            Tiles.Content = _content;

            level1 = new Level1(graphicsDevice, _content);
            level2 = new Level2(graphicsDevice, _content);

            currentLevel = level1;
        }

        public override void Update(GameTime gameTime)
        {
            currentLevel.Update(gameTime);
            hero.Update(gameTime);
            foreach(CollisionTiles tile in currentLevel.map.CollisionTiles)
            {
                hero.Collision(tile.Rectangle, currentLevel.map.Width, currentLevel.map.Height);
            }

            foreach(var enemy in currentLevel.enemies)
            {
                // Hero zal de vijand doden door er langs bovenop te springen.
                if (hero.rectangle.TouchTopOf(enemy.rectangle))
                {
                    enemy.Die();
                    hero.KilledEnemy(true);
                }

                // Als we een enemy de hero raakt -> hero sterft
                if (hero.rectangle.Intersects(enemy.rectangle))
                {
                    if (!KBReader.ReadAttack())
                    {
                        // Hero sterft 
                        Hero.score = 0;
                        _game.ChangeState(new GameOver(_game, _graphicsDevice, _content));
                        counter = 0;
                    }
                    else
                    {
                        enemy.Die();
                        hero.KilledEnemy(false);
                    }
                }

                // Als we het level hebben gehaald
                if(Hero.score == currentLevel.MaxScore)
                {
                    counter++;
                    Hero.score = 0;
                    if (counter > 1)
                    {
                        _game.ChangeState(new WinnerState(_game, _graphicsDevice, _content));
                        counter = 0;
                    }
                    else
                    {
                        _game.ChangeState(new Playing(_game, _graphicsDevice, _content) { currentLevel = level2 });
                    }
                }
            }

            foreach(var star in currentLevel.stars)
            {
                if (hero.rectangle.Intersects(star.rectangle))
                {
                    star.Collected();
                }
            }

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            currentLevel.Draw(spriteBatch);
            hero.Draw(spriteBatch);
        }
    }
}
