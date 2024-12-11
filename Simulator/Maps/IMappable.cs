using System.Globalization;

namespace Simulator.Maps;
public interface IMappable
{
    public char Symbol { get; }

    public string ToString();
    void Go(Direction direction, bool output);
    void InitMapAndPosition(Map map, Point p);
}
