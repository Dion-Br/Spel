using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel.Classes
{
    class AnimationFrame
    {
        public Rectangle srcRectangle { get; set; }

        public AnimationFrame(Rectangle srcRectangle)
        {
            this.srcRectangle = srcRectangle;
        }
    }
}
