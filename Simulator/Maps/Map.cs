
namespace Simulator.Maps
{
    /// <summary>
    /// Map of points.
    /// </summary>
    public abstract class Map
    {
        protected Dictionary<Point, List<IMappable>>? _fields = new();
        protected Rectangle mapa;
        protected Map(int sizeX, int sizeY)
        {
            if (sizeX < 5) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too narrow (X)");
            if (sizeY < 5) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too short (Y)");

            SizeX = sizeX;
            SizeY = sizeY;

            mapa = new(0, 0, sizeX - 1, sizeY - 1);
        }
        public int SizeX { get; set; }
        public int SizeY { get; set; }

        public void Add(IMappable mappable, Point p)
        {
            try
            {
                _fields?[p].Add(mappable);
            }
            catch (KeyNotFoundException)
            {
                _fields[p] = new List<IMappable>();
                _fields[p].Add(mappable);
            }
            mappable.InitMapAndPosition(this, p);
        }
        public  void Remove(IMappable mappable, Point p)
        {
            _fields?[p].Remove(mappable);
            mappable.InitMapAndPosition(this, default);
        }
        public void Move(IMappable mappable, Point source, Point dest)
        {
            Remove(mappable, source);
            Add(mappable, dest);
        }
        public List<IMappable>? At(Point p)
        {
            try
            {
                return _fields?[p];
            }
            catch (KeyNotFoundException)
            {
                return new List<IMappable>();
            }
        }
        public List<IMappable>? At(int x, int y)
        {
            try
            {
                return _fields?[new Point(x, y)];
            }
            catch (KeyNotFoundException)
            {
                return new List<IMappable>();
            }
        }

        public virtual bool Exist(Point p) => mapa.Contains(p);
        /// <summary>
        /// Next position to the point in a given direction.
        /// </summary>
        /// <param name="p">Starting point.</param>
        /// <param name="d">Direction.</param>
        /// <returns>Next point.</returns>
        public abstract Point Next(Point p, Direction d);
        /// <summary>
        /// Next diagonal position to the point in a given direction 
        /// rotated 45 degrees clockwise.
        /// </summary>
        /// <param name="p">Starting point.</param>
        /// <param name="d">Direction.</param>
        /// <returns>Next point.</returns>
        public abstract Point NextDiagonal(Point p, Direction d);
    }
}
