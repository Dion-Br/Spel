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

        private int speed = 1;

        public int Speed
        {
            get { return speed; }
            set { 
                if(value > 0)
                    speed = value;
                else 
                    speed = 1;
            }
        }


        public Vector2 ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;

            if (state.IsKeyDown(Keys.Left))
            {
                direction.X -= speed;
                movement.HDirection = HDirection.Left;
                
            }
            if (state.IsKeyDown(Keys.Right)) 
            {
                direction.X += speed;
                movement.HDirection = HDirection.Right;
            }
            if (state.IsKeyDown(Keys.Up))
            {
                direction.Y -= speed;
                movement.VDirection = VDirection.Up;
            }
            if (state.IsKeyDown(Keys.Down))
            {
                direction.Y += speed;
                movement.VDirection = VDirection.Down;
            }
            return direction;
        }

        public bool ReadMovement()
        {
            // If any movement button is touched the function will return true
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.Down))
                return true;

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
