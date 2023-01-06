using Microsoft.Xna.Framework.Graphics;
using Spel.Classes.Animations;

namespace Spel.Classes.Character
{
    class dragonEnemy : Enemy
    {
        Animation runAnimation, attackAnimation, deathAnimation;

        public dragonEnemy(Texture2D texture, int startPos, int endPos, int height) : base(texture, startPos, endPos, height)
        {
            // Default waardes ingeven
            base.width = 32;
            base.height = 32;
            base.scale = 4;

            // Animaties ingeven.
            MakeAnimations();

            // Huidige animatie intialiseren.
            animationManager = new AnimationManager();
            animationManager.CurrentAnimation = runAnimation;
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
    }
}
