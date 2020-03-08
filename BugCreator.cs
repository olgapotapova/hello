using System;
using System.Collections.Generic;
using System.Text;

namespace Worm
{
    class BugCreator
    {
        private int mapWidht;
        private int mapHeight;
        private char sym;

        Random random = new Random();

        public BugCreator(int mapWidht, int mapHeight, char sym)
        {
            this.mapWidht = mapWidht;
            this.mapHeight = mapHeight;
            this.sym = sym;
        }
        public Point CreateBug()
        {
            int x = random.Next(2, mapWidht - 2);
            int y = random.Next(2, mapHeight - 2);
            return new Point(x, y, sym);
        }
    }
}
