namespace Simulator.Maps;

public class BigTorusMap : BigMap
{
    public readonly int Size;
    public BigTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }
    public override Point Next(Point p, Direction d)
    {
        var next = p.Next(d);
        return new Point((next.X + SizeX) % SizeX, (next.Y + SizeY) % SizeY);
    }
    public override Point NextDiagonal(Point p, Direction d)
    {
        var nextDiag = p.NextDiagonal(d);
        return new Point((nextDiag.X + SizeX) % SizeX, (nextDiag.Y + SizeY) % SizeY);
    }
}
