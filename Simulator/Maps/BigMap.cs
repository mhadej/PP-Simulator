
namespace Simulator.Maps;

public abstract class BigMap : Map
{
    protected Dictionary<Point, List<IMappable>>? _fields = new();

    protected BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 1000) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide (X)");
        if (sizeY > 1000) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too tall (Y)");
    }


    public override List<IMappable>? At(Point p)
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

    public override List<IMappable>? At(int x, int y)
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

    public override void Add(IMappable mappable, Point p)
    {
        try
        {
            _fields?[p].Add(mappable);
        }
        catch(KeyNotFoundException)
        {
            _fields[p] = new List<IMappable>();
            _fields[p].Add(mappable);
        }
        mappable.InitMapAndPosition(this, p);
    }

    public override void Remove(IMappable mappable, Point p)
    {
        _fields?[p].Remove(mappable);
        mappable.InitMapAndPosition(this, default);
    }

    public override void Move(IMappable mappable, Point source, Point dest)
    {
        Remove(mappable, source);
        Add(mappable, dest);
    }
}
