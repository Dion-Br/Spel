using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Spel.Classes.Animations;
using Spel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel.Classes.Character
{
    class Enemy : IGameObject
    {
        private SpriteEffects se = SpriteEffects.None;
        private int width = 32, height = 32, scale = 3;
        private Texture2D enemyTexture;
        private Vector2 position, speed;

        Animation runAnimation, attackAnimation, deathAnimation;
        AnimationManager animationManager;


        public Enemy(Texture2D texture)
        {
            enemyTexture = texture;
            position = new Vector2(500, 500);
            speed = new Vector2(5, 5);

            // Animaties ingeven.
            MakeAnimations();

            // Huidige animatie intialiseren.
            animationManager = new AnimationManager();
            SetCurrentAnimation(runAnimation);
        }

        void SetCurrentAnimation(Animation animation)
        {
            animationManager.CurrentAnimation = animation;
        }

        private void MakeAnimations()
        {
            // Set all the animation for the hero
            deathAnimation = new Animation();
            deathAnimation.AddSpriteRow(width, height, 0, 11);

            runAnimation = new Animation();
            runAnimation.AddSpriteRow(width, height, 1, 4);

            attackAnimation = new Animation();
            attackAnimation.AddSpriteRow(width, height, 2, 7);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(enemyTexture, position, animationManager.CurrentAnimation.CurrFrame.srcRectangle,
                Color.White, 0f, new Vector2(0,0), scale, se, 0f);
        }

        public void Update(GameTime gameTime)
        {
            MoveX();

            // Animatie updaten
            animationManager.CurrentAnimation.Update(gameTime);
        }

        public void MoveX()
        {
            // Variabelen initialiseren
            int widthBorder = 1400;
            int rightBorder = widthBorder - width * scale;

            position.X += speed.X;

            // Hero mag niet uit de rechterkant van het scherm lopen
            if (position.X > rightBorder)
            {
                speed.X *= -1;
                se = SpriteEffects.FlipHorizontally;
            }

            // Hero mag niet uit de linkerkant van het scherm lopen
            if (position.X < 0)
            {
                speed.X *= -1;
                se = SpriteEffects.None;
            }
        }
    }
}
