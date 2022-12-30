using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Spel.Classes.Character;
using Spel.Classes.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace Spel.Classes.Levels
{
    class Level1 : Level
    {

        public Level1(GraphicsDevice graphicsDevice, ContentManager content) : base(graphicsDevice, content)
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
                {0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,3,3,0,0,0,0,0},
                {0,0,0,0,3,3,0,0,0,0,3,0,0,0,3,2,3,0,0,0,0,0},
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
