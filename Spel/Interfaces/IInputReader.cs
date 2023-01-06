using Microsoft.Xna.Framework;

namespace Spel.Interfaces
{
    internal interface IInputReader
    {
        Vector2 ReadInput();

        bool ReadMovement();

        bool ReadAttack();
    }
}
