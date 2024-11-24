
namespace Simulator.Maps
{
    public class SmallTorusMap : SmallMap
    {
        public readonly int Size;
        public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) {  }
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