using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Spel.Classes.Character;
using Spel.Classes.Collectable;
using Spel.Classes.GameStates;
using Spel.Classes.Level;
using Spel.Classes.LevelDesign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel.Classes.Levels
{
    class Level1 : Level
    {
        public Level1(GraphicsDevice graphicsDevice, ContentManager content) : base(graphicsDevice, content)
        {
            // Elementen die nodig zijn in het level inladen
            stars.Add(new Star(content, 800, 650));
            stars.Add(new Star(content, 1000, 500));
            
            enemies.Add(new dragonEnemy(_dragonTexture, 350, 550, 80));
            enemies.Add(new zombieEnemy(_zombieTexture, 1050, 1300, 100));
            background = new Background(_backgroundTexture);

            MaxScore = 4;
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
                {0,0,0,0,3,3,0,0,0,0,3,0,0,0,3,3,3,0,0,0,0,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            }, 64);
        }
    }
}
