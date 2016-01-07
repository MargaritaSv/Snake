﻿using System;
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
            byte right = 0;
            byte left = 1;
            byte down = 2;
            byte up = 3;

            double sleepTime = 100;
            int lastFoodTime = 0;
            int foodDissapearTime = 8000;
            int negativePoints = 0;

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

            int currDirection = right;

            while (true)
            {
                negativePoints++;//when we move negative points up up 

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo userInput = Console.ReadKey();

                    if (userInput.Key == ConsoleKey.RightArrow)
                    {

                        if (currDirection != left)
                        {
                            currDirection = right;

                        }
                    }

                    if (userInput.Key == ConsoleKey.LeftArrow)
                    {
                        if (currDirection != right)
                        {
                            currDirection = left;

                        }
                    }

                    if (userInput.Key == ConsoleKey.DownArrow)
                    {
                        if (currDirection != up)
                        {
                            currDirection = down;

                        }
                    }

                    if (userInput.Key == ConsoleKey.UpArrow)
                    {
                        if (currDirection != down)
                        {
                            currDirection = up;
                        }
                    }
                }

                Position snakeHead = snakeElements.Last();

                Position nextDirection = directions[currDirection];
                Position snakeNewHead = new Position(snakeHead.X + nextDirection.X, snakeHead.Y + nextDirection.Y);

                if (snakeNewHead.X < 0)
                {
                    snakeNewHead.X = Console.WindowHeight - 1;
                }

                if (snakeNewHead.Y < 0)
                {
                    snakeNewHead.Y = Console.WindowWidth - 1;
                }

                if (snakeNewHead.X >= Console.WindowHeight)
                {
                    snakeNewHead.X = 0;
                }

                if (snakeNewHead.Y >= Console.WindowWidth)
                {
                    snakeNewHead.Y = 0;
                }
                /*
                                if (snakeNewHead.X < 0 || snakeNewHead.Y < 0 || snakeNewHead.X >= Console.WindowHeight || snakeNewHead.Y >= Console.WindowWidth)
                                {
                                    Console.SetCursorPosition(0, 0);
                                    Console.WriteLine("Game over!"); //TODO: middle position
                                    int userPoints = ((snakeElements.Count - 6) * 100) - negativePoints; //TODO:
                                    Console.WriteLine("Your points are {0}", userPoints);
                                    return;
                                }
                                */
                if (snakeElements.Contains(snakeNewHead))
                {

                    Console.WriteLine("Your snake cannot through his body. ");
                    break;
                }

                snakeElements.Enqueue(snakeNewHead);
                Console.SetCursorPosition(snakeNewHead.Y, snakeNewHead.X);
                Console.Write("*");



                if (snakeNewHead.X == food.X && snakeNewHead.Y == food.Y)
                {
                    //feeding the snake
                    do
                    {
                        food = new Position(numberGenerator.Next(0, Console.WindowHeight), numberGenerator.Next(0, Console.WindowWidth));

                    } while (snakeElements.Contains(food));

                    lastFoodTime = Environment.TickCount;

                    Console.SetCursorPosition(food.Y, food.X);
                    Console.Write('@');

                    sleepTime--;
                }
                else
                {
                    //move
                    Position last = snakeElements.Dequeue();
                    Console.SetCursorPosition(last.Y, last.X);//col,row
                    Console.Write(" ");
                }

                if (Environment.TickCount - lastFoodTime >= foodDissapearTime)
                {
                    negativePoints += 50;

                    Console.SetCursorPosition(food.Y, food.X);
                    Console.Write(" ");

                    do
                    {
                        food = new Position(numberGenerator.Next(0, Console.WindowHeight), numberGenerator.Next(0, Console.WindowWidth));

                    } while (snakeElements.Contains(food));

                    lastFoodTime = Environment.TickCount;
                }

                Console.SetCursorPosition(food.Y, food.X);
                Console.Write('@');

                sleepTime -= 0.01;

                Thread.Sleep((int)sleepTime);
            }
        }
    }
}
