
namespace Simulator.Maps
{
    public class SmallSquareMap : SmallMap
    {
        public readonly int Size;        

        public SmallSquareMap(int size) : base(size, size) { }
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