using Microsoft.Xna.Framework.Graphics;
using Spel.Classes.Animations;

namespace Spel.Classes.Character
{
    class zombieEnemy : Enemy
    {
        Animation runAnimation, attackAnimation, deathAnimation;        

        public zombieEnemy(Texture2D texture, int startPos, int endPos, int height) : base(texture, startPos, endPos, height)
        {
            // Zombie trager maken
            base.speed.X = 2;
            base.width = 64;
            base.height = 64;
            base.scale = 2;

            // Animaties ingeven.
            MakeAnimations();

            // Huidige animatie intialiseren.
            animationManager.CurrentAnimation = runAnimation;
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
