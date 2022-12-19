using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Spel.Interfaces;
using SharpDX.Direct3D9;
using System.Text.RegularExpressions;

namespace Spel.Classes
{
    // Bron jump + gravity: https://www.youtube.com/watch?v=ZLxIShw-7ac
    class Hero : IGameObject 
    {
        // Variabelen initialiseren
        private KeyboardReader inputReader;
        private Texture2D heroTexture;
        private Vector2 position;
        private Vector2 speed;
        private int scale, width, height;
        private SpriteEffects se = SpriteEffects.None;

        Animation runAnimation, attackAnimation, staticAnimation, jumpAnimation, deathAnimation;
        AnimationManager animationManager;

        public Hero(Texture2D texture, IInputReader inputReader)
        {
            this.heroTexture = texture;
            this.inputReader = (KeyboardReader)inputReader;

            this.speed = new Vector2(5, 5);
            this.position = new Vector2(0, 0);
            this.scale = 2;
            this.width = 64;
            this.height = 64;

            // Animaties ingeven.
            this.MakeAnimations();            

            // Huidige animatie intialiseren.
            this.animationManager = new AnimationManager();
            this.SetCurrentAnimation(staticAnimation);

        }        

        void SetCurrentAnimation(Animation animation)
        {
            animationManager.CurrentAnimation = animation;
        }

        public void Update(GameTime gameTime)
        {
            var direction = inputReader.ReadInput();
            bool moving = inputReader.ReadMovement();
            bool attack = inputReader.ReadAttack();

            CheckAnimationToSet(moving, attack);

            direction *= speed;
            position += direction;
            animationManager.CurrentAnimation.Update(gameTime);
            Move();
        }

        void CheckAnimationToSet(bool moving, bool attack)
        {

            if (inputReader.movement.HDirection == HDirection.Left)
            {
                se = SpriteEffects.FlipHorizontally;
            }
            if (inputReader.movement.HDirection == HDirection.Right)
            {
                se = SpriteEffects.None;
            }

            if (moving)
            {
                SetCurrentAnimation(runAnimation);
            }
            else
            {
                SetCurrentAnimation(staticAnimation);
            }

            if (attack)
            {
                SetCurrentAnimation(attackAnimation);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int rotation = 0;
            spriteBatch.Draw(heroTexture, position, animationManager.CurrentAnimation.CurrFrame.srcRectangle,
                Color.White, rotation, new Vector2(0, 0), scale, se, 0f);
        }

        private void Move()
        {
            int windowWidth = 1400;
            int windowHeight = 700;

            // X Positioning
            if (position.X > windowWidth - (this.width * scale))
            {
                position.X = windowWidth - (this.width * scale);
            }
            if (position.X < 0)
            {
                position.X = 0;
            }

            // Y positioning
            if (position.Y < windowHeight - (this.height * scale))
            {
                position.Y += 5;
            }
            if (position.Y > windowHeight - (this.height * scale))
            {
                position.Y = windowHeight - (this.height * scale);
            }
            if (position.Y < 0)
            {
                position.Y = 0;
            }
        }

        private void MakeAnimations()
        {
            runAnimation = new Animation();
            runAnimation.AddSpriteRow(this.width, this.height, 0, 11);

            attackAnimation = new Animation();
            attackAnimation.AddSpriteRow(this.width, this.height, 1, 6);

            staticAnimation = new Animation();
            staticAnimation.AddSpriteRow(this.width, this.height, 2, 6);

            jumpAnimation = new Animation();
            jumpAnimation.AddSpriteRow(this.width, this.height, 3, 3);

            deathAnimation = new Animation();
            deathAnimation.AddSpriteRow(this.width, this.height, 4, 3);
        }
    }
}
