using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Spel.Classes.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel.Classes.Character
{
    class zombieEnemy : Enemy
    {
        private int width = 64, height = 64, scale = 2;
        Animation runAnimation, attackAnimation, deathAnimation;        

        public zombieEnemy(Texture2D texture, int startPos, int endPos, int height) : base(texture, startPos, endPos, height)
        {
            // Zombie trager maken
            base.speed.X = 2;

            // Animaties ingeven.
            MakeAnimations();

            // Huidige animatie intialiseren.
            animationManager = new AnimationManager();
            base.SetCurrentAnimation(runAnimation);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(enemyTexture, position, animationManager.CurrentAnimation.CurrFrame.srcRectangle,
                Color.White, 0f, new Vector2(0, 0), scale, se, 0f);
        }

        internal override void MakeAnimations()
        {
            // Set all the animation for the hero
            attackAnimation = new Animation();
            attackAnimation.AddSpriteRow(width, height, 0, 9);

            deathAnimation = new Animation();
            deathAnimation.AddSpriteRow(width, height, 1, 8);

            runAnimation = new Animation();
            runAnimation.AddSpriteRow(width, height, 2, 4);
        }
    }
}
