using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worm
{
    class Worm : Figure
    {
        Direction direction;

        public  Worm(Point tail, int lenght, Direction _direction)
       
        {
            direction = _direction;
            pList = new List<Point>();
            for (int i = 0; i < lenght; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                pList.Add(p);
            }

        }


        public  void Move()
        {
            Point tail = pList.First();
            pList.Remove(tail);
            Point head = GetNextPoint();
            pList.Add(head);

            tail.Clear();
            head.Draw(ConsoleColor.DarkGreen);
        }
        public Point GetNextPoint()
        {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);          
            return nextPoint;
                               
        }

      

        public bool IsHitTail()
        {
            var head = pList.Last();
            for (int i = 0;i < pList.Count - 2; i++)
            {
                if (head.IsHit(pList[i]))

                    return true;
            }
            return false;
        }
        /*
        public void HandleKey(ConsoleKey key)

         
        {
            if (key == ConsoleKey.LeftArrow && direction != Direction.RIGHT)
                direction = Direction.LEFT;
            else if (key == ConsoleKey.RightArrow && direction != Direction.LEFT)
                direction = Direction.RIGHT;
            else if (key == ConsoleKey.DownArrow && direction != Direction.UP)
                direction = Direction.DOWN;
            else if (key == ConsoleKey.UpArrow && direction != Direction.DOWN)
                direction = Direction.UP;
        }
        */

        public void HandleKey1(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
                direction = Direction.LEFT;
            else if (key == ConsoleKey.RightArrow)
                direction = Direction.RIGHT;
            else if (key == ConsoleKey.DownArrow)
                direction = Direction.DOWN;
            else if (key == ConsoleKey.UpArrow)
                direction = Direction.UP;
        }
        public void HandleKey2(ConsoleKey key)

        {
            if (key == ConsoleKey.A && direction != Direction.RIGHT)
                direction = Direction.LEFT;
            else if (key == ConsoleKey.D && direction != Direction.LEFT)
                direction = Direction.RIGHT;
            else if (key == ConsoleKey.W && direction != Direction.DOWN)
                direction = Direction.UP;
            else if (key == ConsoleKey.S && direction != Direction.UP)
                direction = Direction.DOWN;

        }

        //internal bool Eat (Point food)
        public bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.sym = head.sym;
                pList.Add(food);
                return true;
            }
            else
                return false;

        }
        public bool Death(Point bug)
        {
            Point head = GetNextPoint();
            if (head.IsHit(bug))
            {
                bug.sym = head.sym;                
                return true;
            }
            else
                return false;
        }

    }
}
