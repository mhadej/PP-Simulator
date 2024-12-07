using System.Reflection.Metadata.Ecma335;

namespace Simulator.Maps;

public class BigBounceMap : BigMap
{
    public readonly int Size;
    public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

    public override Point Next(Point p, Direction d)
    {
        if(!this.Exist(p.Next(d)))
        {
            if(p.Next(d).X == SizeX)
            {
                return p.Next((Direction)3);
            }
            else if (p.Next(d).Y == SizeY)
            {
                return p.Next((Direction)2);
            }
            else if (p.Next(d).X == -1)
            {
                return p.Next((Direction)1);
            }
            else
            {
                return p.Next((Direction)0);
            }
        }
        return p.Next(d);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        if(!this.Exist(p.NextDiagonal(d)))
        {
            if(
                (p.X == 0           && p.Y == 0         && (d == Direction.Right || d == Direction.Left)) ||
                (p.X == 0           && p.Y == SizeY - 1 && (d == Direction.Up    || d == Direction.Down)) ||
                (p.X == SizeX - 1   && p.Y == 0         && (d == Direction.Up    || d == Direction.Down)) ||
                (p.X == SizeX - 1   && p.Y == SizeY - 1 && (d == Direction.Right || d == Direction.Left))
              )
            {
                return p;
            }
            else
            {
                return p.NextDiagonal(p.opposite(d));
            }
        }
        return p.NextDiagonal(d);
    }
}
