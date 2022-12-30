using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Spel.Classes.Character;
using Spel.Classes.Level;
using Spel.Classes.LevelDesign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spel.Classes.Levels
{
    class Level2 : Level
    {
        public Map map;

        public Level2(GraphicsDevice graphicsDevice, ContentManager content) : base(graphicsDevice, content)
        {
            // Elementen die nodig zijn in het level inladen
            dragon = new dragonEnemy(_dragonTexture, 670, 800, 80);
            zombie = new zombieEnemy(_zombieTexture, 1050, 1300, 100);
            background = new Background(_backgroundTexture);
        }

        public override void GenerateLevel()
        {
            map = new Map();

            // 1 = Cobble met mos
            // 2 = Cobble
            // 3 = Steen

            map.Generate(new int[,]
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
            dragon.Update(gameTime);
            zombie.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            map.Draw(spriteBatch);
            dragon.Draw(spriteBatch);
            zombie.Draw(spriteBatch);
        }
    }
}
