
namespace Simulator.Maps
{
    /// <summary>
    /// Map of points.
    /// </summary>
    public abstract class Map
    {
        public abstract void Add(Creature c, Point p);
        public abstract void Remove(Creature c, Point p);
        public abstract void Move(Creature c, Point source, Point dest);
        public abstract List<Creature>? At(Point p);
        public abstract List<Creature>? At(int x, int y);

        protected Rectangle mapa;
        protected Map(int sizeX, int sizeY)
        {
            if (sizeX < 5) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too narrow (X)");
            if (sizeY < 5) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too short (Y)");

            SizeX = sizeX;
            SizeY = sizeY;

            mapa = new(0, 0, sizeX - 1, sizeY - 1);
        }
        public virtual bool Exist(Point p) => mapa.Contains(p);

        public int SizeX { get; set; }
        public int SizeY { get; set; }

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
