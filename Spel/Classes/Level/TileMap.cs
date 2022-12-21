using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel.Classes.Level
{
    public class TileMap
    {
        public enum TileType
        {
            None,
            Stone,
            Wall
        }

        public TileType Type { get; private set; }

        public TileMap(TileType type)
        {
            this.Type = type;
        }
    }
}
