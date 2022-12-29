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
        private Texture2D _backgroundTexture, _heroTexture;

        private Hero hero;
        private Background background;
        private KeyboardReader KBReader;
        public Map map;

        public Playing(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            KBReader = new KeyboardReader();
            map = new Map();

            _heroTexture = _content.Load<Texture2D>("sprite");
            _backgroundTexture = _content.Load<Texture2D>("background");

            Tiles.Content = content;
            hero = new Hero(_heroTexture, KBReader);
            background = new Background(_backgroundTexture);

            map.Generate(new int[,]
            {
                {0,0,0,0,0,0,0,0,0,0,0 },
                {0,0,0,1,1,1,0,1,1,1,1 },
                {0,1,0,0,0,0,0,0,0,0,0 },
                {0,0,1,1,1,0,0,0,1,0,0 },
                {0,0,0,0,0,0,0,1,1,0,0 },
                {1,1,1,1,1,1,1,1,1,1,1 },
                {0,0,0,0,0,0,0,0,0,0,0 }
            }, 128);
        }
        
        public override void Update(GameTime gameTime)
        {
            hero.Update(gameTime);
            foreach(CollisionTiles tile in map.CollisionTiles)
            {
                hero.Collision(tile.Rectangle, map.Width, map.Height);
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            map.Draw(spriteBatch);
            hero.Draw(spriteBatch);
        }
    }
}
