using Microsoft.Xna.Framework;
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
        public Movement movement { get; private set; } = new Movement();
        public bool Jump { get; private set; }

        private int speed = 1;       


        public Vector2 ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;

            if (state.IsKeyDown(Keys.Left))
            {
                if (this.ReadMovement())
                {
                    direction.X -= speed;
                    movement.HDirection = HDirection.Left;                
                }
            }
            if (state.IsKeyDown(Keys.Right)) 
            {
                if (this.ReadMovement())
                {
                    direction.X += speed;
                    movement.HDirection = HDirection.Right;
                }
            }
            if (state.IsKeyDown(Keys.Up))
            {
                Jump = true;
                movement.VDirection = VDirection.Up;             
            }
            else
            {
                Jump = false;
            }
            if (state.IsKeyDown(Keys.Down))
            {
                movement.VDirection = VDirection.Down;
            }
            return direction;
        }

        public bool ReadMovement()
        {
            // Getting keyboard state
            KeyboardState state = Keyboard.GetState();

            // Returning false if both left and right are being pressed at the same time
            if (state.IsKeyDown(Keys.Left) && state.IsKeyDown(Keys.Right)) return false;
            // Returning true if any movement is being made
            if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.Right)) return true;

            return false;
        }

        public bool ReadAttack()
        {
            KeyboardState state = Keyboard.GetState();
            bool attack = false;

            if (state.IsKeyDown(Keys.Space))
            {
                attack = true;
            }

            return attack;
        }
    }
}
