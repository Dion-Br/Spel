using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Spel.Classes.Character;
using Spel.Classes.Level;
using Spel.Classes.LevelDesign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel.Classes.Levels
{
    public abstract class Level
    {
        public Map map;

        internal Background background;
        internal Texture2D _backgroundTexture, _dragonTexture, _zombieTexture;
        internal List<Enemy> enemies;
        internal ContentManager _content;
        internal GraphicsDevice _graphicsDevice;

        public Level(GraphicsDevice graphicsDevice, ContentManager content)
        {
            // Initialisatie
            _content = content;
            _graphicsDevice = graphicsDevice;

            // Textures inladen
            enemies = new List<Enemy>();
            _dragonTexture = _content.Load<Texture2D>("enemy");
            _zombieTexture = _content.Load<Texture2D>("zombie");
            _backgroundTexture = _content.Load<Texture2D>("background");

            // Level genereren
            GenerateLevel();
        }

        public abstract void GenerateLevel();

        public void Update(GameTime gameTime)
        {
            foreach (var enemy in enemies)
                enemy.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            map.Draw(spriteBatch);
            foreach (var enemy in enemies)
                enemy.Draw(spriteBatch);
        }
    }
}
