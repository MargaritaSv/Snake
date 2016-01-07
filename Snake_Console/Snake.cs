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

            Position[] directions = new Position[]
                {
                    new Position(0,1),//right
                    new Position(0,-1),//left
                    new Position(1,0),//down
                    new Position(-1,0)//up
                };


            Queue<Position> snakeElements = new Queue<Position>();

            for (int i = 0; i <= 5; i++)
            {
                snakeElements.Enqueue(new Position(0, i));
            }

            int currDirection = 0;

            while (true)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();

                if (userInput.Key == ConsoleKey.RightArrow)
                {
                    currDirection = 0;
                }

                if (userInput.Key == ConsoleKey.LeftArrow)
                {
                    currDirection = 1;
                }

                if (userInput.Key == ConsoleKey.DownArrow)
                {
                    currDirection = 2;
                }

                if (userInput.Key == ConsoleKey.UpArrow)
                {
                    currDirection = 3;
                }
            }
        }
    }
}
