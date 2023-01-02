using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using Spel.Classes.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel.Classes.Character
{
    class dragonEnemy : Enemy
    {
        private int width = 32, height = 32, scale = 4;
        Animation runAnimation, attackAnimation, deathAnimation;

        public dragonEnemy(Texture2D texture, int startPos, int endPos, int height) : base(texture, startPos, endPos, height)
        {
            // Animaties ingeven.
            MakeAnimations();

            // Huidige animatie intialiseren.
            animationManager = new AnimationManager();
            base.SetCurrentAnimation(runAnimation);
        }

        internal override void MakeAnimations()
        {
            // Set all the animation for the hero
            deathAnimation = new Animation();
            deathAnimation.AddSpriteRow(width, height, 0, 11);

            runAnimation = new Animation();
            runAnimation.AddSpriteRow(width, height, 1, 4);

            attackAnimation = new Animation();
            attackAnimation.AddSpriteRow(width, height, 2, 7);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isAlive)
            {
                spriteBatch.Draw(enemyTexture, position, animationManager.CurrentAnimation.CurrFrame.srcRectangle,
                Color.White, 0f, new Vector2(0, 0), scale, se, 0f);
            }
        }
    }
}
