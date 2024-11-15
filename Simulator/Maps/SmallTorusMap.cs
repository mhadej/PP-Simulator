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
            //Point going outside of map
            if (!mapa.Contains(p.NextDiagonal(d)))
            {
                if (p.NextDiagonal(d).X == Size)
                { 
                    if (d == (Direction)0)
                    { // going x+1 y+1
                        if (p.Y == edge)
                            return new Point(0, 0);
                        return new Point(0, p.Y + 1);
                    }
                    else
                    { // going x+1 y-1
                        if (p.Y == 0)
                            return new Point(0, edge);
                        return new Point(0, p.Y - 1);
                    }
                }
                else if (p.NextDiagonal(d).X == -1)
                {
                    if (d == (Direction)2)
                    { // going x-1 y-1
                        if (p.Y == 0)
                            return new Point(edge, edge);
                        return new Point(edge, p.Y - 1);
                    }
                    else
                    { // going x-1 y+1
                        if (p.Y == edge)
                            return new Point(edge, edge);
                        return new Point(edge, p.Y + 1);
                    }
                }
                else if (p.NextDiagonal(d).Y == Size)
                {
                    if (d == (Direction)0)
                    { // going x+1 y+1
                        if (p.Y == edge)
                            return new Point(0, 0);
                        return new Point(p.X + 1, 0);
                    }
                    else
                    { // going x-1 y+1
                        if (p.X == 0)
                            return new Point(0, 0);
                        return new Point(edge, 0);
                    }
                }
                else
                {
                    if (d == (Direction)1)
                    { // going x+1 y-1
                        if (p.Y == edge)
                            return new Point(0, edge);
                        return new Point(p.X + 1, edge);
                    }
                    else
                    { // going x-1 y-1
                        if (p.X == 0)
                            return new Point(0, edge);
                        return new Point(edge, edge);
                    }
                }
            }
            return p.NextDiagonal(d);
        }
    }
}
