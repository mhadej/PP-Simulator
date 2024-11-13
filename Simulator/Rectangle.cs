namespace Simulator
{
    public class Rectangle
    {
        public readonly int X1, Y1, X2, Y2;

        public Rectangle(int x1, int y1, int x2, int y2)
        {
            if (x1 == x2 || y1 == y2)
            {
                throw new ArgumentException ("Invalid coordinates (too slim rectangle)");
            }
            else
            {
                (X1, X2, Y1, Y2) = x1 < x2 ? (x1, x2, y1, y2) : (x2, x1, y2, y1);
            }
        }
    
        public Rectangle(Point p1, Point p2) : this(p1.X, p1.Y, p2.X, p2.Y) { }

        public bool Contains(Point point)
        {
            if(point.X <= X2 && point.X >= X1 && point.Y <= Y2 && point.Y >= Y1)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"({X1}, {Y1}), ({X2}, {Y2})";
        }
    }
}
