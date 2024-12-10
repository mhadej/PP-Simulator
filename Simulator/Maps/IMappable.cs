namespace Simulator.Maps;
public interface IMappable
{
    void Symbol();
    void Go(Direction direction, bool output);
    void InitMapAndPosition(Map map, Point p);
    Point CurrentPosition();
}
