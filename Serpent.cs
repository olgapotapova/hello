using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worm
{
    class Serpent : Figure
    {
        Direction direction;
        public Serpent(Point tail, int lenght, Direction _direction)
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



        public void Move()
        {
            Point tail = pList.First();
            pList.Remove(tail);
            Point head = GetNextPoint();
            pList.Add(head);

            tail.Clear();
            head.Draw();
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
            for (int i = 0; i < pList.Count - 2; i++)
            {
                if (head.IsHit(pList[i]))

                    return true;
            }
            return false;
        }
        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.NumPad1)
                direction = Direction.LEFT;
            else if (key == ConsoleKey.NumPad4)
                direction = Direction.RIGHT;
            else if (key == ConsoleKey.NumPad2)
                direction = Direction.DOWN;
            else if (key == ConsoleKey.NumPad3)
                direction = Direction.UP;
        
     
        }
    }
}
