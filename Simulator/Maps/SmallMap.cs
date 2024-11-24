namespace Simulator.Maps
{
    public abstract class SmallMap : Map
    {
        protected List<Creature>?[,] _fields;
        protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX > 20) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide (X)");
            if (sizeY > 20) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too tall (Y)");

            _fields = new List<Creature>?[sizeX, sizeY];

            for (int x = 0; x < SizeX; x++)
            {
                for (int y = 0; y < SizeY; y++)
                {
                   _fields[x, y] = new List<Creature>();
                }
            }
        }

        public override List<Creature>? At(int x, int y) => _fields[x, y];
        public override List<Creature>? At(Point p) => _fields[p.X, p.Y];

        public override void Move(Creature c, Point source, Point dest)
        {
            Remove(c, source);
            Add(c, dest);
        }
        public override void Remove(Creature c, Point p)
        {
            _fields[p.X, p.Y]?.Remove(c);
            c.InitMapAndPosition(this, default);
        }
        public override void Add(Creature c, Point p)
        {
            _fields[p.X, p.Y]?.Add(c);
            c.InitMapAndPosition(this, p);
        }
    }
}