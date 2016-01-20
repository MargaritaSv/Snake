using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_OOP
{
    public class Position : Moveable
    {

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;

        }
        public int X
        {
            get
            {
                throw new NotImplementedException();
            }

            private set { this.X = value; }
        }

        public int Y
        {
            get
            {
                throw new NotImplementedException();
            }

            private set { this.Y = value; }

        }
    }
}
