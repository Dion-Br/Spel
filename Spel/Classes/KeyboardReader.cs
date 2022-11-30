﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;
using Spel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel.Classes
{
    public class KeyboardReader : IInputReader
    {
        public bool IsDestinationInput => false;

        public Vector2 ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;

            if (state.IsKeyDown(Keys.Left))
            {
                direction.X -= 1;
            }
            if (state.IsKeyDown(Keys.Right)) 
            {
                direction.X += 1;
            }
            if (state.IsKeyDown(Keys.Up))
            {
                direction.Y -= 1;
            }
            if (state.IsKeyDown(Keys.Down))
            {
                direction.Y += 1;
            }
            return direction;

        }

        public bool ReadMovement()
        {
            KeyboardState state = Keyboard.GetState();
            bool moving = false;
            if (state.IsKeyDown(Keys.Left))
            {
                moving = true;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                moving = true;
            }
            if (state.IsKeyDown(Keys.Up))
            {
                moving = true;
            }
            if (state.IsKeyDown(Keys.Down))
            {
                moving = true;
            }
            return moving;
        }
    }
}
