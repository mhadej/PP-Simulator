using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public class SmallTorusMap : Map
    {
        public readonly int Size;
        private Rectangle mapa;

        public SmallTorusMap(int size)
        {
            if (size > 20 || size < 5)
            {
                throw new ArgumentOutOfRangeException("Wrong size!");
            }
            else
            {
                Size = size;
                mapa = new(0, 0, size - 1, size - 1);
            }
        }

        public override bool Exist(Point p)
        {
            return mapa.Contains(p);
        }

        public override Point Next(Point p, Direction d)
        {
            //Point going outside of map
            if (!mapa.Contains(p.Next(d)))
            {
                if     (p.Next(d).X == Size)
                {
                    return new Point(0, p.Y);
                }
                else if(p.Next(d).X == -1)
                {
                    return new Point(Size - 1, p.Y);
                }
                else if(p.Next(d).Y == Size)
                {
                    return new Point(p.X, 0);
                }
                else
                {
                    return new Point(0, Size - 1);
                }
            }
            return p.Next(d);
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            int edge = Size - 1;
            if(!mapa.Contains(p.NextDiagonal(d)))
            {
                //Point is goin above or right to the of map
                if(p.NextDiagonal(d).X == Size && p.NextDiagonal(d).Y == Size)
                {
                    return new Point(0, 0);
                }
                else if(p.NextDiagonal(d).X == Size)
                {
                    return new Point(0, p.NextDiagonal(d).Y);
                }
                else if (p.NextDiagonal(d).Y == Size)
                {
                    return new Point(p.NextDiagonal(d).X, 0);
                }
                //Point is goin below or left to the map
                else if (p.NextDiagonal(d).X < 0 && p.NextDiagonal(d).Y < 0)
                {
                    return new Point(edge, edge);
                }
                else if (p.NextDiagonal(d).X < 0)
                {
                    return new Point(edge, p.NextDiagonal(d).Y);
                }
                else if (p.NextDiagonal(d).Y < 0)
                {
                    return new Point(p.NextDiagonal(d).X, edge);
                }
            }
            return p.NextDiagonal(d) ;
        }
    }
}
