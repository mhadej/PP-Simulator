namespace Simulator.Maps
{
    public abstract class SmallMap : Map
    {
        protected List<IMappable>?[,] _fields;
        protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX > 20) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide (X)");
            if (sizeY > 20) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too tall (Y)");

            _fields = new List<IMappable>?[sizeX, sizeY];

            for (int x = 0; x < SizeX; x++)
            {
                for (int y = 0; y < SizeY; y++)
                {
                   _fields[x, y] = new List<IMappable>();
                }
            }
        }

        public override List<IMappable>? At(int x, int y) => _fields[x, y];
        public override List<IMappable>? At(Point p) => _fields[p.X, p.Y];

        public override void Move(IMappable mappable, Point source, Point dest)
        {
            Remove(mappable, source);
            Add(mappable, dest);
        }
        public override void Remove(IMappable mappable, Point p)
        {
            _fields[p.X, p.Y]?.Remove(mappable);
           mappable.InitMapAndPosition(this, default);
        }
        public override void Add(IMappable mappable, Point p)
        {
            _fields[p.X, p.Y]?.Add(mappable);
           mappable.InitMapAndPosition(this, p);
        }
    }
}