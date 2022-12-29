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
        internal Vector2 position, speed;
        internal SpriteEffects se = SpriteEffects.None;

        internal Texture2D enemyTexture;
        internal AnimationManager animationManager;

        private int start, end;

        public Enemy(Texture2D texture, int startPos, int endPos, int height)
        {
            end = endPos;
            start = startPos;
            enemyTexture = texture;
            speed = new Vector2(5, 5);
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
            MoveX();

            // Animatie updaten
            animationManager.CurrentAnimation.Update(gameTime);
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
    }
}
