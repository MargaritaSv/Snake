using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

            Console.BufferHeight = Console.WindowHeight; //fix the problem with snake out from console

            Random numberGenerator = new Random();
            Position food = new Position(numberGenerator.Next(0, Console.WindowHeight), numberGenerator.Next(0, Console.WindowWidth));

            Queue<Position> snakeElements = new Queue<Position>();

            for (int i = 0; i <= 5; i++)
            {
                snakeElements.Enqueue(new Position(0, i));
            }

            int currDirection = 0;

            while (true)
            {

                if (Console.KeyAvailable)
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

                Position snakeHead = snakeElements.Last();
                //                snakeElements.Dequeue();

                Position nextDirection = directions[currDirection];
                Position snakeNewHead = new Position(snakeHead.X + nextDirection.X, snakeHead.Y + nextDirection.Y);


                if (snakeNewHead.X == food.X && snakeNewHead.Y == food.Y)
                {
                    food = new Position(numberGenerator.Next(0, Console.WindowHeight), numberGenerator.Next(0, Console.WindowWidth));

                    //TODO: snake eat the food
                }
                else
                {
                    snakeElements.Dequeue();
                }

                snakeElements.Enqueue(snakeNewHead);

                Console.Clear();

                foreach (Position position in snakeElements)
                {
                    Console.SetCursorPosition(position.Y, position.X);
                    Console.Write("*");
                }

                Console.SetCursorPosition(food.Y, food.X);
                Console.WriteLine('@');

                Thread.Sleep(100);
            }
        }
    }
}
