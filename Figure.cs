﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Worm
{
    class Figure
    {
        protected List<Point> pList;
        
        
         public virtual void Draw(ConsoleColor white)     
        {
            foreach (Point p in pList )
            {
                p.Draw(ConsoleColor.White);
            }
           
        }
      
        public virtual bool IsHit(Figure figure)
        {
            foreach(var p in pList)
            {
                if (figure.IsHit(p))
                    return true;
            }
            return false;
          
        }
        private bool IsHit( Point point)
        {
            foreach(var p in pList)
            {                               
                if (p.IsHit(point))
                    return true;               
            }
            return false;
         
     

        }

    }
}
