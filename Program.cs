using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Worm;


namespace Worm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25);
            Walls walls = new Walls(80, 25);
            walls.Draw();

            Point p = new Point(4, 5, '*');
            Worm worm = new Worm(p, 4, Direction.RIGHT);
            worm.Draw(ConsoleColor.Yellow);
            Point n = new Point(14, 15, '.');
            Serpent serpent = new Serpent(n, 6, Direction.LEFT);
            serpent.Draw();


            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if ( walls.IsHit(worm) || worm.IsHitTail() || serpent.IsHitTail() )
                {
                    break;
                }
                if (worm.Eat(food) )
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    worm.Move();
                    serpent.Move();
                }
                Thread.Sleep(200);
                                    
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    worm.HandleKey(key.Key);

                }
                Thread.Sleep(100);
                //worm.Move();
                //serpent.Move();
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    worm.HandleKey(key.Key);
                    serpent.HandleKey(key.Key);
                }
            }
            WriteGameOver();
            Console.ReadLine();
        }

        static void WriteGameOver()
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++);
            yOffset++;
        }

        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }

     
    
    }
}