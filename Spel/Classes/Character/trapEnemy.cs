using Microsoft.Xna.Framework.Graphics;
using Spel.Classes.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spel.Classes.Character
{
    class trapEnemy : Enemy
    {
        Animation staticAnimation;

        public trapEnemy(Texture2D texture, int startPos, int endPos, int height) : base(texture, startPos, endPos, height)
        {
            base.width = 32;
            base.height = 32;
            base.scale = 1;

            MakeAnimations();

            animationManager.CurrentAnimation = staticAnimation;
        }

        internal override void MakeAnimations()
        {
            staticAnimation = new Animation();
            staticAnimation.AddSpriteRow(width, height, 0, 1);
        }

        public override void MoveX()
        {
            position.X += 0;
        }
    }
}
