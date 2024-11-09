using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    internal class SmallSquareMap : Map
    {
        public readonly int Size;

        public SmallSquareMap(int size)
        {
            if(size > 20 || size < 5)
            {
                throw new ArgumentOutOfRangeException("Wrong size!");
            }
            else
            {
                Size = size;
            }
        }
        public override bool Exist(Point p)
        {
            Rectangle mapa = new(0, 0, Size-1, Size-1);
            return mapa.Contains(p);
        }

        public override Point Next(Point p, Direction d)
        {
            Rectangle mapa = new(0, 0, Size - 1, Size - 1);
            if (mapa.Contains(p.Next(d)) == true)
            {
                return p.Next(d);
            }
            return p;
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            Rectangle mapa = new(0, 0, Size - 1, Size - 1);
            if (mapa.Contains(p.NextDiagonal(d)) == true)
            {
                return p.NextDiagonal(d);
            }
            return p;
        }
    }
}
