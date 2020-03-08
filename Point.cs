using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Worm
{
    class Point
    {
        public int x;
        public int y;
        public char sym;
        public Point()
        {
            
        }
        public Point(int x, int y, char sym)
        {
           this.x = x;
           this.y = y;
           this.sym = sym;
           //x = _x;
           // y = _y;
           //sym = _sym;

        }

        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }


        public void Move(int offset, Direction direction)
        {

            if (direction == Direction.RIGHT)
            {
                x += offset;
            }
            else if (direction == Direction.LEFT)
            {
                x -= offset;
            }
            else if (direction == Direction.DOWN)
            {
                y += offset;
            }
            else if (direction == Direction.UP)
            {
                y -= offset;
            }
        }

        public bool IsHit(Point p)
        {
            return p.x == this.x && p.y == this.y;
        }
        public  void Draw(ConsoleColor color)
        {
            try
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = color;
                Console.Write(sym);
            }
            catch (ArgumentOutOfRangeException)

            {
                WriteGameOver();
                Console.ReadLine();
            }
            
            
        }

      

        public void Clear()
        {
            sym = ' ';
            Draw(ConsoleColor.DarkGreen);
        }
        public override string ToString()
        {
            return x + "," + "y" + "," + sym;
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