using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Console
{
    struct Position
    {
        public int X;//row
        public int Y;//col

        public Position(int x,int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
