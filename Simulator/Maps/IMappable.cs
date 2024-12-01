namespace Simulator.Maps;
public interface IMappable
{
    void Symbol();
    void Go(Direction direction);
    void InitMapAndPosition(Map map, Point p);

}
