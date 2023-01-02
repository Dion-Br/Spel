using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Spel.Classes.Animations;
using Spel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Spel.Classes.Character
{
    abstract class Enemy : IGameObject
    {
        public Rectangle rectangle;
        public bool isAlive { get; private set; }

        internal Vector2 position, speed;
        internal SpriteEffects se = SpriteEffects.None;

        internal Texture2D enemyTexture;
        internal AnimationManager animationManager;

        private int start, end;

        public Enemy(Texture2D texture, int startPos, int endPos, int height)
        {
            end = endPos;
            start = startPos;

            isAlive = true;

            enemyTexture = texture;            
            rectangle = new Rectangle((int)position.X, (int)position.Y, 64, 64);

            speed = new Vector2(3, 3);
            position = new Vector2(startPos, (700 - height));

            // Animaties ingeven.
            MakeAnimations();

            // Huidige animatie intialiseren.
            animationManager = new AnimationManager();
        }

        internal void SetCurrentAnimation(Animation animation)
        {
            animationManager.CurrentAnimation = animation;
        }

        internal abstract void MakeAnimations();

        public abstract void Draw(SpriteBatch spriteBatch);

        public void Update(GameTime gameTime)
        {
            if (isAlive)
            {
                // Rectangle opnemen voor collisions
                rectangle.X = (int)position.X;
                rectangle.Y = (int)position.Y;

                MoveX();

                // Animatie updaten
                animationManager.CurrentAnimation.Update(gameTime);
            }
        }

        public virtual void MoveX()
        {
            // Variabelen initialiseren
            position.X += speed.X;

            // Enemey mag niet verder dan eindpositie
            if (position.X >= end)
            {
                speed.X *= -1;
                se = SpriteEffects.FlipHorizontally;
            }

            // Enemy mag niet verder dan startpositie
            if (position.X <= start)
            {
                speed.X *= -1;
                se = SpriteEffects.None;
            }
        }

        public void Die()
        {
            //Dood animatie..

            // Enemy sterft en is niet meer aanraakbaar
            isAlive = false;
            rectangle.Y = -500;
        }
    }
}
