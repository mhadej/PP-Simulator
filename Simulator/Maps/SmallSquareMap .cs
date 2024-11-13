using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public class SmallSquareMap : Map
    {
        public readonly int Size;
        private Rectangle mapa;

        public SmallSquareMap(int size)
        {
            if(size > 20 || size < 5)
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
            if (mapa.Contains(p.Next(d)) == true)
            {
                return p.Next(d);
            }
            return p;
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            if (mapa.Contains(p.NextDiagonal(d)) == true)
            {
                return p.NextDiagonal(d);
            }
            return p;
        }
    }
}
