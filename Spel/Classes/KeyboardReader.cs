using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Spel.Classes.Character;
using Spel.Interfaces;

namespace Spel.Classes
{
    public class KeyboardReader : IInputReader
    {
        public Movement movement { get; private set; } = new Movement();
        public bool Jump { get; private set; }

        private int speed = 1;       


        public Vector2 ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = new Vector2(0,2);

            if (state.IsKeyDown(Keys.Left))
            {
                if (this.ReadMovement())
                {
                    direction.X = -speed;
                    movement.HDirection = HDirection.Left;                
                }
            }
            if (state.IsKeyDown(Keys.Right)) 
            {
                if (this.ReadMovement())
                {
                    direction.X = speed;
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
            // Toetsenbord inlezen
            KeyboardState state = Keyboard.GetState();

            // Als we links en recht ingedrukt hebben is movement false
            if (state.IsKeyDown(Keys.Left) && state.IsKeyDown(Keys.Right)) return false;
            // True als er beweging is
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
