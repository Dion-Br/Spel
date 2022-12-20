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
        public KeyboardReader inputReader { get; set; }
        public bool jump { get; set; } = false;
        bool hasJumped, reachedTop;

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

            this.speed = new Vector2(8, 5);
            this.position = new Vector2(50, 600);
            this.scale = 2;
            this.width = 64;
            this.height = 64;
            this.gravity = 10;
            this.hasJumped = true;

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
            // Richting waarheen we gaan
            var direction = inputReader.ReadInput();

            // Kijken of er beweging is (links of rechts)
            bool moving = inputReader.ReadMovement();

            // Kijken of hero aanvalt
            bool attack = inputReader.ReadAttack();
            
            // Juiste animatie plaatsen adhv van vorige meegegeven variabelen
            CheckAnimationToSet(moving, attack);

            // Richting krijgt snelheid mee
            direction *= speed;

            // Positie updaten met de richting
            position += direction;

            // Animatie updaten
            animationManager.CurrentAnimation.Update(gameTime);
            
            // Bewegen naar de posities die zijn berekend
            Move();
        }

        void CheckAnimationToSet(bool moving, bool attack)
        {
            // Sprite draaien naar de richting waarheen we bewegen 
            if (inputReader.movement.HDirection == HDirection.Left)
                se = SpriteEffects.FlipHorizontally;
            if (inputReader.movement.HDirection == HDirection.Right)
                se = SpriteEffects.None;

            // Run animatie als de hero beweegd
            if (moving)
                SetCurrentAnimation(runAnimation);
            else
                SetCurrentAnimation(staticAnimation);

            // Attack animatie als we aanvallen
            if (attack)
                SetCurrentAnimation(attackAnimation);

            // Jump animation als we springen / in de lucht zijn
            if (hasJumped) 
                SetCurrentAnimation(jumpAnimation);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Variabelen initialiseren
            int rotation = 0;

            // Hero tekenen
            spriteBatch.Draw(heroTexture, position, animationManager.CurrentAnimation.CurrFrame.srcRectangle,
                Color.White, rotation, new Vector2(0, 0), scale, se, 0f);
        }

        private void Move()
        {  
            // Horizontal movement 
            MoveX();

            // Vertical movement
            Jump();   
        }

        private void MoveX()
        {
            // Variabelen initialiseren
            int widthBorder = 1400;
            int rightBorder = widthBorder - (this.width * scale);

            // Hero mag niet uit de rechterkant van het scherm lopen
            if (position.X > rightBorder)
            {
                position.X = rightBorder;
            }
            // Hero mag niet uit de linkerkant van het scherm lopen
            if (position.X < 0)
            {
                position.X = 0;
            }
        }
        
        
        float i = 1, startingJumpPos = 600;

        private void Jump()
        {
            // Kijken of we op Jump knop hebben gedrukt
            jump = inputReader.Jump;

            // Variabelen initialiseren
            int heightBorder = 700;
            int bottomBorder = heightBorder - (this.height * scale);
            
            // Jump instellen 
            // Begin: Op jump gedrukt
            if (jump && !hasJumped && !reachedTop)
            {
                hasJumped = true;
                startingJumpPos = position.Y;
            }
            // Tweede: Omhoog gaan
            if (hasJumped && !reachedTop)
            {
                i *= 1.8f;
                position.Y -= Math.Max(30 - i, 7);
                speed.X = 9;
            }
            // Derde: Controleren of we de top hebben geraakt
            if (hasJumped && position.Y <= startingJumpPos - 150)
            {
                reachedTop = true;
            }
            // Vierde: Omlaag vallen
            if (hasJumped && reachedTop)
            {
                position.Y += 10;
            }       
            // Einde: We hebben onze startpositie bereikt
            if (position.Y >= startingJumpPos)
            {
                i = 1;
                speed.X = 8f;
                hasJumped = false;
                reachedTop = false;
                position.Y = startingJumpPos;
            }
        }

        private void MakeAnimations()
        {
            // Set all the animation for the hero
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
