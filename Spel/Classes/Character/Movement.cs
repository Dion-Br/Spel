using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel.Classes.Character
{
    public enum VDirection
    {
        Up, Down
    }
    public enum HDirection
    {
        Right, Left
    }

    public class Movement
    {
        public HDirection HDirection { get; set; }
        public VDirection VDirection { get; set; }
    }
}
