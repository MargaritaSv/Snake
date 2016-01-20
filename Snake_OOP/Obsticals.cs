using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_OOP
{
    public abstract class Obsticals : Objects
    {
        protected Obsticals(int x, int y)
            : base(x, y)
        {

        }
    }
}
