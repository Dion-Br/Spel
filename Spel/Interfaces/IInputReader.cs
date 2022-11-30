using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel.Interfaces
{
    internal interface IInputReader
    {
        Vector2 ReadInput();
        bool ReadMovement();
        public bool IsDestinationInput { get; }

    }
}
