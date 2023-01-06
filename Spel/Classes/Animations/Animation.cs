using Microsoft.Xna.Framework;
using System.Collections.Generic;
using IUpdateable = Spel.Interfaces.IUpdateable;

namespace Spel.Classes.Animations
{
    internal class Animation : IUpdateable
    {
        public AnimationFrame CurrFrame { get; set; }
        private List<AnimationFrame> frames;
        private int counter;

        public Animation()
        {
            frames = new List<AnimationFrame>();
        }

        private double secondCounter = 0;
        public void AddSpriteRow(int width, int height, int row, int numberOfSpritesInRow)
        {
            for (int i = 0; i < numberOfSpritesInRow; i++)
            {
                frames.Add(new AnimationFrame(new Rectangle(width * i, row * height, width, height)));
            }
        }

        public void Update(GameTime gameTime)
        {
            int fps = 15;
            CurrFrame = frames[counter];

            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;

            if (secondCounter >= 1d / fps)
            {
                counter++;
                secondCounter = 0;
            }

            if (counter >= frames.Count)
            {
                counter = 0;
            }
            CurrFrame = frames[counter];
            if (counter >= frames.Count)
            {
                counter = 0;
            }
        }
    }
}
