using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Console
{
    class Snake
    {
        static void Main()
        {
            Queue<Position> snakeElements = new Queue<Position>();

            // Position startPotision = new Position(0, 0);
            // snakeElements.Enqueue(startPotision);


            snakeElements.Enqueue(new Position(0, 0));
            snakeElements.Enqueue(new Position(0, 1));
            snakeElements.Enqueue(new Position(0, 2));
            snakeElements.Enqueue(new Position(0, 3));
            snakeElements.Enqueue(new Position(0, 4));
            snakeElements.Enqueue(new Position(0, 5));

            while (true)
            {
                Console.Clear();
            }
        }
    }
}
