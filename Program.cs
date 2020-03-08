using System;
using System.Collections.Generic;
using System.Threading;


namespace Worm
{
    class Program
    {



        // public static readonly Worm fSerpent ;


        // public static Worm fSeprent{ get; private set; }
        //public class FSeprent : Worm

        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25);
            Walls walls = new Walls(80, 25);
            walls.Draw();



            Point p1 = new Point(4, 5, '*');
            Point p2 = new Point(44, 15, '.');
            Point p3 = new Point(14, 25, '#');

            BugCreator bugCreator = new BugCreator(80, 25, '#');
            Point bug = bugCreator.CreateBug();
            bug.Draw(ConsoleColor.Red);


            Worm fWormMain = new Worm(p1, 4, Direction.RIGHT);
            Worm fSeprent = new Worm(p2, 6, Direction.RIGHT);
            //Draw(fWormMain);              
            //Draw(fSeprent);
            fWormMain.Draw(ConsoleColor.DarkGreen);
            fSeprent.Draw(ConsoleColor.DarkBlue);
            Worm worm = (Worm)fWormMain;
            Worm serpent = (Worm)fSeprent;


            List<Worm> worms = new List<Worm>();
            worms.Add(fSeprent);
            worms.Add(fWormMain);

            /*
            foreach (var f in worms)
            {
                f.HandleKey(ConsoleKey key);
             {

                }
            }
            static void HandleKey(Worm worm)
            {
                worm.HandleKey(HandleKey);
            }*/


            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw(ConsoleColor.Yellow);

            while (true)
            {
                if (walls.IsHit(worm) || worm.IsHitTail() || fSeprent.IsHitTail() )
                {
                    break;
                }
                if (worm.IsHitTail()|| worm.Death(bug))
                {
                    break;
                }

                if (worm.Eat(food) || fSeprent.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw(ConsoleColor.Yellow);                   
                }
                else
                {
                    worm.Move();
                    // serpent.Move();
                }
                Thread.Sleep(200);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    fWormMain.HandleKey1(key.Key);
                    fSeprent.HandleKey2(key.Key);

                }
                Thread.Sleep(100);

                worm.Move();
                serpent.Move();

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